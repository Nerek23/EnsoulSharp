using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Allows an unmanaged method to call a managed method.</summary>
	// Token: 0x020008E4 RID: 2276
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public sealed class AllowReversePInvokeCallsAttribute : Attribute
	{
	}
}
