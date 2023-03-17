using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Allows you to obtain the method or property name of the caller to the method.</summary>
	// Token: 0x020008BC RID: 2236
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class CallerMemberNameAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.CallerMemberNameAttribute" /> class.</summary>
		// Token: 0x06005CE6 RID: 23782 RVA: 0x00145A8D File Offset: 0x00143C8D
		[__DynamicallyInvokable]
		public CallerMemberNameAttribute()
		{
		}
	}
}
