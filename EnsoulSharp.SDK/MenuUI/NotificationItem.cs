using System;
using System.Collections.Generic;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utils;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000A8 RID: 168
	public class NotificationItem
	{
		// Token: 0x060005B9 RID: 1465 RVA: 0x00027A2C File Offset: 0x00025C2C
		public NotificationItem(string header, string body)
		{
			this.Header = header;
			this.Body = body;
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x00027AD0 File Offset: 0x00025CD0
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x00027AD8 File Offset: 0x00025CD8
		public ColorBGRA ActiveIconColor { get; set; } = Color.White;

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x00027AE1 File Offset: 0x00025CE1
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x00027AE9 File Offset: 0x00025CE9
		public string Body
		{
			get
			{
				return this.body;
			}
			set
			{
				this.LinesList = this.FormatText(value, true);
				this.body = (string.IsNullOrEmpty(value) ? " " : value);
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x00027B0F File Offset: 0x00025D0F
		// (set) Token: 0x060005BF RID: 1471 RVA: 0x00027B17 File Offset: 0x00025D17
		public ColorBGRA BodyTextColor { get; set; } = Color.White;

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00027B20 File Offset: 0x00025D20
		// (set) Token: 0x060005C1 RID: 1473 RVA: 0x00027B28 File Offset: 0x00025D28
		public string Header
		{
			get
			{
				return this.header;
			}
			set
			{
				RawRectangle rawRectangle = NotificationUtility.HeaderFont.MeasureText(value, FontCache.DrawFontFlags.Left);
				if (rawRectangle.Right - rawRectangle.Left > 250)
				{
					string value2 = null;
					for (int i = value.Length; i > 0; i--)
					{
						RawRectangle rawRectangle2 = NotificationUtility.HeaderFont.MeasureText(value.Substring(0, i) + "...", FontCache.DrawFontFlags.Left);
						if (rawRectangle2.Right - rawRectangle2.Left <= 250)
						{
							value2 = value.Substring(0, i) + "...";
							break;
						}
					}
					if (!string.IsNullOrEmpty(value2))
					{
						this.header = value2;
						return;
					}
				}
				this.header = (string.IsNullOrEmpty(value) ? " " : LanguageTranslate.Translation(value));
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x00027BDB File Offset: 0x00025DDB
		// (set) Token: 0x060005C3 RID: 1475 RVA: 0x00027BE3 File Offset: 0x00025DE3
		public float HeaderHeight { get; set; } = 30f;

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x00027BEC File Offset: 0x00025DEC
		// (set) Token: 0x060005C5 RID: 1477 RVA: 0x00027BF4 File Offset: 0x00025DF4
		public ColorBGRA HeaderTextColor { get; set; } = Color.Gold;

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00027BFD File Offset: 0x00025DFD
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x00027C05 File Offset: 0x00025E05
		public NotificationIconType Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				this.icon = value;
				this.IconTexture = NotificationUtility.GetIcon(value);
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x00027C1A File Offset: 0x00025E1A
		// (set) Token: 0x060005C9 RID: 1481 RVA: 0x00027C22 File Offset: 0x00025E22
		public ColorBGRA IconColor { get; set; } = Color.White;

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x00027C2B File Offset: 0x00025E2B
		// (set) Token: 0x060005CB RID: 1483 RVA: 0x00027C33 File Offset: 0x00025E33
		public bool IconFlash
		{
			get
			{
				return this.iconFlash;
			}
			set
			{
				this.iconFlash = value;
				if (!value)
				{
					this.ActiveIconColor = this.IconColor;
				}
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x00027C4B File Offset: 0x00025E4B
		// (set) Token: 0x060005CD RID: 1485 RVA: 0x00027C53 File Offset: 0x00025E53
		public float IconOffset { get; set; } = 33f;

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x00027C5C File Offset: 0x00025E5C
		// (set) Token: 0x060005CF RID: 1487 RVA: 0x00027C64 File Offset: 0x00025E64
		public bool IsOpen { get; set; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x00027C6D File Offset: 0x00025E6D
		// (set) Token: 0x060005D1 RID: 1489 RVA: 0x00027C75 File Offset: 0x00025E75
		public bool IsVisible { get; set; } = true;

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x00027C7E File Offset: 0x00025E7E
		// (set) Token: 0x060005D3 RID: 1491 RVA: 0x00027C86 File Offset: 0x00025E86
		public List<string> LinesList { get; set; } = new List<string>();

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00027C8F File Offset: 0x00025E8F
		// (set) Token: 0x060005D5 RID: 1493 RVA: 0x00027C97 File Offset: 0x00025E97
		public ColorBGRA SecondIconColor { get; set; } = Color.White;

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00027CA0 File Offset: 0x00025EA0
		public float Width
		{
			get
			{
				return 300f;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x00027CA7 File Offset: 0x00025EA7
		// (set) Token: 0x060005D8 RID: 1496 RVA: 0x00027CAF File Offset: 0x00025EAF
		private float BodyHeight { get; set; } = 60f;

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x00027CB8 File Offset: 0x00025EB8
		// (set) Token: 0x060005DA RID: 1498 RVA: 0x00027CC0 File Offset: 0x00025EC0
		private float DrawBodyHeight { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x00027CC9 File Offset: 0x00025EC9
		// (set) Token: 0x060005DC RID: 1500 RVA: 0x00027CD1 File Offset: 0x00025ED1
		private SpriteCache IconTexture { get; set; }

		// Token: 0x060005DD RID: 1501 RVA: 0x00027CDC File Offset: 0x00025EDC
		public List<string> FormatText(string value, bool htmlSupport)
		{
			RawRectangle rawRectangle = NotificationUtility.BodyFont.MeasureText(value, FontCache.DrawFontFlags.Left);
			int num = (rawRectangle.Right - rawRectangle.Left) / 283 + 1;
			int num2 = 0;
			bool flag = false;
			List<string> list = new List<string>();
			if (value.Contains("</br>") && htmlSupport)
			{
				num = 0;
				List<string> list2 = new List<string>();
				string text = value;
				while (text.Contains("</br>"))
				{
					string text2 = text.Substring(0, text.IndexOf("</br>", StringComparison.Ordinal));
					num++;
					list2.Add((!string.IsNullOrEmpty(text2)) ? text2 : string.Empty);
					text = text.Substring(text.IndexOf("</br>", StringComparison.Ordinal) + 5, text.Length - text.IndexOf("</br>", StringComparison.Ordinal) - 5);
				}
				list2.Add(string.IsNullOrEmpty(text) ? " " : text);
				this.BodyHeight += (float)NotificationUtility.BodyFont.FontDescription.Height;
				foreach (string text3 in list2)
				{
					if (string.IsNullOrEmpty(text3))
					{
						list.Add(" ");
						this.BodyHeight += (float)NotificationUtility.BodyFont.FontDescription.Height;
					}
					else
					{
						for (int i = text3.Length; i > -1; i--)
						{
							RawRectangle rawRectangle2 = NotificationUtility.BodyFont.MeasureText(text3.Substring(num2, text3.Length - num2 - i), FontCache.DrawFontFlags.Left);
							if (i - 1 <= -1 || text3.Length - num2 - i < 0 || rawRectangle2.Right - rawRectangle2.Left >= 283)
							{
								string text4 = text3.Substring(num2, text3.Length - num2 - i);
								if (!string.IsNullOrEmpty(text4))
								{
									list.Add(text4);
								}
								num2 = text3.Length - i;
							}
						}
						num2 = 0;
					}
				}
				flag = true;
			}
			if (!flag)
			{
				for (int j = value.Length; j > -1; j--)
				{
					RawRectangle rawRectangle3 = NotificationUtility.BodyFont.MeasureText(value.Substring(num2, value.Length - num2 - j), FontCache.DrawFontFlags.Left);
					if (j - 1 <= -1 || value.Length - num2 - j < 0 || rawRectangle3.Right - rawRectangle3.Left >= 283)
					{
						string text5 = value.Substring(num2, value.Length - num2 - j);
						if (!string.IsNullOrEmpty(text5))
						{
							list.Add(text5);
						}
						num2 = value.Length - j;
					}
				}
			}
			if (num > 4)
			{
				this.BodyHeight += (float)(NotificationUtility.BodyFont.FontDescription.Height * (num - 4));
			}
			return list;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00027FBC File Offset: 0x000261BC
		public float GetReservedHeight()
		{
			return this.HeaderHeight + this.DrawBodyHeight;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00027FCB File Offset: 0x000261CB
		public float GetReservedWidth()
		{
			return this.Width;
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00027FD4 File Offset: 0x000261D4
		public void OnDraw(Vector2 basePosition)
		{
			if (this.IsVisible)
			{
				basePosition.X += this.hideOffsetX;
				NotificationUtility.Line.Draw(new Vector2[]
				{
					new Vector2(basePosition.X - this.Width / 2f, basePosition.Y),
					new Vector2(basePosition.X - this.Width / 2f, basePosition.Y + this.HeaderHeight)
				}, new ColorBGRA(0, 0, 0, 127), 0f);
				if (this.IsOpen || this.DrawBodyHeight > 0f)
				{
					NotificationUtility.Line.Draw(new Vector2[]
					{
						new Vector2(basePosition.X - this.Width / 2f, basePosition.Y + this.HeaderHeight),
						new Vector2(basePosition.X - this.Width / 2f, basePosition.Y + this.HeaderHeight + this.DrawBodyHeight)
					}, new ColorBGRA(0, 0, 0, 170), 0f);
				}
				NotificationUtility.HeaderFont.Draw(this.Header, this.GetHeaderRectangle(basePosition), FontCache.DrawFontFlags.Left, this.HeaderTextColor, null);
				Rectangle bodyRectangle = this.GetBodyRectangle(basePosition);
				if (this.IsOpen || bodyRectangle.Height > 0)
				{
					for (int i = 0; i < this.LinesList.Count; i++)
					{
						Rectangle rectangle = bodyRectangle;
						rectangle.Y += NotificationUtility.BodyFont.FontDescription.Height * i;
						rectangle.Height -= NotificationUtility.BodyFont.FontDescription.Height * i;
						NotificationUtility.BodyFont.Draw(this.LinesList[i], rectangle, FontCache.DrawFontFlags.Left, this.BodyTextColor, null);
					}
					NotificationUtility.ArrowIcon.Scale = new Vector2(0.7f, 0.7f);
					NotificationUtility.ArrowIcon.Color = Color.White;
					NotificationUtility.ArrowIcon.Draw(basePosition.X - this.Width + 5f, basePosition.Y + this.HeaderHeight + this.BodyHeight + 1.5f);
				}
				if (this.Icon != NotificationIconType.None && this.IconTexture != null)
				{
					this.IconTexture.Color = this.IconColor;
					this.IconTexture.Draw(basePosition.X - this.IconOffset, basePosition.Y + 0.5f);
				}
			}
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x00028274 File Offset: 0x00026474
		public void OnUpdate()
		{
			if (Variables.GameTimeTickCount - this.animationTick > 3)
			{
				if ((this.IsOpen && this.DrawBodyHeight <= this.BodyHeight && !this.hideAnimation) || (!this.IsOpen && this.DrawBodyHeight > 0f))
				{
					this.DrawBodyHeight += (float)(this.IsOpen ? 1 : -1);
				}
				if (this.hideAnimation && this.hideOffsetX < this.Width + 5f)
				{
					this.hideOffsetX += 1f;
				}
				if (this.hideAnimation && this.hideOffsetX >= this.Width + 5f)
				{
					if (this.HeaderHeight > 0f && this.DrawBodyHeight <= 0f)
					{
						float num = this.HeaderHeight;
						this.HeaderHeight = num - 1f;
					}
					if (this.DrawBodyHeight > 0f)
					{
						float num = this.DrawBodyHeight;
						this.DrawBodyHeight = num - 1f;
					}
					if (this.DrawBodyHeight <= 0f && this.HeaderHeight <= 0f)
					{
						Notifications.Remove(this);
					}
				}
				this.animationTick = Variables.GameTimeTickCount;
			}
			if (Variables.GameTimeTickCount - this.iconColorTick > 400 && this.IconFlash)
			{
				this.IconColor = ((this.ActiveIconColor == this.IconColor) ? this.SecondIconColor : this.IconColor);
				this.iconColorTick = Variables.GameTimeTickCount;
			}
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x000283F4 File Offset: 0x000265F4
		public void OnWndProc(Vector2 basePosition, WindowsKeys windowsKeys, bool isEdit)
		{
			basePosition.X += this.hideOffsetX;
			if (!isEdit)
			{
				if (windowsKeys.Msg == WindowsKeyMessages.LBUTTONDOWN && windowsKeys.Cursor.IsUnderRectangle(basePosition.X - this.Width - 5f, basePosition.Y, this.Width, this.HeaderHeight))
				{
					windowsKeys.Process = false;
					this.IsOpen = !this.IsOpen;
				}
				if (windowsKeys.Msg == WindowsKeyMessages.LBUTTONDOWN && windowsKeys.Cursor.IsUnderRectangle(basePosition.X - this.Width + 5f, basePosition.Y + this.HeaderHeight + this.BodyHeight + 1.5f, NotificationUtility.ArrowIcon.Width - 3f, NotificationUtility.ArrowIcon.Height * 0.7f) && this.DrawBodyHeight >= this.BodyHeight)
				{
					windowsKeys.Process = false;
					this.hideAnimation = !this.hideAnimation;
				}
			}
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x000284F8 File Offset: 0x000266F8
		private Rectangle GetBodyRectangle(Vector2 basePosition)
		{
			int num = (int)(basePosition.X - this.Width / 2f - 144f);
			float num2 = basePosition.Y + this.HeaderHeight + 2f;
			return new Rectangle(num, (int)num2, (int)this.Width, (int)this.DrawBodyHeight);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00028548 File Offset: 0x00026748
		private Rectangle GetHeaderRectangle(Vector2 basePosition)
		{
			int num = (int)(basePosition.X - this.Width / 2f - 140f);
			float num2 = basePosition.Y + new Rectangle(0, 0, 0, (int)this.HeaderHeight).GetCenteredText(this.Header, CenteredFlags.VerticalCenter).Y;
			return new Rectangle(num, (int)num2, (int)this.Width, (int)this.HeaderHeight);
		}

		// Token: 0x0400030A RID: 778
		private int animationTick;

		// Token: 0x0400030B RID: 779
		private int iconColorTick;

		// Token: 0x0400030C RID: 780
		private float hideOffsetX;

		// Token: 0x0400030D RID: 781
		private bool hideAnimation;

		// Token: 0x0400030E RID: 782
		private bool iconFlash;

		// Token: 0x0400030F RID: 783
		private string body;

		// Token: 0x04000310 RID: 784
		private string header;

		// Token: 0x04000311 RID: 785
		private NotificationIconType icon;
	}
}
