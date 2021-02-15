using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Users;
using Domain.Products;

namespace Domain.Rents
{
    
    public class Rent : Entity
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

        public Rent(User customer, Guid customerId, Product rentedProduct, Guid rentedProductId, DateTime date, DateTime contractStartDate, DateTime contractEndDate, TimeSpan amountOfDays, double rentalValue, string observation)
        {
            Customer = customer;
            CustomerId = customerId;
            RentedProduct = rentedProduct;
            RentedProductId = rentedProductId;
            Date = date;
            ContractStartDate = contractStartDate;
            ContractEndDate = contractEndDate;
            AmountOfDays = amountOfDays;
            RentalValue = rentalValue;
            Observation = observation;            
        }

        protected Rent() {}

        public Rent(Guid id) : base(id) {}

        public double CalculateRent(Guid productId, DateTime ContractStartDate, DateTime ContractEndDate, TimeSpan amountOfDays)
        {
            var product = new Product(productId);

            amountOfDays = ContractEndDate - ContractStartDate;
            var result = product.PricePerDay * amountOfDays.Days;
            
            return result;            
        }

        protected bool ValidateRent()
        {
            if (Customer == null){return false;}
            else if (RentedProduct == null){return false;}
            else if (Date == null){return false;}
            else if (ContractStartDate == null){return false;}
            else if (ContractStartDate < DateTime.Now){return false;}
            else if (ContractEndDate == null){return false;}
            else if (ContractEndDate < DateTime.Now){return false;}
            else if (ContractStartDate > ContractEndDate){return false;}
            else if (RentalValue <= 0){return false;}
            return true;
        }


        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateRent())
            {
                errors.Add("Algum campo obrigatório não foi preenchido ou possui valor inválido.");
            }
            return (errors, errors.Count == 0);
        }
        
    }
}