using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pointSectionController : ControllerBase
    {
        ISectionPointService _sectionPointService;
        public pointSectionController(ISectionPointService sectionPointService)
        {
            _sectionPointService = sectionPointService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            var result = _sectionPointService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result =_sectionPointService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SectionPoint brand)
        {
            var result = _sectionPointService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
