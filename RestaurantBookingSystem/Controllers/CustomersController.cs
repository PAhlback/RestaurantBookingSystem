using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly ICustomersService _customerService;

        public CustomersController(ICustomersService service)
        {
            _customerService = service;
        }
    }
}
