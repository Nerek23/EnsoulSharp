using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x0200009A RID: 154
	public class KebabCaseNamingStrategy : NamingStrategy
	{
		// Token: 0x06000815 RID: 2069 RVA: 0x0002390A File Offset: 0x00021B0A
		public KebabCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)
		{
			base.ProcessDictionaryKeys = processDictionaryKeys;
			base.OverrideSpecifiedNames = overrideSpecifiedNames;
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00023920 File Offset: 0x00021B20
		public KebabCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames) : this(processDictionaryKeys, overrideSpecifiedNames)
		{
			base.ProcessExtensionDataNames = processExtensionDataNames;
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x00023931 File Offset: 0x00021B31
		public KebabCaseNamingStrategy()
		{
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00023939 File Offset: 0x00021B39
		[NullableContext(1)]
		protected override string ResolvePropertyName(string name)
		{
			return StringUtils.ToKebabCase(name);
		}
	}
}
