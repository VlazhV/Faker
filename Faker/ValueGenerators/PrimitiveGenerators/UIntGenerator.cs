using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class UIntGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( uint );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return context.Random.NextInt64( uint.MinValue, uint.MaxValue );
		}
	}
}
