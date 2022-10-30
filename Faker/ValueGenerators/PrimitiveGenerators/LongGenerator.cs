using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class LongGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( long );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return context.Random.NextInt64( long.MinValue, long.MaxValue );			
		}
	}
}
