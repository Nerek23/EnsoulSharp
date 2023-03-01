using System;
using System.Collections;

namespace log4net.Util
{
	// Token: 0x02000010 RID: 16
	[Serializable]
	public sealed class EmptyDictionary : IDictionary, ICollection, IEnumerable
	{
		// Token: 0x0600009A RID: 154 RVA: 0x00002E9D File Offset: 0x00001E9D
		private EmptyDictionary()
		{
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002EA5 File Offset: 0x00001EA5
		public static EmptyDictionary Instance
		{
			get
			{
				return EmptyDictionary.s_instance;
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00002EAC File Offset: 0x00001EAC
		public void CopyTo(Array array, int index)
		{
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00002EAE File Offset: 0x00001EAE
		public bool IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00002EB1 File Offset: 0x00001EB1
		public int Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00002EB4 File Offset: 0x00001EB4
		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00002EB7 File Offset: 0x00001EB7
		IEnumerator IEnumerable.GetEnumerator()
		{
			return NullEnumerator.Instance;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002EBE File Offset: 0x00001EBE
		public void Add(object key, object value)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00002EC5 File Offset: 0x00001EC5
		public void Clear()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002ECC File Offset: 0x00001ECC
		public bool Contains(object key)
		{
			return false;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00002ECF File Offset: 0x00001ECF
		public IDictionaryEnumerator GetEnumerator()
		{
			return NullDictionaryEnumerator.Instance;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00002ED6 File Offset: 0x00001ED6
		public void Remove(object key)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00002EDD File Offset: 0x00001EDD
		public bool IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00002EE0 File Offset: 0x00001EE0
		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00002EE3 File Offset: 0x00001EE3
		public ICollection Keys
		{
			get
			{
				return EmptyCollection.Instance;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00002EEA File Offset: 0x00001EEA
		public ICollection Values
		{
			get
			{
				return EmptyCollection.Instance;
			}
		}

		// Token: 0x17000022 RID: 34
		public object this[object key]
		{
			get
			{
				return null;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x04000016 RID: 22
		private static readonly EmptyDictionary s_instance = new EmptyDictionary();
	}
}
