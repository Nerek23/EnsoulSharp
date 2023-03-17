using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Contains the type description and process transfer information for a variable, function, or a function parameter.</summary>
	// Token: 0x02000A17 RID: 2583
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ELEMDESC
	{
		/// <summary>Identifies the type of the element.</summary>
		// Token: 0x04002CFA RID: 11514
		[__DynamicallyInvokable]
		public TYPEDESC tdesc;

		/// <summary>Contains information about an element.</summary>
		// Token: 0x04002CFB RID: 11515
		[__DynamicallyInvokable]
		public ELEMDESC.DESCUNION desc;

		/// <summary>Contains information about an element.</summary>
		// Token: 0x02000C75 RID: 3189
		[__DynamicallyInvokable]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct DESCUNION
		{
			/// <summary>Contains information for remoting the element.</summary>
			// Token: 0x040037A6 RID: 14246
			[__DynamicallyInvokable]
			[FieldOffset(0)]
			public IDLDESC idldesc;

			/// <summary>Contains information about the parameter.</summary>
			// Token: 0x040037A7 RID: 14247
			[__DynamicallyInvokable]
			[FieldOffset(0)]
			public PARAMDESC paramdesc;
		}
	}
}
