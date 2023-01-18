using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiparisYonetimi.Api.Domain.Models;

namespace SiparisYonetimi.Infrastructure.Persistence.EntityConfigurations
{
    public class CompanyConfiguration : BaseEntityConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.CompanyName).HasMaxLength(400).IsRequired();
            builder.HasIndex(c => c.CompanyName).IsUnique();
        }
    }
}
