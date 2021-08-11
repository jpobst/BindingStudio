using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Java.Interop.Tools.Generator;
using Java.Interop.Tools.Generator.Enumification;

namespace BindingStudio.Dialogs
{
	public partial class CreateNewEnumDialog : Form
	{
		public CreateNewEnumDialog ()
		{
			InitializeComponent ();
		}

		public CreateNewEnumDialog (List<ConstantEntry> constants) : this ()
		{

			textBox1.Text = NamingConverter.ConvertNamespaceToCSharp (constants.First ().JavaPackage.Replace ('/', '.'));

			FieldPrefix = CreateDefaultEnumName (constants);
			textBox2.Text = NamingConverter.ConvertClassToCSharp (constants.First ().JavaType) + FieldPrefix;

			//textBox2.Text = NamingConverter.ConvertClassToCSharp (constants.First ().JavaType) + "." + NamingConverter.ConvertFieldToCSharp (constants.First ().JavaName);
		}

		public string EnumNamespace => textBox1.Text;
		public string EnumName => textBox2.Text;
		public bool IsFlags => checkBox1.Checked;
		public string FieldPrefix { get; set; }

		private string CreateDefaultEnumName (List<ConstantEntry> constants)
		{

			var fields = constants.Select (c => c.JavaName).ToList ();

			var sb = new StringBuilder ();

			// Find the common characters among the field names
			// ex:
			// FOREGROUND_SERVICE_IMMEDIATE
			// FOREGROUND_SERVICE_DEFERRED
			// FOREGROUND_SERVICE_DEFAULT
			for (var i = 0; i < fields.Min (f => f.Length); i++) {
				var c = fields.First () [i];

				if (fields.All (f => f [i] == c))
					sb.Append (c);
				else
					break;
			}

			var result = sb.ToString ();

			if (result.Length == 0)
				return string.Empty;

			// Need to remove trailing extra chars:
			// FOREGROUND_SERVICE_
			var index = result.LastIndexOf ('_');

			if (index == -1)
				return result;

			return NamingConverter.ConvertFieldToCSharp (result.Substring (0, index));
		}
	}
}
