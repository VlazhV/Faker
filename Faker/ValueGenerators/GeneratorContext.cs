

namespace Faker.Core.ValueGenerators
{
	public class GeneratorContext
	{
		public Random Random { get; }
		public IFaker Faker { get; }

		public GeneratorContext(Random random, Faker faker)
		{
			Random = random;
			Faker = faker;
		}

	}
}
