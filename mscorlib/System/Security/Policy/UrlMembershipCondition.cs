using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	/// <summary>Determines whether an assembly belongs to a code group by testing its URL. This class cannot be inherited.</summary>
	// Token: 0x02000343 RID: 835
	[ComVisible(true)]
	[Serializable]
	public sealed class UrlMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002A6C RID: 10860 RVA: 0x0009DB52 File Offset: 0x0009BD52
		internal UrlMembershipCondition()
		{
			this.m_url = null;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.UrlMembershipCondition" /> class with the URL that determines membership.</summary>
		/// <param name="url">The URL for which to test.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="url" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="url" /> must be an absolute URL.</exception>
		// Token: 0x06002A6D RID: 10861 RVA: 0x0009DB64 File Offset: 0x0009BD64
		public UrlMembershipCondition(string url)
		{
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			this.m_url = new URLString(url, false, true);
			if (this.m_url.IsRelativeFileUrl)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_RelativeUrlMembershipCondition"), "url");
			}
		}

		/// <summary>Gets or sets the URL for which the membership condition tests.</summary>
		/// <returns>The URL for which the membership condition tests.</returns>
		/// <exception cref="T:System.ArgumentNullException">An attempt is made to set <see cref="P:System.Security.Policy.UrlMembershipCondition.Url" /> to <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">Value is not an absolute URL.</exception>
		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x06002A6F RID: 10863 RVA: 0x0009DBFE File Offset: 0x0009BDFE
		// (set) Token: 0x06002A6E RID: 10862 RVA: 0x0009DBB8 File Offset: 0x0009BDB8
		public string Url
		{
			get
			{
				if (this.m_url == null && this.m_element != null)
				{
					this.ParseURL();
				}
				return this.m_url.ToString();
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				URLString urlstring = new URLString(value);
				if (urlstring.IsRelativeFileUrl)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_RelativeUrlMembershipCondition"), "value");
				}
				this.m_url = urlstring;
			}
		}

		/// <summary>Determines whether the specified evidence satisfies the membership condition.</summary>
		/// <param name="evidence">The evidence set against which to make the test.</param>
		/// <returns>
		///   <see langword="true" /> if the specified evidence satisfies the membership condition; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.UrlMembershipCondition.Url" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A70 RID: 10864 RVA: 0x0009DC24 File Offset: 0x0009BE24
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002A71 RID: 10865 RVA: 0x0009DC3C File Offset: 0x0009BE3C
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			if (evidence == null)
			{
				return false;
			}
			Url hostEvidence = evidence.GetHostEvidence<Url>();
			if (hostEvidence != null)
			{
				if (this.m_url == null && this.m_element != null)
				{
					this.ParseURL();
				}
				if (hostEvidence.GetURLString().IsSubsetOf(this.m_url))
				{
					usedEvidence = hostEvidence;
					return true;
				}
			}
			return false;
		}

		/// <summary>Creates an equivalent copy of the membership condition.</summary>
		/// <returns>A new, identical copy of the current membership condition.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.UrlMembershipCondition.Url" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A72 RID: 10866 RVA: 0x0009DC8C File Offset: 0x0009BE8C
		public IMembershipCondition Copy()
		{
			if (this.m_url == null && this.m_element != null)
			{
				this.ParseURL();
			}
			return new UrlMembershipCondition
			{
				m_url = new URLString(this.m_url.ToString())
			};
		}

		/// <summary>Creates an XML encoding of the security object and its current state.</summary>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		// Token: 0x06002A73 RID: 10867 RVA: 0x0009DCCC File Offset: 0x0009BECC
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="e">The XML encoding to use to reconstruct the security object.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="e" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="e" /> parameter is not a valid membership condition element.</exception>
		// Token: 0x06002A74 RID: 10868 RVA: 0x0009DCD5 File Offset: 0x0009BED5
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		/// <summary>Creates an XML encoding of the security object and its current state with the specified <see cref="T:System.Security.Policy.PolicyLevel" />.</summary>
		/// <param name="level">The policy level context for resolving named permission set references.</param>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.UrlMembershipCondition.Url" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A75 RID: 10869 RVA: 0x0009DCE0 File Offset: 0x0009BEE0
		public SecurityElement ToXml(PolicyLevel level)
		{
			if (this.m_url == null && this.m_element != null)
			{
				this.ParseURL();
			}
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.UrlMembershipCondition");
			securityElement.AddAttribute("version", "1");
			if (this.m_url != null)
			{
				securityElement.AddAttribute("Url", this.m_url.ToString());
			}
			return securityElement;
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="e">The XML encoding to use to reconstruct the security object.</param>
		/// <param name="level">The policy level context, used to resolve named permission set references.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="e" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="e" /> parameter is not a valid membership condition element.</exception>
		// Token: 0x06002A76 RID: 10870 RVA: 0x0009DD50 File Offset: 0x0009BF50
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
				this.m_url = null;
			}
		}

		// Token: 0x06002A77 RID: 10871 RVA: 0x0009DDC4 File Offset: 0x0009BFC4
		private void ParseURL()
		{
			lock (this)
			{
				if (this.m_element != null)
				{
					string text = this.m_element.Attribute("Url");
					if (text == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_UrlCannotBeNull"));
					}
					URLString urlstring = new URLString(text);
					if (urlstring.IsRelativeFileUrl)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_RelativeUrlMembershipCondition"));
					}
					this.m_url = urlstring;
					this.m_element = null;
				}
			}
		}

		/// <summary>Determines whether the URL from the specified object is equivalent to the URL contained in the current <see cref="T:System.Security.Policy.UrlMembershipCondition" />.</summary>
		/// <param name="o">The object to compare to the current <see cref="T:System.Security.Policy.UrlMembershipCondition" />.</param>
		/// <returns>
		///   <see langword="true" /> if the URL from the specified object is equivalent to the URL contained in the current <see cref="T:System.Security.Policy.UrlMembershipCondition" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.UrlMembershipCondition.Url" /> property of the current object or the specified object is <see langword="null" />.</exception>
		// Token: 0x06002A78 RID: 10872 RVA: 0x0009DE54 File Offset: 0x0009C054
		public override bool Equals(object o)
		{
			UrlMembershipCondition urlMembershipCondition = o as UrlMembershipCondition;
			if (urlMembershipCondition != null)
			{
				if (this.m_url == null && this.m_element != null)
				{
					this.ParseURL();
				}
				if (urlMembershipCondition.m_url == null && urlMembershipCondition.m_element != null)
				{
					urlMembershipCondition.ParseURL();
				}
				if (object.Equals(this.m_url, urlMembershipCondition.m_url))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>Gets the hash code for the current membership condition.</summary>
		/// <returns>The hash code for the current membership condition.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.UrlMembershipCondition.Url" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A79 RID: 10873 RVA: 0x0009DEAD File Offset: 0x0009C0AD
		public override int GetHashCode()
		{
			if (this.m_url == null && this.m_element != null)
			{
				this.ParseURL();
			}
			if (this.m_url != null)
			{
				return this.m_url.GetHashCode();
			}
			return typeof(UrlMembershipCondition).GetHashCode();
		}

		/// <summary>Creates and returns a string representation of the membership condition.</summary>
		/// <returns>A string representation of the state of the membership condition.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Policy.UrlMembershipCondition.Url" /> property is <see langword="null" />.</exception>
		// Token: 0x06002A7A RID: 10874 RVA: 0x0009DEE8 File Offset: 0x0009C0E8
		public override string ToString()
		{
			if (this.m_url == null && this.m_element != null)
			{
				this.ParseURL();
			}
			if (this.m_url != null)
			{
				return string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Url_ToStringArg"), this.m_url.ToString());
			}
			return Environment.GetResourceString("Url_ToString");
		}

		// Token: 0x040010ED RID: 4333
		private URLString m_url;

		// Token: 0x040010EE RID: 4334
		private SecurityElement m_element;
	}
}
