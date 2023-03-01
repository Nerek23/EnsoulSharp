using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000A9 RID: 169
	public class GlyphRunDescription
	{
		// Token: 0x06000362 RID: 866 RVA: 0x0000CA14 File Offset: 0x0000AC14
		internal void __MarshalFrom(ref GlyphRunDescription.__Native @ref)
		{
			this.LocaleName = ((@ref.LocaleName == IntPtr.Zero) ? null : Marshal.PtrToStringUni(@ref.LocaleName));
			this.Text = ((@ref.Text == IntPtr.Zero) ? null : Marshal.PtrToStringUni(@ref.Text, @ref.TextLength));
			this.TextLength = @ref.TextLength;
			this.ClusterMap = @ref.ClusterMap;
			this.TextPosition = @ref.TextPosition;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000CA98 File Offset: 0x0000AC98
		internal void __MarshalTo(ref GlyphRunDescription.__Native @ref)
		{
			@ref.LocaleName = ((this.LocaleName == null) ? IntPtr.Zero : Marshal.StringToHGlobalUni(this.LocaleName));
			@ref.Text = ((this.Text == null) ? IntPtr.Zero : Marshal.StringToHGlobalUni(this.Text));
			@ref.TextLength = ((this.Text == null) ? 0 : this.Text.Length);
			@ref.ClusterMap = this.ClusterMap;
			@ref.TextPosition = this.TextPosition;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000CB19 File Offset: 0x0000AD19
		internal void __MarshalFree(ref GlyphRunDescription.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x0400023F RID: 575
		public string LocaleName;

		// Token: 0x04000240 RID: 576
		public string Text;

		// Token: 0x04000241 RID: 577
		internal int TextLength;

		// Token: 0x04000242 RID: 578
		public IntPtr ClusterMap;

		// Token: 0x04000243 RID: 579
		public int TextPosition;

		// Token: 0x020000AA RID: 170
		internal struct __Native
		{
			// Token: 0x06000366 RID: 870 RVA: 0x0000CB21 File Offset: 0x0000AD21
			internal void __MarshalFree()
			{
				if (this.LocaleName != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.LocaleName);
				}
				if (this.Text != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.Text);
				}
			}

			// Token: 0x04000244 RID: 580
			public IntPtr LocaleName;

			// Token: 0x04000245 RID: 581
			public IntPtr Text;

			// Token: 0x04000246 RID: 582
			public int TextLength;

			// Token: 0x04000247 RID: 583
			public IntPtr ClusterMap;

			// Token: 0x04000248 RID: 584
			public int TextPosition;
		}
	}
}
