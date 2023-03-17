﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Provides the remote procedure call (RPC) interface for all formatters.</summary>
	// Token: 0x02000830 RID: 2096
	[ComVisible(true)]
	public interface IRemotingFormatter : IFormatter
	{
		/// <summary>Begins the deserialization process of a remote procedure call (RPC).</summary>
		/// <param name="serializationStream">The <see cref="T:System.IO.Stream" /> from which the data is deserialized.</param>
		/// <param name="handler">The delegate designed to handle <see cref="T:System.Runtime.Remoting.Messaging.Header" /> objects. Can be <see langword="null" />.</param>
		/// <returns>The root of the deserialized object graph.</returns>
		// Token: 0x06005979 RID: 22905
		object Deserialize(Stream serializationStream, HeaderHandler handler);

		/// <summary>Starts the serialization process of a remote procedure call (RPC).</summary>
		/// <param name="serializationStream">The <see cref="T:System.IO.Stream" /> onto which the specified graph is serialized.</param>
		/// <param name="graph">The root of the object graph to be serialized.</param>
		/// <param name="headers">The array of <see cref="T:System.Runtime.Remoting.Messaging.Header" /> objects to transmit with the graph specified by the <paramref name="graph" /> parameter. Can be <see langword="null" />.</param>
		// Token: 0x0600597A RID: 22906
		void Serialize(Stream serializationStream, object graph, Header[] headers);
	}
}
