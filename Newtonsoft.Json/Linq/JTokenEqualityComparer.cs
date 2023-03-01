using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq
{
	// Token: 0x020000C5 RID: 197
	[NullableContext(1)]
	[Nullable(0)]
	public class JTokenEqualityComparer : IEqualityComparer<JToken>
	{
		// Token: 0x06000B59 RID: 2905 RVA: 0x0002D22E File Offset: 0x0002B42E
		public bool Equals(JToken x, JToken y)
		{
			return JToken.DeepEquals(x, y);
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x0002D237 File Offset: 0x0002B437
		public int GetHashCode(JToken obj)
		{
			if (obj == null)
			{
				return 0;
			}
			return obj.GetDeepHashCode();
		}
	}
}
