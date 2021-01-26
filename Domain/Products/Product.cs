using System.Collections.Generic;
using System.Linq;
using Domain.Common;

namespace Domain.Products
{
    
    public class Product : Entity
    {
        // Potência, alimentação e acessórios devem ser colocados na descrição.
        public string Name { get; protected set; } // Exclusivo no banco de dados, fazer teste
        public string Description { get; protected set; }
        public string Accessories { get; protected set; }
        public string Brand { get; protected set; }
        public string Model { get; protected set; }
        public string Voltage { get; protected set; }
        public string Frequency { get; protected set; }
        public double PricePerHour { get; protected set; }
        public double PricePerDay { get; protected set; }
        public double PricePerDayByWeek { get; protected set; }
        public double PricePerDayByBiweekly { get; protected set; }
        public double PricePerDayByMonth { get; protected set; }
        public int RentingPeriodLimit { get; protected set; } //Definir se a pessoa aluga as peças por apenas um determinado período de tempo.

        public Product(
            string name,
            string description,
            string accessories,
            string brand,
            string model,
            string voltage,
            string frequency,
            double pricePerHour,
            double pricePerDay,
            double pricePerDayByWeek,
            double pricePerDayByBiweekly,
            double pricePerDayByMonth,
            int rentingPeriodLimit)
        {
            Name = name;
            Description = description;
            Accessories = accessories;
            Brand = brand;
            Model = model;
            Voltage = voltage;
            Frequency = frequency;
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            PricePerDayByWeek = pricePerDayByWeek;
            PricePerDayByBiweekly= pricePerDayByBiweekly;
            PricePerDayByMonth = pricePerDayByMonth;
            RentingPeriodLimit = rentingPeriodLimit;
        }

        protected bool ValidateProductName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            var words = Name.Split(' ');

            foreach (var word in words)
            {
                if (words.Length < 2 && word.Trim().Length < 2)
                {
                    return false;
                }
            }
            return true;
        }

        protected bool ValidateProduct()
        {
            if (string.IsNullOrEmpty(Name)){return false;}
            else if (string.IsNullOrEmpty(Description)){return false;}
            else if (PricePerHour < 0){return false;}
            else if (PricePerDay < 0){return false;}
            else if (PricePerDayByWeek < 0){return false;}
            else if (PricePerDayByBiweekly < 0){return false;}
            else if (PricePerDayByMonth < 0){return false;}
            else if (RentingPeriodLimit < 0){return false;}
            return true;
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateProductName())
            {
                errors.Add("Algum campo obrigatório não foi preenchido.");
            }
            if (!ValidateProduct())
            {
                errors.Add("Algum campo obrigatório não foi preenchido.");
            }
            
            return (errors, errors.Count == 0);
        }
    }
}