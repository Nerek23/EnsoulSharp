using System;

namespace System.Collections
{
	/// <summary>Defines methods to support the comparison of objects for structural equality.</summary>
	// Token: 0x02000478 RID: 1144
	[__DynamicallyInvokable]
	public interface IStructuralEquatable
	{
		/// <summary>Determines whether an object is structurally equal to the current instance.</summary>
		/// <param name="other">The object to compare with the current instance.</param>
		/// <param name="comparer">An object that determines whether the current instance and <paramref name="other" /> are equal.</param>
		/// <returns>
		///   <see langword="true" /> if the two objects are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x060037DA RID: 14298
		[__DynamicallyInvokable]
		bool Equals(object other, IEqualityComparer comparer);

		/// <summary>Returns a hash code for the current instance.</summary>
		/// <param name="comparer">An object that computes the hash code of the current object.</param>
		/// <returns>The hash code for the current instance.</returns>
		// Token: 0x060037DB RID: 14299
		[__DynamicallyInvokable]
		int GetHashCode(IEqualityComparer comparer);
	}
}
