using System.Collections;

namespace Faker.Core.ValueGenerators.DataGenerators
{
	public class ListGenerator : IValueGenerator
	{
		public bool CanGenerate( Type type )
		{
			return type.IsGenericType && type.GetInterfaces().Contains( typeof( IList ) );
		}

		public object Generate( Type typeToGenerate, GeneratorContext context )
		{
			var list = (IList) Activator.CreateInstance( typeToGenerate, context.Random.Next(15) );
			for ( int i = 0; i < list.Count; i++ )
				list[ i ] = context.Faker.Create( typeToGenerate.GenericTypeArguments[ 0 ] );

			return list;
		}
	}
}
