﻿using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	/// <summary>Represents a callback method to be executed by a thread pool thread.</summary>
	/// <param name="state">An object containing information to be used by the callback method.</param>
	// Token: 0x020004F2 RID: 1266
	// (Invoke) Token: 0x06003CBC RID: 15548
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public delegate void WaitCallback(object state);
}
