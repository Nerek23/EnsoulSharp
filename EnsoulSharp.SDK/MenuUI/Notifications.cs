using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000B0 RID: 176
	public class Notifications
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x00028AC1 File Offset: 0x00026CC1
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x00028AC8 File Offset: 0x00026CC8
		public static Vector2 Position { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00028AD0 File Offset: 0x00026CD0
		// (set) Token: 0x060005F3 RID: 1523 RVA: 0x00028AD7 File Offset: 0x00026CD7
		private static bool EditButtonDown { get; set; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00028ADF File Offset: 0x00026CDF
		private static LineCache Line
		{
			get
			{
				if (Notifications.line != null)
				{
					return Notifications.line;
				}
				return Notifications.line = LineRender.CreateLine(1f, true, false);
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x00028B00 File Offset: 0x00026D00
		// (set) Token: 0x060005F6 RID: 1526 RVA: 0x00028B07 File Offset: 0x00026D07
		private static Menu Menu { get; set; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x00028B0F File Offset: 0x00026D0F
		// (set) Token: 0x060005F8 RID: 1528 RVA: 0x00028B16 File Offset: 0x00026D16
		private static Vector2? MouseLocation { get; set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x00028B1E File Offset: 0x00026D1E
		// (set) Token: 0x060005FA RID: 1530 RVA: 0x00028B25 File Offset: 0x00026D25
		private static float MouseOffsetX { get; set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x00028B2D File Offset: 0x00026D2D
		// (set) Token: 0x060005FC RID: 1532 RVA: 0x00028B34 File Offset: 0x00026D34
		private static float MouseOffsetY { get; set; }

		// Token: 0x060005FD RID: 1533 RVA: 0x00028B3C File Offset: 0x00026D3C
		public static void Add(NotificationItem notification)
		{
			if (!Notifications.NotificationsList.Contains(notification))
			{
				Notifications.NotificationsList.Add(notification);
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00028B58 File Offset: 0x00026D58
		public static void Initialize(Menu menu)
		{
			Notifications.Menu = menu.Add<Menu>(new Menu("Notifications", "Notifications", false));
			Notifications.Menu.Add<MenuBool>(new MenuBool("enabled", "Enabled Notifications", true));
			Notifications.Menu.Add<MenuBool>(new MenuBool("edit", "Edit Position", false));
			Notifications.Menu.Add<MenuButton>(new MenuButton("AddNotify", "Add Test Notify", "Added")).Action = delegate()
			{
				Notifications.Add(new NotificationItem("TestHeader", "TestBody"));
			};
			if (Notifications.Menu["enabled"].GetValue<MenuBool>().Enabled)
			{
				Notifications.isInit = true;
				Notifications.Position = new Vector2((float)Library.GameCache.WindowsValue.WindowsWidth - 5f, 90f);
				GameEvent.OnGameTick += Notifications.OnUpdate;
				Render.OnDraw += Notifications.OnDraw;
				GameEvent.OnGameWndProc += Notifications.OnWndProc;
			}
			Notifications.Menu["enabled"].GetValue<MenuBool>().ValueChanged += delegate(MenuBool menuItem, EventArgs args)
			{
				if (menuItem.Enabled && !Notifications.isInit)
				{
					if (!Notifications.isInit)
					{
						Notifications.Position = new Vector2((float)Library.GameCache.WindowsValue.WindowsWidth - 5f, 90f);
						GameEvent.OnGameTick += Notifications.OnUpdate;
						Render.OnDraw += Notifications.OnDraw;
						GameEvent.OnGameWndProc += Notifications.OnWndProc;
					}
					Notifications.isInit = true;
					return;
				}
				if (!menuItem.Enabled)
				{
					if (Notifications.isInit)
					{
						GameEvent.OnGameTick -= Notifications.OnUpdate;
						Render.OnDraw -= Notifications.OnDraw;
						GameEvent.OnGameWndProc -= Notifications.OnWndProc;
					}
					Notifications.isInit = false;
				}
			};
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00028CA9 File Offset: 0x00026EA9
		public static void Remove(NotificationItem notification)
		{
			if (Notifications.NotificationsList.Contains(notification))
			{
				Notifications.NotificationsList.Remove(notification);
			}
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00028CC4 File Offset: 0x00026EC4
		private static void OnDraw(EventArgs args)
		{
			if (!Notifications.Menu["enabled"].GetValue<MenuBool>().Enabled)
			{
				return;
			}
			float num = Notifications.Position.Y;
			for (int i = 0; i < Notifications.NotificationsList.Count; i++)
			{
				Notifications.NotificationsList[i].OnDraw(new Vector2(Notifications.Position.X, num));
				if (i < Notifications.NotificationsList.Count)
				{
					num += Notifications.NotificationsList[i].GetReservedHeight();
				}
			}
			if (Notifications.Menu["edit"].GetValue<MenuBool>().Enabled)
			{
				NotificationItem notificationItem = (from n in Notifications.NotificationsList
				orderby n.GetReservedWidth() descending
				select n).FirstOrDefault<NotificationItem>();
				float num2 = (notificationItem != null) ? notificationItem.GetReservedWidth() : 300f;
				if (Math.Abs(num - Notifications.Position.Y) < 1E-45f)
				{
					num += 30f;
				}
				Notifications.Line.Draw(new Vector2[]
				{
					new Vector2(Notifications.Position.X - num2 / 2f, Notifications.Position.Y),
					new Vector2(Notifications.Position.X - num2 / 2f, num)
				}, new ColorBGRA(byte.MaxValue, 0, 0, 127), num2);
			}
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00028E38 File Offset: 0x00027038
		private static void OnUpdate(EventArgs args)
		{
			NotificationItem[] array = Notifications.NotificationsList.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnUpdate();
			}
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00028E68 File Offset: 0x00027068
		private static void OnWndProc(GameEvent.WindowndEventArgs args)
		{
			if (!Notifications.Menu["enabled"].GetValue<MenuBool>().Enabled)
			{
				return;
			}
			WindowsKeys windowsKeys = new WindowsKeys(args);
			float num = Notifications.Position.Y;
			bool enabled = Notifications.Menu["edit"].GetValue<MenuBool>().Enabled;
			foreach (NotificationItem notificationItem in Notifications.NotificationsList.ToArray())
			{
				notificationItem.OnWndProc(new Vector2(Notifications.Position.X, num), windowsKeys, enabled);
				num += notificationItem.GetReservedHeight();
			}
			NotificationItem notificationItem2 = (from n in Notifications.NotificationsList
			orderby n.GetReservedWidth() descending
			select n).FirstOrDefault<NotificationItem>();
			float num2 = (notificationItem2 != null) ? notificationItem2.GetReservedWidth() : 300f;
			if (windowsKeys.Msg == WindowsKeyMessages.LBUTTONDOWN || windowsKeys.Msg == WindowsKeyMessages.LBUTTONUP)
			{
				float num3 = Notifications.NotificationsList.Where((NotificationItem t, int i) => i < Notifications.NotificationsList.Count).Sum((NotificationItem t) => t.GetReservedHeight());
				if (Math.Abs(num3) < 1E-45f)
				{
					num3 = 30f;
				}
				bool flag = windowsKeys.Msg == WindowsKeyMessages.LBUTTONDOWN;
				Notifications.EditButtonDown = (flag && windowsKeys.Cursor.IsUnderRectangle(Notifications.Position.X - num2, Notifications.Position.Y, num2, num3));
				if (!flag)
				{
					Notifications.MouseLocation = null;
					Notifications.MouseOffsetX = 0f;
				}
			}
			if (enabled && Notifications.EditButtonDown)
			{
				if (Notifications.MouseLocation != null)
				{
					Notifications.Position += Notifications.MouseLocation.Value - Notifications.Position;
					Notifications.Position = new Vector2(Notifications.Position.X + Notifications.MouseOffsetX, Notifications.Position.Y + Notifications.MouseOffsetY);
				}
				else
				{
					Notifications.MouseOffsetX = Notifications.Position.X - windowsKeys.Cursor.X;
					Notifications.MouseOffsetY = Notifications.Position.Y - windowsKeys.Cursor.Y;
				}
				Notifications.MouseLocation = new Vector2?(windowsKeys.Cursor);
			}
		}

		// Token: 0x04000405 RID: 1029
		internal static readonly List<NotificationItem> NotificationsList = new List<NotificationItem>();

		// Token: 0x04000406 RID: 1030
		private static LineCache line;

		// Token: 0x04000407 RID: 1031
		private static bool isInit;
	}
}
