using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DetectFacesAPI.Models;
using DetectFacesAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using AnalyzeImageAPI.Models;

namespace DetectFacesAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    public class AnalyzeImageController : ControllerBase
    {
        private readonly IAnalyzeRepository analyzeRepository;
        private readonly IConfiguration config;


        public AnalyzeImageController(IAnalyzeRepository analyzeRepository, IConfiguration config)
        {
            this.analyzeRepository = analyzeRepository;
            this.config = config;

        }

        [HttpPost("ImageURL")]
        public async Task<ImageAnalysis> AnalyzeImage([FromQuery]string imageFilePath, string email)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            Image image = new Image
            {
                ImageUrl = imageFilePath
            };

            await analyzeRepository.Save(image);

            var subscriptionKey = config.GetSection("API:ComputerVisionAPI:subscriptionKey").Value;
            var endpoint = config.GetSection("API:ComputerVisionAPI:endpoint").Value;

            ComputerVisionClient client = Authenticate(endpoint, subscriptionKey);

            ImageAnalysis imageAnalysis = await AnalyzeImageUrl(client, imageFilePath);

            Email emailObj = new Email(config);
            emailObj.Execute(email).Wait();

            return imageAnalysis;      

        }

        public static ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
                new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
                { Endpoint = endpoint };
            return client;
        }

        // Gets the analysis of the specified image by using the Face REST API.
        public static async Task<ImageAnalysis> AnalyzeImageUrl(ComputerVisionClient client, string imageUrl)
        {
            // Creating a list that defines the features to be extracted from the image. 
            List<VisualFeatureTypes> features = new List<VisualFeatureTypes>()
                {
                    VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
                    VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
                    VisualFeatureTypes.Tags, VisualFeatureTypes.Adult,
                    VisualFeatureTypes.Color, VisualFeatureTypes.Brands,
                    VisualFeatureTypes.Objects
                };

            ImageAnalysis results = await client.AnalyzeImageAsync(imageUrl, features);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(@"C:\Users\AnalyzedImage.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, results);
               
            }

            return results;

           

        }

       


    }
       
    }
