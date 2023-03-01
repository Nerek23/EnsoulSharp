﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000D1 RID: 209
	[NullableContext(1)]
	[Nullable(0)]
	internal class FieldMultipleFilter : PathFilter
	{
		// Token: 0x06000BE4 RID: 3044 RVA: 0x0002F069 File Offset: 0x0002D269
		public FieldMultipleFilter(List<string> names)
		{
			this.Names = names;
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x0002F078 File Offset: 0x0002D278
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, bool errorWhenNoMatch)
		{
			foreach (JToken jtoken in current)
			{
				JObject o = jtoken as JObject;
				if (o != null)
				{
					foreach (string name in this.Names)
					{
						JToken jtoken2 = o[name];
						if (jtoken2 != null)
						{
							yield return jtoken2;
						}
						if (errorWhenNoMatch)
						{
							throw new JsonException("Property '{0}' does not exist on JObject.".FormatWith(CultureInfo.InvariantCulture, name));
						}
						name = null;
					}
					List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
				}
				else if (errorWhenNoMatch)
				{
					throw new JsonException("Properties {0} not valid on {1}.".FormatWith(CultureInfo.InvariantCulture, string.Join(", ", from n in this.Names
					select "'" + n + "'"), jtoken.GetType().Name));
				}
				o = null;
			}
			IEnumerator<JToken> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x040003B1 RID: 945
		internal List<string> Names;
	}
}
