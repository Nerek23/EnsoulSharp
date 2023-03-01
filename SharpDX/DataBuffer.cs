using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX
{
	// Token: 0x02000013 RID: 19
	public class DataBuffer : DisposeBase
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00002BFC File Offset: 0x00000DFC
		public unsafe static DataBuffer Create<T>(T[] userBuffer, int index = 0, bool pinBuffer = true) where T : struct
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
			DataBuffer result;
			if (pinBuffer)
			{
				GCHandle handle = GCHandle.Alloc(userBuffer, GCHandleType.Pinned);
				result = new DataBuffer((void*)(num2 + (byte*)((void*)handle.AddrOfPinnedObject())), num - num2, handle);
			}
			else
			{
				int num3 = num2;
				fixed (T* value = &userBuffer[0])
				{
					result = new DataBuffer((void*)((byte*)num3 + (void*)((IntPtr)((void*)value))), num - num2, true);
				}
			}
			return result;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002C8B File Offset: 0x00000E8B
		public unsafe DataBuffer(int sizeInBytes)
		{
			this._buffer = (sbyte*)((void*)Utilities.AllocateMemory(sizeInBytes, 16));
			this._size = sizeInBytes;
			this._ownsBuffer = true;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002CB4 File Offset: 0x00000EB4
		public DataBuffer(DataPointer dataPointer) : this(dataPointer.Pointer, dataPointer.Size)
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002CC8 File Offset: 0x00000EC8
		public unsafe DataBuffer(IntPtr userBuffer, int sizeInBytes) : this((void*)userBuffer, sizeInBytes, false)
		{
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002CD8 File Offset: 0x00000ED8
		internal unsafe DataBuffer(void* buffer, int sizeInBytes, GCHandle handle)
		{
			this._buffer = (sbyte*)buffer;
			this._size = sizeInBytes;
			this._gCHandle = handle;
			this._ownsBuffer = false;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002CFC File Offset: 0x00000EFC
		internal unsafe DataBuffer(void* buffer, int sizeInBytes, bool makeCopy)
		{
			if (makeCopy)
			{
				this._buffer = (sbyte*)((void*)Utilities.AllocateMemory(sizeInBytes, 16));
				Utilities.CopyMemory((IntPtr)((void*)this._buffer), (IntPtr)buffer, sizeInBytes);
			}
			else
			{
				this._buffer = (sbyte*)buffer;
			}
			this._size = sizeInBytes;
			this._ownsBuffer = makeCopy;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002D53 File Offset: 0x00000F53
		internal unsafe DataBuffer(Blob buffer)
		{
			this._buffer = (sbyte*)((void*)buffer.GetBufferPointer());
			this._size = buffer.GetBufferSize();
			this._blob = buffer;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002D84 File Offset: 0x00000F84
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

		// Token: 0x06000074 RID: 116 RVA: 0x00002DF0 File Offset: 0x00000FF0
		public unsafe void Clear(byte value = 0)
		{
			Utilities.ClearMemory((IntPtr)((void*)this._buffer), value, this.Size);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002E0C File Offset: 0x0000100C
		public unsafe T Get<T>(int positionInBytes) where T : struct
		{
			T result = default(T);
			Utilities.Read<T>((IntPtr)((void*)(this._buffer + positionInBytes)), ref result);
			return result;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002E36 File Offset: 0x00001036
		public unsafe void Get<T>(int positionInBytes, out T value) where T : struct
		{
			Utilities.ReadOut<T>((IntPtr)((void*)(this._buffer + positionInBytes)), out value);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002E4C File Offset: 0x0000104C
		public unsafe T[] GetRange<T>(int positionInBytes, int count) where T : struct
		{
			T[] array = new T[count];
			Utilities.Read<T>((IntPtr)((void*)(this._buffer + positionInBytes)), array, 0, count);
			return array;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002E77 File Offset: 0x00001077
		public unsafe void GetRange<T>(int positionInBytes, T[] buffer, int offset, int count) where T : struct
		{
			Utilities.Read<T>((IntPtr)((void*)(this._buffer + positionInBytes)), buffer, offset, count);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002E90 File Offset: 0x00001090
		public unsafe void Set<T>(int positionInBytes, ref T value) where T : struct
		{
			*(T*)(this._buffer + positionInBytes) = value;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002EA0 File Offset: 0x000010A0
		public unsafe void Set<T>(int positionInBytes, T value) where T : struct
		{
			*(T*)(this._buffer + positionInBytes) = value;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002EB1 File Offset: 0x000010B1
		public unsafe void Set(int positionInBytes, bool value)
		{
			*(int*)(this._buffer + positionInBytes) = (value ? 1 : 0);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002EC3 File Offset: 0x000010C3
		public void Set<T>(int positionInBytes, T[] data) where T : struct
		{
			this.Set<T>(positionInBytes, data, 0, data.Length);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002ED1 File Offset: 0x000010D1
		public unsafe void Set(int positionInBytes, IntPtr source, long count)
		{
			Utilities.CopyMemory((IntPtr)((void*)(this._buffer + positionInBytes)), source, (int)count);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002EE8 File Offset: 0x000010E8
		public unsafe void Set<T>(int positionInBytes, T[] data, int offset, int count) where T : struct
		{
			Utilities.Write<T>((IntPtr)((void*)(this._buffer + positionInBytes)), data, offset, count);
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00002F01 File Offset: 0x00001101
		public unsafe IntPtr DataPointer
		{
			get
			{
				return new IntPtr((void*)this._buffer);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002F0E File Offset: 0x0000110E
		public int Size
		{
			get
			{
				return this._size;
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002F16 File Offset: 0x00001116
		public static implicit operator DataPointer(DataBuffer from)
		{
			return new DataPointer(from.DataPointer, from.Size);
		}

		// Token: 0x04000016 RID: 22
		private unsafe sbyte* _buffer;

		// Token: 0x04000017 RID: 23
		private GCHandle _gCHandle;

		// Token: 0x04000018 RID: 24
		private readonly bool _ownsBuffer;

		// Token: 0x04000019 RID: 25
		private readonly int _size;

		// Token: 0x0400001A RID: 26
		private Blob _blob;
	}
}
