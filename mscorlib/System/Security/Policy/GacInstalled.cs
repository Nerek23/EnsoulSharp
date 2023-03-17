using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Security.Policy
{
	/// <summary>Confirms that a code assembly originates in the global assembly cache (GAC) as evidence for policy evaluation. This class cannot be inherited.</summary>
	// Token: 0x02000346 RID: 838
	[ComVisible(true)]
	[Serializable]
	public sealed class GacInstalled : EvidenceBase, IIdentityPermissionFactory
	{
		/// <summary>Creates a new identity permission that corresponds to the current object.</summary>
		/// <param name="evidence">The <see cref="T:System.Security.Policy.Evidence" /> from which to construct the identity permission.</param>
		/// <returns>A new identity permission that corresponds to the current object.</returns>
		// Token: 0x06002A9C RID: 10908 RVA: 0x0009E46B File Offset: 0x0009C66B
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new GacIdentityPermission();
		}

		/// <summary>Indicates whether the current object is equivalent to the specified object.</summary>
		/// <param name="o">The object to compare with the current object.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="o" /> is a <see cref="T:System.Security.Policy.GacInstalled" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002A9D RID: 10909 RVA: 0x0009E472 File Offset: 0x0009C672
		public override bool Equals(object o)
		{
			return o is GacInstalled;
		}

		/// <summary>Returns a hash code for the current object.</summary>
		/// <returns>A hash code for the current object.</returns>
		// Token: 0x06002A9E RID: 10910 RVA: 0x0009E47D File Offset: 0x0009C67D
		public override int GetHashCode()
		{
			return 0;
		}

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		// Token: 0x06002A9F RID: 10911 RVA: 0x0009E480 File Offset: 0x0009C680
		public override EvidenceBase Clone()
		{
			return new GacInstalled();
		}

		/// <summary>Creates an equivalent copy of the current object.</summary>
		/// <returns>An equivalent copy of <see cref="T:System.Security.Policy.GacInstalled" />.</returns>
		// Token: 0x06002AA0 RID: 10912 RVA: 0x0009E487 File Offset: 0x0009C687
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002AA1 RID: 10913 RVA: 0x0009E490 File Offset: 0x0009C690
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement(base.GetType().FullName);
			securityElement.AddAttribute("version", "1");
			return securityElement;
		}

		/// <summary>Returns a string representation of the current  object.</summary>
		/// <returns>A string representation of the current object.</returns>
		// Token: 0x06002AA2 RID: 10914 RVA: 0x0009E4BF File Offset: 0x0009C6BF
		public override string ToString()
		{
			return this.ToXml().ToString();
		}
	}
}
