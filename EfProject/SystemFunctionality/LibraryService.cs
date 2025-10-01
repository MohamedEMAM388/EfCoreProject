using EfProject.Contexts;
using EfProject.Models;
using EfProject.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfProject.SystemFunctionality
{
    public static class LibraryService
    {
        public static string BorrowBook(LibraryManagementSystemContext dbContext, int memberId, int bookId)
        {
            var member = dbContext.Members.Find(memberId);
            if (member is null) return "Error: Member not found.";
            if (member.status == MemberStatus.Suspended) return "Error: Member account is suspended.";

            var book = dbContext.Books.Find(bookId);
            if (book is null) return "Error: Book not found.";
            if (book.AvailableCopies <= 0) return "Book is not available for borrowing.";

            var loan = new Loan { Status = LoanStatus.Borrowed };
            dbContext.Loans.Add(loan);
            dbContext.SaveChanges();

            dbContext.MemberLoans.Add(new MemberLoans
            {
                BookId = bookId,
                MemberId = memberId,
                LoanId = loan.Id,
                DueDate = loan.LoanDate.AddDays(14)
            });
            book.AvailableCopies--;
            dbContext.SaveChanges();

            return $"Book '{book.Title}' borrowed by '{member.Name}'. Loan ID: {loan.Id}";
        }

        public static string ReturnBookWithCheck(LibraryManagementSystemContext dbContext, int loanId, DateTime returnDate)
        {
            var loanInfo = dbContext.MemberLoans
                .Include(ml => ml.Book)
                .Include(ml => ml.Loan)
                .FirstOrDefault(ml => ml.LoanId == loanId);

            if (loanInfo is null) return "Error: Loan not found.";

            loanInfo.ReturnDate = returnDate;
            loanInfo.Book.AvailableCopies++;

            if (returnDate > loanInfo.DueDate)
            {
                var overdueDays = (returnDate - loanInfo.DueDate).Days;
                var fineAmount = overdueDays * 10m;
                var fine = new Fine
                {
                    Amount = fineAmount,
                    IssuedDate = DateTime.Now,
                    LoanId = loanId,
                    Status = FineStatus.Pending
                };
                dbContext.Fines.Add(fine);
                loanInfo.Loan.Status = LoanStatus.Overdue;

                var member = dbContext.Members.Find(loanInfo.MemberId);
                if (member != null) member.status = MemberStatus.Suspended;

                dbContext.SaveChanges();
                return $"Book returned late. Fine of {fineAmount:C} issued. Member suspended.";
            }
            else
            {
                loanInfo.Loan.Status = LoanStatus.Returned;
                dbContext.SaveChanges();
                return "Book returned on time.";
            }
        }

        public static string PayFine(LibraryManagementSystemContext dbContext, int fineId)
        {
            var fine = dbContext.Fines.Find(fineId);
            if (fine is null || fine.Status == FineStatus.Paid)
                return $"Error: Fine {fineId} not found or already paid.";

            fine.PaidDate = DateTime.Now;
            fine.Status = FineStatus.Paid;

            var memberLoan = dbContext.MemberLoans.FirstOrDefault(ml => ml.LoanId == fine.LoanId);
            if (memberLoan != null)
            {
                var memberId = memberLoan.MemberId;
                var hasOtherFines = dbContext.Fines.Any(f =>
                    dbContext.MemberLoans.Any(ml => ml.LoanId == f.LoanId && ml.MemberId == memberId) &&
                    f.Status == FineStatus.Pending && f.Id != fineId);

                if (!hasOtherFines)
                {
                    var member = dbContext.Members.Find(memberId);
                    if (member != null)
                    {
                        member.status = MemberStatus.Active;
                        dbContext.SaveChanges();
                        return $"Fine {fineId} paid. All fines cleared. Member reactivated.";
                    }
                }
            }

            dbContext.SaveChanges();
            return $"Fine {fineId} paid. Member still has other fines.";
        }
    }
}
