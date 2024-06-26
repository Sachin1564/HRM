﻿using EntityLayer.WebApplication.ViewModels.CategoryVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace HRM.Web.Areas.Admin.Controllers
{
    //[Authorize]
    [Area("Admin")]
    public class CategoryController : Controller
    {
       private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> GetCategoryList()
        {
            var categoryList = await _categoryService.GetAllListAsync();
            return View(categoryList);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddVM request)
        {

            await _categoryService.AddCategoryAsync(request);
            return RedirectToAction("GetCategoryList", "Category", new { Areas = ("Admin") });


        }
        [HttpGet]
        public async Task< IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateVM request)
        {
            await _categoryService.UpdateCategoryAsync(request);
            return RedirectToAction("GetCategoryList", "Category", new { Areas = ("Admin") });
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("GetCategoryList", "Category", new { Areas = ("Admin") });
        }

    }
}
