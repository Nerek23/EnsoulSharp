using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	/// <summary>Provides the application directory as evidence for policy evaluation. This class cannot be inherited.</summary>
	// Token: 0x02000314 RID: 788
	[ComVisible(true)]
	[Serializable]
	public sealed class ApplicationDirectory : EvidenceBase
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.ApplicationDirectory" /> class.</summary>
		/// <param name="name">The path of the application directory.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		// Token: 0x0600284A RID: 10314 RVA: 0x00094554 File Offset: 0x00092754
		public ApplicationDirectory(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.m_appDirectory = new URLString(name);
		}

		// Token: 0x0600284B RID: 10315 RVA: 0x00094576 File Offset: 0x00092776
		private ApplicationDirectory(URLString appDirectory)
		{
			this.m_appDirectory = appDirectory;
		}

		/// <summary>Gets the path of the application directory.</summary>
		/// <returns>The path of the application directory.</returns>
		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x0600284C RID: 10316 RVA: 0x00094585 File Offset: 0x00092785
		public string Directory
		{
			get
			{
				return this.m_appDirectory.ToString();
			}
		}

		/// <summary>Determines whether instances of the same type of an evidence object are equivalent.</summary>
		/// <param name="o">An object of same type as the current evidence object.</param>
		/// <returns>
		///   <see langword="true" /> if the two instances are equivalent; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600284D RID: 10317 RVA: 0x00094594 File Offset: 0x00092794
		public override bool Equals(object o)
		{
			ApplicationDirectory applicationDirectory = o as ApplicationDirectory;
			return applicationDirectory != null && this.m_appDirectory.Equals(applicationDirectory.m_appDirectory);
		}

		/// <summary>Gets the hash code of the current application directory.</summary>
		/// <returns>The hash code of the current application directory.</returns>
		// Token: 0x0600284E RID: 10318 RVA: 0x000945BE File Offset: 0x000927BE
		public override int GetHashCode()
		{
			return this.m_appDirectory.GetHashCode();
		}

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		// Token: 0x0600284F RID: 10319 RVA: 0x000945CB File Offset: 0x000927CB
		public override EvidenceBase Clone()
		{
			return new ApplicationDirectory(this.m_appDirectory);
		}

		/// <summary>Creates a new copy of the <see cref="T:System.Security.Policy.ApplicationDirectory" />.</summary>
		/// <returns>A new, identical copy of the <see cref="T:System.Security.Policy.ApplicationDirectory" />.</returns>
		// Token: 0x06002850 RID: 10320 RVA: 0x000945D8 File Offset: 0x000927D8
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002851 RID: 10321 RVA: 0x000945E0 File Offset: 0x000927E0
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.ApplicationDirectory");
			securityElement.AddAttribute("version", "1");
			if (this.m_appDirectory != null)
			{
				securityElement.AddChild(new SecurityElement("Directory", this.m_appDirectory.ToString()));
			}
			return securityElement;
		}

		/// <summary>Gets a string representation of the state of the <see cref="T:System.Security.Policy.ApplicationDirectory" /> evidence object.</summary>
		/// <returns>A representation of the state of the <see cref="T:System.Security.Policy.ApplicationDirectory" /> evidence object.</returns>
		// Token: 0x06002852 RID: 10322 RVA: 0x0009462C File Offset: 0x0009282C
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x0400104E RID: 4174
		private URLString m_appDirectory;
	}
}
