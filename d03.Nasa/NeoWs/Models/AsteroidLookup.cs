using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Nasa.NeoWs.Models
{
	public class AsteroidLookup
	{
		public string Neo_reference_id { get; set; }
		public string Name { get; set; }
		public string Nasa_jpl_url { get; set; }
		public bool Is_potentially_hazardous_asteroid { get; set; }
		public class OrbitalData
		{
			public class OrbitClass
			{
				public string orbit_class_type { get; set; }
				public string orbit_class_description { get; set; }
			}
			public OrbitClass Orbit_class;
		}
		public OrbitalData Orbital_data { get; set; }
	}
}
