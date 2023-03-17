using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Provides return values for the <see cref="M:System.Runtime.InteropServices.ICustomQueryInterface.GetInterface(System.Guid@,System.IntPtr@)" /> method.</summary>
	// Token: 0x02000939 RID: 2361
	[ComVisible(false)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum CustomQueryInterfaceResult
	{
		/// <summary>The interface pointer that is returned from the <see cref="M:System.Runtime.InteropServices.ICustomQueryInterface.GetInterface(System.Guid@,System.IntPtr@)" /> method can be used as the result of IUnknown::QueryInterface.</summary>
		// Token: 0x04002ADB RID: 10971
		[__DynamicallyInvokable]
		Handled,
		/// <summary>The custom <see langword="QueryInterface" /> was not used. Instead, the default implementation of IUnknown::QueryInterface should be used.</summary>
		// Token: 0x04002ADC RID: 10972
		[__DynamicallyInvokable]
		NotHandled,
		/// <summary>The interface for a specific interface ID is not available. In this case, the returned interface is <see langword="null" />. E_NOINTERFACE is returned to the caller of IUnknown::QueryInterface.</summary>
		// Token: 0x04002ADD RID: 10973
		[__DynamicallyInvokable]
		Failed
	}
}
