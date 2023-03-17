using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Marks a method as one way, without a return value and <see langword="out" /> or <see langword="ref" /> parameters.</summary>
	// Token: 0x0200084C RID: 2124
	[AttributeUsage(AttributeTargets.Method)]
	[ComVisible(true)]
	public class OneWayAttribute : Attribute
	{
	}
}
