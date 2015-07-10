using System;

namespace Free.Controls.TreeView.Tree
{
	public class TreeViewAdvEventArgs : EventArgs
	{
		private TreeNodeAdv _node;

		public TreeNodeAdv Node
		{
			get { return _node; }
		}

		public TreeViewAdvEventArgs(TreeNodeAdv node)
		{
			_node=node;
		}
	}
}
