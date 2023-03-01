using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000F3 RID: 243
	public struct Macro
	{
		// Token: 0x0600073E RID: 1854 RVA: 0x00019E1C File Offset: 0x0001801C
		internal void __MarshalFree(ref Macro.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00019E24 File Offset: 0x00018024
		internal void __MarshalFrom(ref Macro.__Native @ref)
		{
			this.Name = ((@ref.Name == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Name));
			this.Definition = ((@ref.Definition == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Definition));
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00019E80 File Offset: 0x00018080
		internal void __MarshalTo(ref Macro.__Native @ref)
		{
			@ref.Name = ((this.Name == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Name));
			@ref.Definition = ((this.Definition == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Definition));
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00019ECD File Offset: 0x000180CD
		public Macro(string name, string definition)
		{
			this.Name = name;
			this.Definition = definition;
		}

		// Token: 0x04000DA7 RID: 3495
		public string Name;

		// Token: 0x04000DA8 RID: 3496
		public string Definition;

		// Token: 0x020000F4 RID: 244
		internal struct __Native
		{
			// Token: 0x06000742 RID: 1858 RVA: 0x00019EDD File Offset: 0x000180DD
			internal void __MarshalFree()
			{
				if (this.Name != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Name);
				}
				if (this.Definition != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Definition);
				}
			}

			// Token: 0x04000DA9 RID: 3497
			public IntPtr Name;

			// Token: 0x04000DAA RID: 3498
			public IntPtr Definition;
		}
	}
}
