using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class likeMovieController : ControllerBase
    {
        ILikeMovieService _likeMovieService;
        public likeMovieController(ILikeMovieService likeMovieService)
        {
            _likeMovieService = likeMovieService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {

            var result = _likeMovieService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        //[HttpDelete]//
        [HttpPost("delete")]
        public IActionResult Delete(LikeMovie likeMovie,int id)
        {
            var result = _likeMovieService.Delete(likeMovie,id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _likeMovieService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(LikeMovie likeMovie,int id)
        {
            var result = _likeMovieService.Add(likeMovie,id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getmovielikedetails")]
        public IActionResult GetMovieLikeDetail()
        {
            var result = _likeMovieService.GetMovieLikeDetail();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmovielikedetailsid")]
        public IActionResult GetMovieLikeDetailsById(int id)
        {
            var result = _likeMovieService.GetMovieLikeDetailsById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmovielikedetailsuserid")]
        public IActionResult GetMovieLikeDetailsByUserId(int userId)
        {
            var result = _likeMovieService.GetMovieLikeDetailsByUserId(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmovielikedetailsmovieid")]
        public IActionResult GetMovieLikeDetailsByMovieId(int movieId)
        {
            var result = _likeMovieService.GetMovieLikeDetailsByMovieId(movieId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
