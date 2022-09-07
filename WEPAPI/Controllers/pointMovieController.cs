using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pointMovieController : ControllerBase
    {
        IMoviePointService _moviePointService;
        public pointMovieController(IMoviePointService moviePointService)
        {
            _moviePointService = moviePointService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            var result = _moviePointService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result =_moviePointService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(MoviePoint brand)
        {
            var result = _moviePointService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
