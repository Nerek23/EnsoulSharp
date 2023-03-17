using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.LIBFLAGS" /> instead.</summary>
	// Token: 0x02000979 RID: 2425
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.LIBFLAGS instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Flags]
	[Serializable]
	public enum LIBFLAGS : short
	{
		/// <summary>The type library is restricted, and should not be displayed to users.</summary>
		// Token: 0x04002BE0 RID: 11232
		LIBFLAG_FRESTRICTED = 1,
		/// <summary>The type library describes controls, and should not be displayed in type browsers intended for nonvisual objects.</summary>
		// Token: 0x04002BE1 RID: 11233
		LIBFLAG_FCONTROL = 2,
		/// <summary>The type library should not be displayed to users, although its use is not restricted. Should be used by controls. Hosts should create a new type library that wraps the control with extended properties.</summary>
		// Token: 0x04002BE2 RID: 11234
		LIBFLAG_FHIDDEN = 4,
		/// <summary>The type library exists in a persisted form on disk.</summary>
		// Token: 0x04002BE3 RID: 11235
		LIBFLAG_FHASDISKIMAGE = 8
	}
}
