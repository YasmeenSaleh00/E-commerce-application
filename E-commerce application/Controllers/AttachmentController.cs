﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        /// <summary>
        /// This EndPoint To Upload Images
        /// </summary>

        [HttpPost]
        [Route("[action]")]
        public async Task<string> UploadImages( IFormFile file)
        {

            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (file == null || file.Length == 0)
            {
                throw new Exception("Please Enter Valid File");
            }

            string newFileURL2 = Guid.NewGuid().ToString() + "" + file.FileName;
            using (var inputFile = new FileStream(Path.Combine(uploadFolder, newFileURL2), FileMode.Create))
            {
                await file.CopyToAsync(inputFile);
            }
            return newFileURL2;
        }

    }
}
