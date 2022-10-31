using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class FamilyPerson : Person
	{
		public FamilyPerson( int age, string name ) : base( age, name )
		{}

		public FamilyPerson[] Children { get; set; }

	}
}
