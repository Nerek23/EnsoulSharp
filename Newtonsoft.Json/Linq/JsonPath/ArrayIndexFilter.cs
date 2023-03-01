using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000CD RID: 205
	internal class ArrayIndexFilter : PathFilter
	{
		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x0002EF71 File Offset: 0x0002D171
		// (set) Token: 0x06000BD4 RID: 3028 RVA: 0x0002EF79 File Offset: 0x0002D179
		public int? Index { get; set; }

		// Token: 0x06000BD5 RID: 3029 RVA: 0x0002EF82 File Offset: 0x0002D182
		[NullableContext(1)]
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, bool errorWhenNoMatch)
		{
			foreach (JToken jtoken in current)
			{
				if (this.Index != null)
				{
					JToken tokenIndex = PathFilter.GetTokenIndex(jtoken, errorWhenNoMatch, this.Index.GetValueOrDefault());
					if (tokenIndex != null)
					{
						yield return tokenIndex;
					}
				}
				else if (jtoken is JArray || jtoken is JConstructor)
				{
					foreach (JToken jtoken2 in ((IEnumerable<JToken>)jtoken))
					{
						yield return jtoken2;
					}
					IEnumerator<JToken> enumerator2 = null;
				}
				else if (errorWhenNoMatch)
				{
					throw new JsonException("Index * not valid on {0}.".FormatWith(CultureInfo.InvariantCulture, jtoken.GetType().Name));
				}
			}
			IEnumerator<JToken> enumerator = null;
			yield break;
			yield break;
		}
	}
}
