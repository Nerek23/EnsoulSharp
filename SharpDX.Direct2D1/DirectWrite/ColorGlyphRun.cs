using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200014E RID: 334
	public struct ColorGlyphRun
	{
		// Token: 0x06000659 RID: 1625 RVA: 0x0001479E File Offset: 0x0001299E
		internal void __MarshalFree(ref ColorGlyphRun.__Native @ref)
		{
			this.GlyphRun.__MarshalFree(ref @ref.GlyphRun);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x000147B4 File Offset: 0x000129B4
		internal void __MarshalFrom(ref ColorGlyphRun.__Native @ref)
		{
			this.GlyphRun.__MarshalFrom(ref @ref.GlyphRun);
			this.GlyphRunDescription = @ref.GlyphRunDescription;
			this.BaselineOriginX = @ref.BaselineOriginX;
			this.BaselineOriginY = @ref.BaselineOriginY;
			this.RunColor = @ref.RunColor;
			this.PaletteIndex = @ref.PaletteIndex;
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x00014810 File Offset: 0x00012A10
		internal void __MarshalTo(ref ColorGlyphRun.__Native @ref)
		{
			this.GlyphRun.__MarshalTo(ref @ref.GlyphRun);
			@ref.GlyphRunDescription = this.GlyphRunDescription;
			@ref.BaselineOriginX = this.BaselineOriginX;
			@ref.BaselineOriginY = this.BaselineOriginY;
			@ref.RunColor = this.RunColor;
			@ref.PaletteIndex = this.PaletteIndex;
		}

		// Token: 0x040004E1 RID: 1249
		public GlyphRun GlyphRun;

		// Token: 0x040004E2 RID: 1250
		public IntPtr GlyphRunDescription;

		// Token: 0x040004E3 RID: 1251
		public float BaselineOriginX;

		// Token: 0x040004E4 RID: 1252
		public float BaselineOriginY;

		// Token: 0x040004E5 RID: 1253
		public RawColor4 RunColor;

		// Token: 0x040004E6 RID: 1254
		public short PaletteIndex;

		// Token: 0x0200014F RID: 335
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x040004E7 RID: 1255
			public GlyphRun.__Native GlyphRun;

			// Token: 0x040004E8 RID: 1256
			public IntPtr GlyphRunDescription;

			// Token: 0x040004E9 RID: 1257
			public float BaselineOriginX;

			// Token: 0x040004EA RID: 1258
			public float BaselineOriginY;

			// Token: 0x040004EB RID: 1259
			public RawColor4 RunColor;

			// Token: 0x040004EC RID: 1260
			public short PaletteIndex;
		}
	}
}
