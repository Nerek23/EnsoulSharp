﻿using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	/// <summary>Represents a method to be called within a new context.</summary>
	/// <param name="state">An object containing information to be used by the callback method each time it executes.</param>
	// Token: 0x020004C8 RID: 1224
	// (Invoke) Token: 0x06003AC8 RID: 15048
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public delegate void ContextCallback(object state);
}
