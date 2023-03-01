using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000100 RID: 256
	public struct AuthenticatedQueryUnrestrictedProtectedSharedResourceCountOutput
	{
		// Token: 0x06000478 RID: 1144 RVA: 0x000111B1 File Offset: 0x0000F3B1
		internal void __MarshalFree(ref AuthenticatedQueryUnrestrictedProtectedSharedResourceCountOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x000111C4 File Offset: 0x0000F3C4
		internal void __MarshalFrom(ref AuthenticatedQueryUnrestrictedProtectedSharedResourceCountOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.UnrestrictedProtectedSharedResourceCount = @ref.UnrestrictedProtectedSharedResourceCount;
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x000111E3 File Offset: 0x0000F3E3
		internal void __MarshalTo(ref AuthenticatedQueryUnrestrictedProtectedSharedResourceCountOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.UnrestrictedProtectedSharedResourceCount = this.UnrestrictedProtectedSharedResourceCount;
		}

		// Token: 0x04000949 RID: 2377
		public AuthenticatedQueryOutput Output;

		// Token: 0x0400094A RID: 2378
		public int UnrestrictedProtectedSharedResourceCount;

		// Token: 0x02000101 RID: 257
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x0400094B RID: 2379
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x0400094C RID: 2380
			public int UnrestrictedProtectedSharedResourceCount;
		}
	}
}
