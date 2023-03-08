using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace CallOfDutyAPI
{
    
    public class COD
    {
        public static RestResponse CallOfDuty()
        {
            var client = new RestClient("https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/Amartin743/psn");

            var request = new RestRequest("", Method.Get);

            request.AddHeader("X-RapidAPI-Key", "6a90fa04f2msh9aa8df2678dce24p1fef9bjsn881118eca4be");

            request.AddHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");

            var response = client.Execute(request);
            Console.WriteLine(response.Content);

            // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);


            return response;
        }


        public static Gamer BRCoDParse(RestResponse response)
        {
            var brObj = JObject.Parse(response.Content).GetValue("br");

            var gamerWins = brObj["wins"];

            var gamer = new Gamer()
            {
                wins = (double)gamerWins
            };

            return gamer;
        }
	}
}

