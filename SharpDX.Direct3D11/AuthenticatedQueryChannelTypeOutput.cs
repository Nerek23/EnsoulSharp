using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000E7 RID: 231
	public struct AuthenticatedQueryChannelTypeOutput
	{
		// Token: 0x0600045A RID: 1114 RVA: 0x00010D35 File Offset: 0x0000EF35
		internal void __MarshalFree(ref AuthenticatedQueryChannelTypeOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00010D48 File Offset: 0x0000EF48
		internal void __MarshalFrom(ref AuthenticatedQueryChannelTypeOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.ChannelType = @ref.ChannelType;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00010D67 File Offset: 0x0000EF67
		internal void __MarshalTo(ref AuthenticatedQueryChannelTypeOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.ChannelType = this.ChannelType;
		}

		// Token: 0x040008FB RID: 2299
		public AuthenticatedQueryOutput Output;

		// Token: 0x040008FC RID: 2300
		public AuthenticatedChannelType ChannelType;

		// Token: 0x020000E8 RID: 232
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008FD RID: 2301
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x040008FE RID: 2302
			public AuthenticatedChannelType ChannelType;
		}
	}
}
