using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	/// <summary>Contributes an envoy message sink on the client end.</summary>
	// Token: 0x020007E7 RID: 2023
	[ComVisible(true)]
	public interface IContributeEnvoySink
	{
		/// <summary>Takes the first sink in the chain of sinks composed so far, and then chains its message sink in front of the chain already formed.</summary>
		/// <param name="obj">The server object for which the chain is being created.</param>
		/// <param name="nextSink">The chain of sinks composed so far.</param>
		/// <returns>The composite sink chain.</returns>
		// Token: 0x060057BE RID: 22462
		[SecurityCritical]
		IMessageSink GetEnvoySink(MarshalByRefObject obj, IMessageSink nextSink);
	}
}
