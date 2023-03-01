using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EnsoulSharp.SDK.Core;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Utility;
using EnsoulSharp.SDK.Utility.MouseActivity;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000B9 RID: 185
	public class Menu : AMenuComponent, IEnumerable
	{
		// Token: 0x06000680 RID: 1664 RVA: 0x0002AC2C File Offset: 0x00028E2C
		public Menu(string name, string displayName, bool root = false) : base(name, displayName)
		{
			base.Root = root;
			base.AssemblyName = (Assembly.GetCallingAssembly().GetName().Name ?? "");
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x0002AC83 File Offset: 0x00028E83
		// (set) Token: 0x06000682 RID: 1666 RVA: 0x0002AC8C File Offset: 0x00028E8C
		public sealed override bool Toggled
		{
			get
			{
				return this.toggled;
			}
			set
			{
				this.toggled = value;
				foreach (KeyValuePair<string, AMenuComponent> keyValuePair in this.Components)
				{
					keyValuePair.Value.ToggleVisible = value;
					if (!this.toggled)
					{
						keyValuePair.Value.Toggled = false;
					}
				}
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x0002AD04 File Offset: 0x00028F04
		// (set) Token: 0x06000684 RID: 1668 RVA: 0x0002AD0C File Offset: 0x00028F0C
		public sealed override bool Visible { get; set; } = true;

		// Token: 0x17000127 RID: 295
		public override AMenuComponent this[string name]
		{
			get
			{
				AMenuComponent result;
				if (!this.Components.TryGetValue(name, out result))
				{
					return null;
				}
				return result;
			}
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0002AD38 File Offset: 0x00028F38
		public void SetLogo(SpriteCache spriteLogo)
		{
			this.HaveLogo = true;
			this.MenuLogo = spriteLogo;
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0002AD48 File Offset: 0x00028F48
		public IEnumerator GetEnumerator()
		{
			return this.Components.GetEnumerator();
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0002AD5C File Offset: 0x00028F5C
		public virtual T Add<T>(T component) where T : AMenuComponent
		{
			if (this.Components.ContainsKey(component.Name))
			{
				Menu menu;
				Menu menu2;
				if ((menu = (this.Components[component.Name] as Menu)) != null && (menu2 = (component as Menu)) != null)
				{
					using (Dictionary<string, AMenuComponent>.Enumerator enumerator = menu2.Components.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<string, AMenuComponent> keyValuePair = enumerator.Current;
							menu.Add<AMenuComponent>(keyValuePair.Value);
						}
						goto IL_FC;
					}
				}
				Console.WriteLine("This menu '" + base.Name + "' already contains a component with the name " + component.Name);
				return component;
			}
			component.Parent = this;
			this.Components[component.Name] = component;
			AMenuComponent amenuComponent = this;
			while (amenuComponent.Parent != null)
			{
				amenuComponent = amenuComponent.Parent;
			}
			if (amenuComponent.Root)
			{
				amenuComponent.Load();
			}
			IL_FC:
			MenuManager.Instance.ResetWidth();
			return component;
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0002AE80 File Offset: 0x00029080
		public Menu Attach()
		{
			if (base.Parent == null && base.Root)
			{
				MenuManager.Instance.Add(this);
				return this;
			}
			Console.WriteLine("You should not add a Menu that already has a parent or is not a Root component. -> {0} - {1}", base.Name, base.DisplayName);
			return this;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0002AEB8 File Offset: 0x000290B8
		public override T GetValue<T>(string name)
		{
			AMenuComponent amenuComponent;
			if (this.Components.TryGetValue(name, out amenuComponent))
			{
				return (T)((object)amenuComponent);
			}
			return default(T);
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0002AEE5 File Offset: 0x000290E5
		public override T GetValue<T>()
		{
			throw new Exception("Cannot get the Value of a Menu");
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0002AEF1 File Offset: 0x000290F1
		public bool Remove(AMenuComponent component)
		{
			if (this.Components.ContainsKey(component.Name))
			{
				component.Save();
				component.Parent = null;
				return this.Components.Remove(component.Name);
			}
			return false;
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x0002AF26 File Offset: 0x00029126
		// (set) Token: 0x0600068E RID: 1678 RVA: 0x0002AF30 File Offset: 0x00029130
		internal sealed override bool ToggleVisible
		{
			get
			{
				return this.toggleVisible;
			}
			set
			{
				this.toggleVisible = value;
				if (this.Toggled)
				{
					foreach (KeyValuePair<string, AMenuComponent> keyValuePair in this.Components)
					{
						keyValuePair.Value.ToggleVisible = value;
					}
				}
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600068F RID: 1679 RVA: 0x0002AF98 File Offset: 0x00029198
		internal string Path
		{
			get
			{
				if (base.Parent == null)
				{
					return System.IO.Path.Combine(Config.ConfigFolder.CreateSubdirectory(base.AssemblyName).FullName, base.Name + ".esconfig");
				}
				return base.Parent.Path;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000690 RID: 1680 RVA: 0x0002AFD8 File Offset: 0x000291D8
		internal override int Width
		{
			get
			{
				return base.Handler.Width();
			}
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0002AFE8 File Offset: 0x000291E8
		internal override void Load()
		{
			if (this.SaveDictionary.Count == 0)
			{
				try
				{
					byte[] arrBytes;
					if (base.Parent == null)
					{
						if (File.Exists(this.Path))
						{
							this.SaveDictionary = MenuUtils.DeserializeMenu<Dictionary<string, byte[]>>(File.ReadAllBytes(this.Path));
						}
					}
					else if (base.Parent.SaveDictionary.Any<KeyValuePair<string, byte[]>>() && base.Parent.SaveDictionary.TryGetValue(base.Name + base.UniqueString, out arrBytes))
					{
						this.SaveDictionary = MenuUtils.DeserializeMenu<Dictionary<string, byte[]>>(arrBytes);
					}
				}
				catch (Exception ex)
				{
					Logging.Write(false, true, "Load")(LogLevel.Error, string.Concat(new object[]
					{
						"Something wrong about the MenuSave Load ",
						base.Name,
						".",
						Environment.NewLine,
						ex
					}), Array.Empty<object>());
				}
			}
			foreach (KeyValuePair<string, AMenuComponent> keyValuePair in this.Components)
			{
				if (!keyValuePair.Value.DontSave)
				{
					keyValuePair.Value.Load();
				}
			}
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0002B128 File Offset: 0x00029328
		internal override void Save()
		{
			foreach (KeyValuePair<string, AMenuComponent> keyValuePair in this.Components)
			{
				if (!keyValuePair.Value.DontSave)
				{
					keyValuePair.Value.Save();
				}
			}
			if (base.Parent == null)
			{
				File.WriteAllBytes(this.Path, MenuUtils.SerializeMenuItem(this.SaveDictionary));
				return;
			}
			base.Parent.SaveDictionary[base.Name + base.UniqueString] = MenuUtils.SerializeMenuItem(this.SaveDictionary);
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0002B1DC File Offset: 0x000293DC
		internal override void OnDraw(Vector2 position)
		{
			base.Position = position;
			base.Handler.Draw();
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0002B1F0 File Offset: 0x000293F0
		internal override void OnWndProc(WindowsKeys args)
		{
			base.Handler.OnWndProc(args);
			foreach (KeyValuePair<string, AMenuComponent> keyValuePair in this.Components)
			{
				keyValuePair.Value.OnWndProc(args);
			}
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0002B258 File Offset: 0x00029458
		internal override void OnWndProc(SingleMouseEventArgs args)
		{
			if (Library.GameCache.IsRiot)
			{
				return;
			}
			base.Handler.OnWndProc(args);
			foreach (KeyValuePair<string, AMenuComponent> keyValuePair in this.Components)
			{
				keyValuePair.Value.OnWndProc(args);
			}
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0002B2CC File Offset: 0x000294CC
		internal override void ResetWidth()
		{
			base.ResetWidth();
			foreach (KeyValuePair<string, AMenuComponent> keyValuePair in this.Components)
			{
				keyValuePair.Value.ResetWidth();
			}
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0002B32C File Offset: 0x0002952C
		public override void RestoreDefault()
		{
			foreach (KeyValuePair<string, AMenuComponent> keyValuePair in this.Components)
			{
				keyValuePair.Value.RestoreDefault();
			}
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0002B384 File Offset: 0x00029584
		internal void Toggle()
		{
			if (this.Components.Count > 0)
			{
				this.Toggled = !this.Toggled;
				if (base.Parent == null)
				{
					using (IEnumerator<Menu> enumerator = (from c in MenuManager.Instance.Menus
					where !c.Equals(this)
					select c).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							Menu menu = enumerator.Current;
							menu.Toggled = false;
						}
						return;
					}
				}
				foreach (KeyValuePair<string, AMenuComponent> keyValuePair in from comp in base.Parent.Components
				where comp.Value.Name != base.Name
				select comp)
				{
					keyValuePair.Value.Toggled = false;
				}
			}
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0002B464 File Offset: 0x00029664
		internal override ADrawable BuildHandler(ITheme theme)
		{
			return theme.BuildMenuHandler(this);
		}

		// Token: 0x0400053C RID: 1340
		private bool toggled;

		// Token: 0x0400053D RID: 1341
		private bool toggleVisible;

		// Token: 0x0400053E RID: 1342
		internal bool HaveLogo;

		// Token: 0x0400053F RID: 1343
		internal SpriteCache MenuLogo;

		// Token: 0x04000540 RID: 1344
		internal Dictionary<string, byte[]> SaveDictionary = new Dictionary<string, byte[]>();

		// Token: 0x04000541 RID: 1345
		public Dictionary<string, AMenuComponent> Components = new Dictionary<string, AMenuComponent>();
	}
}
