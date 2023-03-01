using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000FB RID: 251
	public struct PassDescription
	{
		// Token: 0x06000750 RID: 1872 RVA: 0x0001A35D File Offset: 0x0001855D
		internal void __MarshalFree(ref PassDescription.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0001A368 File Offset: 0x00018568
		internal void __MarshalFrom(ref PassDescription.__Native @ref)
		{
			this.Name = ((@ref.Name == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Name));
			this.Annotations = @ref.Annotations;
			this.PVertexShaderFunction = @ref.PVertexShaderFunction;
			this.PPixelShaderFunction = @ref.PPixelShaderFunction;
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0001A3C0 File Offset: 0x000185C0
		internal void __MarshalTo(ref PassDescription.__Native @ref)
		{
			@ref.Name = ((this.Name == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Name));
			@ref.Annotations = this.Annotations;
			@ref.PVertexShaderFunction = this.PVertexShaderFunction;
			@ref.PPixelShaderFunction = this.PPixelShaderFunction;
		}

		// Token: 0x04000DDA RID: 3546
		public string Name;

		// Token: 0x04000DDB RID: 3547
		public int Annotations;

		// Token: 0x04000DDC RID: 3548
		public IntPtr PVertexShaderFunction;

		// Token: 0x04000DDD RID: 3549
		public IntPtr PPixelShaderFunction;

		// Token: 0x020000FC RID: 252
		internal struct __Native
		{
			// Token: 0x06000753 RID: 1875 RVA: 0x0001A411 File Offset: 0x00018611
			internal void __MarshalFree()
			{
				if (this.Name != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Name);
				}
			}

			// Token: 0x04000DDE RID: 3550
			public IntPtr Name;

			// Token: 0x04000DDF RID: 3551
			public int Annotations;

			// Token: 0x04000DE0 RID: 3552
			public IntPtr PVertexShaderFunction;

			// Token: 0x04000DE1 RID: 3553
			public IntPtr PPixelShaderFunction;
		}
	}
}
