using EfProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfProject.Models
{
    public class Fine : BaseEntity
    {
        #region Properties
        public decimal Amount { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public FineStatus Status { get; set; }
        #endregion

        #region RelationShip
        public int LoanId { get; set; }
        public Loan Loan { get; set; } = null!;
        #endregion

    }
}
