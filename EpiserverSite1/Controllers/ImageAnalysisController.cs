//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//using Newtonsoft.Json;

//namespace EpiserverSite1.Controllers
//{
//    public class ImageAnalysisController : Controller
//    {
//        // GET: ImageAnalysis
//        public ActionResult Index()
//        {

//            return 
//                View();
//        }

//        public ActionResult Analyze(string image)
//        {
//            return new ContentResult() {Content = MakeAnalysisRequest(image).Result};
//        }

//        public static async Task<string> MakeAnalysisRequest(string imageFilePath)
//        {
//            var client = new HttpClient();

//            // Request headers. Replace the second parameter with a valid subscription key.
//            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "13hc77781f7e4b19b5fcdd72a8df7156");

//            // Request parameters. A third optional parameter is "details".
//            string requestParameters = "visualFeatures=Categories&language=en";
//            string uri = "https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze?" + requestParameters;
//            Console.WriteLine(uri);

//            HttpResponseMessage response;



//            using (var content = new StringContent(JsonConvert.SerializeObject(new { url = imageFilePath })))
//            {
//                // This example uses content type "application/octet-stream".
//                // The other content types you can use are "application/json" and "multipart/form-data".
//                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
//                response = await client.PostAsync(uri, content);
//                return JsonConvert.DeserializeObject<>(response.Content.ToString());
//            }
//        }

//        public async 

//        private byte[] GetImageAsByteArray(string imageFilePath)
//        {
//            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
//            BinaryReader binaryReader = new BinaryReader(fileStream);
//            return binaryReader.ReadBytes((int)fileStream.Length);
//        }

//        public async void MakeAnalysisRequest(string imageFilePath)
//        {
//            var client = new HttpClient();

//            // Request headers. Replace the second parameter with a valid subscription key.
//            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "13hc77781f7e4b19b5fcdd72a8df7156");

//            // Request parameters. A third optional parameter is "details".
//            string requestParameters = "visualFeatures=Categories&language=en";
//            string uri = "https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze?" + requestParameters;
//            Console.WriteLine(uri);

//            HttpResponseMessage response;

//            // Request body. Try this sample with a locally stored JPEG image.
//            byte[] byteData = GetImageAsByteArray(imageFilePath);

//            using (var content = new ByteArrayContent(byteData))
//            {
//                // This example uses content type "application/octet-stream".
//                // The other content types you can use are "application/json" and "multipart/form-data".
//                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
//                response = await client.PostAsync(uri, content);
//            }
//        }


//    }
//}