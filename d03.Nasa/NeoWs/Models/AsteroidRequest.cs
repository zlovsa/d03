using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Nasa.NeoWs.Models
{
	public class AsteroidRequest
	{

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int ResultCount { get; set; }
	}
}
