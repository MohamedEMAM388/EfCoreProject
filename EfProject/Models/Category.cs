using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfProject.Models
{
    public class Category : BaseEntity
    {
        #region Properties
        public string Title { get; set; }
        public string? Description { get; set; }
        #endregion

        #region RelationShip
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
        #endregion
    }
}
