using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class countryMovieController : ControllerBase
    {
        IMovieCountryService _movieCountryService;
        public countryMovieController(IMovieCountryService movieCountryService)
        {
            _movieCountryService = movieCountryService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
           
            var result = _movieCountryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _movieCountryService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(MovieCountry movieCountry)
        {
            var result = _movieCountryService.Add(movieCountry);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
