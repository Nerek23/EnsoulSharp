using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	/// <summary>Represents a System Access Control List (SACL).</summary>
	// Token: 0x0200020E RID: 526
	public sealed class SystemAcl : CommonAcl
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.SystemAcl" /> class with the specified values.</summary>
		/// <param name="isContainer">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.SystemAcl" /> object is a container.</param>
		/// <param name="isDS">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.SystemAcl" /> object is a directory object Access Control List (ACL).</param>
		/// <param name="capacity">The number of Access Control Entries (ACEs) this <see cref="T:System.Security.AccessControl.SystemAcl" /> object can contain. This number is to be used only as a hint.</param>
		// Token: 0x06001ED4 RID: 7892 RVA: 0x0006C988 File Offset: 0x0006AB88
		public SystemAcl(bool isContainer, bool isDS, int capacity) : this(isContainer, isDS, isDS ? GenericAcl.AclRevisionDS : GenericAcl.AclRevision, capacity)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.SystemAcl" /> class with the specified values.</summary>
		/// <param name="isContainer">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.SystemAcl" /> object is a container.</param>
		/// <param name="isDS">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.SystemAcl" /> object is a directory object Access Control List (ACL).</param>
		/// <param name="revision">The revision level of the new <see cref="T:System.Security.AccessControl.SystemAcl" /> object.</param>
		/// <param name="capacity">The number of Access Control Entries (ACEs) this <see cref="T:System.Security.AccessControl.SystemAcl" /> object can contain. This number is to be used only as a hint.</param>
		// Token: 0x06001ED5 RID: 7893 RVA: 0x0006C9A2 File Offset: 0x0006ABA2
		public SystemAcl(bool isContainer, bool isDS, byte revision, int capacity) : base(isContainer, isDS, revision, capacity)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.SystemAcl" /> class with the specified values from the specified <see cref="T:System.Security.AccessControl.RawAcl" /> object.</summary>
		/// <param name="isContainer">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.SystemAcl" /> object is a container.</param>
		/// <param name="isDS">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.SystemAcl" /> object is a directory object Access Control List (ACL).</param>
		/// <param name="rawAcl">The underlying <see cref="T:System.Security.AccessControl.RawAcl" /> object for the new <see cref="T:System.Security.AccessControl.SystemAcl" /> object. Specify <see langword="null" /> to create an empty ACL.</param>
		// Token: 0x06001ED6 RID: 7894 RVA: 0x0006C9AF File Offset: 0x0006ABAF
		public SystemAcl(bool isContainer, bool isDS, RawAcl rawAcl) : this(isContainer, isDS, rawAcl, false)
		{
		}

		// Token: 0x06001ED7 RID: 7895 RVA: 0x0006C9BB File Offset: 0x0006ABBB
		internal SystemAcl(bool isContainer, bool isDS, RawAcl rawAcl, bool trusted) : base(isContainer, isDS, rawAcl, trusted, false)
		{
		}

		/// <summary>Adds an audit rule to the current <see cref="T:System.Security.AccessControl.SystemAcl" /> object.</summary>
		/// <param name="auditFlags">The type of audit rule to add.</param>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to add an audit rule.</param>
		/// <param name="accessMask">The access mask for the new audit rule.</param>
		/// <param name="inheritanceFlags">Flags that specify the inheritance properties of the new audit rule.</param>
		/// <param name="propagationFlags">Flags that specify the inheritance propagation properties for the new audit rule.</param>
		// Token: 0x06001ED8 RID: 7896 RVA: 0x0006C9C9 File Offset: 0x0006ABC9
		public void AddAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags)
		{
			base.CheckFlags(inheritanceFlags, propagationFlags);
			base.AddQualifiedAce(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), ObjectAceFlags.None, Guid.Empty, Guid.Empty);
		}

		/// <summary>Sets the specified audit rule for the specified <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</summary>
		/// <param name="auditFlags">The audit condition to set.</param>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to set an audit rule.</param>
		/// <param name="accessMask">The access mask for the new audit rule.</param>
		/// <param name="inheritanceFlags">Flags that specify the inheritance properties of the new audit rule.</param>
		/// <param name="propagationFlags">Flags that specify the inheritance propagation properties for the new audit rule.</param>
		// Token: 0x06001ED9 RID: 7897 RVA: 0x0006C9F9 File Offset: 0x0006ABF9
		public void SetAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags)
		{
			base.CheckFlags(inheritanceFlags, propagationFlags);
			base.SetQualifiedAce(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), ObjectAceFlags.None, Guid.Empty, Guid.Empty);
		}

		/// <summary>Removes the specified audit rule from the current <see cref="T:System.Security.AccessControl.SystemAcl" /> object.</summary>
		/// <param name="auditFlags">The type of audit rule to remove.</param>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to remove an audit rule.</param>
		/// <param name="accessMask">The access mask for the rule to be removed.</param>
		/// <param name="inheritanceFlags">Flags that specify the inheritance properties of the rule to be removed.</param>
		/// <param name="propagationFlags">Flags that specify the inheritance propagation properties for the rule to be removed.</param>
		/// <returns>
		///   <see langword="true" /> if this method successfully removes the specified audit rule; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001EDA RID: 7898 RVA: 0x0006CA2C File Offset: 0x0006AC2C
		public bool RemoveAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags)
		{
			return base.RemoveQualifiedAces(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), true, ObjectAceFlags.None, Guid.Empty, Guid.Empty);
		}

		/// <summary>Removes the specified audit rule from the current <see cref="T:System.Security.AccessControl.DiscretionaryAcl" /> object.</summary>
		/// <param name="auditFlags">The type of audit rule to remove.</param>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to remove an audit rule.</param>
		/// <param name="accessMask">The access mask for the rule to be removed.</param>
		/// <param name="inheritanceFlags">Flags that specify the inheritance properties of the rule to be removed.</param>
		/// <param name="propagationFlags">Flags that specify the inheritance propagation properties for the rule to be removed.</param>
		// Token: 0x06001EDB RID: 7899 RVA: 0x0006CA5E File Offset: 0x0006AC5E
		public void RemoveAuditSpecific(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags)
		{
			base.RemoveQualifiedAcesSpecific(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), ObjectAceFlags.None, Guid.Empty, Guid.Empty);
		}

		/// <summary>Adds an audit rule to the current <see cref="T:System.Security.AccessControl.SystemAcl" /> object.</summary>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to add an audit rule.</param>
		/// <param name="rule">The <see cref="T:System.Security.AccessControl.ObjectAuditRule" /> for the new audit rule.</param>
		// Token: 0x06001EDC RID: 7900 RVA: 0x0006CA84 File Offset: 0x0006AC84
		public void AddAudit(SecurityIdentifier sid, ObjectAuditRule rule)
		{
			this.AddAudit(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
		}

		/// <summary>Adds an audit rule with the specified settings to the current <see cref="T:System.Security.AccessControl.SystemAcl" /> object. Use this method for directory object Access Control Lists (ACLs) when specifying the object type or the inherited object type for the new audit rule.</summary>
		/// <param name="auditFlags">The type of audit rule to add.</param>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to add an audit rule.</param>
		/// <param name="accessMask">The access mask for the new audit rule.</param>
		/// <param name="inheritanceFlags">Flags that specify the inheritance properties of the new audit rule.</param>
		/// <param name="propagationFlags">Flags that specify the inheritance propagation properties for the new audit rule.</param>
		/// <param name="objectFlags">Flags that specify if the <paramref name="objectType" /> and <paramref name="inheritedObjectType" /> parameters contain non-<see langword="null" /> values.</param>
		/// <param name="objectType">The identity of the class of objects to which the new audit rule applies.</param>
		/// <param name="inheritedObjectType">The identity of the class of child objects which can inherit the new audit rule.</param>
		// Token: 0x06001EDD RID: 7901 RVA: 0x0006CAC4 File Offset: 0x0006ACC4
		public void AddAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, ObjectAceFlags objectFlags, Guid objectType, Guid inheritedObjectType)
		{
			if (!base.IsDS)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_OnlyValidForDS"));
			}
			base.CheckFlags(inheritanceFlags, propagationFlags);
			base.AddQualifiedAce(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), objectFlags, objectType, inheritedObjectType);
		}

		/// <summary>Sets the specified audit rule for the specified <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</summary>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to set an audit rule.</param>
		/// <param name="rule">The <see cref="T:System.Security.AccessControl.ObjectAuditRule" /> for which to set an audit rule.</param>
		// Token: 0x06001EDE RID: 7902 RVA: 0x0006CB14 File Offset: 0x0006AD14
		public void SetAudit(SecurityIdentifier sid, ObjectAuditRule rule)
		{
			this.SetAudit(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
		}

		/// <summary>Sets the specified audit rule for the specified <see cref="T:System.Security.Principal.SecurityIdentifier" /> object. Use this method for directory object Access Control Lists (ACLs) when specifying the object type or the inherited object type.</summary>
		/// <param name="auditFlags">The audit condition to set.</param>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to set an audit rule.</param>
		/// <param name="accessMask">The access mask for the new audit rule.</param>
		/// <param name="inheritanceFlags">Flags that specify the inheritance properties of the new audit rule.</param>
		/// <param name="propagationFlags">Flags that specify the inheritance propagation properties for the new audit rule.</param>
		/// <param name="objectFlags">Flags that specify if the <paramref name="objectType" /> and <paramref name="inheritedObjectType" /> parameters contain non-<see langword="null" /> values.</param>
		/// <param name="objectType">The identity of the class of objects to which the new audit rule applies.</param>
		/// <param name="inheritedObjectType">The identity of the class of child objects which can inherit the new audit rule.</param>
		// Token: 0x06001EDF RID: 7903 RVA: 0x0006CB54 File Offset: 0x0006AD54
		public void SetAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, ObjectAceFlags objectFlags, Guid objectType, Guid inheritedObjectType)
		{
			if (!base.IsDS)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_OnlyValidForDS"));
			}
			base.CheckFlags(inheritanceFlags, propagationFlags);
			base.SetQualifiedAce(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), objectFlags, objectType, inheritedObjectType);
		}

		/// <summary>Removes the specified audit rule from the current <see cref="T:System.Security.AccessControl.SystemAcl" /> object.</summary>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to remove an audit rule.</param>
		/// <param name="rule">The <see cref="T:System.Security.AccessControl.ObjectAuditRule" /> for which to remove an audit rule.</param>
		/// <returns>
		///   <see langword="true" /> if this method successfully removes the specified audit rule; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001EE0 RID: 7904 RVA: 0x0006CBA4 File Offset: 0x0006ADA4
		public bool RemoveAudit(SecurityIdentifier sid, ObjectAuditRule rule)
		{
			return this.RemoveAudit(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
		}

		/// <summary>Removes the specified audit rule from the current <see cref="T:System.Security.AccessControl.SystemAcl" /> object. Use this method for directory object Access Control Lists (ACLs) when specifying the object type or the inherited object type.</summary>
		/// <param name="auditFlags">The type of audit rule to remove.</param>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to remove an audit rule.</param>
		/// <param name="accessMask">The access mask for the rule to be removed.</param>
		/// <param name="inheritanceFlags">Flags that specify the inheritance properties of the rule to be removed.</param>
		/// <param name="propagationFlags">Flags that specify the inheritance propagation properties for the rule to be removed.</param>
		/// <param name="objectFlags">Flags that specify if the <paramref name="objectType" /> and <paramref name="inheritedObjectType" /> parameters contain non-<see langword="null" /> values.</param>
		/// <param name="objectType">The identity of the class of objects to which the removed audit control rule applies.</param>
		/// <param name="inheritedObjectType">The identity of the class of child objects which can inherit the removed audit rule.</param>
		/// <returns>
		///   <see langword="true" /> if this method successfully removes the specified audit rule; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001EE1 RID: 7905 RVA: 0x0006CBE4 File Offset: 0x0006ADE4
		public bool RemoveAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, ObjectAceFlags objectFlags, Guid objectType, Guid inheritedObjectType)
		{
			if (!base.IsDS)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_OnlyValidForDS"));
			}
			return base.RemoveQualifiedAces(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), true, objectFlags, objectType, inheritedObjectType);
		}

		/// <summary>Removes the specified audit rule from the current <see cref="T:System.Security.AccessControl.DiscretionaryAcl" /> object.</summary>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to remove an audit rule.</param>
		/// <param name="rule">The <see cref="T:System.Security.AccessControl.ObjectAuditRule" /> for the rule to be removed.</param>
		// Token: 0x06001EE2 RID: 7906 RVA: 0x0006CC2C File Offset: 0x0006AE2C
		public void RemoveAuditSpecific(SecurityIdentifier sid, ObjectAuditRule rule)
		{
			this.RemoveAuditSpecific(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
		}

		/// <summary>Removes the specified audit rule from the current <see cref="T:System.Security.AccessControl.DiscretionaryAcl" /> object. Use this method for directory object Access Control Lists (ACLs) when specifying the object type or the inherited object type.</summary>
		/// <param name="auditFlags">The type of audit rule to remove.</param>
		/// <param name="sid">The <see cref="T:System.Security.Principal.SecurityIdentifier" /> for which to remove an audit rule.</param>
		/// <param name="accessMask">The access mask for the rule to be removed.</param>
		/// <param name="inheritanceFlags">Flags that specify the inheritance properties of the rule to be removed.</param>
		/// <param name="propagationFlags">Flags that specify the inheritance propagation properties for the rule to be removed.</param>
		/// <param name="objectFlags">Flags that specify if the <paramref name="objectType" /> and <paramref name="inheritedObjectType" /> parameters contain non-<see langword="null" /> values.</param>
		/// <param name="objectType">The identity of the class of objects to which the removed audit control rule applies.</param>
		/// <param name="inheritedObjectType">The identity of the class of child objects which can inherit the removed audit rule.</param>
		// Token: 0x06001EE3 RID: 7907 RVA: 0x0006CC6A File Offset: 0x0006AE6A
		public void RemoveAuditSpecific(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, ObjectAceFlags objectFlags, Guid objectType, Guid inheritedObjectType)
		{
			if (!base.IsDS)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_OnlyValidForDS"));
			}
			base.RemoveQualifiedAcesSpecific(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), objectFlags, objectType, inheritedObjectType);
		}
	}
}
