using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyApi
{
    public class APIService
    {
        private readonly string endpoint = "https://api.fastforex.io/convert";
        private readonly string apiKey = "ba5328e551-5b272d14fd-r7i7dd";
        private HttpClient client = new HttpClient();

        int amount = 0;
        string from = "";
        string to = "";

        public int Amount { get => amount; set => amount = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }

        float exchangedAmount = 0F;
        float rate = 0F;
        int requestStatusCode = 0;

        public async Task invokeApiCall()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{endpoint}?from={from}&to={to}&amount={amount}&api_key={apiKey}");
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                var results = JObject.Parse(body);
                exchangedAmount = (float)results["result"][to];
                rate = (float)results["result"]["rate"];
                requestStatusCode = 200; // OK
            }
            catch (HttpRequestException)
            {
                requestStatusCode = 400; // Bad Request
            }
        }

        public bool isResponseValid()
        {
            if(requestStatusCode == 200 && amount > 0 && exchangedAmount > 0 && rate > 0)
            {
                float result = amount * rate;
                if(Math.Round(result, 2) == Math.Round(exchangedAmount, 2))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool isResponseInvalid()
        {
            if(requestStatusCode != 200)
            {
                return true;
            }
            return false;   
        }
    }
}
