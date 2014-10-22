using System;
using System.Linq;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Extensions
{
	public static class TypeExtension
	{
		#region Methods

		public static bool IsAssignableToGenericType(this Type type, Type potentialGenericType)
		{
			if(type == null)
				throw new ArgumentNullException("type");

			if(potentialGenericType == null)
				throw new ArgumentNullException("potentialGenericType");

			var interfaceTypes = type.GetInterfaces();

			if(interfaceTypes.Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == potentialGenericType))
				return true;

			if(type.IsGenericType && type.GetGenericTypeDefinition() == potentialGenericType)
				return true;

			var baseType = type.BaseType;

			return baseType != null && IsAssignableToGenericType(baseType, potentialGenericType);
		}

		#endregion
	}
}