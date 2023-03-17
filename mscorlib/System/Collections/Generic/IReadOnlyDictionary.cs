using System;

namespace System.Collections.Generic
{
	/// <summary>Represents a generic read-only collection of key/value pairs.</summary>
	/// <typeparam name="TKey">The type of keys in the read-only dictionary.</typeparam>
	/// <typeparam name="TValue">The type of values in the read-only dictionary.</typeparam>
	// Token: 0x020004AC RID: 1196
	[__DynamicallyInvokable]
	public interface IReadOnlyDictionary<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		/// <summary>Determines whether the read-only dictionary contains an element that has the specified key.</summary>
		/// <param name="key">The key to locate.</param>
		/// <returns>
		///   <see langword="true" /> if the read-only dictionary contains an element that has the specified key; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x060039BF RID: 14783
		[__DynamicallyInvokable]
		bool ContainsKey(TKey key);

		/// <summary>Gets the value that is associated with the specified key.</summary>
		/// <param name="key">The key to locate.</param>
		/// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value" /> parameter. This parameter is passed uninitialized.</param>
		/// <returns>
		///   <see langword="true" /> if the object that implements the <see cref="T:System.Collections.Generic.IReadOnlyDictionary`2" /> interface contains an element that has the specified key; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x060039C0 RID: 14784
		[__DynamicallyInvokable]
		bool TryGetValue(TKey key, out TValue value);

		/// <summary>Gets the element that has the specified key in the read-only dictionary.</summary>
		/// <param name="key">The key to locate.</param>
		/// <returns>The element that has the specified key in the read-only dictionary.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name="key" /> is not found.</exception>
		// Token: 0x170008D8 RID: 2264
		[__DynamicallyInvokable]
		TValue this[TKey key]
		{
			[__DynamicallyInvokable]
			get;
		}

		/// <summary>Gets an enumerable collection that contains the keys in the read-only dictionary.</summary>
		/// <returns>An enumerable collection that contains the keys in the read-only dictionary.</returns>
		// Token: 0x170008D9 RID: 2265
		// (get) Token: 0x060039C2 RID: 14786
		[__DynamicallyInvokable]
		IEnumerable<TKey> Keys { [__DynamicallyInvokable] get; }

		/// <summary>Gets an enumerable collection that contains the values in the read-only dictionary.</summary>
		/// <returns>An enumerable collection that contains the values in the read-only dictionary.</returns>
		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x060039C3 RID: 14787
		[__DynamicallyInvokable]
		IEnumerable<TValue> Values { [__DynamicallyInvokable] get; }
	}
}
