using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(product => product.Description)
                .HasMaxLength(100);

            builder
                .Property(product => product.Accessories)
                .HasMaxLength(100);

            builder
                .Property(product => product.Brand)
                .HasMaxLength(100);

            builder
                .Property(product => product.Model)
                .HasMaxLength(100);
            
            builder
                .Property(product => product.Voltage)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(product => product.Frequency)
                .HasMaxLength(50);
        }
    }
}