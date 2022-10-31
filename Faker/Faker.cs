using Faker.Core.ValueGenerators;
using System.Reflection;

namespace Faker.Core
{
	public class Faker : IFaker
	{
		private GeneratorContext _context;
		private List<IValueGenerator> _generators;

		public int RecursiveLimit { get; } = 3;

		private Dictionary<Type, int> _currentRecursiveLevels = new Dictionary<Type, int>();
		

		public Faker ()
		{			
			_generators = Load();
			_context = new GeneratorContext( new Random(), this );			
		}

		public Faker(int maxRecursiveLevel)
		{
			RecursiveLimit = maxRecursiveLevel;
			_generators = Load();
			_context = new GeneratorContext( new Random(), this );
		}

		private bool IsOverRecursiveLimit(Type t)
		{
			return (_currentRecursiveLevels.ContainsKey(t) && _currentRecursiveLevels[t] > RecursiveLimit);
		}

		private void IncrementCurrentRecursiveLevel(Type t)
		{
			if ( _currentRecursiveLevels.ContainsKey( t ) )
				++_currentRecursiveLevels[ t ];			
			else
				_currentRecursiveLevels.Add( t, 1 );
		}

		private void DecrementCurrentRecursiveLevels(Type t)
		{			
			--_currentRecursiveLevels[ t ];
			if ( _currentRecursiveLevels[ t ] == 0 )
				_currentRecursiveLevels.Remove( t );
		}


		public T Create<T>()
		{
			return (T) Create(typeof(T));
		}

		public object Create( Type t )
		{
			object? o = null;
			if ( IsOverRecursiveLimit( t ) )
				return o;

			IncrementCurrentRecursiveLevel( t );
			var generator = ChooseGenerator( t );
			if ( generator != null )
				o = generator.Generate( t, _context );
			else
			{
	
				var constructors = t.GetConstructors().ToList()
					.OrderByDescending( c => c.GetParameters().Length ).ToList(); 
			
				foreach ( var constructor in constructors )
				{
					try
					{
						o = constructor.Invoke( constructor.GetParameters().Select( paramInfo => {
								var paramGenerator = ChooseGenerator( paramInfo.ParameterType );
								if ( paramGenerator != null)
								{
									return paramGenerator.Generate( paramInfo.ParameterType, _context );
								}
								else
								{
									return Create( paramInfo.ParameterType );
								}
							}).ToArray() );
						break;
					}
					catch ( Exception ) { }
				}
				if ( o == null )
					o = Default( t );

				if ( o != null )
					FillFieldsAndProperties( t, o );
			}

			DecrementCurrentRecursiveLevels( t );

			return o;
		}


		private IValueGenerator? ChooseGenerator(Type t)
		{
			foreach ( var generator in _generators )
			{
				if (generator.CanGenerate(t))
					return generator;
			}
			return null;
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

		

		private void FillFieldsAndProperties (Type type, object o)
		{
			var fields = type.GetFields();
			foreach (var field in fields)
			{

				if ( field.GetValue( o ) != null )
					continue;
				var generator = ChooseGenerator( field.FieldType );				
				field.SetValue( o, generator != null
						? generator.Generate( field.FieldType, _context ) 
						: Create( field.FieldType ) );
			}

			var props = type.GetProperties();
			props = o.GetType().GetProperties();
			foreach (var prop in props)
			{
				
				if ( prop.GetValue( o ) != null )
					continue;

				var generator = ChooseGenerator( prop.PropertyType );
								
				prop.SetValue( o, generator != null
						? generator.Generate( prop.PropertyType, _context )
						: Create( prop.PropertyType ) );

			}


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