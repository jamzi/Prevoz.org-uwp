using Newtonsoft.Json;
using Prevozi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prevozi
{
    public class APICall
    {

        public static async Task<CarshareList> GetCarsharesID(string id)
        {
            String url = String.Format("https://prevoz.org/api/carshare/" + id);

            HttpClient http = new HttpClient();
            var response = await http.GetAsync(url);

            string jsonText = response.Content.ReadAsStringAsync().Result;

            CarshareList result = JsonConvert.DeserializeObject<CarshareList>(jsonText,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            return result;

        }
    }
}
