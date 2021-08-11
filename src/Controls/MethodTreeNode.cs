using System.Windows.Forms;
using Java.Interop.Tools.Generator.Enumification;

namespace BindingStudio
{
	class MethodTreeNode : TreeNode
	{
		public MethodMapEntry Entry { get; set; }

		public MethodTreeNode (MethodMapEntry entry) : base (entry.JavaSignature)
		{
			Entry = entry;
		}
	}
}
