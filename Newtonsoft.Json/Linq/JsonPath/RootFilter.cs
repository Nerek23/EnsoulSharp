using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000DA RID: 218
	[NullableContext(1)]
	[Nullable(0)]
	internal class RootFilter : PathFilter
	{
		// Token: 0x06000C12 RID: 3090 RVA: 0x00030891 File Offset: 0x0002EA91
		private RootFilter()
		{
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x00030899 File Offset: 0x0002EA99
		public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, bool errorWhenNoMatch)
		{
			return new JToken[]
			{
				root
			};
		}

		// Token: 0x040003CA RID: 970
		public static readonly RootFilter Instance = new RootFilter();
	}
}
