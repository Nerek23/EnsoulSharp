using System;
using System.IO;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;

namespace EnsoulSharp.SDK.Core
{
	// Token: 0x0200005E RID: 94
	public static class Config
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x0001A392 File Offset: 0x00018592
		public static string LogDirectory
		{
			get
			{
				return Config.SandboxConfig.LogDirectory;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x0001A39E File Offset: 0x0001859E
		public static DirectoryInfo ConfigFolder
		{
			get
			{
				return Directory.CreateDirectory(Config.SandboxConfig.ConfigDirectory);
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x0001A3AF File Offset: 0x000185AF
		public static DirectoryInfo ImageFolder
		{
			get
			{
				return Directory.CreateDirectory(Config.SandboxConfig.ConfigDirectory.Replace("Configurations", "Images"));
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x0001A3CF File Offset: 0x000185CF
		public static string Language
		{
			get
			{
				return Config.SandboxConfig.Language;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x0001A3DB File Offset: 0x000185DB
		public static int MenuKey
		{
			get
			{
				return Config.SandboxConfig.ShowMenuPressKey;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x0001A3E7 File Offset: 0x000185E7
		public static int MenuToggleKey
		{
			get
			{
				return Config.SandboxConfig.ShowMenuToggleKey;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x0001A3F3 File Offset: 0x000185F3
		internal static FontCache EnsoulSharpFont
		{
			get
			{
				if (Config.ensoulSharpFont != null)
				{
					return Config.ensoulSharpFont;
				}
				return Config.ensoulSharpFont = TextRender.CreateFont(new FontCache.DrawFontDescription
				{
					Height = 16,
					FaceName = "Tahoma",
					Weight = FontCache.DrawFontWeight.DoNotCare
				});
			}
		}

		// Token: 0x040001FF RID: 511
		internal static BootstrapConfig SandboxConfig;

		// Token: 0x04000200 RID: 512
		internal static readonly string LogFileName = DateTime.Now.ToString("d").Replace('/', '-') + ".log";

		// Token: 0x04000201 RID: 513
		private static FontCache ensoulSharpFont;
	}
}
