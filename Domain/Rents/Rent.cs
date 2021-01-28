using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Users;

namespace Domain.Products
{
    
    public class Rent : Entity
    {
        User Customer { get; set; }
        Product RentedProduct { get; set; }
        public DateTime Date { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public int AmountOfHours { get; set; }
        public int AmountOfDays { get; set; }
        public double RentalValue { get; set;}
        public string Observation { get; set; }

        public Rent(User customer, Product rentedProduct, DateTime date, DateTime contractStartDate, DateTime contractEndDate, int amountOfHours, int amountOfDays, double rentalValue, string observation)
        {
            Customer = customer;
            RentedProduct = rentedProduct;
            Date = date;
            ContractStartDate = contractStartDate;
            ContractEndDate = contractEndDate;
            AmountOfHours = amountOfHours;
            AmountOfDays = amountOfDays;
            RentalValue = rentalValue;
            Observation = observation;            
        }

        public double CalculateRent(Product product, int amountOfHours, int amountOfDays)
        {
            // Testar o algoritmo de cálculo
            const int maxHoursPerDay = 8;
            const int week = 7;
            const int biweekly = 15;
            const int month = 30;

            if ((amountOfHours > 0) && (amountOfHours < maxHoursPerDay))
            {
                return amountOfHours * product.PricePerHour;
            }
            else if (amountOfDays < week)
            {
                return amountOfDays * product.PricePerDay;
            }
            else if (amountOfDays < biweekly)
            {
                return amountOfDays * product.PricePerDayByWeek;
            }
            else if (amountOfDays < month)
            {
                return amountOfDays * product.PricePerDayByBiweekly;
            }
            else return amountOfDays * product.PricePerDayByMonth;
            
        }

        protected bool ValidateRent() // *** Verificar se devem ser incluidos outros itens.
        {
            if (Customer == null){return false;}
            else if (RentedProduct == null){return false;}
            else if (Date == null){return false;}
            else if (ContractStartDate == null){return false;}
            else if (ContractEndDate == null){return false;}
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