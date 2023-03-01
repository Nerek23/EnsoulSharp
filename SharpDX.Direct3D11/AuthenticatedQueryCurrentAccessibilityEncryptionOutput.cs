using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000EC RID: 236
	public struct AuthenticatedQueryCurrentAccessibilityEncryptionOutput
	{
		// Token: 0x06000460 RID: 1120 RVA: 0x00010E07 File Offset: 0x0000F007
		internal void __MarshalFree(ref AuthenticatedQueryCurrentAccessibilityEncryptionOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00010E1A File Offset: 0x0000F01A
		internal void __MarshalFrom(ref AuthenticatedQueryCurrentAccessibilityEncryptionOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.EncryptionGuid = @ref.EncryptionGuid;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00010E39 File Offset: 0x0000F039
		internal void __MarshalTo(ref AuthenticatedQueryCurrentAccessibilityEncryptionOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.EncryptionGuid = this.EncryptionGuid;
		}

		// Token: 0x04000909 RID: 2313
		public AuthenticatedQueryOutput Output;

		// Token: 0x0400090A RID: 2314
		public Guid EncryptionGuid;

		// Token: 0x020000ED RID: 237
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x0400090B RID: 2315
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x0400090C RID: 2316
			public Guid EncryptionGuid;
		}
	}
}
