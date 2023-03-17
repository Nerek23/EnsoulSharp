using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies categories of functionality potentially harmful to the host if invoked by a method or class.</summary>
	// Token: 0x020002B7 RID: 695
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum HostProtectionResource
	{
		/// <summary>Exposes no host resources.</summary>
		// Token: 0x04000DD7 RID: 3543
		None = 0,
		/// <summary>Exposes synchronization.</summary>
		// Token: 0x04000DD8 RID: 3544
		Synchronization = 1,
		/// <summary>Exposes state that might be shared between threads.</summary>
		// Token: 0x04000DD9 RID: 3545
		SharedState = 2,
		/// <summary>Might create or destroy other processes.</summary>
		// Token: 0x04000DDA RID: 3546
		ExternalProcessMgmt = 4,
		/// <summary>Might exit the current process, terminating the server.</summary>
		// Token: 0x04000DDB RID: 3547
		SelfAffectingProcessMgmt = 8,
		/// <summary>Creates or manipulates threads other than its own, which might be harmful to the host.</summary>
		// Token: 0x04000DDC RID: 3548
		ExternalThreading = 16,
		/// <summary>Manipulates threads in a way that only affects user code.</summary>
		// Token: 0x04000DDD RID: 3549
		SelfAffectingThreading = 32,
		/// <summary>Exposes the security infrastructure.</summary>
		// Token: 0x04000DDE RID: 3550
		SecurityInfrastructure = 64,
		/// <summary>Exposes the user interface.</summary>
		// Token: 0x04000DDF RID: 3551
		UI = 128,
		/// <summary>Might cause a resource leak on termination, if not protected by a safe handle or some other means of ensuring the release of resources.</summary>
		// Token: 0x04000DE0 RID: 3552
		MayLeakOnAbort = 256,
		/// <summary>Exposes all host resources.</summary>
		// Token: 0x04000DE1 RID: 3553
		All = 511
	}
}
