using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	/// <summary>Specifies the apartment state of a <see cref="T:System.Threading.Thread" />.</summary>
	// Token: 0x02000509 RID: 1289
	[ComVisible(true)]
	[Serializable]
	public enum ApartmentState
	{
		/// <summary>The <see cref="T:System.Threading.Thread" /> will create and enter a single-threaded apartment.</summary>
		// Token: 0x04001999 RID: 6553
		STA,
		/// <summary>The <see cref="T:System.Threading.Thread" /> will create and enter a multithreaded apartment.</summary>
		// Token: 0x0400199A RID: 6554
		MTA,
		/// <summary>The <see cref="P:System.Threading.Thread.ApartmentState" /> property has not been set.</summary>
		// Token: 0x0400199B RID: 6555
		Unknown
	}
}
