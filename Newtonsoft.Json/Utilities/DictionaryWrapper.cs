using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x0200004E RID: 78
	[NullableContext(1)]
	[Nullable(0)]
	internal class DictionaryWrapper<[Nullable(2)] TKey, [Nullable(2)] TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IWrappedDictionary, IDictionary, ICollection
	{
		// Token: 0x060004A7 RID: 1191 RVA: 0x000136B1 File Offset: 0x000118B1
		public DictionaryWrapper(IDictionary dictionary)
		{
			ValidationUtils.ArgumentNotNull(dictionary, "dictionary");
			this._dictionary = dictionary;
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x000136CB File Offset: 0x000118CB
		public DictionaryWrapper(IDictionary<TKey, TValue> dictionary)
		{
			ValidationUtils.ArgumentNotNull(dictionary, "dictionary");
			this._genericDictionary = dictionary;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x000136E5 File Offset: 0x000118E5
		public DictionaryWrapper(IReadOnlyDictionary<TKey, TValue> dictionary)
		{
			ValidationUtils.ArgumentNotNull(dictionary, "dictionary");
			this._readOnlyDictionary = dictionary;
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x000136FF File Offset: 0x000118FF
		internal IDictionary<TKey, TValue> GenericDictionary
		{
			get
			{
				return this._genericDictionary;
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00013707 File Offset: 0x00011907
		public void Add(TKey key, TValue value)
		{
			if (this._dictionary != null)
			{
				this._dictionary.Add(key, value);
				return;
			}
			if (this._genericDictionary != null)
			{
				this._genericDictionary.Add(key, value);
				return;
			}
			throw new NotSupportedException();
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00013744 File Offset: 0x00011944
		public bool ContainsKey(TKey key)
		{
			if (this._dictionary != null)
			{
				return this._dictionary.Contains(key);
			}
			if (this._readOnlyDictionary != null)
			{
				return this._readOnlyDictionary.ContainsKey(key);
			}
			return this.GenericDictionary.ContainsKey(key);
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x00013784 File Offset: 0x00011984
		public ICollection<TKey> Keys
		{
			get
			{
				if (this._dictionary != null)
				{
					return this._dictionary.Keys.Cast<TKey>().ToList<TKey>();
				}
				if (this._readOnlyDictionary != null)
				{
					return this._readOnlyDictionary.Keys.ToList<TKey>();
				}
				return this.GenericDictionary.Keys;
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x000137D4 File Offset: 0x000119D4
		public bool Remove(TKey key)
		{
			if (this._dictionary != null)
			{
				if (this._dictionary.Contains(key))
				{
					this._dictionary.Remove(key);
					return true;
				}
				return false;
			}
			else
			{
				if (this._readOnlyDictionary != null)
				{
					throw new NotSupportedException();
				}
				return this.GenericDictionary.Remove(key);
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0001382C File Offset: 0x00011A2C
		public bool TryGetValue(TKey key, [MaybeNull] out TValue value)
		{
			if (this._dictionary != null)
			{
				if (!this._dictionary.Contains(key))
				{
					value = default(TValue);
					return false;
				}
				value = (TValue)((object)this._dictionary[key]);
				return true;
			}
			else
			{
				if (this._readOnlyDictionary != null)
				{
					throw new NotSupportedException();
				}
				return this.GenericDictionary.TryGetValue(key, out value);
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x00013898 File Offset: 0x00011A98
		public ICollection<TValue> Values
		{
			get
			{
				if (this._dictionary != null)
				{
					return this._dictionary.Values.Cast<TValue>().ToList<TValue>();
				}
				if (this._readOnlyDictionary != null)
				{
					return this._readOnlyDictionary.Values.ToList<TValue>();
				}
				return this.GenericDictionary.Values;
			}
		}

		// Token: 0x170000B2 RID: 178
		public TValue this[TKey key]
		{
			get
			{
				if (this._dictionary != null)
				{
					return (TValue)((object)this._dictionary[key]);
				}
				if (this._readOnlyDictionary != null)
				{
					return this._readOnlyDictionary[key];
				}
				return this.GenericDictionary[key];
			}
			set
			{
				if (this._dictionary != null)
				{
					this._dictionary[key] = value;
					return;
				}
				if (this._readOnlyDictionary != null)
				{
					throw new NotSupportedException();
				}
				this.GenericDictionary[key] = value;
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00013974 File Offset: 0x00011B74
		public void Add([Nullable(new byte[]
		{
			0,
			1,
			1
		})] KeyValuePair<TKey, TValue> item)
		{
			if (this._dictionary != null)
			{
				((IList)this._dictionary).Add(item);
				return;
			}
			if (this._readOnlyDictionary != null)
			{
				throw new NotSupportedException();
			}
			IDictionary<TKey, TValue> genericDictionary = this._genericDictionary;
			if (genericDictionary == null)
			{
				return;
			}
			genericDictionary.Add(item);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x000139C0 File Offset: 0x00011BC0
		public void Clear()
		{
			if (this._dictionary != null)
			{
				this._dictionary.Clear();
				return;
			}
			if (this._readOnlyDictionary != null)
			{
				throw new NotSupportedException();
			}
			this.GenericDictionary.Clear();
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x000139F0 File Offset: 0x00011BF0
		public bool Contains([Nullable(new byte[]
		{
			0,
			1,
			1
		})] KeyValuePair<TKey, TValue> item)
		{
			if (this._dictionary != null)
			{
				return ((IList)this._dictionary).Contains(item);
			}
			if (this._readOnlyDictionary != null)
			{
				return this._readOnlyDictionary.Contains(item);
			}
			return this.GenericDictionary.Contains(item);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00013A40 File Offset: 0x00011C40
		public void CopyTo([Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			if (this._dictionary != null)
			{
				using (IDictionaryEnumerator enumerator = this._dictionary.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DictionaryEntry entry = enumerator.Entry;
						array[arrayIndex++] = new KeyValuePair<TKey, TValue>((TKey)((object)entry.Key), (TValue)((object)entry.Value));
					}
					return;
				}
			}
			if (this._readOnlyDictionary != null)
			{
				throw new NotSupportedException();
			}
			this.GenericDictionary.CopyTo(array, arrayIndex);
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x00013ADC File Offset: 0x00011CDC
		public int Count
		{
			get
			{
				if (this._dictionary != null)
				{
					return this._dictionary.Count;
				}
				if (this._readOnlyDictionary != null)
				{
					return this._readOnlyDictionary.Count;
				}
				return this.GenericDictionary.Count;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x00013B11 File Offset: 0x00011D11
		public bool IsReadOnly
		{
			get
			{
				if (this._dictionary != null)
				{
					return this._dictionary.IsReadOnly;
				}
				return this._readOnlyDictionary != null || this.GenericDictionary.IsReadOnly;
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00013B3C File Offset: 0x00011D3C
		public bool Remove([Nullable(new byte[]
		{
			0,
			1,
			1
		})] KeyValuePair<TKey, TValue> item)
		{
			if (this._dictionary != null)
			{
				if (!this._dictionary.Contains(item.Key))
				{
					return true;
				}
				if (object.Equals(this._dictionary[item.Key], item.Value))
				{
					this._dictionary.Remove(item.Key);
					return true;
				}
				return false;
			}
			else
			{
				if (this._readOnlyDictionary != null)
				{
					throw new NotSupportedException();
				}
				return this.GenericDictionary.Remove(item);
			}
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00013BCC File Offset: 0x00011DCC
		[return: Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			if (this._dictionary != null)
			{
				return (from DictionaryEntry de in this._dictionary
				select new KeyValuePair<TKey, TValue>((TKey)((object)de.Key), (TValue)((object)de.Value))).GetEnumerator();
			}
			if (this._readOnlyDictionary != null)
			{
				return this._readOnlyDictionary.GetEnumerator();
			}
			return this.GenericDictionary.GetEnumerator();
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00013C35 File Offset: 0x00011E35
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00013C3D File Offset: 0x00011E3D
		void IDictionary.Add(object key, object value)
		{
			if (this._dictionary != null)
			{
				this._dictionary.Add(key, value);
				return;
			}
			if (this._readOnlyDictionary != null)
			{
				throw new NotSupportedException();
			}
			this.GenericDictionary.Add((TKey)((object)key), (TValue)((object)value));
		}

		// Token: 0x170000B5 RID: 181
		[Nullable(2)]
		object IDictionary.this[object key]
		{
			[return: Nullable(2)]
			get
			{
				if (this._dictionary != null)
				{
					return this._dictionary[key];
				}
				if (this._readOnlyDictionary != null)
				{
					return this._readOnlyDictionary[(TKey)((object)key)];
				}
				return this.GenericDictionary[(TKey)((object)key)];
			}
			[param: Nullable(2)]
			set
			{
				if (this._dictionary != null)
				{
					this._dictionary[key] = value;
					return;
				}
				if (this._readOnlyDictionary != null)
				{
					throw new NotSupportedException();
				}
				this.GenericDictionary[(TKey)((object)key)] = (TValue)((object)value);
			}
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00013D10 File Offset: 0x00011F10
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			if (this._dictionary != null)
			{
				return this._dictionary.GetEnumerator();
			}
			if (this._readOnlyDictionary != null)
			{
				return new DictionaryWrapper<TKey, TValue>.DictionaryEnumerator<TKey, TValue>(this._readOnlyDictionary.GetEnumerator());
			}
			return new DictionaryWrapper<TKey, TValue>.DictionaryEnumerator<TKey, TValue>(this.GenericDictionary.GetEnumerator());
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00013D64 File Offset: 0x00011F64
		bool IDictionary.Contains(object key)
		{
			if (this._genericDictionary != null)
			{
				return this._genericDictionary.ContainsKey((TKey)((object)key));
			}
			if (this._readOnlyDictionary != null)
			{
				return this._readOnlyDictionary.ContainsKey((TKey)((object)key));
			}
			return this._dictionary.Contains(key);
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x00013DB1 File Offset: 0x00011FB1
		bool IDictionary.IsFixedSize
		{
			get
			{
				return this._genericDictionary == null && (this._readOnlyDictionary != null || this._dictionary.IsFixedSize);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x00013DD2 File Offset: 0x00011FD2
		ICollection IDictionary.Keys
		{
			get
			{
				if (this._genericDictionary != null)
				{
					return this._genericDictionary.Keys.ToList<TKey>();
				}
				if (this._readOnlyDictionary != null)
				{
					return this._readOnlyDictionary.Keys.ToList<TKey>();
				}
				return this._dictionary.Keys;
			}
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00013E11 File Offset: 0x00012011
		public void Remove(object key)
		{
			if (this._dictionary != null)
			{
				this._dictionary.Remove(key);
				return;
			}
			if (this._readOnlyDictionary != null)
			{
				throw new NotSupportedException();
			}
			this.GenericDictionary.Remove((TKey)((object)key));
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x00013E48 File Offset: 0x00012048
		ICollection IDictionary.Values
		{
			get
			{
				if (this._genericDictionary != null)
				{
					return this._genericDictionary.Values.ToList<TValue>();
				}
				if (this._readOnlyDictionary != null)
				{
					return this._readOnlyDictionary.Values.ToList<TValue>();
				}
				return this._dictionary.Values;
			}
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00013E87 File Offset: 0x00012087
		void ICollection.CopyTo(Array array, int index)
		{
			if (this._dictionary != null)
			{
				this._dictionary.CopyTo(array, index);
				return;
			}
			if (this._readOnlyDictionary != null)
			{
				throw new NotSupportedException();
			}
			this.GenericDictionary.CopyTo((KeyValuePair<TKey, TValue>[])array, index);
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x00013EBF File Offset: 0x000120BF
		bool ICollection.IsSynchronized
		{
			get
			{
				return this._dictionary != null && this._dictionary.IsSynchronized;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x00013ED6 File Offset: 0x000120D6
		object ICollection.SyncRoot
		{
			get
			{
				if (this._syncRoot == null)
				{
					Interlocked.CompareExchange(ref this._syncRoot, new object(), null);
				}
				return this._syncRoot;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x00013EF8 File Offset: 0x000120F8
		public object UnderlyingDictionary
		{
			get
			{
				if (this._dictionary != null)
				{
					return this._dictionary;
				}
				if (this._readOnlyDictionary != null)
				{
					return this._readOnlyDictionary;
				}
				return this.GenericDictionary;
			}
		}

		// Token: 0x040001B8 RID: 440
		[Nullable(2)]
		private readonly IDictionary _dictionary;

		// Token: 0x040001B9 RID: 441
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private readonly IDictionary<TKey, TValue> _genericDictionary;

		// Token: 0x040001BA RID: 442
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private readonly IReadOnlyDictionary<TKey, TValue> _readOnlyDictionary;

		// Token: 0x040001BB RID: 443
		[Nullable(2)]
		private object _syncRoot;

		// Token: 0x02000166 RID: 358
		[Nullable(0)]
		private readonly struct DictionaryEnumerator<[Nullable(2)] TEnumeratorKey, [Nullable(2)] TEnumeratorValue> : IDictionaryEnumerator, IEnumerator
		{
			// Token: 0x06000E81 RID: 3713 RVA: 0x0004142F File Offset: 0x0003F62F
			public DictionaryEnumerator([Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})] IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> e)
			{
				ValidationUtils.ArgumentNotNull(e, "e");
				this._e = e;
			}

			// Token: 0x1700028C RID: 652
			// (get) Token: 0x06000E82 RID: 3714 RVA: 0x00041443 File Offset: 0x0003F643
			public DictionaryEntry Entry
			{
				get
				{
					return (DictionaryEntry)this.Current;
				}
			}

			// Token: 0x1700028D RID: 653
			// (get) Token: 0x06000E83 RID: 3715 RVA: 0x00041450 File Offset: 0x0003F650
			public object Key
			{
				get
				{
					return this.Entry.Key;
				}
			}

			// Token: 0x1700028E RID: 654
			// (get) Token: 0x06000E84 RID: 3716 RVA: 0x0004146C File Offset: 0x0003F66C
			public object Value
			{
				get
				{
					return this.Entry.Value;
				}
			}

			// Token: 0x1700028F RID: 655
			// (get) Token: 0x06000E85 RID: 3717 RVA: 0x00041488 File Offset: 0x0003F688
			public object Current
			{
				get
				{
					KeyValuePair<TEnumeratorKey, TEnumeratorValue> keyValuePair = this._e.Current;
					object key = keyValuePair.Key;
					keyValuePair = this._e.Current;
					return new DictionaryEntry(key, keyValuePair.Value);
				}
			}

			// Token: 0x06000E86 RID: 3718 RVA: 0x000414CF File Offset: 0x0003F6CF
			public bool MoveNext()
			{
				return this._e.MoveNext();
			}

			// Token: 0x06000E87 RID: 3719 RVA: 0x000414DC File Offset: 0x0003F6DC
			public void Reset()
			{
				this._e.Reset();
			}

			// Token: 0x0400067A RID: 1658
			[Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			private readonly IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> _e;
		}
	}
}
