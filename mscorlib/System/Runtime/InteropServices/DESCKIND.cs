using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.DESCKIND" /> instead.</summary>
	// Token: 0x02000961 RID: 2401
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.DESCKIND instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	public enum DESCKIND
	{
		/// <summary>Indicates that no match was found.</summary>
		// Token: 0x04002B3A RID: 11066
		DESCKIND_NONE,
		/// <summary>Indicates that a <see cref="T:System.Runtime.InteropServices.FUNCDESC" /> was returned.</summary>
		// Token: 0x04002B3B RID: 11067
		DESCKIND_FUNCDESC,
		/// <summary>Indicates that a <see langword="VARDESC" /> was returned.</summary>
		// Token: 0x04002B3C RID: 11068
		DESCKIND_VARDESC,
		/// <summary>Indicates that a <see langword="TYPECOMP" /> was returned.</summary>
		// Token: 0x04002B3D RID: 11069
		DESCKIND_TYPECOMP,
		/// <summary>Indicates that an <see langword="IMPLICITAPPOBJ" /> was returned.</summary>
		// Token: 0x04002B3E RID: 11070
		DESCKIND_IMPLICITAPPOBJ,
		/// <summary>Indicates an end of enumeration marker.</summary>
		// Token: 0x04002B3F RID: 11071
		DESCKIND_MAX
	}
}
