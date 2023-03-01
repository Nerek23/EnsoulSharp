using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000E0 RID: 224
	public struct EffectDescription
	{
		// Token: 0x0600071F RID: 1823 RVA: 0x0001973D File Offset: 0x0001793D
		internal void __MarshalFree(ref EffectDescription.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00019748 File Offset: 0x00017948
		internal void __MarshalFrom(ref EffectDescription.__Native @ref)
		{
			this.Creator = ((@ref.Creator == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Creator));
			this.Parameters = @ref.Parameters;
			this.Techniques = @ref.Techniques;
			this.Functions = @ref.Functions;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x000197A0 File Offset: 0x000179A0
		internal void __MarshalTo(ref EffectDescription.__Native @ref)
		{
			@ref.Creator = ((this.Creator == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Creator));
			@ref.Parameters = this.Parameters;
			@ref.Techniques = this.Techniques;
			@ref.Functions = this.Functions;
		}

		// Token: 0x04000A2B RID: 2603
		public string Creator;

		// Token: 0x04000A2C RID: 2604
		public int Parameters;

		// Token: 0x04000A2D RID: 2605
		public int Techniques;

		// Token: 0x04000A2E RID: 2606
		public int Functions;

		// Token: 0x020000E1 RID: 225
		internal struct __Native
		{
			// Token: 0x06000722 RID: 1826 RVA: 0x000197F1 File Offset: 0x000179F1
			internal void __MarshalFree()
			{
				if (this.Creator != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Creator);
				}
			}

			// Token: 0x04000A2F RID: 2607
			public IntPtr Creator;

			// Token: 0x04000A30 RID: 2608
			public int Parameters;

			// Token: 0x04000A31 RID: 2609
			public int Techniques;

			// Token: 0x04000A32 RID: 2610
			public int Functions;
		}
	}
}
