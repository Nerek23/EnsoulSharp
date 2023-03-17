using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	/// <summary>Enables classes to be activated by the Windows Runtime.</summary>
	// Token: 0x020009B5 RID: 2485
	[Guid("00000035-0000-0000-C000-000000000046")]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IActivationFactory
	{
		/// <summary>Returns a new instance of the Windows Runtime class that is created by the <see cref="T:System.Runtime.InteropServices.WindowsRuntime.IActivationFactory" /> interface.</summary>
		/// <returns>The new instance of the Windows Runtime class.</returns>
		// Token: 0x06006365 RID: 25445
		[__DynamicallyInvokable]
		object ActivateInstance();
	}
}
