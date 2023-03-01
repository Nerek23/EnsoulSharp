using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000F9 RID: 249
	public struct AuthenticatedQueryProtectionOutput
	{
		// Token: 0x0600046F RID: 1135 RVA: 0x0001108E File Offset: 0x0000F28E
		internal void __MarshalFree(ref AuthenticatedQueryProtectionOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x000110A1 File Offset: 0x0000F2A1
		internal void __MarshalFrom(ref AuthenticatedQueryProtectionOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.ProtectionFlags = @ref.ProtectionFlags;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x000110C0 File Offset: 0x0000F2C0
		internal void __MarshalTo(ref AuthenticatedQueryProtectionOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.ProtectionFlags = this.ProtectionFlags;
		}

		// Token: 0x04000937 RID: 2359
		public AuthenticatedQueryOutput Output;

		// Token: 0x04000938 RID: 2360
		public AuthenticatedProtectionFlags ProtectionFlags;

		// Token: 0x020000FA RID: 250
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000939 RID: 2361
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x0400093A RID: 2362
			public AuthenticatedProtectionFlags ProtectionFlags;
		}
	}
}
