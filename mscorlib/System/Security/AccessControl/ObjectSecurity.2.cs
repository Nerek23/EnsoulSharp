using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	/// <summary>Provides the ability to control access to objects without direct manipulation of Access Control Lists (ACLs); also grants the ability to type-cast access rights.</summary>
	/// <typeparam name="T">The access rights for the object.</typeparam>
	// Token: 0x02000227 RID: 551
	public abstract class ObjectSecurity<T> : NativeObjectSecurity where T : struct
	{
		/// <summary>Initializes a new instance of the ObjectSecurity`1 class.</summary>
		/// <param name="isContainer">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.ObjectSecurity`1" /> object is a container object.</param>
		/// <param name="resourceType">The type of resource.</param>
		// Token: 0x06001FC9 RID: 8137 RVA: 0x0006EDB2 File Offset: 0x0006CFB2
		protected ObjectSecurity(bool isContainer, ResourceType resourceType) : base(isContainer, resourceType, null, null)
		{
		}

		/// <summary>Initializes a new instance of the ObjectSecurity`1 class.</summary>
		/// <param name="isContainer">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.ObjectSecurity`1" /> object is a container object.</param>
		/// <param name="resourceType">The type of resource.</param>
		/// <param name="name">The name of the securable object with which the new <see cref="T:System.Security.AccessControl.ObjectSecurity`1" /> object is associated.</param>
		/// <param name="includeSections">The sections to include.</param>
		// Token: 0x06001FCA RID: 8138 RVA: 0x0006EDBE File Offset: 0x0006CFBE
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, string name, AccessControlSections includeSections) : base(isContainer, resourceType, name, includeSections, null, null)
		{
		}

		/// <summary>Initializes a new instance of the ObjectSecurity`1 class.</summary>
		/// <param name="isContainer">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.ObjectSecurity`1" /> object is a container object.</param>
		/// <param name="resourceType">The type of resource.</param>
		/// <param name="name">The name of the securable object with which the new <see cref="T:System.Security.AccessControl.ObjectSecurity`1" /> object is associated.</param>
		/// <param name="includeSections">The sections to include.</param>
		/// <param name="exceptionFromErrorCode">A delegate implemented by integrators that provides custom exceptions.</param>
		/// <param name="exceptionContext">An object that contains contextual information about the source or destination of the exception.</param>
		// Token: 0x06001FCB RID: 8139 RVA: 0x0006EDCD File Offset: 0x0006CFCD
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, string name, AccessControlSections includeSections, NativeObjectSecurity.ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext) : base(isContainer, resourceType, name, includeSections, exceptionFromErrorCode, exceptionContext)
		{
		}

		/// <summary>Initializes a new instance of the ObjectSecurity`1 class.</summary>
		/// <param name="isContainer">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.ObjectSecurity`1" /> object is a container object.</param>
		/// <param name="resourceType">The type of resource.</param>
		/// <param name="safeHandle">A handle.</param>
		/// <param name="includeSections">The sections to include.</param>
		// Token: 0x06001FCC RID: 8140 RVA: 0x0006EDDE File Offset: 0x0006CFDE
		[SecuritySafeCritical]
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, SafeHandle safeHandle, AccessControlSections includeSections) : base(isContainer, resourceType, safeHandle, includeSections, null, null)
		{
		}

		/// <summary>Initializes a new instance of the ObjectSecurity`1 class.</summary>
		/// <param name="isContainer">
		///   <see langword="true" /> if the new <see cref="T:System.Security.AccessControl.ObjectSecurity`1" /> object is a container object.</param>
		/// <param name="resourceType">The type of resource.</param>
		/// <param name="safeHandle">A handle.</param>
		/// <param name="includeSections">The sections to include.</param>
		/// <param name="exceptionFromErrorCode">A delegate implemented by integrators that provides custom exceptions.</param>
		/// <param name="exceptionContext">An object that contains contextual information about the source or destination of the exception.</param>
		// Token: 0x06001FCD RID: 8141 RVA: 0x0006EDED File Offset: 0x0006CFED
		[SecuritySafeCritical]
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, SafeHandle safeHandle, AccessControlSections includeSections, NativeObjectSecurity.ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext) : base(isContainer, resourceType, safeHandle, includeSections, exceptionFromErrorCode, exceptionContext)
		{
		}

		/// <summary>Initializes a new instance of the ObjectAccessRule class that represents a new access control rule for the associated security object.</summary>
		/// <param name="identityReference">Represents a user account.</param>
		/// <param name="accessMask">The access type.</param>
		/// <param name="isInherited">
		///   <see langword="true" /> if the access rule is inherited; otherwise, <see langword="false" />.</param>
		/// <param name="inheritanceFlags">Specifies how to propagate access masks to child objects.</param>
		/// <param name="propagationFlags">Specifies how to propagate Access Control Entries (ACEs) to child objects.</param>
		/// <param name="type">Specifies whether access is allowed or denied.</param>
		/// <returns>Represents a new access control rule for the specified user, with the specified access rights, access control, and flags.</returns>
		// Token: 0x06001FCE RID: 8142 RVA: 0x0006EDFE File Offset: 0x0006CFFE
		public override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
		{
			return new AccessRule<T>(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, type);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.AuditRule" /> class representing the specified audit rule for the specified user.</summary>
		/// <param name="identityReference">Represents a user account.</param>
		/// <param name="accessMask">An integer that specifies an access type.</param>
		/// <param name="isInherited">
		///   <see langword="true" /> if the access rule is inherited; otherwise, <see langword="false" />.</param>
		/// <param name="inheritanceFlags">Specifies how to propagate access masks to child objects.</param>
		/// <param name="propagationFlags">Specifies how to propagate Access Control Entries (ACEs) to child objects.</param>
		/// <param name="flags">Describes the type of auditing to perform.</param>
		/// <returns>The specified audit rule for the specified user.</returns>
		// Token: 0x06001FCF RID: 8143 RVA: 0x0006EE0E File Offset: 0x0006D00E
		public override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
		{
			return new AuditRule<T>(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, flags);
		}

		// Token: 0x06001FD0 RID: 8144 RVA: 0x0006EE20 File Offset: 0x0006D020
		private AccessControlSections GetAccessControlSectionsFromChanges()
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

		/// <summary>Saves the security descriptor associated with this ObjectSecurity`1 object to permanent storage, using the specified handle.</summary>
		/// <param name="handle">The handle of the securable object with which this ObjectSecurity`1 object is associated.</param>
		// Token: 0x06001FD1 RID: 8145 RVA: 0x0006EE60 File Offset: 0x0006D060
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		protected internal void Persist(SafeHandle handle)
		{
			base.WriteLock();
			try
			{
				AccessControlSections accessControlSectionsFromChanges = this.GetAccessControlSectionsFromChanges();
				base.Persist(handle, accessControlSectionsFromChanges);
				base.OwnerModified = (base.GroupModified = (base.AuditRulesModified = (base.AccessRulesModified = false)));
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Saves the security descriptor associated with this ObjectSecurity`1 object to permanent storage, using the specified name.</summary>
		/// <param name="name">The name of the securable object with which this ObjectSecurity`1 object is associated.</param>
		// Token: 0x06001FD2 RID: 8146 RVA: 0x0006EEC0 File Offset: 0x0006D0C0
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		protected internal void Persist(string name)
		{
			base.WriteLock();
			try
			{
				AccessControlSections accessControlSectionsFromChanges = this.GetAccessControlSectionsFromChanges();
				base.Persist(name, accessControlSectionsFromChanges);
				base.OwnerModified = (base.GroupModified = (base.AuditRulesModified = (base.AccessRulesModified = false)));
			}
			finally
			{
				base.WriteUnlock();
			}
		}

		/// <summary>Adds the specified access rule to the Discretionary Access Control List (DACL) associated with this ObjectSecurity`1 object.</summary>
		/// <param name="rule">The rule to add.</param>
		// Token: 0x06001FD3 RID: 8147 RVA: 0x0006EF20 File Offset: 0x0006D120
		public virtual void AddAccessRule(AccessRule<T> rule)
		{
			base.AddAccessRule(rule);
		}

		/// <summary>Removes all access rules that contain the same security identifier and qualifier as the specified access rule in the Discretionary Access Control List (DACL) associated with this ObjectSecurity`1 object and then adds the specified access rule.</summary>
		/// <param name="rule">The access rule to set.</param>
		// Token: 0x06001FD4 RID: 8148 RVA: 0x0006EF29 File Offset: 0x0006D129
		public virtual void SetAccessRule(AccessRule<T> rule)
		{
			base.SetAccessRule(rule);
		}

		/// <summary>Removes all access rules in the Discretionary Access Control List (DACL) associated with this ObjectSecurity`1 object and then adds the specified access rule.</summary>
		/// <param name="rule">The access rule to reset.</param>
		// Token: 0x06001FD5 RID: 8149 RVA: 0x0006EF32 File Offset: 0x0006D132
		public virtual void ResetAccessRule(AccessRule<T> rule)
		{
			base.ResetAccessRule(rule);
		}

		/// <summary>Removes access rules that contain the same security identifier and access mask as the specified access rule from the Discretionary Access Control List (DACL) associated with this ObjectSecurity`1 object.</summary>
		/// <param name="rule">The rule to remove.</param>
		/// <returns>
		///   <see langword="true" /> if the access rule was successfully removed; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001FD6 RID: 8150 RVA: 0x0006EF3B File Offset: 0x0006D13B
		public virtual bool RemoveAccessRule(AccessRule<T> rule)
		{
			return base.RemoveAccessRule(rule);
		}

		/// <summary>Removes all access rules that have the same security identifier as the specified access rule from the Discretionary Access Control List (DACL) associated with this ObjectSecurity`1 object.</summary>
		/// <param name="rule">The access rule to remove.</param>
		// Token: 0x06001FD7 RID: 8151 RVA: 0x0006EF44 File Offset: 0x0006D144
		public virtual void RemoveAccessRuleAll(AccessRule<T> rule)
		{
			base.RemoveAccessRuleAll(rule);
		}

		/// <summary>Removes all access rules that exactly match the specified access rule from the Discretionary Access Control List (DACL) associated with this ObjectSecurity`1 object</summary>
		/// <param name="rule">The access rule to remove.</param>
		// Token: 0x06001FD8 RID: 8152 RVA: 0x0006EF4D File Offset: 0x0006D14D
		public virtual void RemoveAccessRuleSpecific(AccessRule<T> rule)
		{
			base.RemoveAccessRuleSpecific(rule);
		}

		/// <summary>Adds the specified audit rule to the System Access Control List (SACL) associated with this ObjectSecurity`1 object.</summary>
		/// <param name="rule">The audit rule to add.</param>
		// Token: 0x06001FD9 RID: 8153 RVA: 0x0006EF56 File Offset: 0x0006D156
		public virtual void AddAuditRule(AuditRule<T> rule)
		{
			base.AddAuditRule(rule);
		}

		/// <summary>Removes all audit rules that contain the same security identifier and qualifier as the specified audit rule in the System Access Control List (SACL) associated with this ObjectSecurity`1 object and then adds the specified audit rule.</summary>
		/// <param name="rule">The audit rule to set.</param>
		// Token: 0x06001FDA RID: 8154 RVA: 0x0006EF5F File Offset: 0x0006D15F
		public virtual void SetAuditRule(AuditRule<T> rule)
		{
			base.SetAuditRule(rule);
		}

		/// <summary>Removes audit rules that contain the same security identifier and access mask as the specified audit rule from the System Access Control List (SACL) associated with this ObjectSecurity`1 object.</summary>
		/// <param name="rule">The audit rule to remove</param>
		/// <returns>
		///   <see langword="true" /> if the object was removed; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001FDB RID: 8155 RVA: 0x0006EF68 File Offset: 0x0006D168
		public virtual bool RemoveAuditRule(AuditRule<T> rule)
		{
			return base.RemoveAuditRule(rule);
		}

		/// <summary>Removes all audit rules that have the same security identifier as the specified audit rule from the System Access Control List (SACL) associated with this ObjectSecurity`1 object.</summary>
		/// <param name="rule">The audit rule to remove.</param>
		// Token: 0x06001FDC RID: 8156 RVA: 0x0006EF71 File Offset: 0x0006D171
		public virtual void RemoveAuditRuleAll(AuditRule<T> rule)
		{
			base.RemoveAuditRuleAll(rule);
		}

		/// <summary>Removes all audit rules that exactly match the specified audit rule from the System Access Control List (SACL) associated with this ObjectSecurity`1 object</summary>
		/// <param name="rule">The audit rule to remove.</param>
		// Token: 0x06001FDD RID: 8157 RVA: 0x0006EF7A File Offset: 0x0006D17A
		public virtual void RemoveAuditRuleSpecific(AuditRule<T> rule)
		{
			base.RemoveAuditRuleSpecific(rule);
		}

		/// <summary>Gets the Type of the securable object associated with this ObjectSecurity`1 object.</summary>
		/// <returns>The type of the securable object associated with the current instance.</returns>
		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06001FDE RID: 8158 RVA: 0x0006EF83 File Offset: 0x0006D183
		public override Type AccessRightType
		{
			get
			{
				return typeof(T);
			}
		}

		/// <summary>Gets the Type of the object associated with the access rules of this ObjectSecurity`1 object.</summary>
		/// <returns>The Type of the object associated with the access rules of the current instance.</returns>
		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06001FDF RID: 8159 RVA: 0x0006EF8F File Offset: 0x0006D18F
		public override Type AccessRuleType
		{
			get
			{
				return typeof(AccessRule<T>);
			}
		}

		/// <summary>Gets the Type object associated with the audit rules of this ObjectSecurity`1 object.</summary>
		/// <returns>The Type object associated with the audit rules of the current instance.</returns>
		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06001FE0 RID: 8160 RVA: 0x0006EF9B File Offset: 0x0006D19B
		public override Type AuditRuleType
		{
			get
			{
				return typeof(AuditRule<T>);
			}
		}
	}
}
