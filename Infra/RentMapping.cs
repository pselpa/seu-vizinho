using Domain.Products;
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
                .Property(rent => rent.Customer);

            builder
                .Property(rent => rent.CustomerId)
                .HasMaxLength(50);

            builder
                .Property(rent => rent.Date);

            builder
                .Property(rent => rent.ContractStartDate);

            builder
                .Property(rent => rent.ContractEndDate);

            builder
                .Property(rent => rent.AmountOfHours);

            builder
                .Property(rent => rent.AmountOfDays);

            builder
                .Property(rent => rent.RentalValue);

            builder
                .Property(rent => rent.Observation)
                .HasMaxLength(200);
        }
    }
}
