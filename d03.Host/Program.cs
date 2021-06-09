using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using d03.Nasa.Apod;
using System.Collections.Generic;
using System.Globalization;
using d03.Nasa.NeoWs;
using d03.Nasa.NeoWs.Models;

namespace d03.Host
{
	class Program
	{
		static public IConfiguration Configuration { get; set; }
		public static async Task Main(string[] args = null) {
			if (args.Length != 2
				|| (args[0] != "apod" && args[0] != "neows")
				|| !int.TryParse(args[1], out int ResultCount)
				|| ResultCount < 1) {
				Console.WriteLine("Usage : d03.Host [apod|neows] <ResultCount>");
				return;
			}
			try {
				var configurationBuilder = new ConfigurationBuilder();
				configurationBuilder.AddJsonFile("appsettings.json", false);
				Configuration = configurationBuilder.Build();
				if (args[0] == "apod") {
					var apod = new ApodClient(Configuration["ApiKey"]);
					var media = await apod.GetAsync(ResultCount);
					CultureInfo.CurrentCulture = new CultureInfo("en-GB", false);
					Console.WriteLine(string.Join(Environment.NewLine, (object[])media));
				} else {
					var neows = new NeoWsClient(Configuration["ApiKey"]);
					var media = await neows.GetAsync(new AsteroidRequest {
						ResultCount = ResultCount,
						StartDate = DateTime.Parse(Configuration["NeoWs:StartDate"]),
						EndDate = DateTime.Parse(Configuration["NeoWs:EndDate"])
					});
				}
			} catch (Exception e){
				Console.WriteLine(e.Message);
			}
		}
	}
}
