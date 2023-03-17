﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	/// <summary>Contributes an interception sink at the context boundary on the server end of a remoting call.</summary>
	// Token: 0x020007E9 RID: 2025
	[ComVisible(true)]
	public interface IContributeServerContextSink
	{
		/// <summary>Takes the first sink in the chain of sinks composed so far, and then chains its message sink in front of the chain already formed.</summary>
		/// <param name="nextSink">The chain of sinks composed so far.</param>
		/// <returns>The composite sink chain.</returns>
		// Token: 0x060057C0 RID: 22464
		[SecurityCritical]
		IMessageSink GetServerContextSink(IMessageSink nextSink);
	}
}
