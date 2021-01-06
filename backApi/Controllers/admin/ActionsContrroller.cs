using System.Security.Claims;
using System.Threading.Tasks;
using _.Data;
using _.Data.Admin;
using _.Dtos.AddActions;
using _.Helpers;
using _.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TempWeb.Models;

namespace _.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    
    
    public class Actions : ControllerBase
    {
        private IAddActions _addActions;
        private IUserRepository _userRepository;
        private IGetActions _getActions;
        private IOptions<CloudanarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public Actions(IAddActions addActions, IUserRepository userRepository, IGetActions getActions, IOptions<CloudanarySettings> cloudinaryConfig)
        {
            _addActions = addActions;
            _userRepository = userRepository; 
            _getActions = getActions;
            _cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            
            _cloudinary = new Cloudinary(acc);
        }

        [HttpPost("addcusine")]
        public async Task<IActionResult> addCusine([FromForm]addCusineDto cusine)
        {
            
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var file = cusine.imgurl;
            
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            
            
            var newCuisine = new Cuisine
            {
                imgurl = uploadResult.Url.ToString(),
                name =  cusine.name,
                desc = cusine.desc,
                UserId = userId,
            };
            
            
            var addCuisine = await _addActions.AddCuisine(newCuisine);
            
            
            var status = new Status {status = false};
            
            if (addCuisine != null)
            {
                status.status= true;
            }
            
            var json = JsonConvert.SerializeObject(status);
            
            
            return Ok(json);
        }


        [HttpPost("addproduct")]
        public async Task<IActionResult> addProduct([FromForm]addProductDto product)
        {
            var cusineid = await _getActions.GetIdCousine(product.cousineName);
            var productId = await _getActions.GetIdProductCategory(product.productCategoryName);
            
            
            var file = product.imgurl;
            
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            
            
            var newProduct = new Product
            {
                imgurl = uploadResult.Url.ToString(),
                name =  product.name,
                price = product.price,
                CuisineId = cusineid.Id,
                ProductCategoryId = productId.Id,
            };
            
            
            var addProduct = await _addActions.AddProduct(newProduct);
            
            
            var status = new Status {status = false};
            
            if (addProduct != null)
            {
                status.status= true;
            }
            
            var json = JsonConvert.SerializeObject(status);

            return Ok(json);

        }

        [HttpPost("addingridient")]
        public async Task<IActionResult> addIngridient([FromForm] addIngridientDto Ingridient)
        {
            var idIngidinet = await _getActions.GetIdIngridient(Ingridient.inridientCategoryName);
            var productid = await _getActions.GetIdProduct(Ingridient.productName);
            
            
                        
            var file = Ingridient.imgurl;
            
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            
            
            
            var newIngridient = new Ingridient
            {
                name = Ingridient.name,
                img_url = uploadResult.Url.ToString(),
                ProductId = productid.Id,
                IngridientCategoryId = idIngidinet.Id
            };
            var status = new Status {status = false};
            
            var addIngridient = await _addActions.AddIncrident(newIngridient);
            
            if (addIngridient != null)
            {
                status.status= true;
            }
            
            var json = JsonConvert.SerializeObject(status);

            return Ok(json);
        }


        [HttpPost("addProductCategory")]
        public async Task<IActionResult> addProductCategory(addProductCategoryDto productcategory)
        {
            
            var newCategory = new ProductCategory
            {
                name = productcategory.name,
            };
            
            var addCategory = await _addActions.AddProductCategory(newCategory);
            
            var status = new Status {status = false};
            if (addCategory != null)
            {
                status.status= true;
            }
            
            var json = JsonConvert.SerializeObject(status);
            return Ok(json);
        }

        
        [HttpPost("addIngridientCategory")]
        public async Task<IActionResult> addIngridientCategory(addIngridientCategoryDto ingridientCategory)
        {
            
            var newCategory = new IngridientCategory()
            {
                name = ingridientCategory.name,
            };
            
            var addCategory = await _addActions.AddIngridientCategory(newCategory);
            
            var status = new Status {status = false};
            if (addCategory != null)
            {
                status.status= true;
            }
            
            var json = JsonConvert.SerializeObject(status);
            return Ok(json);
        }
        
        
        //
        // [HttpPost("addProduct")]
    }
}