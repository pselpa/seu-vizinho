using System;
using Domain.Entities;
using Domain.Users;

namespace Domain.Products
{
    
    public class Rents : Entity
    {
        User Costumer { get; set; }
        Product ProductRented { get; set; }
        public DateTime Date { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public int AmountOfHours { get; set; }
        public int AmountOfDays { get; set; }
        public double RentalValue { get; set;}
        public string Observation { get; set; }

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
        
    }
}