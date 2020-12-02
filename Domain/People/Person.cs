using System.Linq;
using Domain.Entities;

namespace Domain.People
{
    // Abstract, pois não devemos instanciar a classe person. Ela é apenas um modelo.
    public abstract class Person : Entity
    {
        public string Name { get; protected set; }
        public string LastName { get; protected set; }
        public string CPF { get; protected set; }
        public string Email { get; protected set; }
        public string Phone { get; protected set; }
        public string State { get; protected set; }
        public string City { get; protected set; }
        public string District { get; protected set; }
        public string ZipCode { get; protected set; }
        public string HouseNumber { get; protected set; }
        public string AddressComplement { get; protected set; }

        public Person(
            string name,
            string cpf,
            string email,
            string phone,
            string state,
            string city,
            string district,
            string zipcode,
            string houseNumber,
            string addressComplement
        )
        {
            Name = name;
            CPF = cpf;
            Email = email;
            Phone = phone;
            State = state;
            City = city;
            District = district;
            ZipCode = zipcode;
            HouseNumber = houseNumber;
            AddressComplement = addressComplement;
        }
        public Person(string name)
        {
            Name = name;
        }

        protected bool ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            var words = Name.Split(' ');
            if (words.Length < 2)
            {
                return false;
            }

            foreach (var word in words)
            {
                if (word.Trim().Length < 2)
                {
                    return false;
                }
                if (word.Any(x => !char.IsLetter(x)))
                {
                    return false;
                }
            }
            return true;
        }

        protected bool ValidateCPF()
        {
            if (string.IsNullOrEmpty(CPF)) return false;

            var cpf = CPF.Replace(".", "").Replace("-", "");
            
            if (cpf.Length != 11) return false;

            if (!cpf.All(char.IsNumber)) return false;

            var first = cpf[0];
            if (cpf.Substring(1, 10).All(x => x == first)) return false;

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temp;
            string digit;
            int sum;
            int rest;

            temp = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(temp[i].ToString()) * multiplier1[i];
            }

            rest = sum % 11;

            rest = rest < 2 ? 0 : 11 - rest;

            digit = rest.ToString();
            temp += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(temp[i].ToString()) * multiplier2[i];
            }

            rest = sum % 11;

            rest = rest < 2 ? 0 : 11 - rest;

            digit += rest.ToString();

            if (cpf.EndsWith(digit)) return true;

            return false;
        }
    }
}