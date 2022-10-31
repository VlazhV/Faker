using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class BoolGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( bool );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return 1 == context.Random.Next( 1 );
		}
	}
}
