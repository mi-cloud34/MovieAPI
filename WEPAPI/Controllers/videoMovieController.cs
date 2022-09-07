using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class videoMovieController : ControllerBase
    {
        private readonly IMovieVideoService _videoMovieService;
        public videoMovieController(IMovieVideoService videoMovieService) => _videoMovieService = videoMovieService;

        [HttpPost]
        public IActionResult Add([FromForm(Name = "Video")] IFormFile file, [FromForm] MovieVideo movieVideo)
        {
            var result = _videoMovieService.Add(file, movieVideo);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(MovieVideo movieVideo)
        {
            var carDeleteImage = _videoMovieService.GetById(movieVideo.Id).Data;
            var result = _videoMovieService.Delete(carDeleteImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm(Name = "Video")] IFormFile file, [FromForm] MovieVideo movieVideo)
        {
            var result = _videoMovieService.Update(file, movieVideo);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _videoMovieService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _videoMovieService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getvideobyvideoid")]
        //[Route("getimagesbycarid/{carId}")]
        public IActionResult GetVideoByMovieVideoId(int carId)
        {
            var result = _videoMovieService.GetVideoByMovieVideoId(carId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
