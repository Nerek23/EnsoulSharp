using System;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utils;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000B2 RID: 178
	internal class PermashowItem
	{
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600060C RID: 1548 RVA: 0x000299E4 File Offset: 0x00027BE4
		// (set) Token: 0x0600060D RID: 1549 RVA: 0x000299EC File Offset: 0x00027BEC
		public int Index { get; set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600060E RID: 1550 RVA: 0x000299F5 File Offset: 0x00027BF5
		// (set) Token: 0x0600060F RID: 1551 RVA: 0x000299FD File Offset: 0x00027BFD
		public string DisplayName { get; set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000610 RID: 1552 RVA: 0x00029A06 File Offset: 0x00027C06
		// (set) Token: 0x06000611 RID: 1553 RVA: 0x00029A0E File Offset: 0x00027C0E
		public ColorBGRA Color { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x00029A17 File Offset: 0x00027C17
		// (set) Token: 0x06000613 RID: 1555 RVA: 0x00029A1F File Offset: 0x00027C1F
		public MenuItem Item { get; set; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x00029A28 File Offset: 0x00027C28
		// (set) Token: 0x06000615 RID: 1557 RVA: 0x00029A30 File Offset: 0x00027C30
		public MenuValueType ItemType { get; set; }

		// Token: 0x06000616 RID: 1558 RVA: 0x00029A3C File Offset: 0x00027C3C
		public PermashowItem(int index, MenuItem menuItem, MenuValueType menuItemType, string customName = "", Color? color = null)
		{
			this.Index = index;
			this.Item = menuItem;
			this.ItemType = menuItemType;
			this.DisplayName = (string.IsNullOrEmpty(customName) ? (string.IsNullOrEmpty(menuItem.PermasShowText) ? LanguageTranslate.Translation(menuItem.DisplayName) : LanguageTranslate.Translation(menuItem.PermasShowText)) : LanguageTranslate.Translation(customName));
			this.Color = (color ?? new ColorBGRA(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
			this.UpdateValue();
			this.UpdatePosition();
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00029AEC File Offset: 0x00027CEC
		private void UpdateValue()
		{
			if (this.ItemType == MenuValueType.Boolean)
			{
				MenuBool menuBool = (MenuBool)this.Item;
				this.BoxEnabled = menuBool.Enabled;
				this.BoxEnabledText = LanguageTranslate.Translation(this.BoxEnabled.ToString());
				menuBool.ValueChanged += delegate(MenuBool menuItem, EventArgs args)
				{
					this.BoxEnabled = menuItem.Enabled;
					this.BoxEnabledText = LanguageTranslate.Translation(this.BoxEnabled.ToString());
				};
				return;
			}
			if (this.ItemType == MenuValueType.KeyBind)
			{
				MenuKeyBind menuKeyBind = (MenuKeyBind)this.Item;
				this.BoxEnabled = menuKeyBind.Active;
				this.BoxText = menuKeyBind.Key.ToString();
				this.BoxEnabledText = LanguageTranslate.Translation(this.BoxEnabled.ToString());
				menuKeyBind.ValueChanged += delegate(MenuKeyBind menuItem, EventArgs args)
				{
					this.BoxEnabled = menuItem.Active;
					this.BoxText = menuItem.Key.ToString();
					this.BoxEnabledText = LanguageTranslate.Translation(this.BoxEnabled.ToString());
				};
				return;
			}
			if (this.ItemType == MenuValueType.List)
			{
				MenuList menuList = (MenuList)this.Item;
				this.BoxText = LanguageTranslate.Translation(menuList.SelectedValue);
				menuList.ValueChanged += delegate(MenuList menuItem, EventArgs args)
				{
					this.BoxText = LanguageTranslate.Translation(menuItem.SelectedValue);
				};
				return;
			}
			if (this.ItemType == MenuValueType.Slider)
			{
				MenuSlider menuSlider = (MenuSlider)this.Item;
				this.BoxText = menuSlider.Value + "  ";
				menuSlider.ValueChanged += delegate(MenuSlider menuItem, EventArgs args)
				{
					this.BoxText = menuItem.Value + "  ";
				};
				return;
			}
			if (this.ItemType == MenuValueType.SliderButton)
			{
				MenuSliderButton menuSliderButton = (MenuSliderButton)this.Item;
				this.BoxEnabled = menuSliderButton.Enabled;
				this.BoxEnabledText = LanguageTranslate.Translation(this.BoxEnabled.ToString());
				this.BoxText = menuSliderButton.Value + "  ";
				menuSliderButton.ValueChanged += delegate(MenuSliderButton menuItem, EventArgs args)
				{
					this.BoxEnabled = menuItem.Enabled;
					this.BoxText = menuItem.Value + "  ";
					this.BoxEnabledText = LanguageTranslate.Translation(this.BoxEnabled.ToString());
				};
			}
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00029C90 File Offset: 0x00027E90
		public void UpdatePosition()
		{
			this.BoxPosition = new Vector2(PermashowUtility.DrawBoxWidth, PermashowUtility.DrawBasicPosition.Y + (float)PermashowUtility.Text.FontDescription.Height * 1.4f * (float)this.Index);
			this.EndPosition = new Vector2(PermashowUtility.BoxPosition.X + PermashowUtility.PermashowWidth / 2f, PermashowUtility.DrawBasicPosition.Y + (float)PermashowUtility.Text.FontDescription.Height * 1.4f * (float)this.Index);
			this.ItemPosition = new Vector2(PermashowUtility.DrawBasicPosition.X, PermashowUtility.DrawBasicPosition.Y + (float)PermashowUtility.Text.FontDescription.Height * 1.4f * (float)this.Index + (float)PermashowUtility.Text.FontDescription.Height * 0.2f);
			this.FullRectangle = new RawRectangle((int)this.ItemPosition.X, (int)this.ItemPosition.Y, (int)this.EndPosition.X, (int)(this.BoxPosition.Y + (float)PermashowUtility.Text.FontDescription.Height * 1.4f));
			this.BoxRectangle = new RawRectangle((int)(this.BoxPosition.X - PermashowUtility.SmallBoxWidth / 2f), (int)this.BoxPosition.Y, (int)(this.EndPosition.X + PermashowUtility.SmallBoxWidth / 2f), (int)(this.BoxPosition.Y + (float)PermashowUtility.Text.FontDescription.Height * 1.4f));
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00029E34 File Offset: 0x00028034
		public void Draw()
		{
			if (this.ItemType == MenuValueType.Boolean)
			{
				PermashowUtility.DrawBox(this.BoxPosition, this.BoxEnabled);
				PermashowUtility.Text.Draw(this.DisplayName + ":", this.FullRectangle, FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
				PermashowUtility.Text.Draw(this.BoxEnabledText, this.BoxRectangle, FontCache.DrawFontFlags.Center | FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
				return;
			}
			if (this.ItemType == MenuValueType.KeyBind)
			{
				PermashowUtility.DrawBox(this.BoxPosition, this.BoxEnabled);
				PermashowUtility.Text.Draw(this.DisplayName + " [" + this.BoxText + "]:", this.FullRectangle, FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
				PermashowUtility.Text.Draw(this.BoxEnabledText, this.BoxRectangle, FontCache.DrawFontFlags.Center | FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
				return;
			}
			if (this.ItemType == MenuValueType.List)
			{
				PermashowUtility.Text.Draw(this.DisplayName + ":", this.FullRectangle, FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
				PermashowUtility.Text.Draw(this.BoxText, this.BoxRectangle, FontCache.DrawFontFlags.Center | FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
				return;
			}
			if (this.ItemType == MenuValueType.Slider)
			{
				PermashowUtility.Text.Draw(this.DisplayName + ":", this.FullRectangle, FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
				PermashowUtility.Text.Draw(this.BoxText, this.BoxRectangle, FontCache.DrawFontFlags.Center | FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
				return;
			}
			if (this.ItemType == MenuValueType.SliderButton)
			{
				PermashowUtility.DrawBox(this.BoxPosition, this.BoxEnabled);
				PermashowUtility.Text.Draw(this.DisplayName + ":", this.FullRectangle, FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
				PermashowUtility.Text.Draw(this.BoxText, this.BoxRectangle, FontCache.DrawFontFlags.Center | FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
				return;
			}
			if (this.ItemType == MenuValueType.Separator)
			{
				PermashowUtility.Text.Draw(this.DisplayName, this.FullRectangle, FontCache.DrawFontFlags.Center | FontCache.DrawFontFlags.VerticalCenter, this.Color, null);
			}
		}

		// Token: 0x04000410 RID: 1040
		private bool BoxEnabled;

		// Token: 0x04000411 RID: 1041
		private string BoxText;

		// Token: 0x04000412 RID: 1042
		private string BoxEnabledText;

		// Token: 0x04000413 RID: 1043
		private Vector2 BoxPosition;

		// Token: 0x04000414 RID: 1044
		private Vector2 EndPosition;

		// Token: 0x04000415 RID: 1045
		private Vector2 ItemPosition;

		// Token: 0x04000416 RID: 1046
		private RawRectangle BoxRectangle;

		// Token: 0x04000417 RID: 1047
		private RawRectangle FullRectangle;
	}
}
