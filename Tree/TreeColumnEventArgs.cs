using System;

namespace Free.Controls.TreeView.Tree
{
	public class TreeColumnEventArgs : EventArgs
	{
		private TreeColumn _column;
		public TreeColumn Column
		{
			get { return _column; }
		}

		public TreeColumnEventArgs(TreeColumn column)
		{
			_column=column;
		}
	}
}
