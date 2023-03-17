using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace System.Collections.ObjectModel
{
	/// <summary>Represents a read-only, generic collection of key/value pairs.</summary>
	/// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
	/// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
	// Token: 0x0200048A RID: 1162
	[DebuggerTypeProxy(typeof(Mscorlib_DictionaryDebugView<, >))]
	[DebuggerDisplay("Count = {Count}")]
	[__DynamicallyInvokable]
	[Serializable]
	public class ReadOnlyDictionary<TKey, TValue> : IDictionary<!0, !1>, ICollection<KeyValuePair<!0, !1>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<!0, !1>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.ReadOnlyDictionary`2" /> class that is a wrapper around the specified dictionary.</summary>
		/// <param name="dictionary">The dictionary to wrap.</param>
		// Token: 0x060038CB RID: 14539 RVA: 0x000D88D0 File Offset: 0x000D6AD0
		[__DynamicallyInvokable]
		public ReadOnlyDictionary(IDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this.m_dictionary = dictionary;
		}

		/// <summary>Gets the dictionary that is wrapped by this <see cref="T:System.Collections.ObjectModel.ReadOnlyDictionary`2" /> object.</summary>
		/// <returns>The dictionary that is wrapped by this object.</returns>
		// Token: 0x170008A2 RID: 2210
		// (get) Token: 0x060038CC RID: 14540 RVA: 0x000D88ED File Offset: 0x000D6AED
		[__DynamicallyInvokable]
		protected IDictionary<TKey, TValue> Dictionary
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_dictionary;
			}
		}

		/// <summary>Gets a key collection that contains the keys of the dictionary.</summary>
		/// <returns>A key collection that contains the keys of the dictionary.</returns>
		// Token: 0x170008A3 RID: 2211
		// (get) Token: 0x060038CD RID: 14541 RVA: 0x000D88F5 File Offset: 0x000D6AF5
		[__DynamicallyInvokable]
		public ReadOnlyDictionary<TKey, TValue>.KeyCollection Keys
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_keys == null)
				{
					this.m_keys = new ReadOnlyDictionary<TKey, TValue>.KeyCollection(this.m_dictionary.Keys);
				}
				return this.m_keys;
			}
		}

		/// <summary>Gets a collection that contains the values in the dictionary.</summary>
		/// <returns>A collection that contains the values in the object that implements <see cref="T:System.Collections.ObjectModel.ReadOnlyDictionary`2" />.</returns>
		// Token: 0x170008A4 RID: 2212
		// (get) Token: 0x060038CE RID: 14542 RVA: 0x000D891B File Offset: 0x000D6B1B
		[__DynamicallyInvokable]
		public ReadOnlyDictionary<TKey, TValue>.ValueCollection Values
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_values == null)
				{
					this.m_values = new ReadOnlyDictionary<TKey, TValue>.ValueCollection(this.m_dictionary.Values);
				}
				return this.m_values;
			}
		}

		/// <summary>Determines whether the dictionary contains an element that has the specified key.</summary>
		/// <param name="key">The key to locate in the dictionary.</param>
		/// <returns>
		///   <see langword="true" /> if the dictionary contains an element that has the specified key; otherwise, <see langword="false" />.</returns>
		// Token: 0x060038CF RID: 14543 RVA: 0x000D8941 File Offset: 0x000D6B41
		[__DynamicallyInvokable]
		public bool ContainsKey(TKey key)
		{
			return this.m_dictionary.ContainsKey(key);
		}

		// Token: 0x170008A5 RID: 2213
		// (get) Token: 0x060038D0 RID: 14544 RVA: 0x000D894F File Offset: 0x000D6B4F
		[__DynamicallyInvokable]
		ICollection<TKey> IDictionary<!0, !1>.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Keys;
			}
		}

		/// <summary>Retrieves the value that is associated with the specified key.</summary>
		/// <param name="key">The key whose value will be retrieved.</param>
		/// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value" /> parameter. This parameter is passed uninitialized.</param>
		/// <returns>
		///   <see langword="true" /> if the object that implements <see cref="T:System.Collections.ObjectModel.ReadOnlyDictionary`2" /> contains an element with the specified key; otherwise, <see langword="false" />.</returns>
		// Token: 0x060038D1 RID: 14545 RVA: 0x000D8957 File Offset: 0x000D6B57
		[__DynamicallyInvokable]
		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.m_dictionary.TryGetValue(key, out value);
		}

		// Token: 0x170008A6 RID: 2214
		// (get) Token: 0x060038D2 RID: 14546 RVA: 0x000D8966 File Offset: 0x000D6B66
		[__DynamicallyInvokable]
		ICollection<TValue> IDictionary<!0, !1>.Values
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Values;
			}
		}

		/// <summary>Gets the element that has the specified key.</summary>
		/// <param name="key">The key of the element to get.</param>
		/// <returns>The element that has the specified key.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name="key" /> is not found.</exception>
		// Token: 0x170008A7 RID: 2215
		[__DynamicallyInvokable]
		public TValue this[TKey key]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_dictionary[key];
			}
		}

		// Token: 0x060038D4 RID: 14548 RVA: 0x000D897C File Offset: 0x000D6B7C
		[__DynamicallyInvokable]
		void IDictionary<!0, !1>.Add(TKey key, TValue value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060038D5 RID: 14549 RVA: 0x000D8985 File Offset: 0x000D6B85
		[__DynamicallyInvokable]
		bool IDictionary<!0, !1>.Remove(TKey key)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			return false;
		}

		// Token: 0x170008A8 RID: 2216
		[__DynamicallyInvokable]
		TValue IDictionary<!0, !1>.this[TKey key]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_dictionary[key];
			}
			[__DynamicallyInvokable]
			set
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
		}

		/// <summary>Gets the number of items in the dictionary.</summary>
		/// <returns>The number of items in the dictionary.</returns>
		// Token: 0x170008A9 RID: 2217
		// (get) Token: 0x060038D8 RID: 14552 RVA: 0x000D89A6 File Offset: 0x000D6BA6
		[__DynamicallyInvokable]
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_dictionary.Count;
			}
		}

		// Token: 0x060038D9 RID: 14553 RVA: 0x000D89B3 File Offset: 0x000D6BB3
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			return this.m_dictionary.Contains(item);
		}

		// Token: 0x060038DA RID: 14554 RVA: 0x000D89C1 File Offset: 0x000D6BC1
		[__DynamicallyInvokable]
		void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			this.m_dictionary.CopyTo(array, arrayIndex);
		}

		// Token: 0x170008AA RID: 2218
		// (get) Token: 0x060038DB RID: 14555 RVA: 0x000D89D0 File Offset: 0x000D6BD0
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		// Token: 0x060038DC RID: 14556 RVA: 0x000D89D3 File Offset: 0x000D6BD3
		[__DynamicallyInvokable]
		void ICollection<KeyValuePair<!0, !1>>.Add(KeyValuePair<TKey, TValue> item)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060038DD RID: 14557 RVA: 0x000D89DC File Offset: 0x000D6BDC
		[__DynamicallyInvokable]
		void ICollection<KeyValuePair<!0, !1>>.Clear()
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060038DE RID: 14558 RVA: 0x000D89E5 File Offset: 0x000D6BE5
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			return false;
		}

		/// <summary>Returns an enumerator that iterates through the <see cref="T:System.Collections.ObjectModel.ReadOnlyDictionary`2" />.</summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		// Token: 0x060038DF RID: 14559 RVA: 0x000D89EF File Offset: 0x000D6BEF
		[__DynamicallyInvokable]
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return this.m_dictionary.GetEnumerator();
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		// Token: 0x060038E0 RID: 14560 RVA: 0x000D89FC File Offset: 0x000D6BFC
		[__DynamicallyInvokable]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.m_dictionary.GetEnumerator();
		}

		// Token: 0x060038E1 RID: 14561 RVA: 0x000D8A09 File Offset: 0x000D6C09
		private static bool IsCompatibleKey(object key)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			return key is TKey;
		}

		/// <summary>Throws a <see cref="T:System.NotSupportedException" /> exception in all cases.</summary>
		/// <param name="key">The key of the element to add.</param>
		/// <param name="value">The value of the element to add.</param>
		/// <exception cref="T:System.NotSupportedException">In all cases.</exception>
		// Token: 0x060038E2 RID: 14562 RVA: 0x000D8A1D File Offset: 0x000D6C1D
		[__DynamicallyInvokable]
		void IDictionary.Add(object key, object value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		/// <summary>Throws a <see cref="T:System.NotSupportedException" /> exception in all cases.</summary>
		/// <exception cref="T:System.NotSupportedException">In all cases.</exception>
		// Token: 0x060038E3 RID: 14563 RVA: 0x000D8A26 File Offset: 0x000D6C26
		[__DynamicallyInvokable]
		void IDictionary.Clear()
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		/// <summary>Determines whether the dictionary contains an element that has the specified key.</summary>
		/// <param name="key">The key to locate in the dictionary.</param>
		/// <returns>
		///   <see langword="true" /> if the dictionary contains an element that has the specified key; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x060038E4 RID: 14564 RVA: 0x000D8A2F File Offset: 0x000D6C2F
		[__DynamicallyInvokable]
		bool IDictionary.Contains(object key)
		{
			return ReadOnlyDictionary<TKey, TValue>.IsCompatibleKey(key) && this.ContainsKey((TKey)((object)key));
		}

		/// <summary>Returns an enumerator for the dictionary.</summary>
		/// <returns>An enumerator for the dictionary.</returns>
		// Token: 0x060038E5 RID: 14565 RVA: 0x000D8A48 File Offset: 0x000D6C48
		[__DynamicallyInvokable]
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			IDictionary dictionary = this.m_dictionary as IDictionary;
			if (dictionary != null)
			{
				return dictionary.GetEnumerator();
			}
			return new ReadOnlyDictionary<TKey, TValue>.DictionaryEnumerator(this.m_dictionary);
		}

		/// <summary>Gets a value that indicates whether the dictionary has a fixed size.</summary>
		/// <returns>
		///   <see langword="true" /> if the dictionary has a fixed size; otherwise, <see langword="false" />.</returns>
		// Token: 0x170008AB RID: 2219
		// (get) Token: 0x060038E6 RID: 14566 RVA: 0x000D8A7B File Offset: 0x000D6C7B
		[__DynamicallyInvokable]
		bool IDictionary.IsFixedSize
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		/// <summary>Gets a value that indicates whether the dictionary is read-only.</summary>
		/// <returns>
		///   <see langword="true" /> in all cases.</returns>
		// Token: 0x170008AC RID: 2220
		// (get) Token: 0x060038E7 RID: 14567 RVA: 0x000D8A7E File Offset: 0x000D6C7E
		[__DynamicallyInvokable]
		bool IDictionary.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		/// <summary>Gets a collection that contains the keys of the dictionary.</summary>
		/// <returns>A collection that contains the keys of the dictionary.</returns>
		// Token: 0x170008AD RID: 2221
		// (get) Token: 0x060038E8 RID: 14568 RVA: 0x000D8A81 File Offset: 0x000D6C81
		[__DynamicallyInvokable]
		ICollection IDictionary.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Keys;
			}
		}

		/// <summary>Throws a <see cref="T:System.NotSupportedException" /> exception in all cases.</summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <exception cref="T:System.NotSupportedException">In all cases.</exception>
		// Token: 0x060038E9 RID: 14569 RVA: 0x000D8A89 File Offset: 0x000D6C89
		[__DynamicallyInvokable]
		void IDictionary.Remove(object key)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		/// <summary>Gets a collection that contains the values in the dictionary.</summary>
		/// <returns>A collection that contains the values in the dictionary.</returns>
		// Token: 0x170008AE RID: 2222
		// (get) Token: 0x060038EA RID: 14570 RVA: 0x000D8A92 File Offset: 0x000D6C92
		[__DynamicallyInvokable]
		ICollection IDictionary.Values
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Values;
			}
		}

		/// <summary>Gets the element that has the specified key.</summary>
		/// <param name="key">The key of the element to get or set.</param>
		/// <returns>The element that has the specified key.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The property is set.  
		///  -or-  
		///  The property is set, <paramref name="key" /> does not exist in the collection, and the dictionary has a fixed size.</exception>
		// Token: 0x170008AF RID: 2223
		[__DynamicallyInvokable]
		object IDictionary.this[object key]
		{
			[__DynamicallyInvokable]
			get
			{
				if (ReadOnlyDictionary<TKey, TValue>.IsCompatibleKey(key))
				{
					return this[(TKey)((object)key)];
				}
				return null;
			}
			[__DynamicallyInvokable]
			set
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
		}

		/// <summary>Copies the elements of the dictionary to an array, starting at the specified array index.</summary>
		/// <param name="array">The one-dimensional array that is the destination of the elements copied from the dictionary. The array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" /> is multidimensional.  
		/// -or-  
		/// The number of elements in the source dictionary is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.  
		/// -or-  
		/// The type of the source dictionary cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
		// Token: 0x060038ED RID: 14573 RVA: 0x000D8AC0 File Offset: 0x000D6CC0
		[__DynamicallyInvokable]
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
			}
			if (array.Rank != 1)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
			}
			if (array.GetLowerBound(0) != 0)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
			}
			if (index < 0 || index > array.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
			}
			if (array.Length - index < this.Count)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			}
			KeyValuePair<TKey, TValue>[] array2 = array as KeyValuePair<TKey, TValue>[];
			if (array2 != null)
			{
				this.m_dictionary.CopyTo(array2, index);
				return;
			}
			DictionaryEntry[] array3 = array as DictionaryEntry[];
			if (array3 != null)
			{
				using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = this.m_dictionary.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<TKey, TValue> keyValuePair = enumerator.Current;
						array3[index++] = new DictionaryEntry(keyValuePair.Key, keyValuePair.Value);
					}
					return;
				}
			}
			object[] array4 = array as object[];
			if (array4 == null)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
			try
			{
				foreach (KeyValuePair<TKey, TValue> keyValuePair2 in this.m_dictionary)
				{
					array4[index++] = new KeyValuePair<TKey, TValue>(keyValuePair2.Key, keyValuePair2.Value);
				}
			}
			catch (ArrayTypeMismatchException)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
		}

		/// <summary>Gets a value that indicates whether access to the dictionary is synchronized (thread safe).</summary>
		/// <returns>
		///   <see langword="true" /> if access to the dictionary is synchronized (thread safe); otherwise, <see langword="false" />.</returns>
		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x060038EE RID: 14574 RVA: 0x000D8C2C File Offset: 0x000D6E2C
		[__DynamicallyInvokable]
		bool ICollection.IsSynchronized
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Gets an object that can be used to synchronize access to the dictionary.</summary>
		/// <returns>An object that can be used to synchronize access to the dictionary.</returns>
		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x060038EF RID: 14575 RVA: 0x000D8C30 File Offset: 0x000D6E30
		[__DynamicallyInvokable]
		object ICollection.SyncRoot
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_syncRoot == null)
				{
					ICollection collection = this.m_dictionary as ICollection;
					if (collection != null)
					{
						this.m_syncRoot = collection.SyncRoot;
					}
					else
					{
						Interlocked.CompareExchange<object>(ref this.m_syncRoot, new object(), null);
					}
				}
				return this.m_syncRoot;
			}
		}

		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x060038F0 RID: 14576 RVA: 0x000D8C7A File Offset: 0x000D6E7A
		[__DynamicallyInvokable]
		IEnumerable<TKey> IReadOnlyDictionary<!0, !1>.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Keys;
			}
		}

		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x060038F1 RID: 14577 RVA: 0x000D8C82 File Offset: 0x000D6E82
		[__DynamicallyInvokable]
		IEnumerable<TValue> IReadOnlyDictionary<!0, !1>.Values
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Values;
			}
		}

		// Token: 0x0400187C RID: 6268
		private readonly IDictionary<TKey, TValue> m_dictionary;

		// Token: 0x0400187D RID: 6269
		[NonSerialized]
		private object m_syncRoot;

		// Token: 0x0400187E RID: 6270
		[NonSerialized]
		private ReadOnlyDictionary<TKey, TValue>.KeyCollection m_keys;

		// Token: 0x0400187F RID: 6271
		[NonSerialized]
		private ReadOnlyDictionary<TKey, TValue>.ValueCollection m_values;

		// Token: 0x02000BA6 RID: 2982
		[Serializable]
		private struct DictionaryEnumerator : IDictionaryEnumerator, IEnumerator
		{
			// Token: 0x06006DB5 RID: 28085 RVA: 0x0017967F File Offset: 0x0017787F
			public DictionaryEnumerator(IDictionary<TKey, TValue> dictionary)
			{
				this.m_dictionary = dictionary;
				this.m_enumerator = this.m_dictionary.GetEnumerator();
			}

			// Token: 0x170012E2 RID: 4834
			// (get) Token: 0x06006DB6 RID: 28086 RVA: 0x0017969C File Offset: 0x0017789C
			public DictionaryEntry Entry
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.m_enumerator.Current;
					object key = keyValuePair.Key;
					keyValuePair = this.m_enumerator.Current;
					return new DictionaryEntry(key, keyValuePair.Value);
				}
			}

			// Token: 0x170012E3 RID: 4835
			// (get) Token: 0x06006DB7 RID: 28087 RVA: 0x001796E0 File Offset: 0x001778E0
			public object Key
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.m_enumerator.Current;
					return keyValuePair.Key;
				}
			}

			// Token: 0x170012E4 RID: 4836
			// (get) Token: 0x06006DB8 RID: 28088 RVA: 0x00179708 File Offset: 0x00177908
			public object Value
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.m_enumerator.Current;
					return keyValuePair.Value;
				}
			}

			// Token: 0x170012E5 RID: 4837
			// (get) Token: 0x06006DB9 RID: 28089 RVA: 0x0017972D File Offset: 0x0017792D
			public object Current
			{
				get
				{
					return this.Entry;
				}
			}

			// Token: 0x06006DBA RID: 28090 RVA: 0x0017973A File Offset: 0x0017793A
			public bool MoveNext()
			{
				return this.m_enumerator.MoveNext();
			}

			// Token: 0x06006DBB RID: 28091 RVA: 0x00179747 File Offset: 0x00177947
			public void Reset()
			{
				this.m_enumerator.Reset();
			}

			// Token: 0x040034FC RID: 13564
			private readonly IDictionary<TKey, TValue> m_dictionary;

			// Token: 0x040034FD RID: 13565
			private IEnumerator<KeyValuePair<TKey, TValue>> m_enumerator;
		}

		/// <summary>Represents a read-only collection of the keys of a <see cref="T:System.Collections.ObjectModel.ReadOnlyDictionary`2" /> object.</summary>
		/// <typeparam name="TKey" />
		/// <typeparam name="TValue" />
		// Token: 0x02000BA7 RID: 2983
		[DebuggerTypeProxy(typeof(Mscorlib_CollectionDebugView<>))]
		[DebuggerDisplay("Count = {Count}")]
		[__DynamicallyInvokable]
		[Serializable]
		public sealed class KeyCollection : ICollection<!0>, IEnumerable<!0>, IEnumerable, ICollection, IReadOnlyCollection<TKey>
		{
			// Token: 0x06006DBC RID: 28092 RVA: 0x00179754 File Offset: 0x00177954
			internal KeyCollection(ICollection<TKey> collection)
			{
				if (collection == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
				}
				this.m_collection = collection;
			}

			// Token: 0x06006DBD RID: 28093 RVA: 0x0017976C File Offset: 0x0017796C
			[__DynamicallyInvokable]
			void ICollection<!0>.Add(TKey item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}

			// Token: 0x06006DBE RID: 28094 RVA: 0x00179775 File Offset: 0x00177975
			[__DynamicallyInvokable]
			void ICollection<!0>.Clear()
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}

			// Token: 0x06006DBF RID: 28095 RVA: 0x0017977E File Offset: 0x0017797E
			[__DynamicallyInvokable]
			bool ICollection<!0>.Contains(TKey item)
			{
				return this.m_collection.Contains(item);
			}

			/// <summary>Copies the elements of the collection to an array, starting at a specific array index.</summary>
			/// <param name="array">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
			/// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
			/// <exception cref="T:System.ArgumentNullException">
			///   <paramref name="array" /> is <see langword="null" />.</exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">
			///   <paramref name="arrayIndex" /> is less than 0.</exception>
			/// <exception cref="T:System.ArgumentException">
			///   <paramref name="array" /> is multidimensional.  
			/// -or-  
			/// The number of elements in the source collection is greater than the available space from <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.  
			/// -or-  
			/// Type <paramref name="T" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
			// Token: 0x06006DC0 RID: 28096 RVA: 0x0017978C File Offset: 0x0017798C
			[__DynamicallyInvokable]
			public void CopyTo(TKey[] array, int arrayIndex)
			{
				this.m_collection.CopyTo(array, arrayIndex);
			}

			/// <summary>Gets the number of elements in the collection.</summary>
			/// <returns>The number of elements in the collection.</returns>
			// Token: 0x170012E6 RID: 4838
			// (get) Token: 0x06006DC1 RID: 28097 RVA: 0x0017979B File Offset: 0x0017799B
			[__DynamicallyInvokable]
			public int Count
			{
				[__DynamicallyInvokable]
				get
				{
					return this.m_collection.Count;
				}
			}

			// Token: 0x170012E7 RID: 4839
			// (get) Token: 0x06006DC2 RID: 28098 RVA: 0x001797A8 File Offset: 0x001779A8
			[__DynamicallyInvokable]
			bool ICollection<!0>.IsReadOnly
			{
				[__DynamicallyInvokable]
				get
				{
					return true;
				}
			}

			// Token: 0x06006DC3 RID: 28099 RVA: 0x001797AB File Offset: 0x001779AB
			[__DynamicallyInvokable]
			bool ICollection<!0>.Remove(TKey item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
				return false;
			}

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>An enumerator that can be used to iterate through the collection.</returns>
			// Token: 0x06006DC4 RID: 28100 RVA: 0x001797B5 File Offset: 0x001779B5
			[__DynamicallyInvokable]
			public IEnumerator<TKey> GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>An enumerator that can be used to iterate through the collection.</returns>
			// Token: 0x06006DC5 RID: 28101 RVA: 0x001797C2 File Offset: 0x001779C2
			[__DynamicallyInvokable]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			/// <summary>Copies the elements of the collection to an array, starting at a specific array index.</summary>
			/// <param name="array">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
			/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
			/// <exception cref="T:System.ArgumentNullException">
			///   <paramref name="array" /> is <see langword="null" />.</exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">
			///   <paramref name="index" /> is less than 0.</exception>
			/// <exception cref="T:System.ArgumentException">
			///   <paramref name="array" /> is multidimensional.  
			/// -or-  
			/// The number of elements in the source collection is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
			// Token: 0x06006DC6 RID: 28102 RVA: 0x001797CF File Offset: 0x001779CF
			[__DynamicallyInvokable]
			void ICollection.CopyTo(Array array, int index)
			{
				ReadOnlyDictionaryHelpers.CopyToNonGenericICollectionHelper<TKey>(this.m_collection, array, index);
			}

			/// <summary>Gets a value that indicates whether access to the collection is synchronized (thread safe).</summary>
			/// <returns>
			///   <see langword="true" /> if access to the collection is synchronized (thread safe); otherwise, <see langword="false" />.</returns>
			// Token: 0x170012E8 RID: 4840
			// (get) Token: 0x06006DC7 RID: 28103 RVA: 0x001797DE File Offset: 0x001779DE
			[__DynamicallyInvokable]
			bool ICollection.IsSynchronized
			{
				[__DynamicallyInvokable]
				get
				{
					return false;
				}
			}

			/// <summary>Gets an object that can be used to synchronize access to the collection.</summary>
			/// <returns>An object that can be used to synchronize access to the collection.</returns>
			// Token: 0x170012E9 RID: 4841
			// (get) Token: 0x06006DC8 RID: 28104 RVA: 0x001797E4 File Offset: 0x001779E4
			[__DynamicallyInvokable]
			object ICollection.SyncRoot
			{
				[__DynamicallyInvokable]
				get
				{
					if (this.m_syncRoot == null)
					{
						ICollection collection = this.m_collection as ICollection;
						if (collection != null)
						{
							this.m_syncRoot = collection.SyncRoot;
						}
						else
						{
							Interlocked.CompareExchange<object>(ref this.m_syncRoot, new object(), null);
						}
					}
					return this.m_syncRoot;
				}
			}

			// Token: 0x040034FE RID: 13566
			private readonly ICollection<TKey> m_collection;

			// Token: 0x040034FF RID: 13567
			[NonSerialized]
			private object m_syncRoot;
		}

		/// <summary>Represents a read-only collection of the values of a <see cref="T:System.Collections.ObjectModel.ReadOnlyDictionary`2" /> object.</summary>
		/// <typeparam name="TKey" />
		/// <typeparam name="TValue" />
		// Token: 0x02000BA8 RID: 2984
		[DebuggerTypeProxy(typeof(Mscorlib_CollectionDebugView<>))]
		[DebuggerDisplay("Count = {Count}")]
		[__DynamicallyInvokable]
		[Serializable]
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection, IReadOnlyCollection<TValue>
		{
			// Token: 0x06006DC9 RID: 28105 RVA: 0x0017982E File Offset: 0x00177A2E
			internal ValueCollection(ICollection<TValue> collection)
			{
				if (collection == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
				}
				this.m_collection = collection;
			}

			// Token: 0x06006DCA RID: 28106 RVA: 0x00179846 File Offset: 0x00177A46
			[__DynamicallyInvokable]
			void ICollection<!1>.Add(TValue item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}

			// Token: 0x06006DCB RID: 28107 RVA: 0x0017984F File Offset: 0x00177A4F
			[__DynamicallyInvokable]
			void ICollection<!1>.Clear()
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}

			// Token: 0x06006DCC RID: 28108 RVA: 0x00179858 File Offset: 0x00177A58
			[__DynamicallyInvokable]
			bool ICollection<!1>.Contains(TValue item)
			{
				return this.m_collection.Contains(item);
			}

			/// <summary>Copies the elements of the collection to an array, starting at a specific array index.</summary>
			/// <param name="array">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
			/// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
			/// <exception cref="T:System.ArgumentNullException">
			///   <paramref name="array" /> is <see langword="null" />.</exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">
			///   <paramref name="arrayIndex" /> is less than 0.</exception>
			/// <exception cref="T:System.ArgumentException">
			///   <paramref name="array" /> is multidimensional.  
			/// -or-  
			/// The number of elements in the source collection is greater than the available space from <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.  
			/// -or-  
			/// Type <paramref name="T" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
			// Token: 0x06006DCD RID: 28109 RVA: 0x00179866 File Offset: 0x00177A66
			[__DynamicallyInvokable]
			public void CopyTo(TValue[] array, int arrayIndex)
			{
				this.m_collection.CopyTo(array, arrayIndex);
			}

			/// <summary>Gets the number of elements in the collection.</summary>
			/// <returns>The number of elements in the collection.</returns>
			// Token: 0x170012EA RID: 4842
			// (get) Token: 0x06006DCE RID: 28110 RVA: 0x00179875 File Offset: 0x00177A75
			[__DynamicallyInvokable]
			public int Count
			{
				[__DynamicallyInvokable]
				get
				{
					return this.m_collection.Count;
				}
			}

			// Token: 0x170012EB RID: 4843
			// (get) Token: 0x06006DCF RID: 28111 RVA: 0x00179882 File Offset: 0x00177A82
			[__DynamicallyInvokable]
			bool ICollection<!1>.IsReadOnly
			{
				[__DynamicallyInvokable]
				get
				{
					return true;
				}
			}

			// Token: 0x06006DD0 RID: 28112 RVA: 0x00179885 File Offset: 0x00177A85
			[__DynamicallyInvokable]
			bool ICollection<!1>.Remove(TValue item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
				return false;
			}

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>An enumerator that can be used to iterate through the collection.</returns>
			// Token: 0x06006DD1 RID: 28113 RVA: 0x0017988F File Offset: 0x00177A8F
			[__DynamicallyInvokable]
			public IEnumerator<TValue> GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>An enumerator that can be used to iterate through the collection.</returns>
			// Token: 0x06006DD2 RID: 28114 RVA: 0x0017989C File Offset: 0x00177A9C
			[__DynamicallyInvokable]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			/// <summary>Copies the elements of the collection to an array, starting at a specific array index.</summary>
			/// <param name="array">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
			/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
			/// <exception cref="T:System.ArgumentNullException">
			///   <paramref name="array" /> is <see langword="null" />.</exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">
			///   <paramref name="index" /> is less than 0.</exception>
			/// <exception cref="T:System.ArgumentException">
			///   <paramref name="array" /> is multidimensional.  
			/// -or-  
			/// The number of elements in the source collection is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
			// Token: 0x06006DD3 RID: 28115 RVA: 0x001798A9 File Offset: 0x00177AA9
			[__DynamicallyInvokable]
			void ICollection.CopyTo(Array array, int index)
			{
				ReadOnlyDictionaryHelpers.CopyToNonGenericICollectionHelper<TValue>(this.m_collection, array, index);
			}

			/// <summary>Gets a value that indicates whether access to the collection is synchronized (thread safe).</summary>
			/// <returns>
			///   <see langword="true" /> if access to the collection is synchronized (thread safe); otherwise, <see langword="false" />.</returns>
			// Token: 0x170012EC RID: 4844
			// (get) Token: 0x06006DD4 RID: 28116 RVA: 0x001798B8 File Offset: 0x00177AB8
			[__DynamicallyInvokable]
			bool ICollection.IsSynchronized
			{
				[__DynamicallyInvokable]
				get
				{
					return false;
				}
			}

			/// <summary>Gets an object that can be used to synchronize access to the collection.</summary>
			/// <returns>An object that can be used to synchronize access to the collection.</returns>
			// Token: 0x170012ED RID: 4845
			// (get) Token: 0x06006DD5 RID: 28117 RVA: 0x001798BC File Offset: 0x00177ABC
			[__DynamicallyInvokable]
			object ICollection.SyncRoot
			{
				[__DynamicallyInvokable]
				get
				{
					if (this.m_syncRoot == null)
					{
						ICollection collection = this.m_collection as ICollection;
						if (collection != null)
						{
							this.m_syncRoot = collection.SyncRoot;
						}
						else
						{
							Interlocked.CompareExchange<object>(ref this.m_syncRoot, new object(), null);
						}
					}
					return this.m_syncRoot;
				}
			}

			// Token: 0x04003500 RID: 13568
			private readonly ICollection<TValue> m_collection;

			// Token: 0x04003501 RID: 13569
			[NonSerialized]
			private object m_syncRoot;
		}
	}
}
