using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Collections.ObjectModel
{
	/// <summary>Provides the base class for a generic read-only collection.</summary>
	/// <typeparam name="T">The type of elements in the collection.</typeparam>
	// Token: 0x02000489 RID: 1161
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(Mscorlib_CollectionDebugView<>))]
	[DebuggerDisplay("Count = {Count}")]
	[__DynamicallyInvokable]
	[Serializable]
	public class ReadOnlyCollection<T> : IList<!0>, ICollection<!0>, IEnumerable<!0>, IEnumerable, IList, ICollection, IReadOnlyList<!0>, IReadOnlyCollection<T>
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> class that is a read-only wrapper around the specified list.</summary>
		/// <param name="list">The list to wrap.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="list" /> is <see langword="null" />.</exception>
		// Token: 0x060038AB RID: 14507 RVA: 0x000D8605 File Offset: 0x000D6805
		[__DynamicallyInvokable]
		public ReadOnlyCollection(IList<T> list)
		{
			if (list == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.list);
			}
			this.list = list;
		}

		/// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> instance.</summary>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> instance.</returns>
		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x060038AC RID: 14508 RVA: 0x000D861D File Offset: 0x000D681D
		[__DynamicallyInvokable]
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				return this.list.Count;
			}
		}

		/// <summary>Gets the element at the specified index.</summary>
		/// <param name="index">The zero-based index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> is equal to or greater than <see cref="P:System.Collections.ObjectModel.ReadOnlyCollection`1.Count" />.</exception>
		// Token: 0x17000899 RID: 2201
		[__DynamicallyInvokable]
		public T this[int index]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.list[index];
			}
		}

		/// <summary>Determines whether an element is in the <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />.</summary>
		/// <param name="value">The object to locate in the <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />. The value can be <see langword="null" /> for reference types.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="value" /> is found in the <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060038AE RID: 14510 RVA: 0x000D8638 File Offset: 0x000D6838
		[__DynamicallyInvokable]
		public bool Contains(T value)
		{
			return this.list.Contains(value);
		}

		/// <summary>Copies the entire <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> to a compatible one-dimensional <see cref="T:System.Array" />, starting at the specified index of the target array.</summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">The number of elements in the source <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
		// Token: 0x060038AF RID: 14511 RVA: 0x000D8646 File Offset: 0x000D6846
		[__DynamicallyInvokable]
		public void CopyTo(T[] array, int index)
		{
			this.list.CopyTo(array, index);
		}

		/// <summary>Returns an enumerator that iterates through the <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />.</summary>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerator`1" /> for the <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />.</returns>
		// Token: 0x060038B0 RID: 14512 RVA: 0x000D8655 File Offset: 0x000D6855
		[__DynamicallyInvokable]
		public IEnumerator<T> GetEnumerator()
		{
			return this.list.GetEnumerator();
		}

		/// <summary>Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />.</summary>
		/// <param name="value">The object to locate in the <see cref="T:System.Collections.Generic.List`1" />. The value can be <see langword="null" /> for reference types.</param>
		/// <returns>The zero-based index of the first occurrence of <paramref name="item" /> within the entire <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />, if found; otherwise, -1.</returns>
		// Token: 0x060038B1 RID: 14513 RVA: 0x000D8662 File Offset: 0x000D6862
		[__DynamicallyInvokable]
		public int IndexOf(T value)
		{
			return this.list.IndexOf(value);
		}

		/// <summary>Returns the <see cref="T:System.Collections.Generic.IList`1" /> that the <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> wraps.</summary>
		/// <returns>The <see cref="T:System.Collections.Generic.IList`1" /> that the <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> wraps.</returns>
		// Token: 0x1700089A RID: 2202
		// (get) Token: 0x060038B2 RID: 14514 RVA: 0x000D8670 File Offset: 0x000D6870
		[__DynamicallyInvokable]
		protected IList<T> Items
		{
			[__DynamicallyInvokable]
			get
			{
				return this.list;
			}
		}

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x060038B3 RID: 14515 RVA: 0x000D8678 File Offset: 0x000D6878
		[__DynamicallyInvokable]
		bool ICollection<!0>.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		// Token: 0x1700089C RID: 2204
		[__DynamicallyInvokable]
		T IList<!0>.this[int index]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.list[index];
			}
			[__DynamicallyInvokable]
			set
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
		}

		// Token: 0x060038B6 RID: 14518 RVA: 0x000D8692 File Offset: 0x000D6892
		[__DynamicallyInvokable]
		void ICollection<!0>.Add(T value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060038B7 RID: 14519 RVA: 0x000D869B File Offset: 0x000D689B
		[__DynamicallyInvokable]
		void ICollection<!0>.Clear()
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060038B8 RID: 14520 RVA: 0x000D86A4 File Offset: 0x000D68A4
		[__DynamicallyInvokable]
		void IList<!0>.Insert(int index, T value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060038B9 RID: 14521 RVA: 0x000D86AD File Offset: 0x000D68AD
		[__DynamicallyInvokable]
		bool ICollection<!0>.Remove(T value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			return false;
		}

		// Token: 0x060038BA RID: 14522 RVA: 0x000D86B7 File Offset: 0x000D68B7
		[__DynamicallyInvokable]
		void IList<!0>.RemoveAt(int index)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator" /> that can be used to iterate through the collection.</returns>
		// Token: 0x060038BB RID: 14523 RVA: 0x000D86C0 File Offset: 0x000D68C0
		[__DynamicallyInvokable]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.list.GetEnumerator();
		}

		/// <summary>Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).</summary>
		/// <returns>
		///   <see langword="true" /> if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, <see langword="false" />.  In the default implementation of <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />, this property always returns <see langword="false" />.</returns>
		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x060038BC RID: 14524 RVA: 0x000D86CD File Offset: 0x000D68CD
		[__DynamicallyInvokable]
		bool ICollection.IsSynchronized
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.</summary>
		/// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.  In the default implementation of <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />, this property always returns the current instance.</returns>
		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x060038BD RID: 14525 RVA: 0x000D86D0 File Offset: 0x000D68D0
		[__DynamicallyInvokable]
		object ICollection.SyncRoot
		{
			[__DynamicallyInvokable]
			get
			{
				if (this._syncRoot == null)
				{
					ICollection collection = this.list as ICollection;
					if (collection != null)
					{
						this._syncRoot = collection.SyncRoot;
					}
					else
					{
						Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
					}
				}
				return this._syncRoot;
			}
		}

		/// <summary>Copies the elements of the <see cref="T:System.Collections.ICollection" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.</summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" /> is multidimensional.  
		/// -or-  
		/// <paramref name="array" /> does not have zero-based indexing.  
		/// -or-  
		/// The number of elements in the source <see cref="T:System.Collections.ICollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.  
		/// -or-  
		/// The type of the source <see cref="T:System.Collections.ICollection" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
		// Token: 0x060038BE RID: 14526 RVA: 0x000D871C File Offset: 0x000D691C
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
			if (index < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.arrayIndex, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
			}
			if (array.Length - index < this.Count)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			}
			T[] array2 = array as T[];
			if (array2 != null)
			{
				this.list.CopyTo(array2, index);
				return;
			}
			Type elementType = array.GetType().GetElementType();
			Type typeFromHandle = typeof(T);
			if (!elementType.IsAssignableFrom(typeFromHandle) && !typeFromHandle.IsAssignableFrom(elementType))
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
			object[] array3 = array as object[];
			if (array3 == null)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
			int count = this.list.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					array3[index++] = this.list[i];
				}
			}
			catch (ArrayTypeMismatchException)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.IList" /> has a fixed size; otherwise, <see langword="false" />.  In the default implementation of <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />, this property always returns <see langword="true" />.</returns>
		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x060038BF RID: 14527 RVA: 0x000D8820 File Offset: 0x000D6A20
		[__DynamicallyInvokable]
		bool IList.IsFixedSize
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.IList" /> is read-only.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.IList" /> is read-only; otherwise, <see langword="false" />.  In the default implementation of <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />, this property always returns <see langword="true" />.</returns>
		// Token: 0x170008A0 RID: 2208
		// (get) Token: 0x060038C0 RID: 14528 RVA: 0x000D8823 File Offset: 0x000D6A23
		[__DynamicallyInvokable]
		bool IList.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		/// <summary>Gets the element at the specified index. A <see cref="T:System.NotSupportedException" /> occurs if you try to set the item at the specified index.</summary>
		/// <param name="index">The zero-based index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.IList" />.</exception>
		/// <exception cref="T:System.NotSupportedException">Always thrown if the property is set.</exception>
		// Token: 0x170008A1 RID: 2209
		[__DynamicallyInvokable]
		object IList.this[int index]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.list[index];
			}
			[__DynamicallyInvokable]
			set
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
		}

		/// <summary>Adds an item to the <see cref="T:System.Collections.IList" />.  This implementation always throws <see cref="T:System.NotSupportedException" />.</summary>
		/// <param name="value">The <see cref="T:System.Object" /> to add to the <see cref="T:System.Collections.IList" />.</param>
		/// <returns>The position into which the new element was inserted.</returns>
		/// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
		// Token: 0x060038C3 RID: 14531 RVA: 0x000D8842 File Offset: 0x000D6A42
		[__DynamicallyInvokable]
		int IList.Add(object value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			return -1;
		}

		/// <summary>Removes all items from the <see cref="T:System.Collections.IList" />.  This implementation always throws <see cref="T:System.NotSupportedException" />.</summary>
		/// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
		// Token: 0x060038C4 RID: 14532 RVA: 0x000D884C File Offset: 0x000D6A4C
		[__DynamicallyInvokable]
		void IList.Clear()
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060038C5 RID: 14533 RVA: 0x000D8858 File Offset: 0x000D6A58
		private static bool IsCompatibleObject(object value)
		{
			return value is T || (value == null && default(T) == null);
		}

		/// <summary>Determines whether the <see cref="T:System.Collections.IList" /> contains a specific value.</summary>
		/// <param name="value">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Object" /> is found in the <see cref="T:System.Collections.IList" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="value" /> is not of the type specified for the generic type parameter <paramref name="T" />.</exception>
		// Token: 0x060038C6 RID: 14534 RVA: 0x000D8885 File Offset: 0x000D6A85
		[__DynamicallyInvokable]
		bool IList.Contains(object value)
		{
			return ReadOnlyCollection<T>.IsCompatibleObject(value) && this.Contains((T)((object)value));
		}

		/// <summary>Determines the index of a specific item in the <see cref="T:System.Collections.IList" />.</summary>
		/// <param name="value">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
		/// <returns>The index of <paramref name="value" /> if found in the list; otherwise, -1.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="value" /> is not of the type specified for the generic type parameter <paramref name="T" />.</exception>
		// Token: 0x060038C7 RID: 14535 RVA: 0x000D889D File Offset: 0x000D6A9D
		[__DynamicallyInvokable]
		int IList.IndexOf(object value)
		{
			if (ReadOnlyCollection<T>.IsCompatibleObject(value))
			{
				return this.IndexOf((T)((object)value));
			}
			return -1;
		}

		/// <summary>Inserts an item to the <see cref="T:System.Collections.IList" /> at the specified index.  This implementation always throws <see cref="T:System.NotSupportedException" />.</summary>
		/// <param name="index">The zero-based index at which <paramref name="value" /> should be inserted.</param>
		/// <param name="value">The <see cref="T:System.Object" /> to insert into the <see cref="T:System.Collections.IList" />.</param>
		/// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
		// Token: 0x060038C8 RID: 14536 RVA: 0x000D88B5 File Offset: 0x000D6AB5
		[__DynamicallyInvokable]
		void IList.Insert(int index, object value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		/// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList" />.  This implementation always throws <see cref="T:System.NotSupportedException" />.</summary>
		/// <param name="value">The <see cref="T:System.Object" /> to remove from the <see cref="T:System.Collections.IList" />.</param>
		/// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
		// Token: 0x060038C9 RID: 14537 RVA: 0x000D88BE File Offset: 0x000D6ABE
		[__DynamicallyInvokable]
		void IList.Remove(object value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		/// <summary>Removes the <see cref="T:System.Collections.IList" /> item at the specified index.  This implementation always throws <see cref="T:System.NotSupportedException" />.</summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		/// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
		// Token: 0x060038CA RID: 14538 RVA: 0x000D88C7 File Offset: 0x000D6AC7
		[__DynamicallyInvokable]
		void IList.RemoveAt(int index)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x0400187A RID: 6266
		private IList<T> list;

		// Token: 0x0400187B RID: 6267
		[NonSerialized]
		private object _syncRoot;
	}
}
