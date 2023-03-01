using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000F7 RID: 247
	public struct AuthenticatedQueryOutputIdOutput
	{
		// Token: 0x0600046C RID: 1132 RVA: 0x00010FDB File Offset: 0x0000F1DB
		internal void __MarshalFree(ref AuthenticatedQueryOutputIdOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00010FF0 File Offset: 0x0000F1F0
		internal void __MarshalFrom(ref AuthenticatedQueryOutputIdOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.DeviceHandle = @ref.DeviceHandle;
			this.CryptoSessionHandle = @ref.CryptoSessionHandle;
			this.OutputIDIndex = @ref.OutputIDIndex;
			this.OutputID = @ref.OutputID;
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00011040 File Offset: 0x0000F240
		internal void __MarshalTo(ref AuthenticatedQueryOutputIdOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.DeviceHandle = this.DeviceHandle;
			@ref.CryptoSessionHandle = this.CryptoSessionHandle;
			@ref.OutputIDIndex = this.OutputIDIndex;
			@ref.OutputID = this.OutputID;
		}

		// Token: 0x0400092D RID: 2349
		public AuthenticatedQueryOutput Output;

		// Token: 0x0400092E RID: 2350
		public IntPtr DeviceHandle;

		// Token: 0x0400092F RID: 2351
		public IntPtr CryptoSessionHandle;

		// Token: 0x04000930 RID: 2352
		public int OutputIDIndex;

		// Token: 0x04000931 RID: 2353
		public long OutputID;

		// Token: 0x020000F8 RID: 248
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000932 RID: 2354
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x04000933 RID: 2355
			public IntPtr DeviceHandle;

			// Token: 0x04000934 RID: 2356
			public IntPtr CryptoSessionHandle;

			// Token: 0x04000935 RID: 2357
			public int OutputIDIndex;

			// Token: 0x04000936 RID: 2358
			public long OutputID;
		}
	}
}
