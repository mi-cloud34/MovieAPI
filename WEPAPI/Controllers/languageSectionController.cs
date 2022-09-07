using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class languageSectionController : ControllerBase
    {
        ISectionLanguageService _sectionLanguageService;
        public languageSectionController(ISectionLanguageService sectionLanguageService)
        {
            _sectionLanguageService = sectionLanguageService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            var result = _sectionLanguageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _sectionLanguageService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SectionLanguage brand)
        {
            var result = _sectionLanguageService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
