using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class directorMovieController : ControllerBase
    {
        IMovieDirectorService _movieDirectorService;
        public directorMovieController(IMovieDirectorService movieDirectorService)
        {
            _movieDirectorService = movieDirectorService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
           
            var result = _movieDirectorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _movieDirectorService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(MovieDirector movieDirector)
        {
            var result = _movieDirectorService.Add(movieDirector);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
