using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Specifies how to invoke a function by <see langword="IDispatch::Invoke" />.</summary>
	// Token: 0x02000A1D RID: 2589
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum INVOKEKIND
	{
		/// <summary>The member is called using a normal function invocation syntax.</summary>
		// Token: 0x04002D1B RID: 11547
		[__DynamicallyInvokable]
		INVOKE_FUNC = 1,
		/// <summary>The function is invoked using a normal property access syntax.</summary>
		// Token: 0x04002D1C RID: 11548
		[__DynamicallyInvokable]
		INVOKE_PROPERTYGET = 2,
		/// <summary>The function is invoked using a property value assignment syntax.</summary>
		// Token: 0x04002D1D RID: 11549
		[__DynamicallyInvokable]
		INVOKE_PROPERTYPUT = 4,
		/// <summary>The function is invoked using a property reference assignment syntax.</summary>
		// Token: 0x04002D1E RID: 11550
		[__DynamicallyInvokable]
		INVOKE_PROPERTYPUTREF = 8
	}
}
