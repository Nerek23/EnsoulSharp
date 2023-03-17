using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	/// <summary>When applied to an array parameter in a Windows Runtime component, specifies that the contents of an array that is passed to that parameter are used only for output. The caller does not guarantee that the contents are initialized, and the called method should not read the contents.</summary>
	// Token: 0x0200099D RID: 2461
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	public sealed class WriteOnlyArrayAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.WindowsRuntime.WriteOnlyArrayAttribute" /> class.</summary>
		// Token: 0x060062AD RID: 25261 RVA: 0x0014FE07 File Offset: 0x0014E007
		[__DynamicallyInvokable]
		public WriteOnlyArrayAttribute()
		{
		}
	}
}
