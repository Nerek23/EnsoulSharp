using System;

namespace System.Threading
{
	/// <summary>Represents a method to be called when a message is to be dispatched to a synchronization context.</summary>
	/// <param name="state">The object passed to the delegate.</param>
	// Token: 0x020004BE RID: 1214
	// (Invoke) Token: 0x06003A6D RID: 14957
	[__DynamicallyInvokable]
	public delegate void SendOrPostCallback(object state);
}
