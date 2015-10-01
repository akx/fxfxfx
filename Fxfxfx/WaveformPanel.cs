
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Fxfxfx
{
	/// <summary>
	/// Description of WaveformPanel.
	/// </summary>
	public class WaveformPanel: Panel
	{
		float[] waveForm;
		
		public float[] Waveform {
			get { return waveForm; }
			set { waveForm = value; Invalidate(); }
		}
		
		
		public WaveformPanel()
		{
			DoubleBuffered = true;
			Resize += delegate { Invalidate(); };
		}
		
		
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.Clear(Color.Black);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			int h = ClientSize.Height;
			int w = ClientSize.Width;
			float lx = 0, ly = h / 2;
			if(waveForm != null) {
				for(int i = 0; i < waveForm.Length; i++) {
					float x = i / (float)waveForm.Length * w;
					float y = (h + waveForm[i] * h) / 2;
					g.DrawLine(Pens.Lime, lx, ly, x, y);
					lx = x;
					ly = y;
				}
			}
		}
		
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			
		}
		
	}
}
