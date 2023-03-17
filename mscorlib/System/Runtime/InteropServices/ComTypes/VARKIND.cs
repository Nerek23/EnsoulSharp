using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Defines the kind of variable.</summary>
	// Token: 0x02000A18 RID: 2584
	[__DynamicallyInvokable]
	[Serializable]
	public enum VARKIND
	{
		/// <summary>The variable is a field or member of the type. It exists at a fixed offset within each instance of the type.</summary>
		// Token: 0x04002CFD RID: 11517
		[__DynamicallyInvokable]
		VAR_PERINSTANCE,
		/// <summary>There is only one instance of the variable.</summary>
		// Token: 0x04002CFE RID: 11518
		[__DynamicallyInvokable]
		VAR_STATIC,
		/// <summary>The <see langword="VARDESC" /> structure describes a symbolic constant. There is no memory associated with it.</summary>
		// Token: 0x04002CFF RID: 11519
		[__DynamicallyInvokable]
		VAR_CONST,
		/// <summary>The variable can be accessed only through <see langword="IDispatch::Invoke" />.</summary>
		// Token: 0x04002D00 RID: 11520
		[__DynamicallyInvokable]
		VAR_DISPATCH
	}
}
