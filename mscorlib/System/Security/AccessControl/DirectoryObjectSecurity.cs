using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	/// <summary>Provides the ability to control access to directory objects without direct manipulation of Access Control Lists (ACLs).</summary>
	// Token: 0x02000229 RID: 553
	public abstract class DirectoryObjectSecurity : ObjectSecurity
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> class.</summary>
		// Token: 0x06001FF4 RID: 8180 RVA: 0x0006FAD8 File Offset: 0x0006DCD8
		protected DirectoryObjectSecurity() : base(true, true)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> class with the specified security descriptor.</summary>
		/// <param name="securityDescriptor">The security descriptor to be associated with the new <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object.</param>
		// Token: 0x06001FF5 RID: 8181 RVA: 0x0006FAE2 File Offset: 0x0006DCE2
		protected DirectoryObjectSecurity(CommonSecurityDescriptor securityDescriptor) : base(securityDescriptor)
		{
		}

		// Token: 0x06001FF6 RID: 8182 RVA: 0x0006FAEC File Offset: 0x0006DCEC
		private AuthorizationRuleCollection GetRules(bool access, bool includeExplicit, bool includeInherited, Type targetType)
		{
			base.ReadLock();
			AuthorizationRuleCollection result;
			try
			{
				AuthorizationRuleCollection authorizationRuleCollection = new AuthorizationRuleCollection();
				if (!SecurityIdentifier.IsValidTargetTypeStatic(targetType))
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_MustBeIdentityReferenceType"), "targetType");
				}
				CommonAcl commonAcl = null;
				if (access)
				{
					if ((this._securityDescriptor.ControlFlags & ControlFlags.DiscretionaryAclPresent) != ControlFlags.None)
					{
						commonAcl = this._securityDescriptor.DiscretionaryAcl;
					}
				}
				else if ((this._securityDescriptor.ControlFlags & ControlFlags.SystemAclPresent) != ControlFlags.None)
				{
					commonAcl = this._securityDescriptor.SystemAcl;
				}
				if (commonAcl == null)
				{
					result = authorizationRuleCollection;
				}
				else
				{
					IdentityReferenceCollection identityReferenceCollection = null;
					if (targetType != typeof(SecurityIdentifier))
					{
						IdentityReferenceCollection identityReferenceCollection2 = new IdentityReferenceCollection(commonAcl.Count);
						for (int i = 0; i < commonAcl.Count; i++)
						{
							QualifiedAce qualifiedAce = commonAcl[i] as QualifiedAce;
							if (!(qualifiedAce == null) && !qualifiedAce.IsCallback)
							{
								if (access)
								{
									if (qualifiedAce.AceQualifier != AceQualifier.AccessAllowed && qualifiedAce.AceQualifier != AceQualifier.AccessDenied)
									{
										goto IL_EB;
									}
								}
								else if (qualifiedAce.AceQualifier != AceQualifier.SystemAudit)
								{
									goto IL_EB;
								}
								identityReferenceCollection2.Add(qualifiedAce.SecurityIdentifier);
							}
							IL_EB:;
						}
						identityReferenceCollection = identityReferenceCollection2.Translate(targetType);
					}
					int j = 0;
					while (j < commonAcl.Count)
					{
						QualifiedAce qualifiedAce2 = commonAcl[j] as CommonAce;
						if (!(qualifiedAce2 == null))
						{
							goto IL_142;
						}
						qualifiedAce2 = (commonAcl[j] as ObjectAce);
						if (!(qualifiedAce2 == null))
						{
							goto IL_142;
						}
						IL_306:
						j++;
						continue;
						IL_142:
						if (qualifiedAce2.IsCallback)
						{
							goto IL_306;
						}
						if (access)
						{
							if (qualifiedAce2.AceQualifier != AceQualifier.AccessAllowed && qualifiedAce2.AceQualifier != AceQualifier.AccessDenied)
							{
								goto IL_306;
							}
						}
						else if (qualifiedAce2.AceQualifier != AceQualifier.SystemAudit)
						{
							goto IL_306;
						}
						if ((!includeExplicit || (qualifiedAce2.AceFlags & AceFlags.Inherited) != AceFlags.None) && (!includeInherited || (qualifiedAce2.AceFlags & AceFlags.Inherited) == AceFlags.None))
						{
							goto IL_306;
						}
						IdentityReference identityReference = (targetType == typeof(SecurityIdentifier)) ? qualifiedAce2.SecurityIdentifier : identityReferenceCollection[j];
						if (access)
						{
							AccessControlType type;
							if (qualifiedAce2.AceQualifier == AceQualifier.AccessAllowed)
							{
								type = AccessControlType.Allow;
							}
							else
							{
								type = AccessControlType.Deny;
							}
							if (qualifiedAce2 is ObjectAce)
							{
								ObjectAce objectAce = qualifiedAce2 as ObjectAce;
								authorizationRuleCollection.AddRule(this.AccessRuleFactory(identityReference, objectAce.AccessMask, objectAce.IsInherited, objectAce.InheritanceFlags, objectAce.PropagationFlags, type, objectAce.ObjectAceType, objectAce.InheritedObjectAceType));
								goto IL_306;
							}
							CommonAce commonAce = qualifiedAce2 as CommonAce;
							if (!(commonAce == null))
							{
								authorizationRuleCollection.AddRule(this.AccessRuleFactory(identityReference, commonAce.AccessMask, commonAce.IsInherited, commonAce.InheritanceFlags, commonAce.PropagationFlags, type));
								goto IL_306;
							}
							goto IL_306;
						}
						else
						{
							if (qualifiedAce2 is ObjectAce)
							{
								ObjectAce objectAce2 = qualifiedAce2 as ObjectAce;
								authorizationRuleCollection.AddRule(this.AuditRuleFactory(identityReference, objectAce2.AccessMask, objectAce2.IsInherited, objectAce2.InheritanceFlags, objectAce2.PropagationFlags, objectAce2.AuditFlags, objectAce2.ObjectAceType, objectAce2.InheritedObjectAceType));
								goto IL_306;
							}
							CommonAce commonAce2 = qualifiedAce2 as CommonAce;
							if (!(commonAce2 == null))
							{
								authorizationRuleCollection.AddRule(this.AuditRuleFactory(identityReference, commonAce2.AccessMask, commonAce2.IsInherited, commonAce2.InheritanceFlags, commonAce2.PropagationFlags, commonAce2.AuditFlags));
								goto IL_306;
							}
							goto IL_306;
						}
					}
					result = authorizationRuleCollection;
				}
			}
			finally
			{
				base.ReadUnlock();
			}
			return result;
		}

		// Token: 0x06001FF7 RID: 8183 RVA: 0x0006FE3C File Offset: 0x0006E03C
		private bool ModifyAccess(AccessControlModification modification, ObjectAccessRule rule, out bool modified)
		{
			bool flag = true;
			if (this._securityDescriptor.DiscretionaryAcl == null)
			{
				if (modification == AccessControlModification.Remove || modification == AccessControlModification.RemoveAll || modification == AccessControlModification.RemoveSpecific)
				{
					modified = false;
					return flag;
				}
				this._securityDescriptor.DiscretionaryAcl = new DiscretionaryAcl(base.IsContainer, base.IsDS, GenericAcl.AclRevisionDS, 1);
				this._securityDescriptor.AddControlFlags(ControlFlags.DiscretionaryAclPresent);
			}
			else if ((modification == AccessControlModification.Add || modification == AccessControlModification.Set || modification == AccessControlModification.Reset) && rule.ObjectFlags != ObjectAceFlags.None && this._securityDescriptor.DiscretionaryAcl.Revision < GenericAcl.AclRevisionDS)
			{
				byte[] array = new byte[this._securityDescriptor.DiscretionaryAcl.BinaryLength];
				this._securityDescriptor.DiscretionaryAcl.GetBinaryForm(array, 0);
				array[0] = GenericAcl.AclRevisionDS;
				this._securityDescriptor.DiscretionaryAcl = new DiscretionaryAcl(base.IsContainer, base.IsDS, new RawAcl(array, 0));
			}
			SecurityIdentifier sid = rule.IdentityReference.Translate(typeof(SecurityIdentifier)) as SecurityIdentifier;
			if (rule.AccessControlType == AccessControlType.Allow)
			{
				switch (modification)
				{
				case AccessControlModification.Add:
					this._securityDescriptor.DiscretionaryAcl.AddAccess(AccessControlType.Allow, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
					break;
				case AccessControlModification.Set:
					this._securityDescriptor.DiscretionaryAcl.SetAccess(AccessControlType.Allow, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
					break;
				case AccessControlModification.Reset:
					this._securityDescriptor.DiscretionaryAcl.RemoveAccess(AccessControlType.Deny, sid, -1, InheritanceFlags.ContainerInherit, PropagationFlags.None, ObjectAceFlags.None, Guid.Empty, Guid.Empty);
					this._securityDescriptor.DiscretionaryAcl.SetAccess(AccessControlType.Allow, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
					break;
				case AccessControlModification.Remove:
					flag = this._securityDescriptor.DiscretionaryAcl.RemoveAccess(AccessControlType.Allow, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
					break;
				case AccessControlModification.RemoveAll:
					flag = this._securityDescriptor.DiscretionaryAcl.RemoveAccess(AccessControlType.Allow, sid, -1, InheritanceFlags.ContainerInherit, PropagationFlags.None, ObjectAceFlags.None, Guid.Empty, Guid.Empty);
					if (!flag)
					{
						throw new SystemException();
					}
					break;
				case AccessControlModification.RemoveSpecific:
					this._securityDescriptor.DiscretionaryAcl.RemoveAccessSpecific(AccessControlType.Allow, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
					break;
				default:
					throw new ArgumentOutOfRangeException("modification", Environment.GetResourceString("ArgumentOutOfRange_Enum"));
				}
			}
			else
			{
				if (rule.AccessControlType != AccessControlType.Deny)
				{
					throw new SystemException();
				}
				switch (modification)
				{
				case AccessControlModification.Add:
					this._securityDescriptor.DiscretionaryAcl.AddAccess(AccessControlType.Deny, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
					break;
				case AccessControlModification.Set:
					this._securityDescriptor.DiscretionaryAcl.SetAccess(AccessControlType.Deny, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
					break;
				case AccessControlModification.Reset:
					this._securityDescriptor.DiscretionaryAcl.RemoveAccess(AccessControlType.Allow, sid, -1, InheritanceFlags.ContainerInherit, PropagationFlags.None, ObjectAceFlags.None, Guid.Empty, Guid.Empty);
					this._securityDescriptor.DiscretionaryAcl.SetAccess(AccessControlType.Deny, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
					break;
				case AccessControlModification.Remove:
					flag = this._securityDescriptor.DiscretionaryAcl.RemoveAccess(AccessControlType.Deny, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
					break;
				case AccessControlModification.RemoveAll:
					flag = this._securityDescriptor.DiscretionaryAcl.RemoveAccess(AccessControlType.Deny, sid, -1, InheritanceFlags.ContainerInherit, PropagationFlags.None, ObjectAceFlags.None, Guid.Empty, Guid.Empty);
					if (!flag)
					{
						throw new SystemException();
					}
					break;
				case AccessControlModification.RemoveSpecific:
					this._securityDescriptor.DiscretionaryAcl.RemoveAccessSpecific(AccessControlType.Deny, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
					break;
				default:
					throw new ArgumentOutOfRangeException("modification", Environment.GetResourceString("ArgumentOutOfRange_Enum"));
				}
			}
			modified = flag;
			base.AccessRulesModified |= modified;
			return flag;
		}

		// Token: 0x06001FF8 RID: 8184 RVA: 0x000702B4 File Offset: 0x0006E4B4
		private bool ModifyAudit(AccessControlModification modification, ObjectAuditRule rule, out bool modified)
		{
			bool flag = true;
			if (this._securityDescriptor.SystemAcl == null)
			{
				if (modification == AccessControlModification.Remove || modification == AccessControlModification.RemoveAll || modification == AccessControlModification.RemoveSpecific)
				{
					modified = false;
					return flag;
				}
				this._securityDescriptor.SystemAcl = new SystemAcl(base.IsContainer, base.IsDS, GenericAcl.AclRevisionDS, 1);
				this._securityDescriptor.AddControlFlags(ControlFlags.SystemAclPresent);
			}
			else if ((modification == AccessControlModification.Add || modification == AccessControlModification.Set || modification == AccessControlModification.Reset) && rule.ObjectFlags != ObjectAceFlags.None && this._securityDescriptor.SystemAcl.Revision < GenericAcl.AclRevisionDS)
			{
				byte[] array = new byte[this._securityDescriptor.SystemAcl.BinaryLength];
				this._securityDescriptor.SystemAcl.GetBinaryForm(array, 0);
				array[0] = GenericAcl.AclRevisionDS;
				this._securityDescriptor.SystemAcl = new SystemAcl(base.IsContainer, base.IsDS, new RawAcl(array, 0));
			}
			SecurityIdentifier sid = rule.IdentityReference.Translate(typeof(SecurityIdentifier)) as SecurityIdentifier;
			switch (modification)
			{
			case AccessControlModification.Add:
				this._securityDescriptor.SystemAcl.AddAudit(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
				break;
			case AccessControlModification.Set:
				this._securityDescriptor.SystemAcl.SetAudit(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
				break;
			case AccessControlModification.Reset:
				this._securityDescriptor.SystemAcl.RemoveAudit(AuditFlags.Success | AuditFlags.Failure, sid, -1, InheritanceFlags.ContainerInherit, PropagationFlags.None, ObjectAceFlags.None, Guid.Empty, Guid.Empty);
				this._securityDescriptor.SystemAcl.SetAudit(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
				break;
			case AccessControlModification.Remove:
				flag = this._securityDescriptor.SystemAcl.RemoveAudit(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
				break;
			case AccessControlModification.RemoveAll:
				flag = this._securityDescriptor.SystemAcl.RemoveAudit(AuditFlags.Success | AuditFlags.Failure, sid, -1, InheritanceFlags.ContainerInherit, PropagationFlags.None, ObjectAceFlags.None, Guid.Empty, Guid.Empty);
				if (!flag)
				{
					throw new SystemException();
				}
				break;
			case AccessControlModification.RemoveSpecific:
				this._securityDescriptor.SystemAcl.RemoveAuditSpecific(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
				break;
			default:
				throw new ArgumentOutOfRangeException("modification", Environment.GetResourceString("ArgumentOutOfRange_Enum"));
			}
			modified = flag;
			base.AuditRulesModified |= modified;
			return flag;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.AccessRule" /> class with the specified values.</summary>
		/// <param name="identityReference">The identity to which the access rule applies.  It must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier" />.</param>
		/// <param name="accessMask">The access mask of this rule. The access mask is a 32-bit collection of anonymous bits, the meaning of which is defined by the individual integrators.</param>
		/// <param name="isInherited">true if this rule is inherited from a parent container.</param>
		/// <param name="inheritanceFlags">Specifies the inheritance properties of the access rule.</param>
		/// <param name="propagationFlags">Specifies whether inherited access rules are automatically propagated. The propagation flags are ignored if <paramref name="inheritanceFlags" /> is set to <see cref="F:System.Security.AccessControl.InheritanceFlags.None" />.</param>
		/// <param name="type">Specifies the valid access control type.</param>
		/// <param name="objectType">The identity of the class of objects to which the new access rule applies.</param>
		/// <param name="inheritedObjectType">The identity of the class of child objects which can inherit the new access rule.</param>
		/// <returns>The <see cref="T:System.Security.AccessControl.AccessRule" /> object that this method creates.</returns>
		// Token: 0x06001FF9 RID: 8185 RVA: 0x0007057B File Offset: 0x0006E77B
		public virtual AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type, Guid objectType, Guid inheritedObjectType)
		{
			throw new NotImplementedException();
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.AuditRule" /> class with the specified values.</summary>
		/// <param name="identityReference">The identity to which the audit rule applies.  It must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier" />.</param>
		/// <param name="accessMask">The access mask of this rule. The access mask is a 32-bit collection of anonymous bits, the meaning of which is defined by the individual integrators.</param>
		/// <param name="isInherited">
		///   <see langword="true" /> if this rule is inherited from a parent container.</param>
		/// <param name="inheritanceFlags">Specifies the inheritance properties of the audit rule.</param>
		/// <param name="propagationFlags">Specifies whether inherited audit rules are automatically propagated. The propagation flags are ignored if <paramref name="inheritanceFlags" /> is set to <see cref="F:System.Security.AccessControl.InheritanceFlags.None" />.</param>
		/// <param name="flags">Specifies the conditions for which the rule is audited.</param>
		/// <param name="objectType">The identity of the class of objects to which the new audit rule applies.</param>
		/// <param name="inheritedObjectType">The identity of the class of child objects which can inherit the new audit rule.</param>
		/// <returns>The <see cref="T:System.Security.AccessControl.AuditRule" /> object that this method creates.</returns>
		// Token: 0x06001FFA RID: 8186 RVA: 0x00070582 File Offset: 0x0006E782
		public virtual AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags, Guid objectType, Guid inheritedObjectType)
		{
			throw new NotImplementedException();
		}

		/// <summary>Applies the specified modification to the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object.</summary>
		/// <param name="modification">The modification to apply to the DACL.</param>
		/// <param name="rule">The access rule to modify.</param>
		/// <param name="modified">
		///   <see langword="true" /> if the DACL is successfully modified; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> if the DACL is successfully modified; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001FFB RID: 8187 RVA: 0x00070589 File Offset: 0x0006E789
		protected override bool ModifyAccess(AccessControlModification modification, AccessRule rule, out bool modified)
		{
			if (!this.AccessRuleType.IsAssignableFrom(rule.GetType()))
			{
				throw new ArgumentException(Environment.GetResourceString("AccessControl_InvalidAccessRuleType"), "rule");
			}
			return this.ModifyAccess(modification, rule as ObjectAccessRule, out modified);
		}

		/// <summary>Applies the specified modification to the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object.</summary>
		/// <param name="modification">The modification to apply to the SACL.</param>
		/// <param name="rule">The audit rule to modify.</param>
		/// <param name="modified">
		///   <see langword="true" /> if the SACL is successfully modified; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> if the SACL is successfully modified; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001FFC RID: 8188 RVA: 0x000705C1 File Offset: 0x0006E7C1
		protected override bool ModifyAudit(AccessControlModification modification, AuditRule rule, out bool modified)
		{
			if (!this.AuditRuleType.IsAssignableFrom(rule.GetType()))
			{
				throw new ArgumentException(Environment.GetResourceString("AccessControl_InvalidAuditRuleType"), "rule");
			}
			return this.ModifyAudit(modification, rule as ObjectAuditRule, out modified);
		}

		/// <summary>Adds the specified access rule to the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object.</summary>
		/// <param name="rule">The access rule to add.</param>
		// Token: 0x06001FFD RID: 8189 RVA: 0x000705FC File Offset: 0x0006E7FC
		protected void AddAccessRule(ObjectAccessRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			base.WriteLock();
			try
			{
				bool flag;
				this.ModifyAccess(AccessControlModification.Add, rule, out flag);
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Removes all access rules that contain the same security identifier and qualifier as the specified access rule in the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object and then adds the specified access rule.</summary>
		/// <param name="rule">The access rule to set.</param>
		// Token: 0x06001FFE RID: 8190 RVA: 0x00070644 File Offset: 0x0006E844
		protected void SetAccessRule(ObjectAccessRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			base.WriteLock();
			try
			{
				bool flag;
				this.ModifyAccess(AccessControlModification.Set, rule, out flag);
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Removes all access rules in the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object and then adds the specified access rule.</summary>
		/// <param name="rule">The access rule to reset.</param>
		// Token: 0x06001FFF RID: 8191 RVA: 0x0007068C File Offset: 0x0006E88C
		protected void ResetAccessRule(ObjectAccessRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			base.WriteLock();
			try
			{
				bool flag;
				this.ModifyAccess(AccessControlModification.Reset, rule, out flag);
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Removes access rules that contain the same security identifier and access mask as the specified access rule from the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object.</summary>
		/// <param name="rule">The access rule to remove.</param>
		/// <returns>
		///   <see langword="true" /> if the access rule was successfully removed; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002000 RID: 8192 RVA: 0x000706D4 File Offset: 0x0006E8D4
		protected bool RemoveAccessRule(ObjectAccessRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			base.WriteLock();
			bool result;
			try
			{
				if (this._securityDescriptor == null)
				{
					result = true;
				}
				else
				{
					bool flag;
					result = this.ModifyAccess(AccessControlModification.Remove, rule, out flag);
				}
			}
			finally
			{
				base.WriteUnlock();
			}
			return result;
		}

		/// <summary>Removes all access rules that have the same security identifier as the specified access rule from the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object.</summary>
		/// <param name="rule">The access rule to remove.</param>
		// Token: 0x06002001 RID: 8193 RVA: 0x00070728 File Offset: 0x0006E928
		protected void RemoveAccessRuleAll(ObjectAccessRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			base.WriteLock();
			try
			{
				if (this._securityDescriptor != null)
				{
					bool flag;
					this.ModifyAccess(AccessControlModification.RemoveAll, rule, out flag);
				}
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Removes all access rules that exactly match the specified access rule from the Discretionary Access Control List (DACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object.</summary>
		/// <param name="rule">The access rule to remove.</param>
		// Token: 0x06002002 RID: 8194 RVA: 0x00070778 File Offset: 0x0006E978
		protected void RemoveAccessRuleSpecific(ObjectAccessRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			if (this._securityDescriptor == null)
			{
				return;
			}
			base.WriteLock();
			try
			{
				bool flag;
				this.ModifyAccess(AccessControlModification.RemoveSpecific, rule, out flag);
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Adds the specified audit rule to the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object.</summary>
		/// <param name="rule">The audit rule to add.</param>
		// Token: 0x06002003 RID: 8195 RVA: 0x000707C8 File Offset: 0x0006E9C8
		protected void AddAuditRule(ObjectAuditRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			base.WriteLock();
			try
			{
				bool flag;
				this.ModifyAudit(AccessControlModification.Add, rule, out flag);
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Removes all audit rules that contain the same security identifier and qualifier as the specified audit rule in the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object and then adds the specified audit rule.</summary>
		/// <param name="rule">The audit rule to set.</param>
		// Token: 0x06002004 RID: 8196 RVA: 0x00070810 File Offset: 0x0006EA10
		protected void SetAuditRule(ObjectAuditRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			base.WriteLock();
			try
			{
				bool flag;
				this.ModifyAudit(AccessControlModification.Set, rule, out flag);
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Removes audit rules that contain the same security identifier and access mask as the specified audit rule from the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.CommonObjectSecurity" /> object.</summary>
		/// <param name="rule">The audit rule to remove.</param>
		/// <returns>
		///   <see langword="true" /> if the audit rule was successfully removed; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002005 RID: 8197 RVA: 0x00070858 File Offset: 0x0006EA58
		protected bool RemoveAuditRule(ObjectAuditRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			base.WriteLock();
			bool result;
			try
			{
				bool flag;
				result = this.ModifyAudit(AccessControlModification.Remove, rule, out flag);
			}
			finally
			{
				base.WriteUnlock();
			}
			return result;
		}

		/// <summary>Removes all audit rules that have the same security identifier as the specified audit rule from the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object.</summary>
		/// <param name="rule">The audit rule to remove.</param>
		// Token: 0x06002006 RID: 8198 RVA: 0x000708A0 File Offset: 0x0006EAA0
		protected void RemoveAuditRuleAll(ObjectAuditRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			base.WriteLock();
			try
			{
				bool flag;
				this.ModifyAudit(AccessControlModification.RemoveAll, rule, out flag);
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Removes all audit rules that exactly match the specified audit rule from the System Access Control List (SACL) associated with this <see cref="T:System.Security.AccessControl.DirectoryObjectSecurity" /> object.</summary>
		/// <param name="rule">The audit rule to remove.</param>
		// Token: 0x06002007 RID: 8199 RVA: 0x000708E8 File Offset: 0x0006EAE8
		protected void RemoveAuditRuleSpecific(ObjectAuditRule rule)
		{
			if (rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			base.WriteLock();
			try
			{
				bool flag;
				this.ModifyAudit(AccessControlModification.RemoveSpecific, rule, out flag);
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Gets a collection of the access rules associated with the specified security identifier.</summary>
		/// <param name="includeExplicit">
		///   <see langword="true" /> to include access rules explicitly set for the object.</param>
		/// <param name="includeInherited">
		///   <see langword="true" /> to include inherited access rules.</param>
		/// <param name="targetType">The security identifier for which to retrieve access rules. This must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</param>
		/// <returns>The collection of access rules associated with the specified <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</returns>
		// Token: 0x06002008 RID: 8200 RVA: 0x00070930 File Offset: 0x0006EB30
		public AuthorizationRuleCollection GetAccessRules(bool includeExplicit, bool includeInherited, Type targetType)
		{
			return this.GetRules(true, includeExplicit, includeInherited, targetType);
		}

		/// <summary>Gets a collection of the audit rules associated with the specified security identifier.</summary>
		/// <param name="includeExplicit">
		///   <see langword="true" /> to include audit rules explicitly set for the object.</param>
		/// <param name="includeInherited">
		///   <see langword="true" /> to include inherited audit rules.</param>
		/// <param name="targetType">The security identifier for which to retrieve audit rules. This must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</param>
		/// <returns>The collection of audit rules associated with the specified <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</returns>
		// Token: 0x06002009 RID: 8201 RVA: 0x0007093C File Offset: 0x0006EB3C
		public AuthorizationRuleCollection GetAuditRules(bool includeExplicit, bool includeInherited, Type targetType)
		{
			return this.GetRules(false, includeExplicit, includeInherited, targetType);
		}
	}
}
