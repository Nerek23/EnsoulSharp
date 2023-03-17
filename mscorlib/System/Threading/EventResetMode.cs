﻿using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	/// <summary>Indicates whether an <see cref="T:System.Threading.EventWaitHandle" /> is reset automatically or manually after receiving a signal.</summary>
	// Token: 0x020004C6 RID: 1222
	[ComVisible(false)]
	[__DynamicallyInvokable]
	public enum EventResetMode
	{
		/// <summary>When signaled, the <see cref="T:System.Threading.EventWaitHandle" /> resets automatically after releasing a single thread. If no threads are waiting, the <see cref="T:System.Threading.EventWaitHandle" /> remains signaled until a thread blocks, and resets after releasing the thread.</summary>
		// Token: 0x040018C5 RID: 6341
		[__DynamicallyInvokable]
		AutoReset,
		/// <summary>When signaled, the <see cref="T:System.Threading.EventWaitHandle" /> releases all waiting threads and remains signaled until it is manually reset.</summary>
		// Token: 0x040018C6 RID: 6342
		[__DynamicallyInvokable]
		ManualReset
	}
}
