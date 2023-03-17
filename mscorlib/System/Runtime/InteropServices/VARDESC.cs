using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.VARDESC" /> instead.</summary>
	// Token: 0x0200096F RID: 2415
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.VARDESC instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VARDESC
	{
		/// <summary>Indicates the member ID of a variable.</summary>
		// Token: 0x04002B98 RID: 11160
		public int memid;

		/// <summary>This field is reserved for future use.</summary>
		// Token: 0x04002B99 RID: 11161
		public string lpstrSchema;

		/// <summary>Contains the variable type.</summary>
		// Token: 0x04002B9A RID: 11162
		public ELEMDESC elemdescVar;

		/// <summary>Defines the properties of a variable.</summary>
		// Token: 0x04002B9B RID: 11163
		public short wVarFlags;

		/// <summary>Defines how a variable should be marshaled.</summary>
		// Token: 0x04002B9C RID: 11164
		public VarEnum varkind;

		/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.VARDESC.DESCUNION" /> instead.</summary>
		// Token: 0x02000C66 RID: 3174
		[ComVisible(false)]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct DESCUNION
		{
			/// <summary>Indicates the offset of this variable within the instance.</summary>
			// Token: 0x04003775 RID: 14197
			[FieldOffset(0)]
			public int oInst;

			/// <summary>Describes a symbolic constant.</summary>
			// Token: 0x04003776 RID: 14198
			[FieldOffset(0)]
			public IntPtr lpvarValue;
		}
	}
}
