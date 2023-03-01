using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000DB RID: 219
	[NullableContext(2)]
	[Nullable(0)]
	internal class ScanFilter : PathFilter
	{
		// Token: 0x06000C15 RID: 3093 RVA: 0x000308B1 File Offset: 0x0002EAB1
		public ScanFilter(string name)
		{
			this.Name = name;
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x000308C0 File Offset: 0x0002EAC0
		[NullableContext(1)]
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, bool errorWhenNoMatch)
		{
			foreach (JToken c in current)
			{
				if (this.Name == null)
				{
					yield return c;
				}
				JToken value = c;
				for (;;)
				{
					JContainer container = value as JContainer;
					value = PathFilter.GetNextScanValue(c, container, value);
					if (value == null)
					{
						break;
					}
					JProperty jproperty = value as JProperty;
					if (jproperty != null)
					{
						if (jproperty.Name == this.Name)
						{
							yield return jproperty.Value;
						}
					}
					else if (this.Name == null)
					{
						yield return value;
					}
				}
				value = null;
				c = null;
			}
			IEnumerator<JToken> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x040003CB RID: 971
		internal string Name;
	}
}
