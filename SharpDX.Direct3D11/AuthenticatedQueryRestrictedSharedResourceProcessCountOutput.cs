using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000FB RID: 251
	public struct AuthenticatedQueryRestrictedSharedResourceProcessCountOutput
	{
		// Token: 0x06000472 RID: 1138 RVA: 0x000110DF File Offset: 0x0000F2DF
		internal void __MarshalFree(ref AuthenticatedQueryRestrictedSharedResourceProcessCountOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x000110F2 File Offset: 0x0000F2F2
		internal void __MarshalFrom(ref AuthenticatedQueryRestrictedSharedResourceProcessCountOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.RestrictedSharedResourceProcessCount = @ref.RestrictedSharedResourceProcessCount;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00011111 File Offset: 0x0000F311
		internal void __MarshalTo(ref AuthenticatedQueryRestrictedSharedResourceProcessCountOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.RestrictedSharedResourceProcessCount = this.RestrictedSharedResourceProcessCount;
		}

		// Token: 0x0400093B RID: 2363
		public AuthenticatedQueryOutput Output;

		// Token: 0x0400093C RID: 2364
		public int RestrictedSharedResourceProcessCount;

		// Token: 0x020000FC RID: 252
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x0400093D RID: 2365
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x0400093E RID: 2366
			public int RestrictedSharedResourceProcessCount;
		}
	}
}
