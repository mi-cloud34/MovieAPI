using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class genreMovieController : ControllerBase
    {
        IMovieGenreService _movieGenreService;
        public genreMovieController(IMovieGenreService movieGenreService)
        {
            _movieGenreService = movieGenreService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
           
            var result = _movieGenreService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _movieGenreService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(MovieGenre movieGenre)
        {
            var result =_movieGenreService.Add(movieGenre);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
