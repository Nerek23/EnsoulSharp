using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Xml;

namespace log4net.Util
{
	// Token: 0x0200002B RID: 43
	[Serializable]
	public class ReadOnlyPropertiesDictionary : ISerializable, IDictionary, ICollection, IEnumerable
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x00005C41 File Offset: 0x00004C41
		public ReadOnlyPropertiesDictionary()
		{
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00005C54 File Offset: 0x00004C54
		public ReadOnlyPropertiesDictionary(ReadOnlyPropertiesDictionary propertiesDictionary)
		{
			foreach (object obj in ((IEnumerable)propertiesDictionary))
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				this.InnerHashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00005CCC File Offset: 0x00004CCC
		protected ReadOnlyPropertiesDictionary(SerializationInfo info, StreamingContext context)
		{
			foreach (SerializationEntry serializationEntry in info)
			{
				this.InnerHashtable[XmlConvert.DecodeName(serializationEntry.Name)] = serializationEntry.Value;
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00005D20 File Offset: 0x00004D20
		public string[] GetKeys()
		{
			string[] array = new string[this.InnerHashtable.Count];
			this.InnerHashtable.Keys.CopyTo(array, 0);
			return array;
		}

		// Token: 0x1700005A RID: 90
		public virtual object this[string key]
		{
			get
			{
				return this.InnerHashtable[key];
			}
			set
			{
				throw new NotSupportedException("This is a Read Only Dictionary and can not be modified");
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00005D6B File Offset: 0x00004D6B
		public bool Contains(string key)
		{
			return this.InnerHashtable.Contains(key);
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00005D79 File Offset: 0x00004D79
		protected Hashtable InnerHashtable
		{
			get
			{
				return this.m_hashtable;
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00005D84 File Offset: 0x00004D84
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			foreach (object obj in (this.InnerHashtable.Clone() as IDictionary))
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = dictionaryEntry.Key as string;
				object value = dictionaryEntry.Value;
				bool isSerializable = value.GetType().IsSerializable;
				if (text != null && value != null && isSerializable)
				{
					info.AddValue(XmlConvert.EncodeLocalName(text), value);
				}
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00005E24 File Offset: 0x00004E24
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return this.InnerHashtable.GetEnumerator();
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00005E31 File Offset: 0x00004E31
		void IDictionary.Remove(object key)
		{
			throw new NotSupportedException("This is a Read Only Dictionary and can not be modified");
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00005E3D File Offset: 0x00004E3D
		bool IDictionary.Contains(object key)
		{
			return this.InnerHashtable.Contains(key);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00005E4B File Offset: 0x00004E4B
		public virtual void Clear()
		{
			throw new NotSupportedException("This is a Read Only Dictionary and can not be modified");
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00005E57 File Offset: 0x00004E57
		void IDictionary.Add(object key, object value)
		{
			throw new NotSupportedException("This is a Read Only Dictionary and can not be modified");
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00005E63 File Offset: 0x00004E63
		bool IDictionary.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700005D RID: 93
		object IDictionary.this[object key]
		{
			get
			{
				if (!(key is string))
				{
					throw new ArgumentException("key must be a string");
				}
				return this.InnerHashtable[key];
			}
			set
			{
				throw new NotSupportedException("This is a Read Only Dictionary and can not be modified");
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00005E93 File Offset: 0x00004E93
		ICollection IDictionary.Values
		{
			get
			{
				return this.InnerHashtable.Values;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00005EA0 File Offset: 0x00004EA0
		ICollection IDictionary.Keys
		{
			get
			{
				return this.InnerHashtable.Keys;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00005EAD File Offset: 0x00004EAD
		bool IDictionary.IsFixedSize
		{
			get
			{
				return this.InnerHashtable.IsFixedSize;
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00005EBA File Offset: 0x00004EBA
		void ICollection.CopyTo(Array array, int index)
		{
			this.InnerHashtable.CopyTo(array, index);
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00005EC9 File Offset: 0x00004EC9
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.InnerHashtable.IsSynchronized;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00005ED6 File Offset: 0x00004ED6
		public int Count
		{
			get
			{
				return this.InnerHashtable.Count;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00005EE3 File Offset: 0x00004EE3
		object ICollection.SyncRoot
		{
			get
			{
				return this.InnerHashtable.SyncRoot;
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00005EF0 File Offset: 0x00004EF0
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.InnerHashtable).GetEnumerator();
		}

		// Token: 0x0400005F RID: 95
		private readonly Hashtable m_hashtable = new Hashtable();
	}
}
