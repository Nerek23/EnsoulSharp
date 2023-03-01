using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000D6 RID: 214
	[NullableContext(1)]
	[Nullable(0)]
	internal class CompositeExpression : QueryExpression
	{
		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000C03 RID: 3075 RVA: 0x00030334 File Offset: 0x0002E534
		// (set) Token: 0x06000C04 RID: 3076 RVA: 0x0003033C File Offset: 0x0002E53C
		public List<QueryExpression> Expressions { get; set; }

		// Token: 0x06000C05 RID: 3077 RVA: 0x00030345 File Offset: 0x0002E545
		public CompositeExpression(QueryOperator @operator) : base(@operator)
		{
			this.Expressions = new List<QueryExpression>();
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x0003035C File Offset: 0x0002E55C
		public override bool IsMatch(JToken root, JToken t)
		{
			QueryOperator @operator = this.Operator;
			if (@operator == QueryOperator.And)
			{
				using (List<QueryExpression>.Enumerator enumerator = this.Expressions.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (!enumerator.Current.IsMatch(root, t))
						{
							return false;
						}
					}
				}
				return true;
			}
			if (@operator != QueryOperator.Or)
			{
				throw new ArgumentOutOfRangeException();
			}
			using (List<QueryExpression>.Enumerator enumerator = this.Expressions.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsMatch(root, t))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
