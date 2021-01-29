using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using Domain.Products;
using Microsoft.Extensions.Primitives;
using System;


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
           
            return Ok(response.Id);
        }


    }
}