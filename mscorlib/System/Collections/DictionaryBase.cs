using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Provides the <see langword="abstract" /> base class for a strongly typed collection of key/value pairs.</summary>
	// Token: 0x02000460 RID: 1120
	[ComVisible(true)]
	[Serializable]
	public abstract class DictionaryBase : IDictionary, ICollection, IEnumerable
	{
		/// <summary>Gets the list of elements contained in the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <returns>A <see cref="T:System.Collections.Hashtable" /> representing the <see cref="T:System.Collections.DictionaryBase" /> instance itself.</returns>
		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x06003677 RID: 13943 RVA: 0x000D0FFD File Offset: 0x000CF1FD
		protected Hashtable InnerHashtable
		{
			get
			{
				if (this.hashtable == null)
				{
					this.hashtable = new Hashtable();
				}
				return this.hashtable;
			}
		}

		/// <summary>Gets the list of elements contained in the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <returns>An <see cref="T:System.Collections.IDictionary" /> representing the <see cref="T:System.Collections.DictionaryBase" /> instance itself.</returns>
		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x06003678 RID: 13944 RVA: 0x000D1018 File Offset: 0x000CF218
		protected IDictionary Dictionary
		{
			get
			{
				return this;
			}
		}

		/// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.DictionaryBase" /> instance.</returns>
		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x06003679 RID: 13945 RVA: 0x000D101B File Offset: 0x000CF21B
		public int Count
		{
			get
			{
				if (this.hashtable != null)
				{
					return this.hashtable.Count;
				}
				return 0;
			}
		}

		/// <summary>Gets a value indicating whether a <see cref="T:System.Collections.DictionaryBase" /> object is read-only.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.DictionaryBase" /> object is read-only; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x0600367A RID: 13946 RVA: 0x000D1032 File Offset: 0x000CF232
		bool IDictionary.IsReadOnly
		{
			get
			{
				return this.InnerHashtable.IsReadOnly;
			}
		}

		/// <summary>Gets a value indicating whether a <see cref="T:System.Collections.DictionaryBase" /> object has a fixed size.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.DictionaryBase" /> object has a fixed size; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x0600367B RID: 13947 RVA: 0x000D103F File Offset: 0x000CF23F
		bool IDictionary.IsFixedSize
		{
			get
			{
				return this.InnerHashtable.IsFixedSize;
			}
		}

		/// <summary>Gets a value indicating whether access to a <see cref="T:System.Collections.DictionaryBase" /> object is synchronized (thread safe).</summary>
		/// <returns>
		///   <see langword="true" /> if access to the <see cref="T:System.Collections.DictionaryBase" /> object is synchronized (thread safe); otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x0600367C RID: 13948 RVA: 0x000D104C File Offset: 0x000CF24C
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.InnerHashtable.IsSynchronized;
			}
		}

		/// <summary>Gets an <see cref="T:System.Collections.ICollection" /> object containing the keys in the <see cref="T:System.Collections.DictionaryBase" /> object.</summary>
		/// <returns>An <see cref="T:System.Collections.ICollection" /> object containing the keys in the <see cref="T:System.Collections.DictionaryBase" /> object.</returns>
		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x0600367D RID: 13949 RVA: 0x000D1059 File Offset: 0x000CF259
		ICollection IDictionary.Keys
		{
			get
			{
				return this.InnerHashtable.Keys;
			}
		}

		/// <summary>Gets an object that can be used to synchronize access to a <see cref="T:System.Collections.DictionaryBase" /> object.</summary>
		/// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.DictionaryBase" /> object.</returns>
		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x0600367E RID: 13950 RVA: 0x000D1066 File Offset: 0x000CF266
		object ICollection.SyncRoot
		{
			get
			{
				return this.InnerHashtable.SyncRoot;
			}
		}

		/// <summary>Gets an <see cref="T:System.Collections.ICollection" /> object containing the values in the <see cref="T:System.Collections.DictionaryBase" /> object.</summary>
		/// <returns>An <see cref="T:System.Collections.ICollection" /> object containing the values in the <see cref="T:System.Collections.DictionaryBase" /> object.</returns>
		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x0600367F RID: 13951 RVA: 0x000D1073 File Offset: 0x000CF273
		ICollection IDictionary.Values
		{
			get
			{
				return this.InnerHashtable.Values;
			}
		}

		/// <summary>Copies the <see cref="T:System.Collections.DictionaryBase" /> elements to a one-dimensional <see cref="T:System.Array" /> at the specified index.</summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the <see cref="T:System.Collections.DictionaryEntry" /> objects copied from the <see cref="T:System.Collections.DictionaryBase" /> instance. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" /> is multidimensional.  
		/// -or-  
		/// The number of elements in the source <see cref="T:System.Collections.DictionaryBase" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
		/// <exception cref="T:System.InvalidCastException">The type of the source <see cref="T:System.Collections.DictionaryBase" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
		// Token: 0x06003680 RID: 13952 RVA: 0x000D1080 File Offset: 0x000CF280
		public void CopyTo(Array array, int index)
		{
			this.InnerHashtable.CopyTo(array, index);
		}

		/// <summary>Gets or sets the value associated with the specified key.</summary>
		/// <param name="key">The key whose value to get or set.</param>
		/// <returns>The value associated with the specified key. If the specified key is not found, attempting to get it returns <see langword="null" />, and attempting to set it creates a new element using the specified key.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.DictionaryBase" /> is read-only.  
		///  -or-  
		///  The property is set, <paramref name="key" /> does not exist in the collection, and the <see cref="T:System.Collections.DictionaryBase" /> has a fixed size.</exception>
		// Token: 0x1700081E RID: 2078
		object IDictionary.this[object key]
		{
			get
			{
				object obj = this.InnerHashtable[key];
				this.OnGet(key, obj);
				return obj;
			}
			set
			{
				this.OnValidate(key, value);
				bool flag = true;
				object obj = this.InnerHashtable[key];
				if (obj == null)
				{
					flag = this.InnerHashtable.Contains(key);
				}
				this.OnSet(key, obj, value);
				this.InnerHashtable[key] = value;
				try
				{
					this.OnSetComplete(key, obj, value);
				}
				catch
				{
					if (flag)
					{
						this.InnerHashtable[key] = obj;
					}
					else
					{
						this.InnerHashtable.Remove(key);
					}
					throw;
				}
			}
		}

		/// <summary>Determines whether the <see cref="T:System.Collections.DictionaryBase" /> contains a specific key.</summary>
		/// <param name="key">The key to locate in the <see cref="T:System.Collections.DictionaryBase" />.</param>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.DictionaryBase" /> contains an element with the specified key; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x06003683 RID: 13955 RVA: 0x000D113C File Offset: 0x000CF33C
		bool IDictionary.Contains(object key)
		{
			return this.InnerHashtable.Contains(key);
		}

		/// <summary>Adds an element with the specified key and value into the <see cref="T:System.Collections.DictionaryBase" />.</summary>
		/// <param name="key">The key of the element to add.</param>
		/// <param name="value">The value of the element to add.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">An element with the same key already exists in the <see cref="T:System.Collections.DictionaryBase" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.DictionaryBase" /> is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.DictionaryBase" /> has a fixed size.</exception>
		// Token: 0x06003684 RID: 13956 RVA: 0x000D114C File Offset: 0x000CF34C
		void IDictionary.Add(object key, object value)
		{
			this.OnValidate(key, value);
			this.OnInsert(key, value);
			this.InnerHashtable.Add(key, value);
			try
			{
				this.OnInsertComplete(key, value);
			}
			catch
			{
				this.InnerHashtable.Remove(key);
				throw;
			}
		}

		/// <summary>Clears the contents of the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		// Token: 0x06003685 RID: 13957 RVA: 0x000D11A0 File Offset: 0x000CF3A0
		public void Clear()
		{
			this.OnClear();
			this.InnerHashtable.Clear();
			this.OnClearComplete();
		}

		/// <summary>Removes the element with the specified key from the <see cref="T:System.Collections.DictionaryBase" />.</summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.DictionaryBase" /> is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.DictionaryBase" /> has a fixed size.</exception>
		// Token: 0x06003686 RID: 13958 RVA: 0x000D11BC File Offset: 0x000CF3BC
		void IDictionary.Remove(object key)
		{
			if (this.InnerHashtable.Contains(key))
			{
				object value = this.InnerHashtable[key];
				this.OnValidate(key, value);
				this.OnRemove(key, value);
				this.InnerHashtable.Remove(key);
				try
				{
					this.OnRemoveComplete(key, value);
				}
				catch
				{
					this.InnerHashtable.Add(key, value);
					throw;
				}
			}
		}

		/// <summary>Returns an <see cref="T:System.Collections.IDictionaryEnumerator" /> that iterates through the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <returns>An <see cref="T:System.Collections.IDictionaryEnumerator" /> for the <see cref="T:System.Collections.DictionaryBase" /> instance.</returns>
		// Token: 0x06003687 RID: 13959 RVA: 0x000D122C File Offset: 0x000CF42C
		public IDictionaryEnumerator GetEnumerator()
		{
			return this.InnerHashtable.GetEnumerator();
		}

		/// <summary>Returns an <see cref="T:System.Collections.IEnumerator" /> that iterates through the <see cref="T:System.Collections.DictionaryBase" />.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator" /> for the <see cref="T:System.Collections.DictionaryBase" />.</returns>
		// Token: 0x06003688 RID: 13960 RVA: 0x000D1239 File Offset: 0x000CF439
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.InnerHashtable.GetEnumerator();
		}

		/// <summary>Gets the element with the specified key and value in the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <param name="key">The key of the element to get.</param>
		/// <param name="currentValue">The current value of the element associated with <paramref name="key" />.</param>
		/// <returns>An <see cref="T:System.Object" /> containing the element with the specified key and value.</returns>
		// Token: 0x06003689 RID: 13961 RVA: 0x000D1246 File Offset: 0x000CF446
		protected virtual object OnGet(object key, object currentValue)
		{
			return currentValue;
		}

		/// <summary>Performs additional custom processes before setting a value in the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <param name="key">The key of the element to locate.</param>
		/// <param name="oldValue">The old value of the element associated with <paramref name="key" />.</param>
		/// <param name="newValue">The new value of the element associated with <paramref name="key" />.</param>
		// Token: 0x0600368A RID: 13962 RVA: 0x000D1249 File Offset: 0x000CF449
		protected virtual void OnSet(object key, object oldValue, object newValue)
		{
		}

		/// <summary>Performs additional custom processes before inserting a new element into the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <param name="key">The key of the element to insert.</param>
		/// <param name="value">The value of the element to insert.</param>
		// Token: 0x0600368B RID: 13963 RVA: 0x000D124B File Offset: 0x000CF44B
		protected virtual void OnInsert(object key, object value)
		{
		}

		/// <summary>Performs additional custom processes before clearing the contents of the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		// Token: 0x0600368C RID: 13964 RVA: 0x000D124D File Offset: 0x000CF44D
		protected virtual void OnClear()
		{
		}

		/// <summary>Performs additional custom processes before removing an element from the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <param name="value">The value of the element to remove.</param>
		// Token: 0x0600368D RID: 13965 RVA: 0x000D124F File Offset: 0x000CF44F
		protected virtual void OnRemove(object key, object value)
		{
		}

		/// <summary>Performs additional custom processes when validating the element with the specified key and value.</summary>
		/// <param name="key">The key of the element to validate.</param>
		/// <param name="value">The value of the element to validate.</param>
		// Token: 0x0600368E RID: 13966 RVA: 0x000D1251 File Offset: 0x000CF451
		protected virtual void OnValidate(object key, object value)
		{
		}

		/// <summary>Performs additional custom processes after setting a value in the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <param name="key">The key of the element to locate.</param>
		/// <param name="oldValue">The old value of the element associated with <paramref name="key" />.</param>
		/// <param name="newValue">The new value of the element associated with <paramref name="key" />.</param>
		// Token: 0x0600368F RID: 13967 RVA: 0x000D1253 File Offset: 0x000CF453
		protected virtual void OnSetComplete(object key, object oldValue, object newValue)
		{
		}

		/// <summary>Performs additional custom processes after inserting a new element into the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <param name="key">The key of the element to insert.</param>
		/// <param name="value">The value of the element to insert.</param>
		// Token: 0x06003690 RID: 13968 RVA: 0x000D1255 File Offset: 0x000CF455
		protected virtual void OnInsertComplete(object key, object value)
		{
		}

		/// <summary>Performs additional custom processes after clearing the contents of the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		// Token: 0x06003691 RID: 13969 RVA: 0x000D1257 File Offset: 0x000CF457
		protected virtual void OnClearComplete()
		{
		}

		/// <summary>Performs additional custom processes after removing an element from the <see cref="T:System.Collections.DictionaryBase" /> instance.</summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <param name="value">The value of the element to remove.</param>
		// Token: 0x06003692 RID: 13970 RVA: 0x000D1259 File Offset: 0x000CF459
		protected virtual void OnRemoveComplete(object key, object value)
		{
		}

		// Token: 0x040017FE RID: 6142
		private Hashtable hashtable;
	}
}
