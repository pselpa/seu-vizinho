using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using Domain.Products;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;

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
                request.PricePerDay,
                request.RentingPeriodLimit
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
            var product = _productsService.GetById(id);
            
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpGet()]
        public IActionResult GetByParameter([FromQuery] Dictionary<string, string> model)
        {
            var product = _productsService.GetAll(x => 
            {
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
            return Ok(product.OrderBy(x => x.Name));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] CreateProductRequest request)
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

            var product = _productsService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Accessories = request.Accessories;
            product.Brand = request.Brand;
            product.Model = request.Model;
            product.Voltage  = request.Voltage;
            product.Frequency  = request.Frequency;
            product.PricePerDay = request.PricePerDay;
            product.RentingPeriodLimit = request.RentingPeriodLimit;

            _productsService.Modify(product);
            return NoContent();
            
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