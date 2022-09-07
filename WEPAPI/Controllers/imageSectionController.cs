using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imageSectionController : ControllerBase
    {
        private readonly ISectionImageService _sectionImageService;
        public imageSectionController(ISectionImageService sectionImageService) => _sectionImageService = sectionImageService;

        [HttpPost]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] SectionImage movieImage)
        {
            var result = _sectionImageService.Add(file, movieImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(SectionImage movieImage)
        {
            var carDeleteImage = _sectionImageService.GetById(movieImage.Id).Data;
            var result = _sectionImageService.Delete(carDeleteImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] SectionImage movieImage)
        {
            var result = _sectionImageService.Update(file, movieImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _sectionImageService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _sectionImageService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getimagesbysectionid")]
        //[Route("getimagesbycarid/{carId}")]
        public IActionResult GetImagesBySectionId(int carId)
        {
            var result = _sectionImageService.GetImagesBySectionId(carId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
