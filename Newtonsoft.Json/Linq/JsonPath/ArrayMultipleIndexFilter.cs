using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000CE RID: 206
	[NullableContext(1)]
	[Nullable(0)]
	internal class ArrayMultipleIndexFilter : PathFilter
	{
		// Token: 0x06000BD7 RID: 3031 RVA: 0x0002EFA8 File Offset: 0x0002D1A8
		public ArrayMultipleIndexFilter(List<int> indexes)
		{
			this.Indexes = indexes;
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0002EFB7 File Offset: 0x0002D1B7
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, bool errorWhenNoMatch)
		{
			foreach (JToken t in current)
			{
				foreach (int index in this.Indexes)
				{
					JToken tokenIndex = PathFilter.GetTokenIndex(t, errorWhenNoMatch, index);
					if (tokenIndex != null)
					{
						yield return tokenIndex;
					}
				}
				List<int>.Enumerator enumerator2 = default(List<int>.Enumerator);
				t = null;
			}
			IEnumerator<JToken> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x040003AC RID: 940
		internal List<int> Indexes;
	}
}
