using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Contains a pointer to a bound-to <see cref="T:System.Runtime.InteropServices.FUNCDESC" /> structure, <see cref="T:System.Runtime.InteropServices.VARDESC" /> structure, or an <see langword="ITypeComp" /> interface.</summary>
	// Token: 0x02000A0B RID: 2571
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct BINDPTR
	{
		/// <summary>Represents a pointer to a <see cref="T:System.Runtime.InteropServices.FUNCDESC" /> structure.</summary>
		// Token: 0x04002CA4 RID: 11428
		[FieldOffset(0)]
		public IntPtr lpfuncdesc;

		/// <summary>Represents a pointer to a <see cref="T:System.Runtime.InteropServices.VARDESC" /> structure.</summary>
		// Token: 0x04002CA5 RID: 11429
		[FieldOffset(0)]
		public IntPtr lpvardesc;

		/// <summary>Represents a pointer to an <see cref="T:System.Runtime.InteropServices.ComTypes.ITypeComp" /> interface.</summary>
		// Token: 0x04002CA6 RID: 11430
		[FieldOffset(0)]
		public IntPtr lptcomp;
	}
}
