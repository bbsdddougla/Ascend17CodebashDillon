using EPiServer.ServiceLocation;

using Newtonsoft.Json;

using RestSharp;



namespace EpiserverSite1.Business.SearchAnalyzation

{

    [ServiceConfiguration(ServiceType = typeof(ITextServiceAnalyzer))]

    public class TextServiceAnalyzer : ITextServiceAnalyzer

    {

        public string[] AnalyzeText(ISearchDocument document)

        {

            var client = new RestClient("https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases");

            var request = new RestRequest(Method.POST);

            request.AddHeader("postman-token", "f6b90abe-1ad5-53a7-9503-fabeff365832");

            request.AddHeader("cache-control", "no-cache");

            request.AddHeader("accept", "application/json");

            request.AddHeader("content-type", "application/json");

            request.AddHeader("ocp-apim-subscription-key", "fa3521f7e1ad483591d9e47f83e6d212");



            var docs = new { Documents = new[] { new { language = document.Language, id = document.Id, text = document.Text } } };



            request.AddParameter("application/json", JsonConvert.SerializeObject(docs), ParameterType.RequestBody);





            IRestResponse response = client.Execute(request);



            dynamic responseData = JsonConvert.DeserializeObject(response.Content);

            var jArray = responseData.documents[0].keyPhrases;

            string[] returnData = jArray.ToObject<string[]>();



            return returnData;

        }

    }

}