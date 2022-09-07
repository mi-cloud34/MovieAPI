using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class directorSectionController : ControllerBase
    {
        ISectionDirectorService _sectionDirectorService;
        public directorSectionController(ISectionDirectorService sectionDirectorService)
        {
            _sectionDirectorService = sectionDirectorService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _sectionDirectorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _sectionDirectorService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SectionDirector sectionDirector)
        {
            var result =_sectionDirectorService.Add(sectionDirector);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
