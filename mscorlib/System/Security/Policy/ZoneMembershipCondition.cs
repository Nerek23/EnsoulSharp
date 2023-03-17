using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	/// <summary>Determines whether an assembly belongs to a code group by testing its zone of origin. This class cannot be inherited.</summary>
	// Token: 0x02000345 RID: 837
	[ComVisible(true)]
	[Serializable]
	public sealed class ZoneMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002A8A RID: 10890 RVA: 0x0009E0E7 File Offset: 0x0009C2E7
		internal ZoneMembershipCondition()
		{
			this.m_zone = SecurityZone.NoZone;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.ZoneMembershipCondition" /> class with the zone that determines membership.</summary>
		/// <param name="zone">The <see cref="T:System.Security.SecurityZone" /> for which to test.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="zone" /> parameter is not a valid <see cref="T:System.Security.SecurityZone" />.</exception>
		// Token: 0x06002A8B RID: 10891 RVA: 0x0009E0F6 File Offset: 0x0009C2F6
		public ZoneMembershipCondition(SecurityZone zone)
		{
			ZoneMembershipCondition.VerifyZone(zone);
			this.SecurityZone = zone;
		}

		/// <summary>Gets or sets the zone for which the membership condition tests.</summary>
		/// <returns>The zone for which the membership condition tests.</returns>
		/// <exception cref="T:System.ArgumentNullException">The value is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">An attempt is made to set <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> to an invalid <see cref="T:System.Security.SecurityZone" />.</exception>
		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x06002A8D RID: 10893 RVA: 0x0009E11A File Offset: 0x0009C31A
		// (set) Token: 0x06002A8C RID: 10892 RVA: 0x0009E10B File Offset: 0x0009C30B
		public SecurityZone SecurityZone
		{
			get
			{
				if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
				{
					this.ParseZone();
				}
				return this.m_zone;
			}
			set
			{
				ZoneMembershipCondition.VerifyZone(value);
				this.m_zone = value;
			}
		}

		// Token: 0x06002A8E RID: 10894 RVA: 0x0009E139 File Offset: 0x0009C339
		private static void VerifyZone(SecurityZone zone)
		{
			if (zone < SecurityZone.MyComputer || zone > SecurityZone.Untrusted)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IllegalZone"));
			}
		}

		/// <summary>Determines whether the specified evidence satisfies the membership condition.</summary>
		/// <param name="evidence">The evidence set against which to make the test.</param>
		/// <returns>
		///   <see langword="true" /> if the specified evidence satisfies the membership condition; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is not a valid <see cref="T:System.Security.SecurityZone" />.</exception>
		// Token: 0x06002A8F RID: 10895 RVA: 0x0009E154 File Offset: 0x0009C354
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002A90 RID: 10896 RVA: 0x0009E16C File Offset: 0x0009C36C
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			if (evidence == null)
			{
				return false;
			}
			Zone hostEvidence = evidence.GetHostEvidence<Zone>();
			if (hostEvidence != null)
			{
				if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
				{
					this.ParseZone();
				}
				if (hostEvidence.SecurityZone == this.m_zone)
				{
					usedEvidence = hostEvidence;
					return true;
				}
			}
			return false;
		}

		/// <summary>Creates an equivalent copy of the membership condition.</summary>
		/// <returns>A new, identical copy of the current membership condition.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is not a valid <see cref="T:System.Security.SecurityZone" />.</exception>
		// Token: 0x06002A91 RID: 10897 RVA: 0x0009E1B6 File Offset: 0x0009C3B6
		public IMembershipCondition Copy()
		{
			if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
			{
				this.ParseZone();
			}
			return new ZoneMembershipCondition(this.m_zone);
		}

		/// <summary>Creates an XML encoding of the security object and its current state.</summary>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is not a valid <see cref="T:System.Security.SecurityZone" />.</exception>
		// Token: 0x06002A92 RID: 10898 RVA: 0x0009E1DA File Offset: 0x0009C3DA
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="e">The XML encoding to use to reconstruct the security object.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="e" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="e" /> parameter is not a valid membership condition element.</exception>
		// Token: 0x06002A93 RID: 10899 RVA: 0x0009E1E3 File Offset: 0x0009C3E3
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		/// <summary>Creates an XML encoding of the security object and its current state with the specified <see cref="T:System.Security.Policy.PolicyLevel" />.</summary>
		/// <param name="level">The policy level context for resolving named permission set references.</param>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is not a valid <see cref="T:System.Security.SecurityZone" />.</exception>
		// Token: 0x06002A94 RID: 10900 RVA: 0x0009E1F0 File Offset: 0x0009C3F0
		public SecurityElement ToXml(PolicyLevel level)
		{
			if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
			{
				this.ParseZone();
			}
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.ZoneMembershipCondition");
			securityElement.AddAttribute("version", "1");
			if (this.m_zone != SecurityZone.NoZone)
			{
				securityElement.AddAttribute("Zone", Enum.GetName(typeof(SecurityZone), this.m_zone));
			}
			return securityElement;
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="e">The XML encoding to use to reconstruct the security object.</param>
		/// <param name="level">The policy level context used to resolve named permission set references.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="e" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="e" /> parameter is not a valid membership condition element.</exception>
		// Token: 0x06002A95 RID: 10901 RVA: 0x0009E270 File Offset: 0x0009C470
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
				this.m_zone = SecurityZone.NoZone;
				this.m_element = e;
			}
		}

		// Token: 0x06002A96 RID: 10902 RVA: 0x0009E2E4 File Offset: 0x0009C4E4
		private void ParseZone()
		{
			lock (this)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("Zone");
					this.m_zone = SecurityZone.NoZone;
					if (text == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_ZoneCannotBeNull"));
					}
					this.m_zone = (SecurityZone)Enum.Parse(typeof(SecurityZone), text);
					ZoneMembershipCondition.VerifyZone(this.m_zone);
					this.m_element = null;
				}
			}
		}

		/// <summary>Determines whether the zone from the specified object is equivalent to the zone contained in the current <see cref="T:System.Security.Policy.ZoneMembershipCondition" />.</summary>
		/// <param name="o">The object to compare to the current <see cref="T:System.Security.Policy.ZoneMembershipCondition" />.</param>
		/// <returns>
		///   <see langword="true" /> if the zone from the specified object is equivalent to the zone contained in the current <see cref="T:System.Security.Policy.ZoneMembershipCondition" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property for the current object or the specified object is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property for the current object or the specified object is not a valid <see cref="T:System.Security.SecurityZone" />.</exception>
		// Token: 0x06002A97 RID: 10903 RVA: 0x0009E380 File Offset: 0x0009C580
		public override bool Equals(object o)
		{
			ZoneMembershipCondition zoneMembershipCondition = o as ZoneMembershipCondition;
			if (zoneMembershipCondition != null)
			{
				if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
				{
					this.ParseZone();
				}
				if (zoneMembershipCondition.m_zone == SecurityZone.NoZone && zoneMembershipCondition.m_element != null)
				{
					zoneMembershipCondition.ParseZone();
				}
				if (this.m_zone == zoneMembershipCondition.m_zone)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>Gets the hash code for the current membership condition.</summary>
		/// <returns>The hash code for the current membership condition.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is not a valid <see cref="T:System.Security.SecurityZone" />.</exception>
		// Token: 0x06002A98 RID: 10904 RVA: 0x0009E3D6 File Offset: 0x0009C5D6
		public override int GetHashCode()
		{
			if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
			{
				this.ParseZone();
			}
			return (int)this.m_zone;
		}

		/// <summary>Creates and returns a string representation of the membership condition.</summary>
		/// <returns>A string representation of the state of the membership condition.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Policy.ZoneMembershipCondition.SecurityZone" /> property is not a valid <see cref="T:System.Security.SecurityZone" />.</exception>
		// Token: 0x06002A99 RID: 10905 RVA: 0x0009E3F5 File Offset: 0x0009C5F5
		public override string ToString()
		{
			if (this.m_zone == SecurityZone.NoZone && this.m_element != null)
			{
				this.ParseZone();
			}
			return string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Zone_ToString"), ZoneMembershipCondition.s_names[(int)this.m_zone]);
		}

		// Token: 0x040010F2 RID: 4338
		private static readonly string[] s_names = new string[]
		{
			"MyComputer",
			"Intranet",
			"Trusted",
			"Internet",
			"Untrusted"
		};

		// Token: 0x040010F3 RID: 4339
		private SecurityZone m_zone;

		// Token: 0x040010F4 RID: 4340
		private SecurityElement m_element;
	}
}
