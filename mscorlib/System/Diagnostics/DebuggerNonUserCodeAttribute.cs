﻿using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	/// <summary>Identifies a type or member that is not part of the user code for an application.</summary>
	// Token: 0x020003BD RID: 957
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DebuggerNonUserCodeAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerNonUserCodeAttribute" /> class.</summary>
		// Token: 0x060031E9 RID: 12777 RVA: 0x000C0136 File Offset: 0x000BE336
		[__DynamicallyInvokable]
		public DebuggerNonUserCodeAttribute()
		{
		}
	}
}
