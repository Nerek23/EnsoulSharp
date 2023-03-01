using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000D0 RID: 208
	public struct AuthenticatedConfigureAccessibleEncryptionInput
	{
		// Token: 0x06000436 RID: 1078 RVA: 0x0001083A File Offset: 0x0000EA3A
		internal void __MarshalFree(ref AuthenticatedConfigureAccessibleEncryptionInput.__Native @ref)
		{
			this.Parameters.__MarshalFree(ref @ref.Parameters);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0001084D File Offset: 0x0000EA4D
		internal void __MarshalFrom(ref AuthenticatedConfigureAccessibleEncryptionInput.__Native @ref)
		{
			this.Parameters.__MarshalFrom(ref @ref.Parameters);
			this.EncryptionGuid = @ref.EncryptionGuid;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0001086C File Offset: 0x0000EA6C
		internal void __MarshalTo(ref AuthenticatedConfigureAccessibleEncryptionInput.__Native @ref)
		{
			this.Parameters.__MarshalTo(ref @ref.Parameters);
			@ref.EncryptionGuid = this.EncryptionGuid;
		}

		// Token: 0x040008B2 RID: 2226
		public AuthenticatedConfigureInput Parameters;

		// Token: 0x040008B3 RID: 2227
		public Guid EncryptionGuid;

		// Token: 0x020000D1 RID: 209
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008B4 RID: 2228
			public AuthenticatedConfigureInput.__Native Parameters;

			// Token: 0x040008B5 RID: 2229
			public Guid EncryptionGuid;
		}
	}
}
