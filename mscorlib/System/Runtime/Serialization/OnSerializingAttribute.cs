using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	/// <summary>When applied to a method, specifies that the method is during serialization of an object in an object graph. The order of serialization relative to other objects in the graph is non-deterministic.</summary>
	// Token: 0x0200070D RID: 1805
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class OnSerializingAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Serialization.OnSerializingAttribute" /> class.</summary>
		// Token: 0x060050AD RID: 20653 RVA: 0x0011B37F File Offset: 0x0011957F
		[__DynamicallyInvokable]
		public OnSerializingAttribute()
		{
		}
	}
}
