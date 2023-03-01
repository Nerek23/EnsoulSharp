using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000DC RID: 220
	public struct ConstantTableDescription
	{
		// Token: 0x0600071B RID: 1819 RVA: 0x0001969C File Offset: 0x0001789C
		internal void __MarshalFree(ref ConstantTableDescription.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x000196A4 File Offset: 0x000178A4
		internal void __MarshalFrom(ref ConstantTableDescription.__Native @ref)
		{
			this.Creator = ((@ref.Creator == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Creator));
			this.Version = @ref.Version;
			this.Constants = @ref.Constants;
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x000196E4 File Offset: 0x000178E4
		internal void __MarshalTo(ref ConstantTableDescription.__Native @ref)
		{
			@ref.Creator = ((this.Creator == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Creator));
			@ref.Version = this.Version;
			@ref.Constants = this.Constants;
		}

		// Token: 0x04000A1E RID: 2590
		public string Creator;

		// Token: 0x04000A1F RID: 2591
		public int Version;

		// Token: 0x04000A20 RID: 2592
		public int Constants;

		// Token: 0x020000DD RID: 221
		internal struct __Native
		{
			// Token: 0x0600071E RID: 1822 RVA: 0x0001971E File Offset: 0x0001791E
			internal void __MarshalFree()
			{
				if (this.Creator != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Creator);
				}
			}

			// Token: 0x04000A21 RID: 2593
			public IntPtr Creator;

			// Token: 0x04000A22 RID: 2594
			public int Version;

			// Token: 0x04000A23 RID: 2595
			public int Constants;
		}
	}
}
