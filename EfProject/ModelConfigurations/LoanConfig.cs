using EfProject.Models;
using EfProject.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfProject.ModelConfigurations
{
    internal class LoanConfig : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.Property(L => L.LoanDate).HasDefaultValueSql("GETDATE()");

            builder.Property(L => L.Status).HasConversion<string>()
                                           .HasDefaultValue(LoanStatus.Borrowed);
        }
    }
}
