using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Threading
{
	/// <summary>Notifies one or more waiting threads that an event has occurred. This class cannot be inherited.</summary>
	// Token: 0x020004D3 RID: 1235
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public sealed class ManualResetEvent : EventWaitHandle
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.ManualResetEvent" /> class with a Boolean value indicating whether to set the initial state to signaled.</summary>
		/// <param name="initialState">
		///   <see langword="true" /> to set the initial state signaled; <see langword="false" /> to set the initial state to nonsignaled.</param>
		// Token: 0x06003B40 RID: 15168 RVA: 0x000DF8CE File Offset: 0x000DDACE
		[__DynamicallyInvokable]
		public ManualResetEvent(bool initialState) : base(initialState, EventResetMode.ManualReset)
		{
		}
	}
}
