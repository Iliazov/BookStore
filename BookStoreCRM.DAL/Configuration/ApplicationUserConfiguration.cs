using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCRM.DAL.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable(nameof(ApplicationUser));
            builder.HasKey(x => x.Id);

            builder.Property(u => u.FirstName)
                   .IsRequired();

            builder.Property(u => u.LastName)
                   .IsRequired();
        }
    }
}
