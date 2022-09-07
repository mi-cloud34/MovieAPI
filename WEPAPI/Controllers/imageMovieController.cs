using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imageMovieController : ControllerBase
    {
        private readonly IMovieImageService _movieImageService;
        public imageMovieController(IMovieImageService movieImageService) => _movieImageService = movieImageService;

        [HttpPost]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] MovieImage movieImage)
        {
            var result = _movieImageService.Add(file, movieImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(MovieImage movieImage)
        {
            var carDeleteImage = _movieImageService.GetById(movieImage.Id).Data;
            var result = _movieImageService.Delete(carDeleteImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] MovieImage movieImage)
        {
            var result = _movieImageService.Update(file, movieImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _movieImageService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _movieImageService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getimagesbymovieid")]
        //[Route("getimagesbycarid/{carId}")]
        public IActionResult GetImagesByMovieId(int carId)
        {
            var result = _movieImageService.GetImagesByMovieId(carId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
