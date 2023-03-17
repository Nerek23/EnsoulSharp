using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Represents a nongeneric collection of key/value pairs.</summary>
	// Token: 0x0200046F RID: 1135
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IDictionary : ICollection, IEnumerable
	{
		/// <summary>Gets or sets the element with the specified key.</summary>
		/// <param name="key">The key of the element to get or set.</param>
		/// <returns>The element with the specified key, or <see langword="null" /> if the key does not exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.IDictionary" /> object is read-only.  
		///  -or-  
		///  The property is set, <paramref name="key" /> does not exist in the collection, and the <see cref="T:System.Collections.IDictionary" /> has a fixed size.</exception>
		// Token: 0x17000859 RID: 2137
		[__DynamicallyInvokable]
		object this[object key]
		{
			[__DynamicallyInvokable]
			get;
			[__DynamicallyInvokable]
			set;
		}

		/// <summary>Gets an <see cref="T:System.Collections.ICollection" /> object containing the keys of the <see cref="T:System.Collections.IDictionary" /> object.</summary>
		/// <returns>An <see cref="T:System.Collections.ICollection" /> object containing the keys of the <see cref="T:System.Collections.IDictionary" /> object.</returns>
		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x0600378F RID: 14223
		[__DynamicallyInvokable]
		ICollection Keys { [__DynamicallyInvokable] get; }

		/// <summary>Gets an <see cref="T:System.Collections.ICollection" /> object containing the values in the <see cref="T:System.Collections.IDictionary" /> object.</summary>
		/// <returns>An <see cref="T:System.Collections.ICollection" /> object containing the values in the <see cref="T:System.Collections.IDictionary" /> object.</returns>
		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x06003790 RID: 14224
		[__DynamicallyInvokable]
		ICollection Values { [__DynamicallyInvokable] get; }

		/// <summary>Determines whether the <see cref="T:System.Collections.IDictionary" /> object contains an element with the specified key.</summary>
		/// <param name="key">The key to locate in the <see cref="T:System.Collections.IDictionary" /> object.</param>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.IDictionary" /> contains an element with the key; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x06003791 RID: 14225
		[__DynamicallyInvokable]
		bool Contains(object key);

		/// <summary>Adds an element with the provided key and value to the <see cref="T:System.Collections.IDictionary" /> object.</summary>
		/// <param name="key">The <see cref="T:System.Object" /> to use as the key of the element to add.</param>
		/// <param name="value">The <see cref="T:System.Object" /> to use as the value of the element to add.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">An element with the same key already exists in the <see cref="T:System.Collections.IDictionary" /> object.</exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IDictionary" /> is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.IDictionary" /> has a fixed size.</exception>
		// Token: 0x06003792 RID: 14226
		[__DynamicallyInvokable]
		void Add(object key, object value);

		/// <summary>Removes all elements from the <see cref="T:System.Collections.IDictionary" /> object.</summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IDictionary" /> object is read-only.</exception>
		// Token: 0x06003793 RID: 14227
		[__DynamicallyInvokable]
		void Clear();

		/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.IDictionary" /> object is read-only.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.IDictionary" /> object is read-only; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x06003794 RID: 14228
		[__DynamicallyInvokable]
		bool IsReadOnly { [__DynamicallyInvokable] get; }

		/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.IDictionary" /> object has a fixed size.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.IDictionary" /> object has a fixed size; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x06003795 RID: 14229
		[__DynamicallyInvokable]
		bool IsFixedSize { [__DynamicallyInvokable] get; }

		/// <summary>Returns an <see cref="T:System.Collections.IDictionaryEnumerator" /> object for the <see cref="T:System.Collections.IDictionary" /> object.</summary>
		/// <returns>An <see cref="T:System.Collections.IDictionaryEnumerator" /> object for the <see cref="T:System.Collections.IDictionary" /> object.</returns>
		// Token: 0x06003796 RID: 14230
		[__DynamicallyInvokable]
		IDictionaryEnumerator GetEnumerator();

		/// <summary>Removes the element with the specified key from the <see cref="T:System.Collections.IDictionary" /> object.</summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IDictionary" /> object is read-only.  
		///  -or-  
		///  The <see cref="T:System.Collections.IDictionary" /> has a fixed size.</exception>
		// Token: 0x06003797 RID: 14231
		[__DynamicallyInvokable]
		void Remove(object key);
	}
}
