using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000110 RID: 272
	public struct TechniqueDescription
	{
		// Token: 0x0600075B RID: 1883 RVA: 0x0001A5D6 File Offset: 0x000187D6
		internal void __MarshalFree(ref TechniqueDescription.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0001A5DE File Offset: 0x000187DE
		internal void __MarshalFrom(ref TechniqueDescription.__Native @ref)
		{
			this.Name = ((@ref.Name == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Name));
			this.Passes = @ref.Passes;
			this.Annotations = @ref.Annotations;
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x0001A61E File Offset: 0x0001881E
		internal void __MarshalTo(ref TechniqueDescription.__Native @ref)
		{
			@ref.Name = ((this.Name == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Name));
			@ref.Passes = this.Passes;
			@ref.Annotations = this.Annotations;
		}

		// Token: 0x04000E46 RID: 3654
		public string Name;

		// Token: 0x04000E47 RID: 3655
		public int Passes;

		// Token: 0x04000E48 RID: 3656
		public int Annotations;

		// Token: 0x02000111 RID: 273
		internal struct __Native
		{
			// Token: 0x0600075E RID: 1886 RVA: 0x0001A658 File Offset: 0x00018858
			internal void __MarshalFree()
			{
				if (this.Name != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Name);
				}
			}

			// Token: 0x04000E49 RID: 3657
			public IntPtr Name;

			// Token: 0x04000E4A RID: 3658
			public int Passes;

			// Token: 0x04000E4B RID: 3659
			public int Annotations;
		}
	}
}
