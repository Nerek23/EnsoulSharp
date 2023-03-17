using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Util;

namespace System.Security.Policy
{
	/// <summary>Determines whether an assembly belongs to a code group by testing its software publisher's Authenticode X.509v3 certificate. This class cannot be inherited.</summary>
	// Token: 0x0200034B RID: 843
	[ComVisible(true)]
	[Serializable]
	public sealed class PublisherMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002AE9 RID: 10985 RVA: 0x0009F5E7 File Offset: 0x0009D7E7
		internal PublisherMembershipCondition()
		{
			this.m_element = null;
			this.m_certificate = null;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.PublisherMembershipCondition" /> class with the Authenticode X.509v3 certificate that determines membership.</summary>
		/// <param name="certificate">An <see cref="T:System.Security.Cryptography.X509Certificates.X509Certificate" /> that contains the software publisher's public key.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="certificate" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002AEA RID: 10986 RVA: 0x0009F5FD File Offset: 0x0009D7FD
		public PublisherMembershipCondition(X509Certificate certificate)
		{
			PublisherMembershipCondition.CheckCertificate(certificate);
			this.m_certificate = new X509Certificate(certificate);
		}

		// Token: 0x06002AEB RID: 10987 RVA: 0x0009F617 File Offset: 0x0009D817
		private static void CheckCertificate(X509Certificate certificate)
		{
			if (certificate == null)
			{
				throw new ArgumentNullException("certificate");
			}
		}

		/// <summary>Gets or sets the Authenticode X.509v3 certificate for which the membership condition tests.</summary>
		/// <returns>The <see cref="T:System.Security.Cryptography.X509Certificates.X509Certificate" /> for which the membership condition tests.</returns>
		/// <exception cref="T:System.ArgumentNullException">The property value is <see langword="null" />.</exception>
		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x06002AED RID: 10989 RVA: 0x0009F63B File Offset: 0x0009D83B
		// (set) Token: 0x06002AEC RID: 10988 RVA: 0x0009F627 File Offset: 0x0009D827
		public X509Certificate Certificate
		{
			get
			{
				if (this.m_certificate == null && this.m_element != null)
				{
					this.ParseCertificate();
				}
				if (this.m_certificate != null)
				{
					return new X509Certificate(this.m_certificate);
				}
				return null;
			}
			set
			{
				PublisherMembershipCondition.CheckCertificate(value);
				this.m_certificate = new X509Certificate(value);
			}
		}

		/// <summary>Creates and returns a string representation of the <see cref="T:System.Security.Policy.PublisherMembershipCondition" />.</summary>
		/// <returns>A representation of the <see cref="T:System.Security.Policy.PublisherMembershipCondition" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.PublisherMembershipCondition.Certificate" /> property is <see langword="null" />.</exception>
		// Token: 0x06002AEE RID: 10990 RVA: 0x0009F668 File Offset: 0x0009D868
		public override string ToString()
		{
			if (this.m_certificate == null && this.m_element != null)
			{
				this.ParseCertificate();
			}
			if (this.m_certificate == null)
			{
				return Environment.GetResourceString("Publisher_ToString");
			}
			string subject = this.m_certificate.Subject;
			if (subject != null)
			{
				return string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Publisher_ToStringArg"), Hex.EncodeHexString(this.m_certificate.GetPublicKey()));
			}
			return Environment.GetResourceString("Publisher_ToString");
		}

		/// <summary>Determines whether the specified evidence satisfies the membership condition.</summary>
		/// <param name="evidence">The <see cref="T:System.Security.Policy.Evidence" /> against which to make the test.</param>
		/// <returns>
		///   <see langword="true" /> if the specified evidence satisfies the membership condition; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.PublisherMembershipCondition.Certificate" /> property is <see langword="null" />.</exception>
		// Token: 0x06002AEF RID: 10991 RVA: 0x0009F6DC File Offset: 0x0009D8DC
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002AF0 RID: 10992 RVA: 0x0009F6F4 File Offset: 0x0009D8F4
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			if (evidence == null)
			{
				return false;
			}
			Publisher hostEvidence = evidence.GetHostEvidence<Publisher>();
			if (hostEvidence != null)
			{
				if (this.m_certificate == null && this.m_element != null)
				{
					this.ParseCertificate();
				}
				if (hostEvidence.Equals(new Publisher(this.m_certificate)))
				{
					usedEvidence = hostEvidence;
					return true;
				}
			}
			return false;
		}

		/// <summary>Creates an equivalent copy of the membership condition.</summary>
		/// <returns>A new, identical copy of the current membership condition.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.PublisherMembershipCondition.Certificate" /> property is <see langword="null" />.</exception>
		// Token: 0x06002AF1 RID: 10993 RVA: 0x0009F742 File Offset: 0x0009D942
		public IMembershipCondition Copy()
		{
			if (this.m_certificate == null && this.m_element != null)
			{
				this.ParseCertificate();
			}
			return new PublisherMembershipCondition(this.m_certificate);
		}

		/// <summary>Creates an XML encoding of the security object and its current state.</summary>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.PublisherMembershipCondition.Certificate" /> property is <see langword="null" />.</exception>
		// Token: 0x06002AF2 RID: 10994 RVA: 0x0009F765 File Offset: 0x0009D965
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="e">The XML encoding to use to reconstruct the security object.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="e" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="e" /> parameter is not a valid membership condition element.</exception>
		// Token: 0x06002AF3 RID: 10995 RVA: 0x0009F76E File Offset: 0x0009D96E
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		/// <summary>Creates an XML encoding of the security object and its current state with the specified <see cref="T:System.Security.Policy.PolicyLevel" />.</summary>
		/// <param name="level">The <see cref="T:System.Security.Policy.PolicyLevel" /> context, which is used to resolve <see cref="T:System.Security.NamedPermissionSet" /> references.</param>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.PublisherMembershipCondition.Certificate" /> property is <see langword="null" />.</exception>
		// Token: 0x06002AF4 RID: 10996 RVA: 0x0009F778 File Offset: 0x0009D978
		public SecurityElement ToXml(PolicyLevel level)
		{
			if (this.m_certificate == null && this.m_element != null)
			{
				this.ParseCertificate();
			}
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.PublisherMembershipCondition");
			securityElement.AddAttribute("version", "1");
			if (this.m_certificate != null)
			{
				securityElement.AddAttribute("X509Certificate", this.m_certificate.GetRawCertDataString());
			}
			return securityElement;
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="e">The XML encoding to use to reconstruct the security object.</param>
		/// <param name="level">The <see cref="T:System.Security.Policy.PolicyLevel" /> context, used to resolve <see cref="T:System.Security.NamedPermissionSet" /> references.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="e" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="e" /> parameter is not a valid membership condition element.</exception>
		// Token: 0x06002AF5 RID: 10997 RVA: 0x0009F7E8 File Offset: 0x0009D9E8
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
				this.m_element = e;
				this.m_certificate = null;
			}
		}

		// Token: 0x06002AF6 RID: 10998 RVA: 0x0009F85C File Offset: 0x0009DA5C
		private void ParseCertificate()
		{
			lock (this)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("X509Certificate");
					this.m_certificate = ((text == null) ? null : new X509Certificate(Hex.DecodeHexString(text)));
					PublisherMembershipCondition.CheckCertificate(this.m_certificate);
					this.m_element = null;
				}
			}
		}

		/// <summary>Determines whether the publisher certificate from the specified object is equivalent to the publisher certificate contained in the current <see cref="T:System.Security.Policy.PublisherMembershipCondition" />.</summary>
		/// <param name="o">The object to compare to the current <see cref="T:System.Security.Policy.PublisherMembershipCondition" />.</param>
		/// <returns>
		///   <see langword="true" /> if the publisher certificate from the specified object is equivalent to the publisher certificate contained in the current <see cref="T:System.Security.Policy.PublisherMembershipCondition" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.PublisherMembershipCondition.Certificate" /> property is <see langword="null" />.</exception>
		// Token: 0x06002AF7 RID: 10999 RVA: 0x0009F8D8 File Offset: 0x0009DAD8
		public override bool Equals(object o)
		{
			PublisherMembershipCondition publisherMembershipCondition = o as PublisherMembershipCondition;
			if (publisherMembershipCondition != null)
			{
				if (this.m_certificate == null && this.m_element != null)
				{
					this.ParseCertificate();
				}
				if (publisherMembershipCondition.m_certificate == null && publisherMembershipCondition.m_element != null)
				{
					publisherMembershipCondition.ParseCertificate();
				}
				if (Publisher.PublicKeyEquals(this.m_certificate, publisherMembershipCondition.m_certificate))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>Gets the hash code for the current membership condition.</summary>
		/// <returns>The hash code for the current membership condition.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.PublisherMembershipCondition.Certificate" /> property is <see langword="null" />.</exception>
		// Token: 0x06002AF8 RID: 11000 RVA: 0x0009F931 File Offset: 0x0009DB31
		public override int GetHashCode()
		{
			if (this.m_certificate == null && this.m_element != null)
			{
				this.ParseCertificate();
			}
			if (this.m_certificate != null)
			{
				return this.m_certificate.GetHashCode();
			}
			return typeof(PublisherMembershipCondition).GetHashCode();
		}

		// Token: 0x040010FF RID: 4351
		private X509Certificate m_certificate;

		// Token: 0x04001100 RID: 4352
		private SecurityElement m_element;
	}
}
