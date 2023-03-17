using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies access flags for the security permission object.</summary>
	// Token: 0x020002D9 RID: 729
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum SecurityPermissionFlag
	{
		/// <summary>No security access.</summary>
		// Token: 0x04000E69 RID: 3689
		NoFlags = 0,
		/// <summary>Ability to assert that all this code's callers have the requisite permission for the operation.</summary>
		// Token: 0x04000E6A RID: 3690
		Assertion = 1,
		/// <summary>Ability to call unmanaged code.</summary>
		// Token: 0x04000E6B RID: 3691
		UnmanagedCode = 2,
		/// <summary>Ability to skip verification of code in this assembly. Code that is unverifiable can be run if this permission is granted.</summary>
		// Token: 0x04000E6C RID: 3692
		SkipVerification = 4,
		/// <summary>Permission for the code to run. Without this permission, managed code will not be executed.</summary>
		// Token: 0x04000E6D RID: 3693
		Execution = 8,
		/// <summary>Ability to use certain advanced operations on threads.</summary>
		// Token: 0x04000E6E RID: 3694
		ControlThread = 16,
		/// <summary>Ability to provide evidence, including the ability to alter the evidence provided by the common language runtime.</summary>
		// Token: 0x04000E6F RID: 3695
		ControlEvidence = 32,
		/// <summary>Ability to view and modify policy.</summary>
		// Token: 0x04000E70 RID: 3696
		ControlPolicy = 64,
		/// <summary>Ability to provide serialization services. Used by serialization formatters.</summary>
		// Token: 0x04000E71 RID: 3697
		SerializationFormatter = 128,
		/// <summary>Ability to specify domain policy.</summary>
		// Token: 0x04000E72 RID: 3698
		ControlDomainPolicy = 256,
		/// <summary>Ability to manipulate the principal object.</summary>
		// Token: 0x04000E73 RID: 3699
		ControlPrincipal = 512,
		/// <summary>Ability to create and manipulate an <see cref="T:System.AppDomain" />.</summary>
		// Token: 0x04000E74 RID: 3700
		ControlAppDomain = 1024,
		/// <summary>Permission to configure Remoting types and channels.</summary>
		// Token: 0x04000E75 RID: 3701
		RemotingConfiguration = 2048,
		/// <summary>Permission to plug code into the common language runtime infrastructure, such as adding Remoting Context Sinks, Envoy Sinks and Dynamic Sinks.</summary>
		// Token: 0x04000E76 RID: 3702
		Infrastructure = 4096,
		/// <summary>Permission to perform explicit binding redirection in the application configuration file. This includes redirection of .NET Framework assemblies that have been unified as well as other assemblies found outside the .NET Framework.</summary>
		// Token: 0x04000E77 RID: 3703
		BindingRedirects = 8192,
		/// <summary>The unrestricted state of the permission.</summary>
		// Token: 0x04000E78 RID: 3704
		AllFlags = 16383
	}
}
