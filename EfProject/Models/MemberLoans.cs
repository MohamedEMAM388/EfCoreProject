using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfProject.Models
{
    public class MemberLoans
    {
        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;

        public int BookId { get; set; }
        public Book Book { get; set; } = null!; 

        public int LoanId { get; set; }
        public Loan Loan { get; set; } = null!;

        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
