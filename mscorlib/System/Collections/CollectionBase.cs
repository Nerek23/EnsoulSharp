using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Provides the <see langword="abstract" /> base class for a strongly typed collection.</summary>
	// Token: 0x0200045F RID: 1119
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class CollectionBase : IList, ICollection, IEnumerable
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.CollectionBase" /> class with the default initial capacity.</summary>
		// Token: 0x06003658 RID: 13912 RVA: 0x000D0C5A File Offset: 0x000CEE5A
		protected CollectionBase()
		{
			this.list = new ArrayList();
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.CollectionBase" /> class with the specified capacity.</summary>
		/// <param name="capacity">The number of elements that the new list can initially store.</param>
		// Token: 0x06003659 RID: 13913 RVA: 0x000D0C6D File Offset: 0x000CEE6D
		protected CollectionBase(int capacity)
		{
			this.list = new ArrayList(capacity);
		}

		/// <summary>Gets an <see cref="T:System.Collections.ArrayList" /> containing the list of elements in the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		/// <returns>An <see cref="T:System.Collections.ArrayList" /> representing the <see cref="T:System.Collections.CollectionBase" /> instance itself.  
		///  Retrieving the value of this property is an O(1) operation.</returns>
		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x0600365A RID: 13914 RVA: 0x000D0C81 File Offset: 0x000CEE81
		protected ArrayList InnerList
		{
			get
			{
				if (this.list == null)
				{
					this.list = new ArrayList();
				}
				return this.list;
			}
		}

		/// <summary>Gets an <see cref="T:System.Collections.IList" /> containing the list of elements in the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		/// <returns>An <see cref="T:System.Collections.IList" /> representing the <see cref="T:System.Collections.CollectionBase" /> instance itself.</returns>
		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x0600365B RID: 13915 RVA: 0x000D0C9C File Offset: 0x000CEE9C
		protected IList List
		{
			get
			{
				return this;
			}
		}

		/// <summary>Gets or sets the number of elements that the <see cref="T:System.Collections.CollectionBase" /> can contain.</summary>
		/// <returns>The number of elements that the <see cref="T:System.Collections.CollectionBase" /> can contain.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <see cref="P:System.Collections.CollectionBase.Capacity" /> is set to a value that is less than <see cref="P:System.Collections.CollectionBase.Count" />.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is not enough memory available on the system.</exception>
		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x0600365C RID: 13916 RVA: 0x000D0C9F File Offset: 0x000CEE9F
		// (set) Token: 0x0600365D RID: 13917 RVA: 0x000D0CAC File Offset: 0x000CEEAC
		[ComVisible(false)]
		public int Capacity
		{
			get
			{
				return this.InnerList.Capacity;
			}
			set
			{
				this.InnerList.Capacity = value;
			}
		}

		/// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.CollectionBase" /> instance. This property cannot be overridden.</summary>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.CollectionBase" /> instance.  
		///  Retrieving the value of this property is an O(1) operation.</returns>
		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x0600365E RID: 13918 RVA: 0x000D0CBA File Offset: 0x000CEEBA
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.list != null)
				{
					return this.list.Count;
				}
				return 0;
			}
		}

		/// <summary>Removes all objects from the <see cref="T:System.Collections.CollectionBase" /> instance. This method cannot be overridden.</summary>
		// Token: 0x0600365F RID: 13919 RVA: 0x000D0CD1 File Offset: 0x000CEED1
		[__DynamicallyInvokable]
		public void Clear()
		{
			this.OnClear();
			this.InnerList.Clear();
			this.OnClearComplete();
		}

		/// <summary>Removes the element at the specified index of the <see cref="T:System.Collections.CollectionBase" /> instance. This method is not overridable.</summary>
		/// <param name="index">The zero-based index of the element to remove.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> is equal to or greater than <see cref="P:System.Collections.CollectionBase.Count" />.</exception>
		// Token: 0x06003660 RID: 13920 RVA: 0x000D0CEC File Offset: 0x000CEEEC
		[__DynamicallyInvokable]
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			object value = this.InnerList[index];
			this.OnValidate(value);
			this.OnRemove(index, value);
			this.InnerList.RemoveAt(index);
			try
			{
				this.OnRemoveComplete(index, value);
			}
			catch
			{
				this.InnerList.Insert(index, value);
				throw;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.CollectionBase" /> is read-only.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.CollectionBase" /> is read-only; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x06003661 RID: 13921 RVA: 0x000D0D70 File Offset: 0x000CEF70
		bool IList.IsReadOnly
		{
			get
			{
				return this.InnerList.IsReadOnly;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.CollectionBase" /> has a fixed size.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.CollectionBase" /> has a fixed size; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x06003662 RID: 13922 RVA: 0x000D0D7D File Offset: 0x000CEF7D
		bool IList.IsFixedSize
		{
			get
			{
				return this.InnerList.IsFixedSize;
			}
		}

		/// <summary>Gets a value indicating whether access to the <see cref="T:System.Collections.CollectionBase" /> is synchronized (thread safe).</summary>
		/// <returns>
		///   <see langword="true" /> if access to the <see cref="T:System.Collections.CollectionBase" /> is synchronized (thread safe); otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x06003663 RID: 13923 RVA: 0x000D0D8A File Offset: 0x000CEF8A
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.InnerList.IsSynchronized;
			}
		}

		/// <summary>Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.CollectionBase" />.</summary>
		/// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.CollectionBase" />.</returns>
		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x06003664 RID: 13924 RVA: 0x000D0D97 File Offset: 0x000CEF97
		object ICollection.SyncRoot
		{
			get
			{
				return this.InnerList.SyncRoot;
			}
		}

		/// <summary>Copies the entire <see cref="T:System.Collections.CollectionBase" /> to a compatible one-dimensional <see cref="T:System.Array" />, starting at the specified index of the target array.</summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.CollectionBase" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" /> is multidimensional.  
		/// -or-  
		/// The number of elements in the source <see cref="T:System.Collections.CollectionBase" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
		/// <exception cref="T:System.InvalidCastException">The type of the source <see cref="T:System.Collections.CollectionBase" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
		// Token: 0x06003665 RID: 13925 RVA: 0x000D0DA4 File Offset: 0x000CEFA4
		void ICollection.CopyTo(Array array, int index)
		{
			this.InnerList.CopyTo(array, index);
		}

		/// <summary>Gets or sets the element at the specified index.</summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> is equal to or greater than <see cref="P:System.Collections.CollectionBase.Count" />.</exception>
		// Token: 0x17000814 RID: 2068
		object IList.this[int index]
		{
			get
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				return this.InnerList[index];
			}
			set
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				this.OnValidate(value);
				object obj = this.InnerList[index];
				this.OnSet(index, obj, value);
				this.InnerList[index] = value;
				try
				{
					this.OnSetComplete(index, obj, value);
				}
				catch
				{
					this.InnerList[index] = obj;
					throw;
				}
			}
		}

		/// <summary>Determines whether the <see cref="T:System.Collections.CollectionBase" /> contains a specific element.</summary>
		/// <param name="value">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.CollectionBase" />.</param>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.CollectionBase" /> contains the specified <paramref name="value" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003668 RID: 13928 RVA: 0x000D0E68 File Offset: 0x000CF068
		bool IList.Contains(object value)
		{
			return this.InnerList.Contains(value);
		}

		/// <summary>Adds an object to the end of the <see cref="T:System.Collections.CollectionBase" />.</summary>
		/// <param name="value">The <see cref="T:System.Object" /> to be added to the end of the <see cref="T:System.Collections.CollectionBase" />.</param>
		/// <returns>The <see cref="T:System.Collections.CollectionBase" /> index at which the <paramref name="value" /> has been added.</returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.CollectionBase" /> is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.CollectionBase" /> has a fixed size.</exception>
		// Token: 0x06003669 RID: 13929 RVA: 0x000D0E78 File Offset: 0x000CF078
		int IList.Add(object value)
		{
			this.OnValidate(value);
			this.OnInsert(this.InnerList.Count, value);
			int num = this.InnerList.Add(value);
			try
			{
				this.OnInsertComplete(num, value);
			}
			catch
			{
				this.InnerList.RemoveAt(num);
				throw;
			}
			return num;
		}

		/// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.CollectionBase" />.</summary>
		/// <param name="value">The <see cref="T:System.Object" /> to remove from the <see cref="T:System.Collections.CollectionBase" />.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="value" /> parameter was not found in the <see cref="T:System.Collections.CollectionBase" /> object.</exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.CollectionBase" /> is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.CollectionBase" /> has a fixed size.</exception>
		// Token: 0x0600366A RID: 13930 RVA: 0x000D0ED8 File Offset: 0x000CF0D8
		void IList.Remove(object value)
		{
			this.OnValidate(value);
			int num = this.InnerList.IndexOf(value);
			if (num < 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_RemoveArgNotFound"));
			}
			this.OnRemove(num, value);
			this.InnerList.RemoveAt(num);
			try
			{
				this.OnRemoveComplete(num, value);
			}
			catch
			{
				this.InnerList.Insert(num, value);
				throw;
			}
		}

		/// <summary>Searches for the specified <see cref="T:System.Object" /> and returns the zero-based index of the first occurrence within the entire <see cref="T:System.Collections.CollectionBase" />.</summary>
		/// <param name="value">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.CollectionBase" />.</param>
		/// <returns>The zero-based index of the first occurrence of <paramref name="value" /> within the entire <see cref="T:System.Collections.CollectionBase" />, if found; otherwise, -1.</returns>
		// Token: 0x0600366B RID: 13931 RVA: 0x000D0F4C File Offset: 0x000CF14C
		int IList.IndexOf(object value)
		{
			return this.InnerList.IndexOf(value);
		}

		/// <summary>Inserts an element into the <see cref="T:System.Collections.CollectionBase" /> at the specified index.</summary>
		/// <param name="index">The zero-based index at which <paramref name="value" /> should be inserted.</param>
		/// <param name="value">The <see cref="T:System.Object" /> to insert.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> is greater than <see cref="P:System.Collections.CollectionBase.Count" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.CollectionBase" /> is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.CollectionBase" /> has a fixed size.</exception>
		// Token: 0x0600366C RID: 13932 RVA: 0x000D0F5C File Offset: 0x000CF15C
		void IList.Insert(int index, object value)
		{
			if (index < 0 || index > this.Count)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			this.OnValidate(value);
			this.OnInsert(index, value);
			this.InnerList.Insert(index, value);
			try
			{
				this.OnInsertComplete(index, value);
			}
			catch
			{
				this.InnerList.RemoveAt(index);
				throw;
			}
		}

		/// <summary>Returns an enumerator that iterates through the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator" /> for the <see cref="T:System.Collections.CollectionBase" /> instance.</returns>
		// Token: 0x0600366D RID: 13933 RVA: 0x000D0FD0 File Offset: 0x000CF1D0
		[__DynamicallyInvokable]
		public IEnumerator GetEnumerator()
		{
			return this.InnerList.GetEnumerator();
		}

		/// <summary>Performs additional custom processes before setting a value in the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		/// <param name="index">The zero-based index at which <paramref name="oldValue" /> can be found.</param>
		/// <param name="oldValue">The value to replace with <paramref name="newValue" />.</param>
		/// <param name="newValue">The new value of the element at <paramref name="index" />.</param>
		// Token: 0x0600366E RID: 13934 RVA: 0x000D0FDD File Offset: 0x000CF1DD
		protected virtual void OnSet(int index, object oldValue, object newValue)
		{
		}

		/// <summary>Performs additional custom processes before inserting a new element into the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		/// <param name="index">The zero-based index at which to insert <paramref name="value" />.</param>
		/// <param name="value">The new value of the element at <paramref name="index" />.</param>
		// Token: 0x0600366F RID: 13935 RVA: 0x000D0FDF File Offset: 0x000CF1DF
		protected virtual void OnInsert(int index, object value)
		{
		}

		/// <summary>Performs additional custom processes when clearing the contents of the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		// Token: 0x06003670 RID: 13936 RVA: 0x000D0FE1 File Offset: 0x000CF1E1
		protected virtual void OnClear()
		{
		}

		/// <summary>Performs additional custom processes when removing an element from the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		/// <param name="index">The zero-based index at which <paramref name="value" /> can be found.</param>
		/// <param name="value">The value of the element to remove from <paramref name="index" />.</param>
		// Token: 0x06003671 RID: 13937 RVA: 0x000D0FE3 File Offset: 0x000CF1E3
		protected virtual void OnRemove(int index, object value)
		{
		}

		/// <summary>Performs additional custom processes when validating a value.</summary>
		/// <param name="value">The object to validate.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		// Token: 0x06003672 RID: 13938 RVA: 0x000D0FE5 File Offset: 0x000CF1E5
		protected virtual void OnValidate(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
		}

		/// <summary>Performs additional custom processes after setting a value in the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		/// <param name="index">The zero-based index at which <paramref name="oldValue" /> can be found.</param>
		/// <param name="oldValue">The value to replace with <paramref name="newValue" />.</param>
		/// <param name="newValue">The new value of the element at <paramref name="index" />.</param>
		// Token: 0x06003673 RID: 13939 RVA: 0x000D0FF5 File Offset: 0x000CF1F5
		protected virtual void OnSetComplete(int index, object oldValue, object newValue)
		{
		}

		/// <summary>Performs additional custom processes after inserting a new element into the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		/// <param name="index">The zero-based index at which to insert <paramref name="value" />.</param>
		/// <param name="value">The new value of the element at <paramref name="index" />.</param>
		// Token: 0x06003674 RID: 13940 RVA: 0x000D0FF7 File Offset: 0x000CF1F7
		protected virtual void OnInsertComplete(int index, object value)
		{
		}

		/// <summary>Performs additional custom processes after clearing the contents of the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		// Token: 0x06003675 RID: 13941 RVA: 0x000D0FF9 File Offset: 0x000CF1F9
		protected virtual void OnClearComplete()
		{
		}

		/// <summary>Performs additional custom processes after removing an element from the <see cref="T:System.Collections.CollectionBase" /> instance.</summary>
		/// <param name="index">The zero-based index at which <paramref name="value" /> can be found.</param>
		/// <param name="value">The value of the element to remove from <paramref name="index" />.</param>
		// Token: 0x06003676 RID: 13942 RVA: 0x000D0FFB File Offset: 0x000CF1FB
		protected virtual void OnRemoveComplete(int index, object value)
		{
		}

		// Token: 0x040017FD RID: 6141
		private ArrayList list;
	}
}
