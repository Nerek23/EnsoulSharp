using System;

namespace SharpDX
{
	// Token: 0x02000014 RID: 20
	public struct DataPointer : IEquatable<DataPointer>
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00002F29 File Offset: 0x00001129
		public DataPointer(IntPtr pointer, int size)
		{
			this.Pointer = pointer;
			this.Size = size;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002F39 File Offset: 0x00001139
		public unsafe DataPointer(void* pointer, int size)
		{
			this.Pointer = (IntPtr)pointer;
			this.Size = size;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00002F4E File Offset: 0x0000114E
		public bool IsEmpty
		{
			get
			{
				return this.Equals(DataPointer.Zero);
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002F5B File Offset: 0x0000115B
		public bool Equals(DataPointer other)
		{
			return this.Pointer.Equals(other.Pointer) && this.Size == other.Size;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002F85 File Offset: 0x00001185
		public override bool Equals(object obj)
		{
			return obj != null && obj is DataPointer && this.Equals((DataPointer)obj);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00002FA2 File Offset: 0x000011A2
		public override int GetHashCode()
		{
			return this.Pointer.GetHashCode() * 397 ^ this.Size;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00002FBC File Offset: 0x000011BC
		public DataStream ToDataStream()
		{
			if (this.Pointer == IntPtr.Zero)
			{
				throw new InvalidOperationException("DataPointer is Zero");
			}
			return new DataStream(this);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002FE6 File Offset: 0x000011E6
		public DataBuffer ToDataBuffer()
		{
			if (this.Pointer == IntPtr.Zero)
			{
				throw new InvalidOperationException("DataPointer is Zero");
			}
			return new DataBuffer(this);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003010 File Offset: 0x00001210
		public byte[] ToArray()
		{
			if (this.Pointer == IntPtr.Zero)
			{
				throw new InvalidOperationException("DataPointer is Zero");
			}
			if (this.Size < 0)
			{
				throw new InvalidOperationException("Size cannot be < 0");
			}
			byte[] array = new byte[this.Size];
			Utilities.Read<byte>(this.Pointer, array, 0, this.Size);
			return array;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003070 File Offset: 0x00001270
		public T[] ToArray<T>() where T : struct
		{
			if (this.Pointer == IntPtr.Zero)
			{
				throw new InvalidOperationException("DataPointer is Zero");
			}
			T[] array = new T[this.Size / Utilities.SizeOf<T>()];
			this.CopyTo<T>(array, 0, array.Length);
			return array;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000030B8 File Offset: 0x000012B8
		public void CopyTo<T>(T[] buffer, int offset, int count) where T : struct
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (this.Pointer == IntPtr.Zero)
			{
				throw new InvalidOperationException("DataPointer is Zero");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Must be >= 0");
			}
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count", "Must be > 0");
			}
			if (count * Utilities.SizeOf<T>() > this.Size)
			{
				throw new ArgumentOutOfRangeException("buffer", "Total buffer size cannot be larger than size of this data pointer");
			}
			Utilities.Read<T>(this.Pointer, buffer, offset, count);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003146 File Offset: 0x00001346
		public void CopyFrom<T>(T[] buffer) where T : struct
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (this.Pointer == IntPtr.Zero)
			{
				throw new InvalidOperationException("DataPointer is Zero");
			}
			this.CopyFrom<T>(buffer, 0, buffer.Length);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003180 File Offset: 0x00001380
		public void CopyFrom<T>(T[] buffer, int offset, int count) where T : struct
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (this.Pointer == IntPtr.Zero)
			{
				throw new InvalidOperationException("DataPointer is Zero");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Must be >= 0");
			}
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count", "Must be > 0");
			}
			if (count * Utilities.SizeOf<T>() > this.Size)
			{
				throw new ArgumentOutOfRangeException("buffer", "Total buffer size cannot be larger than size of this data pointer");
			}
			Utilities.Write<T>(this.Pointer, buffer, offset, count);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000320E File Offset: 0x0000140E
		public static bool operator ==(DataPointer left, DataPointer right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003218 File Offset: 0x00001418
		public static bool operator !=(DataPointer left, DataPointer right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0400001B RID: 27
		public static readonly DataPointer Zero = new DataPointer(IntPtr.Zero, 0);

		// Token: 0x0400001C RID: 28
		public IntPtr Pointer;

		// Token: 0x0400001D RID: 29
		public int Size;
	}
}
