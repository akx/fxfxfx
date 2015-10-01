
namespace Fxfxfx
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.playButton = new System.Windows.Forms.ToolStripButton();
			this.exportDropDown = new System.Windows.Forms.ToolStripDropDownButton();
			this.toWAVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.lengthBox = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.graphsLbl = new System.Windows.Forms.ToolStripLabel();
			this.bufSizeBox = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.srComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.setLengthsButton = new System.Windows.Forms.ToolStripButton();
			this.outerTablePanel = new System.Windows.Forms.TableLayoutPanel();
			this.paramsTablePanel = new System.Windows.Forms.TableLayoutPanel();
			this.noisePeriodGraph = new Fxfxfx.GraphPanel();
			this.noiseVolumeGraph = new Fxfxfx.GraphPanel();
			this.waveGraph = new Fxfxfx.GraphPanel();
			this.waveVolumeGraph = new Fxfxfx.GraphPanel();
			this.wavePeriodGraph = new Fxfxfx.GraphPanel();
			this.waveDivisorGraph = new Fxfxfx.GraphPanel();
			this.waveformPanel1 = new Fxfxfx.WaveformPanel();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.toolStrip1.SuspendLayout();
			this.outerTablePanel.SuspendLayout();
			this.paramsTablePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.playButton,
									this.exportDropDown,
									this.toolStripSeparator1,
									this.toolStripLabel1,
									this.lengthBox,
									this.toolStripLabel2,
									this.graphsLbl,
									this.bufSizeBox,
									this.toolStripLabel3,
									this.srComboBox,
									this.setLengthsButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(870, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// playButton
			// 
			this.playButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.playButton.Image = ((System.Drawing.Image)(resources.GetObject("playButton.Image")));
			this.playButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(31, 22);
			this.playButton.Text = "Play";
			this.playButton.Click += new System.EventHandler(this.PlayButtonClick);
			// 
			// exportDropDown
			// 
			this.exportDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.exportDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toWAVToolStripMenuItem,
									this.toClipboardToolStripMenuItem,
									this.fromClipboardToolStripMenuItem});
			this.exportDropDown.Image = ((System.Drawing.Image)(resources.GetObject("exportDropDown.Image")));
			this.exportDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.exportDropDown.Name = "exportDropDown";
			this.exportDropDown.Size = new System.Drawing.Size(100, 22);
			this.exportDropDown.Text = "Import/Export...";
			// 
			// toWAVToolStripMenuItem
			// 
			this.toWAVToolStripMenuItem.Name = "toWAVToolStripMenuItem";
			this.toWAVToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.toWAVToolStripMenuItem.Text = "To WAV";
			this.toWAVToolStripMenuItem.Click += new System.EventHandler(this.ExportWAVBtnClick);
			// 
			// toClipboardToolStripMenuItem
			// 
			this.toClipboardToolStripMenuItem.Name = "toClipboardToolStripMenuItem";
			this.toClipboardToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.toClipboardToolStripMenuItem.Text = "To Clipboard";
			this.toClipboardToolStripMenuItem.Click += new System.EventHandler(this.ToClipboardToolStripMenuItemClick);
			// 
			// fromClipboardToolStripMenuItem
			// 
			this.fromClipboardToolStripMenuItem.Name = "fromClipboardToolStripMenuItem";
			this.fromClipboardToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.fromClipboardToolStripMenuItem.Text = "From Clipboard";
			this.fromClipboardToolStripMenuItem.Click += new System.EventHandler(this.FromClipboardToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(80, 22);
			this.toolStripLabel1.Text = "Sound Length";
			// 
			// lengthBox
			// 
			this.lengthBox.MaxLength = 5;
			this.lengthBox.Name = "lengthBox";
			this.lengthBox.Size = new System.Drawing.Size(40, 25);
			this.lengthBox.Text = "1";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(32, 22);
			this.toolStripLabel2.Text = "sec   ";
			// 
			// graphsLbl
			// 
			this.graphsLbl.Name = "graphsLbl";
			this.graphsLbl.Size = new System.Drawing.Size(78, 22);
			this.graphsLbl.Text = "Graph Length";
			// 
			// bufSizeBox
			// 
			this.bufSizeBox.Name = "bufSizeBox";
			this.bufSizeBox.Size = new System.Drawing.Size(40, 25);
			// 
			// toolStripLabel3
			// 
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(20, 22);
			this.toolStripLabel3.Text = "SR";
			// 
			// srComboBox
			// 
			this.srComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.srComboBox.Items.AddRange(new object[] {
									"8000",
									"11025",
									"22050",
									"44100"});
			this.srComboBox.Name = "srComboBox";
			this.srComboBox.Size = new System.Drawing.Size(75, 25);
			// 
			// setLengthsButton
			// 
			this.setLengthsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.setLengthsButton.Image = ((System.Drawing.Image)(resources.GetObject("setLengthsButton.Image")));
			this.setLengthsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.setLengthsButton.Name = "setLengthsButton";
			this.setLengthsButton.Size = new System.Drawing.Size(30, 22);
			this.setLengthsButton.Text = "Set!";
			this.setLengthsButton.Click += new System.EventHandler(this.SetLengthsButtonClick);
			// 
			// outerTablePanel
			// 
			this.outerTablePanel.ColumnCount = 1;
			this.outerTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.outerTablePanel.Controls.Add(this.paramsTablePanel, 0, 0);
			this.outerTablePanel.Controls.Add(this.waveformPanel1, 0, 1);
			this.outerTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outerTablePanel.Location = new System.Drawing.Point(0, 25);
			this.outerTablePanel.Margin = new System.Windows.Forms.Padding(0);
			this.outerTablePanel.Name = "outerTablePanel";
			this.outerTablePanel.RowCount = 2;
			this.outerTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.outerTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.outerTablePanel.Size = new System.Drawing.Size(870, 530);
			this.outerTablePanel.TabIndex = 1;
			// 
			// paramsTablePanel
			// 
			this.paramsTablePanel.ColumnCount = 1;
			this.paramsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.paramsTablePanel.Controls.Add(this.noisePeriodGraph, 0, 0);
			this.paramsTablePanel.Controls.Add(this.noiseVolumeGraph, 0, 1);
			this.paramsTablePanel.Controls.Add(this.waveGraph, 0, 2);
			this.paramsTablePanel.Controls.Add(this.waveVolumeGraph, 0, 3);
			this.paramsTablePanel.Controls.Add(this.wavePeriodGraph, 0, 4);
			this.paramsTablePanel.Controls.Add(this.waveDivisorGraph, 0, 5);
			this.paramsTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.paramsTablePanel.Location = new System.Drawing.Point(3, 3);
			this.paramsTablePanel.Name = "paramsTablePanel";
			this.paramsTablePanel.RowCount = 6;
			this.paramsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.paramsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.paramsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.paramsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.paramsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.paramsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.paramsTablePanel.Size = new System.Drawing.Size(864, 365);
			this.paramsTablePanel.TabIndex = 0;
			// 
			// noisePeriodGraph
			// 
			this.noisePeriodGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.noisePeriodGraph.Buffer = null;
			this.noisePeriodGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.noisePeriodGraph.LabelText = null;
			this.noisePeriodGraph.Location = new System.Drawing.Point(0, 0);
			this.noisePeriodGraph.Margin = new System.Windows.Forms.Padding(0);
			this.noisePeriodGraph.Marker = -1;
			this.noisePeriodGraph.Name = "noisePeriodGraph";
			this.noisePeriodGraph.Quantize = 16;
			this.noisePeriodGraph.Size = new System.Drawing.Size(864, 69);
			this.noisePeriodGraph.TabIndex = 0;
			// 
			// noiseVolumeGraph
			// 
			this.noiseVolumeGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.noiseVolumeGraph.Buffer = null;
			this.noiseVolumeGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.noiseVolumeGraph.LabelText = null;
			this.noiseVolumeGraph.Location = new System.Drawing.Point(0, 69);
			this.noiseVolumeGraph.Margin = new System.Windows.Forms.Padding(0);
			this.noiseVolumeGraph.Marker = -1;
			this.noiseVolumeGraph.Name = "noiseVolumeGraph";
			this.noiseVolumeGraph.Quantize = 16;
			this.noiseVolumeGraph.Size = new System.Drawing.Size(864, 69);
			this.noiseVolumeGraph.TabIndex = 1;
			// 
			// waveGraph
			// 
			this.waveGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.waveGraph.Buffer = null;
			this.waveGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.waveGraph.LabelText = null;
			this.waveGraph.Location = new System.Drawing.Point(0, 138);
			this.waveGraph.Margin = new System.Windows.Forms.Padding(0);
			this.waveGraph.Marker = -1;
			this.waveGraph.Name = "waveGraph";
			this.waveGraph.Quantize = 16;
			this.waveGraph.Size = new System.Drawing.Size(864, 69);
			this.waveGraph.TabIndex = 2;
			// 
			// waveVolumeGraph
			// 
			this.waveVolumeGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.waveVolumeGraph.Buffer = null;
			this.waveVolumeGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.waveVolumeGraph.LabelText = null;
			this.waveVolumeGraph.Location = new System.Drawing.Point(0, 207);
			this.waveVolumeGraph.Margin = new System.Windows.Forms.Padding(0);
			this.waveVolumeGraph.Marker = -1;
			this.waveVolumeGraph.Name = "waveVolumeGraph";
			this.waveVolumeGraph.Quantize = 16;
			this.waveVolumeGraph.Size = new System.Drawing.Size(864, 69);
			this.waveVolumeGraph.TabIndex = 3;
			// 
			// wavePeriodGraph
			// 
			this.wavePeriodGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.wavePeriodGraph.Buffer = null;
			this.wavePeriodGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wavePeriodGraph.LabelText = null;
			this.wavePeriodGraph.Location = new System.Drawing.Point(0, 276);
			this.wavePeriodGraph.Margin = new System.Windows.Forms.Padding(0);
			this.wavePeriodGraph.Marker = -1;
			this.wavePeriodGraph.Name = "wavePeriodGraph";
			this.wavePeriodGraph.Quantize = 16;
			this.wavePeriodGraph.Size = new System.Drawing.Size(864, 69);
			this.wavePeriodGraph.TabIndex = 4;
			// 
			// waveDivisorGraph
			// 
			this.waveDivisorGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.waveDivisorGraph.Buffer = null;
			this.waveDivisorGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.waveDivisorGraph.LabelText = null;
			this.waveDivisorGraph.Location = new System.Drawing.Point(0, 345);
			this.waveDivisorGraph.Margin = new System.Windows.Forms.Padding(0);
			this.waveDivisorGraph.Marker = -1;
			this.waveDivisorGraph.Name = "waveDivisorGraph";
			this.waveDivisorGraph.Quantize = 16;
			this.waveDivisorGraph.Size = new System.Drawing.Size(864, 20);
			this.waveDivisorGraph.TabIndex = 5;
			// 
			// waveformPanel1
			// 
			this.waveformPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.waveformPanel1.Location = new System.Drawing.Point(3, 374);
			this.waveformPanel1.Name = "waveformPanel1";
			this.waveformPanel1.Size = new System.Drawing.Size(864, 153);
			this.waveformPanel1.TabIndex = 1;
			this.waveformPanel1.Waveform = null;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "wav";
			this.saveFileDialog1.Filter = "\"WAV files|*.wav|All files|*.*\"";
			this.saveFileDialog1.RestoreDirectory = true;
			this.saveFileDialog1.SupportMultiDottedExtensions = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(870, 555);
			this.Controls.Add(this.outerTablePanel);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "MainForm";
			this.Text = "Fxfxfx";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.outerTablePanel.ResumeLayout(false);
			this.paramsTablePanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripComboBox srComboBox;
		private System.Windows.Forms.ToolStripLabel toolStripLabel3;
		private System.Windows.Forms.ToolStripMenuItem fromClipboardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toClipboardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toWAVToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton exportDropDown;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripTextBox bufSizeBox;
		private System.Windows.Forms.ToolStripButton setLengthsButton;
		private System.Windows.Forms.ToolStripLabel graphsLbl;
		private System.Windows.Forms.ToolStripTextBox lengthBox;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private Fxfxfx.GraphPanel waveDivisorGraph;
		private System.Windows.Forms.ToolStripButton playButton;
		private Fxfxfx.WaveformPanel waveformPanel1;
		private Fxfxfx.GraphPanel wavePeriodGraph;
		private Fxfxfx.GraphPanel waveVolumeGraph;
		private Fxfxfx.GraphPanel waveGraph;
		private Fxfxfx.GraphPanel noiseVolumeGraph;
		private Fxfxfx.GraphPanel noisePeriodGraph;
		private System.Windows.Forms.TableLayoutPanel paramsTablePanel;
		private System.Windows.Forms.TableLayoutPanel outerTablePanel;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
