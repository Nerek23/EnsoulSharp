using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EnsoulSharp.SDK.Properties;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;
using SharpDX.Direct3D9;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000A9 RID: 169
	internal static class NotificationUtility
	{
		// Token: 0x060005E5 RID: 1509 RVA: 0x000285B0 File Offset: 0x000267B0
		static NotificationUtility()
		{
			foreach (KeyValuePair<NotificationIconType, Bitmap> keyValuePair in from bitmap in NotificationUtility.IconBitmaps
			where !NotificationUtility.IconTextures.ContainsKey(bitmap.Key)
			select bitmap)
			{
				SpriteCache value = SpriteRender.CreateSprite(keyValuePair.Value, default(Vector2));
				NotificationUtility.IconTextures.Add(keyValuePair.Key, value);
			}
			NotificationUtility.BodyFont = TextRender.CreateFont(new FontCache.DrawFontDescription
			{
				Height = 13,
				Width = 0,
				Weight = FontCache.DrawFontWeight.DoNotCare,
				MipLevels = 5,
				Italic = false,
				CharacterSet = FontCharacterSet.Default,
				OutputPrecision = FontPrecision.Character,
				Quality = FontQuality.Antialiased,
				PitchAndFamily = (FontPitchAndFamily.Decorative | FontPitchAndFamily.Mono),
				FaceName = "Tahoma"
			});
			NotificationUtility.HeaderFont = TextRender.CreateFont(new FontCache.DrawFontDescription
			{
				Height = 16,
				Width = 0,
				Weight = FontCache.DrawFontWeight.Bold,
				MipLevels = 5,
				Italic = false,
				CharacterSet = FontCharacterSet.Default,
				OutputPrecision = FontPrecision.Character,
				Quality = FontQuality.Antialiased,
				PitchAndFamily = (FontPitchAndFamily.Decorative | FontPitchAndFamily.Mono),
				FaceName = "Tahoma"
			});
			NotificationUtility.Line = LineRender.CreateLine(300f, true, true);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0002875C File Offset: 0x0002695C
		public static SpriteCache GetIcon(NotificationIconType iconType)
		{
			SpriteCache result;
			if (!NotificationUtility.IconTextures.TryGetValue(iconType, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0002877B File Offset: 0x0002697B
		public static SpriteCache ArrowIcon
		{
			get
			{
				return NotificationUtility.GetIcon(NotificationIconType.Arrow);
			}
		}

		// Token: 0x0400031F RID: 799
		public static FontCache BodyFont;

		// Token: 0x04000320 RID: 800
		public static FontCache HeaderFont;

		// Token: 0x04000321 RID: 801
		public static LineCache Line;

		// Token: 0x04000322 RID: 802
		public const int MaximumBodyLineLength = 283;

		// Token: 0x04000323 RID: 803
		public const int MaximumHeaderLineLength = 250;

		// Token: 0x04000324 RID: 804
		private static readonly Dictionary<NotificationIconType, Bitmap> IconBitmaps = new Dictionary<NotificationIconType, Bitmap>
		{
			{
				NotificationIconType.Error,
				Resources.notifications_error
			},
			{
				NotificationIconType.Warning,
				Resources.notifications_warning
			},
			{
				NotificationIconType.Check,
				Resources.notifications_check
			},
			{
				NotificationIconType.Select,
				Resources.notifications_select
			},
			{
				NotificationIconType.Arrow,
				Resources.notifications_arrow
			}
		};

		// Token: 0x04000325 RID: 805
		private static readonly Dictionary<NotificationIconType, SpriteCache> IconTextures = new Dictionary<NotificationIconType, SpriteCache>();
	}
}
