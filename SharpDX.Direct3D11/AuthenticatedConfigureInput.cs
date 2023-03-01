using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000D6 RID: 214
	public struct AuthenticatedConfigureInput
	{
		// Token: 0x0600043F RID: 1087 RVA: 0x00010975 File Offset: 0x0000EB75
		internal void __MarshalFree(ref AuthenticatedConfigureInput.__Native @ref)
		{
			this.Omac.__MarshalFree(ref @ref.Omac);
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00010988 File Offset: 0x0000EB88
		internal void __MarshalFrom(ref AuthenticatedConfigureInput.__Native @ref)
		{
			this.Omac.__MarshalFrom(ref @ref.Omac);
			this.ConfigureType = @ref.ConfigureType;
			this.HChannel = @ref.HChannel;
			this.SequenceNumber = @ref.SequenceNumber;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x000109BF File Offset: 0x0000EBBF
		internal void __MarshalTo(ref AuthenticatedConfigureInput.__Native @ref)
		{
			this.Omac.__MarshalTo(ref @ref.Omac);
			@ref.ConfigureType = this.ConfigureType;
			@ref.HChannel = this.HChannel;
			@ref.SequenceNumber = this.SequenceNumber;
		}

		// Token: 0x040008C4 RID: 2244
		public MessageAuthenticationCode Omac;

		// Token: 0x040008C5 RID: 2245
		public Guid ConfigureType;

		// Token: 0x040008C6 RID: 2246
		public IntPtr HChannel;

		// Token: 0x040008C7 RID: 2247
		public int SequenceNumber;

		// Token: 0x020000D7 RID: 215
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008C8 RID: 2248
			public MessageAuthenticationCode.__Native Omac;

			// Token: 0x040008C9 RID: 2249
			public Guid ConfigureType;

			// Token: 0x040008CA RID: 2250
			public IntPtr HChannel;

			// Token: 0x040008CB RID: 2251
			public int SequenceNumber;
		}
	}
}
