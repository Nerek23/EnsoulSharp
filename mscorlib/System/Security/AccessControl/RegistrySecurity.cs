using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using Microsoft.Win32.SafeHandles;

namespace System.Security.AccessControl
{
	/// <summary>Represents the Windows access control security for a registry key. This class cannot be inherited.</summary>
	// Token: 0x0200022F RID: 559
	public sealed class RegistrySecurity : NativeObjectSecurity
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.RegistrySecurity" /> class with default values.</summary>
		// Token: 0x06002023 RID: 8227 RVA: 0x00070FD4 File Offset: 0x0006F1D4
		public RegistrySecurity() : base(true, ResourceType.RegistryKey)
		{
		}

		// Token: 0x06002024 RID: 8228 RVA: 0x00070FDE File Offset: 0x0006F1DE
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		internal RegistrySecurity(SafeRegistryHandle hKey, string name, AccessControlSections includeSections) : base(true, ResourceType.RegistryKey, hKey, includeSections, new NativeObjectSecurity.ExceptionFromErrorCode(RegistrySecurity._HandleErrorCode), null)
		{
			new RegistryPermission(RegistryPermissionAccess.NoAccess, AccessControlActions.View, name).Demand();
		}

		// Token: 0x06002025 RID: 8229 RVA: 0x00071004 File Offset: 0x0006F204
		[SecurityCritical]
		private static Exception _HandleErrorCode(int errorCode, string name, SafeHandle handle, object context)
		{
			Exception result = null;
			if (errorCode != 2)
			{
				if (errorCode != 6)
				{
					if (errorCode == 123)
					{
						result = new ArgumentException(Environment.GetResourceString("Arg_RegInvalidKeyName", new object[]
						{
							"name"
						}));
					}
				}
				else
				{
					result = new ArgumentException(Environment.GetResourceString("AccessControl_InvalidHandle"));
				}
			}
			else
			{
				result = new IOException(Environment.GetResourceString("Arg_RegKeyNotFound", new object[]
				{
					errorCode
				}));
			}
			return result;
		}

		/// <summary>Creates a new access control rule for the specified user, with the specified access rights, access control, and flags.</summary>
		/// <param name="identityReference">An <see cref="T:System.Security.Principal.IdentityReference" /> that identifies the user or group the rule applies to.</param>
		/// <param name="accessMask">A bitwise combination of <see cref="T:System.Security.AccessControl.RegistryRights" /> values specifying the access rights to allow or deny, cast to an integer.</param>
		/// <param name="isInherited">A Boolean value specifying whether the rule is inherited.</param>
		/// <param name="inheritanceFlags">A bitwise combination of <see cref="T:System.Security.AccessControl.InheritanceFlags" /> values specifying how the rule is inherited by subkeys.</param>
		/// <param name="propagationFlags">A bitwise combination of <see cref="T:System.Security.AccessControl.PropagationFlags" /> values that modify the way the rule is inherited by subkeys. Meaningless if the value of <paramref name="inheritanceFlags" /> is <see cref="F:System.Security.AccessControl.InheritanceFlags.None" />.</param>
		/// <param name="type">One of the <see cref="T:System.Security.AccessControl.AccessControlType" /> values specifying whether the rights are allowed or denied.</param>
		/// <returns>A <see cref="T:System.Security.AccessControl.RegistryAccessRule" /> object representing the specified rights for the specified user.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="accessMask" />, <paramref name="inheritanceFlags" />, <paramref name="propagationFlags" />, or <paramref name="type" /> specifies an invalid value.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="identityReference" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="accessMask" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="identityReference" /> is neither of type <see cref="T:System.Security.Principal.SecurityIdentifier" />, nor of a type such as <see cref="T:System.Security.Principal.NTAccount" /> that can be converted to type <see cref="T:System.Security.Principal.SecurityIdentifier" />.</exception>
		// Token: 0x06002026 RID: 8230 RVA: 0x00071074 File Offset: 0x0006F274
		public override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
		{
			return new RegistryAccessRule(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, type);
		}

		/// <summary>Creates a new audit rule, specifying the user the rule applies to, the access rights to audit, the inheritance and propagation of the rule, and the outcome that triggers the rule.</summary>
		/// <param name="identityReference">An <see cref="T:System.Security.Principal.IdentityReference" /> that identifies the user or group the rule applies to.</param>
		/// <param name="accessMask">A bitwise combination of <see cref="T:System.Security.AccessControl.RegistryRights" /> values specifying the access rights to audit, cast to an integer.</param>
		/// <param name="isInherited">A Boolean value specifying whether the rule is inherited.</param>
		/// <param name="inheritanceFlags">A bitwise combination of <see cref="T:System.Security.AccessControl.InheritanceFlags" /> values specifying how the rule is inherited by subkeys.</param>
		/// <param name="propagationFlags">A bitwise combination of <see cref="T:System.Security.AccessControl.PropagationFlags" /> values that modify the way the rule is inherited by subkeys. Meaningless if the value of <paramref name="inheritanceFlags" /> is <see cref="F:System.Security.AccessControl.InheritanceFlags.None" />.</param>
		/// <param name="flags">A bitwise combination of <see cref="T:System.Security.AccessControl.AuditFlags" /> values specifying whether to audit successful access, failed access, or both.</param>
		/// <returns>A <see cref="T:System.Security.AccessControl.RegistryAuditRule" /> object representing the specified audit rule for the specified user, with the specified flags. The return type of the method is the base class, <see cref="T:System.Security.AccessControl.AuditRule" />, but the return value can be cast safely to the derived class.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="accessMask" />, <paramref name="inheritanceFlags" />, <paramref name="propagationFlags" />, or <paramref name="flags" /> specifies an invalid value.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="identityReference" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="accessMask" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="identityReference" /> is neither of type <see cref="T:System.Security.Principal.SecurityIdentifier" />, nor of a type such as <see cref="T:System.Security.Principal.NTAccount" /> that can be converted to type <see cref="T:System.Security.Principal.SecurityIdentifier" />.</exception>
		// Token: 0x06002027 RID: 8231 RVA: 0x00071084 File Offset: 0x0006F284
		public override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
		{
			return new RegistryAuditRule(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, flags);
		}

		// Token: 0x06002028 RID: 8232 RVA: 0x00071094 File Offset: 0x0006F294
		internal AccessControlSections GetAccessControlSectionsFromChanges()
		{
			AccessControlSections accessControlSections = AccessControlSections.None;
			if (base.AccessRulesModified)
			{
				accessControlSections = AccessControlSections.Access;
			}
			if (base.AuditRulesModified)
			{
				accessControlSections |= AccessControlSections.Audit;
			}
			if (base.OwnerModified)
			{
				accessControlSections |= AccessControlSections.Owner;
			}
			if (base.GroupModified)
			{
				accessControlSections |= AccessControlSections.Group;
			}
			return accessControlSections;
		}

		// Token: 0x06002029 RID: 8233 RVA: 0x000710D4 File Offset: 0x0006F2D4
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		internal void Persist(SafeRegistryHandle hKey, string keyName)
		{
			new RegistryPermission(RegistryPermissionAccess.NoAccess, AccessControlActions.Change, keyName).Demand();
			base.WriteLock();
			try
			{
				AccessControlSections accessControlSectionsFromChanges = this.GetAccessControlSectionsFromChanges();
				if (accessControlSectionsFromChanges != AccessControlSections.None)
				{
					base.Persist(hKey, accessControlSectionsFromChanges);
					base.OwnerModified = (base.GroupModified = (base.AuditRulesModified = (base.AccessRulesModified = false)));
				}
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Searches for a matching access control with which the new rule can be merged. If none are found, adds the new rule.</summary>
		/// <param name="rule">The access control rule to add.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rule" /> is <see langword="null" />.</exception>
		// Token: 0x0600202A RID: 8234 RVA: 0x00071144 File Offset: 0x0006F344
		public void AddAccessRule(RegistryAccessRule rule)
		{
			base.AddAccessRule(rule);
		}

		/// <summary>Removes all access control rules with the same user and <see cref="T:System.Security.AccessControl.AccessControlType" /> (allow or deny) as the specified rule, and then adds the specified rule.</summary>
		/// <param name="rule">The <see cref="T:System.Security.AccessControl.RegistryAccessRule" /> to add. The user and <see cref="T:System.Security.AccessControl.AccessControlType" /> of this rule determine the rules to remove before this rule is added.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rule" /> is <see langword="null" />.</exception>
		// Token: 0x0600202B RID: 8235 RVA: 0x0007114D File Offset: 0x0006F34D
		public void SetAccessRule(RegistryAccessRule rule)
		{
			base.SetAccessRule(rule);
		}

		/// <summary>Removes all access control rules with the same user as the specified rule, regardless of <see cref="T:System.Security.AccessControl.AccessControlType" />, and then adds the specified rule.</summary>
		/// <param name="rule">The <see cref="T:System.Security.AccessControl.RegistryAccessRule" /> to add. The user specified by this rule determines the rules to remove before this rule is added.</param>
		// Token: 0x0600202C RID: 8236 RVA: 0x00071156 File Offset: 0x0006F356
		public void ResetAccessRule(RegistryAccessRule rule)
		{
			base.ResetAccessRule(rule);
		}

		/// <summary>Searches for an access control rule with the same user and <see cref="T:System.Security.AccessControl.AccessControlType" /> (allow or deny) as the specified access rule, and with compatible inheritance and propagation flags; if such a rule is found, the rights contained in the specified access rule are removed from it.</summary>
		/// <param name="rule">A <see cref="T:System.Security.AccessControl.RegistryAccessRule" /> that specifies the user and <see cref="T:System.Security.AccessControl.AccessControlType" /> to search for, and a set of inheritance and propagation flags that a matching rule, if found, must be compatible with. Specifies the rights to remove from the compatible rule, if found.</param>
		/// <returns>
		///   <see langword="true" /> if a compatible rule is found; otherwise <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rule" /> is <see langword="null" />.</exception>
		// Token: 0x0600202D RID: 8237 RVA: 0x0007115F File Offset: 0x0006F35F
		public bool RemoveAccessRule(RegistryAccessRule rule)
		{
			return base.RemoveAccessRule(rule);
		}

		/// <summary>Searches for all access control rules with the same user and <see cref="T:System.Security.AccessControl.AccessControlType" /> (allow or deny) as the specified rule and, if found, removes them.</summary>
		/// <param name="rule">A <see cref="T:System.Security.AccessControl.RegistryAccessRule" /> that specifies the user and <see cref="T:System.Security.AccessControl.AccessControlType" /> to search for. Any rights, inheritance flags, or propagation flags specified by this rule are ignored.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rule" /> is <see langword="null" />.</exception>
		// Token: 0x0600202E RID: 8238 RVA: 0x00071168 File Offset: 0x0006F368
		public void RemoveAccessRuleAll(RegistryAccessRule rule)
		{
			base.RemoveAccessRuleAll(rule);
		}

		/// <summary>Searches for an access control rule that exactly matches the specified rule and, if found, removes it.</summary>
		/// <param name="rule">The <see cref="T:System.Security.AccessControl.RegistryAccessRule" /> to remove.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rule" /> is <see langword="null" />.</exception>
		// Token: 0x0600202F RID: 8239 RVA: 0x00071171 File Offset: 0x0006F371
		public void RemoveAccessRuleSpecific(RegistryAccessRule rule)
		{
			base.RemoveAccessRuleSpecific(rule);
		}

		/// <summary>Searches for an audit rule with which the new rule can be merged. If none are found, adds the new rule.</summary>
		/// <param name="rule">The audit rule to add. The user specified by this rule determines the search.</param>
		// Token: 0x06002030 RID: 8240 RVA: 0x0007117A File Offset: 0x0006F37A
		public void AddAuditRule(RegistryAuditRule rule)
		{
			base.AddAuditRule(rule);
		}

		/// <summary>Removes all audit rules with the same user as the specified rule, regardless of the <see cref="T:System.Security.AccessControl.AuditFlags" /> value, and then adds the specified rule.</summary>
		/// <param name="rule">The <see cref="T:System.Security.AccessControl.RegistryAuditRule" /> to add. The user specified by this rule determines the rules to remove before this rule is added.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rule" /> is <see langword="null" />.</exception>
		// Token: 0x06002031 RID: 8241 RVA: 0x00071183 File Offset: 0x0006F383
		public void SetAuditRule(RegistryAuditRule rule)
		{
			base.SetAuditRule(rule);
		}

		/// <summary>Searches for an audit control rule with the same user as the specified rule, and with compatible inheritance and propagation flags; if a compatible rule is found, the rights contained in the specified rule are removed from it.</summary>
		/// <param name="rule">A <see cref="T:System.Security.AccessControl.RegistryAuditRule" /> that specifies the user to search for, and a set of inheritance and propagation flags that a matching rule, if found, must be compatible with. Specifies the rights to remove from the compatible rule, if found.</param>
		/// <returns>
		///   <see langword="true" /> if a compatible rule is found; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rule" /> is <see langword="null" />.</exception>
		// Token: 0x06002032 RID: 8242 RVA: 0x0007118C File Offset: 0x0006F38C
		public bool RemoveAuditRule(RegistryAuditRule rule)
		{
			return base.RemoveAuditRule(rule);
		}

		/// <summary>Searches for all audit rules with the same user as the specified rule and, if found, removes them.</summary>
		/// <param name="rule">A <see cref="T:System.Security.AccessControl.RegistryAuditRule" /> that specifies the user to search for. Any rights, inheritance flags, or propagation flags specified by this rule are ignored.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rule" /> is <see langword="null" />.</exception>
		// Token: 0x06002033 RID: 8243 RVA: 0x00071195 File Offset: 0x0006F395
		public void RemoveAuditRuleAll(RegistryAuditRule rule)
		{
			base.RemoveAuditRuleAll(rule);
		}

		/// <summary>Searches for an audit rule that exactly matches the specified rule and, if found, removes it.</summary>
		/// <param name="rule">The <see cref="T:System.Security.AccessControl.RegistryAuditRule" /> to be removed.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rule" /> is <see langword="null" />.</exception>
		// Token: 0x06002034 RID: 8244 RVA: 0x0007119E File Offset: 0x0006F39E
		public void RemoveAuditRuleSpecific(RegistryAuditRule rule)
		{
			base.RemoveAuditRuleSpecific(rule);
		}

		/// <summary>Gets the enumeration type that the <see cref="T:System.Security.AccessControl.RegistrySecurity" /> class uses to represent access rights.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing the <see cref="T:System.Security.AccessControl.RegistryRights" /> enumeration.</returns>
		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06002035 RID: 8245 RVA: 0x000711A7 File Offset: 0x0006F3A7
		public override Type AccessRightType
		{
			get
			{
				return typeof(RegistryRights);
			}
		}

		/// <summary>Gets the type that the <see cref="T:System.Security.AccessControl.RegistrySecurity" /> class uses to represent access rules.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing the <see cref="T:System.Security.AccessControl.RegistryAccessRule" /> class.</returns>
		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06002036 RID: 8246 RVA: 0x000711B3 File Offset: 0x0006F3B3
		public override Type AccessRuleType
		{
			get
			{
				return typeof(RegistryAccessRule);
			}
		}

		/// <summary>Gets the type that the <see cref="T:System.Security.AccessControl.RegistrySecurity" /> class uses to represent audit rules.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing the <see cref="T:System.Security.AccessControl.RegistryAuditRule" /> class.</returns>
		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06002037 RID: 8247 RVA: 0x000711BF File Offset: 0x0006F3BF
		public override Type AuditRuleType
		{
			get
			{
				return typeof(RegistryAuditRule);
			}
		}
	}
}
