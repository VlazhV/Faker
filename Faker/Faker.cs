using Faker.Core;

namespace Faker
{
	public class Faker : IFaker
	{
		public T Create<T>()
		{
			throw new NotImplementedException();
		}

		public object Create( Type t )
		{
			throw new NotImplementedException();
		}
	}
}