using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SiparisYonetimi.Api.Domain.Models;

namespace SiparisYonetimi.Infrastructure.Persistence.EntityConfigurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.HasMany(o => o.Products).WithMany(p => p.Orders);
            builder.HasOne(o => o.Company).WithMany(c => c.Orders).HasForeignKey(o => o.CompanyId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.CustomerName).HasMaxLength(200).IsRequired();
            builder.HasCheckConstraint("CHK_OrderDate", "[OrderDate]<GETDATE()");
        }
    }
}
