
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
			return (ushort)(context.Random.Next( ushort.MinValue, ushort.MaxValue ));
		}
	}
}
