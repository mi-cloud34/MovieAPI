using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sectionController : ControllerBase
    {
        ISectionService _sectionService;
        public sectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {

            var result = _sectionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _sectionService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Section section )
        {
            var result = _sectionService.Add(section);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getsectiondetails")]
        public IActionResult GetSectionDetail()
        {
            var result = _sectionService.GetSectionDetail();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getsectiondetailsbyId")]
        public IActionResult GetSectionDetailsById(int id)
        {
            var result = _sectionService.GetSectionDetailsById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getsectiondirectordetails")]
        public IActionResult GetSectionDetailsByDirectorId(int directorId)
        {
            var result = _sectionService.GetSectionDetailsByDirectorId(directorId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getsectionpointdetails")]
        public IActionResult GetSectionDetailsByPointId(int pointId)
        {
            var result = _sectionService.GetSectionDetailsByPointId(pointId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getsectiongenredetails")]
        public IActionResult GetSectionDetailGenreId(int genreId)
        {
            var result = _sectionService.GetSectionDetailGenreId(genreId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getsectionlanguagedetails")]
        public IActionResult GetSectionDetailsByLanguageId(int languageId)
        {
            var result = _sectionService.GetSectionDetailsByLanguageId(languageId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getsectioncountrydetails")]
        public IActionResult GetSectionDetailsByCountryId(int countryId)
        {
            var result = _sectionService.GetSectionDetailsByCountryId(countryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
