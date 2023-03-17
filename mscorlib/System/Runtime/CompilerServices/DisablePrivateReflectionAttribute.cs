using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Indicates that any private members contained in an assembly's types are not available to reflection.</summary>
	// Token: 0x02000885 RID: 2181
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class DisablePrivateReflectionAttribute : Attribute
	{
		/// <summary>Initializes a new instances of the <see cref="T:System.Runtime.CompilerServices.DisablePrivateReflectionAttribute" /> class.</summary>
		// Token: 0x06005C87 RID: 23687 RVA: 0x00144C4C File Offset: 0x00142E4C
		[__DynamicallyInvokable]
		public DisablePrivateReflectionAttribute()
		{
		}
	}
}
