using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting
{
	/// <summary>Provides envoy information.</summary>
	// Token: 0x0200078A RID: 1930
	[ComVisible(true)]
	public interface IEnvoyInfo
	{
		/// <summary>Gets or sets the list of envoys that were contributed by the server context and object chains when the object was marshaled.</summary>
		/// <returns>A chain of envoy sinks.</returns>
		// Token: 0x17000E00 RID: 3584
		// (get) Token: 0x0600546A RID: 21610
		// (set) Token: 0x0600546B RID: 21611
		IMessageSink EnvoySinks { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
