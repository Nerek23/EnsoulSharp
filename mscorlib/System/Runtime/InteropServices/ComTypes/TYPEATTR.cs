using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Contains attributes of a <see langword="UCOMITypeInfo" />.</summary>
	// Token: 0x02000A10 RID: 2576
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TYPEATTR
	{
		/// <summary>A constant used with the <see cref="F:System.Runtime.InteropServices.TYPEATTR.memidConstructor" /> and <see cref="F:System.Runtime.InteropServices.TYPEATTR.memidDestructor" /> fields.</summary>
		// Token: 0x04002CC6 RID: 11462
		[__DynamicallyInvokable]
		public const int MEMBER_ID_NIL = -1;

		/// <summary>The GUID of the type information.</summary>
		// Token: 0x04002CC7 RID: 11463
		[__DynamicallyInvokable]
		public Guid guid;

		/// <summary>Locale of member names and documentation strings.</summary>
		// Token: 0x04002CC8 RID: 11464
		[__DynamicallyInvokable]
		public int lcid;

		/// <summary>Reserved for future use.</summary>
		// Token: 0x04002CC9 RID: 11465
		[__DynamicallyInvokable]
		public int dwReserved;

		/// <summary>ID of constructor, or <see cref="F:System.Runtime.InteropServices.TYPEATTR.MEMBER_ID_NIL" /> if none.</summary>
		// Token: 0x04002CCA RID: 11466
		[__DynamicallyInvokable]
		public int memidConstructor;

		/// <summary>ID of destructor, or <see cref="F:System.Runtime.InteropServices.TYPEATTR.MEMBER_ID_NIL" /> if none.</summary>
		// Token: 0x04002CCB RID: 11467
		[__DynamicallyInvokable]
		public int memidDestructor;

		/// <summary>Reserved for future use.</summary>
		// Token: 0x04002CCC RID: 11468
		public IntPtr lpstrSchema;

		/// <summary>The size of an instance of this type.</summary>
		// Token: 0x04002CCD RID: 11469
		[__DynamicallyInvokable]
		public int cbSizeInstance;

		/// <summary>A <see cref="T:System.Runtime.InteropServices.TYPEKIND" /> value describing the type this information describes.</summary>
		// Token: 0x04002CCE RID: 11470
		[__DynamicallyInvokable]
		public TYPEKIND typekind;

		/// <summary>Indicates the number of functions on the interface this structure describes.</summary>
		// Token: 0x04002CCF RID: 11471
		[__DynamicallyInvokable]
		public short cFuncs;

		/// <summary>Indicates the number of variables and data fields on the interface described by this structure.</summary>
		// Token: 0x04002CD0 RID: 11472
		[__DynamicallyInvokable]
		public short cVars;

		/// <summary>Indicates the number of implemented interfaces on the interface this structure describes.</summary>
		// Token: 0x04002CD1 RID: 11473
		[__DynamicallyInvokable]
		public short cImplTypes;

		/// <summary>The size of this type's virtual method table (VTBL).</summary>
		// Token: 0x04002CD2 RID: 11474
		[__DynamicallyInvokable]
		public short cbSizeVft;

		/// <summary>Specifies the byte alignment for an instance of this type.</summary>
		// Token: 0x04002CD3 RID: 11475
		[__DynamicallyInvokable]
		public short cbAlignment;

		/// <summary>A <see cref="T:System.Runtime.InteropServices.TYPEFLAGS" /> value describing this information.</summary>
		// Token: 0x04002CD4 RID: 11476
		[__DynamicallyInvokable]
		public TYPEFLAGS wTypeFlags;

		/// <summary>Major version number.</summary>
		// Token: 0x04002CD5 RID: 11477
		[__DynamicallyInvokable]
		public short wMajorVerNum;

		/// <summary>Minor version number.</summary>
		// Token: 0x04002CD6 RID: 11478
		[__DynamicallyInvokable]
		public short wMinorVerNum;

		/// <summary>If <see cref="F:System.Runtime.InteropServices.TYPEATTR.typekind" /> == <see cref="F:System.Runtime.InteropServices.TYPEKIND.TKIND_ALIAS" />, specifies the type for which this type is an alias.</summary>
		// Token: 0x04002CD7 RID: 11479
		[__DynamicallyInvokable]
		public TYPEDESC tdescAlias;

		/// <summary>IDL attributes of the described type.</summary>
		// Token: 0x04002CD8 RID: 11480
		[__DynamicallyInvokable]
		public IDLDESC idldescType;
	}
}
