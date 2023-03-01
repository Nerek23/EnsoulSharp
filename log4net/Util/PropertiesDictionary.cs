using System;
using System.Collections;
using System.Runtime.Serialization;

namespace log4net.Util
{
	// Token: 0x02000026 RID: 38
	[Serializable]
	public sealed class PropertiesDictionary : ReadOnlyPropertiesDictionary, ISerializable, IDictionary, ICollection, IEnumerable
	{
		// Token: 0x06000185 RID: 389 RVA: 0x000058BA File Offset: 0x000048BA
		public PropertiesDictionary()
		{
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000058C2 File Offset: 0x000048C2
		public PropertiesDictionary(ReadOnlyPropertiesDictionary propertiesDictionary) : base(propertiesDictionary)
		{
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000058CB File Offset: 0x000048CB
		private PropertiesDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x1700004E RID: 78
		public override object this[string key]
		{
			get
			{
				return base.InnerHashtable[key];
			}
			set
			{
				base.InnerHashtable[key] = value;
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000058F2 File Offset: 0x000048F2
		public void Remove(string key)
		{
			base.InnerHashtable.Remove(key);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00005900 File Offset: 0x00004900
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return base.InnerHashtable.GetEnumerator();
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000590D File Offset: 0x0000490D
		void IDictionary.Remove(object key)
		{
			base.InnerHashtable.Remove(key);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000591B File Offset: 0x0000491B
		bool IDictionary.Contains(object key)
		{
			return base.InnerHashtable.Contains(key);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00005929 File Offset: 0x00004929
		public override void Clear()
		{
			base.InnerHashtable.Clear();
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00005936 File Offset: 0x00004936
		void IDictionary.Add(object key, object value)
		{
			if (!(key is string))
			{
				throw new ArgumentException("key must be a string", "key");
			}
			base.InnerHashtable.Add(key, value);
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000595D File Offset: 0x0000495D
		bool IDictionary.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000050 RID: 80
		object IDictionary.this[object key]
		{
			get
			{
				if (!(key is string))
				{
					throw new ArgumentException("key must be a string", "key");
				}
				return base.InnerHashtable[key];
			}
			set
			{
				if (!(key is string))
				{
					throw new ArgumentException("key must be a string", "key");
				}
				base.InnerHashtable[key] = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000193 RID: 403 RVA: 0x000059AD File Offset: 0x000049AD
		ICollection IDictionary.Values
		{
			get
			{
				return base.InnerHashtable.Values;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000194 RID: 404 RVA: 0x000059BA File Offset: 0x000049BA
		ICollection IDictionary.Keys
		{
			get
			{
				return base.InnerHashtable.Keys;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000195 RID: 405 RVA: 0x000059C7 File Offset: 0x000049C7
		bool IDictionary.IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000059CA File Offset: 0x000049CA
		void ICollection.CopyTo(Array array, int index)
		{
			base.InnerHashtable.CopyTo(array, index);
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000197 RID: 407 RVA: 0x000059D9 File Offset: 0x000049D9
		bool ICollection.IsSynchronized
		{
			get
			{
				return base.InnerHashtable.IsSynchronized;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000198 RID: 408 RVA: 0x000059E6 File Offset: 0x000049E6
		object ICollection.SyncRoot
		{
			get
			{
				return base.InnerHashtable.SyncRoot;
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000059F3 File Offset: 0x000049F3
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)base.InnerHashtable).GetEnumerator();
		}
	}
}
