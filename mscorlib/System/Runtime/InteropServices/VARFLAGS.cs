using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.VARFLAGS" /> instead.</summary>
	// Token: 0x02000976 RID: 2422
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.VARFLAGS instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Flags]
	[Serializable]
	public enum VARFLAGS : short
	{
		/// <summary>Assignment to the variable should not be allowed.</summary>
		// Token: 0x04002BCE RID: 11214
		VARFLAG_FREADONLY = 1,
		/// <summary>The variable returns an object that is a source of events.</summary>
		// Token: 0x04002BCF RID: 11215
		VARFLAG_FSOURCE = 2,
		/// <summary>The variable supports data binding.</summary>
		// Token: 0x04002BD0 RID: 11216
		VARFLAG_FBINDABLE = 4,
		/// <summary>When set, any attempt to directly change the property results in a call to <see langword="IPropertyNotifySink::OnRequestEdit" />. The implementation of <see langword="OnRequestEdit" /> determines if the change is accepted.</summary>
		// Token: 0x04002BD1 RID: 11217
		VARFLAG_FREQUESTEDIT = 8,
		/// <summary>The variable is displayed to the user as bindable. <see cref="F:System.Runtime.InteropServices.VARFLAGS.VARFLAG_FBINDABLE" /> must also be set.</summary>
		// Token: 0x04002BD2 RID: 11218
		VARFLAG_FDISPLAYBIND = 16,
		/// <summary>The variable is the single property that best represents the object. Only one variable in type information can have this attribute.</summary>
		// Token: 0x04002BD3 RID: 11219
		VARFLAG_FDEFAULTBIND = 32,
		/// <summary>The variable should not be displayed to the user in a browser, although it exists and is bindable.</summary>
		// Token: 0x04002BD4 RID: 11220
		VARFLAG_FHIDDEN = 64,
		/// <summary>The variable should not be accessible from macro languages. This flag is intended for system-level variables or variables that you do not want type browsers to display.</summary>
		// Token: 0x04002BD5 RID: 11221
		VARFLAG_FRESTRICTED = 128,
		/// <summary>Permits an optimization in which the compiler looks for a member named "xyz" on the type of "abc". If such a member is found and is flagged as an accessor function for an element of the default collection, then a call is generated to that member function. Permitted on members in dispinterfaces and interfaces; not permitted on modules.</summary>
		// Token: 0x04002BD6 RID: 11222
		VARFLAG_FDEFAULTCOLLELEM = 256,
		/// <summary>The variable is the default display in the user interface.</summary>
		// Token: 0x04002BD7 RID: 11223
		VARFLAG_FUIDEFAULT = 512,
		/// <summary>The variable appears in an object browser, but not in a properties browser.</summary>
		// Token: 0x04002BD8 RID: 11224
		VARFLAG_FNONBROWSABLE = 1024,
		/// <summary>Tags the interface as having default behaviors.</summary>
		// Token: 0x04002BD9 RID: 11225
		VARFLAG_FREPLACEABLE = 2048,
		/// <summary>The variable is mapped as individual bindable properties.</summary>
		// Token: 0x04002BDA RID: 11226
		VARFLAG_FIMMEDIATEBIND = 4096
	}
}
