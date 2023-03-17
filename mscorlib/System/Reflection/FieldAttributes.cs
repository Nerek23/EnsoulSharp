using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies flags that describe the attributes of a field.</summary>
	// Token: 0x020005B7 RID: 1463
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum FieldAttributes
	{
		/// <summary>Specifies the access level of a given field.</summary>
		// Token: 0x04001BEA RID: 7146
		[__DynamicallyInvokable]
		FieldAccessMask = 7,
		/// <summary>Specifies that the field cannot be referenced.</summary>
		// Token: 0x04001BEB RID: 7147
		[__DynamicallyInvokable]
		PrivateScope = 0,
		/// <summary>Specifies that the field is accessible only by the parent type.</summary>
		// Token: 0x04001BEC RID: 7148
		[__DynamicallyInvokable]
		Private = 1,
		/// <summary>Specifies that the field is accessible only by subtypes in this assembly.</summary>
		// Token: 0x04001BED RID: 7149
		[__DynamicallyInvokable]
		FamANDAssem = 2,
		/// <summary>Specifies that the field is accessible throughout the assembly.</summary>
		// Token: 0x04001BEE RID: 7150
		[__DynamicallyInvokable]
		Assembly = 3,
		/// <summary>Specifies that the field is accessible only by type and subtypes.</summary>
		// Token: 0x04001BEF RID: 7151
		[__DynamicallyInvokable]
		Family = 4,
		/// <summary>Specifies that the field is accessible by subtypes anywhere, as well as throughout this assembly.</summary>
		// Token: 0x04001BF0 RID: 7152
		[__DynamicallyInvokable]
		FamORAssem = 5,
		/// <summary>Specifies that the field is accessible by any member for whom this scope is visible.</summary>
		// Token: 0x04001BF1 RID: 7153
		[__DynamicallyInvokable]
		Public = 6,
		/// <summary>Specifies that the field represents the defined type, or else it is per-instance.</summary>
		// Token: 0x04001BF2 RID: 7154
		[__DynamicallyInvokable]
		Static = 16,
		/// <summary>Specifies that the field is initialized only, and can be set only in the body of a constructor.</summary>
		// Token: 0x04001BF3 RID: 7155
		[__DynamicallyInvokable]
		InitOnly = 32,
		/// <summary>Specifies that the field's value is a compile-time (static or early bound) constant. Any attempt to set it throws a <see cref="T:System.FieldAccessException" />.</summary>
		// Token: 0x04001BF4 RID: 7156
		[__DynamicallyInvokable]
		Literal = 64,
		/// <summary>Specifies that the field does not have to be serialized when the type is remoted.</summary>
		// Token: 0x04001BF5 RID: 7157
		[__DynamicallyInvokable]
		NotSerialized = 128,
		/// <summary>Specifies a special method, with the name describing how the method is special.</summary>
		// Token: 0x04001BF6 RID: 7158
		[__DynamicallyInvokable]
		SpecialName = 512,
		/// <summary>Reserved for future use.</summary>
		// Token: 0x04001BF7 RID: 7159
		[__DynamicallyInvokable]
		PinvokeImpl = 8192,
		/// <summary>Reserved.</summary>
		// Token: 0x04001BF8 RID: 7160
		ReservedMask = 38144,
		/// <summary>Specifies that the common language runtime (metadata internal APIs) should check the name encoding.</summary>
		// Token: 0x04001BF9 RID: 7161
		[__DynamicallyInvokable]
		RTSpecialName = 1024,
		/// <summary>Specifies that the field has marshaling information.</summary>
		// Token: 0x04001BFA RID: 7162
		[__DynamicallyInvokable]
		HasFieldMarshal = 4096,
		/// <summary>Specifies that the field has a default value.</summary>
		// Token: 0x04001BFB RID: 7163
		[__DynamicallyInvokable]
		HasDefault = 32768,
		/// <summary>Specifies that the field has a relative virtual address (RVA). The RVA is the location of the method body in the current image, as an address relative to the start of the image file in which it is located.</summary>
		// Token: 0x04001BFC RID: 7164
		[__DynamicallyInvokable]
		HasFieldRVA = 256
	}
}
