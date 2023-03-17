using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.DISPPARAMS" /> instead.</summary>
	// Token: 0x02000970 RID: 2416
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.DISPPARAMS instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DISPPARAMS
	{
		/// <summary>Represents a reference to the array of arguments.</summary>
		// Token: 0x04002B9D RID: 11165
		public IntPtr rgvarg;

		/// <summary>Represents the dispatch IDs of named arguments.</summary>
		// Token: 0x04002B9E RID: 11166
		public IntPtr rgdispidNamedArgs;

		/// <summary>Represents the count of arguments.</summary>
		// Token: 0x04002B9F RID: 11167
		public int cArgs;

		/// <summary>Represents the count of named arguments.</summary>
		// Token: 0x04002BA0 RID: 11168
		public int cNamedArgs;
	}
}
