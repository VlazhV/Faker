﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators
{
	public class GeneratorContext
	{
		public Random Random { get; }
		public IFaker Faker { get; }

		public GeneratorContext(Random random, global::Faker faker)
		{
			Random = random;
			Faker = faker;
		}

	}
}
