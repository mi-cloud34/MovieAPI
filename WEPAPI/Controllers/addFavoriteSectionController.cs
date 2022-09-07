﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class addFavoriteSectionController : ControllerBase
    {

        IAddFavoriteSectionService _addFavoriteSectionService;
        public addFavoriteSectionController(IAddFavoriteSectionService addFavoriteSectionService)
        {
            _addFavoriteSectionService = addFavoriteSectionService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {

            var result = _addFavoriteSectionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyId")]
        public IActionResult Get(int id)
        {
            var result = _addFavoriteSectionService.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(AddFavoriteSection addFavoriteSection)
        {
            var result = _addFavoriteSectionService.Add(addFavoriteSection);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
