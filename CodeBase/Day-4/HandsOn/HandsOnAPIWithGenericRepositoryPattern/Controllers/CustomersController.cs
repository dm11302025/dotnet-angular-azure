using HandsOnAPIWithGenericRepositoryPattern.CustomRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIWithGenericRepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repo;

        public CustomersController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("by-email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var customer = _repo.FindByEmail(email);
            return customer == null ? NotFound() : Ok(customer);
        }
    }

}
