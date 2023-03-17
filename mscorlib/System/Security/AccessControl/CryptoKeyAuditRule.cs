using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	/// <summary>Represents an audit rule for a cryptographic key. An audit rule represents a combination of a user's identity and an access mask. An audit rule also contains information about the how the rule is inherited by child objects, how that inheritance is propagated, and for what conditions it is audited.</summary>
	// Token: 0x02000212 RID: 530
	public sealed class CryptoKeyAuditRule : AuditRule
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.CryptoKeyAuditRule" /> class using the specified values.</summary>
		/// <param name="identity">The identity to which the audit rule applies. This parameter must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier" />.</param>
		/// <param name="cryptoKeyRights">The cryptographic key operation for which this audit rule generates audits.</param>
		/// <param name="flags">The conditions that generate audits.</param>
		// Token: 0x06001EFF RID: 7935 RVA: 0x0006D142 File Offset: 0x0006B342
		public CryptoKeyAuditRule(IdentityReference identity, CryptoKeyRights cryptoKeyRights, AuditFlags flags) : this(identity, CryptoKeyAuditRule.AccessMaskFromRights(cryptoKeyRights), false, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.CryptoKeyAuditRule" /> class using the specified values.</summary>
		/// <param name="identity">The identity to which the audit rule applies.</param>
		/// <param name="cryptoKeyRights">The cryptographic key operation for which this audit rule generates audits.</param>
		/// <param name="flags">The conditions that generate audits.</param>
		// Token: 0x06001F00 RID: 7936 RVA: 0x0006D155 File Offset: 0x0006B355
		public CryptoKeyAuditRule(string identity, CryptoKeyRights cryptoKeyRights, AuditFlags flags) : this(new NTAccount(identity), CryptoKeyAuditRule.AccessMaskFromRights(cryptoKeyRights), false, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x0006D16D File Offset: 0x0006B36D
		private CryptoKeyAuditRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, flags)
		{
		}

		/// <summary>Gets the cryptographic key operation for which this audit rule generates audits.</summary>
		/// <returns>The cryptographic key operation for which this audit rule generates audits.</returns>
		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06001F02 RID: 7938 RVA: 0x0006D17E File Offset: 0x0006B37E
		public CryptoKeyRights CryptoKeyRights
		{
			get
			{
				return CryptoKeyAuditRule.RightsFromAccessMask(base.AccessMask);
			}
		}

		// Token: 0x06001F03 RID: 7939 RVA: 0x0006D18B File Offset: 0x0006B38B
		private static int AccessMaskFromRights(CryptoKeyRights cryptoKeyRights)
		{
			return (int)cryptoKeyRights;
		}

		// Token: 0x06001F04 RID: 7940 RVA: 0x0006D18E File Offset: 0x0006B38E
		internal static CryptoKeyRights RightsFromAccessMask(int accessMask)
		{
			return (CryptoKeyRights)accessMask;
		}
	}
}
