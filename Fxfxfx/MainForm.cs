
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

using NAudio.Wave;

namespace Fxfxfx
{
	public partial class MainForm : Form
	{
		IWavePlayer wavePlayer;
		float sampleLengthSecs = 1;
		int samplingRate = 22050;
		
		public MainForm()
		{
			InitializeComponent();
			DoubleBuffered = true;
			noisePeriodGraph.LabelText = "Noise Period";
			noiseVolumeGraph.LabelText = "Noise Volume";
			waveGraph.LabelText = "Waveform";
			wavePeriodGraph.LabelText = "Wave Period";
			waveVolumeGraph.LabelText = "Wave Volume";
			waveDivisorGraph.LabelText = "Wave Divisor";
			ResizeBuffers(256);
			if(File.Exists("use-waveout.txt")) {
				wavePlayer = new WaveOut();
			} else {
				try {
					wavePlayer = new DirectSoundOut();
				} catch {
					if(MessageBox.Show("Instantiating DS failed. Try Waveout instead from now on?", "Oops", MessageBoxButtons.YesNo) == DialogResult.Yes) {
						File.WriteAllText("use-waveout.txt", "yes");
						MessageBox.Show("use-waveout.txt written.");
						wavePlayer = new WaveOut();
					}
				}
			}
			Closed += DidClose;
			var p = 100 / (float)paramsTablePanel.RowCount;
			for(var r = 0; r < paramsTablePanel.RowCount; r++) {
				paramsTablePanel.RowStyles[r].SizeType = SizeType.Percent;
				paramsTablePanel.RowStyles[r].Height = p;
			}
			foreach(Control c in paramsTablePanel.Controls) {
				if(c is GraphPanel) {
					(c as GraphPanel).GraphChanged += DoRecalculate;
				}
			}
			Text = "fxfxfx " + Application.ProductVersion;
			lengthBox.Text = (1.0).ToString();
			srComboBox.SelectedItem = "22050";
			CalculateWaveform();
		}

		void DidClose(object sender, EventArgs e)
		{
			wavePlayer.Stop();
			wavePlayer.Dispose();
		}
		
		void ResizeBuffers(int size) {
			bufSizeBox.Text = size.ToString();
			noisePeriodGraph.Quantize = 256;
			noiseVolumeGraph.Quantize = 32;
			wavePeriodGraph.Quantize = 256;
			waveGraph.Quantize = 2;
			waveVolumeGraph.Quantize = 32;
			waveDivisorGraph.Quantize = 64;
			
			noisePeriodGraph.ResizeBuffer(size);
			noiseVolumeGraph.ResizeBuffer(size);
			waveGraph.ResizeBuffer(size);
			wavePeriodGraph.ResizeBuffer(size);			
			waveVolumeGraph.ResizeBuffer(size);
			waveDivisorGraph.ResizeBuffer(size);
			
		}
		
		void DoRecalculate(GraphPanel gp) {
			CalculateWaveform();
		}
		
		
		
		void CalculateWaveform() {
			int points = waveGraph.Buffer.Length;
			
			int samplesPerPoint = (int)(samplingRate * (1 / (float)points) * sampleLengthSecs);
			float[] sampleBuf = new float[points * samplesPerPoint];
			//Random r = new Random();
			int noiseP = 0;// r.Next(0, ChipNoise.noiseBuf.Length);
			int sampP = 0;
			int waveP = 0;
			int noisePCntr = 0;
			int wavePCntr = 0;
			for(int iPoint = 0; iPoint < points; iPoint++) {
				int noisePeriod = noisePeriodGraph.Buffer[iPoint];
				int noiseVolume = noiseVolumeGraph.Buffer[iPoint];
				int wave = waveGraph.Buffer[iPoint];
				int wavePeriod = wavePeriodGraph.Buffer[iPoint];
				int waveVolume = waveVolumeGraph.Buffer[iPoint];
				int waveFullPeriod = waveDivisorGraph.Buffer[iPoint] + 4;
				int waveHalfPeriod = waveFullPeriod / 2;
				for(int samp = 0; samp < samplesPerPoint; samp++) {
					//waveP += wavePeriod;
					noisePCntr ++;
					wavePCntr ++;
					if(noisePCntr >= noisePeriod) {
						noisePCntr = 0;
						noiseP ++;
					}
					if(wavePCntr >= wavePeriod) {
						wavePCntr = 0;
						waveP ++;
					}
					
					while(noiseP >= ChipNoise.bits.Length) noiseP -= ChipNoise.bits.Length;
					float noiseVal = (ChipNoise.bits[noiseP] ? 1 : -1);
					float waveVal = 0;
					switch(wave) {
						case 0: // saw
							waveVal = ((waveP % waveFullPeriod) - waveHalfPeriod) / ((float)waveFullPeriod);
							break;
						case 1: // sqr
							waveVal = ((waveP % waveFullPeriod) < waveHalfPeriod) ? -.5f : .5f;
							break;
						case 2: // tri-or-something
							int z = (waveP % waveFullPeriod);
							float q = (z % waveHalfPeriod) / (float) waveHalfPeriod;
							if(z < waveHalfPeriod) waveVal = q - 1;
							else waveVal = 1 - q;
							break;
					}
					float val = 
						(waveVal * (waveVolume / (float)waveVolumeGraph.Quantize)) + 
						(noiseVal * (noiseVolume / (float)noiseVolumeGraph.Quantize));
					if(val < -1) val = -1;//+= 2;
					if(val > 1) val = 1;
					sampleBuf[sampP] = val;
					sampP ++;
				}
			}
			//System.Diagnostics.Debug.Print("Buf = {0}", sampleBuf.Length);
			waveformPanel1.Waveform = sampleBuf;
		}
		
		byte[] MakeByteBuf() {
			float[] buf = waveformPanel1.Waveform;
			if(buf == null) return null;
			byte[] bbuf = new byte[buf.Length];
			for(int i=0; i< buf.Length; i++) bbuf[i] = (byte)(127 + buf[i] * 127);
			return bbuf;
		}
		
		
		void PlayCurrentWaveform() {
			wavePlayer.Init(new MemoryBufWaveStream(new WaveFormat(samplingRate, 8, 1), MakeByteBuf()));
			wavePlayer.Play();
		}
		
		void PlayButtonClick(object sender, EventArgs e)
		{
			PlayCurrentWaveform();
		}
		
		
		void SetLengthsButtonClick(object sender, EventArgs e)
		{
			float l = sampleLengthSecs;
			try {
				l = float.Parse(lengthBox.Text);
				if(l <= 0) throw new Exception();
				sampleLengthSecs = l;
			} catch {
				MessageBox.Show("Invalid sample length.");
			}
			
			try {
				int bufSize = int.Parse(bufSizeBox.Text);
				if(bufSize <= 1) throw new Exception();
				ResizeBuffers(bufSize);
			}catch {
				MessageBox.Show("Invalid graph length.");
			}
			
			samplingRate = int.Parse(srComboBox.SelectedItem.ToString());
			
			CalculateWaveform();
		}
		
		void ExportWAVBtnClick(object sender, EventArgs e)
		{
			if(saveFileDialog1.ShowDialog() == DialogResult.OK) {
				byte[] buf = MakeByteBuf();
				WaveFileWriter wfw = new WaveFileWriter(saveFileDialog1.FileName, new WaveFormat(samplingRate, 8, 1));
				wfw.WriteData(buf, 0, buf.Length);
				wfw.Close();
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Space)
			{
				PlayCurrentWaveform();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		void ToClipboardToolStripMenuItemClick(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(String.Format("sampling_rate={0}", samplingRate.ToString(CultureInfo.InvariantCulture)));
			sb.AppendLine(String.Format("length={0}", sampleLengthSecs.ToString(CultureInfo.InvariantCulture)));
			sb.AppendLine(String.Format("buffer_length={0}", waveGraph.Buffer.Length.ToString(CultureInfo.InvariantCulture)));
			sb.AppendLine(String.Format("noise_period={0}", noisePeriodGraph.ExportText()));
			sb.AppendLine(String.Format("noise_volume={0}", noiseVolumeGraph.ExportText()));
			sb.AppendLine(String.Format("waveform={0}", waveGraph.ExportText()));
			sb.AppendLine(String.Format("wave_period={0}", wavePeriodGraph.ExportText()));
			sb.AppendLine(String.Format("wave_volume={0}", waveVolumeGraph.ExportText()));
			sb.AppendLine(String.Format("wave_divisor={0}", waveDivisorGraph.ExportText()));
			Clipboard.SetText(sb.ToString());
		}
		
		void FromClipboardToolStripMenuItemClick(object sender, EventArgs e)
		{
			string[] lines = Clipboard.GetText().Split('\n');
			foreach(string line in lines) {
				string[] parts = line.TrimEnd().Split(new char[]{'='}, 2);
				if(parts.Length != 2) continue;
				switch(parts[0]) {
					case "sampling_rate":	samplingRate = int.Parse(parts[1]);break;
					case "length":			sampleLengthSecs=float.Parse(parts[1], CultureInfo.InvariantCulture); break;
					case "buffer_length":	ResizeBuffers(int.Parse(parts[1])); break;
					case "noise_period":	noisePeriodGraph.ImportText(parts[1]); break;
					case "noise_volume":	noiseVolumeGraph.ImportText(parts[1]); break;
					case "waveform":		waveGraph.ImportText(parts[1]); break;
					case "wave_period":		wavePeriodGraph.ImportText(parts[1]); break;
					case "wave_volume":		waveVolumeGraph.ImportText(parts[1]); break;
					case "wave_divisor":	waveDivisorGraph.ImportText(parts[1]); break;
					default:	MessageBox.Show("Unknown value " + parts[0] + " in import."); break;
				}
			}
			
		}
	}
	

}
