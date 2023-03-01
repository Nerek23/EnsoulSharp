using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001FF RID: 511
	public struct LayerParameters1
	{
		// Token: 0x06000AEC RID: 2796 RVA: 0x0001F4EB File Offset: 0x0001D6EB
		public LayerParameters1(RawRectangleF contentBounds, Geometry geometryMask, AntialiasMode maskAntialiasMode, RawMatrix3x2 maskTransform, float opacity, Brush opacityBrush, LayerOptions1 layerOptions)
		{
			this = default(LayerParameters1);
			this.ContentBounds = contentBounds;
			this.GeometricMask = geometryMask;
			this.MaskAntialiasMode = maskAntialiasMode;
			this.MaskTransform = maskTransform;
			this.Opacity = opacity;
			this.OpacityBrush = opacityBrush;
			this.LayerOptions = layerOptions;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x00009E0F File Offset: 0x0000800F
		internal void __MarshalFree(ref LayerParameters1.__Native @ref)
		{
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0001F52C File Offset: 0x0001D72C
		internal void __MarshalFrom(ref LayerParameters1.__Native @ref)
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

		// Token: 0x06000AEF RID: 2799 RVA: 0x0001F5D0 File Offset: 0x0001D7D0
		internal void __MarshalTo(ref LayerParameters1.__Native @ref)
		{
			@ref.ContentBounds = this.ContentBounds;
			@ref.GeometricMask = CppObject.ToCallbackPtr<Geometry>(this.GeometricMask);
			@ref.MaskAntialiasMode = this.MaskAntialiasMode;
			@ref.MaskTransform = this.MaskTransform;
			@ref.Opacity = this.Opacity;
			@ref.OpacityBrush = CppObject.ToCallbackPtr<Brush>(this.OpacityBrush);
			@ref.LayerOptions = this.LayerOptions;
		}

		// Token: 0x04000684 RID: 1668
		public RawRectangleF ContentBounds;

		// Token: 0x04000685 RID: 1669
		public Geometry GeometricMask;

		// Token: 0x04000686 RID: 1670
		public AntialiasMode MaskAntialiasMode;

		// Token: 0x04000687 RID: 1671
		public RawMatrix3x2 MaskTransform;

		// Token: 0x04000688 RID: 1672
		public float Opacity;

		// Token: 0x04000689 RID: 1673
		public Brush OpacityBrush;

		// Token: 0x0400068A RID: 1674
		public LayerOptions1 LayerOptions;

		// Token: 0x02000200 RID: 512
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x0400068B RID: 1675
			public RawRectangleF ContentBounds;

			// Token: 0x0400068C RID: 1676
			public IntPtr GeometricMask;

			// Token: 0x0400068D RID: 1677
			public AntialiasMode MaskAntialiasMode;

			// Token: 0x0400068E RID: 1678
			public RawMatrix3x2 MaskTransform;

			// Token: 0x0400068F RID: 1679
			public float Opacity;

			// Token: 0x04000690 RID: 1680
			public IntPtr OpacityBrush;

			// Token: 0x04000691 RID: 1681
			public LayerOptions1 LayerOptions;
		}
	}
}
