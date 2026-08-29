using EfProject.Contexts;
using EfProject.Models;
using EfProject.Models.Enums;
using EfProject.SystemFunctionality;
using Microsoft.EntityFrameworkCore;

namespace EfProject
{
    internal class Program
    {




        static void Main(string[] args)
        {
            using LibraryManagementSystemContext dbContext = new LibraryManagementSystemContext();

            #region DataSeed
            //bool isSeeded = LibraryDbContextSeed.DataSeed(dbContext);

            //Console.WriteLine(isSeeded ? "Data Seeded Successfully" : "Data Seeding Failed or Already Seeded");

            #endregion


            #region System Functionality
            //int memberid = 15, bookid = 1;
            //var LoanId = dbContext.MemberLoans.FirstOrDefault(ML => ML.MemberId == memberid)?.LoanId ?? 0;
            //var fineId = dbContext.Fines.FirstOrDefault(F => F.LoanId == LoanId)?.Id ?? 0;


            //var BorrowBook = LibraryService.BorrowBook(dbContext, memberid, bookid);
            //Console.WriteLine(BorrowBook);


            //var ReturnDate = new DateTime(2025, 10, 18);

            //var ReturnBook = LibraryService.ReturnBookWithCheck(dbContext, LoanId, ReturnDate);
            //Console.WriteLine(ReturnBook);


            //var PayFine = LibraryService.PayFine(dbContext, fineId);
            //Console.WriteLine(PayFine); 
            #endregion

            #region Data Manipulation 

            #region Retrieve the book title, its category title , and the author’s full name for all books whose price is greater than 300

            //var Books = dbContext.Books.Where(B => B.Price > 300).Include(B => B.Author).Include(B => B.Category);
            //foreach (var Book in Books) 
            //{
            //    Console.WriteLine($"Book Title is {Book.Title} And His Category is {Book.Category.Title} And The Author Name {Book.Author.FirstName} {Book.Author.LastName}");
            //}

            //var Books = from b in dbContext.Books
            //            join c in dbContext.Categories on b.CategoryId equals c.Id
            //            join a in dbContext.Authors on b.AuthorId equals a.Id
            //            where b.Price > 300
            //            select new{
            //                Title = b.Title,
            //                Category = c.Title,
            //                AuthorFullName = a.FirstName + " " + a.LastName

            //            }


            //;

            //foreach ( var book in Books) { 

            //    Console.WriteLine($"Book Title is {book.Title} And His Category is {book.Category} And The Author Name {book.AuthorFullName}");

            //}


            #endregion

            #region Retrieve All Authors And His/Her Books if Exists
            //var authors = dbContext.Authors
            //    .Include(a => a.AuthorBook)
            //    .ToList();

            //foreach (var author in authors) {

            //    Console.WriteLine($"{author.FirstName} {author.LastName}");
            //    foreach (var book in author.AuthorBook) {

            //        Console.WriteLine($"{book.Title}");

            //    }
            //    Console.WriteLine("------------------");


            //}

            #endregion

            #region Member with id 1 Want To Borrow The Book With Id 2 And He Will Return it After 5 Days 
            //int memberid = 1, bookid = 2;




            //var BorrowBook = LibraryService.BorrowBook(dbContext, memberid, bookid);
            //Console.WriteLine(BorrowBook);



            //var Loan = dbContext.MemberLoans.FirstOrDefault(ML => ML.MemberId == memberid);
            //var LoanId = Loan?.LoanId ?? 0;
            //var ReturnDate = Loan!.Loan.LoanDate.AddDays(5);
            //var ReturnBook = LibraryService.ReturnBookWithCheck(dbContext, LoanId, ReturnDate);
            //Console.WriteLine(ReturnBook);


            #region After 10 Days Member with id 1 Returned The Book

            //int memberid = 1, bookid = 2;




            //var BorrowBook = LibraryService.BorrowBook(dbContext, memberid, bookid);
            //Console.WriteLine(BorrowBook);



            //var Loan = dbContext.MemberLoans.FirstOrDefault(ML => ML.MemberId == memberid);
            //var LoanId = Loan?.LoanId ?? 0;
            //var ReturnDate = Loan!.Loan.LoanDate.AddDays(10);
            //var ReturnBook = LibraryService.ReturnBookWithCheck(dbContext, LoanId, ReturnDate);
            //Console.WriteLine(ReturnBook);

            #endregion

            #endregion

            #endregion

            #region Retrieve all members who currently have active loans (i.e., loans that have not yet been returned)

            //var memberWithLoans = (from m in dbContext.Members
            //                       join ml in dbContext.MemberLoans on m.Id equals ml.MemberId
            //                       where ml.ReturnDate == null
            //                       select m.Name).Distinct();

            //foreach (var member in memberWithLoans)
            //    Console.WriteLine(member);





            #endregion


        }
    }
}
