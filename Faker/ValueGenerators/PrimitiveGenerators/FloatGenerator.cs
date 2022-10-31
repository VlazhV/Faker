namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class FloatGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( float );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return context.Random.NextSingle();
		}
	}
}
