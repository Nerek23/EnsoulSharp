using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	/// <summary>Determines whether an assembly belongs to a code group by testing its global assembly cache membership. This class cannot be inherited.</summary>
	// Token: 0x02000347 RID: 839
	[ComVisible(true)]
	[Serializable]
	public sealed class GacMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		/// <summary>Indicates whether the specified evidence satisfies the membership condition.</summary>
		/// <param name="evidence">The <see cref="T:System.Security.Policy.Evidence" /> against which to make the test.</param>
		/// <returns>
		///   <see langword="true" /> if the specified evidence satisfies the membership condition; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002AA4 RID: 10916 RVA: 0x0009E4D4 File Offset: 0x0009C6D4
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002AA5 RID: 10917 RVA: 0x0009E4EC File Offset: 0x0009C6EC
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			return evidence != null && evidence.GetHostEvidence<GacInstalled>() != null;
		}

		/// <summary>Creates an equivalent copy of the membership condition.</summary>
		/// <returns>A new <see cref="T:System.Security.Policy.GacMembershipCondition" /> object.</returns>
		// Token: 0x06002AA6 RID: 10918 RVA: 0x0009E4FF File Offset: 0x0009C6FF
		public IMembershipCondition Copy()
		{
			return new GacMembershipCondition();
		}

		/// <summary>Creates an XML encoding of the security object and its current state.</summary>
		/// <returns>A <see cref="T:System.Security.SecurityElement" /> that contains the XML encoding of the security object, including any state information.</returns>
		// Token: 0x06002AA7 RID: 10919 RVA: 0x0009E506 File Offset: 0x0009C706
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		/// <summary>Uses the specified XML encoding to reconstruct a security object.</summary>
		/// <param name="e">The <see cref="T:System.Security.SecurityElement" /> that contains the XML encoding to use to reconstruct the security object.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="e" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="e" /> is not a valid membership condition element.</exception>
		// Token: 0x06002AA8 RID: 10920 RVA: 0x0009E50F File Offset: 0x0009C70F
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		/// <summary>Creates an XML encoding of the security object and its current state, using the specified policy level context.</summary>
		/// <param name="level">The <see cref="T:System.Security.Policy.PolicyLevel" /> context for resolving <see cref="T:System.Security.NamedPermissionSet" /> references.</param>
		/// <returns>A <see cref="T:System.Security.SecurityElement" /> that contains the XML encoding of the security object, including any state information.</returns>
		// Token: 0x06002AA9 RID: 10921 RVA: 0x0009E51C File Offset: 0x0009C71C
		public SecurityElement ToXml(PolicyLevel level)
		{
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), base.GetType().FullName);
			securityElement.AddAttribute("version", "1");
			return securityElement;
		}

		/// <summary>Uses the specified XML encoding to reconstruct a security object, using the specified policy level context.</summary>
		/// <param name="e">The <see cref="T:System.Security.SecurityElement" /> that contains the XML encoding to use to reconstruct the security object.</param>
		/// <param name="level">The <see cref="T:System.Security.Policy.PolicyLevel" /> context for resolving <see cref="T:System.Security.NamedPermissionSet" /> references.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="e" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="e" /> is not a valid membership condition element.</exception>
		// Token: 0x06002AAA RID: 10922 RVA: 0x0009E55C File Offset: 0x0009C75C
		public void FromXml(SecurityElement e, PolicyLevel level)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (!e.Tag.Equals("IMembershipCondition"))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MembershipConditionElement"));
			}
		}

		/// <summary>Indicates whether the current object is equivalent to the specified object.</summary>
		/// <param name="o">The object to compare with the current object.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="o" /> is a <see cref="T:System.Security.Policy.GacMembershipCondition" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002AAB RID: 10923 RVA: 0x0009E590 File Offset: 0x0009C790
		public override bool Equals(object o)
		{
			return o is GacMembershipCondition;
		}

		/// <summary>Gets a hash code for the current membership condition.</summary>
		/// <returns>0 (zero).</returns>
		// Token: 0x06002AAC RID: 10924 RVA: 0x0009E5AA File Offset: 0x0009C7AA
		public override int GetHashCode()
		{
			return 0;
		}

		/// <summary>Returns a string representation of the membership condition.</summary>
		/// <returns>A string representation of the membership condition.</returns>
		// Token: 0x06002AAD RID: 10925 RVA: 0x0009E5AD File Offset: 0x0009C7AD
		public override string ToString()
		{
			return Environment.GetResourceString("GAC_ToString");
		}
	}
}
