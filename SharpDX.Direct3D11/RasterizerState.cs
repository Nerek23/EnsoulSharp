using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000037 RID: 55
	[Guid("9bb4ab81-ab1a-4d8f-b506-fc04200b6ee7")]
	public class RasterizerState : DeviceChild
	{
		// Token: 0x06000294 RID: 660 RVA: 0x0000AE3F File Offset: 0x0000903F
		public RasterizerState(Device device, RasterizerStateDescription description) : base(IntPtr.Zero)
		{
			device.CreateRasterizerState(ref description, this);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00002075 File Offset: 0x00000275
		public RasterizerState(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000AE55 File Offset: 0x00009055
		public new static explicit operator RasterizerState(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RasterizerState(nativePtr);
			}
			return null;
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000AE6C File Offset: 0x0000906C
		public RasterizerStateDescription Description
		{
			get
			{
				RasterizerStateDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000AE84 File Offset: 0x00009084
		internal unsafe void GetDescription(out RasterizerStateDescription descRef)
		{
			descRef = default(RasterizerStateDescription);
			fixed (RasterizerStateDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
