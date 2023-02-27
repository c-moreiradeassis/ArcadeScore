using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PunctuationController : ControllerBase
    {
        private PunctuationService _service;

        public PunctuationController(PunctuationService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _service.GetAll();

            return Ok(result);
        }

        [HttpGet("{player}")]
        public ActionResult Details(string player)
        {
            var result = _service.Details(player);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Punctuation punctuation)
        {
             _service.Add(punctuation);

            return Ok();
        }
    }
}