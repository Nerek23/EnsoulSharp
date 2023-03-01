using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000DC RID: 220
	public struct AuthenticatedConfigureSharedResourceInput
	{
		// Token: 0x06000448 RID: 1096 RVA: 0x00010AFB File Offset: 0x0000ECFB
		internal void __MarshalFree(ref AuthenticatedConfigureSharedResourceInput.__Native @ref)
		{
			this.Parameters.__MarshalFree(ref @ref.Parameters);
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00010B0E File Offset: 0x0000ED0E
		internal void __MarshalFrom(ref AuthenticatedConfigureSharedResourceInput.__Native @ref)
		{
			this.Parameters.__MarshalFrom(ref @ref.Parameters);
			this.ProcessType = @ref.ProcessType;
			this.ProcessHandle = @ref.ProcessHandle;
			this.AllowAccess = @ref.AllowAccess;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00010B45 File Offset: 0x0000ED45
		internal void __MarshalTo(ref AuthenticatedConfigureSharedResourceInput.__Native @ref)
		{
			this.Parameters.__MarshalTo(ref @ref.Parameters);
			@ref.ProcessType = this.ProcessType;
			@ref.ProcessHandle = this.ProcessHandle;
			@ref.AllowAccess = this.AllowAccess;
		}

		// Token: 0x040008DA RID: 2266
		public AuthenticatedConfigureInput Parameters;

		// Token: 0x040008DB RID: 2267
		public AuthenticatedProcessIdentifierType ProcessType;

		// Token: 0x040008DC RID: 2268
		public IntPtr ProcessHandle;

		// Token: 0x040008DD RID: 2269
		public RawBool AllowAccess;

		// Token: 0x020000DD RID: 221
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008DE RID: 2270
			public AuthenticatedConfigureInput.__Native Parameters;

			// Token: 0x040008DF RID: 2271
			public AuthenticatedProcessIdentifierType ProcessType;

			// Token: 0x040008E0 RID: 2272
			public IntPtr ProcessHandle;

			// Token: 0x040008E1 RID: 2273
			public RawBool AllowAccess;
		}
	}
}
