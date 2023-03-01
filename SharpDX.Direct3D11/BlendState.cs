using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000003 RID: 3
	[Guid("75b68faa-347d-4159-8f45-a0640f01cd9a")]
	public class BlendState : DeviceChild
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000205F File Offset: 0x0000025F
		public BlendState(Device device, BlendStateDescription description) : base(IntPtr.Zero)
		{
			device.CreateBlendState(ref description, this);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002075 File Offset: 0x00000275
		public BlendState(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000207E File Offset: 0x0000027E
		public new static explicit operator BlendState(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BlendState(nativePtr);
			}
			return null;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002098 File Offset: 0x00000298
		public BlendStateDescription Description
		{
			get
			{
				BlendStateDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
		internal unsafe void GetDescription(out BlendStateDescription descRef)
		{
			BlendStateDescription.__Native _Native = default(BlendStateDescription.__Native);
			descRef = default(BlendStateDescription);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			descRef.__MarshalFrom(ref _Native);
		}
	}
}
