using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SaveYourSearchAPI.DbContexts;
using SaveYourSearchAPI.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.WindowsAzure.Storage.Auth;

namespace SaveYourSearchAPI.Controllers
{
    [EnableCors(origins: "*", headers:"*",methods:"*")]
    [Route("api/Images")]
   
    public class ImagesController : ControllerBase
    {
       private  SaveYourSearchContext _context;
        private CloudBlobContainer _container;
        //[Route("api/[controller]")]
        //[ApiController]
        //public ImagesController(SaveYourSearchContext context)
        //{
        //    _context = context;
        //}
 
        public ImagesController(SaveYourSearchContext context)
        {
            _context = context;
            CloudStorageAccount storageAccount = new CloudStorageAccount(
                new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                        "saveyoursearchstorage",
                        "KyAhDLUF3ld+wRnv3/beukoL6kehN+dnPOA28v7K1BVmX1dtwSZUeXop4QiPSYr0A1tsju0TvYyJ3Qzffml+Hw=="), true);
            // Create a blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            _container = blobClient.GetContainerReference("savedimages");
        }
        [HttpGet]
        //  [SwaggerOperation()]
        public object Get()
        {
            return new { Naveen = "Naveen patancheru", FullName = "NaveenKumarReddy" };
        }


        [HttpGet("{userId}")]
        public IActionResult GetImages(string userID)
        {
            var images = _context.SavedImages.Where(image => image.UserId == userID);
            return Ok(images);
        }



        [HttpPost]
        //[Route("Post")]
     //   [SwaggerOperation()]
        public async Task<IActionResult> Post([FromBody] ImagePostRequest request)
        {
          
            CloudBlockBlob blockBlob = _container.GetBlockBlobReference($"{request.id}.{request.encodingFormat}");

            HttpWebRequest aRequest = (HttpWebRequest)WebRequest.Create(request.url);
            HttpWebResponse aResponse = (await aRequest.GetResponseAsync()) as HttpWebResponse;
            var stream = aResponse.GetResponseStream();
            await blockBlob.UploadFromStreamAsync(stream);
            stream.Dispose();


            var savedImage = new SavedImage();
            savedImage.UserId = request.userId;
            savedImage.Description = request.description;
            savedImage.StorageUrl = blockBlob.Uri.ToString();
            savedImage.Tags = new List<SavedImageTag>();

            foreach (var tag in request.tags)
            {
                savedImage.Tags.Add(new SavedImageTag() { Tag = tag });
            }

            _context.Add(savedImage);
            _context.SaveChanges();
            return Ok();
        }
        //public IActionResult GetData()
        //{
        //    var savedImage= new SavedImage 
        //}
        public class ImagePostRequest
        {
            public string userId { get; set; }
            public string description { get; set; }
            public string[] tags { get; set; }
            public string url { get; set; }
            public string id { get; set; }
            public string encodingFormat { get; set; }
        }
        //[HttpPost]
        //[Route("api/Images")]
        //[SwaggerOperation()]

        //public async Task<IActionResult> PostImage([FromBody]ImagePostRequest request)
        //{
        //    CloudBlockBlob blockBlob = _container.GetBlockBlobReference($"{request.Id}.{request.EncodingFormat}");
        //    HttpWebRequest aRequest = (HttpWebRequest)WebRequest.Create(request.URL);
        //    HttpWebResponse aResponse = (await aRequest.GetResponseAsync()) as HttpWebResponse;
        //    var stream = aResponse.GetResponseStream();
        //    await blockBlob.UploadFromStreamAsync(stream);
        //    stream.Dispose();


        //    var savedImage = new SavedImage();
        //    savedImage.UserId = request.UserId;
        //    savedImage.Description = request.Description;
        //    savedImage.StorageUrl = blockBlob.Uri.ToString();
        //    savedImage.Tags = new List<SavedImageTag>();

        //    foreach (var tag in request.Tags)
        //    {
        //        savedImage.Tags.Add(new SavedImageTag() { Tag = tag });
        //    }

        //    _context.Add(savedImage);
        //    _context.SaveChanges();

        //    return Ok();
        //    return Ok();
        //}
   }
}
