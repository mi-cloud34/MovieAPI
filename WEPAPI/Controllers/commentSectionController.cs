using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class commentSectionController : ControllerBase
    {
        ICommentSectionService _commentSectionService;
        public commentSectionController(ICommentSectionService commentSectionService)
        {
            _commentSectionService = commentSectionService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {

            var result = _commentSectionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _commentSectionService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(CommentSection commentSection)
        {
            var result = _commentSectionService.Add(commentSection);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getsectioncommentdetails")]
        public IActionResult GetSectionCommmentDetail()
        {
            var result = _commentSectionService.GetSectionCommentDetail();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getsectioncommentdetailsid")]
        public IActionResult GetSectionCommentDetailsById(int id)
        {
            var result = _commentSectionService.GetSectionCommentDetailBySectionId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getsectionecommentdetailsuser")]
        public IActionResult GetSectionCommentDetailsByUserId(int userId)
        {
            var result = _commentSectionService.GetSectionCommentDetailByUserId(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getsectioncommentdetailsmovie")]
        public IActionResult GetSectionCommentDetailsByMovieId(int movieId)
        {
            var result = _commentSectionService.GetSectionCommentDetailBySectionId(movieId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
