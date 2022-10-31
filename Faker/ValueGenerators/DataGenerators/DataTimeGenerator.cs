using System;

namespace Faker.Core.ValueGenerators.DataGenerators
{
	class DataTimeGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type == typeof( DateTime );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			int year = context.Random.Next(1950, 2100);
			int month = context.Random.Next(0, 12);
			int day = context.Random.Next(0, 28);
			int hour = context.Random.Next(0, 23);
			int minute = context.Random.Next(0, 59);
			int second = context.Random.Next(0, 59);

			return new DateTime (year, month, day, hour, minute, second);	
		}
	}
}
