
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Fxfxfx
{
	delegate int IntMapDelegate(int[] buf, int pos, int val);
	
	public class GraphPanelPopupMenu: ContextMenuStrip
	{
		public Point MouseBufPt = Point.Empty;
		GraphPanel panel;
		List<ToolStripMenuItem> scaleItems;
		public GraphPanelPopupMenu(GraphPanel gp): base()
		{
			panel = gp;
			Items.Add(new ToolStripMenuItem("Zero", null, ZeroGp));
			Items.Add(new ToolStripMenuItem("Zero To Here", null, ZeroToHereGp));
			Items.Add(new ToolStripMenuItem("Zero From Here", null, ZeroFromHereGp));
			Items.Add(new ToolStripMenuItem("Randomize", null, RandomizeGp));
			Items.Add(new ToolStripMenuItem("Smooth", null, SmoothGp));
			Items.Add(new ToolStripMenuItem("Fill Gaps", null, FillGapsGp));
			Items.Add(new ToolStripMenuItem("Ramp Up To Here", null, RampUpGp));
			//Items.Add(new ToolStripMenuItem("Ramp Up To Here (from last zero)", null, RampUpFlzGp));
			Items.Add(new ToolStripSeparator());
			Items.Add(new ToolStripMenuItem("Copy", null, CopyGp));
			Items.Add(new ToolStripMenuItem("Paste", null, PasteGp));
			Items.Add(new ToolStripMenuItem("Copy From Marker (ALT) To Here", null, CopyFromMarkerGp));
			Items.Add(new ToolStripMenuItem("Paste Starting Here", null, PasteHereGp));
			Items.Add(new ToolStripSeparator());
			scaleItems = new List<ToolStripMenuItem>();
			foreach(object obj in Enum.GetValues(typeof(GraphViewScale))) {
				string name = Enum.GetName(typeof(GraphViewScale), obj);
				ToolStripMenuItem tsmi = new ToolStripMenuItem("Scale: " + name, null, MakeViewScaleSetter((GraphViewScale)obj));
				tsmi.Checked = (panel.ViewScale == (GraphViewScale)obj);
				Items.Add(tsmi);
				scaleItems.Add(tsmi);
			}
		}
		
		internal EventHandler MakeViewScaleSetter(GraphViewScale vs) {
			return delegate(object sender, EventArgs ea) { panel.ViewScale = vs; scaleItems.ForEach((a)=>{a.Checked = ((a == sender) ? true : false);});};
		}
		
		void MapGp(IntMapDelegate d) {
			int[] buf = panel.Buffer;
			for(int i = 0; i < buf.Length; i++) {
				buf[i] = d(buf, i, buf[i]);
			}
			panel.ForceUpdate();
		}
		
		void RandomizeGp(object sender, EventArgs ea) { Random r = new Random(); MapGp((b,v,p)=>r.Next(0,panel.Quantize + 1)); }
		void ZeroGp(object sender, EventArgs ea) { MapGp((b,p,v)=>0); }
		void ZeroToHereGp(object sender, EventArgs ea) { MapGp((b,p,v)=>(p<MouseBufPt.X?0:v)); }
		void ZeroFromHereGp(object sender, EventArgs ea) { MapGp((b,p,v)=>(p>MouseBufPt.X?0:v)); }
		void SmoothGp(object sender, EventArgs ea) { MapGp((b,p,v)=>((int)Math.Round((p>0?(v+b[p-1])*.5:v)))); }
		void FillGapsGp(object sender, EventArgs ea) { MapGp((b,p,v)=>(v==0&&p>0?b[p-1]:v)); }
		void RampUpGp(object sender, EventArgs ea) { MapGp((b,p,v)=>(p <= MouseBufPt.X ? ((int)Math.Round(p / (float)MouseBufPt.X*MouseBufPt.Y)) : v)); }
		void CopyGp(object sender, EventArgs ea) {
			Clipboard.SetText(panel.ExportText());
		}
		void PasteGp(object sender, EventArgs ea) {
			panel.ImportText(Clipboard.GetText());
			panel.ForceUpdate();
		}
		void CopyFromMarkerGp(object sender, EventArgs ea) {
			Clipboard.SetText(panel.ExportText(panel.Marker, MouseBufPt.X));
		}
		void PasteHereGp(object sender, EventArgs ea) {
			panel.ImportText(Clipboard.GetText(), MouseBufPt.X);
			panel.ForceUpdate();
		}
	}
}
