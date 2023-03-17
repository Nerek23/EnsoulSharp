using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies the security actions that can be performed using declarative security.</summary>
	// Token: 0x020002C1 RID: 705
	[ComVisible(true)]
	[Serializable]
	public enum SecurityAction
	{
		/// <summary>All callers higher in the call stack are required to have been granted the permission specified by the current permission object.</summary>
		// Token: 0x04000E22 RID: 3618
		Demand = 2,
		/// <summary>The calling code can access the resource identified by the current permission object, even if callers higher in the stack have not been granted permission to access the resource (see Using the Assert Method).</summary>
		// Token: 0x04000E23 RID: 3619
		Assert,
		/// <summary>The ability to access the resource specified by the current permission object is denied to callers, even if they have been granted permission to access it (see Using the Deny Method).</summary>
		// Token: 0x04000E24 RID: 3620
		[Obsolete("Deny is obsolete and will be removed in a future release of the .NET Framework. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		Deny,
		/// <summary>Only the resources specified by this permission object can be accessed, even if the code has been granted permission to access other resources.</summary>
		// Token: 0x04000E25 RID: 3621
		PermitOnly,
		/// <summary>The immediate caller is required to have been granted the specified permission. Do not use in the .NET Framework 4. For full trust, use <see cref="T:System.Security.SecurityCriticalAttribute" /> instead; for partial trust, use <see cref="F:System.Security.Permissions.SecurityAction.Demand" />.</summary>
		// Token: 0x04000E26 RID: 3622
		LinkDemand,
		/// <summary>The derived class inheriting the class or overriding a method is required to have been granted the specified permission.</summary>
		// Token: 0x04000E27 RID: 3623
		InheritanceDemand,
		/// <summary>The request for the minimum permissions required for code to run. This action can only be used within the scope of the assembly.</summary>
		// Token: 0x04000E28 RID: 3624
		[Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		RequestMinimum,
		/// <summary>The request for additional permissions that are optional (not required to run). This request implicitly refuses all other permissions not specifically requested. This action can only be used within the scope of the assembly.</summary>
		// Token: 0x04000E29 RID: 3625
		[Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		RequestOptional,
		/// <summary>The request that permissions that might be misused will not be granted to the calling code. This action can only be used within the scope of the assembly.</summary>
		// Token: 0x04000E2A RID: 3626
		[Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		RequestRefuse
	}
}
