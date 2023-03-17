using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Fixes the address of a static value type field throughout its lifetime. This class cannot be inherited.</summary>
	// Token: 0x02000893 RID: 2195
	[AttributeUsage(AttributeTargets.Field)]
	[Serializable]
	public sealed class FixedAddressValueTypeAttribute : Attribute
	{
	}
}
