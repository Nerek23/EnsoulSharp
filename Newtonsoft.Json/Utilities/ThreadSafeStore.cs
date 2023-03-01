using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x0200006E RID: 110
	[NullableContext(1)]
	[Nullable(0)]
	internal class ThreadSafeStore<[Nullable(2)] TKey, [Nullable(2)] TValue>
	{
		// Token: 0x060005F2 RID: 1522 RVA: 0x00019517 File Offset: 0x00017717
		public ThreadSafeStore(Func<TKey, TValue> creator)
		{
			ValidationUtils.ArgumentNotNull(creator, "creator");
			this._creator = creator;
			this._concurrentStore = new ConcurrentDictionary<TKey, TValue>();
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0001953C File Offset: 0x0001773C
		public TValue Get(TKey key)
		{
			return this._concurrentStore.GetOrAdd(key, this._creator);
		}

		// Token: 0x0400020C RID: 524
		private readonly ConcurrentDictionary<TKey, TValue> _concurrentStore;

		// Token: 0x0400020D RID: 525
		private readonly Func<TKey, TValue> _creator;
	}
}
