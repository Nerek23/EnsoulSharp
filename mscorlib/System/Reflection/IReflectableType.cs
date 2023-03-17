using System;

namespace System.Reflection
{
	/// <summary>Represents a type that you can reflect over.</summary>
	// Token: 0x020005BE RID: 1470
	[__DynamicallyInvokable]
	public interface IReflectableType
	{
		/// <summary>Retrieves an object that represents this type.</summary>
		/// <returns>An object that represents this type.</returns>
		// Token: 0x06004532 RID: 17714
		[__DynamicallyInvokable]
		TypeInfo GetTypeInfo();
	}
}
