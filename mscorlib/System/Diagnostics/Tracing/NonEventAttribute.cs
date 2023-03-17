using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>Identifies a method that is not generating an event.</summary>
	// Token: 0x020003FB RID: 1019
	[AttributeUsage(AttributeTargets.Method)]
	[__DynamicallyInvokable]
	public sealed class NonEventAttribute : Attribute
	{
		/// <summary>Creates a new instance of the <see cref="T:System.Diagnostics.Tracing.NonEventAttribute" /> class.</summary>
		// Token: 0x06003425 RID: 13349 RVA: 0x000C9C9E File Offset: 0x000C7E9E
		[__DynamicallyInvokable]
		public NonEventAttribute()
		{
		}
	}
}
