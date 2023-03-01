using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000F4 RID: 244
	public struct AuthenticatedQueryOutputIdCountOutput
	{
		// Token: 0x06000469 RID: 1129 RVA: 0x00010F5A File Offset: 0x0000F15A
		internal void __MarshalFree(ref AuthenticatedQueryOutputIdCountOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00010F6D File Offset: 0x0000F16D
		internal void __MarshalFrom(ref AuthenticatedQueryOutputIdCountOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.DeviceHandle = @ref.DeviceHandle;
			this.CryptoSessionHandle = @ref.CryptoSessionHandle;
			this.OutputIDCount = @ref.OutputIDCount;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00010FA4 File Offset: 0x0000F1A4
		internal void __MarshalTo(ref AuthenticatedQueryOutputIdCountOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.DeviceHandle = this.DeviceHandle;
			@ref.CryptoSessionHandle = this.CryptoSessionHandle;
			@ref.OutputIDCount = this.OutputIDCount;
		}

		// Token: 0x04000921 RID: 2337
		public AuthenticatedQueryOutput Output;

		// Token: 0x04000922 RID: 2338
		public IntPtr DeviceHandle;

		// Token: 0x04000923 RID: 2339
		public IntPtr CryptoSessionHandle;

		// Token: 0x04000924 RID: 2340
		public int OutputIDCount;

		// Token: 0x020000F5 RID: 245
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000925 RID: 2341
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x04000926 RID: 2342
			public IntPtr DeviceHandle;

			// Token: 0x04000927 RID: 2343
			public IntPtr CryptoSessionHandle;

			// Token: 0x04000928 RID: 2344
			public int OutputIDCount;
		}
	}
}
