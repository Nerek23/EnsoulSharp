using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000E3 RID: 227
	public struct ExtendedMaterial
	{
		// Token: 0x06000723 RID: 1827 RVA: 0x00019810 File Offset: 0x00017A10
		internal void __MarshalFree(ref ExtendedMaterial.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00019818 File Offset: 0x00017A18
		internal void __MarshalFrom(ref ExtendedMaterial.__Native @ref)
		{
			this.MaterialD3D = @ref.MaterialD3D;
			this.TextureFileName = ((@ref.TextureFileName == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.TextureFileName));
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0001984C File Offset: 0x00017A4C
		internal void __MarshalTo(ref ExtendedMaterial.__Native @ref)
		{
			@ref.MaterialD3D = this.MaterialD3D;
			@ref.TextureFileName = ((this.TextureFileName == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.TextureFileName));
		}

		// Token: 0x04000A3C RID: 2620
		public Material MaterialD3D;

		// Token: 0x04000A3D RID: 2621
		public string TextureFileName;

		// Token: 0x020000E4 RID: 228
		internal struct __Native
		{
			// Token: 0x06000726 RID: 1830 RVA: 0x0001987A File Offset: 0x00017A7A
			internal void __MarshalFree()
			{
				if (this.TextureFileName != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.TextureFileName);
				}
			}

			// Token: 0x04000A3E RID: 2622
			public Material MaterialD3D;

			// Token: 0x04000A3F RID: 2623
			public IntPtr TextureFileName;
		}
	}
}
