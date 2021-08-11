using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Android.Tools.ObjectModel
{
	public class EnumType
	{
		public string Namespace { get; set; }
		public string Type { get; set; }

		public override string ToString () => $"{Namespace}.{Type}";
	}
}
