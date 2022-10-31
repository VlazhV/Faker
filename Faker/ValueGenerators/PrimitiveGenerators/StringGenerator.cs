
using System.Text;

namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class StringGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( string );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			int stringLength = context.Random.Next( 15 );
			StringBuilder sb = new StringBuilder();
			for ( int i = 0; i < stringLength; i++ )
				sb.Append( (char)context.Random.Next( char.MinValue, char.MaxValue ) );
			return sb.ToString(); 
		}
	}
}
