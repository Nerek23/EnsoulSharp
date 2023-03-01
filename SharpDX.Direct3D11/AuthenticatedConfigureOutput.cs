using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000D8 RID: 216
	public struct AuthenticatedConfigureOutput
	{
		// Token: 0x06000442 RID: 1090 RVA: 0x000109F6 File Offset: 0x0000EBF6
		internal void __MarshalFree(ref AuthenticatedConfigureOutput.__Native @ref)
		{
			this.Omac.__MarshalFree(ref @ref.Omac);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00010A0C File Offset: 0x0000EC0C
		internal void __MarshalFrom(ref AuthenticatedConfigureOutput.__Native @ref)
		{
			this.Omac.__MarshalFrom(ref @ref.Omac);
			this.ConfigureType = @ref.ConfigureType;
			this.HChannel = @ref.HChannel;
			this.SequenceNumber = @ref.SequenceNumber;
			this.ReturnCode = @ref.ReturnCode;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00010A5C File Offset: 0x0000EC5C
		internal void __MarshalTo(ref AuthenticatedConfigureOutput.__Native @ref)
		{
			this.Omac.__MarshalTo(ref @ref.Omac);
			@ref.ConfigureType = this.ConfigureType;
			@ref.HChannel = this.HChannel;
			@ref.SequenceNumber = this.SequenceNumber;
			@ref.ReturnCode = this.ReturnCode;
		}

		// Token: 0x040008CC RID: 2252
		public MessageAuthenticationCode Omac;

		// Token: 0x040008CD RID: 2253
		public Guid ConfigureType;

		// Token: 0x040008CE RID: 2254
		public IntPtr HChannel;

		// Token: 0x040008CF RID: 2255
		public int SequenceNumber;

		// Token: 0x040008D0 RID: 2256
		public Result ReturnCode;

		// Token: 0x020000D9 RID: 217
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008D1 RID: 2257
			public MessageAuthenticationCode.__Native Omac;

			// Token: 0x040008D2 RID: 2258
			public Guid ConfigureType;

			// Token: 0x040008D3 RID: 2259
			public IntPtr HChannel;

			// Token: 0x040008D4 RID: 2260
			public int SequenceNumber;

			// Token: 0x040008D5 RID: 2261
			public Result ReturnCode;
		}
	}
}
