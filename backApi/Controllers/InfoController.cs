using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _.Data;
using _.Data.Admin;
using _.Dtos;
using _.Dtos.AddActions;
using _.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public Info(IGenericActions genericActions, IReletionalActions reletionalActions, IMapper mapper)
        {
            _genericActions = genericActions;
            _reletionalActions = reletionalActions;
            _mapper = mapper;
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
        public async Task<IActionResult> getProductsCuisine(string cusineId)
        {
            
            var info =  await _reletionalActions.CuisineAllProductsInCategory(cusineId);

            var infoToReturn = _mapper.Map<IEnumerable<ProductCategoryDto>>(info);;
            
            return Ok(infoToReturn);
        }
        
        
        [HttpGet("AllCategoryIngridientsOfProduct/{productId}")]
        public async Task<IActionResult> getIngridientsProduct(string productId)
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