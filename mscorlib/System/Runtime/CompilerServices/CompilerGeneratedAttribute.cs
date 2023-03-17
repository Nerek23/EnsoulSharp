using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Distinguishes a compiler-generated element from a user-generated element. This class cannot be inherited.</summary>
	// Token: 0x02000880 RID: 2176
	[AttributeUsage(AttributeTargets.All, Inherited = true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class CompilerGeneratedAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.CompilerGeneratedAttribute" /> class.</summary>
		// Token: 0x06005C7B RID: 23675 RVA: 0x001448FE File Offset: 0x00142AFE
		[__DynamicallyInvokable]
		public CompilerGeneratedAttribute()
		{
		}
	}
}
