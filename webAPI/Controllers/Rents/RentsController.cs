using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Rents;
using Domain.Users;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Controllers.Rents
{
    [ApiController]
    [Route("[controller]")]
    public class RentsController : ControllerBase
    {
        public readonly IRentsService _rentsService;
        public readonly IUsersService _usersService;
        public RentsController(IUsersService usersService, IRentsService rentsService)
        {
            _usersService = usersService;
            _rentsService = rentsService;
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Create(CreateRentRequest request)
        {
            StringValues userId;
            if(!Request.Headers.TryGetValue("UserId", out userId))
            {
                return Unauthorized();
            }

            var user = _usersService.GetById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            var response = _rentsService.Create(
                request.CustomerId,
                request.RentedProductId,
                request.Date,
                request.ContractStartDate,
                request.ContractEndDate,
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

        [HttpPut("{id}")]
        public IActionResult UpdateRent(Guid id, [FromBody] CreateRentRequest request)
        {
            StringValues userId;
            if (!Request.Headers.TryGetValue("UserId", out userId))
            {
                return Unauthorized();
            }

            var user = _usersService.GetById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            if (user.Profile != UserProfile.Admin && user.Id != request.CustomerId)
            {
                return Unauthorized();
            }

            var rent = _rentsService.GetById(id);
            if (rent == null)
            {
                return NotFound();
            }

            rent.CustomerId = request.CustomerId;
            rent.RentedProductId = request.RentedProductId;
            rent.Date = request.Date;
            rent.ContractStartDate = request.ContractStartDate;
            rent.ContractEndDate = request.ContractEndDate;
            rent.Observation = request.Observation;

            rent.RentalValue = _rentsService.CalculateRent(request.RentedProductId, request.ContractStartDate, request.ContractEndDate);
            
            _rentsService.Modify(rent);
            return NoContent();
            
        }
    }
}