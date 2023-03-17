using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	/// <summary>Contributes an object-specific interception sink on the server end of a remoting call.</summary>
	// Token: 0x020007E8 RID: 2024
	[ComVisible(true)]
	public interface IContributeObjectSink
	{
		/// <summary>Chains the message sink of the provided server object in front of the given sink chain.</summary>
		/// <param name="obj">The server object which provides the message sink that is to be chained in front of the given chain.</param>
		/// <param name="nextSink">The chain of sinks composed so far.</param>
		/// <returns>The composite sink chain.</returns>
		// Token: 0x060057BF RID: 22463
		[SecurityCritical]
		IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink);
	}
}
