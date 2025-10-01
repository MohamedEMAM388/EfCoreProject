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
    internal class MemberLoansConfig : IEntityTypeConfiguration<MemberLoans>
    {
        public void Configure(EntityTypeBuilder<MemberLoans> builder)
        {

            builder.HasKey(ML => new { ML.MemberId, ML.LoanId, ML.BookId });

            builder.HasOne(ML => ML.Book)
                .WithMany(B => B.MemberLoans)
                     .HasForeignKey(ML => ML.BookId);

            builder.HasOne(ML => ML.Member)
                .WithMany(M => M.MemberLoans)
                     .HasForeignKey(ML => ML.MemberId);

            builder.HasOne(ML => ML.Loan)
                .WithMany(L => L.MemberLoans)
                     .HasForeignKey(ML => ML.LoanId);

        }
    }
}
