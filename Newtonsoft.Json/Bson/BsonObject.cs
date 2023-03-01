using System;
using System.Collections;
using System.Collections.Generic;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x02000107 RID: 263
	internal class BsonObject : BsonToken, IEnumerable<BsonProperty>, IEnumerable
	{
		// Token: 0x06000D80 RID: 3456 RVA: 0x00036710 File Offset: 0x00034910
		public void Add(string name, BsonToken token)
		{
			this._children.Add(new BsonProperty
			{
				Name = new BsonString(name, false),
				Value = token
			});
			token.Parent = this;
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000D81 RID: 3457 RVA: 0x0003673D File Offset: 0x0003493D
		public override BsonType Type
		{
			get
			{
				return BsonType.Object;
			}
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x00036740 File Offset: 0x00034940
		public IEnumerator<BsonProperty> GetEnumerator()
		{
			return this._children.GetEnumerator();
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x00036752 File Offset: 0x00034952
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0400041B RID: 1051
		private readonly List<BsonProperty> _children = new List<BsonProperty>();
	}
}
