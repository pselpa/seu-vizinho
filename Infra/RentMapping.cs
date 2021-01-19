using Domain.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class RentMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder
                .HasOne(rent => rent.Customer)
                .WithOne(customer => customer.Rent)
                .HasForeignKey<Customer>(rent => rent.Customer);

            builder
                .HasOne(rent => rent.ProductRented)
                .WithOne(productrented => productrented.Rent)
                .HasForeignKey<ProductRented>(rent => rent.ProductRented);

            builder
                .Property(rent => rent.Observation)
                .HasMaxLength(200);
        }
    }
}
