using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Indicates that a method is an extension method, or that a class or assembly contains extension methods.</summary>
	// Token: 0x02000889 RID: 2185
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
	[__DynamicallyInvokable]
	public sealed class ExtensionAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.ExtensionAttribute" /> class.</summary>
		// Token: 0x06005C8C RID: 23692 RVA: 0x00144C82 File Offset: 0x00142E82
		[__DynamicallyInvokable]
		public ExtensionAttribute()
		{
		}
	}
}
