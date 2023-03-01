using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000DC RID: 220
	[NullableContext(1)]
	[Nullable(0)]
	internal class ScanMultipleFilter : PathFilter
	{
		// Token: 0x06000C17 RID: 3095 RVA: 0x000308D7 File Offset: 0x0002EAD7
		public ScanMultipleFilter(List<string> names)
		{
			this._names = names;
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x000308E6 File Offset: 0x0002EAE6
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, bool errorWhenNoMatch)
		{
			foreach (JToken c in current)
			{
				JToken value = c;
				for (;;)
				{
					JContainer container = value as JContainer;
					value = PathFilter.GetNextScanValue(c, container, value);
					if (value == null)
					{
						break;
					}
					JProperty property = value as JProperty;
					if (property != null)
					{
						foreach (string b in this._names)
						{
							if (property.Name == b)
							{
								yield return property.Value;
							}
						}
						List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
					}
					property = null;
				}
				value = null;
				c = null;
			}
			IEnumerator<JToken> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x040003CC RID: 972
		private List<string> _names;
	}
}
