using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class CompanyEntityTypeConfigurations : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Id).HasColumnName("CompanyId");
            builder.HasData
                 (
                 new Company
                 {
                     Id = 1,
                     Name = "IT_Solutions Ltd",
                     Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                     Country = "USA"
                 },
                 new Company
                 {
                     Id = 2,
                     Name = "Admin_Solutions Ltd",
                     Address = "312 Forest Avenue, BF 923",
                     Country = "USA"
                 }
                 );
        }
    }
}
