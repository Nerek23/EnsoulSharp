using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>Specifies a property should be ignored when writing an event type with the <see cref="M:System.Diagnostics.Tracing.EventSource.Write``1(System.String,System.Diagnostics.Tracing.EventSourceOptions@,``0@)" /> method.</summary>
	// Token: 0x02000418 RID: 1048
	[AttributeUsage(AttributeTargets.Property)]
	[__DynamicallyInvokable]
	public class EventIgnoreAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Tracing.EventIgnoreAttribute" /> class.</summary>
		// Token: 0x060034EC RID: 13548 RVA: 0x000CDA29 File Offset: 0x000CBC29
		[__DynamicallyInvokable]
		public EventIgnoreAttribute()
		{
		}
	}
}
