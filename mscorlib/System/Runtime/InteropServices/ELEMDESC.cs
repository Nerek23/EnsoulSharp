using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.ELEMDESC" /> instead.</summary>
	// Token: 0x0200096E RID: 2414
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.ELEMDESC instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ELEMDESC
	{
		/// <summary>Identifies the type of the element.</summary>
		// Token: 0x04002B96 RID: 11158
		public TYPEDESC tdesc;

		/// <summary>Contains information about an element.</summary>
		// Token: 0x04002B97 RID: 11159
		public ELEMDESC.DESCUNION desc;

		/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.ELEMDESC.DESCUNION" /> instead.</summary>
		// Token: 0x02000C65 RID: 3173
		[ComVisible(false)]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct DESCUNION
		{
			/// <summary>Contains information for remoting the element.</summary>
			// Token: 0x04003773 RID: 14195
			[FieldOffset(0)]
			public IDLDESC idldesc;

			/// <summary>Contains information about the parameter.</summary>
			// Token: 0x04003774 RID: 14196
			[FieldOffset(0)]
			public PARAMDESC paramdesc;
		}
	}
}
