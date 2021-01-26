using System.Collections.Generic;

namespace WebAPI.Controllers.Rents
{
    public class CreateRentRequest
    {
        public string Name { get; set; }
        public IList<string> Rents { get; set; }
    }
}