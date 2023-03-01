using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001FD RID: 509
	public struct LayerParameters
	{
		// Token: 0x06000AE9 RID: 2793 RVA: 0x00009E0F File Offset: 0x0000800F
		internal void __MarshalFree(ref LayerParameters.__Native @ref)
		{
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0001F3DC File Offset: 0x0001D5DC
		internal void __MarshalFrom(ref LayerParameters.__Native @ref)
		{
			this.ContentBounds = @ref.ContentBounds;
			if (@ref.GeometricMask != IntPtr.Zero)
			{
				this.GeometricMask = new Geometry(@ref.GeometricMask);
			}
			else
			{
				this.GeometricMask = null;
			}
			this.MaskAntialiasMode = @ref.MaskAntialiasMode;
			this.MaskTransform = @ref.MaskTransform;
			this.Opacity = @ref.Opacity;
			if (@ref.OpacityBrush != IntPtr.Zero)
			{
				this.OpacityBrush = new Brush(@ref.OpacityBrush);
			}
			else
			{
				this.OpacityBrush = null;
			}
			this.LayerOptions = @ref.LayerOptions;
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x0001F480 File Offset: 0x0001D680
		internal void __MarshalTo(ref LayerParameters.__Native @ref)
		{
			@ref.ContentBounds = this.ContentBounds;
			@ref.GeometricMask = CppObject.ToCallbackPtr<Geometry>(this.GeometricMask);
			@ref.MaskAntialiasMode = this.MaskAntialiasMode;
			@ref.MaskTransform = this.MaskTransform;
			@ref.Opacity = this.Opacity;
			@ref.OpacityBrush = CppObject.ToCallbackPtr<Brush>(this.OpacityBrush);
			@ref.LayerOptions = this.LayerOptions;
		}

		// Token: 0x04000676 RID: 1654
		public RawRectangleF ContentBounds;

		// Token: 0x04000677 RID: 1655
		public Geometry GeometricMask;

		// Token: 0x04000678 RID: 1656
		public AntialiasMode MaskAntialiasMode;

		// Token: 0x04000679 RID: 1657
		public RawMatrix3x2 MaskTransform;

		// Token: 0x0400067A RID: 1658
		public float Opacity;

		// Token: 0x0400067B RID: 1659
		public Brush OpacityBrush;

		// Token: 0x0400067C RID: 1660
		public LayerOptions LayerOptions;

		// Token: 0x020001FE RID: 510
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x0400067D RID: 1661
			public RawRectangleF ContentBounds;

			// Token: 0x0400067E RID: 1662
			public IntPtr GeometricMask;

			// Token: 0x0400067F RID: 1663
			public AntialiasMode MaskAntialiasMode;

			// Token: 0x04000680 RID: 1664
			public RawMatrix3x2 MaskTransform;

			// Token: 0x04000681 RID: 1665
			public float Opacity;

			// Token: 0x04000682 RID: 1666
			public IntPtr OpacityBrush;

			// Token: 0x04000683 RID: 1667
			public LayerOptions LayerOptions;
		}
	}
}
