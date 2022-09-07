using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class translateLanguageSectionConteoller : ControllerBase
    {
        ISectionTranslateLanguageService _sectionTranslateLanguageService;
        public translateLanguageSectionConteoller(ISectionTranslateLanguageService sectionTranslateLanguageService)
        {
            _sectionTranslateLanguageService = sectionTranslateLanguageService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            var result = _sectionTranslateLanguageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _sectionTranslateLanguageService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SectionTranslateLanguage sectionTranslateLanguage)
        {
            var result = _sectionTranslateLanguageService.Add(sectionTranslateLanguage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
