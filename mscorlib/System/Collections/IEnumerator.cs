using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Supports a simple iteration over a non-generic collection.</summary>
	// Token: 0x02000472 RID: 1138
	[Guid("496B0ABF-CDEE-11d3-88E8-00902754C43A")]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IEnumerator
	{
		/// <summary>Advances the enumerator to the next element of the collection.</summary>
		/// <returns>
		///   <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" /> if the enumerator has passed the end of the collection.</returns>
		/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
		// Token: 0x0600379C RID: 14236
		[__DynamicallyInvokable]
		bool MoveNext();

		/// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
		/// <returns>The element in the collection at the current position of the enumerator.</returns>
		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x0600379D RID: 14237
		[__DynamicallyInvokable]
		object Current { [__DynamicallyInvokable] get; }

		/// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
		/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
		// Token: 0x0600379E RID: 14238
		[__DynamicallyInvokable]
		void Reset();
	}
}
