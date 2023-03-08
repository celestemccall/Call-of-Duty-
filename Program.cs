using System;
using Newtonsoft.Json;
using RestSharp;


namespace CallOfDutyAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/Amartin743/psn");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "6a90fa04f2msh9aa8df2678dce24p1fef9bjsn881118eca4be");
            request.AddHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");
            var response = client.Execute(request).Content;

            var root = JsonConvert.DeserializeObject<Root>(response);

            Console.WriteLine($"Games Played: {root.data.lifetime.mode.gun.properties.gamesPlayed}");
            Console.WriteLine($"KD Ratio: {root.data.lifetime.mode.gun.properties.kdRatio}");
        }
    }
}