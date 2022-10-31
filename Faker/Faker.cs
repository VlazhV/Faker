using Faker.Core;
using Faker.Core.ValueGenerators;
using System.Reflection;

namespace Faker
{
	public class Faker : IFaker
	{
		private GeneratorContext _context;
		private List<IValueGenerator> _generators;
		

		public Faker ()
		{			
			_generators = Load();
			_context = new GeneratorContext( new Random(), this );			
		}

		public T Create<T>()
		{
			return (T) Create(typeof(T));
		}

		public object Create( Type t )
		{
			throw new NotImplementedException();
		}

		private object CreateObject (Type type)
		{
			var constructors = type.GetConstructors().ToList().OrderByDescending( c => c.GetParameters().Length ).ToList();
			foreach (var constructor in constructors)
			{
				try
				{
					return constructor.Invoke( constructor.GetParameters().Select( info => {
						if ()
					} );
				}
				catch (Exception )
				{ }
			}
		}

		private static List<IValueGenerator> Load()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var generators = assembly.DefinedTypes
				.Where( t => t.IsAssignableTo( typeof( IValueGenerator ) ) && t.IsClass )
				.Select( i => (IValueGenerator)Activator.CreateInstance( i ) )
				.ToList();
			return generators;
		}

		

		private void FillMembers (Type type, object o)
		{
			var fields = type.GetFields();
			foreach (var field in fields)
			{
				var isDefault = Equal( field.GetValue( o ), Default( field.FieldType));

			}
		}


		private static bool Equal(object? o1, object? o2)
		{
			if ( o1 != null )
				return o1.Equals( o2 );
			else
				return o2 == null; 
		}

		private static object? Default(Type type)
		{
			if ( type.IsValueType )
				return Activator.CreateInstance( type );
			else
				return null;
		}
	}
}