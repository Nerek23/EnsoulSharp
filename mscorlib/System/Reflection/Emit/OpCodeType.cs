using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Describes the types of the Microsoft intermediate language (MSIL) instructions.</summary>
	// Token: 0x0200062A RID: 1578
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum OpCodeType
	{
		/// <summary>This enumerator value is reserved and should not be used.</summary>
		// Token: 0x0400208E RID: 8334
		[Obsolete("This API has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		Annotation,
		/// <summary>These are Microsoft intermediate language (MSIL) instructions that are used as a synonym for other MSIL instructions. For example, <see langword="ldarg.0" /> represents the <see langword="ldarg" /> instruction with an argument of 0.</summary>
		// Token: 0x0400208F RID: 8335
		[__DynamicallyInvokable]
		Macro,
		/// <summary>Describes a reserved Microsoft intermediate language (MSIL) instruction.</summary>
		// Token: 0x04002090 RID: 8336
		[__DynamicallyInvokable]
		Nternal,
		/// <summary>Describes a Microsoft intermediate language (MSIL) instruction that applies to objects.</summary>
		// Token: 0x04002091 RID: 8337
		[__DynamicallyInvokable]
		Objmodel,
		/// <summary>Describes a prefix instruction that modifies the behavior of the following instruction.</summary>
		// Token: 0x04002092 RID: 8338
		[__DynamicallyInvokable]
		Prefix,
		/// <summary>Describes a built-in instruction.</summary>
		// Token: 0x04002093 RID: 8339
		[__DynamicallyInvokable]
		Primitive
	}
}
