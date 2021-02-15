using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;

namespace Domain.Products
{
    
    public class Product : Entity
    {
        // Potência, alimentação e acessórios devem ser colocados na descrição.
        public string Name { get; set; } // Exclusivo no banco de dados, fazer teste
        public string Description { get; set; }
        public string Accessories { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Voltage { get; set; }
        public string Frequency { get; set; }
        public double PricePerDay { get; set; }
        public int RentingPeriodLimit { get; set; } //Definir se a pessoa aluga as peças por apenas um determinado período de tempo.

        public Product(
            string name,
            string description,
            string accessories,
            string brand,
            string model,
            string voltage,
            string frequency,
            double pricePerDay,
            int rentingPeriodLimit)
        {
            Name = name;
            Description = description;
            Accessories = accessories;
            Brand = brand;
            Model = model;
            Voltage = voltage;
            Frequency = frequency;
            PricePerDay = pricePerDay;
            RentingPeriodLimit = rentingPeriodLimit;
        }

        public Product(Guid id) : base(id) {}

        public Product() {}

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
            else if (PricePerDay <= 0){return false;}
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
                errors.Add("Algum campo obrigatório não foi preenchido ou possui valor inválido.");
            }
            return (errors, errors.Count == 0);
        }
    }
}