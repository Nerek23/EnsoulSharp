using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	/// <summary>Represents a set of access rights allowed or denied for a user or group. This class cannot be inherited.</summary>
	// Token: 0x02000215 RID: 533
	public sealed class EventWaitHandleAccessRule : AccessRule
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.EventWaitHandleAccessRule" /> class, specifying the user or group the rule applies to, the access rights, and whether the specified access rights are allowed or denied.</summary>
		/// <param name="identity">The user or group the rule applies to. Must be of type <see cref="T:System.Security.Principal.SecurityIdentifier" /> or a type such as <see cref="T:System.Security.Principal.NTAccount" /> that can be converted to type <see cref="T:System.Security.Principal.SecurityIdentifier" />.</param>
		/// <param name="eventRights">A bitwise combination of <see cref="T:System.Security.AccessControl.EventWaitHandleRights" /> values specifying the rights allowed or denied.</param>
		/// <param name="type">One of the <see cref="T:System.Security.AccessControl.AccessControlType" /> values specifying whether the rights are allowed or denied.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="eventRights" /> specifies an invalid value.  
		/// -or-  
		/// <paramref name="type" /> specifies an invalid value.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="identity" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="eventRights" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="identity" /> is neither of type <see cref="T:System.Security.Principal.SecurityIdentifier" /> nor of a type such as <see cref="T:System.Security.Principal.NTAccount" /> that can be converted to type <see cref="T:System.Security.Principal.SecurityIdentifier" />.</exception>
		// Token: 0x06001F18 RID: 7960 RVA: 0x0006D2CC File Offset: 0x0006B4CC
		public EventWaitHandleAccessRule(IdentityReference identity, EventWaitHandleRights eventRights, AccessControlType type) : this(identity, (int)eventRights, false, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.EventWaitHandleAccessRule" /> class, specifying the name of the user or group the rule applies to, the access rights, and whether the specified access rights are allowed or denied.</summary>
		/// <param name="identity">The name of the user or group the rule applies to.</param>
		/// <param name="eventRights">A bitwise combination of <see cref="T:System.Security.AccessControl.EventWaitHandleRights" /> values specifying the rights allowed or denied.</param>
		/// <param name="type">One of the <see cref="T:System.Security.AccessControl.AccessControlType" /> values specifying whether the rights are allowed or denied.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="eventRights" /> specifies an invalid value.  
		/// -or-  
		/// <paramref name="type" /> specifies an invalid value.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="eventRights" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="identity" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="identity" /> is a zero-length string.  
		/// -or-  
		/// <paramref name="identity" /> is longer than 512 characters.</exception>
		// Token: 0x06001F19 RID: 7961 RVA: 0x0006D2DA File Offset: 0x0006B4DA
		public EventWaitHandleAccessRule(string identity, EventWaitHandleRights eventRights, AccessControlType type) : this(new NTAccount(identity), (int)eventRights, false, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		// Token: 0x06001F1A RID: 7962 RVA: 0x0006D2ED File Offset: 0x0006B4ED
		internal EventWaitHandleAccessRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, type)
		{
		}

		/// <summary>Gets the rights allowed or denied by the access rule.</summary>
		/// <returns>A bitwise combination of <see cref="T:System.Security.AccessControl.EventWaitHandleRights" /> values indicating the rights allowed or denied by the access rule.</returns>
		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06001F1B RID: 7963 RVA: 0x0006D2FE File Offset: 0x0006B4FE
		public EventWaitHandleRights EventWaitHandleRights
		{
			get
			{
				return (EventWaitHandleRights)base.AccessMask;
			}
		}
	}
}
