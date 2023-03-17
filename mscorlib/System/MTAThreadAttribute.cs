using System;
using System.Runtime.InteropServices;

namespace System
{
	/// <summary>Indicates that the COM threading model for an application is multithreaded apartment (MTA).</summary>
	// Token: 0x02000141 RID: 321
	[AttributeUsage(AttributeTargets.Method)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class MTAThreadAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.MTAThreadAttribute" /> class.</summary>
		// Token: 0x06001340 RID: 4928 RVA: 0x0003873A File Offset: 0x0003693A
		[__DynamicallyInvokable]
		public MTAThreadAttribute()
		{
		}
	}
}
