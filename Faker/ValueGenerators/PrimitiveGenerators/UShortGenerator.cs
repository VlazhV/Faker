using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class UShortGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( ushort );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return context.Random.Next( ushort.MinValue, ushort.MaxValue );
		}
	}
}
