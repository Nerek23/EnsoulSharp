﻿using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Stores a collection of headers used in the channel sinks.</summary>
	// Token: 0x0200081F RID: 2079
	[ComVisible(true)]
	public interface ITransportHeaders
	{
		/// <summary>Gets or sets a transport header associated with the given key.</summary>
		/// <param name="key">The key the requested transport header is associated with.</param>
		/// <returns>A transport header associated with the given key.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EE8 RID: 3816
		object this[object key]
		{
			[SecurityCritical]
			get;
			[SecurityCritical]
			set;
		}

		/// <summary>Returns a <see cref="T:System.Collections.IEnumerator" /> that iterates over all entries in the <see cref="T:System.Runtime.Remoting.Channels.ITransportHeaders" /> object.</summary>
		/// <returns>A <see cref="T:System.Collections.IEnumerator" /> that iterates over all entries in the <see cref="T:System.Runtime.Remoting.Channels.ITransportHeaders" /> object.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005912 RID: 22802
		[SecurityCritical]
		IEnumerator GetEnumerator();
	}
}
