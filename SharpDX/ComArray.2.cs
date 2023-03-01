using System;
using System.Collections;
using System.Collections.Generic;

namespace SharpDX
{
	// Token: 0x02000005 RID: 5
	public class ComArray<T> : ComArray, IEnumerable<T>, IEnumerable where T : ComObject
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002294 File Offset: 0x00000494
		public ComArray(params T[] array) : base(array)
		{
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000022AA File Offset: 0x000004AA
		public ComArray(int size) : base(size)
		{
		}

		// Token: 0x17000004 RID: 4
		public T this[int i]
		{
			get
			{
				return (T)((object)base.Get(i));
			}
			set
			{
				base.Set(i, value);
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000022D0 File Offset: 0x000004D0
		public new IEnumerator<T> GetEnumerator()
		{
			return new ComArray<T>.ArrayEnumerator<T>(this.values.GetEnumerator());
		}

		// Token: 0x02000006 RID: 6
		private struct ArrayEnumerator<T1> : IEnumerator<T1>, IDisposable, IEnumerator where T1 : ComObject
		{
			// Token: 0x06000018 RID: 24 RVA: 0x000022E7 File Offset: 0x000004E7
			public ArrayEnumerator(IEnumerator enumerator)
			{
				this.enumerator = enumerator;
			}

			// Token: 0x06000019 RID: 25 RVA: 0x000022F0 File Offset: 0x000004F0
			public void Dispose()
			{
			}

			// Token: 0x0600001A RID: 26 RVA: 0x000022F2 File Offset: 0x000004F2
			public bool MoveNext()
			{
				return this.enumerator.MoveNext();
			}

			// Token: 0x0600001B RID: 27 RVA: 0x000022FF File Offset: 0x000004FF
			public void Reset()
			{
				this.enumerator.Reset();
			}

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x0600001C RID: 28 RVA: 0x0000230C File Offset: 0x0000050C
			public T1 Current
			{
				get
				{
					return (T1)((object)this.enumerator.Current);
				}
			}

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x0600001D RID: 29 RVA: 0x0000231E File Offset: 0x0000051E
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x04000005 RID: 5
			private readonly IEnumerator enumerator;
		}
	}
}
