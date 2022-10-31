namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class ShortGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( short );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return (short)( context.Random.Next( short.MinValue, short.MaxValue ) );
		}
	}
}
