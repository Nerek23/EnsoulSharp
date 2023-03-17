using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	/// <summary>Represents a method to be called when a <see cref="T:System.Threading.WaitHandle" /> is signaled or times out.</summary>
	/// <param name="state">An object containing information to be used by the callback method each time it executes.</param>
	/// <param name="timedOut">
	///   <see langword="true" /> if the <see cref="T:System.Threading.WaitHandle" /> timed out; <see langword="false" /> if it was signaled.</param>
	// Token: 0x020004F3 RID: 1267
	// (Invoke) Token: 0x06003CC0 RID: 15552
	[ComVisible(true)]
	public delegate void WaitOrTimerCallback(object state, bool timedOut);
}
