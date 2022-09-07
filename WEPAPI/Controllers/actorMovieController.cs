using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class actormovieController : ControllerBase
    {
        IMovieActorService _movieActorService;
        public actormovieController(IMovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
           
            var result = _movieActorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _movieActorService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(MovieActor movieActor)
        {
            var result = _movieActorService.Add(movieActor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
