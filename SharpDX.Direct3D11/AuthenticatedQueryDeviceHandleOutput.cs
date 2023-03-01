using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000EE RID: 238
	public struct AuthenticatedQueryDeviceHandleOutput
	{
		// Token: 0x06000463 RID: 1123 RVA: 0x00010E58 File Offset: 0x0000F058
		internal void __MarshalFree(ref AuthenticatedQueryDeviceHandleOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00010E6B File Offset: 0x0000F06B
		internal void __MarshalFrom(ref AuthenticatedQueryDeviceHandleOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.DeviceHandle = @ref.DeviceHandle;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00010E8A File Offset: 0x0000F08A
		internal void __MarshalTo(ref AuthenticatedQueryDeviceHandleOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.DeviceHandle = this.DeviceHandle;
		}

		// Token: 0x0400090D RID: 2317
		public AuthenticatedQueryOutput Output;

		// Token: 0x0400090E RID: 2318
		public IntPtr DeviceHandle;

		// Token: 0x020000EF RID: 239
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x0400090F RID: 2319
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x04000910 RID: 2320
			public IntPtr DeviceHandle;
		}
	}
}
