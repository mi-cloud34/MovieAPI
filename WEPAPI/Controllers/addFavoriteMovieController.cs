using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class addFavoriteMovieController : ControllerBase
    {
        IAddFavoriteMovieService _addFavoriteMovieService;
        public addFavoriteMovieController(IAddFavoriteMovieService addFavoriteMovieService)
        {
            _addFavoriteMovieService = addFavoriteMovieService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {

            var result = _addFavoriteMovieService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _addFavoriteMovieService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(AddFavoriteMovie addFavoriteMovie)
        {
            var result = _addFavoriteMovieService.Add(addFavoriteMovie);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
