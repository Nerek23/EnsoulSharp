using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000150 RID: 336
	public struct ColorGlyphRun1
	{
		// Token: 0x0600065C RID: 1628 RVA: 0x0001486A File Offset: 0x00012A6A
		internal void __MarshalFree(ref ColorGlyphRun1.__Native @ref)
		{
			this.GlyphRun.__MarshalFree(ref @ref.GlyphRun);
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x00014880 File Offset: 0x00012A80
		internal void __MarshalFrom(ref ColorGlyphRun1.__Native @ref)
		{
			this.GlyphRun.__MarshalFrom(ref @ref.GlyphRun);
			this.GlyphRunDescription = @ref.GlyphRunDescription;
			this.BaselineOriginX = @ref.BaselineOriginX;
			this.BaselineOriginY = @ref.BaselineOriginY;
			this.RunColor = @ref.RunColor;
			this.PaletteIndex = @ref.PaletteIndex;
			this.GlyphImageFormat = @ref.GlyphImageFormat;
			this.MeasuringMode = @ref.MeasuringMode;
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x000148F4 File Offset: 0x00012AF4
		internal void __MarshalTo(ref ColorGlyphRun1.__Native @ref)
		{
			this.GlyphRun.__MarshalTo(ref @ref.GlyphRun);
			@ref.GlyphRunDescription = this.GlyphRunDescription;
			@ref.BaselineOriginX = this.BaselineOriginX;
			@ref.BaselineOriginY = this.BaselineOriginY;
			@ref.RunColor = this.RunColor;
			@ref.PaletteIndex = this.PaletteIndex;
			@ref.GlyphImageFormat = this.GlyphImageFormat;
			@ref.MeasuringMode = this.MeasuringMode;
		}

		// Token: 0x040004ED RID: 1261
		public GlyphRun GlyphRun;

		// Token: 0x040004EE RID: 1262
		public IntPtr GlyphRunDescription;

		// Token: 0x040004EF RID: 1263
		public float BaselineOriginX;

		// Token: 0x040004F0 RID: 1264
		public float BaselineOriginY;

		// Token: 0x040004F1 RID: 1265
		public RawColor4 RunColor;

		// Token: 0x040004F2 RID: 1266
		public short PaletteIndex;

		// Token: 0x040004F3 RID: 1267
		public GlyphImageFormatS GlyphImageFormat;

		// Token: 0x040004F4 RID: 1268
		public MeasuringMode MeasuringMode;

		// Token: 0x02000151 RID: 337
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040004F5 RID: 1269
			public GlyphRun.__Native GlyphRun;

			// Token: 0x040004F6 RID: 1270
			public IntPtr GlyphRunDescription;

			// Token: 0x040004F7 RID: 1271
			public float BaselineOriginX;

			// Token: 0x040004F8 RID: 1272
			public float BaselineOriginY;

			// Token: 0x040004F9 RID: 1273
			public RawColor4 RunColor;

			// Token: 0x040004FA RID: 1274
			public short PaletteIndex;

			// Token: 0x040004FB RID: 1275
			public GlyphImageFormatS GlyphImageFormat;

			// Token: 0x040004FC RID: 1276
			public MeasuringMode MeasuringMode;
		}
	}
}
