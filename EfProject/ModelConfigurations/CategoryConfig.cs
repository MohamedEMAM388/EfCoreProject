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
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(C => C.Title)
                   .HasColumnName("Title")            
                   .HasColumnType("varchar(50)")      
                   .HasMaxLength(50);

            builder.Property(C => C.Description)
                   .HasColumnName("Description")      
                   .HasColumnType("varchar(100)")     
                   .HasMaxLength(100);
        }
    }
}
