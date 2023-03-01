using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200005B RID: 91
	[Guid("77db970f-6276-48ba-ba28-070143b4392c")]
	public class Device1 : Device
	{
		// Token: 0x06000176 RID: 374 RVA: 0x000064A5 File Offset: 0x000046A5
		public Device1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000064AE File Offset: 0x000046AE
		public new static explicit operator Device1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device1(nativePtr);
			}
			return null;
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000178 RID: 376 RVA: 0x000064C8 File Offset: 0x000046C8
		// (set) Token: 0x06000179 RID: 377 RVA: 0x000064DE File Offset: 0x000046DE
		public int MaximumFrameLatency
		{
			get
			{
				int result;
				this.GetMaximumFrameLatency(out result);
				return result;
			}
			set
			{
				this.SetMaximumFrameLatency(value);
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x000064E8 File Offset: 0x000046E8
		internal unsafe void SetMaximumFrameLatency(int maxLatency)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, maxLatency, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00006524 File Offset: 0x00004724
		internal unsafe void GetMaximumFrameLatency(out int maxLatencyRef)
		{
			Result result;
			fixed (int* ptr = &maxLatencyRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
