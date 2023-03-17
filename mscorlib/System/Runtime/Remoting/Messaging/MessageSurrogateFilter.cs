﻿using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Determines whether the <see cref="T:System.Runtime.Remoting.Messaging.RemotingSurrogateSelector" /> class should ignore a particular <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> property while creating an <see cref="T:System.Runtime.Remoting.ObjRef" /> for a <see cref="T:System.MarshalByRefObject" /> class.</summary>
	/// <param name="key">The key to a particular remoting message property.</param>
	/// <param name="value">The value of a particular remoting message property.</param>
	/// <returns>True if the <see cref="T:System.Runtime.Remoting.Messaging.RemotingSurrogateSelector" /> class should ignore a particular <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> property while creating an <see cref="T:System.Runtime.Remoting.ObjRef" /> for a <see cref="T:System.MarshalByRefObject" /> class.</returns>
	// Token: 0x0200084D RID: 2125
	// (Invoke) Token: 0x06005B2D RID: 23341
	[ComVisible(true)]
	public delegate bool MessageSurrogateFilter(string key, object value);
}
