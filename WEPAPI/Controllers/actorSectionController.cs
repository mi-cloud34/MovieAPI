using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class actorSectionController : ControllerBase
    {
        ISectionActorService _sectionActorService;
        public actorSectionController(ISectionActorService sectionActorService)
        {
            _sectionActorService = sectionActorService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            var result = _sectionActorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _sectionActorService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SectionActor sectionActor)
        {
            var result = _sectionActorService.Add(sectionActor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
