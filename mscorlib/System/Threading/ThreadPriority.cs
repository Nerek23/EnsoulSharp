using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	/// <summary>Specifies the scheduling priority of a <see cref="T:System.Threading.Thread" />.</summary>
	// Token: 0x020004FA RID: 1274
	[ComVisible(true)]
	[Serializable]
	public enum ThreadPriority
	{
		/// <summary>The <see cref="T:System.Threading.Thread" /> can be scheduled after threads with any other priority.</summary>
		// Token: 0x04001963 RID: 6499
		Lowest,
		/// <summary>The <see cref="T:System.Threading.Thread" /> can be scheduled after threads with <see langword="Normal" /> priority and before those with <see langword="Lowest" /> priority.</summary>
		// Token: 0x04001964 RID: 6500
		BelowNormal,
		/// <summary>The <see cref="T:System.Threading.Thread" /> can be scheduled after threads with <see langword="AboveNormal" /> priority and before those with <see langword="BelowNormal" /> priority. Threads have <see langword="Normal" /> priority by default.</summary>
		// Token: 0x04001965 RID: 6501
		Normal,
		/// <summary>The <see cref="T:System.Threading.Thread" /> can be scheduled after threads with <see langword="Highest" /> priority and before those with <see langword="Normal" /> priority.</summary>
		// Token: 0x04001966 RID: 6502
		AboveNormal,
		/// <summary>The <see cref="T:System.Threading.Thread" /> can be scheduled before threads with any other priority.</summary>
		// Token: 0x04001967 RID: 6503
		Highest
	}
}
