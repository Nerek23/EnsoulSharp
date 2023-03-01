using System;
using System.Collections;

namespace log4net.Util
{
	// Token: 0x0200000F RID: 15
	[Serializable]
	public sealed class EmptyCollection : ICollection, IEnumerable
	{
		// Token: 0x06000092 RID: 146 RVA: 0x00002E70 File Offset: 0x00001E70
		private EmptyCollection()
		{
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00002E78 File Offset: 0x00001E78
		public static EmptyCollection Instance
		{
			get
			{
				return EmptyCollection.s_instance;
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002E7F File Offset: 0x00001E7F
		public void CopyTo(Array array, int index)
		{
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00002E81 File Offset: 0x00001E81
		public bool IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00002E84 File Offset: 0x00001E84
		public int Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00002E87 File Offset: 0x00001E87
		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00002E8A File Offset: 0x00001E8A
		public IEnumerator GetEnumerator()
		{
			return NullEnumerator.Instance;
		}

		// Token: 0x04000015 RID: 21
		private static readonly EmptyCollection s_instance = new EmptyCollection();
	}
}
