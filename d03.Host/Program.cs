using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using d03.Nasa.Apod;
using System.Collections.Generic;
using System.Globalization;

namespace d03.Host
{
	class Program
	{
		static public IConfiguration Configuration { get; set; }
		public static async Task Main(string[] args = null) {
			if (args.Length != 1
				|| !int.TryParse(args[0], out int ResultCount)
				|| ResultCount < 1) {
				Console.WriteLine("Usage : d03.Host <ResultCount>");
				return;
			}
			try {
				var configurationBuilder = new ConfigurationBuilder();
				configurationBuilder.AddJsonFile("appsettings.json", false);
				Configuration = configurationBuilder.Build();
				var apod = new ApodClient(Configuration["ApiKey"]);
				var media = await apod.GetAsync(ResultCount);
				CultureInfo.CurrentCulture = new CultureInfo("en-GB", false);
				Console.WriteLine(string.Join(Environment.NewLine, (object[])media));
			} catch (Exception e){
				Console.WriteLine(e.Message);
			}
		}
	}
}
