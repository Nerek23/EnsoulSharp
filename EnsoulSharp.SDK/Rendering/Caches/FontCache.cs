using System;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.Rendering.Caches
{
	// Token: 0x020000A4 RID: 164
	public abstract class FontCache
	{
		// Token: 0x060005A3 RID: 1443 RVA: 0x000276EC File Offset: 0x000258EC
		internal FontCache(FontCache.DrawFontDescription fontDescription)
		{
			this.FontDescription = fontDescription;
		}

		// Token: 0x060005A4 RID: 1444
		public abstract RawRectangle MeasureText(string text, FontCache.DrawFontFlags fontDrawFlags);

		// Token: 0x060005A5 RID: 1445
		public abstract RawRectangle MeasureText(Sprite sprite, string text, FontCache.DrawFontFlags fontDrawFlags);

		// Token: 0x060005A6 RID: 1446
		public abstract void Dispose();

		// Token: 0x040002FE RID: 766
		public FontCache.DrawFontDescription FontDescription;

		// Token: 0x020004DD RID: 1245
		public class DrawFontDescription
		{
			// Token: 0x04000C8F RID: 3215
			public int Height;

			// Token: 0x04000C90 RID: 3216
			public int Width;

			// Token: 0x04000C91 RID: 3217
			public FontCache.DrawFontWeight Weight = FontCache.DrawFontWeight.DoNotCare;

			// Token: 0x04000C92 RID: 3218
			public int MipLevels;

			// Token: 0x04000C93 RID: 3219
			public RawBool Italic = false;

			// Token: 0x04000C94 RID: 3220
			public FontCharacterSet CharacterSet = FontCharacterSet.Default;

			// Token: 0x04000C95 RID: 3221
			public FontPrecision OutputPrecision = FontPrecision.TrueType;

			// Token: 0x04000C96 RID: 3222
			public FontQuality Quality = FontQuality.ClearTypeNatural;

			// Token: 0x04000C97 RID: 3223
			public FontPitchAndFamily PitchAndFamily = FontPitchAndFamily.Decorative | FontPitchAndFamily.Swiss;

			// Token: 0x04000C98 RID: 3224
			public string FaceName;
		}

		// Token: 0x020004DE RID: 1246
		public enum DrawFontWeight
		{
			// Token: 0x04000C9A RID: 3226
			DoNotCare = 400,
			// Token: 0x04000C9B RID: 3227
			Thin = 100,
			// Token: 0x04000C9C RID: 3228
			ExtraLight = 200,
			// Token: 0x04000C9D RID: 3229
			UltraLight = 200,
			// Token: 0x04000C9E RID: 3230
			Light = 300,
			// Token: 0x04000C9F RID: 3231
			SemiLight = 350,
			// Token: 0x04000CA0 RID: 3232
			Normal = 400,
			// Token: 0x04000CA1 RID: 3233
			Regular = 400,
			// Token: 0x04000CA2 RID: 3234
			Medium = 500,
			// Token: 0x04000CA3 RID: 3235
			DemiBold = 600,
			// Token: 0x04000CA4 RID: 3236
			SemiBold = 600,
			// Token: 0x04000CA5 RID: 3237
			Bold = 700,
			// Token: 0x04000CA6 RID: 3238
			ExtraBold = 800,
			// Token: 0x04000CA7 RID: 3239
			UltraBold = 800,
			// Token: 0x04000CA8 RID: 3240
			Black = 900,
			// Token: 0x04000CA9 RID: 3241
			Heavy = 900,
			// Token: 0x04000CAA RID: 3242
			ExtraBlack = 950,
			// Token: 0x04000CAB RID: 3243
			UltraBlack = 950
		}

		// Token: 0x020004DF RID: 1247
		[Flags]
		public enum DrawFontFlags
		{
			// Token: 0x04000CAD RID: 3245
			Left = 0,
			// Token: 0x04000CAE RID: 3246
			Top = 0,
			// Token: 0x04000CAF RID: 3247
			Center = 1,
			// Token: 0x04000CB0 RID: 3248
			Right = 2,
			// Token: 0x04000CB1 RID: 3249
			VerticalCenter = 4,
			// Token: 0x04000CB2 RID: 3250
			Bottom = 8
		}
	}
}
