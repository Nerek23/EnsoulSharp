using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Defines size, enumerators, and synchronization methods for all nongeneric collections.</summary>
	// Token: 0x0200046D RID: 1133
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface ICollection : IEnumerable
	{
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
		/// The number of elements in the source <see cref="T:System.Collections.ICollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.  
		/// -or-  
		/// The type of the source <see cref="T:System.Collections.ICollection" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
		// Token: 0x06003788 RID: 14216
		[__DynamicallyInvokable]
		void CopyTo(Array array, int index);

		/// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.ICollection" />.</summary>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.ICollection" />.</returns>
		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x06003789 RID: 14217
		[__DynamicallyInvokable]
		int Count { [__DynamicallyInvokable] get; }

		/// <summary>Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.</summary>
		/// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.</returns>
		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x0600378A RID: 14218
		[__DynamicallyInvokable]
		object SyncRoot { [__DynamicallyInvokable] get; }

		/// <summary>Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).</summary>
		/// <returns>
		///   <see langword="true" /> if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, <see langword="false" />.</returns>
		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x0600378B RID: 14219
		[__DynamicallyInvokable]
		bool IsSynchronized { [__DynamicallyInvokable] get; }
	}
}
