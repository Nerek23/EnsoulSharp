﻿using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies the permitted use of isolated storage.</summary>
	// Token: 0x020002BD RID: 701
	[ComVisible(true)]
	[Serializable]
	public enum IsolatedStorageContainment
	{
		/// <summary>Use of isolated storage is not allowed.</summary>
		// Token: 0x04000E09 RID: 3593
		None,
		/// <summary>Storage is isolated first by user and then by domain and assembly. Storage is also isolated by computer. Data can only be accessed within the context of the same application and only when run by the same user. This is helpful when a third-party assembly wants to keep a private data store.</summary>
		// Token: 0x04000E0A RID: 3594
		DomainIsolationByUser = 16,
		/// <summary>Storage is isolated first by user and then by application. Storage is also isolated by computer. This provides a data store for the application that is accessible in any domain context. The per-application data compartment requires additional trust because it potentially provides a "tunnel" between applications that could compromise the data isolation of applications in particular Web sites.</summary>
		// Token: 0x04000E0B RID: 3595
		ApplicationIsolationByUser = 21,
		/// <summary>Storage is isolated first by user and then by code assembly. Storage is also isolated by computer. This provides a data store for the assembly that is accessible in any domain context. The per-assembly data compartment requires additional trust because it potentially provides a "tunnel" between applications that could compromise the data isolation of applications in particular Web sites.</summary>
		// Token: 0x04000E0C RID: 3596
		AssemblyIsolationByUser = 32,
		/// <summary>Storage is isolated first by computer and then by domain and assembly. Data can only be accessed within the context of the same application and only when run on the same computer. This is helpful when a third-party assembly wants to keep a private data store.</summary>
		// Token: 0x04000E0D RID: 3597
		DomainIsolationByMachine = 48,
		/// <summary>Storage is isolated first by computer and then by code assembly. This provides a data store for the assembly that is accessible in any domain context. The per-assembly data compartment requires additional trust because it potentially provides a "tunnel" between applications that could compromise the data isolation of applications in particular Web sites.</summary>
		// Token: 0x04000E0E RID: 3598
		AssemblyIsolationByMachine = 64,
		/// <summary>Storage is isolated first by computer and then by application. This provides a data store for the application that is accessible in any domain context. The per-application data compartment requires additional trust because it potentially provides a "tunnel" between applications that could compromise the data isolation of applications in particular Web sites.</summary>
		// Token: 0x04000E0F RID: 3599
		ApplicationIsolationByMachine = 69,
		/// <summary>Storage is isolated first by user and then by domain and assembly. Storage will roam if Windows user data roaming is enabled. Data can only be accessed within the context of the same application and only when run by the same user. This is helpful when a third-party assembly wants to keep a private data store.</summary>
		// Token: 0x04000E10 RID: 3600
		DomainIsolationByRoamingUser = 80,
		/// <summary>Storage is isolated first by user and then by assembly evidence. Storage will roam if Windows user data roaming is enabled. This provides a data store for the assembly that is accessible in any domain context. The per-assembly data compartment requires additional trust because it potentially provides a "tunnel" between applications that could compromise the data isolation of applications in particular Web sites.</summary>
		// Token: 0x04000E11 RID: 3601
		AssemblyIsolationByRoamingUser = 96,
		/// <summary>Storage is isolated first by user and then by application evidence. Storage will roam if Windows user data roaming is enabled. This provides a data store for the application that is accessible in any domain context. The per-application data compartment requires additional trust because it potentially provides a "tunnel" between applications that could compromise the data isolation of applications in particular Web sites.</summary>
		// Token: 0x04000E12 RID: 3602
		ApplicationIsolationByRoamingUser = 101,
		/// <summary>Unlimited administration ability for the user store. Allows browsing and deletion of the entire user store, but not read access other than the user's own domain/assembly identity.</summary>
		// Token: 0x04000E13 RID: 3603
		AdministerIsolatedStorageByUser = 112,
		/// <summary>Use of isolated storage is allowed without restriction. Code has full access to any part of the user store, regardless of the identity of the domain or assembly. This use of isolated storage includes the ability to enumerate the contents of the isolated storage data store.</summary>
		// Token: 0x04000E14 RID: 3604
		UnrestrictedIsolatedStorage = 240
	}
}
