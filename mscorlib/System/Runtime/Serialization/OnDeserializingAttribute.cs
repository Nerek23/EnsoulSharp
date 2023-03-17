using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	/// <summary>When applied to a method, specifies that the method is called during deserialization of an object in an object graph. The order of deserialization relative to other objects in the graph is non-deterministic.</summary>
	// Token: 0x0200070F RID: 1807
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class OnDeserializingAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Serialization.OnDeserializingAttribute" /> class.</summary>
		// Token: 0x060050AF RID: 20655 RVA: 0x0011B38F File Offset: 0x0011958F
		[__DynamicallyInvokable]
		public OnDeserializingAttribute()
		{
		}
	}
}
