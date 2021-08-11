using System;
using System.Collections.Generic;
using System.Linq;
using Java.Interop.Tools.Generator;
using Java.Interop.Tools.Generator.Enumification;
using Xamarin.Android.Tools.ObjectModel;

namespace Xamarin.Android.Tools.Fields
{
	public static class UtilityExtensions
	{
		public static bool ContainsAny (this string enumeration, params string[] values)
		{
			foreach (var en in values)
				if (enumeration.Contains (en, StringComparison.OrdinalIgnoreCase))
					return true;

			return false;
		}

		//public static bool In<T> (this T enumeration, params T [] values) //where T : Enum
		//{
		//	foreach (var en in values)
		//		if (enumeration.Equals (en))
		//			return true;

		//	return false;
		//}

		//public static bool StartsWithAny (this string value, params string [] values)
		//{
		//	foreach (var en in values)
		//		if (value.StartsWith (en, StringComparison.OrdinalIgnoreCase))
		//			return true;

		//	return false;
		//}

		//public static bool HasValue (this string str) => !string.IsNullOrEmpty (str);

		public static List<EnumType> FindExistingEnumTypes (List<ConstantEntry> constants)
		{
			var types = constants.Where (c => c.EnumNamespace.HasValue ()).Select (c => new EnumType { Namespace = c.EnumNamespace, Type = c.EnumType });

			return types.GroupBy (c => c.ToString ()).Select (group => group.First ()).ToList ();
		}

		public static bool EnumIsFlags (List<ConstantEntry> constants, EnumType type)
		{
			var types = constants.Where (c => c.EnumFullType == type.ToString ());

			return types.Any (c => c.IsFlags);
		}
	}
}
