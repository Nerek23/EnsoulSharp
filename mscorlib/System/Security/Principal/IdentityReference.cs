using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	/// <summary>Represents an identity and is the base class for the <see cref="T:System.Security.Principal.NTAccount" /> and <see cref="T:System.Security.Principal.SecurityIdentifier" /> classes. This class does not provide a public constructor, and therefore cannot be inherited.</summary>
	// Token: 0x02000307 RID: 775
	[ComVisible(false)]
	public abstract class IdentityReference
	{
		// Token: 0x060027D5 RID: 10197 RVA: 0x000925FB File Offset: 0x000907FB
		internal IdentityReference()
		{
		}

		/// <summary>Gets the string value of the identity represented by the <see cref="T:System.Security.Principal.IdentityReference" /> object.</summary>
		/// <returns>The string value of the identity represented by the <see cref="T:System.Security.Principal.IdentityReference" /> object.</returns>
		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x060027D6 RID: 10198
		public abstract string Value { get; }

		/// <summary>Returns a value that indicates whether the specified type is a valid translation type for the <see cref="T:System.Security.Principal.IdentityReference" /> class.</summary>
		/// <param name="targetType">The type being queried for validity to serve as a conversion from <see cref="T:System.Security.Principal.IdentityReference" />. The following target types are valid:  
		///  <see cref="T:System.Security.Principal.NTAccount" /><see cref="T:System.Security.Principal.SecurityIdentifier" /></param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="targetType" /> is a valid translation type for the <see cref="T:System.Security.Principal.IdentityReference" /> class; otherwise, <see langword="false" />.</returns>
		// Token: 0x060027D7 RID: 10199
		public abstract bool IsValidTargetType(Type targetType);

		/// <summary>Translates the account name represented by the <see cref="T:System.Security.Principal.IdentityReference" /> object into another <see cref="T:System.Security.Principal.IdentityReference" />-derived type.</summary>
		/// <param name="targetType">The target type for the conversion from <see cref="T:System.Security.Principal.IdentityReference" />.</param>
		/// <returns>The converted identity.</returns>
		// Token: 0x060027D8 RID: 10200
		public abstract IdentityReference Translate(Type targetType);

		/// <summary>Returns a value that indicates whether the specified object equals this instance of the <see cref="T:System.Security.Principal.IdentityReference" /> class.</summary>
		/// <param name="o">An object to compare with this <see cref="T:System.Security.Principal.IdentityReference" /> instance, or a null reference.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="o" /> is an object with the same underlying type and value as this <see cref="T:System.Security.Principal.IdentityReference" /> instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x060027D9 RID: 10201
		public abstract override bool Equals(object o);

		/// <summary>Serves as a hash function for <see cref="T:System.Security.Principal.IdentityReference" />. <see cref="M:System.Security.Principal.IdentityReference.GetHashCode" /> is suitable for use in hashing algorithms and data structures like a hash table.</summary>
		/// <returns>The hash code for this <see cref="T:System.Security.Principal.IdentityReference" /> object.</returns>
		// Token: 0x060027DA RID: 10202
		public abstract override int GetHashCode();

		/// <summary>Returns the string representation of the identity represented by the <see cref="T:System.Security.Principal.IdentityReference" /> object.</summary>
		/// <returns>The identity in string format.</returns>
		// Token: 0x060027DB RID: 10203
		public abstract override string ToString();

		/// <summary>Compares two <see cref="T:System.Security.Principal.IdentityReference" /> objects to determine whether they are equal. They are considered equal if they have the same canonical name representation as the one returned by the <see cref="P:System.Security.Principal.IdentityReference.Value" /> property or if they are both <see langword="null" />.</summary>
		/// <param name="left">The left <see cref="T:System.Security.Principal.IdentityReference" /> operand to use for the equality comparison. This parameter can be <see langword="null" />.</param>
		/// <param name="right">The right <see cref="T:System.Security.Principal.IdentityReference" /> operand to use for the equality comparison. This parameter can be <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x060027DC RID: 10204 RVA: 0x00092604 File Offset: 0x00090804
		public static bool operator ==(IdentityReference left, IdentityReference right)
		{
			return (left == null && right == null) || (left != null && right != null && left.Equals(right));
		}

		/// <summary>Compares two <see cref="T:System.Security.Principal.IdentityReference" /> objects to determine whether they are not equal. They are considered not equal if they have different canonical name representations than the one returned by the <see cref="P:System.Security.Principal.IdentityReference.Value" /> property or if one of the objects is <see langword="null" /> and the other is not.</summary>
		/// <param name="left">The left <see cref="T:System.Security.Principal.IdentityReference" /> operand to use for the inequality comparison. This parameter can be <see langword="null" />.</param>
		/// <param name="right">The right <see cref="T:System.Security.Principal.IdentityReference" /> operand to use for the inequality comparison. This parameter can be <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x060027DD RID: 10205 RVA: 0x0009262C File Offset: 0x0009082C
		public static bool operator !=(IdentityReference left, IdentityReference right)
		{
			return !(left == right);
		}
	}
}
