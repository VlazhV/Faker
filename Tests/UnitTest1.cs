using Faker.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void GenerateSomePrimitivesTest()
		{
			var faker = new Faker.Core.Faker();

			var boolean = faker.Create<bool>();
			Assert.IsNotNull(boolean);
			Assert.IsTrue( boolean.GetType() == typeof( bool ) );

			var b = faker.Create<byte>();
			Assert.IsNotNull(b);
			Assert.IsTrue( b.GetType() == typeof( byte ) );

			var c = faker.Create<char>();
			Assert.IsNotNull( c );
			Assert.IsTrue( c.GetType() == typeof( char ) );

			var d = faker.Create<double>();
			Assert.IsNotNull( d );
			Assert.IsTrue( d.GetType() == typeof( double ) );

			var f = faker.Create<float>();
			Assert.IsNotNull( f );
			Assert.IsTrue( f.GetType() == typeof( float ) );

			var i = faker.Create<int>();
			Assert.IsNotNull(i);
			Assert.IsTrue( i.GetType() == typeof( int ) );

			var l = faker.Create<long>();
			Assert.IsNotNull( l );
			Assert.IsTrue( l.GetType() == typeof( long ) );

			var sb = faker.Create<sbyte>();
			Assert.IsNotNull( sb );
			Assert.IsTrue( sb.GetType() == typeof( sbyte ) );

			var sh = faker.Create<short>();
			Assert.IsNotNull( sh );
			Assert.IsTrue( sh.GetType() == typeof( short ) );

			var ui = faker.Create<uint>();
			Assert.IsNotNull( ui );
			Assert.IsTrue( ui.GetType() == typeof( uint ) );

			var ul = faker.Create<ulong>();
			Assert.IsNotNull(ul);
			Assert.IsTrue( ul.GetType() == typeof( ulong ) );

			var ush = faker.Create<ushort>();
			Assert.IsNotNull(ush);
			Assert.IsTrue( ush.GetType() == typeof( ushort ) );

			//var s = faker.Create<string>();
			//Assert.IsNotNull( s );
			//Assert.IsTrue( s.GetType() == typeof( string ) );
		}

		[TestMethod]
		public void GenerateDateTimeTest()
		{
			var faker = new Faker.Core.Faker();

			var datetime = faker.Create<DateTime>();
			Assert.IsNotNull( datetime );
			Assert.IsTrue( datetime.GetType() == typeof( DateTime ) );
			
			foreach (var field in datetime.GetType().GetFields() )
				Assert.IsNotNull(field.GetValue( datetime ) );

			foreach ( var prop in datetime.GetType().GetProperties() )
				Assert.IsNotNull( prop.GetValue( datetime ) );
		}

		[TestMethod]
		public void GenerateList1dTest()
		{
			var faker = new Faker.Core.Faker();

			var listInt = faker.Create<List<int>>();
			Assert.IsNotNull( listInt );
			Assert.IsTrue( listInt.GetType() == typeof( List<int> ) );
			foreach (var i in listInt)
			{
				Assert.IsNotNull( i );
				Assert.IsTrue( i.GetType() == typeof( int) );
			}			
		}

		[TestMethod]
		public void GenerateList2dTest()
		{
			var faker = new Faker.Core.Faker();

			var listListInt = faker.Create< List<List<int>> >();
			Assert.IsNotNull( listListInt );
			Assert.IsTrue( listListInt.GetType() == typeof( List<List<int>> ) );
			foreach(var listInt in listListInt)
			{
				Assert.IsNotNull( listInt );
				Assert.IsTrue( listInt.GetType() == typeof( List<int> ) );
				foreach ( var i in listInt )
				{
					Assert.IsNotNull( i );
					Assert.IsTrue( i.GetType() == typeof( int ) );
				}
			}
		}

		[TestMethod]
		public void GenerateObjectWithoutRecursive()
		{
			var faker = new Faker.Core.Faker();
			
			var person = faker.Create<Person>();
			Assert.IsNotNull( person );
			Assert.IsTrue(person.GetType() == typeof( Person ) );

			foreach ( var field in person.GetType().GetFields() )
				Assert.IsNotNull( field.GetValue( person ) );

			foreach ( var prop in person.GetType().GetProperties() )
				Assert.IsNotNull( prop.GetValue( person ) );

		}

		[TestMethod]
		public void GenerateObjectWithRecursive()
		{
			int recLimit = 2;
			var faker = new Faker.Core.Faker( recLimit );

			var familyPerson = faker.Create<FamilyPerson>();
			Assert.IsNotNull( familyPerson );
			Assert.IsTrue( familyPerson.GetType() == typeof( FamilyPerson ) );
			
			foreach ( var field in familyPerson.GetType().GetFields() )			
				Assert.IsNotNull( field.GetValue(familyPerson) );

			foreach ( var prop in familyPerson.GetType().GetProperties() )
				Assert.IsNotNull( prop.GetValue( familyPerson ) );

			CheckRecursiveFillProps( recLimit, familyPerson );
		}

		private void CheckRecursiveFillProps(int currRecLevel, FamilyPerson familyPerson)
		{
			if (currRecLevel < 0)
				return;

			var fatherProp = familyPerson.GetType().GetProperties()
				.Where( p => p.PropertyType.Equals( typeof( FamilyPerson ) ) )
				.ToArray().First();

			if ( currRecLevel == 0 )
				Assert.IsNull( fatherProp.GetValue(familyPerson) );
			else
			{
				Assert.IsNotNull( fatherProp.GetValue( familyPerson ) );
				CheckRecursiveFillProps( --currRecLevel, (FamilyPerson)fatherProp.GetValue( familyPerson ) );
			}
		}

	}
}