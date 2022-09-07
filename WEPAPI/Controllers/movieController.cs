using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class movieController : ControllerBase
    {
        IMovieService _movieService;
        public movieController(IMovieService  movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {

            var result = _movieService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _movieService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Movie movie )
        {
            var result = _movieService.Add(movie);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getmoviedetails")]
        public IActionResult GetSectionDetail()
        {
            var result = _movieService.GetMovieDetail();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmoviedetailsbyId")]
        public IActionResult GetSectionDetailsById(int id)
        {
            var result = _movieService.GetMovieDetailsById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmoviedirectordetails")]
        public IActionResult GetSectionDetailsByDirectorId(int directorId)
        {
            var result = _movieService.GetMovieDetailsByDirectorId(directorId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmoviepointdetails")]
        public IActionResult GetSectionDetailsByPointId(int pointId)
        {
            var result = _movieService.GetMovieDetailsByPointId(pointId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmoviegenredetails")]
        public IActionResult GetSectionDetailGenreId(int genreId)
        {
            var result = _movieService.GetMovieDetailGenreId(genreId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmovielanguagedetails")]
        public IActionResult GetSectionDetailsByLanguageId(int languageId)
        {
            var result = _movieService.GetMovieDetailsByLanguageId(languageId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getmoviecountrydetails")]
        public IActionResult GetSectionDetailsByCountryId(int countryId)
        {
            var result = _movieService.GetMovieDetailsByCountryId(countryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
