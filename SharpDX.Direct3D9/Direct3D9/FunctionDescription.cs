using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000E9 RID: 233
	public struct FunctionDescription
	{
		// Token: 0x0600072F RID: 1839 RVA: 0x00019AE4 File Offset: 0x00017CE4
		internal void __MarshalFree(ref FunctionDescription.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00019AEC File Offset: 0x00017CEC
		internal void __MarshalFrom(ref FunctionDescription.__Native @ref)
		{
			this.Name = ((@ref.Name == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Name));
			this.Annotations = @ref.Annotations;
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00019B20 File Offset: 0x00017D20
		internal void __MarshalTo(ref FunctionDescription.__Native @ref)
		{
			@ref.Name = ((this.Name == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Name));
			@ref.Annotations = this.Annotations;
		}

		// Token: 0x04000A7D RID: 2685
		public string Name;

		// Token: 0x04000A7E RID: 2686
		public int Annotations;

		// Token: 0x020000EA RID: 234
		internal struct __Native
		{
			// Token: 0x06000732 RID: 1842 RVA: 0x00019B4E File Offset: 0x00017D4E
			internal void __MarshalFree()
			{
				if (this.Name != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Name);
				}
			}

			// Token: 0x04000A7F RID: 2687
			public IntPtr Name;

			// Token: 0x04000A80 RID: 2688
			public int Annotations;
		}
	}
}
