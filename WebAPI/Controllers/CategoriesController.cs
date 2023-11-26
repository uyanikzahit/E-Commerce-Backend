﻿using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if(result.Success)
            {
                return Ok (result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            if(result.Success)
            {
                return Ok (result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if(result.Success)
            {
                return Ok (result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Category category) 
        {
            var result = _categoryService.Update(category);
            if(result.Success)
            {
                return Ok (result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Category category) 
        {
            var result = _categoryService.Delete(category);
            if (result.Success)
            {
                return Ok (result);
            }
            return BadRequest(result);
        }
    }
}
