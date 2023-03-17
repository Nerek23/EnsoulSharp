using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	/// <summary>Represents the method that handles calls from a <see cref="T:System.Threading.Timer" />.</summary>
	/// <param name="state">An object containing application-specific information relevant to the method invoked by this delegate, or <see langword="null" />.</param>
	// Token: 0x02000500 RID: 1280
	// (Invoke) Token: 0x06003D12 RID: 15634
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public delegate void TimerCallback(object state);
}
