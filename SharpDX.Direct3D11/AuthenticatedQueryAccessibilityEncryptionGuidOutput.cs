using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000E3 RID: 227
	public struct AuthenticatedQueryAccessibilityEncryptionGuidOutput
	{
		// Token: 0x06000454 RID: 1108 RVA: 0x00010C4B File Offset: 0x0000EE4B
		internal void __MarshalFree(ref AuthenticatedQueryAccessibilityEncryptionGuidOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00010C5E File Offset: 0x0000EE5E
		internal void __MarshalFrom(ref AuthenticatedQueryAccessibilityEncryptionGuidOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.EncryptionGuidIndex = @ref.EncryptionGuidIndex;
			this.EncryptionGuid = @ref.EncryptionGuid;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00010C89 File Offset: 0x0000EE89
		internal void __MarshalTo(ref AuthenticatedQueryAccessibilityEncryptionGuidOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.EncryptionGuidIndex = this.EncryptionGuidIndex;
			@ref.EncryptionGuid = this.EncryptionGuid;
		}

		// Token: 0x040008ED RID: 2285
		public AuthenticatedQueryOutput Output;

		// Token: 0x040008EE RID: 2286
		public int EncryptionGuidIndex;

		// Token: 0x040008EF RID: 2287
		public Guid EncryptionGuid;

		// Token: 0x020000E4 RID: 228
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008F0 RID: 2288
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x040008F1 RID: 2289
			public int EncryptionGuidIndex;

			// Token: 0x040008F2 RID: 2290
			public Guid EncryptionGuid;
		}
	}
}
