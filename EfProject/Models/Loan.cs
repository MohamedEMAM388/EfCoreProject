using EfProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfProject.Models
{
    public class Loan : BaseEntity
    {

        #region Properties
        public DateTime LoanDate { get; set; }
        public LoanStatus Status { get; set; }
        #endregion

        #region RelationShip

        public Fine? Fine { get; set; } 

        public ICollection<MemberLoans> MemberLoans { get; set; } = new HashSet<MemberLoans>();


        #endregion
    }
}
