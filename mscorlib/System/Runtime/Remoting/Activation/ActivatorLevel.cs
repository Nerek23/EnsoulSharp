using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Activation
{
	/// <summary>Defines the appropriate position for a <see cref="T:System.Activator" /> in the chain of activators.</summary>
	// Token: 0x0200086D RID: 2157
	[ComVisible(true)]
	[Serializable]
	public enum ActivatorLevel
	{
		/// <summary>Constructs a blank object and runs the constructor.</summary>
		// Token: 0x0400293B RID: 10555
		Construction = 4,
		/// <summary>Finds or creates a suitable context.</summary>
		// Token: 0x0400293C RID: 10556
		Context = 8,
		/// <summary>Finds or creates a <see cref="T:System.AppDomain" />.</summary>
		// Token: 0x0400293D RID: 10557
		AppDomain = 12,
		/// <summary>Starts a process.</summary>
		// Token: 0x0400293E RID: 10558
		Process = 16,
		/// <summary>Finds a suitable computer.</summary>
		// Token: 0x0400293F RID: 10559
		Machine = 20
	}
}
