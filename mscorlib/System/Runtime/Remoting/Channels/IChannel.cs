using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Provides conduits for messages that cross remoting boundaries.</summary>
	// Token: 0x02000810 RID: 2064
	[ComVisible(true)]
	public interface IChannel
	{
		/// <summary>Gets the priority of the channel.</summary>
		/// <returns>An integer that indicates the priority of the channel.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000ED9 RID: 3801
		// (get) Token: 0x060058E9 RID: 22761
		int ChannelPriority { [SecurityCritical] get; }

		/// <summary>Gets the name of the channel.</summary>
		/// <returns>The name of the channel.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EDA RID: 3802
		// (get) Token: 0x060058EA RID: 22762
		string ChannelName { [SecurityCritical] get; }

		/// <summary>Returns the object URI as an out parameter, and the URI of the current channel as the return value.</summary>
		/// <param name="url">The URL of the object.</param>
		/// <param name="objectURI">When this method returns, contains a <see cref="T:System.String" /> that holds the object URI. This parameter is passed uninitialized.</param>
		/// <returns>The URI of the current channel, or <see langword="null" /> if the URI does not belong to this channel.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x060058EB RID: 22763
		[SecurityCritical]
		string Parse(string url, out string objectURI);
	}
}
