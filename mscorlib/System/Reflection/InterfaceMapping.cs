using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Retrieves the mapping of an interface into the actual methods on a class that implements that interface.</summary>
	// Token: 0x020005C1 RID: 1473
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public struct InterfaceMapping
	{
		/// <summary>Represents the type that was used to create the interface mapping.</summary>
		// Token: 0x04001C14 RID: 7188
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public Type TargetType;

		/// <summary>Shows the type that represents the interface.</summary>
		// Token: 0x04001C15 RID: 7189
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public Type InterfaceType;

		/// <summary>Shows the methods that implement the interface.</summary>
		// Token: 0x04001C16 RID: 7190
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public MethodInfo[] TargetMethods;

		/// <summary>Shows the methods that are defined on the interface.</summary>
		// Token: 0x04001C17 RID: 7191
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public MethodInfo[] InterfaceMethods;
	}
}
