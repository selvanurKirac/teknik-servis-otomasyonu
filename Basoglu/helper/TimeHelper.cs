using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace SaatUygulamasi.Helpers
{
    public class TimeHelper
    {
        public static async Task<string> GetSaatAsync()
        {
            string url = "https://timeapi.io/api/Time/current/zone?timeZone=Europe/Istanbul";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                JObject json = JObject.Parse(response);

                // API'den gelen zaman verisi: "time" → örneğin "15:03:28"
                string time = json["time"]?.ToString();

                return time ?? "Saat alınamadı";
            }
        }
        }
}
