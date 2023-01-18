using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisYonetimi.Api.Domain.Models;

namespace SiparisYonetimi.Infrastructure.Persistence.EntityConfigurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.Company).WithMany(c => c.ProductList).HasForeignKey(p => p.CompanyId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.ProductName).HasMaxLength(200).IsRequired();
            builder.HasIndex(p => new { p.ProductName, p.CompanyId }).IsUnique();
            builder.HasCheckConstraint("CHK_UnitInStock", "[UnitInStock]>=0");
            builder.HasCheckConstraint("CHK_Price", "[Price]>=0");

        }
    }
}
