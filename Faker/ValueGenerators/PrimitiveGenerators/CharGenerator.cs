using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class CharGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( char );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return context.Random.Next( char.MinValue, char.MaxValue );
		}
	}
}
