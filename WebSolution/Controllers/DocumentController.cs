using Microsoft.AspNetCore.Mvc;

using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WebSolution.Controllers
{
    public class DocumentController : controllerBase
    {
        private IConfiguration _configuration;
 
        public DocumentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IAmazonS3 getClient()
        {
            var options = _configuration.GetAWSOptions();
            return options.CreateServiceClient<IAmazonS3>();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            base.addHomeToBreadCrumb();

            using (var client = getClient())
            {
                var model = await ListingObjects(client, "org2techtest");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Upload()
        {
            base.addDocumentToBreadCrumb();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile(IFormFile file)
        {
            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                    using (var client = getClient())
                    {
                        await WritingAnObject(client, "org2techtest", file.FileName, stream);
                    }                        
                }

                return RedirectToAction("Index");
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok();
        }

        private static async Task<IEnumerable<string>> ListingObjects(
            IAmazonS3 client, 
            string bucketName)
        {
            try
            {
                var request = new ListObjectsRequest();
                request.BucketName = bucketName;
                var response = await client.ListObjectsAsync(request);
                return response.S3Objects.Select(o => o.Key);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new ApplicationException("Please check the provided AWS Credentials.", amazonS3Exception);
                }
                else
                {
                    throw new ApplicationException($"An error occurred with the message '{amazonS3Exception.Message}' when listing objects", amazonS3Exception);
                }
            }
        }

        private static async Task WritingAnObject(
            IAmazonS3 client,
            string bucketName,
            string fileName,
            Stream stream)
        {
            try
            {                
                // simple object put
                var request = new PutObjectRequest()
                {
                    InputStream = stream,                     
                    BucketName = bucketName,
                    Key = fileName
                };

                var response = await client.PutObjectAsync(request);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new ApplicationException("Please check the provided AWS Credentials.", amazonS3Exception);
                }
                else
                {
                    throw new ApplicationException($"An error occurred with the message '{amazonS3Exception.Message}' when writing an object", amazonS3Exception);
                }
            }
        }
    }
}