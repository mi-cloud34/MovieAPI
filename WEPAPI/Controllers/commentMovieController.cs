using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class commentMovieController : ControllerBase
    {
        ICommentMovieService _commentMovieService;
        public commentMovieController(ICommentMovieService commentMovieService)
        {
            _commentMovieService = commentMovieService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {

            var result = _commentMovieService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _commentMovieService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(CommentMovie commentMovie)
        {
            var result = _commentMovieService.Add(commentMovie);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getmoviecommentdetails")]
        public IActionResult GetMovieCommmentDetail()
        {
            var result = _commentMovieService.GetMovieCommmentDetail();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmoviecommentdetailsid")]
        public IActionResult GetMovieCommentDetailsById(int id)
        {
            var result = _commentMovieService.GetMovieCommentDetailsById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmoviecommentdetailsuserid")]
        public IActionResult GetMovieCommentDetailsByUserId(int userId)
        {
            var result = _commentMovieService.GetMovieCommentDetailsByUserId(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmoviecommentdetailsmovieid")]
        public IActionResult GetMovieCommentDetailsByMovieId(int movieId)
        {
            var result = _commentMovieService.GetMovieCommentDetailsByMovieId(movieId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}


