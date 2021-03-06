using Domain.Users;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var crypt = new Crypt();
            var cryptPassword = crypt.CreateMD5("admin123");

            builder.HasData(new User(
                "System Admin",
                "24068108013",
                "admin@email.com",
                "47999999999",
                "SC",
                "Blumenau",
                "Centro",
                "89000000",
                "999",
                "Casa",
                UserProfile.Admin,
                cryptPassword
            ));

            builder
                .Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(user => user.CPF)
                .HasMaxLength(15);

            builder
                .Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(user => user.Phone)
                .HasMaxLength(20);
            
            builder
                .Property(user => user.State)
                .HasMaxLength(2);

            builder
                .Property(user => user.City)
                .HasMaxLength(50);
            
            builder
                .Property(user => user.District)
                .HasMaxLength(50);

            builder
                .Property(user => user.ZipCode)
                .HasMaxLength(10);

            builder
                .Property(user => user.HouseNumber)
                .HasMaxLength(10);
            
            builder
                .Property(user => user.AddressComplement)
                .HasMaxLength(100);

            builder
                .Property(user => user.Profile)
                .HasMaxLength(100);

            builder
                .Property(user => user.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasIndex(user => user.Email)
                .IsUnique();
        }
    }
}
