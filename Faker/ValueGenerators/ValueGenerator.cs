﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Core.ValueGenerators
{
	internal class ValueGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			throw new NotImplementedException();
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			throw new NotImplementedException();
		}
	}
}
