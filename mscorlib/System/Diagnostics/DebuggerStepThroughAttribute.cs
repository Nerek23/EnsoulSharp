using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	/// <summary>Instructs the debugger to step through the code instead of stepping into the code. This class cannot be inherited.</summary>
	// Token: 0x020003BA RID: 954
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DebuggerStepThroughAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerStepThroughAttribute" /> class.</summary>
		// Token: 0x060031E6 RID: 12774 RVA: 0x000C011E File Offset: 0x000BE31E
		[__DynamicallyInvokable]
		public DebuggerStepThroughAttribute()
		{
		}
	}
}
