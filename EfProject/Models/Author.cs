using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfProject.Models
{
    public class Author : BaseEntity
    {
        #region Properties
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        #endregion

        #region RelationShip

        public ICollection<Book> AuthorBook { get; set; } = new HashSet<Book>();

        #endregion
    }
}
