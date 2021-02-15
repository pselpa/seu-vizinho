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
        public IActionResult Create(CreateUserRequest request)
        {
            if (request.Profile == UserProfile.Admin)
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

                if (user.Profile != UserProfile.Admin)
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
                    request.ZipCode,
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
            else
            {
                var response = _usersService.Create(
                    request.Name,
                    request.CPF,
                    request.Email,
                    request.Phone,
                    request.State,
                    request.City,
                    request.District,
                    request.ZipCode,
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
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] CreateUserRequest request)
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
            if (user.CPF != request.CPF)
            {
                return Unauthorized();
            }

            var modifiedUser = _usersService.GetById(id);
            if (modifiedUser == null)
            {
                return NotFound();
            }

            modifiedUser.Name = request.Name;
            modifiedUser.CPF = request.CPF;
            modifiedUser.Email = request.Email;
            modifiedUser.Phone = request.Phone;
            modifiedUser.State = request.State;
            modifiedUser.City = request.City;
            modifiedUser.District = request.District;
            modifiedUser.ZipCode = request.ZipCode;
            modifiedUser.HouseNumber = request.HouseNumber;
            modifiedUser.AddressComplement = request.AddressComplement;
            modifiedUser.Profile = request.Profile;
            modifiedUser.Password = request.Password;

            _usersService.Modify(modifiedUser);
            return NoContent();
            
        }

        

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