using System;
using System.Collections;
using System.Configuration;
using System.IO;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x02000041 RID: 65
	internal sealed class AppSettingPatternConverter : PatternConverter
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000254 RID: 596 RVA: 0x000074FC File Offset: 0x000064FC
		private static IDictionary AppSettingsDictionary
		{
			get
			{
				if (AppSettingPatternConverter._appSettingsHashTable == null)
				{
					Hashtable hashtable = new Hashtable();
					foreach (object obj in ConfigurationManager.AppSettings)
					{
						string text = (string)obj;
						hashtable.Add(text, ConfigurationManager.AppSettings[text]);
					}
					AppSettingPatternConverter._appSettingsHashTable = hashtable;
				}
				return AppSettingPatternConverter._appSettingsHashTable;
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00007578 File Offset: 0x00006578
		protected override void Convert(TextWriter writer, object state)
		{
			if (this.Option != null)
			{
				PatternConverter.WriteObject(writer, null, ConfigurationManager.AppSettings[this.Option]);
				return;
			}
			PatternConverter.WriteDictionary(writer, null, AppSettingPatternConverter.AppSettingsDictionary);
		}

		// Token: 0x0400007E RID: 126
		private static Hashtable _appSettingsHashTable;
	}
}
