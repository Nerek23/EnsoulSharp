using System;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX
{
	// Token: 0x02000016 RID: 22
	public class DataStream : Stream
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00003247 File Offset: 0x00001447
		public unsafe DataStream(Blob buffer)
		{
			this._buffer = (byte*)((void*)buffer.GetBufferPointer());
			this._size = buffer.GetBufferSize();
			this._canRead = true;
			this._canWrite = true;
			this._blob = buffer;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003288 File Offset: 0x00001488
		public unsafe static DataStream Create<T>(T[] userBuffer, bool canRead, bool canWrite, int index = 0, bool pinBuffer = true) where T : struct
		{
			if (userBuffer == null)
			{
				throw new ArgumentNullException("userBuffer");
			}
			if (index < 0 || index > userBuffer.Length)
			{
				throw new ArgumentException("Index is out of range [0, userBuffer.Length-1]", "index");
			}
			int num = Utilities.SizeOf<T>(userBuffer);
			int num2 = index * Utilities.SizeOf<T>();
			DataStream result;
			if (pinBuffer)
			{
				GCHandle handle = GCHandle.Alloc(userBuffer, GCHandleType.Pinned);
				result = new DataStream((void*)(num2 + (byte*)((void*)handle.AddrOfPinnedObject())), num - num2, canRead, canWrite, handle);
			}
			else
			{
				int num3 = num2;
				fixed (T* value = &userBuffer[0])
				{
					result = new DataStream((void*)((byte*)num3 + (void*)((IntPtr)((void*)value))), num - num2, canRead, canWrite, true);
				}
			}
			return result;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000331C File Offset: 0x0000151C
		public unsafe DataStream(int sizeInBytes, bool canRead, bool canWrite)
		{
			this._buffer = (byte*)((void*)Utilities.AllocateMemory(sizeInBytes, 16));
			this._size = (long)sizeInBytes;
			this._ownsBuffer = true;
			this._canRead = canRead;
			this._canWrite = canWrite;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003354 File Offset: 0x00001554
		public DataStream(DataPointer dataPointer) : this(dataPointer.Pointer, (long)dataPointer.Size, true, true)
		{
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000336B File Offset: 0x0000156B
		public unsafe DataStream(IntPtr userBuffer, long sizeInBytes, bool canRead, bool canWrite)
		{
			this._buffer = (byte*)userBuffer.ToPointer();
			this._size = sizeInBytes;
			this._canRead = canRead;
			this._canWrite = canWrite;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003396 File Offset: 0x00001596
		internal unsafe DataStream(void* dataPointer, int sizeInBytes, bool canRead, bool canWrite, GCHandle handle)
		{
			this._gCHandle = handle;
			this._buffer = (byte*)dataPointer;
			this._size = (long)sizeInBytes;
			this._canRead = canRead;
			this._canWrite = canWrite;
			this._ownsBuffer = false;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000033CC File Offset: 0x000015CC
		internal unsafe DataStream(void* buffer, int sizeInBytes, bool canRead, bool canWrite, bool makeCopy)
		{
			if (makeCopy)
			{
				this._buffer = (byte*)((void*)Utilities.AllocateMemory(sizeInBytes, 16));
				Utilities.CopyMemory((IntPtr)((void*)this._buffer), (IntPtr)buffer, sizeInBytes);
			}
			else
			{
				this._buffer = (byte*)buffer;
			}
			this._size = (long)sizeInBytes;
			this._canRead = canRead;
			this._canWrite = canWrite;
			this._ownsBuffer = makeCopy;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003438 File Offset: 0x00001638
		~DataStream()
		{
			this.Dispose(false);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003468 File Offset: 0x00001668
		protected unsafe override void Dispose(bool disposing)
		{
			if (disposing && this._blob != null)
			{
				this._blob.Dispose();
				this._blob = null;
			}
			if (this._gCHandle.IsAllocated)
			{
				this._gCHandle.Free();
			}
			if (this._ownsBuffer && this._buffer != null)
			{
				Utilities.FreeMemory((IntPtr)((void*)this._buffer));
				this._buffer = null;
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000034D4 File Offset: 0x000016D4
		public override void Flush()
		{
			throw new NotSupportedException("DataStream objects cannot be flushed.");
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000034E0 File Offset: 0x000016E0
		public unsafe T Read<T>() where T : struct
		{
			if (!this._canRead)
			{
				throw new NotSupportedException();
			}
			byte* value = this._buffer + this._position;
			T result = default(T);
			this._position = (long)((byte*)((void*)Utilities.ReadAndPosition<T>((IntPtr)((void*)value), ref result)) - (byte*)this._buffer);
			return result;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003538 File Offset: 0x00001738
		public unsafe override int ReadByte()
		{
			if (this._position >= this.Length)
			{
				return -1;
			}
			IntPtr buffer = this._buffer;
			long position = this._position;
			this._position = position + 1L;
			return (int)(*(buffer + (IntPtr)position));
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003570 File Offset: 0x00001770
		public override int Read(byte[] buffer, int offset, int count)
		{
			int count2 = (int)Math.Min(this.RemainingLength, (long)count);
			return this.ReadRange<byte>(buffer, offset, count2);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003595 File Offset: 0x00001795
		public unsafe void Read(IntPtr buffer, int offset, int count)
		{
			Utilities.CopyMemory(new IntPtr((void*)((byte*)((void*)buffer) + offset)), (IntPtr)((void*)(this._buffer + this._position)), count);
			this._position += (long)count;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000035CC File Offset: 0x000017CC
		public unsafe T[] ReadRange<T>(int count) where T : struct
		{
			if (!this._canRead)
			{
				throw new NotSupportedException();
			}
			byte* value = this._buffer + this._position;
			T[] array = new T[count];
			this._position = (long)((byte*)((void*)Utilities.Read<T>((IntPtr)((void*)value), array, 0, count)) - (byte*)this._buffer);
			return array;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003624 File Offset: 0x00001824
		public unsafe int ReadRange<T>(T[] buffer, int offset, int count) where T : struct
		{
			if (!this._canRead)
			{
				throw new NotSupportedException();
			}
			long position = this._position;
			this._position = (long)((byte*)((void*)Utilities.Read<T>((IntPtr)((void*)(this._buffer + this._position)), buffer, offset, count)) - (byte*)this._buffer);
			return (int)(this._position - position);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003680 File Offset: 0x00001880
		public override long Seek(long offset, SeekOrigin origin)
		{
			long num = 0L;
			switch (origin)
			{
			case SeekOrigin.Begin:
				num = offset;
				break;
			case SeekOrigin.Current:
				num = this._position + offset;
				break;
			case SeekOrigin.End:
				num = this._size - offset;
				break;
			}
			if (num < 0L)
			{
				throw new InvalidOperationException("Cannot seek beyond the beginning of the stream.");
			}
			if (num > this._size)
			{
				throw new InvalidOperationException("Cannot seek beyond the end of the stream.");
			}
			this._position = num;
			return this._position;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000036ED File Offset: 0x000018ED
		public override void SetLength(long value)
		{
			throw new NotSupportedException("DataStream objects cannot be resized.");
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000036F9 File Offset: 0x000018F9
		public unsafe void Write<T>(T value) where T : struct
		{
			if (!this._canWrite)
			{
				throw new NotSupportedException();
			}
			this._position = (long)((byte*)((void*)Utilities.WriteAndPosition<T>((IntPtr)((void*)(this._buffer + this._position)), ref value)) - (byte*)this._buffer);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003738 File Offset: 0x00001938
		public override void Write(byte[] buffer, int offset, int count)
		{
			this.WriteRange<byte>(buffer, offset, count);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003743 File Offset: 0x00001943
		public unsafe void Write(IntPtr buffer, int offset, int count)
		{
			Utilities.CopyMemory((IntPtr)((void*)(this._buffer + this._position)), new IntPtr((void*)((byte*)((void*)buffer) + offset)), count);
			this._position += (long)count;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000377A File Offset: 0x0000197A
		public void WriteRange<T>(T[] data) where T : struct
		{
			this.WriteRange<T>(data, 0, data.Length);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003787 File Offset: 0x00001987
		public unsafe void WriteRange(IntPtr source, long count)
		{
			if (!this._canWrite)
			{
				throw new NotSupportedException();
			}
			Utilities.CopyMemory((IntPtr)((void*)(this._buffer + this._position)), source, (int)count);
			this._position += count;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000037C0 File Offset: 0x000019C0
		public unsafe void WriteRange<T>(T[] data, int offset, int count) where T : struct
		{
			if (!this._canWrite)
			{
				throw new NotSupportedException();
			}
			this._position = (long)((byte*)((void*)Utilities.Write<T>((IntPtr)((void*)(this._buffer + this._position)), data, offset, count)) - (byte*)this._buffer);
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00003800 File Offset: 0x00001A00
		public override bool CanRead
		{
			get
			{
				return this._canRead;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00003808 File Offset: 0x00001A08
		public override bool CanSeek
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000AD RID: 173 RVA: 0x0000380B File Offset: 0x00001A0B
		public override bool CanWrite
		{
			get
			{
				return this._canWrite;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003813 File Offset: 0x00001A13
		public unsafe IntPtr DataPointer
		{
			get
			{
				return new IntPtr((void*)this._buffer);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00003820 File Offset: 0x00001A20
		public override long Length
		{
			get
			{
				return this._size;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00003828 File Offset: 0x00001A28
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x00003830 File Offset: 0x00001A30
		public override long Position
		{
			get
			{
				return this._position;
			}
			set
			{
				this.Seek(value, SeekOrigin.Begin);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x0000383B File Offset: 0x00001A3B
		public unsafe IntPtr PositionPointer
		{
			get
			{
				return (IntPtr)((void*)(this._buffer + this._position));
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00003850 File Offset: 0x00001A50
		public long RemainingLength
		{
			get
			{
				return this._size - this._position;
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000385F File Offset: 0x00001A5F
		public static implicit operator DataPointer(DataStream from)
		{
			return new DataPointer(from.PositionPointer, (int)from.RemainingLength);
		}

		// Token: 0x04000020 RID: 32
		private unsafe byte* _buffer;

		// Token: 0x04000021 RID: 33
		private readonly bool _canRead;

		// Token: 0x04000022 RID: 34
		private readonly bool _canWrite;

		// Token: 0x04000023 RID: 35
		private GCHandle _gCHandle;

		// Token: 0x04000024 RID: 36
		private Blob _blob;

		// Token: 0x04000025 RID: 37
		private readonly bool _ownsBuffer;

		// Token: 0x04000026 RID: 38
		private long _position;

		// Token: 0x04000027 RID: 39
		private readonly long _size;
	}
}
