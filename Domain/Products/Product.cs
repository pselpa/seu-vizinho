using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Products
{
    
    public class Product : Entity
    {
        // Potência, alimentação e acessórios devem ser colocados na descrição.
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Brand { get; protected set; }
        public string Model { get; protected set; }
        public string Voltage { get; protected set; }
        public string Frequency { get; protected set; }
        public int Quantity { get; protected set; }
        public int RentingPeriodLimit { get; protected set; } //Definir se a pessoa aluga as peças por apenas um determinado período de tempo.

        public Product(string name, string description, string brand, string model, string voltage, string frequency, int quantity, int rentingPeriodLimit)
        {
            Name = name;
            Description = description;
            Brand = brand;
            Model = model;
            Voltage = voltage;
            Frequency = frequency;
            Quantity = quantity;
            RentingPeriodLimit = rentingPeriodLimit;
        }

        protected bool ValidateProductName()
        {
            if (string.IsNullOrEmpty(Name)){return false;}
            else if (string.IsNullOrEmpty(Description)){return false;}
            else if (string.IsNullOrEmpty(Voltage)){return false;}
            else if (string.IsNullOrEmpty(Frequency)){return false;}
            else if (Quantity == 0){return false;}
            return true;
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateProductName())
            {
                errors.Add("Algum campo obrigatório não foi preenchido.");
            }
            
            return (errors, errors.Count == 0);
        }
    }
}