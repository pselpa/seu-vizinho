using System;
using Domain.Products;
using Domain.Users;

namespace WebAPI.Controllers.Rents
{
    public class CreateRentRequest
    {
        public virtual User Customer { get; set; }
        public  Guid CustomerId { get; set; }
        public Product RentedProduct { get; set; }
        public  Guid RentedProductId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public TimeSpan AmountOfDays { get; set; }
        public double RentalValue { get; set;}
        public string Observation { get; set; }
    }
}