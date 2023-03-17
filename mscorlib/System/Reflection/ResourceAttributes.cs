using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies the attributes for a manifest resource.</summary>
	// Token: 0x020005F2 RID: 1522
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum ResourceAttributes
	{
		/// <summary>A mask used to retrieve public manifest resources.</summary>
		// Token: 0x04001D5F RID: 7519
		Public = 1,
		/// <summary>A mask used to retrieve private manifest resources.</summary>
		// Token: 0x04001D60 RID: 7520
		Private = 2
	}
}
