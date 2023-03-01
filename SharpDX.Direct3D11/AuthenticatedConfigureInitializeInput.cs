using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000D4 RID: 212
	public struct AuthenticatedConfigureInitializeInput
	{
		// Token: 0x0600043C RID: 1084 RVA: 0x0001090C File Offset: 0x0000EB0C
		internal void __MarshalFree(ref AuthenticatedConfigureInitializeInput.__Native @ref)
		{
			this.Parameters.__MarshalFree(ref @ref.Parameters);
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0001091F File Offset: 0x0000EB1F
		internal void __MarshalFrom(ref AuthenticatedConfigureInitializeInput.__Native @ref)
		{
			this.Parameters.__MarshalFrom(ref @ref.Parameters);
			this.StartSequenceQuery = @ref.StartSequenceQuery;
			this.StartSequenceConfigure = @ref.StartSequenceConfigure;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0001094A File Offset: 0x0000EB4A
		internal void __MarshalTo(ref AuthenticatedConfigureInitializeInput.__Native @ref)
		{
			this.Parameters.__MarshalTo(ref @ref.Parameters);
			@ref.StartSequenceQuery = this.StartSequenceQuery;
			@ref.StartSequenceConfigure = this.StartSequenceConfigure;
		}

		// Token: 0x040008BE RID: 2238
		public AuthenticatedConfigureInput Parameters;

		// Token: 0x040008BF RID: 2239
		public int StartSequenceQuery;

		// Token: 0x040008C0 RID: 2240
		public int StartSequenceConfigure;

		// Token: 0x020000D5 RID: 213
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008C1 RID: 2241
			public AuthenticatedConfigureInput.__Native Parameters;

			// Token: 0x040008C2 RID: 2242
			public int StartSequenceQuery;

			// Token: 0x040008C3 RID: 2243
			public int StartSequenceConfigure;
		}
	}
}
