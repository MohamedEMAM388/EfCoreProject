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
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(A => A.FirstName)
                   .HasColumnName("FirstName")
                   .HasColumnType("varchar(20)")
                   .HasMaxLength(20);

            builder.Property(A => A.LastName)
                   .HasColumnName("LastName")
                   .HasColumnType("varchar(20)")
                   .HasMaxLength(20);

        }
    }
}
