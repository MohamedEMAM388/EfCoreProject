using EfProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfProject.Models
{
    public class Member : BaseEntity
    {

        #region Properties
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime MemberShipDate { get; set; }
        public MemberStatus status { get; set; } 
        #endregion

        public ICollection<MemberLoans> MemberLoans { get; set; } = new HashSet<MemberLoans>();

    }
}
