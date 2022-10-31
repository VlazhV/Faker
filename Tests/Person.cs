using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class Person
	{
		public int Age { get; set; }
		public string Name { get; set; }
		private string _passportId;
		private ushort height;
		private ushort weight;

		public Person (int age, string name)
		{
			Age = age;
			Name = name;
		}

	}
}
