using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting
{
	/// <summary>Defines how well-known objects are activated.</summary>
	// Token: 0x02000780 RID: 1920
	[ComVisible(true)]
	[Serializable]
	public enum WellKnownObjectMode
	{
		/// <summary>Every incoming message is serviced by the same object instance.</summary>
		// Token: 0x0400266E RID: 9838
		Singleton = 1,
		/// <summary>Every incoming message is serviced by a new object instance.</summary>
		// Token: 0x0400266F RID: 9839
		SingleCall
	}
}
