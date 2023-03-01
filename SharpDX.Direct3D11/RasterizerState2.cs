using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000039 RID: 57
	[Guid("6fbd02fb-209f-46c4-b059-2ed15586a6ac")]
	public class RasterizerState2 : RasterizerState1
	{
		// Token: 0x0600029E RID: 670 RVA: 0x0000AF46 File Offset: 0x00009146
		public RasterizerState2(Device3 device, RasterizerStateDescription2 description) : base(IntPtr.Zero)
		{
			device.CreateRasterizerState2(ref description, this);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000AF5C File Offset: 0x0000915C
		public RasterizerState2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000AF65 File Offset: 0x00009165
		public new static explicit operator RasterizerState2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RasterizerState2(nativePtr);
			}
			return null;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x0000AF7C File Offset: 0x0000917C
		public RasterizerStateDescription2 Description2
		{
			get
			{
				RasterizerStateDescription2 result;
				this.GetDescription2(out result);
				return result;
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000AF94 File Offset: 0x00009194
		internal unsafe void GetDescription2(out RasterizerStateDescription2 descRef)
		{
			descRef = default(RasterizerStateDescription2);
			fixed (RasterizerStateDescription2* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
