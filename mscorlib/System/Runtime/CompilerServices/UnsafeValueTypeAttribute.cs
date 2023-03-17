using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Specifies that a type contains an unmanaged array that might potentially overflow. This class cannot be inherited.</summary>
	// Token: 0x02000894 RID: 2196
	[AttributeUsage(AttributeTargets.Struct)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class UnsafeValueTypeAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.UnsafeValueTypeAttribute" /> class.</summary>
		// Token: 0x06005C9D RID: 23709 RVA: 0x00144D50 File Offset: 0x00142F50
		[__DynamicallyInvokable]
		public UnsafeValueTypeAttribute()
		{
		}
	}
}
