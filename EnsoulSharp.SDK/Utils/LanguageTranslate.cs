using System;
using System.Collections.Generic;
using System.Text;
using EnsoulSharp.SDK.Core;
using EnsoulSharp.SDK.Properties;
using EnsoulSharp.SDK.Utility;
using Newtonsoft.Json;

namespace EnsoulSharp.SDK.Utils
{
	// Token: 0x0200005D RID: 93
	internal class LanguageTranslate
	{
		// Token: 0x060003AC RID: 940 RVA: 0x0001A168 File Offset: 0x00018368
		internal static void Initialize()
		{
			try
			{
				string language = Config.SandboxConfig.Language;
				if (!language.Contains("en_"))
				{
					byte[] array = (byte[])Resources.ResourceManager.GetObject(language);
					if (array != null)
					{
						string @string = Encoding.UTF8.GetString(array);
						if (!string.IsNullOrEmpty(@string))
						{
							LanguageTranslate.translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(@string);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logging.Write(false, true, "Initialize")(LogLevel.Error, "LanguageTranslate LoadTranslation threw an exception.\n{0}", new object[]
				{
					ex
				});
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0001A1FC File Offset: 0x000183FC
		public static string Translation(string textToTranslate)
		{
			if (LanguageTranslate.translations.Count <= 0)
			{
				return textToTranslate;
			}
			if (!LanguageTranslate.translations.ContainsKey(textToTranslate))
			{
				return textToTranslate;
			}
			return LanguageTranslate.translations[textToTranslate];
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0001A228 File Offset: 0x00018428
		internal static string GetOnTranslation()
		{
			if (LanguageTranslate.translations.Count <= 0)
			{
				return "ON";
			}
			if (LanguageTranslate.OnTranslate != "")
			{
				return LanguageTranslate.OnTranslate;
			}
			LanguageTranslate.OnTranslate = (LanguageTranslate.translations.ContainsKey("ON") ? LanguageTranslate.translations["ON"] : "ON");
			return LanguageTranslate.OnTranslate;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0001A290 File Offset: 0x00018490
		internal static string GetOffTranslation()
		{
			if (LanguageTranslate.translations.Count <= 0)
			{
				return "OFF";
			}
			if (LanguageTranslate.OffTranslate != "")
			{
				return LanguageTranslate.OffTranslate;
			}
			LanguageTranslate.OffTranslate = (LanguageTranslate.translations.ContainsKey("OFF") ? LanguageTranslate.translations["OFF"] : "OFF");
			return LanguageTranslate.OffTranslate;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0001A2F8 File Offset: 0x000184F8
		internal static string GetPressKeyTranslation()
		{
			if (LanguageTranslate.translations.Count <= 0)
			{
				return "Press a key";
			}
			if (LanguageTranslate.PressKeyTranslate != "")
			{
				return LanguageTranslate.PressKeyTranslate;
			}
			LanguageTranslate.PressKeyTranslate = (LanguageTranslate.translations.ContainsKey("Press a key") ? LanguageTranslate.translations["Press a key"] : "Press a key");
			return LanguageTranslate.PressKeyTranslate;
		}

		// Token: 0x040001FB RID: 507
		private static string OnTranslate = "";

		// Token: 0x040001FC RID: 508
		private static string OffTranslate = "";

		// Token: 0x040001FD RID: 509
		private static string PressKeyTranslate = "";

		// Token: 0x040001FE RID: 510
		private static Dictionary<string, string> translations = new Dictionary<string, string>();
	}
}
