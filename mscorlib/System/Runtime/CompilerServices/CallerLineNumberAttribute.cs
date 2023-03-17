using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Allows you to obtain the line number in the source file at which the method is called.</summary>
	// Token: 0x020008BB RID: 2235
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class CallerLineNumberAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.CallerLineNumberAttribute" /> class.</summary>
		// Token: 0x06005CE5 RID: 23781 RVA: 0x00145A85 File Offset: 0x00143C85
		[__DynamicallyInvokable]
		public CallerLineNumberAttribute()
		{
		}
	}
}
