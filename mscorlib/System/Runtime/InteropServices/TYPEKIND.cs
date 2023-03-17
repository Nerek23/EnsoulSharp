using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.TYPEKIND" /> instead.</summary>
	// Token: 0x02000964 RID: 2404
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.TYPEKIND instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	public enum TYPEKIND
	{
		/// <summary>A set of enumerators.</summary>
		// Token: 0x04002B44 RID: 11076
		TKIND_ENUM,
		/// <summary>A structure with no methods.</summary>
		// Token: 0x04002B45 RID: 11077
		TKIND_RECORD,
		/// <summary>A module that can only have static functions and data (for example, a DLL).</summary>
		// Token: 0x04002B46 RID: 11078
		TKIND_MODULE,
		/// <summary>A type that has virtual functions, all of which are pure.</summary>
		// Token: 0x04002B47 RID: 11079
		TKIND_INTERFACE,
		/// <summary>A set of methods and properties that are accessible through <see langword="IDispatch::Invoke" />. By default, dual interfaces return <see langword="TKIND_DISPATCH" />.</summary>
		// Token: 0x04002B48 RID: 11080
		TKIND_DISPATCH,
		/// <summary>A set of implemented components interfaces.</summary>
		// Token: 0x04002B49 RID: 11081
		TKIND_COCLASS,
		/// <summary>A type that is an alias for another type.</summary>
		// Token: 0x04002B4A RID: 11082
		TKIND_ALIAS,
		/// <summary>A union of all members that have an offset of zero.</summary>
		// Token: 0x04002B4B RID: 11083
		TKIND_UNION,
		/// <summary>End of enumeration marker.</summary>
		// Token: 0x04002B4C RID: 11084
		TKIND_MAX
	}
}
