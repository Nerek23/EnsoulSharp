using System;
using SharpDX;

namespace EnsoulSharp.SDK.Utils
{
	// Token: 0x0200005C RID: 92
	internal class Cursor
	{
		// Token: 0x060003A7 RID: 935 RVA: 0x0001A0CB File Offset: 0x000182CB
		static Cursor()
		{
			Game.OnWndProc += Cursor.OnWndProc;
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x0001A0F2 File Offset: 0x000182F2
		public static Vector2 Position
		{
			get
			{
				Cursor.CachePoint.X = (float)Cursor.posX;
				Cursor.CachePoint.Y = (float)Cursor.posY;
				return Cursor.CachePoint;
			}
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0001A119 File Offset: 0x00018319
		internal static void SetCursorPosition(int x, int y)
		{
			Cursor.posX = x;
			Cursor.posY = y;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0001A127 File Offset: 0x00018327
		private static void OnWndProc(GameWndEventArgs args)
		{
			if (!Library.GameCache.IsRiot)
			{
				return;
			}
			if (args.Msg == 512U)
			{
				Cursor.posX = (int)((short)args.LParam);
				Cursor.posY = (int)((short)((long)args.LParam >> 16));
			}
		}

		// Token: 0x040001F8 RID: 504
		private static int posX;

		// Token: 0x040001F9 RID: 505
		private static int posY;

		// Token: 0x040001FA RID: 506
		private static Vector2 CachePoint = new Vector2(0f, 0f);
	}
}
