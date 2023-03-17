using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Describes how values are pushed onto a stack or popped off a stack.</summary>
	// Token: 0x0200062B RID: 1579
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum StackBehaviour
	{
		/// <summary>No values are popped off the stack.</summary>
		// Token: 0x04002095 RID: 8341
		[__DynamicallyInvokable]
		Pop0,
		/// <summary>Pops one value off the stack.</summary>
		// Token: 0x04002096 RID: 8342
		[__DynamicallyInvokable]
		Pop1,
		/// <summary>Pops 1 value off the stack for the first operand, and 1 value of the stack for the second operand.</summary>
		// Token: 0x04002097 RID: 8343
		[__DynamicallyInvokable]
		Pop1_pop1,
		/// <summary>Pops a 32-bit integer off the stack.</summary>
		// Token: 0x04002098 RID: 8344
		[__DynamicallyInvokable]
		Popi,
		/// <summary>Pops a 32-bit integer off the stack for the first operand, and a value off the stack for the second operand.</summary>
		// Token: 0x04002099 RID: 8345
		[__DynamicallyInvokable]
		Popi_pop1,
		/// <summary>Pops a 32-bit integer off the stack for the first operand, and a 32-bit integer off the stack for the second operand.</summary>
		// Token: 0x0400209A RID: 8346
		[__DynamicallyInvokable]
		Popi_popi,
		/// <summary>Pops a 32-bit integer off the stack for the first operand, and a 64-bit integer off the stack for the second operand.</summary>
		// Token: 0x0400209B RID: 8347
		[__DynamicallyInvokable]
		Popi_popi8,
		/// <summary>Pops a 32-bit integer off the stack for the first operand, a 32-bit integer off the stack for the second operand, and a 32-bit integer off the stack for the third operand.</summary>
		// Token: 0x0400209C RID: 8348
		[__DynamicallyInvokable]
		Popi_popi_popi,
		/// <summary>Pops a 32-bit integer off the stack for the first operand, and a 32-bit floating point number off the stack for the second operand.</summary>
		// Token: 0x0400209D RID: 8349
		[__DynamicallyInvokable]
		Popi_popr4,
		/// <summary>Pops a 32-bit integer off the stack for the first operand, and a 64-bit floating point number off the stack for the second operand.</summary>
		// Token: 0x0400209E RID: 8350
		[__DynamicallyInvokable]
		Popi_popr8,
		/// <summary>Pops a reference off the stack.</summary>
		// Token: 0x0400209F RID: 8351
		[__DynamicallyInvokable]
		Popref,
		/// <summary>Pops a reference off the stack for the first operand, and a value off the stack for the second operand.</summary>
		// Token: 0x040020A0 RID: 8352
		[__DynamicallyInvokable]
		Popref_pop1,
		/// <summary>Pops a reference off the stack for the first operand, and a 32-bit integer off the stack for the second operand.</summary>
		// Token: 0x040020A1 RID: 8353
		[__DynamicallyInvokable]
		Popref_popi,
		/// <summary>Pops a reference off the stack for the first operand, a value off the stack for the second operand, and a value off the stack for the third operand.</summary>
		// Token: 0x040020A2 RID: 8354
		[__DynamicallyInvokable]
		Popref_popi_popi,
		/// <summary>Pops a reference off the stack for the first operand, a value off the stack for the second operand, and a 64-bit integer off the stack for the third operand.</summary>
		// Token: 0x040020A3 RID: 8355
		[__DynamicallyInvokable]
		Popref_popi_popi8,
		/// <summary>Pops a reference off the stack for the first operand, a value off the stack for the second operand, and a 32-bit integer off the stack for the third operand.</summary>
		// Token: 0x040020A4 RID: 8356
		[__DynamicallyInvokable]
		Popref_popi_popr4,
		/// <summary>Pops a reference off the stack for the first operand, a value off the stack for the second operand, and a 64-bit floating point number off the stack for the third operand.</summary>
		// Token: 0x040020A5 RID: 8357
		[__DynamicallyInvokable]
		Popref_popi_popr8,
		/// <summary>Pops a reference off the stack for the first operand, a value off the stack for the second operand, and a reference off the stack for the third operand.</summary>
		// Token: 0x040020A6 RID: 8358
		[__DynamicallyInvokable]
		Popref_popi_popref,
		/// <summary>No values are pushed onto the stack.</summary>
		// Token: 0x040020A7 RID: 8359
		[__DynamicallyInvokable]
		Push0,
		/// <summary>Pushes one value onto the stack.</summary>
		// Token: 0x040020A8 RID: 8360
		[__DynamicallyInvokable]
		Push1,
		/// <summary>Pushes 1 value onto the stack for the first operand, and 1 value onto the stack for the second operand.</summary>
		// Token: 0x040020A9 RID: 8361
		[__DynamicallyInvokable]
		Push1_push1,
		/// <summary>Pushes a 32-bit integer onto the stack.</summary>
		// Token: 0x040020AA RID: 8362
		[__DynamicallyInvokable]
		Pushi,
		/// <summary>Pushes a 64-bit integer onto the stack.</summary>
		// Token: 0x040020AB RID: 8363
		[__DynamicallyInvokable]
		Pushi8,
		/// <summary>Pushes a 32-bit floating point number onto the stack.</summary>
		// Token: 0x040020AC RID: 8364
		[__DynamicallyInvokable]
		Pushr4,
		/// <summary>Pushes a 64-bit floating point number onto the stack.</summary>
		// Token: 0x040020AD RID: 8365
		[__DynamicallyInvokable]
		Pushr8,
		/// <summary>Pushes a reference onto the stack.</summary>
		// Token: 0x040020AE RID: 8366
		[__DynamicallyInvokable]
		Pushref,
		/// <summary>Pops a variable off the stack.</summary>
		// Token: 0x040020AF RID: 8367
		[__DynamicallyInvokable]
		Varpop,
		/// <summary>Pushes a variable onto the stack.</summary>
		// Token: 0x040020B0 RID: 8368
		[__DynamicallyInvokable]
		Varpush,
		/// <summary>Pops a reference off the stack for the first operand, a value off the stack for the second operand, and a 32-bit integer off the stack for the third operand.</summary>
		// Token: 0x040020B1 RID: 8369
		[__DynamicallyInvokable]
		Popref_popi_pop1
	}
}
