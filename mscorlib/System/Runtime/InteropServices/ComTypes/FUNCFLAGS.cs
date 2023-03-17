using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Identifies the constants that define the properties of a function.</summary>
	// Token: 0x02000A1F RID: 2591
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum FUNCFLAGS : short
	{
		/// <summary>The function should not be accessible from macro languages. This flag is intended for system-level functions or functions that type browsers should not display.</summary>
		// Token: 0x04002D2B RID: 11563
		[__DynamicallyInvokable]
		FUNCFLAG_FRESTRICTED = 1,
		/// <summary>The function returns an object that is a source of events.</summary>
		// Token: 0x04002D2C RID: 11564
		[__DynamicallyInvokable]
		FUNCFLAG_FSOURCE = 2,
		/// <summary>The function that supports data binding.</summary>
		// Token: 0x04002D2D RID: 11565
		[__DynamicallyInvokable]
		FUNCFLAG_FBINDABLE = 4,
		/// <summary>When set, any call to a method that sets the property results first in a call to <see langword="IPropertyNotifySink::OnRequestEdit" />. The implementation of <see langword="OnRequestEdit" /> determines if the call is allowed to set the property.</summary>
		// Token: 0x04002D2E RID: 11566
		[__DynamicallyInvokable]
		FUNCFLAG_FREQUESTEDIT = 8,
		/// <summary>The function that is displayed to the user as bindable. <see cref="F:System.Runtime.InteropServices.FUNCFLAGS.FUNCFLAG_FBINDABLE" /> must also be set.</summary>
		// Token: 0x04002D2F RID: 11567
		[__DynamicallyInvokable]
		FUNCFLAG_FDISPLAYBIND = 16,
		/// <summary>The function that best represents the object. Only one function in a type can have this attribute.</summary>
		// Token: 0x04002D30 RID: 11568
		[__DynamicallyInvokable]
		FUNCFLAG_FDEFAULTBIND = 32,
		/// <summary>The function should not be displayed to the user, although it exists and is bindable.</summary>
		// Token: 0x04002D31 RID: 11569
		[__DynamicallyInvokable]
		FUNCFLAG_FHIDDEN = 64,
		/// <summary>The function supports <see langword="GetLastError" />. If an error occurs during the function, the caller can call <see langword="GetLastError" /> to retrieve the error code.</summary>
		// Token: 0x04002D32 RID: 11570
		[__DynamicallyInvokable]
		FUNCFLAG_FUSESGETLASTERROR = 128,
		/// <summary>Permits an optimization in which the compiler looks for a member named "xyz" on the type of "abc". If such a member is found, and is flagged as an accessor function for an element of the default collection, a call is generated to that member function. Permitted on members in dispinterfaces and interfaces; not permitted on modules.</summary>
		// Token: 0x04002D33 RID: 11571
		[__DynamicallyInvokable]
		FUNCFLAG_FDEFAULTCOLLELEM = 256,
		/// <summary>The type information member is the default member for display in the user interface.</summary>
		// Token: 0x04002D34 RID: 11572
		[__DynamicallyInvokable]
		FUNCFLAG_FUIDEFAULT = 512,
		/// <summary>The property appears in an object browser, but not in a properties browser.</summary>
		// Token: 0x04002D35 RID: 11573
		[__DynamicallyInvokable]
		FUNCFLAG_FNONBROWSABLE = 1024,
		/// <summary>Tags the interface as having default behaviors.</summary>
		// Token: 0x04002D36 RID: 11574
		[__DynamicallyInvokable]
		FUNCFLAG_FREPLACEABLE = 2048,
		/// <summary>Mapped as individual bindable properties.</summary>
		// Token: 0x04002D37 RID: 11575
		[__DynamicallyInvokable]
		FUNCFLAG_FIMMEDIATEBIND = 4096
	}
}
