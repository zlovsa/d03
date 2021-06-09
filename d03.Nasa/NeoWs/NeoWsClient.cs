using d03.Nasa.NeoWs.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace d03.Nasa.NeoWs
{
	public class NeoWsClient : ApiClientBase, INasaClient<AsteroidRequest, Task<AsteroidLookup[]>>
	{
		public NeoWsClient(string apiKey) : base(apiKey) {
		}

		public async Task<AsteroidLookup[]> GetAsync(AsteroidRequest ar) {
			var jsondoc = await
				HttpGetAsync<JsonDocument>($"https://api.nasa.gov/neo/rest/v1/feed?start_date={ar.StartDate:dddd-mm-dd}&end_date={ar.EndDate:dddd-mm-dd}&api_key={ApiKey}");
			var neo = jsondoc.RootElement.GetProperty("near_earth_objects");
			var dict = JsonSerializer.Deserialize<Dictionary<DateTime, AsteroidInfo[]>>(neo.GetRawText());
			var dictreq =
				from item in dict.Values
				orderby item[0].Distance ascending
				select item;

			return await HttpGetAsync<AsteroidLookup[]>("");
		}

		protected override async Task<T> HttpGetAsync<T>(string url) {
			var client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			//Console.WriteLine($"GET {url} returned {response.StatusCode}:{response.Content}");
			T retval = await response.Content.ReadFromJsonAsync<T>();
			return retval;
		}
	}
}
