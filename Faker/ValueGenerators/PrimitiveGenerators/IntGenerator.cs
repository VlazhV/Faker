namespace Faker.Core.ValueGenerators.PrimitiveGenerators
{
	public class IntGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( int );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			return context.Random.Next( int.MinValue, int.MaxValue );
		}
	}
}
