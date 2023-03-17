using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Creates server channel sinks for the server channel through which remoting messages flow.</summary>
	// Token: 0x02000815 RID: 2069
	[ComVisible(true)]
	public interface IServerChannelSinkProvider
	{
		/// <summary>Returns the channel data for the channel that the current sink is associated with.</summary>
		/// <param name="channelData">A <see cref="T:System.Runtime.Remoting.Channels.IChannelDataStore" /> object in which the channel data is to be returned.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x060058F8 RID: 22776
		[SecurityCritical]
		void GetChannelData(IChannelDataStore channelData);

		/// <summary>Creates a sink chain.</summary>
		/// <param name="channel">The channel for which to create the channel sink chain.</param>
		/// <returns>The first sink of the newly formed channel sink chain, or <see langword="null" />, which indicates that this provider will not or cannot provide a connection for this endpoint.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x060058F9 RID: 22777
		[SecurityCritical]
		IServerChannelSink CreateSink(IChannelReceiver channel);

		/// <summary>Gets or sets the next sink provider in the channel sink provider chain.</summary>
		/// <returns>The next sink provider in the channel sink provider chain.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EE0 RID: 3808
		// (get) Token: 0x060058FA RID: 22778
		// (set) Token: 0x060058FB RID: 22779
		IServerChannelSinkProvider Next { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
