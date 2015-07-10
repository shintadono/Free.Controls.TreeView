namespace SampleApp
{
    partial class ColumnHandling
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			this.treeViewAdv1 = new Free.Controls.TreeView.Tree.TreeViewAdv();
			this.treeColumn1 = new Free.Controls.TreeView.Tree.TreeColumn();
			this.treeColumn2 = new Free.Controls.TreeView.Tree.TreeColumn();
			this.treeColumn3 = new Free.Controls.TreeView.Tree.TreeColumn();
			this.treeColumn4 = new Free.Controls.TreeView.Tree.TreeColumn();
			this.treeColumn5 = new Free.Controls.TreeView.Tree.TreeColumn();
			this.SuspendLayout();
			// 
			// treeViewAdv1
			// 
			this.treeViewAdv1.AllowColumnReorder = true;
			this.treeViewAdv1.BackColor = System.Drawing.SystemColors.Window;
			this.treeViewAdv1.Columns.Add(this.treeColumn1);
			this.treeViewAdv1.Columns.Add(this.treeColumn2);
			this.treeViewAdv1.Columns.Add(this.treeColumn3);
			this.treeViewAdv1.Columns.Add(this.treeColumn4);
			this.treeViewAdv1.Columns.Add(this.treeColumn5);
			this.treeViewAdv1.Cursor = System.Windows.Forms.Cursors.Default;
			this.treeViewAdv1.DefaultToolTipProvider = null;
			this.treeViewAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewAdv1.DragDropMarkColor = System.Drawing.Color.Black;
			this.treeViewAdv1.GridLineStyle = ((Free.Controls.TreeView.Tree.GridLineStyle)((Free.Controls.TreeView.Tree.GridLineStyle.Horizontal | Free.Controls.TreeView.Tree.GridLineStyle.Vertical)));
			this.treeViewAdv1.LineColor = System.Drawing.SystemColors.ControlDark;
			this.treeViewAdv1.Location = new System.Drawing.Point(0, 0);
			this.treeViewAdv1.Model = null;
			this.treeViewAdv1.Name = "treeViewAdv1";
			this.treeViewAdv1.SelectedNode = null;
			this.treeViewAdv1.Size = new System.Drawing.Size(626, 406);
			this.treeViewAdv1.TabIndex = 0;
			this.treeViewAdv1.Text = "treeViewAdv1";
			this.treeViewAdv1.UseColumns = true;
			this.treeViewAdv1.NodeMouseDoubleClick += new System.EventHandler<Free.Controls.TreeView.Tree.TreeNodeAdvMouseEventArgs>(this.treeViewAdv1_NodeMouseDoubleClick);
			// 
			// treeColumn1
			// 
			this.treeColumn1.Header = "Hiddenable";
			this.treeColumn1.SortOrder = System.Windows.Forms.SortOrder.None;
			this.treeColumn1.TooltipText = "qweqweqwe";
			this.treeColumn1.Width = 100;
			// 
			// treeColumn2
			// 
			this.treeColumn2.Header = "Min width 10";
			this.treeColumn2.MinColumnWidth = 10;
			this.treeColumn2.SortOrder = System.Windows.Forms.SortOrder.None;
			this.treeColumn2.TooltipText = "xcvxcxcvxcvxv";
			this.treeColumn2.Width = 150;
			// 
			// treeColumn3
			// 
			this.treeColumn3.Header = "Fixed 100";
			this.treeColumn3.MaxColumnWidth = 100;
			this.treeColumn3.MinColumnWidth = 100;
			this.treeColumn3.SortOrder = System.Windows.Forms.SortOrder.None;
			this.treeColumn3.TooltipText = "12312312313";
			this.treeColumn3.Width = 100;
			// 
			// treeColumn4
			// 
			this.treeColumn4.Header = "Max width 150";
			this.treeColumn4.MaxColumnWidth = 150;
			this.treeColumn4.SortOrder = System.Windows.Forms.SortOrder.None;
			this.treeColumn4.TooltipText = null;
			this.treeColumn4.Width = 150;
			// 
			// treeColumn5
			// 
			this.treeColumn5.Header = "Hiddenable";
			this.treeColumn5.SortOrder = System.Windows.Forms.SortOrder.None;
			this.treeColumn5.TooltipText = null;
			this.treeColumn5.Width = 75;
			// 
			// ColumnHandling
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.treeViewAdv1);
			this.Name = "ColumnHandling";
			this.Size = new System.Drawing.Size(626, 406);
			this.ResumeLayout(false);

        }

        #endregion

		private Free.Controls.TreeView.Tree.TreeViewAdv treeViewAdv1;
		private Free.Controls.TreeView.Tree.TreeColumn treeColumn1;
		private Free.Controls.TreeView.Tree.TreeColumn treeColumn2;
		private Free.Controls.TreeView.Tree.TreeColumn treeColumn3;
		private Free.Controls.TreeView.Tree.TreeColumn treeColumn4;
		private Free.Controls.TreeView.Tree.TreeColumn treeColumn5;
    }
}
