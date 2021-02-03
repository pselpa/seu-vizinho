using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Rents;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Controllers.Rents
{
    [ApiController]
    [Route("[controller]")]
    public class RentsController : ControllerBase
    {
        public readonly IRentsService _rentsService;
        public RentsController(IRentsService rentsService)
        {
            _rentsService = rentsService;
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Create(CreateRentRequest request)
        {
            StringValues rentId;
            if(!Request.Headers.TryGetValue("RentId", out rentId))
            {
                return Unauthorized();
            }

            var rent = _rentsService.GetById(Guid.Parse(rentId));

            if (rent == null)
            {
                return Unauthorized();
            }

            if (request.Profile == UserProfile.Admin && user.Profile != UserProfile.Admin)
            {
                return Unauthorized();
            }

            var response = _rentsService.Create(
                request.Customer,
                request.CustomerId,
                request.RentedProduct,
                request.Date,
                request.ContractStartDate,
                request.ContractEndDate,
                request.AmountOfHours,
                request.AmountOfDays,
                request.RentalValue,
                request.AddressComplement,
                request.Observation
            );

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var rent = _rentsService.GetById(id);
            
            if (rent == null)
            {
                return NotFound();
            }
            
            return Ok(rent);
        }


    }
}