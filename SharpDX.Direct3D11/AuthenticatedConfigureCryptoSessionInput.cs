using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000D2 RID: 210
	public struct AuthenticatedConfigureCryptoSessionInput
	{
		// Token: 0x06000439 RID: 1081 RVA: 0x0001088B File Offset: 0x0000EA8B
		internal void __MarshalFree(ref AuthenticatedConfigureCryptoSessionInput.__Native @ref)
		{
			this.Parameters.__MarshalFree(ref @ref.Parameters);
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x0001089E File Offset: 0x0000EA9E
		internal void __MarshalFrom(ref AuthenticatedConfigureCryptoSessionInput.__Native @ref)
		{
			this.Parameters.__MarshalFrom(ref @ref.Parameters);
			this.DecoderHandle = @ref.DecoderHandle;
			this.CryptoSessionHandle = @ref.CryptoSessionHandle;
			this.DeviceHandle = @ref.DeviceHandle;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000108D5 File Offset: 0x0000EAD5
		internal void __MarshalTo(ref AuthenticatedConfigureCryptoSessionInput.__Native @ref)
		{
			this.Parameters.__MarshalTo(ref @ref.Parameters);
			@ref.DecoderHandle = this.DecoderHandle;
			@ref.CryptoSessionHandle = this.CryptoSessionHandle;
			@ref.DeviceHandle = this.DeviceHandle;
		}

		// Token: 0x040008B6 RID: 2230
		public AuthenticatedConfigureInput Parameters;

		// Token: 0x040008B7 RID: 2231
		public IntPtr DecoderHandle;

		// Token: 0x040008B8 RID: 2232
		public IntPtr CryptoSessionHandle;

		// Token: 0x040008B9 RID: 2233
		public IntPtr DeviceHandle;

		// Token: 0x020000D3 RID: 211
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008BA RID: 2234
			public AuthenticatedConfigureInput.__Native Parameters;

			// Token: 0x040008BB RID: 2235
			public IntPtr DecoderHandle;

			// Token: 0x040008BC RID: 2236
			public IntPtr CryptoSessionHandle;

			// Token: 0x040008BD RID: 2237
			public IntPtr DeviceHandle;
		}
	}
}
