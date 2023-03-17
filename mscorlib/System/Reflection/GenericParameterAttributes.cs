using System;

namespace System.Reflection
{
	/// <summary>Describes the constraints on a generic type parameter of a generic type or method.</summary>
	// Token: 0x020005BC RID: 1468
	[Flags]
	[__DynamicallyInvokable]
	public enum GenericParameterAttributes
	{
		/// <summary>There are no special flags.</summary>
		// Token: 0x04001C0B RID: 7179
		[__DynamicallyInvokable]
		None = 0,
		/// <summary>Selects the combination of all variance flags. This value is the result of using logical OR to combine the following flags: <see cref="F:System.Reflection.GenericParameterAttributes.Contravariant" /> and <see cref="F:System.Reflection.GenericParameterAttributes.Covariant" />.</summary>
		// Token: 0x04001C0C RID: 7180
		[__DynamicallyInvokable]
		VarianceMask = 3,
		/// <summary>The generic type parameter is covariant. A covariant type parameter can appear as the result type of a method, the type of a read-only field, a declared base type, or an implemented interface.</summary>
		// Token: 0x04001C0D RID: 7181
		[__DynamicallyInvokable]
		Covariant = 1,
		/// <summary>The generic type parameter is contravariant. A contravariant type parameter can appear as a parameter type in method signatures.</summary>
		// Token: 0x04001C0E RID: 7182
		[__DynamicallyInvokable]
		Contravariant = 2,
		/// <summary>Selects the combination of all special constraint flags. This value is the result of using logical OR to combine the following flags: <see cref="F:System.Reflection.GenericParameterAttributes.DefaultConstructorConstraint" />, <see cref="F:System.Reflection.GenericParameterAttributes.ReferenceTypeConstraint" />, and <see cref="F:System.Reflection.GenericParameterAttributes.NotNullableValueTypeConstraint" />.</summary>
		// Token: 0x04001C0F RID: 7183
		[__DynamicallyInvokable]
		SpecialConstraintMask = 28,
		/// <summary>A type can be substituted for the generic type parameter only if it is a reference type.</summary>
		// Token: 0x04001C10 RID: 7184
		[__DynamicallyInvokable]
		ReferenceTypeConstraint = 4,
		/// <summary>A type can be substituted for the generic type parameter only if it is a value type and is not nullable.</summary>
		// Token: 0x04001C11 RID: 7185
		[__DynamicallyInvokable]
		NotNullableValueTypeConstraint = 8,
		/// <summary>A type can be substituted for the generic type parameter only if it has a parameterless constructor.</summary>
		// Token: 0x04001C12 RID: 7186
		[__DynamicallyInvokable]
		DefaultConstructorConstraint = 16
	}
}
