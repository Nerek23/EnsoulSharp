using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Describes the type of a COM member.</summary>
	// Token: 0x02000935 RID: 2357
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum ComMemberType
	{
		/// <summary>The member is a normal method.</summary>
		// Token: 0x04002AD7 RID: 10967
		[__DynamicallyInvokable]
		Method,
		/// <summary>The member gets properties.</summary>
		// Token: 0x04002AD8 RID: 10968
		[__DynamicallyInvokable]
		PropGet,
		/// <summary>The member sets properties.</summary>
		// Token: 0x04002AD9 RID: 10969
		[__DynamicallyInvokable]
		PropSet
	}
}
