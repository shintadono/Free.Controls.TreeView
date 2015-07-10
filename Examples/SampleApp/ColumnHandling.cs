using System;
using System.Windows.Forms;

namespace SampleApp
{
    public partial class ColumnHandling : UserControl
    {
        public ColumnHandling()
        {
            InitializeComponent();
        }

		private void treeViewAdv1_NodeMouseDoubleClick(object sender, Free.Controls.TreeView.Tree.TreeNodeAdvMouseEventArgs e)
		{
			Console.WriteLine("DblClick {0}", e.Node);
		}
    }
}
