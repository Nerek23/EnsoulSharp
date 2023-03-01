using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000DA RID: 218
	public struct AuthenticatedConfigureProtectionInput
	{
		// Token: 0x06000445 RID: 1093 RVA: 0x00010AAA File Offset: 0x0000ECAA
		internal void __MarshalFree(ref AuthenticatedConfigureProtectionInput.__Native @ref)
		{
			this.Parameters.__MarshalFree(ref @ref.Parameters);
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00010ABD File Offset: 0x0000ECBD
		internal void __MarshalFrom(ref AuthenticatedConfigureProtectionInput.__Native @ref)
		{
			this.Parameters.__MarshalFrom(ref @ref.Parameters);
			this.Protections = @ref.Protections;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00010ADC File Offset: 0x0000ECDC
		internal void __MarshalTo(ref AuthenticatedConfigureProtectionInput.__Native @ref)
		{
			this.Parameters.__MarshalTo(ref @ref.Parameters);
			@ref.Protections = this.Protections;
		}

		// Token: 0x040008D6 RID: 2262
		public AuthenticatedConfigureInput Parameters;

		// Token: 0x040008D7 RID: 2263
		public AuthenticatedProtectionFlags Protections;

		// Token: 0x020000DB RID: 219
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040008D8 RID: 2264
			public AuthenticatedConfigureInput.__Native Parameters;

			// Token: 0x040008D9 RID: 2265
			public AuthenticatedProtectionFlags Protections;
		}
	}
}
