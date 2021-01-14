/*
using System.Threading.Tasks;
 using _.Data;
 using _.Dtos;
 using _.Helpers;
 using _.Models;
 using AutoMapper;
 using CloudinaryDotNet;
 using CloudinaryDotNet.Actions;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.Extensions.Configuration;
 using Microsoft.Extensions.Options;
 
 namespace _.Controllers
 {
     [Authorize]
     [Route("[controller]")]
     [ApiController]
     public class PhotosController : ControllerBase
     {
    
         private IdatingRepository _repo;
         private IConfiguration _config;
         private IMapper _mapper;
         private IOptions<CloudanarySettings> _cloudanaryConfig;
         private Cloudinary _clodinary;
 
         public PhotosController(IdatingRepository repo, IConfiguration config, IMapper mapper, 
             IOptions<CloudanarySettings> cloudanaryConfig)
         {
             _config = config;
             _mapper = mapper;
             _cloudanaryConfig = cloudanaryConfig;
             Account  acc = new Account(
                 _cloudanaryConfig.Value.CloudName,
                 _cloudanaryConfig.Value.ApiKey,
                 _cloudanaryConfig.Value.ApiSecret
 
             );
             _clodinary = new Cloudinary(acc);
         }
 
         [HttpPost("add")]
         public async Task<IActionResult> AddPhotoUser(int userId, PhotoForDetailedDto photoForDetailedDto)
         {
             var userFromRepo = await _repo.GetUser(userId);
 
             var file = photoForDetailedDto;
 
             var uploadResult = new ImageUploadResult();
             
             
         }
     }
 }
 */