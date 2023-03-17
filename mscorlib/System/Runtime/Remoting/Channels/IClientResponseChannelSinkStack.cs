using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Provides the stack functionality for a stack of client response channel sinks that must be invoked during an asynchronous message response decoding.</summary>
	// Token: 0x02000801 RID: 2049
	[ComVisible(true)]
	public interface IClientResponseChannelSinkStack
	{
		/// <summary>Requests asynchronous processing of a method call on the sinks in the current sink stack.</summary>
		/// <param name="headers">The headers retrieved from the server response stream.</param>
		/// <param name="stream">The stream coming back from the transport sink.</param>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">The current sink stack is empty.</exception>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005884 RID: 22660
		[SecurityCritical]
		void AsyncProcessResponse(ITransportHeaders headers, Stream stream);

		/// <summary>Dispatches the specified reply message on the reply sink.</summary>
		/// <param name="msg">The <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> to dispatch.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005885 RID: 22661
		[SecurityCritical]
		void DispatchReplyMessage(IMessage msg);

		/// <summary>Dispatches the specified exception on the reply sink.</summary>
		/// <param name="e">The exception to dispatch to the server.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005886 RID: 22662
		[SecurityCritical]
		void DispatchException(Exception e);
	}
}
