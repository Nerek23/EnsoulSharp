using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	/// <summary>Provides the ability to control access to a cryptographic key object without direct manipulation of  an Access Control List (ACL).</summary>
	// Token: 0x02000213 RID: 531
	public sealed class CryptoKeySecurity : NativeObjectSecurity
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> class.</summary>
		// Token: 0x06001F05 RID: 7941 RVA: 0x0006D191 File Offset: 0x0006B391
		public CryptoKeySecurity() : base(false, ResourceType.FileObject)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> class by using the specified security descriptor.</summary>
		/// <param name="securityDescriptor">The security descriptor from which to create the new <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</param>
		// Token: 0x06001F06 RID: 7942 RVA: 0x0006D19B File Offset: 0x0006B39B
		[SecuritySafeCritical]
		public CryptoKeySecurity(CommonSecurityDescriptor securityDescriptor) : base(ResourceType.FileObject, securityDescriptor)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.AccessRule" /> class with the specified values.</summary>
		/// <param name="identityReference">The identity to which the access rule applies.  It must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier" />.</param>
		/// <param name="accessMask">The access mask of this rule. The access mask is a 32-bit collection of anonymous bits, the meaning of which is defined by the individual integrators.</param>
		/// <param name="isInherited">true if this rule is inherited from a parent container.</param>
		/// <param name="inheritanceFlags">Specifies the inheritance properties of the access rule.</param>
		/// <param name="propagationFlags">Specifies whether inherited access rules are automatically propagated. The propagation flags are ignored if <paramref name="inheritanceFlags" /> is set to <see cref="F:System.Security.AccessControl.InheritanceFlags.None" />.</param>
		/// <param name="type">Specifies the valid access control type.</param>
		/// <returns>The <see cref="T:System.Security.AccessControl.AccessRule" /> object that this method creates.</returns>
		// Token: 0x06001F07 RID: 7943 RVA: 0x0006D1A5 File Offset: 0x0006B3A5
		public sealed override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
		{
			return new CryptoKeyAccessRule(identityReference, CryptoKeyAccessRule.RightsFromAccessMask(accessMask), type);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.AuditRule" /> class with the specified values.</summary>
		/// <param name="identityReference">The identity to which the audit rule applies.  It must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier" />.</param>
		/// <param name="accessMask">The access mask of this rule. The access mask is a 32-bit collection of anonymous bits, the meaning of which is defined by the individual integrators.</param>
		/// <param name="isInherited">
		///   <see langword="true" /> if this rule is inherited from a parent container.</param>
		/// <param name="inheritanceFlags">Specifies the inheritance properties of the audit rule.</param>
		/// <param name="propagationFlags">Specifies whether inherited audit rules are automatically propagated. The propagation flags are ignored if <paramref name="inheritanceFlags" /> is set to <see cref="F:System.Security.AccessControl.InheritanceFlags.None" />.</param>
		/// <param name="flags">Specifies the conditions for which the rule is audited.</param>
		/// <returns>The <see cref="T:System.Security.AccessControl.AuditRule" /> object that this method creates.</returns>
		// Token: 0x06001F08 RID: 7944 RVA: 0x0006D1B5 File Offset: 0x0006B3B5
		public sealed override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
		{
			return new CryptoKeyAuditRule(identityReference, CryptoKeyAuditRule.RightsFromAccessMask(accessMask), flags);
		}

		/// <summary>Adds the specified access rule to the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</summary>
		/// <param name="rule">The access rule to add.</param>
		// Token: 0x06001F09 RID: 7945 RVA: 0x0006D1C5 File Offset: 0x0006B3C5
		public void AddAccessRule(CryptoKeyAccessRule rule)
		{
			base.AddAccessRule(rule);
		}

		/// <summary>Removes all access rules that contain the same security identifier and qualifier as the specified access rule in the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object and then adds the specified access rule.</summary>
		/// <param name="rule">The access rule to set.</param>
		// Token: 0x06001F0A RID: 7946 RVA: 0x0006D1CE File Offset: 0x0006B3CE
		public void SetAccessRule(CryptoKeyAccessRule rule)
		{
			base.SetAccessRule(rule);
		}

		/// <summary>Removes all access rules in the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object and then adds the specified access rule.</summary>
		/// <param name="rule">The access rule to reset.</param>
		// Token: 0x06001F0B RID: 7947 RVA: 0x0006D1D7 File Offset: 0x0006B3D7
		public void ResetAccessRule(CryptoKeyAccessRule rule)
		{
			base.ResetAccessRule(rule);
		}

		/// <summary>Removes access rules that contain the same security identifier and access mask as the specified access rule from the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</summary>
		/// <param name="rule">The access rule to remove.</param>
		/// <returns>
		///   <see langword="true" /> if the access rule was successfully removed; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001F0C RID: 7948 RVA: 0x0006D1E0 File Offset: 0x0006B3E0
		public bool RemoveAccessRule(CryptoKeyAccessRule rule)
		{
			return base.RemoveAccessRule(rule);
		}

		/// <summary>Removes all access rules that have the same security identifier as the specified access rule from the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</summary>
		/// <param name="rule">The access rule to remove.</param>
		// Token: 0x06001F0D RID: 7949 RVA: 0x0006D1E9 File Offset: 0x0006B3E9
		public void RemoveAccessRuleAll(CryptoKeyAccessRule rule)
		{
			base.RemoveAccessRuleAll(rule);
		}

		/// <summary>Removes all access rules that exactly match the specified access rule from the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</summary>
		/// <param name="rule">The access rule to remove.</param>
		// Token: 0x06001F0E RID: 7950 RVA: 0x0006D1F2 File Offset: 0x0006B3F2
		public void RemoveAccessRuleSpecific(CryptoKeyAccessRule rule)
		{
			base.RemoveAccessRuleSpecific(rule);
		}

		/// <summary>Adds the specified audit rule to the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</summary>
		/// <param name="rule">The audit rule to add.</param>
		// Token: 0x06001F0F RID: 7951 RVA: 0x0006D1FB File Offset: 0x0006B3FB
		public void AddAuditRule(CryptoKeyAuditRule rule)
		{
			base.AddAuditRule(rule);
		}

		/// <summary>Removes all audit rules that contain the same security identifier and qualifier as the specified audit rule in the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object and then adds the specified audit rule.</summary>
		/// <param name="rule">The audit rule to set.</param>
		// Token: 0x06001F10 RID: 7952 RVA: 0x0006D204 File Offset: 0x0006B404
		public void SetAuditRule(CryptoKeyAuditRule rule)
		{
			base.SetAuditRule(rule);
		}

		/// <summary>Removes audit rules that contain the same security identifier and access mask as the specified audit rule from the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</summary>
		/// <param name="rule">The audit rule to remove.</param>
		/// <returns>
		///   <see langword="true" /> if the audit rule was successfully removed; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001F11 RID: 7953 RVA: 0x0006D20D File Offset: 0x0006B40D
		public bool RemoveAuditRule(CryptoKeyAuditRule rule)
		{
			return base.RemoveAuditRule(rule);
		}

		/// <summary>Removes all audit rules that have the same security identifier as the specified audit rule from the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</summary>
		/// <param name="rule">The audit rule to remove.</param>
		// Token: 0x06001F12 RID: 7954 RVA: 0x0006D216 File Offset: 0x0006B416
		public void RemoveAuditRuleAll(CryptoKeyAuditRule rule)
		{
			base.RemoveAuditRuleAll(rule);
		}

		/// <summary>Removes all audit rules that exactly match the specified audit rule from the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</summary>
		/// <param name="rule">The audit rule to remove.</param>
		// Token: 0x06001F13 RID: 7955 RVA: 0x0006D21F File Offset: 0x0006B41F
		public void RemoveAuditRuleSpecific(CryptoKeyAuditRule rule)
		{
			base.RemoveAuditRuleSpecific(rule);
		}

		/// <summary>Gets the <see cref="T:System.Type" /> of the securable object associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</summary>
		/// <returns>The type of the securable object associated with this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</returns>
		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06001F14 RID: 7956 RVA: 0x0006D228 File Offset: 0x0006B428
		public override Type AccessRightType
		{
			get
			{
				return typeof(CryptoKeyRights);
			}
		}

		/// <summary>Gets the <see cref="T:System.Type" /> of the object associated with the access rules of this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object. The <see cref="T:System.Type" /> object must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</summary>
		/// <returns>The type of the object associated with the access rules of this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</returns>
		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06001F15 RID: 7957 RVA: 0x0006D234 File Offset: 0x0006B434
		public override Type AccessRuleType
		{
			get
			{
				return typeof(CryptoKeyAccessRule);
			}
		}

		/// <summary>Gets the <see cref="T:System.Type" /> object associated with the audit rules of this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object. The <see cref="T:System.Type" /> object must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</summary>
		/// <returns>The type of the object associated with the audit rules of this <see cref="T:System.Security.AccessControl.CryptoKeySecurity" /> object.</returns>
		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06001F16 RID: 7958 RVA: 0x0006D240 File Offset: 0x0006B440
		public override Type AuditRuleType
		{
			get
			{
				return typeof(CryptoKeyAuditRule);
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06001F17 RID: 7959 RVA: 0x0006D24C File Offset: 0x0006B44C
		internal AccessControlSections ChangedAccessControlSections
		{
			[SecurityCritical]
			get
			{
				AccessControlSections accessControlSections = AccessControlSections.None;
				bool flag = false;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					RuntimeHelpers.PrepareConstrainedRegions();
					try
					{
					}
					finally
					{
						base.ReadLock();
						flag = true;
					}
					if (base.AccessRulesModified)
					{
						accessControlSections |= AccessControlSections.Access;
					}
					if (base.AuditRulesModified)
					{
						accessControlSections |= AccessControlSections.Audit;
					}
					if (base.GroupModified)
					{
						accessControlSections |= AccessControlSections.Group;
					}
					if (base.OwnerModified)
					{
						accessControlSections |= AccessControlSections.Owner;
					}
				}
				finally
				{
					if (flag)
					{
						base.ReadUnlock();
					}
				}
				return accessControlSections;
			}
		}

		// Token: 0x04000B25 RID: 2853
		private const ResourceType s_ResourceType = ResourceType.FileObject;
	}
}
