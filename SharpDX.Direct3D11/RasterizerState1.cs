using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000038 RID: 56
	[Guid("1217d7a6-5039-418c-b042-9cbe256afd6e")]
	public class RasterizerState1 : RasterizerState
	{
		// Token: 0x06000299 RID: 665 RVA: 0x0000AEBE File Offset: 0x000090BE
		public RasterizerState1(Device1 device, RasterizerStateDescription1 description) : base(IntPtr.Zero)
		{
			device.CreateRasterizerState1(ref description, this);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000AED4 File Offset: 0x000090D4
		public RasterizerState1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000AEDD File Offset: 0x000090DD
		public new static explicit operator RasterizerState1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RasterizerState1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600029C RID: 668 RVA: 0x0000AEF4 File Offset: 0x000090F4
		public RasterizerStateDescription1 Description1
		{
			get
			{
				RasterizerStateDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000AF0C File Offset: 0x0000910C
		internal unsafe void GetDescription1(out RasterizerStateDescription1 descRef)
		{
			descRef = default(RasterizerStateDescription1);
			fixed (RasterizerStateDescription1* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
