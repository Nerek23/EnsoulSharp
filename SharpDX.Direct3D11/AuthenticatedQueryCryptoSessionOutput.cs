using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000EA RID: 234
	public struct AuthenticatedQueryCryptoSessionOutput
	{
		// Token: 0x0600045D RID: 1117 RVA: 0x00010D86 File Offset: 0x0000EF86
		internal void __MarshalFree(ref AuthenticatedQueryCryptoSessionOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00010D99 File Offset: 0x0000EF99
		internal void __MarshalFrom(ref AuthenticatedQueryCryptoSessionOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.DecoderHandle = @ref.DecoderHandle;
			this.CryptoSessionHandle = @ref.CryptoSessionHandle;
			this.DeviceHandle = @ref.DeviceHandle;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00010DD0 File Offset: 0x0000EFD0
		internal void __MarshalTo(ref AuthenticatedQueryCryptoSessionOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.DecoderHandle = this.DecoderHandle;
			@ref.CryptoSessionHandle = this.CryptoSessionHandle;
			@ref.DeviceHandle = this.DeviceHandle;
		}

		// Token: 0x04000901 RID: 2305
		public AuthenticatedQueryOutput Output;

		// Token: 0x04000902 RID: 2306
		public IntPtr DecoderHandle;

		// Token: 0x04000903 RID: 2307
		public IntPtr CryptoSessionHandle;

		// Token: 0x04000904 RID: 2308
		public IntPtr DeviceHandle;

		// Token: 0x020000EB RID: 235
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000905 RID: 2309
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x04000906 RID: 2310
			public IntPtr DecoderHandle;

			// Token: 0x04000907 RID: 2311
			public IntPtr CryptoSessionHandle;

			// Token: 0x04000908 RID: 2312
			public IntPtr DeviceHandle;
		}
	}
}
