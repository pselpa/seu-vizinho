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
                .HasOne(rent => rent.RentedProduct)
                .WithOne(rentedproduct => rentedproduct.Rent)
                .HasForeignKey<RentedProduct>(rent => rent.RentedProduct);

            builder
                .Property(rent => rent.Observation)
                .HasMaxLength(200);
        }
    }
}
