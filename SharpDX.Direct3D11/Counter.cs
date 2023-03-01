using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200000E RID: 14
	[Guid("6e8c49fb-a371-4770-b440-29086022b741")]
	public class Counter : Asynchronous
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00002D02 File Offset: 0x00000F02
		public Counter(Device device, CounterDescription description) : base(IntPtr.Zero)
		{
			device.CreateCounter(description, this);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002D17 File Offset: 0x00000F17
		public Counter(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002D20 File Offset: 0x00000F20
		public new static explicit operator Counter(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Counter(nativePtr);
			}
			return null;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002D38 File Offset: 0x00000F38
		public CounterDescription Description
		{
			get
			{
				CounterDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002D50 File Offset: 0x00000F50
		internal unsafe void GetDescription(out CounterDescription descRef)
		{
			descRef = default(CounterDescription);
			fixed (CounterDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
