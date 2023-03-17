using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	/// <summary>Defines the test to determine whether a code assembly is a member of a code group.</summary>
	// Token: 0x0200032B RID: 811
	[ComVisible(true)]
	public interface IMembershipCondition : ISecurityEncodable, ISecurityPolicyEncodable
	{
		/// <summary>Determines whether the specified evidence satisfies the membership condition.</summary>
		/// <param name="evidence">The evidence set against which to make the test.</param>
		/// <returns>
		///   <see langword="true" /> if the specified evidence satisfies the membership condition; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002951 RID: 10577
		bool Check(Evidence evidence);

		/// <summary>Creates an equivalent copy of the membership condition.</summary>
		/// <returns>A new, identical copy of the current membership condition.</returns>
		// Token: 0x06002952 RID: 10578
		IMembershipCondition Copy();

		/// <summary>Creates and returns a string representation of the membership condition.</summary>
		/// <returns>A string representation of the state of the current membership condition.</returns>
		// Token: 0x06002953 RID: 10579
		string ToString();

		/// <summary>Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.</summary>
		/// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
		/// <returns>
		///   <see langword="true" /> if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002954 RID: 10580
		bool Equals(object obj);
	}
}
