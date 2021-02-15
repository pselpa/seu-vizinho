using System;
using Domain.Products;

namespace WebAPI.Controllers.Products
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Accessories { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Voltage { get; set; } 
        public string Frequency { get; set; }
        public double PricePerDay { get; set; }
        public int RentingPeriodLimit { get; set; }
    }

}