﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Creates client channel sinks for the client channel through which remoting messages flow.</summary>
	// Token: 0x02000814 RID: 2068
	[ComVisible(true)]
	public interface IClientChannelSinkProvider
	{
		/// <summary>Creates a sink chain.</summary>
		/// <param name="channel">Channel for which the current sink chain is being constructed.</param>
		/// <param name="url">The URL of the object to connect to. This parameter can be <see langword="null" /> if the connection is based entirely on the information contained in the <paramref name="remoteChannelData" /> parameter.</param>
		/// <param name="remoteChannelData">A channel data object that describes a channel on the remote server.</param>
		/// <returns>The first sink of the newly formed channel sink chain, or <see langword="null" />, which indicates that this provider will not or cannot provide a connection for this endpoint.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x060058F5 RID: 22773
		[SecurityCritical]
		IClientChannelSink CreateSink(IChannelSender channel, string url, object remoteChannelData);

		/// <summary>Gets or sets the next sink provider in the channel sink provider chain.</summary>
		/// <returns>The next sink provider in the channel sink provider chain.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EDF RID: 3807
		// (get) Token: 0x060058F6 RID: 22774
		// (set) Token: 0x060058F7 RID: 22775
		IClientChannelSinkProvider Next { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
