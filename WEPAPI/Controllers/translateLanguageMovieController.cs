using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class translateLanguageMovieController : ControllerBase
    {
        IMovieTranslateLanguageService _movieTranslateLanguageService;
        public translateLanguageMovieController(IMovieTranslateLanguageService movieTranslateLanguageService)
        {
            _movieTranslateLanguageService = movieTranslateLanguageService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            var result =_movieTranslateLanguageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _movieTranslateLanguageService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(MovieTranslateLanguage movieTranslateLanguage)
        {
            var result = _movieTranslateLanguageService.Add(movieTranslateLanguage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
