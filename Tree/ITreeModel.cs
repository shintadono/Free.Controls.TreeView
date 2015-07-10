using System;
using System.Collections;

namespace Free.Controls.TreeView.Tree
{
	public interface ITreeModel
	{
		IEnumerable GetChildren(TreePath treePath);
		bool IsLeaf(TreePath treePath);

		event EventHandler<TreeModelEventArgs> NodesChanged;
		event EventHandler<TreeModelEventArgs> NodesInserted;
		event EventHandler<TreeModelEventArgs> NodesRemoved;
		event EventHandler<TreePathEventArgs> StructureChanged;
	}
}
