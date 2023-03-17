using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	/// <summary>Determines whether an assembly belongs to a code group by testing the site from which it originated. This class cannot be inherited.</summary>
	// Token: 0x0200033E RID: 830
	[ComVisible(true)]
	[Serializable]
	public sealed class SiteMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002A1F RID: 10783 RVA: 0x0009C994 File Offset: 0x0009AB94
		internal SiteMembershipCondition()
		{
			this.m_site = null;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.SiteMembershipCondition" /> class with name of the site that determines membership.</summary>
		/// <param name="site">The site name or wildcard expression.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="site" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="site" /> parameter is not a valid <see cref="T:System.Security.Policy.Site" />.</exception>
		// Token: 0x06002A20 RID: 10784 RVA: 0x0009C9A3 File Offset: 0x0009ABA3
		public SiteMembershipCondition(string site)
		{
			if (site == null)
			{
				throw new ArgumentNullException("site");
			}
			this.m_site = new SiteString(site);
		}

		/// <summary>Gets or sets the site for which the membership condition tests.</summary>
		/// <returns>The site for which the membership condition tests.</returns>
		/// <exception cref="T:System.ArgumentNullException">An attempt is made to set <see cref="P:System.Security.Policy.SiteMembershipCondition.Site" /> to <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">An attempt is made to set <see cref="P:System.Security.Policy.SiteMembershipCondition.Site" /> to an invalid <see cref="T:System.Security.Policy.Site" />.</exception>
		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x06002A22 RID: 10786 RVA: 0x0009C9E1 File Offset: 0x0009ABE1
		// (set) Token: 0x06002A21 RID: 10785 RVA: 0x0009C9C5 File Offset: 0x0009ABC5
		public string Site
		{
			get
			{
				if (this.m_site == null && this.m_element != null)
				{
					this.ParseSite();
				}
				if (this.m_site != null)
				{
					return this.m_site.ToString();
				}
				return "";
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.m_site = new SiteString(value);
			}
		}

		/// <summary>Determines whether the specified evidence satisfies the membership condition.</summary>
		/// <param name="evidence">The <see cref="T:System.Security.Policy.Evidence" /> against which to make the test.</param>
		/// <returns>
		///   <see langword="true" /> if the specified evidence satisfies the membership condition; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.SiteMembershipCondition.Site" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A23 RID: 10787 RVA: 0x0009CA14 File Offset: 0x0009AC14
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002A24 RID: 10788 RVA: 0x0009CA2C File Offset: 0x0009AC2C
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			if (evidence == null)
			{
				return false;
			}
			Site hostEvidence = evidence.GetHostEvidence<Site>();
			if (hostEvidence != null)
			{
				if (this.m_site == null && this.m_element != null)
				{
					this.ParseSite();
				}
				if (hostEvidence.GetSiteString().IsSubsetOf(this.m_site))
				{
					usedEvidence = hostEvidence;
					return true;
				}
			}
			return false;
		}

		/// <summary>Creates an equivalent copy of the membership condition.</summary>
		/// <returns>A new, identical copy of the current membership condition.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.SiteMembershipCondition.Site" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A25 RID: 10789 RVA: 0x0009CA7A File Offset: 0x0009AC7A
		public IMembershipCondition Copy()
		{
			if (this.m_site == null && this.m_element != null)
			{
				this.ParseSite();
			}
			return new SiteMembershipCondition(this.m_site.ToString());
		}

		/// <summary>Creates an XML encoding of the security object and its current state.</summary>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.SiteMembershipCondition.Site" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A26 RID: 10790 RVA: 0x0009CAA2 File Offset: 0x0009ACA2
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="e">The XML encoding to use to reconstruct the security object.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="e" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="e" /> parameter is not a valid membership condition element.</exception>
		// Token: 0x06002A27 RID: 10791 RVA: 0x0009CAAB File Offset: 0x0009ACAB
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		/// <summary>Creates an XML encoding of the security object and its current state with the specified <see cref="T:System.Security.Policy.PolicyLevel" />.</summary>
		/// <param name="level">The <see cref="T:System.Security.Policy.PolicyLevel" /> context, used to resolve <see cref="T:System.Security.NamedPermissionSet" /> references.</param>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.SiteMembershipCondition.Site" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A28 RID: 10792 RVA: 0x0009CAB8 File Offset: 0x0009ACB8
		public SecurityElement ToXml(PolicyLevel level)
		{
			if (this.m_site == null && this.m_element != null)
			{
				this.ParseSite();
			}
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.SiteMembershipCondition");
			securityElement.AddAttribute("version", "1");
			if (this.m_site != null)
			{
				securityElement.AddAttribute("Site", this.m_site.ToString());
			}
			return securityElement;
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="e">The XML encoding to use to reconstruct the security object.</param>
		/// <param name="level">The <see cref="T:System.Security.Policy.PolicyLevel" /> context, used to resolve <see cref="T:System.Security.NamedPermissionSet" /> references.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="e" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="e" /> parameter is not a valid membership condition element.</exception>
		// Token: 0x06002A29 RID: 10793 RVA: 0x0009CB28 File Offset: 0x0009AD28
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
			lock (this)
			{
				this.m_site = null;
				this.m_element = e;
			}
		}

		// Token: 0x06002A2A RID: 10794 RVA: 0x0009CB9C File Offset: 0x0009AD9C
		private void ParseSite()
		{
			lock (this)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("Site");
					if (text == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_SiteCannotBeNull"));
					}
					this.m_site = new SiteString(text);
					this.m_element = null;
				}
			}
		}

		/// <summary>Determines whether the site from the specified <see cref="T:System.Security.Policy.SiteMembershipCondition" /> object is equivalent to the site contained in the current <see cref="T:System.Security.Policy.SiteMembershipCondition" />.</summary>
		/// <param name="o">The <see cref="T:System.Security.Policy.SiteMembershipCondition" /> object to compare to the current <see cref="T:System.Security.Policy.SiteMembershipCondition" />.</param>
		/// <returns>
		///   <see langword="true" /> if the site from the specified <see cref="T:System.Security.Policy.SiteMembershipCondition" /> object is equivalent to the site contained in the current <see cref="T:System.Security.Policy.SiteMembershipCondition" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.SiteMembershipCondition.Site" /> property for the current object or the specified object is <see langword="null" />.</exception>
		// Token: 0x06002A2B RID: 10795 RVA: 0x0009CC14 File Offset: 0x0009AE14
		public override bool Equals(object o)
		{
			SiteMembershipCondition siteMembershipCondition = o as SiteMembershipCondition;
			if (siteMembershipCondition != null)
			{
				if (this.m_site == null && this.m_element != null)
				{
					this.ParseSite();
				}
				if (siteMembershipCondition.m_site == null && siteMembershipCondition.m_element != null)
				{
					siteMembershipCondition.ParseSite();
				}
				if (object.Equals(this.m_site, siteMembershipCondition.m_site))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>Gets the hash code for the current membership condition.</summary>
		/// <returns>The hash code for the current membership condition.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.SiteMembershipCondition.Site" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A2C RID: 10796 RVA: 0x0009CC6D File Offset: 0x0009AE6D
		public override int GetHashCode()
		{
			if (this.m_site == null && this.m_element != null)
			{
				this.ParseSite();
			}
			if (this.m_site != null)
			{
				return this.m_site.GetHashCode();
			}
			return typeof(SiteMembershipCondition).GetHashCode();
		}

		/// <summary>Creates and returns a string representation of the membership condition.</summary>
		/// <returns>A string representation of the membership condition.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.SiteMembershipCondition.Site" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A2D RID: 10797 RVA: 0x0009CCA8 File Offset: 0x0009AEA8
		public override string ToString()
		{
			if (this.m_site == null && this.m_element != null)
			{
				this.ParseSite();
			}
			if (this.m_site != null)
			{
				return string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Site_ToStringArg"), this.m_site);
			}
			return Environment.GetResourceString("Site_ToString");
		}

		// Token: 0x040010DE RID: 4318
		private SiteString m_site;

		// Token: 0x040010DF RID: 4319
		private SecurityElement m_element;
	}
}
