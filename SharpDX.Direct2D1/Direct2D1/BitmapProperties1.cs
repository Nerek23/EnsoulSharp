using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200017A RID: 378
	public class BitmapProperties1
	{
		// Token: 0x060006F3 RID: 1779 RVA: 0x000067AA File Offset: 0x000049AA
		public BitmapProperties1()
		{
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00015D44 File Offset: 0x00013F44
		public BitmapProperties1(PixelFormat pixelFormat) : this(pixelFormat, 96f, 96f)
		{
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00015D57 File Offset: 0x00013F57
		public BitmapProperties1(PixelFormat pixelFormat, float dpiX, float dpiY) : this(pixelFormat, dpiX, dpiY, BitmapOptions.None)
		{
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00015D63 File Offset: 0x00013F63
		public BitmapProperties1(PixelFormat pixelFormat, float dpiX, float dpiY, BitmapOptions bitmapOptions) : this(pixelFormat, dpiX, dpiY, bitmapOptions, null)
		{
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00015D71 File Offset: 0x00013F71
		public BitmapProperties1(PixelFormat pixelFormat, float dpiX, float dpiY, BitmapOptions bitmapOptions, ColorContext colorContext)
		{
			this.PixelFormat = pixelFormat;
			this.DpiX = dpiX;
			this.DpiY = dpiY;
			this.BitmapOptions = bitmapOptions;
			this.ColorContext = colorContext;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00009E0F File Offset: 0x0000800F
		internal void __MarshalFree(ref BitmapProperties1.__Native @ref)
		{
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00015DA0 File Offset: 0x00013FA0
		internal void __MarshalFrom(ref BitmapProperties1.__Native @ref)
		{
			this.PixelFormat = @ref.PixelFormat;
			this.DpiX = @ref.DpiX;
			this.DpiY = @ref.DpiY;
			this.BitmapOptions = @ref.BitmapOptions;
			if (@ref.ColorContext != IntPtr.Zero)
			{
				this.ColorContext = new ColorContext(@ref.ColorContext);
				return;
			}
			this.ColorContext = null;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00015E08 File Offset: 0x00014008
		internal void __MarshalTo(ref BitmapProperties1.__Native @ref)
		{
			@ref.PixelFormat = this.PixelFormat;
			@ref.DpiX = this.DpiX;
			@ref.DpiY = this.DpiY;
			@ref.BitmapOptions = this.BitmapOptions;
			@ref.ColorContext = CppObject.ToCallbackPtr<ColorContext>(this.ColorContext);
		}

		// Token: 0x040005EE RID: 1518
		private ColorContext colorContext;

		// Token: 0x040005EF RID: 1519
		public PixelFormat PixelFormat;

		// Token: 0x040005F0 RID: 1520
		public float DpiX;

		// Token: 0x040005F1 RID: 1521
		public float DpiY;

		// Token: 0x040005F2 RID: 1522
		public BitmapOptions BitmapOptions;

		// Token: 0x040005F3 RID: 1523
		public ColorContext ColorContext;

		// Token: 0x0200017B RID: 379
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040005F4 RID: 1524
			public PixelFormat PixelFormat;

			// Token: 0x040005F5 RID: 1525
			public float DpiX;

			// Token: 0x040005F6 RID: 1526
			public float DpiY;

			// Token: 0x040005F7 RID: 1527
			public BitmapOptions BitmapOptions;

			// Token: 0x040005F8 RID: 1528
			public IntPtr ColorContext;
		}
	}
}
