using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000B8 RID: 184
	[Guid("5c1e0d8a-7c23-48f9-8c59-a92958ceff11")]
	public class DeviceContextState : DeviceChild
	{
		// Token: 0x06000388 RID: 904 RVA: 0x00002075 File Offset: 0x00000275
		public DeviceContextState(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000DDDF File Offset: 0x0000BFDF
		public new static explicit operator DeviceContextState(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContextState(nativePtr);
			}
			return null;
		}
	}
}
