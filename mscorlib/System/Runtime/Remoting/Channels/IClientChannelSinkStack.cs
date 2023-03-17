using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Provides functionality for a stack of client channel sinks that must be invoked during an asynchronous message response decoding.</summary>
	// Token: 0x02000800 RID: 2048
	[ComVisible(true)]
	public interface IClientChannelSinkStack : IClientResponseChannelSinkStack
	{
		/// <summary>Pushes the specified sink and information associated with it onto the sink stack.</summary>
		/// <param name="sink">The sink to push onto the sink stack.</param>
		/// <param name="state">Information generated on the request side that is needed on the response side.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005882 RID: 22658
		[SecurityCritical]
		void Push(IClientChannelSink sink, object state);

		/// <summary>Pops the information associated with all the sinks from the sink stack up to and including the specified sink.</summary>
		/// <param name="sink">The sink to remove and return from the sink stack.</param>
		/// <returns>Information generated on the request side and associated with the specified sink.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005883 RID: 22659
		[SecurityCritical]
		object Pop(IClientChannelSink sink);
	}
}
