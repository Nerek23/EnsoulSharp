﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Provides the stack functionality for a stack of server response channel sinks.</summary>
	// Token: 0x02000804 RID: 2052
	[ComVisible(true)]
	public interface IServerResponseChannelSinkStack
	{
		/// <summary>Requests asynchronous processing of a method call on the sinks in the current sink stack.</summary>
		/// <param name="msg">The response message.</param>
		/// <param name="headers">The headers retrieved from the server response stream.</param>
		/// <param name="stream">The stream coming back from the transport sink.</param>
		// Token: 0x06005893 RID: 22675
		[SecurityCritical]
		void AsyncProcessResponse(IMessage msg, ITransportHeaders headers, Stream stream);

		/// <summary>Returns the <see cref="T:System.IO.Stream" /> onto which the specified message is to be serialized.</summary>
		/// <param name="msg">The message to be serialized onto the requested stream.</param>
		/// <param name="headers">The headers retrieved from the server response stream.</param>
		/// <returns>The <see cref="T:System.IO.Stream" /> onto which the specified message is to be serialized.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005894 RID: 22676
		[SecurityCritical]
		Stream GetResponseStream(IMessage msg, ITransportHeaders headers);
	}
}
