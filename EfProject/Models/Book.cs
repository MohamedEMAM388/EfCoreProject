using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfProject.Models
{
    public class Book : BaseEntity
    {

        #region Properties
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }
        #endregion

        #region RelationShip

        #region AuthorRelation 
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        #endregion

        #region CategoryRelation
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        #endregion

        #region MemberLoansRelation
        public ICollection<MemberLoans> MemberLoans { get; set; } = new HashSet<MemberLoans>();
        #endregion



        #endregion


        public override string ToString()
        {
            return Title;
        }

    }
}
