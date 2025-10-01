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
    internal class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(M => M.Name)
                   .HasColumnName("Name")              
                   .HasColumnType("varchar(50)")      
                   .HasMaxLength(50);

            builder.Property(M => M.Email)
                   .HasColumnName("Email")             
                   .HasColumnType("varchar(100)")     
                   .HasMaxLength(100);

            builder.ToTable(T => T.HasCheckConstraint("CK_EmailFormat", "[Email] like '%_@_%._%'"));


            builder.Property(M => M.PhoneNumber)
                   .HasColumnName("PhoneNumber")       
                   .HasColumnType("varchar(11)")      
                   .HasMaxLength(11);

            builder.ToTable(T => T.HasCheckConstraint("CK_EgyptionPhone_Format", 
                                                      "[PhoneNumber] like '01_________' AND [PhoneNumber] NOT LIKE '%[^0-9]%'"));

            builder.Property(M => M.Address)
                   .HasColumnName("Address")          
                   .HasColumnType("varchar(100)")      
                   .HasMaxLength(100);

            builder.Property(M => M.MemberShipDate).HasDefaultValueSql("GETDATE()");

           builder.Property(M => M.status).HasConversion<string>()
                                          .HasDefaultValue(MemberStatus.Active);



        }
    }
}
