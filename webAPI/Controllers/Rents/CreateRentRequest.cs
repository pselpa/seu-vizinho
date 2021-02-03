using System;
using System.Collections.Generic;
using Domain.Products;
using Domain.Users;

namespace WebAPI.Controllers.Rents
{
    public class CreateRentRequest
    {
        public virtual User Customer { get; set; }
        public  Guid CustomerId { get; set; }
        public Product RentedProduct { get; set; }
        public DateTime Date { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public int AmountOfHours { get; set; }
        public int AmountOfDays { get; set; }
        public double RentalValue { get; set;}
        public string Observation { get; set; }
    }
}