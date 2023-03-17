using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.BIND_OPTS" /> instead.</summary>
	// Token: 0x0200094D RID: 2381
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.BIND_OPTS instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	public struct BIND_OPTS
	{
		/// <summary>Specifies the size of the <see langword="BIND_OPTS" /> structure in bytes.</summary>
		// Token: 0x04002B26 RID: 11046
		public int cbStruct;

		/// <summary>Controls aspects of moniker binding operations.</summary>
		// Token: 0x04002B27 RID: 11047
		public int grfFlags;

		/// <summary>Flags that should be used when opening the file that contains the object identified by the moniker.</summary>
		// Token: 0x04002B28 RID: 11048
		public int grfMode;

		/// <summary>Indicates the amount of time (clock time in milliseconds, as returned by the <see langword="GetTickCount" /> function) the caller specified to complete the binding operation.</summary>
		// Token: 0x04002B29 RID: 11049
		public int dwTickCountDeadline;
	}
}
