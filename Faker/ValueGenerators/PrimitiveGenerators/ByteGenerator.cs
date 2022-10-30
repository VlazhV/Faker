using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class ByteGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( byte );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return (byte)context.Random.Next(0, 256 );
		}
	}
}
