using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Nasa
{
	interface INasaClient<in TIn, out TOut>
	{
		public TOut GetAsync(TIn input);
	}
}
