using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class languageMovieController : ControllerBase
    {
        public IMovieLanguageService _movieLanguageService;
        public languageMovieController(IMovieLanguageService movieLanguageService)
        {
            _movieLanguageService = movieLanguageService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            var result = _movieLanguageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _movieLanguageService.GetById(id);
            if (result.Success)  
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(MovieLanguage movieLanguage)
        {
            var result = _movieLanguageService.Add(movieLanguage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
