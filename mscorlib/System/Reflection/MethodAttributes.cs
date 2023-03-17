using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies flags for method attributes. These flags are defined in the corhdr.h file.</summary>
	// Token: 0x020005D7 RID: 1495
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum MethodAttributes
	{
		/// <summary>Retrieves accessibility information.</summary>
		// Token: 0x04001CAD RID: 7341
		[__DynamicallyInvokable]
		MemberAccessMask = 7,
		/// <summary>Indicates that the member cannot be referenced.</summary>
		// Token: 0x04001CAE RID: 7342
		[__DynamicallyInvokable]
		PrivateScope = 0,
		/// <summary>Indicates that the method is accessible only to the current class.</summary>
		// Token: 0x04001CAF RID: 7343
		[__DynamicallyInvokable]
		Private = 1,
		/// <summary>Indicates that the method is accessible to members of this type and its derived types that are in this assembly only.</summary>
		// Token: 0x04001CB0 RID: 7344
		[__DynamicallyInvokable]
		FamANDAssem = 2,
		/// <summary>Indicates that the method is accessible to any class of this assembly.</summary>
		// Token: 0x04001CB1 RID: 7345
		[__DynamicallyInvokable]
		Assembly = 3,
		/// <summary>Indicates that the method is accessible only to members of this class and its derived classes.</summary>
		// Token: 0x04001CB2 RID: 7346
		[__DynamicallyInvokable]
		Family = 4,
		/// <summary>Indicates that the method is accessible to derived classes anywhere, as well as to any class in the assembly.</summary>
		// Token: 0x04001CB3 RID: 7347
		[__DynamicallyInvokable]
		FamORAssem = 5,
		/// <summary>Indicates that the method is accessible to any object for which this object is in scope.</summary>
		// Token: 0x04001CB4 RID: 7348
		[__DynamicallyInvokable]
		Public = 6,
		/// <summary>Indicates that the method is defined on the type; otherwise, it is defined per instance.</summary>
		// Token: 0x04001CB5 RID: 7349
		[__DynamicallyInvokable]
		Static = 16,
		/// <summary>Indicates that the method cannot be overridden.</summary>
		// Token: 0x04001CB6 RID: 7350
		[__DynamicallyInvokable]
		Final = 32,
		/// <summary>Indicates that the method is virtual.</summary>
		// Token: 0x04001CB7 RID: 7351
		[__DynamicallyInvokable]
		Virtual = 64,
		/// <summary>Indicates that the method hides by name and signature; otherwise, by name only.</summary>
		// Token: 0x04001CB8 RID: 7352
		[__DynamicallyInvokable]
		HideBySig = 128,
		/// <summary>Indicates that the method can only be overridden when it is also accessible.</summary>
		// Token: 0x04001CB9 RID: 7353
		[__DynamicallyInvokable]
		CheckAccessOnOverride = 512,
		/// <summary>Retrieves vtable attributes.</summary>
		// Token: 0x04001CBA RID: 7354
		[__DynamicallyInvokable]
		VtableLayoutMask = 256,
		/// <summary>Indicates that the method will reuse an existing slot in the vtable. This is the default behavior.</summary>
		// Token: 0x04001CBB RID: 7355
		[__DynamicallyInvokable]
		ReuseSlot = 0,
		/// <summary>Indicates that the method always gets a new slot in the vtable.</summary>
		// Token: 0x04001CBC RID: 7356
		[__DynamicallyInvokable]
		NewSlot = 256,
		/// <summary>Indicates that the class does not provide an implementation of this method.</summary>
		// Token: 0x04001CBD RID: 7357
		[__DynamicallyInvokable]
		Abstract = 1024,
		/// <summary>Indicates that the method is special. The name describes how this method is special.</summary>
		// Token: 0x04001CBE RID: 7358
		[__DynamicallyInvokable]
		SpecialName = 2048,
		/// <summary>Indicates that the method implementation is forwarded through PInvoke (Platform Invocation Services).</summary>
		// Token: 0x04001CBF RID: 7359
		[__DynamicallyInvokable]
		PinvokeImpl = 8192,
		/// <summary>Indicates that the managed method is exported by thunk to unmanaged code.</summary>
		// Token: 0x04001CC0 RID: 7360
		[__DynamicallyInvokable]
		UnmanagedExport = 8,
		/// <summary>Indicates that the common language runtime checks the name encoding.</summary>
		// Token: 0x04001CC1 RID: 7361
		[__DynamicallyInvokable]
		RTSpecialName = 4096,
		/// <summary>Indicates a reserved flag for runtime use only.</summary>
		// Token: 0x04001CC2 RID: 7362
		ReservedMask = 53248,
		/// <summary>Indicates that the method has security associated with it. Reserved flag for runtime use only.</summary>
		// Token: 0x04001CC3 RID: 7363
		[__DynamicallyInvokable]
		HasSecurity = 16384,
		/// <summary>Indicates that the method calls another method containing security code. Reserved flag for runtime use only.</summary>
		// Token: 0x04001CC4 RID: 7364
		[__DynamicallyInvokable]
		RequireSecObject = 32768
	}
}
