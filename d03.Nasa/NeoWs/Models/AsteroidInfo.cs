using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Nasa.NeoWs.Models
{
	public class AsteroidInfo
	{
		public string Id { get; set; }
		public class CloseApproachData
		{
			public class MissDistance
			{
				public double Kilometers { get; set; }
			}
		}
		public CloseApproachData Close_approach_data { get; set; }
	}
}
