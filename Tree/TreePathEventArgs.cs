using System;

namespace Free.Controls.TreeView.Tree
{
	public class TreePathEventArgs : EventArgs
	{
		private TreePath _path;
		public TreePath Path
		{
			get { return _path; }
		}

		public TreePathEventArgs()
		{
			_path=new TreePath();
		}

		public TreePathEventArgs(TreePath path)
		{
			if(path==null)
				throw new ArgumentNullException();

			_path=path;
		}
	}
}
