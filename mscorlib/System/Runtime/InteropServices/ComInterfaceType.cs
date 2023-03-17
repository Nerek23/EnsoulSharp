using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Identifies how to expose an interface to COM.</summary>
	// Token: 0x020008E6 RID: 2278
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum ComInterfaceType
	{
		/// <summary>Indicates that the interface is exposed to COM as a dual interface, which enables both early and late binding. <see cref="F:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsDual" /> is the default value.</summary>
		// Token: 0x040029AB RID: 10667
		[__DynamicallyInvokable]
		InterfaceIsDual,
		/// <summary>Indicates that an interface is exposed to COM as an interface that is derived from IUnknown, which enables only early binding.</summary>
		// Token: 0x040029AC RID: 10668
		[__DynamicallyInvokable]
		InterfaceIsIUnknown,
		/// <summary>Indicates that an interface is exposed to COM as a dispinterface, which enables late binding only.</summary>
		// Token: 0x040029AD RID: 10669
		[__DynamicallyInvokable]
		InterfaceIsIDispatch,
		/// <summary>Indicates that an interface is exposed to COM as a Windows Runtime interface.</summary>
		// Token: 0x040029AE RID: 10670
		[ComVisible(false)]
		[__DynamicallyInvokable]
		InterfaceIsIInspectable
	}
}
