using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	/// <summary>When applied to a method, specifies that the method is called after serialization of an object in an object graph. The order of serialization relative to other objects in the graph is non-deterministic.</summary>
	// Token: 0x0200070E RID: 1806
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class OnSerializedAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Serialization.OnSerializedAttribute" /> class.</summary>
		// Token: 0x060050AE RID: 20654 RVA: 0x0011B387 File Offset: 0x00119587
		[__DynamicallyInvokable]
		public OnSerializedAttribute()
		{
		}
	}
}
