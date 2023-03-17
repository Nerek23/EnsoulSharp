using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Indicates that the implementing channel wants to hook into the outside listener service.</summary>
	// Token: 0x02000813 RID: 2067
	[ComVisible(true)]
	public interface IChannelReceiverHook
	{
		/// <summary>Gets the type of listener to hook into.</summary>
		/// <returns>The type of listener to hook into (for example, "http").</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EDC RID: 3804
		// (get) Token: 0x060058F1 RID: 22769
		string ChannelScheme { [SecurityCritical] get; }

		/// <summary>Gets a Boolean value that indicates whether <see cref="T:System.Runtime.Remoting.Channels.IChannelReceiverHook" /> needs to be hooked into the outside listener service.</summary>
		/// <returns>A Boolean value that indicates whether <see cref="T:System.Runtime.Remoting.Channels.IChannelReceiverHook" /> needs to be hooked into the outside listener service.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EDD RID: 3805
		// (get) Token: 0x060058F2 RID: 22770
		bool WantsToListen { [SecurityCritical] get; }

		/// <summary>Gets the channel sink chain that the current channel is using.</summary>
		/// <returns>The channel sink chain that the current channel is using.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EDE RID: 3806
		// (get) Token: 0x060058F3 RID: 22771
		IServerChannelSink ChannelSinkChain { [SecurityCritical] get; }

		/// <summary>Adds a URI on which the channel hook will listen.</summary>
		/// <param name="channelUri">A URI on which the channel hook will listen.</param>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x060058F4 RID: 22772
		[SecurityCritical]
		void AddHookChannelUri(string channelUri);
	}
}
