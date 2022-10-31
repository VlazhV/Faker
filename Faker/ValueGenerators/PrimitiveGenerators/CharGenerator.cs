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
			return (char) (context.Random.Next( char.MinValue, char.MaxValue ));
		}
	}
}
