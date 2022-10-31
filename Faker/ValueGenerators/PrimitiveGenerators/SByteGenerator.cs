using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class SByteGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( sbyte );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return context.Random.Next( sbyte.MinValue, sbyte.MaxValue );
		}
	}
}
