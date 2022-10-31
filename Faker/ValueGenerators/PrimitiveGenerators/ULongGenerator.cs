using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class ULongGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( ulong );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return (ulong)context.Random.NextInt64( 0, long.MaxValue ) + (ulong)context.Random.NextInt64( 0, long.MaxValue ) ;
		}
	}
}
