using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Users;
using Domain.Products;

namespace Domain.Rents
{
    
    public class Rent : Entity
    {
        public  Guid CustomerId { get; set; }
        public  Guid RentedProductId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public double RentalValue { get; set;}
        public string Observation { get; set; }

        public Rent(Guid customerId, Guid rentedProductId, DateTime date, DateTime contractStartDate, DateTime contractEndDate, double rentalValue, string observation)
        {
            CustomerId = customerId;
            RentedProductId = rentedProductId;
            Date = date;
            ContractStartDate = contractStartDate;
            ContractEndDate = contractEndDate;
            RentalValue = rentalValue;
            Observation = observation;            
        }

        protected Rent() {}

        public Rent(Guid id) : base(id) {}

        protected bool ValidateRent()
        {
            if (CustomerId == null){return false;}
            else if (RentedProductId == null){return false;}
            else if (Date == null){return false;}
            else if (ContractStartDate == null){return false;}
            else if (ContractStartDate < DateTime.Now){return false;}
            else if (ContractEndDate == null){return false;}
            else if (ContractEndDate < DateTime.Now){return false;}
            else if (ContractStartDate > ContractEndDate){return false;}
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