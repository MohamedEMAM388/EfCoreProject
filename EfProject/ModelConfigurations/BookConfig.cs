using EfProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfProject.ModelConfigurations
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(B => B.Title)
                   .HasColumnName("Title")
                   .HasColumnType("varchar(50)")
                   .HasMaxLength(50);

            builder.Property(B => B.Price).HasPrecision(6, 2);

            builder.ToTable(t => t.HasCheckConstraint("CK_Book_PublicationYear",
                                      "[PublicationYear] >= 1950 AND [PublicationYear] <= YEAR(GETDATE())")
            );

            builder.ToTable(T => T.HasCheckConstraint("CK_Book_AvailableCopies", "[AvailableCopies] <= [TotalCopies]"));

            #region RelationShip

            builder.HasOne(B => B.Author)
                    .WithMany(A => A.AuthorBook)
                    .HasForeignKey(B => B.AuthorId);

            builder.HasOne(B => B.Category)
                    .WithMany(C => C.Books)
                    .HasForeignKey(B => B.CategoryId);

            

            #endregion
        }
    }
}
