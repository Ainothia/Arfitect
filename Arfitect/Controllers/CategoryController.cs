﻿using Microsoft.AspNetCore.Mvc;
using Product.API.Business.Interfaces;
using Product.API.Dto;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("/category")]
    public class CategoryController : Controller
	{
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("save")]
        [ProducesDefaultResponseType(typeof(bool))]
        public bool Save([FromBody] SaveCategoryRequestDto saveCategoryRequestDto)
        {
            return _categoryService.Save(saveCategoryRequestDto);
        }
    }
}

