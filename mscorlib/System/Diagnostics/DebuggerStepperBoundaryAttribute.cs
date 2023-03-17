using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	/// <summary>Indicates the code following the attribute is to be executed in run, not step, mode.</summary>
	// Token: 0x020003BB RID: 955
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class DebuggerStepperBoundaryAttribute : Attribute
	{
	}
}
