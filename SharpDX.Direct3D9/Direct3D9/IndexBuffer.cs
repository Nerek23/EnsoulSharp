using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000B3 RID: 179
	[Guid("7C9DD65E-D3F7-4529-ACEE-785830ACDE35")]
	public class IndexBuffer : Resource
	{
		// Token: 0x060004CC RID: 1228 RVA: 0x00003BF6 File Offset: 0x00001DF6
		public IndexBuffer(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00011EDF File Offset: 0x000100DF
		public new static explicit operator IndexBuffer(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new IndexBuffer(nativePointer);
			}
			return null;
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x00011EF8 File Offset: 0x000100F8
		public IndexBufferDescription Description
		{
			get
			{
				IndexBufferDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00011F10 File Offset: 0x00010110
		internal unsafe void Lock(int offsetToLock, int sizeToLock, out IntPtr bDataOut, LockFlags flags)
		{
			Result result;
			fixed (IntPtr* ptr = &bDataOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32), this._nativePointer, offsetToLock, sizeToLock, ptr2, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00011F58 File Offset: 0x00010158
		public unsafe void Unlock()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00011F90 File Offset: 0x00010190
		internal unsafe void GetDescription(out IndexBufferDescription descRef)
		{
			descRef = default(IndexBufferDescription);
			Result result;
			fixed (IndexBufferDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00011FD8 File Offset: 0x000101D8
		public IndexBuffer(Device device, int sizeInBytes, Usage usage, Pool pool, bool sixteenBit) : base(IntPtr.Zero)
		{
			device.CreateIndexBuffer(sizeInBytes, (int)usage, sixteenBit ? Format.Index16 : Format.Index32, pool, this, IntPtr.Zero);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00012000 File Offset: 0x00010200
		public unsafe IndexBuffer(Device device, int sizeInBytes, Usage usage, Pool pool, bool sixteenBit, ref IntPtr sharedHandle) : base(IntPtr.Zero)
		{
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				device.CreateIndexBuffer(sizeInBytes, (int)usage, sixteenBit ? Format.Index16 : Format.Index32, pool, this, (IntPtr)value);
			}
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0001203C File Offset: 0x0001023C
		public DataStream Lock(int offsetToLock, int sizeToLock, LockFlags lockFlags)
		{
			if (sizeToLock == 0)
			{
				sizeToLock = this.Description.Size;
			}
			IntPtr userBuffer;
			this.Lock(offsetToLock, sizeToLock, out userBuffer, lockFlags);
			return new DataStream(userBuffer, (long)sizeToLock, true, (lockFlags & LockFlags.ReadOnly) == LockFlags.None);
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00012074 File Offset: 0x00010274
		public IntPtr LockToPointer(int offsetToLock, int sizeToLock, LockFlags lockFlags)
		{
			if (sizeToLock == 0)
			{
				sizeToLock = this.Description.Size;
			}
			IntPtr result;
			this.Lock(offsetToLock, sizeToLock, out result, lockFlags);
			return result;
		}
	}
}
