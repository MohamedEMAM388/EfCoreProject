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
    internal class FineConfig : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            builder.Property(F => F.Amount).HasPrecision(6 , 2);

            builder.Property(F => F.IssuedDate).HasDefaultValueSql("GETDATE()");

            builder.Property(F => F.Status).HasConversion<string>()
                                           .HasDefaultValue(FineStatus.Pending);

            #region RelationShip

            builder.HasOne(F => F.Loan)
                    .WithOne(L => L.Fine)
                    .HasForeignKey<Fine>(F => F.LoanId);


            #endregion

        }
    }
}
