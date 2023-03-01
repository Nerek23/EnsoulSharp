using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000D5 RID: 213
	internal abstract class QueryExpression
	{
		// Token: 0x06000C01 RID: 3073 RVA: 0x00030325 File Offset: 0x0002E525
		public QueryExpression(QueryOperator @operator)
		{
			this.Operator = @operator;
		}

		// Token: 0x06000C02 RID: 3074
		[NullableContext(1)]
		public abstract bool IsMatch(JToken root, JToken t);

		// Token: 0x040003C4 RID: 964
		internal QueryOperator Operator;
	}
}
