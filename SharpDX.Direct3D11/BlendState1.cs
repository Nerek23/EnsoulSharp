using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000004 RID: 4
	[Guid("cc86fabe-da55-401d-85e7-e3c9de2877e9")]
	public class BlendState1 : BlendState
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000020F4 File Offset: 0x000002F4
		public BlendState1(Device1 device, BlendStateDescription1 description) : base(IntPtr.Zero)
		{
			device.CreateBlendState1(ref description, this);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000210A File Offset: 0x0000030A
		public BlendState1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002113 File Offset: 0x00000313
		public new static explicit operator BlendState1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BlendState1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000212C File Offset: 0x0000032C
		public BlendStateDescription1 Description1
		{
			get
			{
				BlendStateDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002144 File Offset: 0x00000344
		internal unsafe void GetDescription1(out BlendStateDescription1 descRef)
		{
			BlendStateDescription1.__Native _Native = default(BlendStateDescription1.__Native);
			descRef = default(BlendStateDescription1);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			descRef.__MarshalFrom(ref _Native);
		}
	}
}
