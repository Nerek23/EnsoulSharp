using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000AA RID: 170
	internal static class PermashowUtility
	{
		// Token: 0x060005E8 RID: 1512 RVA: 0x00028784 File Offset: 0x00026984
		public static void DrawBox(Vector2 pos, bool isEnabled)
		{
			RectangleRender.Draw(new Vector2(pos.X, pos.Y), PermashowUtility.SmallBoxWidth, (float)PermashowUtility.Text.FontDescription.Height * 1.4f, 0f, isEnabled ? PermashowUtility.DarkGreen : PermashowUtility.DarkRed, isEnabled ? PermashowUtility.DarkGreen : PermashowUtility.DarkRed);
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x000287F0 File Offset: 0x000269F0
		public static void UpdateAllIndex()
		{
			int num = 0;
			using (List<PermashowItem>.Enumerator enumerator = (from x in PermashowUtility.AllPermashows
			orderby x.Index
			select x).ToList<PermashowItem>().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PermashowItem permashow = enumerator.Current;
					if (PermashowUtility.AllPermashows.Find((PermashowItem x) => x.Item == permashow.Item) != null)
					{
						permashow.Index = num;
						num++;
					}
				}
			}
			PermaShow.Index = num;
			foreach (PermashowItem permashowItem in PermashowUtility.AllPermashows)
			{
				permashowItem.UpdatePosition();
			}
		}

		// Token: 0x04000326 RID: 806
		public static float XFactor;

		// Token: 0x04000327 RID: 807
		public static float HalfPermashowWidth;

		// Token: 0x04000328 RID: 808
		public static float PermashowWidth;

		// Token: 0x04000329 RID: 809
		public static float SmallBoxWidth;

		// Token: 0x0400032A RID: 810
		public static float DrawBoxWidth;

		// Token: 0x0400032B RID: 811
		public static Vector2 BoxPosition;

		// Token: 0x0400032C RID: 812
		public static Vector2 DrawBasicPosition;

		// Token: 0x0400032D RID: 813
		public static FontCache Text;

		// Token: 0x0400032E RID: 814
		public static readonly ColorBGRA Black = new ColorBGRA((float)Color.Black.R, (float)Color.Black.G, (float)Color.Black.B, 0.4f);

		// Token: 0x0400032F RID: 815
		public static readonly List<PermashowItem> AllPermashows = new List<PermashowItem>();

		// Token: 0x04000330 RID: 816
		private static readonly ColorBGRA DarkGreen = new ColorBGRA(Color.DarkGreen.R, Color.DarkGreen.G, Color.DarkGreen.B, 150);

		// Token: 0x04000331 RID: 817
		private static readonly ColorBGRA DarkRed = new ColorBGRA(Color.DarkRed.R, Color.DarkRed.G, Color.DarkRed.B, 150);
	}
}
