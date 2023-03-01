using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000122 RID: 290
	[Guid("CE25F8FD-863B-4D13-9651-C1F88DC73FE2")]
	public class AsyncResult : ComObject
	{
		// Token: 0x060004F1 RID: 1265 RVA: 0x00002A7F File Offset: 0x00000C7F
		public AsyncResult(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000100A7 File Offset: 0x0000E2A7
		public new static explicit operator AsyncResult(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new AsyncResult(nativePtr);
			}
			return null;
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x000100BE File Offset: 0x0000E2BE
		public IntPtr WaitHandle
		{
			get
			{
				return this.GetWaitHandle();
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x000100C6 File Offset: 0x0000E2C6
		public Result Result
		{
			get
			{
				return this.GetResult();
			}
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x000100CE File Offset: 0x0000E2CE
		internal unsafe IntPtr GetWaitHandle()
		{
			return calli(System.IntPtr(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x000100ED File Offset: 0x0000E2ED
		internal unsafe Result GetResult()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}
	}
}
