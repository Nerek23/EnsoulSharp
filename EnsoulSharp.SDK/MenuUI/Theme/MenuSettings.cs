using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI.Theme
{
	// Token: 0x020000CA RID: 202
	internal class MenuSettings
	{
		// Token: 0x060007AF RID: 1967 RVA: 0x0002D570 File Offset: 0x0002B770
		static MenuSettings()
		{
			MenuSettings.ContainerWidth = 200f;
			MenuSettings.Font = TextRender.CreateFont(new FontCache.DrawFontDescription
			{
				Height = 15,
				FaceName = "Tahoma",
				Weight = FontCache.DrawFontWeight.DoNotCare,
				OutputPrecision = FontPrecision.TrueType,
				Quality = FontQuality.ClearTypeNatural,
				PitchAndFamily = (FontPitchAndFamily.Decorative | FontPitchAndFamily.Swiss)
			});
			MenuSettings.ContainerTextMarkOffset = 8f;
			MenuSettings.ContainerTextOffset = 15f;
			MenuSettings.HoverColor = new ColorBGRA(byte.MaxValue, byte.MaxValue, byte.MaxValue, 50);
			MenuSettings.RootContainerColor = new ColorBGRA(0, 0, 0, 62);
			MenuSettings.TextColor = new ColorBGRA(Color.White.R, Color.White.G, Color.White.B, Color.White.A);
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0002D68B File Offset: 0x0002B88B
		// (set) Token: 0x060007B1 RID: 1969 RVA: 0x0002D692 File Offset: 0x0002B892
		public static int ContainerHeight { get; set; } = 30;

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060007B2 RID: 1970 RVA: 0x0002D69A File Offset: 0x0002B89A
		// (set) Token: 0x060007B3 RID: 1971 RVA: 0x0002D6A1 File Offset: 0x0002B8A1
		public static ColorBGRA ContainerSelectedColor { get; set; } = new ColorBGRA(byte.MaxValue, byte.MaxValue, byte.MaxValue, 125);

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060007B4 RID: 1972 RVA: 0x0002D6A9 File Offset: 0x0002B8A9
		// (set) Token: 0x060007B5 RID: 1973 RVA: 0x0002D6B0 File Offset: 0x0002B8B0
		public static ColorBGRA ContainerSeparatorColor { get; set; } = new ColorBGRA(byte.MaxValue, byte.MaxValue, byte.MaxValue, 100);

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060007B6 RID: 1974 RVA: 0x0002D6B8 File Offset: 0x0002B8B8
		// (set) Token: 0x060007B7 RID: 1975 RVA: 0x0002D6BF File Offset: 0x0002B8BF
		public static float ContainerTextMarkOffset { get; set; }

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060007B8 RID: 1976 RVA: 0x0002D6C7 File Offset: 0x0002B8C7
		// (set) Token: 0x060007B9 RID: 1977 RVA: 0x0002D6CE File Offset: 0x0002B8CE
		public static float ContainerTextMarkWidth { get; set; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060007BA RID: 1978 RVA: 0x0002D6D6 File Offset: 0x0002B8D6
		// (set) Token: 0x060007BB RID: 1979 RVA: 0x0002D6DD File Offset: 0x0002B8DD
		public static float ContainerTextOffset { get; set; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060007BC RID: 1980 RVA: 0x0002D6E5 File Offset: 0x0002B8E5
		// (set) Token: 0x060007BD RID: 1981 RVA: 0x0002D6EC File Offset: 0x0002B8EC
		public static float ContainerWidth { get; set; }

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x0002D6F4 File Offset: 0x0002B8F4
		// (set) Token: 0x060007BF RID: 1983 RVA: 0x0002D6FC File Offset: 0x0002B8FC
		public static FontCache Font
		{
			get
			{
				return MenuSettings.font;
			}
			set
			{
				MenuSettings.font = value;
				RawRectangle rawRectangle = value.MeasureText("»", FontCache.DrawFontFlags.Left);
				MenuSettings.ContainerTextMarkWidth = (float)(rawRectangle.Right - rawRectangle.Left);
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060007C0 RID: 1984 RVA: 0x0002D72F File Offset: 0x0002B92F
		// (set) Token: 0x060007C1 RID: 1985 RVA: 0x0002D736 File Offset: 0x0002B936
		public static ColorBGRA HoverColor { get; set; }

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x0002D73E File Offset: 0x0002B93E
		// (set) Token: 0x060007C3 RID: 1987 RVA: 0x0002D748 File Offset: 0x0002B948
		public static Vector2 Position
		{
			get
			{
				return MenuSettings.position;
			}
			set
			{
				if (MenuCustomizer.Instance != null)
				{
					MenuSettings.position = value;
					MenuCustomizer.Instance.PositionX.Value = (int)MenuSettings.position.X;
					MenuCustomizer.Instance.PositionY.Value = (int)MenuSettings.position.Y;
					return;
				}
				MenuSettings.position = value;
			}
		} = new Vector2(30f, 30f);

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x0002D79D File Offset: 0x0002B99D
		// (set) Token: 0x060007C5 RID: 1989 RVA: 0x0002D7A4 File Offset: 0x0002B9A4
		public static ColorBGRA RootContainerColor { get; set; }

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060007C6 RID: 1990 RVA: 0x0002D7AC File Offset: 0x0002B9AC
		// (set) Token: 0x060007C7 RID: 1991 RVA: 0x0002D7B3 File Offset: 0x0002B9B3
		public static ColorBGRA TextColor { get; set; }

		// Token: 0x0400057F RID: 1407
		private static FontCache font;

		// Token: 0x04000580 RID: 1408
		private static Vector2 position;
	}
}
