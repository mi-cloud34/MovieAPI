using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class videoSectionController : ControllerBase
    {
        private readonly ISectionVideoService _sectionVideoService;
        public videoSectionController(ISectionVideoService sectionVideoService) => _sectionVideoService = sectionVideoService;

        [HttpPost]
        public IActionResult Add([FromForm(Name = "Video")] IFormFile file, [FromForm] SectionVideo carImage)
        {
            var result = _sectionVideoService.Add(file, carImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(SectionVideo sectionVideo)
        {
            var carDeleteImage = _sectionVideoService.GetById(sectionVideo.Id).Data;
            var result = _sectionVideoService.Delete(carDeleteImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm(Name = "Video")] IFormFile file, [FromForm] SectionVideo sectionVideo)
        {
            var result = _sectionVideoService.Update(file, sectionVideo);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _sectionVideoService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _sectionVideoService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getvideobyvideoid")]
        
        public IActionResult GetVideoBySectionVideoId(int sectionVideoId)
        {
            var result = _sectionVideoService.GetVideoBySectionVideoId(sectionVideoId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
