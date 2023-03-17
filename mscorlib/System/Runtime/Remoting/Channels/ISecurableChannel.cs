using System;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>The <see cref="T:System.Runtime.Remoting.Channels.ISecurableChannel" /> contains one property, <see cref="P:System.Runtime.Remoting.Channels.ISecurableChannel.IsSecured" />, which gets or sets a Boolean value that indicates whether the current channel is secure.</summary>
	// Token: 0x02000827 RID: 2087
	public interface ISecurableChannel
	{
		/// <summary>Gets or sets a Boolean value that indicates whether the current channel is secure.</summary>
		/// <returns>A Boolean value that indicates whether the current channel is secure.</returns>
		// Token: 0x17000F03 RID: 3843
		// (get) Token: 0x06005948 RID: 22856
		// (set) Token: 0x06005949 RID: 22857
		bool IsSecured { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
