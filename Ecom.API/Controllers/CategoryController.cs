using AutoMapper;
using Ecom.API.DTOs;
using Ecom.API.Helpers;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unitOfWork):base(unitOfWork) {}

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories=await _unitOfWork.categoryRepository.GetAllAsync();
                 return categories is null?NotFound(new ResponseAPI(404)) : Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> Get( [FromQuery] int id)
        {
            try
            {
                var category= await _unitOfWork.categoryRepository.GetByIdAsync(id);
                return category is null?NotFound(new ResponseAPI(404)) : Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Add_Category")]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            try
            {
                var newCategory = new Category()
                {
                    Name = category.CategoryName,
                    Description = category.CategoryDescription
                };

                await _unitOfWork.categoryRepository.AddAsync(newCategory);
                return Ok("Category Added Successfully");
            }
            catch (Exception)
            {
                return BadRequest("failed add this category");
            }
        }

        [HttpPut("Update_Catregory")]
        public async Task<IActionResult> Update(UpdateCategoryDto category)
        {
            try
            {
                if(category is not null)
                {
                    var updatedCategory = new Category()
                    {
                        Id = category.CategoryId,
                        Name = category.CategoryName,
                        Description = category.CategoryDescription
                    };
                    await _unitOfWork.categoryRepository.UpdateAsync(updatedCategory);
                    return Ok("Category Updeted successfully");
                }
                return BadRequest("Input Category has problem");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        
        }

        [HttpDelete("Delte_Category")]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await _unitOfWork.categoryRepository.DeleteAsync(id);
                return Ok("Category Deleted Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
