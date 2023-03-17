using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	/// <summary>Represents a membership condition that matches all code. This class cannot be inherited.</summary>
	// Token: 0x02000312 RID: 786
	[ComVisible(true)]
	[Serializable]
	public sealed class AllMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		/// <summary>Determines whether the specified evidence satisfies the membership condition.</summary>
		/// <param name="evidence">The evidence set against which to make the test.</param>
		/// <returns>Always <see langword="true" />.</returns>
		// Token: 0x0600283C RID: 10300 RVA: 0x000943E4 File Offset: 0x000925E4
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x0600283D RID: 10301 RVA: 0x000943FC File Offset: 0x000925FC
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			return true;
		}

		/// <summary>Creates an equivalent copy of the membership condition.</summary>
		/// <returns>A new, identical copy of the current membership condition.</returns>
		// Token: 0x0600283E RID: 10302 RVA: 0x00094402 File Offset: 0x00092602
		public IMembershipCondition Copy()
		{
			return new AllMembershipCondition();
		}

		/// <summary>Creates and returns a string representation of the membership condition.</summary>
		/// <returns>A representation of the membership condition.</returns>
		// Token: 0x0600283F RID: 10303 RVA: 0x00094409 File Offset: 0x00092609
		public override string ToString()
		{
			return Environment.GetResourceString("All_ToString");
		}

		/// <summary>Creates an XML encoding of the security object and its current state.</summary>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		// Token: 0x06002840 RID: 10304 RVA: 0x00094415 File Offset: 0x00092615
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="e">The XML encoding to use to reconstruct the security object.</param>
		// Token: 0x06002841 RID: 10305 RVA: 0x0009441E File Offset: 0x0009261E
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		/// <summary>Creates an XML encoding of the security object and its current state with the specified <see cref="T:System.Security.Policy.PolicyLevel" />.</summary>
		/// <param name="level">The policy level context for resolving named permission set references.</param>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		// Token: 0x06002842 RID: 10306 RVA: 0x00094428 File Offset: 0x00092628
		public SecurityElement ToXml(PolicyLevel level)
		{
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.AllMembershipCondition");
			securityElement.AddAttribute("version", "1");
			return securityElement;
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="e">The XML encoding to use to reconstruct the security object.</param>
		/// <param name="level">The policy level context used to resolve named permission set references.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="e" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="e" /> parameter is not a valid membership condition element.</exception>
		// Token: 0x06002843 RID: 10307 RVA: 0x00094462 File Offset: 0x00092662
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

		/// <summary>Determines whether the specified membership condition is an <see cref="T:System.Security.Policy.AllMembershipCondition" />.</summary>
		/// <param name="o">The object to compare to <see cref="T:System.Security.Policy.AllMembershipCondition" />.</param>
		/// <returns>
		///   <see langword="true" /> if the specified membership condition is an <see cref="T:System.Security.Policy.AllMembershipCondition" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002844 RID: 10308 RVA: 0x00094494 File Offset: 0x00092694
		public override bool Equals(object o)
		{
			return o is AllMembershipCondition;
		}

		/// <summary>Gets the hash code for the current membership condition.</summary>
		/// <returns>The hash code for the current membership condition.</returns>
		// Token: 0x06002845 RID: 10309 RVA: 0x0009449F File Offset: 0x0009269F
		public override int GetHashCode()
		{
			return typeof(AllMembershipCondition).GetHashCode();
		}
	}
}
