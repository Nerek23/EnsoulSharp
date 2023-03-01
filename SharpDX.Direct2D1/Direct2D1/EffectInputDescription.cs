using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200031F RID: 799
	public class EffectInputDescription
	{
		// Token: 0x06000E08 RID: 3592 RVA: 0x00009E0F File Offset: 0x0000800F
		internal void __MarshalFree(ref EffectInputDescription.__Native @ref)
		{
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00026BEC File Offset: 0x00024DEC
		internal void __MarshalFrom(ref EffectInputDescription.__Native @ref)
		{
			if (@ref.Effect != IntPtr.Zero)
			{
				this.Effect = new Effect(@ref.Effect);
			}
			else
			{
				this.Effect = null;
			}
			this.InputIndex = @ref.InputIndex;
			this.InputRectangle = @ref.InputRectangle;
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x00026C3D File Offset: 0x00024E3D
		internal void __MarshalTo(ref EffectInputDescription.__Native @ref)
		{
			@ref.Effect = CppObject.ToCallbackPtr<Effect>(this.Effect);
			@ref.InputIndex = this.InputIndex;
			@ref.InputRectangle = this.InputRectangle;
		}

		// Token: 0x04000AC6 RID: 2758
		public Effect Effect;

		// Token: 0x04000AC7 RID: 2759
		public int InputIndex;

		// Token: 0x04000AC8 RID: 2760
		public RawRectangleF InputRectangle;

		// Token: 0x02000320 RID: 800
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000AC9 RID: 2761
			public IntPtr Effect;

			// Token: 0x04000ACA RID: 2762
			public int InputIndex;

			// Token: 0x04000ACB RID: 2763
			public RawRectangleF InputRectangle;
		}
	}
}
