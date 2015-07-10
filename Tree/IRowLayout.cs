using System.Drawing;

namespace Free.Controls.TreeView.Tree
{
	internal interface IRowLayout
	{
		int PreferredRowHeight
		{
			get;
			set;
		}

		int PageRowCount
		{
			get;
		}

		int CurrentPageSize
		{
			get;
		}

		Rectangle GetRowBounds(int rowNo);

		int GetRowAt(Point point);

		int GetFirstRow(int lastPageRow);

		void ClearCache();
	}
}
