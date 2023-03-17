using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Util;

namespace System.Security.Policy
{
	/// <summary>Provides the Web site from which a code assembly originates as evidence for policy evaluation. This class cannot be inherited.</summary>
	// Token: 0x0200033D RID: 829
	[ComVisible(true)]
	[Serializable]
	public sealed class Site : EvidenceBase, IIdentityPermissionFactory
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.Site" /> class with the website from which a code assembly originates.</summary>
		/// <param name="name">The website of origin for the associated code assembly.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002A11 RID: 10769 RVA: 0x0009C827 File Offset: 0x0009AA27
		public Site(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.m_name = new SiteString(name);
		}

		// Token: 0x06002A12 RID: 10770 RVA: 0x0009C849 File Offset: 0x0009AA49
		private Site(SiteString name)
		{
			this.m_name = name;
		}

		/// <summary>Creates a new <see cref="T:System.Security.Policy.Site" /> object from the specified URL.</summary>
		/// <param name="url">The URL from which to create the new <see cref="T:System.Security.Policy.Site" /> object.</param>
		/// <returns>A new site object.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="url" /> parameter is not a valid URL.  
		///  -or-  
		///  The <paramref name="url" /> parameter is a file name.</exception>
		// Token: 0x06002A13 RID: 10771 RVA: 0x0009C858 File Offset: 0x0009AA58
		public static Site CreateFromUrl(string url)
		{
			return new Site(Site.ParseSiteFromUrl(url));
		}

		// Token: 0x06002A14 RID: 10772 RVA: 0x0009C868 File Offset: 0x0009AA68
		private static SiteString ParseSiteFromUrl(string name)
		{
			URLString urlstring = new URLString(name);
			if (string.Compare(urlstring.Scheme, "file", StringComparison.OrdinalIgnoreCase) == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidSite"));
			}
			return new SiteString(new URLString(name).Host);
		}

		/// <summary>Gets the website from which the code assembly originates.</summary>
		/// <returns>The name of the website from which the code assembly originates.</returns>
		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x06002A15 RID: 10773 RVA: 0x0009C8AF File Offset: 0x0009AAAF
		public string Name
		{
			get
			{
				return this.m_name.ToString();
			}
		}

		// Token: 0x06002A16 RID: 10774 RVA: 0x0009C8BC File Offset: 0x0009AABC
		internal SiteString GetSiteString()
		{
			return this.m_name;
		}

		/// <summary>Creates an identity permission that corresponds to the current <see cref="T:System.Security.Policy.Site" /> object.</summary>
		/// <param name="evidence">The evidence from which to construct the identity permission.</param>
		/// <returns>A site identity permission for the current <see cref="T:System.Security.Policy.Site" /> object.</returns>
		// Token: 0x06002A17 RID: 10775 RVA: 0x0009C8C4 File Offset: 0x0009AAC4
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new SiteIdentityPermission(this.Name);
		}

		/// <summary>Compares the current <see cref="T:System.Security.Policy.Site" /> to the specified object for equivalence.</summary>
		/// <param name="o">The object to test for equivalence with the current object.</param>
		/// <returns>
		///   <see langword="true" /> if the two instances of the <see cref="T:System.Security.Policy.Site" /> class are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002A18 RID: 10776 RVA: 0x0009C8D4 File Offset: 0x0009AAD4
		public override bool Equals(object o)
		{
			Site site = o as Site;
			return site != null && string.Equals(this.Name, site.Name, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>Returns the hash code of the current website name.</summary>
		/// <returns>The hash code of the current website name.</returns>
		// Token: 0x06002A19 RID: 10777 RVA: 0x0009C8FF File Offset: 0x0009AAFF
		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		// Token: 0x06002A1A RID: 10778 RVA: 0x0009C90C File Offset: 0x0009AB0C
		public override EvidenceBase Clone()
		{
			return new Site(this.m_name);
		}

		/// <summary>Creates an equivalent copy of the <see cref="T:System.Security.Policy.Site" /> object.</summary>
		/// <returns>A new object that is identical to the current <see cref="T:System.Security.Policy.Site" /> object.</returns>
		// Token: 0x06002A1B RID: 10779 RVA: 0x0009C919 File Offset: 0x0009AB19
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002A1C RID: 10780 RVA: 0x0009C924 File Offset: 0x0009AB24
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.Site");
			securityElement.AddAttribute("version", "1");
			if (this.m_name != null)
			{
				securityElement.AddChild(new SecurityElement("Name", this.m_name.ToString()));
			}
			return securityElement;
		}

		/// <summary>Returns a string representation of the current <see cref="T:System.Security.Policy.Site" /> object.</summary>
		/// <returns>A representation of the current site.</returns>
		// Token: 0x06002A1D RID: 10781 RVA: 0x0009C970 File Offset: 0x0009AB70
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x06002A1E RID: 10782 RVA: 0x0009C97D File Offset: 0x0009AB7D
		internal object Normalize()
		{
			return this.m_name.ToString().ToUpper(CultureInfo.InvariantCulture);
		}

		// Token: 0x040010DD RID: 4317
		private SiteString m_name;
	}
}
