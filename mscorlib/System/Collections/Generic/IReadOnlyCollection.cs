using System;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
	/// <summary>Represents a strongly-typed, read-only collection of elements.</summary>
	/// <typeparam name="T">The type of the elements.</typeparam>
	// Token: 0x020004AA RID: 1194
	[TypeDependency("System.SZArrayHelper")]
	[__DynamicallyInvokable]
	public interface IReadOnlyCollection<out T> : IEnumerable<!0>, IEnumerable
	{
		/// <summary>Gets the number of elements in the collection.</summary>
		/// <returns>The number of elements in the collection.</returns>
		// Token: 0x170008D6 RID: 2262
		// (get) Token: 0x060039BD RID: 14781
		[__DynamicallyInvokable]
		int Count { [__DynamicallyInvokable] get; }
	}
}
