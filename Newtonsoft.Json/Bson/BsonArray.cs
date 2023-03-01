using System;
using System.Collections;
using System.Collections.Generic;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x02000108 RID: 264
	internal class BsonArray : BsonToken, IEnumerable<BsonToken>, IEnumerable
	{
		// Token: 0x06000D85 RID: 3461 RVA: 0x0003676D File Offset: 0x0003496D
		public void Add(BsonToken token)
		{
			this._children.Add(token);
			token.Parent = this;
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000D86 RID: 3462 RVA: 0x00036782 File Offset: 0x00034982
		public override BsonType Type
		{
			get
			{
				return BsonType.Array;
			}
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x00036785 File Offset: 0x00034985
		public IEnumerator<BsonToken> GetEnumerator()
		{
			return this._children.GetEnumerator();
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x00036797 File Offset: 0x00034997
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0400041C RID: 1052
		private readonly List<BsonToken> _children = new List<BsonToken>();
	}
}
