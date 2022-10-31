using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class ShortGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( short );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return context.Random.Next( short.MinValue, short.MaxValue );
		}
	}
}
