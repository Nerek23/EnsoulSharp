﻿using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Represents a non-generic collection of objects that can be individually accessed by index.</summary>
	// Token: 0x02000475 RID: 1141
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IList : ICollection, IEnumerable
	{
		/// <summary>Gets or sets the element at the specified index.</summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.IList" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.IList" /> is read-only.</exception>
		// Token: 0x17000862 RID: 2146
		[__DynamicallyInvokable]
		object this[int index]
		{
			[__DynamicallyInvokable]
			get;
			[__DynamicallyInvokable]
			set;
		}

		/// <summary>Adds an item to the <see cref="T:System.Collections.IList" />.</summary>
		/// <param name="value">The object to add to the <see cref="T:System.Collections.IList" />.</param>
		/// <returns>The position into which the new element was inserted, or -1 to indicate that the item was not inserted into the collection.</returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.IList" /> has a fixed size.</exception>
		// Token: 0x060037A4 RID: 14244
		[__DynamicallyInvokable]
		int Add(object value);

		/// <summary>Determines whether the <see cref="T:System.Collections.IList" /> contains a specific value.</summary>
		/// <param name="value">The object to locate in the <see cref="T:System.Collections.IList" />.</param>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Object" /> is found in the <see cref="T:System.Collections.IList" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060037A5 RID: 14245
		[__DynamicallyInvokable]
		bool Contains(object value);

		/// <summary>Removes all items from the <see cref="T:System.Collections.IList" />.</summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.</exception>
		// Token: 0x060037A6 RID: 14246
		[__DynamicallyInvokable]
		void Clear();

		/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.IList" /> is read-only.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.IList" /> is read-only; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x060037A7 RID: 14247
		[__DynamicallyInvokable]
		bool IsReadOnly { [__DynamicallyInvokable] get; }

		/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.IList" /> has a fixed size; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x060037A8 RID: 14248
		[__DynamicallyInvokable]
		bool IsFixedSize { [__DynamicallyInvokable] get; }

		/// <summary>Determines the index of a specific item in the <see cref="T:System.Collections.IList" />.</summary>
		/// <param name="value">The object to locate in the <see cref="T:System.Collections.IList" />.</param>
		/// <returns>The index of <paramref name="value" /> if found in the list; otherwise, -1.</returns>
		// Token: 0x060037A9 RID: 14249
		[__DynamicallyInvokable]
		int IndexOf(object value);

		/// <summary>Inserts an item to the <see cref="T:System.Collections.IList" /> at the specified index.</summary>
		/// <param name="index">The zero-based index at which <paramref name="value" /> should be inserted.</param>
		/// <param name="value">The object to insert into the <see cref="T:System.Collections.IList" />.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.IList" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.IList" /> has a fixed size.</exception>
		/// <exception cref="T:System.NullReferenceException">
		///   <paramref name="value" /> is null reference in the <see cref="T:System.Collections.IList" />.</exception>
		// Token: 0x060037AA RID: 14250
		[__DynamicallyInvokable]
		void Insert(int index, object value);

		/// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList" />.</summary>
		/// <param name="value">The object to remove from the <see cref="T:System.Collections.IList" />.</param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.IList" /> has a fixed size.</exception>
		// Token: 0x060037AB RID: 14251
		[__DynamicallyInvokable]
		void Remove(object value);

		/// <summary>Removes the <see cref="T:System.Collections.IList" /> item at the specified index.</summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.IList" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.IList" /> has a fixed size.</exception>
		// Token: 0x060037AC RID: 14252
		[__DynamicallyInvokable]
		void RemoveAt(int index);
	}
}
