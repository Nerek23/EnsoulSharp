using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	/// <summary>When applied to an array parameter in a Windows Runtime component, specifies that the contents of the array that is passed to that parameter are used only for input. The caller expects the array to be unchanged by the call.</summary>
	// Token: 0x0200099C RID: 2460
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	public sealed class ReadOnlyArrayAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.WindowsRuntime.ReadOnlyArrayAttribute" /> class.</summary>
		// Token: 0x060062AC RID: 25260 RVA: 0x0014FDFF File Offset: 0x0014DFFF
		[__DynamicallyInvokable]
		public ReadOnlyArrayAttribute()
		{
		}
	}
}
