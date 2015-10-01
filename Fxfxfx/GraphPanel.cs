
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Fxfxfx
{
	
	public delegate void GraphChangedEventHandler(GraphPanel sender);
	
	public enum GraphViewScale {
		Linear,
		Logarithmic
	};
	
	public class GraphPanel: Panel
	{
		private const int LOG_SCALE = 100;

		int[] buffer = null;
		int quantize = 16;
		int mPos = -1;
		int mDownX = -1, mDownV = -1;
		int marker = -1;
		bool doInterp = false;
		bool logInterp = false;
		bool drawing = false;
		string labelText = "";
		GraphViewScale viewScale = GraphViewScale.Linear;
		public event GraphChangedEventHandler GraphChanged;

		public int[] Buffer {
			get { return buffer; }
			set { buffer = value; }
		}
		
		public int Quantize {
			get { return quantize; }
			set { quantize = value; }
		}
		
		public int Marker {
			get { return marker; }
			set { marker = value; Invalidate(); }
		}
		
		public GraphViewScale ViewScale {
			get { return viewScale; }
			set { viewScale = value; Invalidate(); }
		}
		
		public string LabelText {
			get { return labelText; }
			set { labelText = value; Invalidate(); }
		}
		
		public void ResizeBuffer(int newLength) {
			int[] newBuffer = new int[newLength];
			if(buffer != null) {
				for(int i = 0; i < Math.Min(buffer.Length, newLength); i++) newBuffer[i] = buffer[i];
			}
			buffer = newBuffer;
			Invalidate();
			
		}
		
		public GraphPanel(): base()
		{
			DoubleBuffered = true;
			Padding = new Padding(0);
			Margin = new Padding(0);
			MouseDown += new MouseEventHandler(MouseDownEvt);
			MouseUp += new MouseEventHandler(MouseUpEvt);
			MouseMove += new MouseEventHandler(MouseMoveEvt);
			Resize += new EventHandler(Resized);
			BorderStyle = BorderStyle.Fixed3D;
			ContextMenuStrip = new GraphPanelPopupMenu(this);
		}

		void Resized(object sender, EventArgs e)
		{
			Invalidate();
		}
		
		int CXtoBufPos(int x) {
			int p = (int)Math.Round(x / (float)(ClientSize.Width) * buffer.Length);
			if(p<0) return -1;
			if(p>=buffer.Length) return -1;
			return p;
		}
		
		int BufPosToCX(int p) {
			return (int)((p / (float)buffer.Length) * ClientSize.Width);
		}
		
		int CYtoBufVal(int y) {
			float fv = 1.0f - (y / (float)(ClientSize.Height));
			if (viewScale == GraphViewScale.Logarithmic) fv = (float)(Math.Pow(10, fv * Math.Log10(LOG_SCALE)) / LOG_SCALE);
			int v = (int)Math.Round(fv * quantize);
			if(v<0) v=0;
			if(v>quantize) v=quantize;
			return v;
		}
		
		int BufValToCY(int v) {
			float fv = (v / (float)quantize);
			if (viewScale == GraphViewScale.Logarithmic) fv = (fv > 0 ? (float)(Math.Log10(fv * LOG_SCALE) / Math.Log10(LOG_SCALE)) : 0); 
			return (int)((1.0f - fv) * ClientSize.Height);
		}

		void MouseMoveEvt(object sender, MouseEventArgs e)
		{
			if(drawing) {
				if(buffer != null) {
					int pos = CXtoBufPos(e.X);
					int val = CYtoBufVal(e.Y);
					if(pos >= 0 && pos < buffer.Length) {
						if(doInterp) {
							int x0, x1, v0, v1;
							if(mDownX < pos) {
								x0 = mDownX; v0 = mDownV;
								x1 = pos; v1 = val;
							} else {
								x1 = mDownX; v1 = mDownV;
								x0 = pos; v0 = val;
							}
							if(x1 != x0) {
								for(int x = x0 ; x <= x1; x++) {
									float p = (x - x0) / (float)(x1 - x0);
									if(logInterp) p = (float)Math.Sqrt(p);//p * p;
									float v = v1 * p + v0 * (1.0f - p);
									//System.Diagnostics.Debug.Print("p={0} v={1}..{2} -> {3}", p, v0, v1, v);
									buffer[x] = (int)Math.Round(v);
								}
							}	
						} else {
							buffer[pos] = val;
							mPos = pos;
						}
					}
					
				}
				Invalidate();
			}
		}

		void MouseUpEvt(object sender, MouseEventArgs e)
		{
			Capture = false;
			drawing = false;
			mPos = -1;
			Invalidate();
			if(GraphChanged != null) GraphChanged(this);
		}

		void MouseDownEvt(object sender, MouseEventArgs e)
		{
			mDownX = CXtoBufPos(e.X);
			mDownV = CYtoBufVal(e.Y);
			(ContextMenuStrip as GraphPanelPopupMenu).MouseBufPt = new Point(mDownX, mDownV);
			if((Control.ModifierKeys & Keys.Alt) == Keys.Alt) {
				marker = mDownX;
				Invalidate();
				return;
			}
			if(e.Button == MouseButtons.Left) {
				Capture = true;
				drawing = true;
				doInterp = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
				logInterp = (Control.ModifierKeys & Keys.Control) == Keys.Control;
				MouseMoveEvt(sender, e);
			}
		}
		
		public void ForceUpdate() {
			Invalidate();
			if(GraphChanged != null) GraphChanged(this);
		}
		
		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}
		
		
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;			
			int w = ClientSize.Width;
			int h = ClientSize.Height;
			using(Brush b = new LinearGradientBrush(Point.Empty, new Point(0, h), Color.Silver, Color.White)) {
				g.FillRectangle(b, 0, 0, w, h);
			}
			//g.Clear(Color.White);
			
			if(buffer != null) {

				int sw = (int)Math.Ceiling(w / (float) buffer.Length);
				for(int i = 0; i < buffer.Length; i++) {
					
					int x = BufPosToCX(i);//i * sw;
					int y = BufValToCY(buffer[i]);
					
					if(i == marker) g.FillRectangle(Brushes.Lime, x, 0, sw, h);
					g.FillRectangle(Brushes.Orange, x, y, sw, h - y);
					if(sw >= 5) g.DrawLine(Pens.White, x, 0, x, h);
				}
			}
			
			g.DrawString(LabelText, Font, Brushes.Black, 3, 3);
		}
		
		public void ImportText(string text, int bufOffset) {
			string[] parts = text.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
			int[] buf = buffer;
			for(int i = 0; i < parts.Length; i++) {
				string part = parts[i];
				int r = 0;
				bool ok = int.TryParse(part, out r);
				if(!ok) r = (int)(part[0]);
				r %= quantize;
				if(i + bufOffset < buf.Length) buf[i + bufOffset] = r;
			}
			Invalidate();

		}
		
		public void ImportText(string text) {
			ImportText(text, 0);
		}
		
		public string ExportText(int start, int end) {
			StringBuilder sb = new StringBuilder();
			if(end < start) {
				int tmp = end;
				end = start;
				start = tmp;
			}
			for(int i=Math.Max(0, start);i<=Math.Min(buffer.Length - 1, end); i++) {
				sb.Append(buffer[i].ToString(CultureInfo.InvariantCulture));
			    sb.Append(' ');
			};
			return sb.ToString().TrimEnd();
		}
		
		public string ExportText() {
			return ExportText(0, buffer.Length);
		}
	}
}
