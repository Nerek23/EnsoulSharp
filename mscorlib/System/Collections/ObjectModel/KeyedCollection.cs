using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Collections.ObjectModel
{
	/// <summary>Provides the abstract base class for a collection whose keys are embedded in the values.</summary>
	/// <typeparam name="TKey">The type of keys in the collection.</typeparam>
	/// <typeparam name="TItem">The type of items in the collection.</typeparam>
	// Token: 0x0200048C RID: 1164
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(Mscorlib_KeyedCollectionDebugView<, >))]
	[DebuggerDisplay("Count = {Count}")]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class KeyedCollection<TKey, TItem> : Collection<TItem>
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" /> class that uses the default equality comparer.</summary>
		// Token: 0x060038F3 RID: 14579 RVA: 0x000D8DB0 File Offset: 0x000D6FB0
		[__DynamicallyInvokable]
		protected KeyedCollection() : this(null, 0)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" /> class that uses the specified equality comparer.</summary>
		/// <param name="comparer">The implementation of the <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> generic interface to use when comparing keys, or <see langword="null" /> to use the default equality comparer for the type of the key, obtained from <see cref="P:System.Collections.Generic.EqualityComparer`1.Default" />.</param>
		// Token: 0x060038F4 RID: 14580 RVA: 0x000D8DBA File Offset: 0x000D6FBA
		[__DynamicallyInvokable]
		protected KeyedCollection(IEqualityComparer<TKey> comparer) : this(comparer, 0)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" /> class that uses the specified equality comparer and creates a lookup dictionary when the specified threshold is exceeded.</summary>
		/// <param name="comparer">The implementation of the <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> generic interface to use when comparing keys, or <see langword="null" /> to use the default equality comparer for the type of the key, obtained from <see cref="P:System.Collections.Generic.EqualityComparer`1.Default" />.</param>
		/// <param name="dictionaryCreationThreshold">The number of elements the collection can hold without creating a lookup dictionary (0 creates the lookup dictionary when the first item is added), or -1 to specify that a lookup dictionary is never created.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="dictionaryCreationThreshold" /> is less than -1.</exception>
		// Token: 0x060038F5 RID: 14581 RVA: 0x000D8DC4 File Offset: 0x000D6FC4
		[__DynamicallyInvokable]
		protected KeyedCollection(IEqualityComparer<TKey> comparer, int dictionaryCreationThreshold)
		{
			if (comparer == null)
			{
				comparer = EqualityComparer<TKey>.Default;
			}
			if (dictionaryCreationThreshold == -1)
			{
				dictionaryCreationThreshold = int.MaxValue;
			}
			if (dictionaryCreationThreshold < -1)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.dictionaryCreationThreshold, ExceptionResource.ArgumentOutOfRange_InvalidThreshold);
			}
			this.comparer = comparer;
			this.threshold = dictionaryCreationThreshold;
		}

		/// <summary>Gets the generic equality comparer that is used to determine equality of keys in the collection.</summary>
		/// <returns>The implementation of the <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> generic interface that is used to determine equality of keys in the collection.</returns>
		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x060038F6 RID: 14582 RVA: 0x000D8DFB File Offset: 0x000D6FFB
		[__DynamicallyInvokable]
		public IEqualityComparer<TKey> Comparer
		{
			[__DynamicallyInvokable]
			get
			{
				return this.comparer;
			}
		}

		/// <summary>Gets the element with the specified key.</summary>
		/// <param name="key">The key of the element to get.</param>
		/// <returns>The element with the specified key. If an element with the specified key is not found, an exception is thrown.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Collections.Generic.KeyNotFoundException">An element with the specified key does not exist in the collection.</exception>
		// Token: 0x170008B5 RID: 2229
		[__DynamicallyInvokable]
		public TItem this[TKey key]
		{
			[__DynamicallyInvokable]
			get
			{
				if (key == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
				}
				if (this.dict != null)
				{
					return this.dict[key];
				}
				foreach (TItem titem in base.Items)
				{
					if (this.comparer.Equals(this.GetKeyForItem(titem), key))
					{
						return titem;
					}
				}
				ThrowHelper.ThrowKeyNotFoundException();
				return default(TItem);
			}
		}

		/// <summary>Determines whether the collection contains an element with the specified key.</summary>
		/// <param name="key">The key to locate in the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" />.</param>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" /> contains an element with the specified key; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x060038F8 RID: 14584 RVA: 0x000D8E98 File Offset: 0x000D7098
		[__DynamicallyInvokable]
		public bool Contains(TKey key)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			if (this.dict != null)
			{
				return this.dict.ContainsKey(key);
			}
			if (key != null)
			{
				foreach (TItem item in base.Items)
				{
					if (this.comparer.Equals(this.GetKeyForItem(item), key))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x060038F9 RID: 14585 RVA: 0x000D8F28 File Offset: 0x000D7128
		private bool ContainsItem(TItem item)
		{
			TKey keyForItem;
			if (this.dict == null || (keyForItem = this.GetKeyForItem(item)) == null)
			{
				return base.Items.Contains(item);
			}
			TItem x;
			bool flag = this.dict.TryGetValue(keyForItem, out x);
			return flag && EqualityComparer<TItem>.Default.Equals(x, item);
		}

		/// <summary>Removes the element with the specified key from the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" />.</summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <returns>
		///   <see langword="true" /> if the element is successfully removed; otherwise, <see langword="false" />.  This method also returns <see langword="false" /> if <paramref name="key" /> is not found in the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x060038FA RID: 14586 RVA: 0x000D8F7C File Offset: 0x000D717C
		[__DynamicallyInvokable]
		public bool Remove(TKey key)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			if (this.dict != null)
			{
				return this.dict.ContainsKey(key) && base.Remove(this.dict[key]);
			}
			if (key != null)
			{
				for (int i = 0; i < base.Items.Count; i++)
				{
					if (this.comparer.Equals(this.GetKeyForItem(base.Items[i]), key))
					{
						this.RemoveItem(i);
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>Gets the lookup dictionary of the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" />.</summary>
		/// <returns>The lookup dictionary of the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" />, if it exists; otherwise, <see langword="null" />.</returns>
		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x060038FB RID: 14587 RVA: 0x000D900A File Offset: 0x000D720A
		[__DynamicallyInvokable]
		protected IDictionary<TKey, TItem> Dictionary
		{
			[__DynamicallyInvokable]
			get
			{
				return this.dict;
			}
		}

		/// <summary>Changes the key associated with the specified element in the lookup dictionary.</summary>
		/// <param name="item">The element to change the key of.</param>
		/// <param name="newKey">The new key for <paramref name="item" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="item" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="item" /> is not found.  
		/// -or-  
		/// <paramref name="key" /> already exists in the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" />.</exception>
		// Token: 0x060038FC RID: 14588 RVA: 0x000D9014 File Offset: 0x000D7214
		[__DynamicallyInvokable]
		protected void ChangeItemKey(TItem item, TKey newKey)
		{
			if (!this.ContainsItem(item))
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_ItemNotExist);
			}
			TKey keyForItem = this.GetKeyForItem(item);
			if (!this.comparer.Equals(keyForItem, newKey))
			{
				if (newKey != null)
				{
					this.AddKey(newKey, item);
				}
				if (keyForItem != null)
				{
					this.RemoveKey(keyForItem);
				}
			}
		}

		/// <summary>Removes all elements from the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" />.</summary>
		// Token: 0x060038FD RID: 14589 RVA: 0x000D9067 File Offset: 0x000D7267
		[__DynamicallyInvokable]
		protected override void ClearItems()
		{
			base.ClearItems();
			if (this.dict != null)
			{
				this.dict.Clear();
			}
			this.keyCount = 0;
		}

		/// <summary>When implemented in a derived class, extracts the key from the specified element.</summary>
		/// <param name="item">The element from which to extract the key.</param>
		/// <returns>The key for the specified element.</returns>
		// Token: 0x060038FE RID: 14590
		[__DynamicallyInvokable]
		protected abstract TKey GetKeyForItem(TItem item);

		/// <summary>Inserts an element into the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" /> at the specified index.</summary>
		/// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
		/// <param name="item">The object to insert.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than 0.  
		/// -or-  
		/// <paramref name="index" /> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.</exception>
		// Token: 0x060038FF RID: 14591 RVA: 0x000D908C File Offset: 0x000D728C
		[__DynamicallyInvokable]
		protected override void InsertItem(int index, TItem item)
		{
			TKey keyForItem = this.GetKeyForItem(item);
			if (keyForItem != null)
			{
				this.AddKey(keyForItem, item);
			}
			base.InsertItem(index, item);
		}

		/// <summary>Removes the element at the specified index of the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2" />.</summary>
		/// <param name="index">The index of the element to remove.</param>
		// Token: 0x06003900 RID: 14592 RVA: 0x000D90BC File Offset: 0x000D72BC
		[__DynamicallyInvokable]
		protected override void RemoveItem(int index)
		{
			TKey keyForItem = this.GetKeyForItem(base.Items[index]);
			if (keyForItem != null)
			{
				this.RemoveKey(keyForItem);
			}
			base.RemoveItem(index);
		}

		/// <summary>Replaces the item at the specified index with the specified item.</summary>
		/// <param name="index">The zero-based index of the item to be replaced.</param>
		/// <param name="item">The new item.</param>
		// Token: 0x06003901 RID: 14593 RVA: 0x000D90F4 File Offset: 0x000D72F4
		[__DynamicallyInvokable]
		protected override void SetItem(int index, TItem item)
		{
			TKey keyForItem = this.GetKeyForItem(item);
			TKey keyForItem2 = this.GetKeyForItem(base.Items[index]);
			if (this.comparer.Equals(keyForItem2, keyForItem))
			{
				if (keyForItem != null && this.dict != null)
				{
					this.dict[keyForItem] = item;
				}
			}
			else
			{
				if (keyForItem != null)
				{
					this.AddKey(keyForItem, item);
				}
				if (keyForItem2 != null)
				{
					this.RemoveKey(keyForItem2);
				}
			}
			base.SetItem(index, item);
		}

		// Token: 0x06003902 RID: 14594 RVA: 0x000D9174 File Offset: 0x000D7374
		private void AddKey(TKey key, TItem item)
		{
			if (this.dict != null)
			{
				this.dict.Add(key, item);
				return;
			}
			if (this.keyCount == this.threshold)
			{
				this.CreateDictionary();
				this.dict.Add(key, item);
				return;
			}
			if (this.Contains(key))
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_AddingDuplicate);
			}
			this.keyCount++;
		}

		// Token: 0x06003903 RID: 14595 RVA: 0x000D91D8 File Offset: 0x000D73D8
		private void CreateDictionary()
		{
			this.dict = new Dictionary<TKey, TItem>(this.comparer);
			foreach (TItem titem in base.Items)
			{
				TKey keyForItem = this.GetKeyForItem(titem);
				if (keyForItem != null)
				{
					this.dict.Add(keyForItem, titem);
				}
			}
		}

		// Token: 0x06003904 RID: 14596 RVA: 0x000D924C File Offset: 0x000D744C
		private void RemoveKey(TKey key)
		{
			if (this.dict != null)
			{
				this.dict.Remove(key);
				return;
			}
			this.keyCount--;
		}

		// Token: 0x04001880 RID: 6272
		private const int defaultThreshold = 0;

		// Token: 0x04001881 RID: 6273
		private IEqualityComparer<TKey> comparer;

		// Token: 0x04001882 RID: 6274
		private Dictionary<TKey, TItem> dict;

		// Token: 0x04001883 RID: 6275
		private int keyCount;

		// Token: 0x04001884 RID: 6276
		private int threshold;
	}
}
