﻿using System;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
	/// <summary>Exposes the enumerator, which supports a simple iteration over a collection of a specified type.</summary>
	/// <typeparam name="T">The type of objects to enumerate.</typeparam>
	// Token: 0x020004A6 RID: 1190
	[TypeDependency("System.SZArrayHelper")]
	[__DynamicallyInvokable]
	public interface IEnumerable<out T> : IEnumerable
	{
		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		// Token: 0x060039B4 RID: 14772
		[__DynamicallyInvokable]
		IEnumerator<T> GetEnumerator();
	}
}
