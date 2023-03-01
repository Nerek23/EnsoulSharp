using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x020000A2 RID: 162
	public class SnakeCaseNamingStrategy : NamingStrategy
	{
		// Token: 0x0600083B RID: 2107 RVA: 0x00023D7A File Offset: 0x00021F7A
		public SnakeCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)
		{
			base.ProcessDictionaryKeys = processDictionaryKeys;
			base.OverrideSpecifiedNames = overrideSpecifiedNames;
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00023D90 File Offset: 0x00021F90
		public SnakeCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames) : this(processDictionaryKeys, overrideSpecifiedNames)
		{
			base.ProcessExtensionDataNames = processExtensionDataNames;
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00023DA1 File Offset: 0x00021FA1
		public SnakeCaseNamingStrategy()
		{
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x00023DA9 File Offset: 0x00021FA9
		[NullableContext(1)]
		protected override string ResolvePropertyName(string name)
		{
			return StringUtils.ToSnakeCase(name);
		}
	}
}
