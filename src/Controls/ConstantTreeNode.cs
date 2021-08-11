using System.Windows.Forms;
using Java.Interop.Tools.Generator.Enumification;

namespace BindingStudio
{
	class ConstantTreeNode : TreeNode
	{
		public ConstantEntry Entry { get; set; }

		public ConstantTreeNode (ConstantEntry entry)
		{
			Entry = entry;
		}
	}
}
