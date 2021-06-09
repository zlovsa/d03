using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Nasa.Apod.Models
{
	public class MediaOfToday
	{
		public string Copyright { get; set; }
		public DateTime Date { get; set; }
		public string Explanation { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }

		public override string ToString() => $"{Date:d}{Environment.NewLine}"
			+ $"'{Title}' by {Copyright}{Environment.NewLine}"
			+ $"{Explanation}{Environment.NewLine}"
			+ $"{Url}{Environment.NewLine}";

	}
}
