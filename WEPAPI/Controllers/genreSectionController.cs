using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class genreSectionController : ControllerBase
    {
        ISectionGenreService _sectionGenreService;
        public genreSectionController(ISectionGenreService sectionGenreService)
        {
          _sectionGenreService = sectionGenreService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
           
            var result = _sectionGenreService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _sectionGenreService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SectionGenre sectionGenre)
        {
            var result = _sectionGenreService.Add(sectionGenre);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
