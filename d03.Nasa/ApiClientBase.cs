using System;
using System.Threading.Tasks;

namespace d03.Nasa
{
	public abstract class ApiClientBase
	{
		protected ApiClientBase(string apiKey) {
			this.ApiKey = apiKey;
		}
		protected abstract Task<T> HttpGetAsync<T>(string url);
		protected string ApiKey { get; set; }
	}
}
