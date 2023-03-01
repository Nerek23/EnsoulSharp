using System;
using System.Collections.Generic;
using System.IO;

namespace SharpDX.Multimedia
{
	// Token: 0x0200006E RID: 110
	public class SoundStream : Stream
	{
		// Token: 0x060002B0 RID: 688 RVA: 0x000080CC File Offset: 0x000062CC
		public SoundStream(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			this.input = stream;
			this.Initialize(stream);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x000080F0 File Offset: 0x000062F0
		private void Initialize(Stream stream)
		{
			RiffParser riffParser = new RiffParser(stream);
			this.FileFormatName = "Unknown";
			if (!riffParser.MoveNext() || riffParser.Current == null)
			{
				this.ThrowInvalidFileFormat(null);
				return;
			}
			this.FileFormatName = riffParser.Current.Type;
			if (this.FileFormatName != "WAVE" && this.FileFormatName != "XWMA")
			{
				throw new InvalidOperationException("Unsupported " + this.FileFormatName + " file format. Only WAVE or XWMA");
			}
			riffParser.Descend();
			IList<RiffChunk> allChunks = riffParser.GetAllChunks();
			RiffChunk riffChunk = this.Chunk(allChunks, "fmt ");
			if ((ulong)riffChunk.Size < (ulong)((long)sizeof(WaveFormat.__PcmNative)))
			{
				this.ThrowInvalidFileFormat(null);
			}
			try
			{
				this.Format = WaveFormat.MarshalFrom(riffChunk.GetData());
			}
			catch (InvalidOperationException nestedException)
			{
				this.ThrowInvalidFileFormat(nestedException);
			}
			if (this.FileFormatName == "XWMA")
			{
				if (this.Format.Encoding != WaveFormatEncoding.Wmaudio2 && this.Format.Encoding != WaveFormatEncoding.Wmaudio3)
				{
					this.ThrowInvalidFileFormat(null);
				}
				RiffChunk riffChunk2 = this.Chunk(allChunks, "dpds");
				this.DecodedPacketsInfo = riffChunk2.GetDataAsArray<uint>();
			}
			else
			{
				WaveFormatEncoding encoding = this.Format.Encoding;
				if (encoding != WaveFormatEncoding.Extensible && encoding - WaveFormatEncoding.Pcm > 2)
				{
					this.ThrowInvalidFileFormat(null);
				}
			}
			RiffChunk riffChunk3 = this.Chunk(allChunks, "data");
			this.startPositionOfData = (long)((ulong)riffChunk3.DataPosition);
			this.length = (long)((ulong)riffChunk3.Size);
			this.input.Position = this.startPositionOfData;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00008290 File Offset: 0x00006490
		protected void ThrowInvalidFileFormat(Exception nestedException = null)
		{
			throw new InvalidOperationException("Invalid " + this.FileFormatName + " file format", nestedException);
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x000082AD File Offset: 0x000064AD
		// (set) Token: 0x060002B4 RID: 692 RVA: 0x000082B5 File Offset: 0x000064B5
		public uint[] DecodedPacketsInfo { get; private set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x000082BE File Offset: 0x000064BE
		// (set) Token: 0x060002B6 RID: 694 RVA: 0x000082C6 File Offset: 0x000064C6
		public WaveFormat Format { get; protected set; }

		// Token: 0x060002B7 RID: 695 RVA: 0x000082D0 File Offset: 0x000064D0
		public DataStream ToDataStream()
		{
			byte[] array = new byte[this.Length];
			if ((long)this.Read(array, 0, (int)this.Length) != this.Length)
			{
				throw new InvalidOperationException("Unable to get a valid DataStream");
			}
			return DataStream.Create<byte>(array, true, true, 0, true);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00008317 File Offset: 0x00006517
		public static implicit operator DataStream(SoundStream stream)
		{
			return stream.ToDataStream();
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x00003808 File Offset: 0x00001A08
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00003808 File Offset: 0x00001A08
		public override bool CanSeek
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060002BB RID: 699 RVA: 0x0000831F File Offset: 0x0000651F
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00008322 File Offset: 0x00006522
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00003830 File Offset: 0x00001A30
		public override long Position
		{
			get
			{
				return this.input.Position - this.startPositionOfData;
			}
			set
			{
				this.Seek(value, SeekOrigin.Begin);
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00008336 File Offset: 0x00006536
		protected override void Dispose(bool disposing)
		{
			if (this.input != null)
			{
				this.input.Dispose();
				this.input = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000835C File Offset: 0x0000655C
		protected RiffChunk Chunk(IEnumerable<RiffChunk> chunks, string id)
		{
			RiffChunk riffChunk = null;
			foreach (RiffChunk riffChunk2 in chunks)
			{
				if (riffChunk2.Type == id)
				{
					riffChunk = riffChunk2;
					break;
				}
			}
			if (riffChunk == null || riffChunk.Type != id)
			{
				throw new InvalidOperationException("Invalid " + this.FileFormatName + " file format");
			}
			return riffChunk;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x000083E8 File Offset: 0x000065E8
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x000083F0 File Offset: 0x000065F0
		private string FileFormatName { get; set; }

		// Token: 0x060002C2 RID: 706 RVA: 0x0000602D File Offset: 0x0000422D
		public override void Flush()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000083FC File Offset: 0x000065FC
		public override long Seek(long offset, SeekOrigin origin)
		{
			long num = this.input.Position;
			switch (origin)
			{
			case SeekOrigin.Begin:
				num = this.startPositionOfData + offset;
				break;
			case SeekOrigin.Current:
				num = this.input.Position + offset;
				break;
			case SeekOrigin.End:
				num = this.startPositionOfData + this.length + offset;
				break;
			}
			if (num < this.startPositionOfData || num > this.startPositionOfData + this.length)
			{
				throw new InvalidOperationException("Cannot seek outside the range of this stream");
			}
			return this.input.Seek(num, SeekOrigin.Begin);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000602D File Offset: 0x0000422D
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00008485 File Offset: 0x00006685
		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.input.Read(buffer, offset, Math.Min(count, (int)Math.Max(this.startPositionOfData + this.length - this.input.Position, 0L)));
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x000084BB File Offset: 0x000066BB
		public override long Length
		{
			get
			{
				return this.length;
			}
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000602D File Offset: 0x0000422D
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		// Token: 0x04000D87 RID: 3463
		private Stream input;

		// Token: 0x04000D88 RID: 3464
		private long startPositionOfData;

		// Token: 0x04000D89 RID: 3465
		private long length;
	}
}
