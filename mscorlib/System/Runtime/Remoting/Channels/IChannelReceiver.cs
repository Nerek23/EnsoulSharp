using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Provides required functions and properties for the receiver channels.</summary>
	// Token: 0x02000812 RID: 2066
	[ComVisible(true)]
	public interface IChannelReceiver : IChannel
	{
		/// <summary>Gets the channel-specific data.</summary>
		/// <returns>The channel data.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EDB RID: 3803
		// (get) Token: 0x060058ED RID: 22765
		object ChannelData { [SecurityCritical] get; }

		/// <summary>Returns an array of all the URLs for a URI.</summary>
		/// <param name="objectURI">The URI for which URLs are required.</param>
		/// <returns>An array of the URLs.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x060058EE RID: 22766
		[SecurityCritical]
		string[] GetUrlsForUri(string objectURI);

		/// <summary>Instructs the current channel to start listening for requests.</summary>
		/// <param name="data">Optional initialization information.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x060058EF RID: 22767
		[SecurityCritical]
		void StartListening(object data);

		/// <summary>Instructs the current channel to stop listening for requests.</summary>
		/// <param name="data">Optional state information for the channel.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x060058F0 RID: 22768
		[SecurityCritical]
		void StopListening(object data);
	}
}
