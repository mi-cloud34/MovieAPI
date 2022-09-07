using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class likeSectionController : ControllerBase
    {
        ILikeSectionService _likeSectionService;
        public likeSectionController(ILikeSectionService likeSectionService)
        {
            _likeSectionService = likeSectionService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {

            var result = _likeSectionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _likeSectionService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(LikeSection likeSection, int id)
        {
            var result = _likeSectionService.Add(likeSection,id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getlikesectiondetails")]
        public IActionResult GetSectionLikeDetail()
        {
            var result = _likeSectionService.GetSectionLikeDetail();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("gettlikesectiondetailsid")]
        public IActionResult GetMovieCommentDetailsById(int id)
        {
            var result = _likeSectionService.GetSectionLikeDetailsById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("gettlikesectiondetailsuser")]
        public IActionResult GetSectionLikeDetailsByUserId(int userId)
        {
            var result = _likeSectionService.GetSectionLikeDetailsByUserId(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("gettlikesectiondetailsmovie")]
        public IActionResult GetSectionLikeDetailsByMovieId(int movieId)
        {
            var result = _likeSectionService.GetSectionLikeDetailsByMovieId(movieId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
