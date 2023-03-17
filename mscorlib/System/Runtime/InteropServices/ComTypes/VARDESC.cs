using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Describes a variable, constant, or data member.</summary>
	// Token: 0x02000A19 RID: 2585
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VARDESC
	{
		/// <summary>Indicates the member ID of a variable.</summary>
		// Token: 0x04002D01 RID: 11521
		[__DynamicallyInvokable]
		public int memid;

		/// <summary>This field is reserved for future use.</summary>
		// Token: 0x04002D02 RID: 11522
		[__DynamicallyInvokable]
		public string lpstrSchema;

		/// <summary>Contains information about a variable.</summary>
		// Token: 0x04002D03 RID: 11523
		[__DynamicallyInvokable]
		public VARDESC.DESCUNION desc;

		/// <summary>Contains the variable type.</summary>
		// Token: 0x04002D04 RID: 11524
		[__DynamicallyInvokable]
		public ELEMDESC elemdescVar;

		/// <summary>Defines the properties of a variable.</summary>
		// Token: 0x04002D05 RID: 11525
		[__DynamicallyInvokable]
		public short wVarFlags;

		/// <summary>Defines how to marshal a variable.</summary>
		// Token: 0x04002D06 RID: 11526
		[__DynamicallyInvokable]
		public VARKIND varkind;

		/// <summary>Contains information about a variable.</summary>
		// Token: 0x02000C76 RID: 3190
		[__DynamicallyInvokable]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct DESCUNION
		{
			/// <summary>Indicates the offset of this variable within the instance.</summary>
			// Token: 0x040037A8 RID: 14248
			[__DynamicallyInvokable]
			[FieldOffset(0)]
			public int oInst;

			/// <summary>Describes a symbolic constant.</summary>
			// Token: 0x040037A9 RID: 14249
			[FieldOffset(0)]
			public IntPtr lpvarValue;
		}
	}
}
