using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies flags for the attributes of a method implementation.</summary>
	// Token: 0x020005DA RID: 1498
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum MethodImplAttributes
	{
		/// <summary>Specifies flags about code type.</summary>
		// Token: 0x04001CD4 RID: 7380
		[__DynamicallyInvokable]
		CodeTypeMask = 3,
		/// <summary>Specifies that the method implementation is in Microsoft intermediate language (MSIL).</summary>
		// Token: 0x04001CD5 RID: 7381
		[__DynamicallyInvokable]
		IL = 0,
		/// <summary>Specifies that the method implementation is native.</summary>
		// Token: 0x04001CD6 RID: 7382
		[__DynamicallyInvokable]
		Native,
		/// <summary>Specifies that the method implementation is in Optimized Intermediate Language (OPTIL).</summary>
		// Token: 0x04001CD7 RID: 7383
		[__DynamicallyInvokable]
		OPTIL,
		/// <summary>Specifies that the method implementation is provided by the runtime.</summary>
		// Token: 0x04001CD8 RID: 7384
		[__DynamicallyInvokable]
		Runtime,
		/// <summary>Specifies whether the method is implemented in managed or unmanaged code.</summary>
		// Token: 0x04001CD9 RID: 7385
		[__DynamicallyInvokable]
		ManagedMask,
		/// <summary>Specifies that the method is implemented in unmanaged code.</summary>
		// Token: 0x04001CDA RID: 7386
		[__DynamicallyInvokable]
		Unmanaged = 4,
		/// <summary>Specifies that the method is implemented in managed code.</summary>
		// Token: 0x04001CDB RID: 7387
		[__DynamicallyInvokable]
		Managed = 0,
		/// <summary>Specifies that the method is not defined.</summary>
		// Token: 0x04001CDC RID: 7388
		[__DynamicallyInvokable]
		ForwardRef = 16,
		/// <summary>Specifies that the method signature is exported exactly as declared.</summary>
		// Token: 0x04001CDD RID: 7389
		[__DynamicallyInvokable]
		PreserveSig = 128,
		/// <summary>Specifies an internal call.</summary>
		// Token: 0x04001CDE RID: 7390
		[__DynamicallyInvokable]
		InternalCall = 4096,
		/// <summary>Specifies that the method is single-threaded through the body. Static methods (<see langword="Shared" /> in Visual Basic) lock on the type, whereas instance methods lock on the instance. You can also use the C# lock statement or the Visual Basic SyncLock statement for this purpose.</summary>
		// Token: 0x04001CDF RID: 7391
		[__DynamicallyInvokable]
		Synchronized = 32,
		/// <summary>Specifies that the method cannot be inlined.</summary>
		// Token: 0x04001CE0 RID: 7392
		[__DynamicallyInvokable]
		NoInlining = 8,
		/// <summary>Specifies that the method should be inlined wherever possible.</summary>
		// Token: 0x04001CE1 RID: 7393
		[ComVisible(false)]
		[__DynamicallyInvokable]
		AggressiveInlining = 256,
		/// <summary>Specifies that the method is not optimized by the just-in-time (JIT) compiler or by native code generation (see Ngen.exe) when debugging possible code generation problems.</summary>
		// Token: 0x04001CE2 RID: 7394
		[__DynamicallyInvokable]
		NoOptimization = 64,
		/// <summary>Specifies that the JIT compiler should look for security mitigation attributes, such as the user-defined <see langword="System.Runtime.CompilerServices.SecurityMitigationsAttribute" />. If found, the JIT compiler applies any related security mitigations. Available starting with .NET Framework 4.8.</summary>
		// Token: 0x04001CE3 RID: 7395
		SecurityMitigations = 1024,
		/// <summary>Specifies a range check value.</summary>
		// Token: 0x04001CE4 RID: 7396
		MaxMethodImplVal = 65535
	}
}
