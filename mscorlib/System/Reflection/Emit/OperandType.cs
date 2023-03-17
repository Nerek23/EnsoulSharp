using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Describes the operand type of Microsoft intermediate language (MSIL) instruction.</summary>
	// Token: 0x0200062C RID: 1580
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum OperandType
	{
		/// <summary>The operand is a 32-bit integer branch target.</summary>
		// Token: 0x040020B3 RID: 8371
		[__DynamicallyInvokable]
		InlineBrTarget,
		/// <summary>The operand is a 32-bit metadata token.</summary>
		// Token: 0x040020B4 RID: 8372
		[__DynamicallyInvokable]
		InlineField,
		/// <summary>The operand is a 32-bit integer.</summary>
		// Token: 0x040020B5 RID: 8373
		[__DynamicallyInvokable]
		InlineI,
		/// <summary>The operand is a 64-bit integer.</summary>
		// Token: 0x040020B6 RID: 8374
		[__DynamicallyInvokable]
		InlineI8,
		/// <summary>The operand is a 32-bit metadata token.</summary>
		// Token: 0x040020B7 RID: 8375
		[__DynamicallyInvokable]
		InlineMethod,
		/// <summary>No operand.</summary>
		// Token: 0x040020B8 RID: 8376
		[__DynamicallyInvokable]
		InlineNone,
		/// <summary>The operand is reserved and should not be used.</summary>
		// Token: 0x040020B9 RID: 8377
		[Obsolete("This API has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		InlinePhi,
		/// <summary>The operand is a 64-bit IEEE floating point number.</summary>
		// Token: 0x040020BA RID: 8378
		[__DynamicallyInvokable]
		InlineR,
		/// <summary>The operand is a 32-bit metadata signature token.</summary>
		// Token: 0x040020BB RID: 8379
		[__DynamicallyInvokable]
		InlineSig = 9,
		/// <summary>The operand is a 32-bit metadata string token.</summary>
		// Token: 0x040020BC RID: 8380
		[__DynamicallyInvokable]
		InlineString,
		/// <summary>The operand is the 32-bit integer argument to a switch instruction.</summary>
		// Token: 0x040020BD RID: 8381
		[__DynamicallyInvokable]
		InlineSwitch,
		/// <summary>The operand is a <see langword="FieldRef" />, <see langword="MethodRef" />, or <see langword="TypeRef" /> token.</summary>
		// Token: 0x040020BE RID: 8382
		[__DynamicallyInvokable]
		InlineTok,
		/// <summary>The operand is a 32-bit metadata token.</summary>
		// Token: 0x040020BF RID: 8383
		[__DynamicallyInvokable]
		InlineType,
		/// <summary>The operand is 16-bit integer containing the ordinal of a local variable or an argument.</summary>
		// Token: 0x040020C0 RID: 8384
		[__DynamicallyInvokable]
		InlineVar,
		/// <summary>The operand is an 8-bit integer branch target.</summary>
		// Token: 0x040020C1 RID: 8385
		[__DynamicallyInvokable]
		ShortInlineBrTarget,
		/// <summary>The operand is an 8-bit integer.</summary>
		// Token: 0x040020C2 RID: 8386
		[__DynamicallyInvokable]
		ShortInlineI,
		/// <summary>The operand is a 32-bit IEEE floating point number.</summary>
		// Token: 0x040020C3 RID: 8387
		[__DynamicallyInvokable]
		ShortInlineR,
		/// <summary>The operand is an 8-bit integer containing the ordinal of a local variable or an argumenta.</summary>
		// Token: 0x040020C4 RID: 8388
		[__DynamicallyInvokable]
		ShortInlineVar
	}
}
