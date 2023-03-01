using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000C8 RID: 200
	[Guid("B64BB1B5-FD70-4df6-BF91-19D0A12455E3")]
	public class VertexBuffer : Resource
	{
		// Token: 0x06000683 RID: 1667 RVA: 0x00003BF6 File Offset: 0x00001DF6
		public VertexBuffer(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x00017782 File Offset: 0x00015982
		public new static explicit operator VertexBuffer(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new VertexBuffer(nativePointer);
			}
			return null;
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x0001779C File Offset: 0x0001599C
		public VertexBufferDescription Description
		{
			get
			{
				VertexBufferDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x000177B4 File Offset: 0x000159B4
		internal unsafe void Lock_(int offsetToLock, int sizeToLock, out IntPtr bDataOut, LockFlags lockFlags)
		{
			Result result;
			fixed (IntPtr* ptr = &bDataOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32), this._nativePointer, offsetToLock, sizeToLock, ptr2, lockFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x000177FC File Offset: 0x000159FC
		public unsafe void Unlock()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00017834 File Offset: 0x00015A34
		internal unsafe void GetDescription(out VertexBufferDescription descRef)
		{
			descRef = default(VertexBufferDescription);
			Result result;
			fixed (VertexBufferDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0001787C File Offset: 0x00015A7C
		public VertexBuffer(Device device, int sizeInBytes, Usage usage, VertexFormat format, Pool pool) : base(IntPtr.Zero)
		{
			device.CreateVertexBuffer(sizeInBytes, usage, format, pool, this, IntPtr.Zero);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0001789C File Offset: 0x00015A9C
		public unsafe VertexBuffer(Device device, int sizeInBytes, Usage usage, VertexFormat format, Pool pool, ref IntPtr sharedHandle) : base(IntPtr.Zero)
		{
			sharedHandle = IntPtr.Zero;
			fixed (IntPtr* ptr = &sharedHandle)
			{
				void* value = (void*)ptr;
				device.CreateVertexBuffer(sizeInBytes, usage, format, pool, this, new IntPtr(value));
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x000178D8 File Offset: 0x00015AD8
		public DataStream Lock(int offsetToLock, int sizeToLock, LockFlags lockFlags)
		{
			IntPtr userBuffer;
			this.Lock_(offsetToLock, sizeToLock, out userBuffer, lockFlags);
			if (sizeToLock == 0)
			{
				sizeToLock = this.Description.SizeInBytes;
			}
			return new DataStream(userBuffer, (long)sizeToLock, true, (lockFlags & LockFlags.ReadOnly) == LockFlags.None);
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00017910 File Offset: 0x00015B10
		public IntPtr LockToPointer(int offsetToLock, int sizeToLock, LockFlags lockFlags)
		{
			if (sizeToLock == 0)
			{
				sizeToLock = this.Description.SizeInBytes;
			}
			IntPtr result;
			this.Lock_(offsetToLock, sizeToLock, out result, lockFlags);
			return result;
		}
	}
}
