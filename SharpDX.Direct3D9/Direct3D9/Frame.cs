using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000E7 RID: 231
	public struct Frame
	{
		// Token: 0x0600072B RID: 1835 RVA: 0x000199F9 File Offset: 0x00017BF9
		internal void __MarshalFree(ref Frame.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00019A04 File Offset: 0x00017C04
		internal void __MarshalFrom(ref Frame.__Native @ref)
		{
			this.Name = ((@ref.Name == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(@ref.Name));
			this.TransformationMatrix = @ref.TransformationMatrix;
			this.PMeshContainer = @ref.PMeshContainer;
			this.PFrameSibling = @ref.PFrameSibling;
			this.PFrameFirstChild = @ref.PFrameFirstChild;
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00019A68 File Offset: 0x00017C68
		internal void __MarshalTo(ref Frame.__Native @ref)
		{
			@ref.Name = ((this.Name == null) ? IntPtr.Zero : Utilities.StringToHGlobalAnsi(this.Name));
			@ref.TransformationMatrix = this.TransformationMatrix;
			@ref.PMeshContainer = this.PMeshContainer;
			@ref.PFrameSibling = this.PFrameSibling;
			@ref.PFrameFirstChild = this.PFrameFirstChild;
		}

		// Token: 0x04000A73 RID: 2675
		public string Name;

		// Token: 0x04000A74 RID: 2676
		public RawMatrix TransformationMatrix;

		// Token: 0x04000A75 RID: 2677
		public IntPtr PMeshContainer;

		// Token: 0x04000A76 RID: 2678
		public IntPtr PFrameSibling;

		// Token: 0x04000A77 RID: 2679
		public IntPtr PFrameFirstChild;

		// Token: 0x020000E8 RID: 232
		internal struct __Native
		{
			// Token: 0x0600072E RID: 1838 RVA: 0x00019AC5 File Offset: 0x00017CC5
			internal void __MarshalFree()
			{
				if (this.Name != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Name);
				}
			}

			// Token: 0x04000A78 RID: 2680
			public IntPtr Name;

			// Token: 0x04000A79 RID: 2681
			public RawMatrix TransformationMatrix;

			// Token: 0x04000A7A RID: 2682
			public IntPtr PMeshContainer;

			// Token: 0x04000A7B RID: 2683
			public IntPtr PFrameSibling;

			// Token: 0x04000A7C RID: 2684
			public IntPtr PFrameFirstChild;
		}
	}
}
