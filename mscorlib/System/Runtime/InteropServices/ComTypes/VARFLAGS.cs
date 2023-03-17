using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Identifies the constants that define the properties of a variable.</summary>
	// Token: 0x02000A20 RID: 2592
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum VARFLAGS : short
	{
		/// <summary>Assignment to the variable should not be allowed.</summary>
		// Token: 0x04002D39 RID: 11577
		[__DynamicallyInvokable]
		VARFLAG_FREADONLY = 1,
		/// <summary>The variable returns an object that is a source of events.</summary>
		// Token: 0x04002D3A RID: 11578
		[__DynamicallyInvokable]
		VARFLAG_FSOURCE = 2,
		/// <summary>The variable supports data binding.</summary>
		// Token: 0x04002D3B RID: 11579
		[__DynamicallyInvokable]
		VARFLAG_FBINDABLE = 4,
		/// <summary>When set, any attempt to directly change the property results in a call to <see langword="IPropertyNotifySink::OnRequestEdit" />. The implementation of <see langword="OnRequestEdit" /> determines if the change is accepted.</summary>
		// Token: 0x04002D3C RID: 11580
		[__DynamicallyInvokable]
		VARFLAG_FREQUESTEDIT = 8,
		/// <summary>The variable is displayed to the user as bindable. <see cref="F:System.Runtime.InteropServices.VARFLAGS.VARFLAG_FBINDABLE" /> must also be set.</summary>
		// Token: 0x04002D3D RID: 11581
		[__DynamicallyInvokable]
		VARFLAG_FDISPLAYBIND = 16,
		/// <summary>The variable is the single property that best represents the object. Only one variable in type information can have this attribute.</summary>
		// Token: 0x04002D3E RID: 11582
		[__DynamicallyInvokable]
		VARFLAG_FDEFAULTBIND = 32,
		/// <summary>The variable should not be displayed to the user in a browser, although it exists and is bindable.</summary>
		// Token: 0x04002D3F RID: 11583
		[__DynamicallyInvokable]
		VARFLAG_FHIDDEN = 64,
		/// <summary>The variable should not be accessible from macro languages. This flag is intended for system-level variables or variables that you do not want type browsers to display.</summary>
		// Token: 0x04002D40 RID: 11584
		[__DynamicallyInvokable]
		VARFLAG_FRESTRICTED = 128,
		/// <summary>Permits an optimization in which the compiler looks for a member named "xyz" on the type of "abc". If such a member is found and is flagged as an accessor function for an element of the default collection, then a call is generated to that member function. Permitted on members in dispinterfaces and interfaces; not permitted on modules.</summary>
		// Token: 0x04002D41 RID: 11585
		[__DynamicallyInvokable]
		VARFLAG_FDEFAULTCOLLELEM = 256,
		/// <summary>The variable is the default display in the user interface.</summary>
		// Token: 0x04002D42 RID: 11586
		[__DynamicallyInvokable]
		VARFLAG_FUIDEFAULT = 512,
		/// <summary>The variable appears in an object browser, but not in a properties browser.</summary>
		// Token: 0x04002D43 RID: 11587
		[__DynamicallyInvokable]
		VARFLAG_FNONBROWSABLE = 1024,
		/// <summary>Tags the interface as having default behaviors.</summary>
		// Token: 0x04002D44 RID: 11588
		[__DynamicallyInvokable]
		VARFLAG_FREPLACEABLE = 2048,
		/// <summary>The variable is mapped as individual bindable properties.</summary>
		// Token: 0x04002D45 RID: 11589
		[__DynamicallyInvokable]
		VARFLAG_FIMMEDIATEBIND = 4096
	}
}
