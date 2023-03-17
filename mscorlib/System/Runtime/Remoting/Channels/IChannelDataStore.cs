﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Stores channel data for the remoting channels.</summary>
	// Token: 0x0200081D RID: 2077
	[ComVisible(true)]
	public interface IChannelDataStore
	{
		/// <summary>Gets an array of channel URIs to which the current channel maps.</summary>
		/// <returns>An array of channel URIs to which the current channel maps.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EE4 RID: 3812
		// (get) Token: 0x06005906 RID: 22790
		string[] ChannelUris { [SecurityCritical] get; }

		/// <summary>Gets or sets the data object associated with the specified key for the implementing channel.</summary>
		/// <param name="key">The key the data object is associated with.</param>
		/// <returns>The specified data object for the implementing channel.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EE5 RID: 3813
		object this[object key]
		{
			[SecurityCritical]
			get;
			[SecurityCritical]
			set;
		}
	}
}
