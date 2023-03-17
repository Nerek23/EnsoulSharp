using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting
{
	/// <summary>Specifies how custom errors are handled.</summary>
	// Token: 0x02000799 RID: 1945
	[ComVisible(true)]
	public enum CustomErrorsModes
	{
		/// <summary>All callers receive filtered exception information.</summary>
		// Token: 0x040026D0 RID: 9936
		On,
		/// <summary>All callers receive complete exception information.</summary>
		// Token: 0x040026D1 RID: 9937
		Off,
		/// <summary>Local callers receive complete exception information; remote callers receive filtered exception information.</summary>
		// Token: 0x040026D2 RID: 9938
		RemoteOnly
	}
}
