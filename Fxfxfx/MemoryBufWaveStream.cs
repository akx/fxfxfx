using System;
using NAudio.Wave;

namespace Fxfxfx
{
	public class MemoryBufWaveStream: WaveStream {
		WaveFormat wf;
		long pos;
		byte[] buffer;
		
		public MemoryBufWaveStream(WaveFormat wf, byte[] buffer)
		{
			this.wf = wf;
			this.buffer = buffer;
			this.pos = 0;
		}
		
		
		public override WaveFormat WaveFormat {
			get {
				return wf;
			}
		}
		
		public override bool CanRead {
			get {
				return true;
			}
		}
		
		public override bool CanSeek {
			get { return true; }
		}
		
		public override bool CanWrite {
			get { return false; }
		}
		
		public override long Length {
			get { return buffer.Length; }
		}
		
		public override long Position {
			get {
				return pos;
			}
			set {
				pos = Math.Min(buffer.Length, Math.Max(0, value));
			}
		}
		
		public override int Read(byte[] buffer, int offset, int count)
		{
			if(pos + count >= this.buffer.Length) count = (int)(this.buffer.Length - pos);
			Array.Copy(this.buffer, pos, buffer, offset, count);
			pos += count;
			if(pos >= this.buffer.Length) pos = this.buffer.Length;
			return count;
		}
		
		
	}
}
