using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000E0 RID: 224
	public struct AuthenticatedQueryAccessibilityEncryptionGuidCountOutput
	{
		// Token: 0x06000451 RID: 1105 RVA: 0x00010BFA File Offset: 0x0000EDFA
		internal void __MarshalFree(ref AuthenticatedQueryAccessibilityEncryptionGuidCountOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00010C0D File Offset: 0x0000EE0D
		internal void __MarshalFrom(ref AuthenticatedQueryAccessibilityEncryptionGuidCountOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.EncryptionGuidCount = @ref.EncryptionGuidCount;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00010C2C File Offset: 0x0000EE2C
		internal void __MarshalTo(ref AuthenticatedQueryAccessibilityEncryptionGuidCountOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.EncryptionGuidCount = this.EncryptionGuidCount;
		}

		// Token: 0x040008E7 RID: 2279
		public AuthenticatedQueryOutput Output;

		// Token: 0x040008E8 RID: 2280
		public int EncryptionGuidCount;

		// Token: 0x020000E1 RID: 225
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008E9 RID: 2281
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x040008EA RID: 2282
			public int EncryptionGuidCount;
		}
	}
}
