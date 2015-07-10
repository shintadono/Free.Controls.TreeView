using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace Free.Controls.TreeView.Tree.NodeControls
{
	public class ProgressData : Node
	{
		public new string Text { get; internal set; }
		public int Position { get; private set; }

		public ProgressData(string text, int pos)
		{
			Text=text;
			Position=pos;
		}

		public override string ToString()
		{
			return Text;
		}
	}

	public class NodeTextBoxWithProgress : BaseTextControl
	{
		//Variablen
		private const int MinTextBoxWidth=30;

		//Eigenschaften
		public Color ActiveFirstColor { get; set; }
		public Color ActiveSecondColor { get; set; }
		public Color NonActiveFirstColor { get; set; }
		public Color NonActiveSecondColor { get; set; }
		public Color BorderColor { get; set; }
		public Color ForeColor { get; set; }

		public bool MaximizeControl { get; set; }

		int minimum=0;
		[DefaultValue(0)]
		public int Minimum
		{
			get { return minimum; }
			set { minimum=value; }
		}

		int maximum=100;
		[DefaultValue(100)]
		public int Maximum
		{
			get { return maximum; }
			set { maximum=value; }
		}

		int _value=50;
		[DefaultValue(50)]
		public int Value
		{
			get { return _value; }
			set { _value=value; }
		}

		public NodeTextBoxWithProgress()
		{
			//VerticalAlign=VerticalAlignment.Top; //damit der Text oben steht

			//Maximize
			MaximizeControl=true;

			//Color
			ActiveFirstColor=Color.FromArgb(0, 49, 43);

			ActiveSecondColor=Color.GreenYellow;
			NonActiveFirstColor=Color.FromArgb(39, 39, 39);
			NonActiveSecondColor=Color.Gray;
			BorderColor=Color.Black;
			ForeColor=Color.White;
		}

		public override void SetValue(TreeNodeAdv node, object value)
		{
			if(VirtualMode)
			{
				NodeControlValueEventArgs args=new NodeControlValueEventArgs(node);
				args.Value=value;
				OnValuePushed(args);
			}
			else
			{
				try
				{
					MemberAdapter ma=GetMemberAdapter(node);
					((ProgressData)(ma.Value)).Text=(string)value;
				}
				catch(TargetInvocationException ex)
				{
					if(ex.InnerException!=null)
						throw new ArgumentException(ex.InnerException.Message, ex.InnerException);
					else
						throw new ArgumentException(ex.Message);
				}
			}
		}

		protected override Size CalculateEditorSize(EditorContext context)
		{
			if(Parent.UseColumns)
			{
				return context.Bounds.Size;
			}
			else
			{
				Size size=GetLabelSize(context.CurrentNode, context.DrawContext, _label);
				int width=Math.Max(size.Width+Font.Height, MinTextBoxWidth); // reserve a place for new typed character
				return new Size(width, size.Height);
			}
		}

		public override void KeyDown(KeyEventArgs args)
		{
			if(args.KeyCode==Keys.F2&&Parent.CurrentNode!=null&&EditEnabled)
			{
				args.Handled=true;
				BeginEdit();
			}
		}

		protected override Control CreateEditor(TreeNodeAdv node)
		{
			TextBox textBox=CreateTextBox();
			textBox.TextAlign=TextAlign;
			textBox.Text=GetLabel(node);
			textBox.BorderStyle=BorderStyle.FixedSingle;
			textBox.TextChanged+=EditorTextChanged;
			textBox.KeyDown+=EditorKeyDown;
			_label=textBox.Text;
			SetEditControlProperties(textBox, node);
			return textBox;
		}

		protected virtual TextBox CreateTextBox()
		{
			return new TextBox();
		}

		protected override void DisposeEditor(Control editor)
		{
			var textBox=editor as TextBox;
			textBox.TextChanged-=EditorTextChanged;
			textBox.KeyDown-=EditorKeyDown;
		}

		private void EditorKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
				EndEdit(false);
			else if(e.KeyCode==Keys.Enter)
				EndEdit(true);
		}

		private string _label;
		private void EditorTextChanged(object sender, EventArgs e)
		{
			var textBox=sender as TextBox;
			_label=textBox.Text;
			Parent.UpdateEditorBounds();
		}

		protected override void DoApplyChanges(TreeNodeAdv node, Control editor)
		{
			var label=(editor as TextBox).Text;
			string oldLabel=GetLabel(node);
			if(oldLabel!=label)
			{
				SetLabel(node, label);
				OnLabelChanged(node.Tag, oldLabel, label);
			}
		}

		public override void Cut(Control control)
		{
			(control as TextBox).Cut();
		}

		public override void Copy(Control control)
		{
			(control as TextBox).Copy();
		}

		public override void Paste(Control control)
		{
			(control as TextBox).Paste();
		}

		public override void Delete(Control control)
		{
			var textBox=control as TextBox;
			int len=Math.Max(textBox.SelectionLength, 1);
			if(textBox.SelectionStart<textBox.Text.Length)
			{
				int start=textBox.SelectionStart;
				textBox.Text=textBox.Text.Remove(textBox.SelectionStart, len);
				textBox.SelectionStart=start;
			}
		}

		public event EventHandler<LabelEventArgs> LabelChanged;
		protected void OnLabelChanged(object subject, string oldLabel, string newLabel)
		{
			if(LabelChanged!=null)
				LabelChanged(this, new LabelEventArgs(subject, oldLabel, newLabel));
		}

		private static void DrawGradient(Graphics g, Rectangle rect, Color firstColor, Color secondColor)
		{
			Rectangle r=new Rectangle(rect.X, rect.Y, rect.Width, rect.Height/2);
			if(rect.Width==0) return;

			g.FillRectangle(new LinearGradientBrush(r, firstColor, secondColor, 90.1f), r);
			r.Y=rect.Y+rect.Height-r.Height;
			g.FillRectangle(new LinearGradientBrush(r, secondColor, firstColor, 90.1f), r);
		}

		/// <summary>
		/// Zeichnet den Progress
		/// </summary>
		/// <param name="node"></param>
		/// <param name="context"></param>
		/// <param name="bounds">Gibt die Zeichenfläche an</param>
		public void DrawProgress(TreeNodeAdv node, DrawContext context, Rectangle bounds)
		{
			int leftStartPosForDrawing=bounds.X+LeftMargin;
			int width=bounds.Width-(LeftMargin*2); //Padding links und rechts

			//basebar
			Rectangle basebar=new Rectangle(leftStartPosForDrawing, bounds.Y+1, width, bounds.Height);
			DrawGradient(context.Graphics, basebar, NonActiveFirstColor, NonActiveSecondColor);

			//Progressbar
			if(Value!=0) basebar.Width=(int)(basebar.Width*(float)Value/(Maximum-Minimum));
			else basebar.Width=0;

			DrawGradient(context.Graphics, basebar, ActiveFirstColor, ActiveSecondColor);
		}

		public override Size MeasureSize(TreeNodeAdv node, DrawContext context, int rightBoundLastControl)
		{
			int left=rightBoundLastControl+LeftMargin; //Linke Position des Controls
			int widthTree=node.Tree.DisplayRectangle.Width;
			int widthControl=widthTree-left;

			Size size=GetLabelSize(node, context);
			//context.
			if(MaximizeControl) return new Size(widthControl, size.Height);
			else return size;
		}

		public override void Draw(TreeNodeAdv node, DrawContext context)
		{
			if(context.CurrentEditorOwner==this&&node==Parent.CurrentNode) return;

			string label="";

			//Hole Infos
			object o=GetValue(node);

			if(o is ProgressData)
			{
				ProgressData data=(ProgressData)o;
				Value=data.Position;
				label=data.Text;
			}

			PerformanceAnalyzer.Start("NodeTextBoxWithProgress.Draw");

			Rectangle bounds=GetBounds(node, context);
			Rectangle focusRect=new Rectangle(bounds.X, context.Bounds.Y, bounds.Width, context.Bounds.Height);

			Brush backgroundBrush;
			Color textColor;
			Font font;

			CreateBrushes(node, context, label, out backgroundBrush, out textColor, out font, ref label);

			if(backgroundBrush!=null) context.Graphics.FillRectangle(backgroundBrush, focusRect);

			if(context.DrawFocus)
			{
				focusRect.Width--;
				focusRect.Height--;
				if(context.DrawSelection==DrawSelectionMode.None)
				{
					_focusPen.Color=SystemColors.ControlText;
				}
				else
				{
					_focusPen.Color=SystemColors.InactiveCaption;
					context.Graphics.DrawRectangle(_focusPen, focusRect);
				}
			}

			PerformanceAnalyzer.Start("NodeTextBoxWithProgress.DrawText");
			if(UseCompatibleTextRendering)
			{
				TextRenderer.DrawText(context.Graphics, label, font, bounds, textColor, _formatFlags);
			}
			else
			{
				context.Graphics.DrawString(label, font, GetFrush(textColor), bounds, _format);
			}

			Rectangle r=bounds;
			r.Y+=bounds.Height;
			r.Height=4;

			DrawProgress(node, context, r);

			PerformanceAnalyzer.Finish("NodeTextBoxWithProgress.DrawText");
			PerformanceAnalyzer.Finish("NodeTextBoxWithProgress.Draw");
		}
	}
}
