using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BindingStudio.Dialogs;
using BindingStudio.Panels;
using Java.Interop.Tools.Generator;
using Java.Interop.Tools.Generator.Enumification;
using Xamarin.Android.Tools.Fields;

namespace BindingStudio
{
	public partial class MainForm : Form
	{
		public const char CURRENT_API_NAME = 'S';
		public const int CURRENT_API_LEVEL = 32;

		private DataGridView grid;
		List<ConstantEntry> constants;
		List<MethodMapEntry> method_map;
		private List<string> updates = new List<string> ();
		private string open_constants_filename;
		private string open_methods_filename;
		private MethodMapPanel current_panel;

		string api_31_csv = @"C:\Users\jopobst\Desktop\api-31.csv";

		public MainForm ()
		{
			InitializeComponent ();

			grid = new DataGridView {
				Dock = DockStyle.Fill
			};

			ConstantsFileName = null;
			MethodsFileName = null;

			splitContainer1.Panel2.Controls.Add (grid);

			treeView1.NodeMouseClick += TreeView1_NodeMouseClick;

			newToolStripMenuItem.Click += NewToolStripMenuItem_Click;
			openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
			openMethodMapToolStripMenuItem.Click += OpenMethodMapToolStripMenuItem_Click;
			saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
			saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
		}

		public string ConstantsFileName {
			get => open_constants_filename;
			set {
				open_constants_filename = value;
				ConstantsFileToolStripLabel.Text = "Constants: " + (value.HasValue () ? Path.GetFileName (value) : "None");
			}
		}

		public string MethodsFileName {
			get => open_methods_filename;
			set {
				open_methods_filename = value;
				MethodMapFileToolStripLabel.Text = "Methods: " + (value.HasValue () ? Path.GetFileName (value) : "None");
			}
		}

		void NewToolStripMenuItem_Click (object sender, EventArgs e)
		{
			using var open = new OpenFileDialog {
				Title = "Choose api.xml file to import constants from:",
				Filter = "api.xml (*.xml)|*.xml"
			};

			if (open.ShowDialog () == DialogResult.OK) {
				var file = open.FileName;
				constants = ConstantsParser.FromApiXml (file);

				LoadTree ();
			}
		}

		void OpenToolStripMenuItem_Click (object sender, EventArgs e)
		{
			using var open = new OpenFileDialog {
				Title = "Choose .csv file to import constants from:",
				Filter = "CSV (*.csv)|*.csv"
			};

			if (open.ShowDialog () == DialogResult.OK) {
				var file = open.FileName;
				ConstantsFileName = file;
				constants = ConstantsParser.FromEnumMapCsv (file);

				// Ignore resource IDs
				foreach (var c in constants.Where (p => p.JavaSignature.StartsWith ("android/R$")))
					c.Action = ConstantAction.Ignore;

				LoadTree ();
			}
		}

		void OpenMethodMapToolStripMenuItem_Click (object sender, EventArgs e)
		{
			using var open = new OpenFileDialog {
				Title = "Choose .csv file to import method map from:",
				Filter = "CSV (*.csv)|*.csv"
			};

			if (open.ShowDialog () == DialogResult.OK) {
				var file = open.FileName;
				//var file = api_31_csv;
			MethodsFileName = file;
			method_map = MethodMapParser.FromMethodMapCsv (file);

			foreach (var method in method_map.Where (m => m.JavaName == "describeContents" && m.ParameterName == "return"))
				method.Action = MethodAction.Ignore;
			foreach (var method in method_map.Where (m => m.JavaName == "writeToParcel" && m.ParameterName == "flags")) {
				method.Action = MethodAction.Enumify;
				method.EnumFullType = "Android.OS.ParcelableWriteFlags";
			}
			foreach (var method in method_map.Where (m => m.ParameterName.ContainsAny ("length", "charat", "digits", "min", "max", "subsequence", "count", "uid", "index", "offset", "viewid")))
				method.Action = MethodAction.Ignore;

			foreach (var method in method_map.Where (c => c.ApiLevel == CURRENT_API_LEVEL && c.Action == MethodAction.None)) {
				var root = new MethodTreeNode (method);
				treeView1.Nodes.Add (root);
			}

			toolStripStatusLabel1.Text = treeView1.Nodes.Count.ToString () + " remaining";
			}
		}

		void SaveToolStripMenuItem_Click (object sender, EventArgs e)
		{
			if (method_map != null)
				MethodMapParser.SaveMethodMapCsv (method_map, MethodsFileName, true);
			else
				ConstantsParser.SaveEnumMapCsv (constants, ConstantsFileName);

			if (!ConstantsFileName.HasValue ()) {
				SaveAsToolStripMenuItem_Click (sender, e);
				return;
			}

		}

		void SaveAsToolStripMenuItem_Click (object sender, EventArgs e)
		{
			using var save = new SaveFileDialog {
				Title = "Choose .csv file to save:",
				Filter = "CSV (*.csv)|*.csv",
				FileName = "map.csv"
			};

			if (save.ShowDialog () == DialogResult.OK) {
				var file = save.FileName;
				ConstantsFileName = file;
				ConstantsParser.SaveEnumMapCsv (constants, file);
			}
		}

		void TreeView1_NodeMouseClick (object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node is MethodTreeNode method) {
				if (current_panel is null) {
					current_panel = new MethodMapPanel (constants);
					splitContainer1.Panel2.Controls.Add (current_panel);
					grid.Hide ();
				}

				current_panel.LoadEntry (method.Entry);
			} else {
				var cs = constants.Where (c => $"{c.JavaPackage}.{c.JavaType}" == e.Node.Text).ToList ();
				grid.DataSource = cs;
				grid.Show ();
			}
		}

		string api = @"C:\code\xamarin-android\src\Mono.Android\obj\Debug\monoandroid10\android-R\mcw\api.xml.fixed";
		//string api = @"C:\users\jopobst\desktop\api-dp2.xml.fixed";
		string enummap = @"C:\code\xamarin-android\src\Mono.Android\map.csv";
		string enummap2 = @"C:\code\xamarin-android\src\Mono.Android\removed.csv";



		private void LoadTree ()
		{
			treeView1.Nodes.Clear ();

			//foreach (var group in constants.GroupBy (c => $"{c.JavaPackage}.{c.JavaType}")) {
			foreach (var group in constants.Where (c => c.ApiLevel == CURRENT_API_LEVEL && c.Action == ConstantAction.None && !c.JavaSignature.StartsWith ("android/R$")).GroupBy (c => $"{c.JavaPackage}.{c.JavaType}")) {
				var root = new TreeNode (group.Key);
				treeView1.Nodes.Add (root);
			}
			//var existing_constants = ConstantsParser.FromEnumMapCsv (enummap);
			//var api_constants = ConstantsParser.FromApiXml (api);

			//var added_constants = api_constants.Except (existing_constants, JavaSignatureComparer.Instance).ToList ();
			//existing_constants.AddRange (added_constants);

			////var removed_constants = existing_constants.Where (c => c.Action != ConstantAction.Add).Except (api_constants, JavaSignatureComparer.Instance).ToList ();

			////foreach (var c in removed_constants)
			////	existing_constants.Remove (c);

			//constants = existing_constants;

			//ConstantsParser.SaveEnumMapCsv (constants, enummap2);

			////var cf = new ConstantsFinder ();
			////constants = cf.FindConstants ();

			//foreach (var group in constants.Where (c => c.ApiLevel == 30 && c.Action == ConstantAction.None).GroupBy (c => $"{c.JavaPackage}.{c.JavaType}")) {
			//	var root = new TreeNode (group.Key);
			//	treeView1.Nodes.Add (root);
			//}
		}


		IEnumerable<ConstantEntry> Filter (IEnumerable<ConstantEntry> values)
		{
			return values.Where (p =>
				!p.ToString ().StartsWithAny (
					"android.R",
					"javax.microedition",
					"dalvik.bytecode",
					"android.bluetooth.BluetoothAssignedNumbers"
			));
		}

		private void AddToExistingEnum_Click (object sender, EventArgs e)
		{
			var type_constants = (List<ConstantEntry>) grid.DataSource;
			var selected_constants = GetSelectedConstants ();

			var existing_enums = Xamarin.Android.Tools.Fields.UtilityExtensions.FindExistingEnumTypes (type_constants);

			var dialog = new AddToExistingDialog (existing_enums);

			if (dialog.ShowDialog (this) == DialogResult.OK) {
				var selected_enum = dialog.SelectedType;

				foreach (var c in selected_constants) {
					c.Action = ConstantAction.Enumify;
					c.EnumFullType = selected_enum.ToString ();
					c.EnumMember = NamingConverter.ConvertFieldToCSharp (c.JavaName);
					c.FieldAction = FieldAction.Remove;
					c.IsFlags = Xamarin.Android.Tools.Fields.UtilityExtensions.EnumIsFlags (type_constants, selected_enum);
				}
			}
		}

		private void CreateNewEnum_Click (object sender, EventArgs e)
		{
			var selected_constants = GetSelectedConstants ();

			var dialog = new CreateNewEnumDialog (selected_constants);

			if (dialog.ShowDialog (this) == DialogResult.OK) {
				foreach (var c in selected_constants) {
					c.Action = ConstantAction.Enumify;
					c.EnumFullType = dialog.EnumNamespace + "." + dialog.EnumName;
					c.EnumMember = NamingConverter.ConvertFieldToCSharp (c.JavaName).Substring (dialog.FieldPrefix.Length);
					c.FieldAction = FieldAction.Remove;
					c.IsFlags = dialog.IsFlags;
				}
			}
		}

		private List<ConstantEntry> GetSelectedConstants ()
		{
			return grid.SelectedRows.Cast<DataGridViewRow> ().Select (p => p.DataBoundItem).Cast<ConstantEntry> ().ToList ();
		}

		string methodmap = @"C:\code\xamarin-android\src\Mono.Android\methods-R - Copy (4).csv";
		string newmethodmap = @"C:\code\xamarin-android\src\Mono.Android\method-r2.csv";
		string orphanmap = @"C:\code\xamarin-android\src\Mono.Android\orphans.csv";
		string unnamed_params = @"C:\code\xamarin-android\src\Mono.Android\unnamed-params.csv";

		private void FindMethodsUsingNonexistantEnums (string enumMap)
		{
			var existing_methods = MethodMapParser.FromMethodMapCsv (methodmap).Where (p => p.ApiLevel == 30).ToList ();
			var existing_constants = ConstantsParser.FromEnumMapCsv (enumMap);
			var existing_enums = existing_constants.Select (p => p.EnumFullType).Distinct ().ToImmutableSortedSet ();

			var orphans = existing_methods.Where (m => !existing_enums.Contains (m.EnumFullType)).ToList ();

			MethodMapParser.SaveMethodMapCsv (orphans, orphanmap, true);
		}

		private void IgnoreConstant_Click (object sender, EventArgs e)
		{
			var selected_constants = GetSelectedConstants ();

			foreach (var item in selected_constants)
				item.Action = ConstantAction.Ignore;
		}

		// Searches an api.xml file for new constants to add to an existing map.csv.
		private void AddAPILevelConstantsToolStripMenuItem_Click (object sender, EventArgs e)
		{
			using var dialog = new AddApiLevelConstants ();

			if (dialog.ShowDialog (this) == DialogResult.OK) {
				// Load existing map.csv
				var existing_constants = ConstantsParser.FromEnumMapCsv (dialog.SelectedMapCsv);

				// Load new constants
				var api_constants = ConstantsParser.FromApiXml (dialog.SelectedApiXml);

				foreach (var c in existing_constants.Where (p => p.ApiLevel == 0).ToList ()) {
					var match = api_constants.FirstOrDefault (p => p.JavaSignature == c.JavaSignature);

					if (match != null)
						c.ApiLevel = match.ApiLevel;
				}


				// Merge the two
				var added_constants = api_constants.Except (existing_constants, JavaSignatureComparer.Instance).ToList ();
				existing_constants.AddRange (added_constants);

				// Populate the GUI
				ConstantsFileName = dialog.SelectedMapCsv;
				constants = existing_constants;

				LoadTree ();
			}
		}

		// Searches an api.xml file for new methods that involve an int
		private void FindAPILevelMethodsToolStripMenuItem_Click (object sender, EventArgs e)
		{
			// The api.xml file for the new API level
			var api = @"C:\code\xamarin-android\src\Mono.Android\obj\Debug\net6.0\android-32\mcw\api.xml";

			// Output method map for new API level
			// This should be a new file, not the existing methodmap.csv
			var csv = @"C:\Users\jopobst\Desktop\api-32-new-methods.csv";


			//var existing = @"C:\Users\jopobst\Desktop\api-31.csv";

			//var existing_methods = MethodMapParser.FromMethodMapCsv (existing);
			var methods = MethodMapParser.FromApiXml (api);

			// Copy new data to existing file
			//foreach (var method in existing_methods) {
			//	var new_method = methods.Find (m => m.JavaSignature == method.JavaSignature);

			//	if (method.ParameterName == "p0")
			//		Console.WriteLine ();

			//	if (new_method != null)
			//		method.ParameterName = new_method.ParameterName;
			//}

			// Add new "31" methods
			var new_methods = methods.Where (r => r.ApiLevel == CURRENT_API_LEVEL).ToList ();

			//foreach (var method in api_31)
			//	if (!existing_methods.Contains (method, MethodMapEntry.MethodMapComparer.Instance))
			//		existing_methods.Add (method);

			//MethodMapParser.SaveMethodMapCsv (existing_methods, existing);
			MethodMapParser.SaveMethodMapCsv (new_methods, csv, true);

			MessageBox.Show ("Done");
		}

		private void ExportFinalMethodMapToolStripMenuItem_Click (object sender, EventArgs e)
		{
			using var dialog = new SaveFileDialog {
				Title = "Choose .csv file to save:",
				Filter = "CSV (*.csv)|*.csv",
				FileName = "map.csv"
			};

			if (dialog.ShowDialog () == DialogResult.OK) {
				var file = dialog.FileName;
				var final = method_map.Where (m => m.Action == MethodAction.Enumify);

				MethodMapParser.SaveMethodMapCsv (final, file, false);
			}
		}

		private void DumpAPILevelUnnamedParametersToolStripMenuItem_Click (object sender, EventArgs e)
		{
			using var open = new OpenFileDialog {
				Title = "Choose api.xml file to dump unnamed parameters from:",
				Filter = "api.xml (*.xml)|*.xml"
			};

			if (open.ShowDialog () == DialogResult.OK) {
				var file = open.FileName;
				var api_methods = MethodMapParser.FromApiXml (file).Where (p => p.ApiLevel == CURRENT_API_LEVEL).ToList ();
				var unnamed = api_methods.Where (p => p.ParameterName.StartsWith ('p') && p.ParameterName.Length == 2).ToList ();

				var sb = new StringWriter ();
				MethodMapParser.SaveMethodMapCsv (unnamed, sb, true);

				if (sb.ToString ().Length > 0) {
					Clipboard.SetText (sb.ToString ());
					MessageBox.Show ("Results placed in clipboard");
				} else
					MessageBox.Show ($"No unnamed parameters found for API level {CURRENT_API_LEVEL}"); ;
			}
		}
	}
}
