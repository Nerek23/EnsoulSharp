using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	/// <summary>Exposes an enumerator, which supports a simple iteration over a non-generic collection.</summary>
	// Token: 0x02000471 RID: 1137
	[Guid("496B0ABE-CDEE-11d3-88E8-00902754C43A")]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IEnumerable
	{
		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
		// Token: 0x0600379B RID: 14235
		[DispId(-4)]
		[__DynamicallyInvokable]
		IEnumerator GetEnumerator();
	}
}
