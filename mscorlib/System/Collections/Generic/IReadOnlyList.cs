﻿using System;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
	/// <summary>Represents a read-only collection of elements that can be accessed by index.</summary>
	/// <typeparam name="T">The type of elements in the read-only list.</typeparam>
	// Token: 0x020004AB RID: 1195
	[TypeDependency("System.SZArrayHelper")]
	[__DynamicallyInvokable]
	public interface IReadOnlyList<out T> : IReadOnlyCollection<T>, IEnumerable<!0>, IEnumerable
	{
		/// <summary>Gets the element at the specified index in the read-only list.</summary>
		/// <param name="index">The zero-based index of the element to get.</param>
		/// <returns>The element at the specified index in the read-only list.</returns>
		// Token: 0x170008D7 RID: 2263
		[__DynamicallyInvokable]
		T this[int index]
		{
			[__DynamicallyInvokable]
			get;
		}
	}
}
