using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000125 RID: 293
	public class InfoQueueFilter
	{
		// Token: 0x0600047B RID: 1147 RVA: 0x00011202 File Offset: 0x0000F402
		internal void __MarshalFree(ref InfoQueueFilter.__Native @ref)
		{
			this.AllowList.__MarshalFree(ref @ref.AllowList);
			this.DenyList.__MarshalFree(ref @ref.DenyList);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00011226 File Offset: 0x0000F426
		internal void __MarshalFrom(ref InfoQueueFilter.__Native @ref)
		{
			this.AllowList.__MarshalFrom(ref @ref.AllowList);
			this.DenyList.__MarshalFrom(ref @ref.DenyList);
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0001124A File Offset: 0x0000F44A
		internal void __MarshalTo(ref InfoQueueFilter.__Native @ref)
		{
			this.AllowList.__MarshalTo(ref @ref.AllowList);
			this.DenyList.__MarshalTo(ref @ref.DenyList);
		}

		// Token: 0x040009B4 RID: 2484
		public InfoQueueFilterDescription AllowList;

		// Token: 0x040009B5 RID: 2485
		public InfoQueueFilterDescription DenyList;

		// Token: 0x02000126 RID: 294
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040009B6 RID: 2486
			public InfoQueueFilterDescription.__Native AllowList;

			// Token: 0x040009B7 RID: 2487
			public InfoQueueFilterDescription.__Native DenyList;
		}
	}
}
