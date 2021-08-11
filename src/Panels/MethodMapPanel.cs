using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Java.Interop.Tools.Generator.Enumification;
using Microsoft.Web.WebView2.WinForms;

namespace BindingStudio.Panels
{
	public partial class MethodMapPanel : UserControl
	{
		private MethodMapEntry entry;
		private List<ConstantEntry> constants;

		WebView2 web;

		public MethodMapPanel ()
		{
			InitializeComponent ();
			web = new WebView2 {
				Top = 0,
				Left = 0,
				Width = 1400,
				Height = 800,
				Dock = DockStyle.Top
			};


			((ISupportInitialize) web).BeginInit ();
			//web.Dock = DockStyle.Fill;
			Controls.Add (web);
			((ISupportInitialize) web).EndInit ();
			//Controls.Add (web);
			web.Source = new Uri ("https://google.com");
			//web.Show ();

		}

		public MethodMapPanel (List<ConstantEntry> constants) : this ()
		{
			Dock = DockStyle.Fill;
			this.constants = constants;

			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			listBox2.SelectedIndexChanged += ListBox2_SelectedIndexChanged;
		}

		void ListBox2_SelectedIndexChanged (object sender, EventArgs e)
		{
			if (listBox2.SelectedItem is null)
				return;

			var selected = listBox2.SelectedItem.ToString ();

			var constant = constants.FirstOrDefault (c => c.JavaSignature == selected);

			if (constant != null) {
				var index = comboBox1.Items.IndexOf (constant.EnumFullType);
				comboBox1.SelectedIndex = index;
			}

		}

		string current_url;

		public async void LoadEntry (MethodMapEntry entry)
		{
			this.entry = entry;

			label1.Text = entry.JavaSignature;
			label2.Text = "Parameter Name: " + entry.ParameterName;

			radioButton1.Checked = entry.Action == MethodAction.None;
			radioButton2.Checked = entry.Action == MethodAction.Ignore;
			radioButton3.Checked = entry.Action == MethodAction.Enumify;

			var package = entry.JavaPackage;

			if (package.StartsWith ("I:"))
				package = package.Substring (2);

			var url = @"https://developer.android.com/reference/" + package + "/" + entry.JavaType.Replace ('$', '.');

			if (url != current_url) {
				current_url = url;
				await web.EnsureCoreWebView2Async ();
				web.Source = new Uri (url);
			}

			comboBox1.Items.Clear ();
			comboBox1.Items.AddRange (constants.Select (p => p.EnumFullType).OrderBy (p => p).Distinct ().ToArray ());

			listBox1.Items.Clear ();
		}

		void ComboBox1_SelectedIndexChanged (object sender, EventArgs e)
		{
			var enu = comboBox1.SelectedItem.ToString ();
			var members = constants.Where (p => p.EnumFullType == enu);

			listBox1.Items.Clear ();
			listBox1.Items.AddRange (members.OrderBy (p => p.JavaSignature).Select (p => p.JavaSignature).ToArray ());
		}

		private void btnSave_Click (object sender, EventArgs e)
		{
			if (radioButton1.Checked)
				entry.Action = MethodAction.None;
			else if (radioButton2.Checked)
				entry.Action = MethodAction.Ignore;
			else if (radioButton3.Checked)
				entry.Action = MethodAction.Enumify;

			if (entry.Action == MethodAction.Enumify) {
				if (comboBox1.SelectedItem is null) {
					MessageBox.Show ("No enum selected, save aborted");
					return;
				}
				entry.EnumFullType = comboBox1.SelectedItem.ToString ();
			} else
				entry.EnumFullType = null;
		}

		private void btnSearch_Click (object sender, EventArgs e)
		{
			var matches = constants.Where (c => c.JavaName.Contains (textBox1.Text, StringComparison.OrdinalIgnoreCase));

			listBox2.Items.Clear ();
			listBox2.Items.AddRange (matches.Select (c => c.JavaSignature).ToArray ());
		}
	}
}
