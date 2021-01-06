using System;
using System.Threading.Tasks;
using _.Data;
using _.Data.Admin;
using _.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TempWeb.Models;

namespace _.Controllers
{
    [Route("[controller]")]
    [ApiController]


    public class Info : Controller
    {
        private IGenericActions _genericActions;
        private IReletionalActions _reletionalActions;

        public Info(IGenericActions genericActions, IReletionalActions reletionalActions)
        {
            _genericActions = genericActions;
            _reletionalActions = reletionalActions;
        }

        [HttpGet("allProductCategories")]
        public async Task<IActionResult> getAllCategories()
        {
            var info = await _genericActions.GetAll<ProductCategory>();
            
            return Ok(info);
        }

        [HttpGet("allCuisines")]
        public async Task<IActionResult> getAllCuisines()
        {
            var info = await _genericActions.GetAll<Cuisine>();
            return Ok(info);
        }

        [HttpGet("AllCategoryProductsOfCuisine/{cusineId}")]
        public async Task<IActionResult> getProductsCuisine(int cusineId)
        {
       
            var info =  await _reletionalActions.CuisineAllProductsInCategory(cusineId);
            return Ok(info);
        }
        
        
        [HttpGet("AllCategoryIngridientsOfProduct/{productId}")]
        public async Task<IActionResult> getIngridientsProduct(int productId)
        {
       
            var info =  await _reletionalActions.ProductAllIngridentsInCategory(productId);
            return Ok(info);
        }

        

        [HttpGet("ProductCategory/{id}")]
        public async Task<IActionResult> getOneCategory(int id)
        {
            var element = await _genericActions.GetOneElement<ProductCategory>(id);
            
            return Ok(element);
        }
        
        
    }
}