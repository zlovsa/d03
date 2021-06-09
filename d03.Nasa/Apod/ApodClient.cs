using d03.Nasa.Apod.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;

namespace d03.Nasa.Apod
{
	public class ApodClient : ApiClientBase, INasaClient<int, Task<MediaOfToday[]>>
	{
		public ApodClient(string apiKey) : base(apiKey) {
		}

		public Task<MediaOfToday[]> GetAsync(int resultCount) {
			var apodTask =
				HttpGetAsync<MediaOfToday[]>($"https://api.nasa.gov/planetary/apod?api_key={ApiKey}&count={resultCount}");
			return apodTask;
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
