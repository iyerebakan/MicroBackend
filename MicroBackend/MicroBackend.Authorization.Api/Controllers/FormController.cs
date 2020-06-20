using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroBackend.Authorization.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpPost("add")]
        public IActionResult Add(Form form)
        {
            _formService.Add(form);
            return Ok("Kaydedildi");
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(_formService.GetList());
        }
    }
}
