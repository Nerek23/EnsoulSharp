using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Indicates which <see langword="IDispatch" /> implementation to use for a particular class.</summary>
	// Token: 0x020008F2 RID: 2290
	[Obsolete("The IDispatchImplAttribute is deprecated.", false)]
	[ComVisible(true)]
	[Serializable]
	public enum IDispatchImplType
	{
		/// <summary>Specifies that the common language runtime decides which <see langword="IDispatch" /> implementation to use.</summary>
		// Token: 0x040029BC RID: 10684
		SystemDefinedImpl,
		/// <summary>Specifies that the <see langword="IDispatch" /> implementation is supplied by the runtime.</summary>
		// Token: 0x040029BD RID: 10685
		InternalImpl,
		/// <summary>Specifies that the <see langword="IDispatch" /> implementation is supplied by passing the type information for the object to the COM <see langword="CreateStdDispatch" /> API method.</summary>
		// Token: 0x040029BE RID: 10686
		CompatibleImpl
	}
}
