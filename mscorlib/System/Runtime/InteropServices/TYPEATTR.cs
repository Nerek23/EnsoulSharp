using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.TYPEATTR" /> instead.</summary>
	// Token: 0x02000967 RID: 2407
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.TYPEATTR instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TYPEATTR
	{
		/// <summary>A constant used with the <see cref="F:System.Runtime.InteropServices.TYPEATTR.memidConstructor" /> and <see cref="F:System.Runtime.InteropServices.TYPEATTR.memidDestructor" /> fields.</summary>
		// Token: 0x04002B62 RID: 11106
		public const int MEMBER_ID_NIL = -1;

		/// <summary>The GUID of the type information.</summary>
		// Token: 0x04002B63 RID: 11107
		public Guid guid;

		/// <summary>Locale of member names and documentation strings.</summary>
		// Token: 0x04002B64 RID: 11108
		public int lcid;

		/// <summary>Reserved for future use.</summary>
		// Token: 0x04002B65 RID: 11109
		public int dwReserved;

		/// <summary>ID of constructor, or <see cref="F:System.Runtime.InteropServices.TYPEATTR.MEMBER_ID_NIL" /> if none.</summary>
		// Token: 0x04002B66 RID: 11110
		public int memidConstructor;

		/// <summary>ID of destructor, or <see cref="F:System.Runtime.InteropServices.TYPEATTR.MEMBER_ID_NIL" /> if none.</summary>
		// Token: 0x04002B67 RID: 11111
		public int memidDestructor;

		/// <summary>Reserved for future use.</summary>
		// Token: 0x04002B68 RID: 11112
		public IntPtr lpstrSchema;

		/// <summary>The size of an instance of this type.</summary>
		// Token: 0x04002B69 RID: 11113
		public int cbSizeInstance;

		/// <summary>A <see cref="T:System.Runtime.InteropServices.TYPEKIND" /> value describing the type this information describes.</summary>
		// Token: 0x04002B6A RID: 11114
		public TYPEKIND typekind;

		/// <summary>Indicates the number of functions on the interface this structure describes.</summary>
		// Token: 0x04002B6B RID: 11115
		public short cFuncs;

		/// <summary>Indicates the number of variables and data fields on the interface described by this structure.</summary>
		// Token: 0x04002B6C RID: 11116
		public short cVars;

		/// <summary>Indicates the number of implemented interfaces on the interface this structure describes.</summary>
		// Token: 0x04002B6D RID: 11117
		public short cImplTypes;

		/// <summary>The size of this type's virtual method table (VTBL).</summary>
		// Token: 0x04002B6E RID: 11118
		public short cbSizeVft;

		/// <summary>Specifies the byte alignment for an instance of this type.</summary>
		// Token: 0x04002B6F RID: 11119
		public short cbAlignment;

		/// <summary>A <see cref="T:System.Runtime.InteropServices.TYPEFLAGS" /> value describing this information.</summary>
		// Token: 0x04002B70 RID: 11120
		public TYPEFLAGS wTypeFlags;

		/// <summary>Major version number.</summary>
		// Token: 0x04002B71 RID: 11121
		public short wMajorVerNum;

		/// <summary>Minor version number.</summary>
		// Token: 0x04002B72 RID: 11122
		public short wMinorVerNum;

		/// <summary>If <see cref="F:System.Runtime.InteropServices.TYPEATTR.typekind" /> == <see cref="F:System.Runtime.InteropServices.TYPEKIND.TKIND_ALIAS" />, specifies the type for which this type is an alias.</summary>
		// Token: 0x04002B73 RID: 11123
		public TYPEDESC tdescAlias;

		/// <summary>IDL attributes of the described type.</summary>
		// Token: 0x04002B74 RID: 11124
		public IDLDESC idldescType;
	}
}
