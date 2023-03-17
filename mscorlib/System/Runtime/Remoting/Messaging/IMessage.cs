using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Contains communication data sent between cooperating message sinks.</summary>
	// Token: 0x0200082A RID: 2090
	[ComVisible(true)]
	public interface IMessage
	{
		/// <summary>Gets an <see cref="T:System.Collections.IDictionary" /> that represents a collection of the message's properties.</summary>
		/// <returns>A dictionary that represents a collection of the message's properties.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F0D RID: 3853
		// (get) Token: 0x0600595F RID: 22879
		IDictionary Properties { [SecurityCritical] get; }
	}
}
