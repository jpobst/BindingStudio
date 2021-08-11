using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Java.Interop.Tools.Generator.Enumification;
using Microsoft.VisualBasic;

namespace BindingStudio.Dialogs
{
	public partial class AddApiLevelConstants : Form
	{
		public AddApiLevelConstants ()
		{
			InitializeComponent ();
		}

		private void btnSelectMapCsv_Click (object sender, EventArgs e)
		{
			using var open = new OpenFileDialog {
				Title = "Choose existing map.csv file to add constants to:",
				Filter = "map.csv (*.csv)|*.csv"
			};

			if (open.ShowDialog () == DialogResult.OK)
				txtMapCsv.Text = open.FileName;
		}

		private void btnSelectApiXml_Click (object sender, EventArgs e)
		{
			using var open = new OpenFileDialog {
				Title = "Choose api.xml file to import constants from:",
				Filter = "api.xml (*.xml)|*.xml"
			};

			if (open.ShowDialog () == DialogResult.OK)
				txtApiXml.Text = open.FileName;
		}

		public string SelectedMapCsv => txtMapCsv.Text;

		public string SelectedApiXml => txtApiXml.Text;
	}
}
