using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x02000072 RID: 114
	public class CamelCaseNamingStrategy : NamingStrategy
	{
		// Token: 0x06000609 RID: 1545 RVA: 0x000196F5 File Offset: 0x000178F5
		public CamelCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)
		{
			base.ProcessDictionaryKeys = processDictionaryKeys;
			base.OverrideSpecifiedNames = overrideSpecifiedNames;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0001970B File Offset: 0x0001790B
		public CamelCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames) : this(processDictionaryKeys, overrideSpecifiedNames)
		{
			base.ProcessExtensionDataNames = processExtensionDataNames;
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0001971C File Offset: 0x0001791C
		public CamelCaseNamingStrategy()
		{
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00019724 File Offset: 0x00017924
		[NullableContext(1)]
		protected override string ResolvePropertyName(string name)
		{
			return StringUtils.ToCamelCase(name);
		}
	}
}
