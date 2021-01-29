using Domain.Products;
using Domain.Users;
using Domain.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class RentMapping : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder
                .HasOne(rent => rent.Customer);

            builder
                .HasOne(rent => rent.RentedProduct);

            builder
                .Property(rent => rent.Observation)
                .HasMaxLength(200);
        }
    }
}
