using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000FE RID: 254
	public struct AuthenticatedQueryRestrictedSharedResourceProcessOutput
	{
		// Token: 0x06000475 RID: 1141 RVA: 0x00011130 File Offset: 0x0000F330
		internal void __MarshalFree(ref AuthenticatedQueryRestrictedSharedResourceProcessOutput.__Native @ref)
		{
			this.Output.__MarshalFree(ref @ref.Output);
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00011143 File Offset: 0x0000F343
		internal void __MarshalFrom(ref AuthenticatedQueryRestrictedSharedResourceProcessOutput.__Native @ref)
		{
			this.Output.__MarshalFrom(ref @ref.Output);
			this.ProcessIndex = @ref.ProcessIndex;
			this.ProcessIdentifier = @ref.ProcessIdentifier;
			this.ProcessHandle = @ref.ProcessHandle;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0001117A File Offset: 0x0000F37A
		internal void __MarshalTo(ref AuthenticatedQueryRestrictedSharedResourceProcessOutput.__Native @ref)
		{
			this.Output.__MarshalTo(ref @ref.Output);
			@ref.ProcessIndex = this.ProcessIndex;
			@ref.ProcessIdentifier = this.ProcessIdentifier;
			@ref.ProcessHandle = this.ProcessHandle;
		}

		// Token: 0x04000941 RID: 2369
		public AuthenticatedQueryOutput Output;

		// Token: 0x04000942 RID: 2370
		public int ProcessIndex;

		// Token: 0x04000943 RID: 2371
		public AuthenticatedProcessIdentifierType ProcessIdentifier;

		// Token: 0x04000944 RID: 2372
		public IntPtr ProcessHandle;

		// Token: 0x020000FF RID: 255
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000945 RID: 2373
			public AuthenticatedQueryOutput.__Native Output;

			// Token: 0x04000946 RID: 2374
			public int ProcessIndex;

			// Token: 0x04000947 RID: 2375
			public AuthenticatedProcessIdentifierType ProcessIdentifier;

			// Token: 0x04000948 RID: 2376
			public IntPtr ProcessHandle;
		}
	}
}
