using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Describes how an instruction alters the flow of control.</summary>
	// Token: 0x0200062D RID: 1581
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum FlowControl
	{
		/// <summary>Branch instruction.</summary>
		// Token: 0x040020C6 RID: 8390
		[__DynamicallyInvokable]
		Branch,
		/// <summary>Break instruction.</summary>
		// Token: 0x040020C7 RID: 8391
		[__DynamicallyInvokable]
		Break,
		/// <summary>Call instruction.</summary>
		// Token: 0x040020C8 RID: 8392
		[__DynamicallyInvokable]
		Call,
		/// <summary>Conditional branch instruction.</summary>
		// Token: 0x040020C9 RID: 8393
		[__DynamicallyInvokable]
		Cond_Branch,
		/// <summary>Provides information about a subsequent instruction. For example, the <see langword="Unaligned" /> instruction of <see langword="Reflection.Emit.Opcodes" /> has <see langword="FlowControl.Meta" /> and specifies that the subsequent pointer instruction might be unaligned.</summary>
		// Token: 0x040020CA RID: 8394
		[__DynamicallyInvokable]
		Meta,
		/// <summary>Normal flow of control.</summary>
		// Token: 0x040020CB RID: 8395
		[__DynamicallyInvokable]
		Next,
		/// <summary>This enumerator value is reserved and should not be used.</summary>
		// Token: 0x040020CC RID: 8396
		[Obsolete("This API has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		Phi,
		/// <summary>Return instruction.</summary>
		// Token: 0x040020CD RID: 8397
		[__DynamicallyInvokable]
		Return,
		/// <summary>Exception throw instruction.</summary>
		// Token: 0x040020CE RID: 8398
		[__DynamicallyInvokable]
		Throw
	}
}
