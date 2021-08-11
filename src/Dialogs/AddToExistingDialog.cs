using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Xamarin.Android.Tools.ObjectModel;

namespace BindingStudio.Dialogs
{
	public partial class AddToExistingDialog : Form
	{
		public AddToExistingDialog ()
		{
			InitializeComponent ();
		}

		public AddToExistingDialog (List<EnumType> types) : this ()
		{
			comboBox1.Items.AddRange (types.ToArray ());
			comboBox1.SelectedIndex = 0;
		}

		public EnumType SelectedType => (EnumType)comboBox1.SelectedItem;
	}
}
