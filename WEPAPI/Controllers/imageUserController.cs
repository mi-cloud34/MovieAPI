using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imageUserController : ControllerBase
    {
        private readonly IUserImageService _userImageService;
        public imageUserController(IUserImageService userImageService) => _userImageService = userImageService;

        [HttpPost]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] UserImage userImage)
        {
            var result = _userImageService.Add(file, userImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(UserImage userImage)
        {
            var carDeleteImage = _userImageService.GetById(userImage.Id).Data;
            var result = _userImageService.Delete(carDeleteImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] UserImage userImage)
        {
            var result = _userImageService.Update(file, userImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userImageService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userImageService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getimagesbyuserid")]
        //[Route("getimagesbycarid/{carId}")]
        public IActionResult GetImagesByUserId(int carId)
        {
            var result = _userImageService.GetImagesByUserId(carId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
