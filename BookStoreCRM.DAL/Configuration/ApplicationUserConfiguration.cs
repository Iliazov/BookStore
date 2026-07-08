using BookStoreCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreCRM.DAL.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUsers>
    {
        public void Configure(EntityTypeBuilder<ApplicationUsers> builder)
        {
            builder.ToTable(nameof(ApplicationUsers));
            builder.HasKey(x => x.Id);

            builder.Property(u => u.FirstName)
                   .IsRequired();

            builder.Property(u => u.LastName)
                   .IsRequired();
        }
    }
}
