using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class countrySectionController : ControllerBase
    {
        ISectionCountryService _sectionCountryService;
        public countrySectionController(ISectionCountryService sectionCountryService)
        {
            _sectionCountryService = sectionCountryService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            var result = _sectionCountryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _sectionCountryService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SectionCountry sectionCountry)
        {
            var result = _sectionCountryService.Add(sectionCountry);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
