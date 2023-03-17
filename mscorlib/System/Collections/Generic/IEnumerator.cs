using System;

namespace System.Collections.Generic
{
	/// <summary>Supports a simple iteration over a generic collection.</summary>
	/// <typeparam name="T">The type of objects to enumerate.</typeparam>
	// Token: 0x020004A7 RID: 1191
	[__DynamicallyInvokable]
	public interface IEnumerator<out T> : IDisposable, IEnumerator
	{
		/// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
		/// <returns>The element in the collection at the current position of the enumerator.</returns>
		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x060039B5 RID: 14773
		[__DynamicallyInvokable]
		T Current { [__DynamicallyInvokable] get; }
	}
}
