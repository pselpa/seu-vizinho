using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult CreateAdmin(CreateUserRequest request)
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

            if (request.Profile == UserProfile.Admin && user.Profile != UserProfile.Admin)
            {
                return Unauthorized();
            }

            var response = _usersService.Create(
                request.Name,
                request.CPF,
                request.Email,
                request.Phone,
                request.State,
                request.City,
                request.District,
                request.Zipcode,
                request.HouseNumber,
                request.AddressComplement,
                request.Profile,
                request.Password
            );

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }

        // [HttpPost]
        // public IActionResult CreateClient(CreateUserRequest request)
        // {
        //     if (request.Profile == UserProfile.Client)
        //     {
        //         var response = _usersService.Create(
        //         request.Name,
        //         request.CPF,
        //         request.Email,
        //         request.Phone,
        //         request.State,
        //         request.City,
        //         request.District,
        //         request.Zipcode,
        //         request.HouseNumber,
        //         request.AddressComplement,
        //         request.Profile,
        //         request.Password
        //         );

        //         if (!response.IsValid)
        //         {
        //             return BadRequest(response.Errors);
        //         }
        //     }
        //     return NoContent();
        // }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _usersService.GetById(id);
            
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }


    }
}