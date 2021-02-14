using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using Domain.Products;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers.Products
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public readonly IProductsService _productsService;
        public readonly IUsersService _usersService;
        public ProductsController(IUsersService usersService, IProductsService productsService)
        {
            _usersService = usersService;
            _productsService = productsService;
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Create(CreateProductRequest request)
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
            
            var response = _productsService.Create(
                request.Name,
                request.Description, 
                request.Accessories, 
                request.Brand, 
                request.Model, 
                request.Voltage, 
                request.Frequency, 
                request.PricePerHour, 
                request.PricePerDay, 
                request.PricePerDayByWeek, 
                request.PricePerDayByBiweekly, 
                request.PricePerDayByMonth, 
                request.RentingPeriodLimit
            );

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
           
            return NoContent();
        }


                //   ******* USAR QUERYSTRING - NÃO DÁ PRA USAR O MESMO ENDPOINT

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var product = _productsService.GetById(id);
            
            if (product == null)
            {
                return NotFound();
            }
            
            return Ok(product);
        }


        [HttpGet()]
        public IActionResult GetByParameter([FromQuery] Dictionary<string, string> model)   // Alterar para pesquisar por parte do nome
        {
            var product = _productsService.GetAll(x => {
                bool matches = true;
                if (model.TryGetValue("name", out string name)) 
                {
                    matches = matches && x.Name == name;
                }
                if (model.TryGetValue("brand", out string brand)) 
                {
                    matches = matches && x.Brand == brand;
                }
                if (model.TryGetValue("voltage", out string voltage)) 
                {
                    matches = matches && x.Voltage == voltage;
                }
                if (model.TryGetValue("frequency", out string frequency)) 
                {
                    matches = matches && x.Frequency == frequency;
                }
                return matches;
            });
            
            if (product == null)
            {
                return NotFound();
            }
            
            return Ok(product);
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
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

            if (user.Profile != UserProfile.Admin)
            {
                return Unauthorized();
            }

            _productsService.Remove(id);
            return NoContent();
            
        }


    }
}