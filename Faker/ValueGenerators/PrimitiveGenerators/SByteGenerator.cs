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
			return (sbyte)(context.Random.Next( sbyte.MinValue, sbyte.MaxValue ));
		}
	}
}
