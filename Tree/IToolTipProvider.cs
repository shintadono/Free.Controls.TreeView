using Free.Controls.TreeView.Tree.NodeControls;

namespace Free.Controls.TreeView.Tree
{
	public interface IToolTipProvider
	{
		string GetToolTip(TreeNodeAdv node, NodeControl nodeControl);
	}
}
