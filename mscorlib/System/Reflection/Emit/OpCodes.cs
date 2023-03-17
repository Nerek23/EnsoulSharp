using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Provides field representations of the Microsoft Intermediate Language (MSIL) instructions for emission by the <see cref="T:System.Reflection.Emit.ILGenerator" /> class members (such as <see cref="M:System.Reflection.Emit.ILGenerator.Emit(System.Reflection.Emit.OpCode)" />).</summary>
	// Token: 0x02000628 RID: 1576
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public class OpCodes
	{
		// Token: 0x06004B83 RID: 19331 RVA: 0x001110A6 File Offset: 0x0010F2A6
		private OpCodes()
		{
		}

		/// <summary>Returns true or false if the supplied opcode takes a single byte argument.</summary>
		/// <param name="inst">An instance of an Opcode object.</param>
		/// <returns>
		///   <see langword="true" /> or <see langword="false" />.</returns>
		// Token: 0x06004B84 RID: 19332 RVA: 0x001110B0 File Offset: 0x0010F2B0
		[__DynamicallyInvokable]
		public static bool TakesSingleByteArgument(OpCode inst)
		{
			OperandType operandType = inst.OperandType;
			return operandType - OperandType.ShortInlineBrTarget <= 1 || operandType == OperandType.ShortInlineVar;
		}

		/// <summary>Fills space if opcodes are patched. No meaningful operation is performed although a processing cycle can be consumed.</summary>
		// Token: 0x04001F93 RID: 8083
		[__DynamicallyInvokable]
		public static readonly OpCode Nop = new OpCode(OpCodeValues.Nop, 6556325);

		/// <summary>Signals the Common Language Infrastructure (CLI) to inform the debugger that a break point has been tripped.</summary>
		// Token: 0x04001F94 RID: 8084
		[__DynamicallyInvokable]
		public static readonly OpCode Break = new OpCode(OpCodeValues.Break, 6556197);

		/// <summary>Loads the argument at index 0 onto the evaluation stack.</summary>
		// Token: 0x04001F95 RID: 8085
		[__DynamicallyInvokable]
		public static readonly OpCode Ldarg_0 = new OpCode(OpCodeValues.Ldarg_0, 275120805);

		/// <summary>Loads the argument at index 1 onto the evaluation stack.</summary>
		// Token: 0x04001F96 RID: 8086
		[__DynamicallyInvokable]
		public static readonly OpCode Ldarg_1 = new OpCode(OpCodeValues.Ldarg_1, 275120805);

		/// <summary>Loads the argument at index 2 onto the evaluation stack.</summary>
		// Token: 0x04001F97 RID: 8087
		[__DynamicallyInvokable]
		public static readonly OpCode Ldarg_2 = new OpCode(OpCodeValues.Ldarg_2, 275120805);

		/// <summary>Loads the argument at index 3 onto the evaluation stack.</summary>
		// Token: 0x04001F98 RID: 8088
		[__DynamicallyInvokable]
		public static readonly OpCode Ldarg_3 = new OpCode(OpCodeValues.Ldarg_3, 275120805);

		/// <summary>Loads the local variable at index 0 onto the evaluation stack.</summary>
		// Token: 0x04001F99 RID: 8089
		[__DynamicallyInvokable]
		public static readonly OpCode Ldloc_0 = new OpCode(OpCodeValues.Ldloc_0, 275120805);

		/// <summary>Loads the local variable at index 1 onto the evaluation stack.</summary>
		// Token: 0x04001F9A RID: 8090
		[__DynamicallyInvokable]
		public static readonly OpCode Ldloc_1 = new OpCode(OpCodeValues.Ldloc_1, 275120805);

		/// <summary>Loads the local variable at index 2 onto the evaluation stack.</summary>
		// Token: 0x04001F9B RID: 8091
		[__DynamicallyInvokable]
		public static readonly OpCode Ldloc_2 = new OpCode(OpCodeValues.Ldloc_2, 275120805);

		/// <summary>Loads the local variable at index 3 onto the evaluation stack.</summary>
		// Token: 0x04001F9C RID: 8092
		[__DynamicallyInvokable]
		public static readonly OpCode Ldloc_3 = new OpCode(OpCodeValues.Ldloc_3, 275120805);

		/// <summary>Pops the current value from the top of the evaluation stack and stores it in a the local variable list at index 0.</summary>
		// Token: 0x04001F9D RID: 8093
		[__DynamicallyInvokable]
		public static readonly OpCode Stloc_0 = new OpCode(OpCodeValues.Stloc_0, -261877083);

		/// <summary>Pops the current value from the top of the evaluation stack and stores it in a the local variable list at index 1.</summary>
		// Token: 0x04001F9E RID: 8094
		[__DynamicallyInvokable]
		public static readonly OpCode Stloc_1 = new OpCode(OpCodeValues.Stloc_1, -261877083);

		/// <summary>Pops the current value from the top of the evaluation stack and stores it in a the local variable list at index 2.</summary>
		// Token: 0x04001F9F RID: 8095
		[__DynamicallyInvokable]
		public static readonly OpCode Stloc_2 = new OpCode(OpCodeValues.Stloc_2, -261877083);

		/// <summary>Pops the current value from the top of the evaluation stack and stores it in a the local variable list at index 3.</summary>
		// Token: 0x04001FA0 RID: 8096
		[__DynamicallyInvokable]
		public static readonly OpCode Stloc_3 = new OpCode(OpCodeValues.Stloc_3, -261877083);

		/// <summary>Loads the argument (referenced by a specified short form index) onto the evaluation stack.</summary>
		// Token: 0x04001FA1 RID: 8097
		[__DynamicallyInvokable]
		public static readonly OpCode Ldarg_S = new OpCode(OpCodeValues.Ldarg_S, 275120818);

		/// <summary>Load an argument address, in short form, onto the evaluation stack.</summary>
		// Token: 0x04001FA2 RID: 8098
		[__DynamicallyInvokable]
		public static readonly OpCode Ldarga_S = new OpCode(OpCodeValues.Ldarga_S, 275382962);

		/// <summary>Stores the value on top of the evaluation stack in the argument slot at a specified index, short form.</summary>
		// Token: 0x04001FA3 RID: 8099
		[__DynamicallyInvokable]
		public static readonly OpCode Starg_S = new OpCode(OpCodeValues.Starg_S, -261877070);

		/// <summary>Loads the local variable at a specific index onto the evaluation stack, short form.</summary>
		// Token: 0x04001FA4 RID: 8100
		[__DynamicallyInvokable]
		public static readonly OpCode Ldloc_S = new OpCode(OpCodeValues.Ldloc_S, 275120818);

		/// <summary>Loads the address of the local variable at a specific index onto the evaluation stack, short form.</summary>
		// Token: 0x04001FA5 RID: 8101
		[__DynamicallyInvokable]
		public static readonly OpCode Ldloca_S = new OpCode(OpCodeValues.Ldloca_S, 275382962);

		/// <summary>Pops the current value from the top of the evaluation stack and stores it in a the local variable list at <paramref name="index" /> (short form).</summary>
		// Token: 0x04001FA6 RID: 8102
		[__DynamicallyInvokable]
		public static readonly OpCode Stloc_S = new OpCode(OpCodeValues.Stloc_S, -261877070);

		/// <summary>Pushes a null reference (type <see langword="O" />) onto the evaluation stack.</summary>
		// Token: 0x04001FA7 RID: 8103
		[__DynamicallyInvokable]
		public static readonly OpCode Ldnull = new OpCode(OpCodeValues.Ldnull, 275909285);

		/// <summary>Pushes the integer value of -1 onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FA8 RID: 8104
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_M1 = new OpCode(OpCodeValues.Ldc_I4_M1, 275382949);

		/// <summary>Pushes the integer value of 0 onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FA9 RID: 8105
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_0 = new OpCode(OpCodeValues.Ldc_I4_0, 275382949);

		/// <summary>Pushes the integer value of 1 onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FAA RID: 8106
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_1 = new OpCode(OpCodeValues.Ldc_I4_1, 275382949);

		/// <summary>Pushes the integer value of 2 onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FAB RID: 8107
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_2 = new OpCode(OpCodeValues.Ldc_I4_2, 275382949);

		/// <summary>Pushes the integer value of 3 onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FAC RID: 8108
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_3 = new OpCode(OpCodeValues.Ldc_I4_3, 275382949);

		/// <summary>Pushes the integer value of 4 onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FAD RID: 8109
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_4 = new OpCode(OpCodeValues.Ldc_I4_4, 275382949);

		/// <summary>Pushes the integer value of 5 onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FAE RID: 8110
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_5 = new OpCode(OpCodeValues.Ldc_I4_5, 275382949);

		/// <summary>Pushes the integer value of 6 onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FAF RID: 8111
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_6 = new OpCode(OpCodeValues.Ldc_I4_6, 275382949);

		/// <summary>Pushes the integer value of 7 onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FB0 RID: 8112
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_7 = new OpCode(OpCodeValues.Ldc_I4_7, 275382949);

		/// <summary>Pushes the integer value of 8 onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FB1 RID: 8113
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_8 = new OpCode(OpCodeValues.Ldc_I4_8, 275382949);

		/// <summary>Pushes the supplied <see langword="int8" /> value onto the evaluation stack as an <see langword="int32" />, short form.</summary>
		// Token: 0x04001FB2 RID: 8114
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4_S = new OpCode(OpCodeValues.Ldc_I4_S, 275382960);

		/// <summary>Pushes a supplied value of type <see langword="int32" /> onto the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04001FB3 RID: 8115
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I4 = new OpCode(OpCodeValues.Ldc_I4, 275384994);

		/// <summary>Pushes a supplied value of type <see langword="int64" /> onto the evaluation stack as an <see langword="int64" />.</summary>
		// Token: 0x04001FB4 RID: 8116
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_I8 = new OpCode(OpCodeValues.Ldc_I8, 275516067);

		/// <summary>Pushes a supplied value of type <see langword="float32" /> onto the evaluation stack as type <see langword="F" /> (float).</summary>
		// Token: 0x04001FB5 RID: 8117
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_R4 = new OpCode(OpCodeValues.Ldc_R4, 275647153);

		/// <summary>Pushes a supplied value of type <see langword="float64" /> onto the evaluation stack as type <see langword="F" /> (float).</summary>
		// Token: 0x04001FB6 RID: 8118
		[__DynamicallyInvokable]
		public static readonly OpCode Ldc_R8 = new OpCode(OpCodeValues.Ldc_R8, 275778215);

		/// <summary>Copies the current topmost value on the evaluation stack, and then pushes the copy onto the evaluation stack.</summary>
		// Token: 0x04001FB7 RID: 8119
		[__DynamicallyInvokable]
		public static readonly OpCode Dup = new OpCode(OpCodeValues.Dup, 275258021);

		/// <summary>Removes the value currently on top of the evaluation stack.</summary>
		// Token: 0x04001FB8 RID: 8120
		[__DynamicallyInvokable]
		public static readonly OpCode Pop = new OpCode(OpCodeValues.Pop, -261875035);

		/// <summary>Exits current method and jumps to specified method.</summary>
		// Token: 0x04001FB9 RID: 8121
		[__DynamicallyInvokable]
		public static readonly OpCode Jmp = new OpCode(OpCodeValues.Jmp, 23333444);

		/// <summary>Calls the method indicated by the passed method descriptor.</summary>
		// Token: 0x04001FBA RID: 8122
		[__DynamicallyInvokable]
		public static readonly OpCode Call = new OpCode(OpCodeValues.Call, 7842372);

		/// <summary>Calls the method indicated on the evaluation stack (as a pointer to an entry point) with arguments described by a calling convention.</summary>
		// Token: 0x04001FBB RID: 8123
		[__DynamicallyInvokable]
		public static readonly OpCode Calli = new OpCode(OpCodeValues.Calli, 7842377);

		/// <summary>Returns from the current method, pushing a return value (if present) from the callee's evaluation stack onto the caller's evaluation stack.</summary>
		// Token: 0x04001FBC RID: 8124
		[__DynamicallyInvokable]
		public static readonly OpCode Ret = new OpCode(OpCodeValues.Ret, 23440101);

		/// <summary>Unconditionally transfers control to a target instruction (short form).</summary>
		// Token: 0x04001FBD RID: 8125
		[__DynamicallyInvokable]
		public static readonly OpCode Br_S = new OpCode(OpCodeValues.Br_S, 23331343);

		/// <summary>Transfers control to a target instruction if <paramref name="value" /> is <see langword="false" />, a null reference, or zero.</summary>
		// Token: 0x04001FBE RID: 8126
		[__DynamicallyInvokable]
		public static readonly OpCode Brfalse_S = new OpCode(OpCodeValues.Brfalse_S, -261868945);

		/// <summary>Transfers control to a target instruction (short form) if <paramref name="value" /> is <see langword="true" />, not null, or non-zero.</summary>
		// Token: 0x04001FBF RID: 8127
		[__DynamicallyInvokable]
		public static readonly OpCode Brtrue_S = new OpCode(OpCodeValues.Brtrue_S, -261868945);

		/// <summary>Transfers control to a target instruction (short form) if two values are equal.</summary>
		// Token: 0x04001FC0 RID: 8128
		[__DynamicallyInvokable]
		public static readonly OpCode Beq_S = new OpCode(OpCodeValues.Beq_S, -530308497);

		/// <summary>Transfers control to a target instruction (short form) if the first value is greater than or equal to the second value.</summary>
		// Token: 0x04001FC1 RID: 8129
		[__DynamicallyInvokable]
		public static readonly OpCode Bge_S = new OpCode(OpCodeValues.Bge_S, -530308497);

		/// <summary>Transfers control to a target instruction (short form) if the first value is greater than the second value.</summary>
		// Token: 0x04001FC2 RID: 8130
		[__DynamicallyInvokable]
		public static readonly OpCode Bgt_S = new OpCode(OpCodeValues.Bgt_S, -530308497);

		/// <summary>Transfers control to a target instruction (short form) if the first value is less than or equal to the second value.</summary>
		// Token: 0x04001FC3 RID: 8131
		[__DynamicallyInvokable]
		public static readonly OpCode Ble_S = new OpCode(OpCodeValues.Ble_S, -530308497);

		/// <summary>Transfers control to a target instruction (short form) if the first value is less than the second value.</summary>
		// Token: 0x04001FC4 RID: 8132
		[__DynamicallyInvokable]
		public static readonly OpCode Blt_S = new OpCode(OpCodeValues.Blt_S, -530308497);

		/// <summary>Transfers control to a target instruction (short form) when two unsigned integer values or unordered float values are not equal.</summary>
		// Token: 0x04001FC5 RID: 8133
		[__DynamicallyInvokable]
		public static readonly OpCode Bne_Un_S = new OpCode(OpCodeValues.Bne_Un_S, -530308497);

		/// <summary>Transfers control to a target instruction (short form) if the first value is greater than the second value, when comparing unsigned integer values or unordered float values.</summary>
		// Token: 0x04001FC6 RID: 8134
		[__DynamicallyInvokable]
		public static readonly OpCode Bge_Un_S = new OpCode(OpCodeValues.Bge_Un_S, -530308497);

		/// <summary>Transfers control to a target instruction (short form) if the first value is greater than the second value, when comparing unsigned integer values or unordered float values.</summary>
		// Token: 0x04001FC7 RID: 8135
		[__DynamicallyInvokable]
		public static readonly OpCode Bgt_Un_S = new OpCode(OpCodeValues.Bgt_Un_S, -530308497);

		/// <summary>Transfers control to a target instruction (short form) if the first value is less than or equal to the second value, when comparing unsigned integer values or unordered float values.</summary>
		// Token: 0x04001FC8 RID: 8136
		[__DynamicallyInvokable]
		public static readonly OpCode Ble_Un_S = new OpCode(OpCodeValues.Ble_Un_S, -530308497);

		/// <summary>Transfers control to a target instruction (short form) if the first value is less than the second value, when comparing unsigned integer values or unordered float values.</summary>
		// Token: 0x04001FC9 RID: 8137
		[__DynamicallyInvokable]
		public static readonly OpCode Blt_Un_S = new OpCode(OpCodeValues.Blt_Un_S, -530308497);

		/// <summary>Unconditionally transfers control to a target instruction.</summary>
		// Token: 0x04001FCA RID: 8138
		[__DynamicallyInvokable]
		public static readonly OpCode Br = new OpCode(OpCodeValues.Br, 23333376);

		/// <summary>Transfers control to a target instruction if <paramref name="value" /> is <see langword="false" />, a null reference (<see langword="Nothing" /> in Visual Basic), or zero.</summary>
		// Token: 0x04001FCB RID: 8139
		[__DynamicallyInvokable]
		public static readonly OpCode Brfalse = new OpCode(OpCodeValues.Brfalse, -261866912);

		/// <summary>Transfers control to a target instruction if <paramref name="value" /> is <see langword="true" />, not null, or non-zero.</summary>
		// Token: 0x04001FCC RID: 8140
		[__DynamicallyInvokable]
		public static readonly OpCode Brtrue = new OpCode(OpCodeValues.Brtrue, -261866912);

		/// <summary>Transfers control to a target instruction if two values are equal.</summary>
		// Token: 0x04001FCD RID: 8141
		[__DynamicallyInvokable]
		public static readonly OpCode Beq = new OpCode(OpCodeValues.Beq, -530308512);

		/// <summary>Transfers control to a target instruction if the first value is greater than or equal to the second value.</summary>
		// Token: 0x04001FCE RID: 8142
		[__DynamicallyInvokable]
		public static readonly OpCode Bge = new OpCode(OpCodeValues.Bge, -530308512);

		/// <summary>Transfers control to a target instruction if the first value is greater than the second value.</summary>
		// Token: 0x04001FCF RID: 8143
		[__DynamicallyInvokable]
		public static readonly OpCode Bgt = new OpCode(OpCodeValues.Bgt, -530308512);

		/// <summary>Transfers control to a target instruction if the first value is less than or equal to the second value.</summary>
		// Token: 0x04001FD0 RID: 8144
		[__DynamicallyInvokable]
		public static readonly OpCode Ble = new OpCode(OpCodeValues.Ble, -530308512);

		/// <summary>Transfers control to a target instruction if the first value is less than the second value.</summary>
		// Token: 0x04001FD1 RID: 8145
		[__DynamicallyInvokable]
		public static readonly OpCode Blt = new OpCode(OpCodeValues.Blt, -530308512);

		/// <summary>Transfers control to a target instruction when two unsigned integer values or unordered float values are not equal.</summary>
		// Token: 0x04001FD2 RID: 8146
		[__DynamicallyInvokable]
		public static readonly OpCode Bne_Un = new OpCode(OpCodeValues.Bne_Un, -530308512);

		/// <summary>Transfers control to a target instruction if the first value is greater than the second value, when comparing unsigned integer values or unordered float values.</summary>
		// Token: 0x04001FD3 RID: 8147
		[__DynamicallyInvokable]
		public static readonly OpCode Bge_Un = new OpCode(OpCodeValues.Bge_Un, -530308512);

		/// <summary>Transfers control to a target instruction if the first value is greater than the second value, when comparing unsigned integer values or unordered float values.</summary>
		// Token: 0x04001FD4 RID: 8148
		[__DynamicallyInvokable]
		public static readonly OpCode Bgt_Un = new OpCode(OpCodeValues.Bgt_Un, -530308512);

		/// <summary>Transfers control to a target instruction if the first value is less than or equal to the second value, when comparing unsigned integer values or unordered float values.</summary>
		// Token: 0x04001FD5 RID: 8149
		[__DynamicallyInvokable]
		public static readonly OpCode Ble_Un = new OpCode(OpCodeValues.Ble_Un, -530308512);

		/// <summary>Transfers control to a target instruction if the first value is less than the second value, when comparing unsigned integer values or unordered float values.</summary>
		// Token: 0x04001FD6 RID: 8150
		[__DynamicallyInvokable]
		public static readonly OpCode Blt_Un = new OpCode(OpCodeValues.Blt_Un, -530308512);

		/// <summary>Implements a jump table.</summary>
		// Token: 0x04001FD7 RID: 8151
		[__DynamicallyInvokable]
		public static readonly OpCode Switch = new OpCode(OpCodeValues.Switch, -261866901);

		/// <summary>Loads a value of type <see langword="int8" /> as an <see langword="int32" /> onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FD8 RID: 8152
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_I1 = new OpCode(OpCodeValues.Ldind_I1, 6961829);

		/// <summary>Loads a value of type <see langword="unsigned int8" /> as an <see langword="int32" /> onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FD9 RID: 8153
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_U1 = new OpCode(OpCodeValues.Ldind_U1, 6961829);

		/// <summary>Loads a value of type <see langword="int16" /> as an <see langword="int32" /> onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FDA RID: 8154
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_I2 = new OpCode(OpCodeValues.Ldind_I2, 6961829);

		/// <summary>Loads a value of type <see langword="unsigned int16" /> as an <see langword="int32" /> onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FDB RID: 8155
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_U2 = new OpCode(OpCodeValues.Ldind_U2, 6961829);

		/// <summary>Loads a value of type <see langword="int32" /> as an <see langword="int32" /> onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FDC RID: 8156
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_I4 = new OpCode(OpCodeValues.Ldind_I4, 6961829);

		/// <summary>Loads a value of type <see langword="unsigned int32" /> as an <see langword="int32" /> onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FDD RID: 8157
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_U4 = new OpCode(OpCodeValues.Ldind_U4, 6961829);

		/// <summary>Loads a value of type <see langword="int64" /> as an <see langword="int64" /> onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FDE RID: 8158
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_I8 = new OpCode(OpCodeValues.Ldind_I8, 7092901);

		/// <summary>Loads a value of type <see langword="native int" /> as a <see langword="native int" /> onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FDF RID: 8159
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_I = new OpCode(OpCodeValues.Ldind_I, 6961829);

		/// <summary>Loads a value of type <see langword="float32" /> as a type <see langword="F" /> (float) onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FE0 RID: 8160
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_R4 = new OpCode(OpCodeValues.Ldind_R4, 7223973);

		/// <summary>Loads a value of type <see langword="float64" /> as a type <see langword="F" /> (float) onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FE1 RID: 8161
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_R8 = new OpCode(OpCodeValues.Ldind_R8, 7355045);

		/// <summary>Loads an object reference as a type <see langword="O" /> (object reference) onto the evaluation stack indirectly.</summary>
		// Token: 0x04001FE2 RID: 8162
		[__DynamicallyInvokable]
		public static readonly OpCode Ldind_Ref = new OpCode(OpCodeValues.Ldind_Ref, 7486117);

		/// <summary>Stores a object reference value at a supplied address.</summary>
		// Token: 0x04001FE3 RID: 8163
		[__DynamicallyInvokable]
		public static readonly OpCode Stind_Ref = new OpCode(OpCodeValues.Stind_Ref, -530294107);

		/// <summary>Stores a value of type <see langword="int8" /> at a supplied address.</summary>
		// Token: 0x04001FE4 RID: 8164
		[__DynamicallyInvokable]
		public static readonly OpCode Stind_I1 = new OpCode(OpCodeValues.Stind_I1, -530294107);

		/// <summary>Stores a value of type <see langword="int16" /> at a supplied address.</summary>
		// Token: 0x04001FE5 RID: 8165
		[__DynamicallyInvokable]
		public static readonly OpCode Stind_I2 = new OpCode(OpCodeValues.Stind_I2, -530294107);

		/// <summary>Stores a value of type <see langword="int32" /> at a supplied address.</summary>
		// Token: 0x04001FE6 RID: 8166
		[__DynamicallyInvokable]
		public static readonly OpCode Stind_I4 = new OpCode(OpCodeValues.Stind_I4, -530294107);

		/// <summary>Stores a value of type <see langword="int64" /> at a supplied address.</summary>
		// Token: 0x04001FE7 RID: 8167
		[__DynamicallyInvokable]
		public static readonly OpCode Stind_I8 = new OpCode(OpCodeValues.Stind_I8, -530290011);

		/// <summary>Stores a value of type <see langword="float32" /> at a supplied address.</summary>
		// Token: 0x04001FE8 RID: 8168
		[__DynamicallyInvokable]
		public static readonly OpCode Stind_R4 = new OpCode(OpCodeValues.Stind_R4, -530281819);

		/// <summary>Stores a value of type <see langword="float64" /> at a supplied address.</summary>
		// Token: 0x04001FE9 RID: 8169
		[__DynamicallyInvokable]
		public static readonly OpCode Stind_R8 = new OpCode(OpCodeValues.Stind_R8, -530277723);

		/// <summary>Adds two values and pushes the result onto the evaluation stack.</summary>
		// Token: 0x04001FEA RID: 8170
		[__DynamicallyInvokable]
		public static readonly OpCode Add = new OpCode(OpCodeValues.Add, -261739867);

		/// <summary>Subtracts one value from another and pushes the result onto the evaluation stack.</summary>
		// Token: 0x04001FEB RID: 8171
		[__DynamicallyInvokable]
		public static readonly OpCode Sub = new OpCode(OpCodeValues.Sub, -261739867);

		/// <summary>Multiplies two values and pushes the result on the evaluation stack.</summary>
		// Token: 0x04001FEC RID: 8172
		[__DynamicallyInvokable]
		public static readonly OpCode Mul = new OpCode(OpCodeValues.Mul, -261739867);

		/// <summary>Divides two values and pushes the result as a floating-point (type <see langword="F" />) or quotient (type <see langword="int32" />) onto the evaluation stack.</summary>
		// Token: 0x04001FED RID: 8173
		[__DynamicallyInvokable]
		public static readonly OpCode Div = new OpCode(OpCodeValues.Div, -261739867);

		/// <summary>Divides two unsigned integer values and pushes the result (<see langword="int32" />) onto the evaluation stack.</summary>
		// Token: 0x04001FEE RID: 8174
		[__DynamicallyInvokable]
		public static readonly OpCode Div_Un = new OpCode(OpCodeValues.Div_Un, -261739867);

		/// <summary>Divides two values and pushes the remainder onto the evaluation stack.</summary>
		// Token: 0x04001FEF RID: 8175
		[__DynamicallyInvokable]
		public static readonly OpCode Rem = new OpCode(OpCodeValues.Rem, -261739867);

		/// <summary>Divides two unsigned values and pushes the remainder onto the evaluation stack.</summary>
		// Token: 0x04001FF0 RID: 8176
		[__DynamicallyInvokable]
		public static readonly OpCode Rem_Un = new OpCode(OpCodeValues.Rem_Un, -261739867);

		/// <summary>Computes the bitwise AND of two values and pushes the result onto the evaluation stack.</summary>
		// Token: 0x04001FF1 RID: 8177
		[__DynamicallyInvokable]
		public static readonly OpCode And = new OpCode(OpCodeValues.And, -261739867);

		/// <summary>Compute the bitwise complement of the two integer values on top of the stack and pushes the result onto the evaluation stack.</summary>
		// Token: 0x04001FF2 RID: 8178
		[__DynamicallyInvokable]
		public static readonly OpCode Or = new OpCode(OpCodeValues.Or, -261739867);

		/// <summary>Computes the bitwise XOR of the top two values on the evaluation stack, pushing the result onto the evaluation stack.</summary>
		// Token: 0x04001FF3 RID: 8179
		[__DynamicallyInvokable]
		public static readonly OpCode Xor = new OpCode(OpCodeValues.Xor, -261739867);

		/// <summary>Shifts an integer value to the left (in zeroes) by a specified number of bits, pushing the result onto the evaluation stack.</summary>
		// Token: 0x04001FF4 RID: 8180
		[__DynamicallyInvokable]
		public static readonly OpCode Shl = new OpCode(OpCodeValues.Shl, -261739867);

		/// <summary>Shifts an integer value (in sign) to the right by a specified number of bits, pushing the result onto the evaluation stack.</summary>
		// Token: 0x04001FF5 RID: 8181
		[__DynamicallyInvokable]
		public static readonly OpCode Shr = new OpCode(OpCodeValues.Shr, -261739867);

		/// <summary>Shifts an unsigned integer value (in zeroes) to the right by a specified number of bits, pushing the result onto the evaluation stack.</summary>
		// Token: 0x04001FF6 RID: 8182
		[__DynamicallyInvokable]
		public static readonly OpCode Shr_Un = new OpCode(OpCodeValues.Shr_Un, -261739867);

		/// <summary>Negates a value and pushes the result onto the evaluation stack.</summary>
		// Token: 0x04001FF7 RID: 8183
		[__DynamicallyInvokable]
		public static readonly OpCode Neg = new OpCode(OpCodeValues.Neg, 6691493);

		/// <summary>Computes the bitwise complement of the integer value on top of the stack and pushes the result onto the evaluation stack as the same type.</summary>
		// Token: 0x04001FF8 RID: 8184
		[__DynamicallyInvokable]
		public static readonly OpCode Not = new OpCode(OpCodeValues.Not, 6691493);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="int8" />, then extends (pads) it to <see langword="int32" />.</summary>
		// Token: 0x04001FF9 RID: 8185
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_I1 = new OpCode(OpCodeValues.Conv_I1, 6953637);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="int16" />, then extends (pads) it to <see langword="int32" />.</summary>
		// Token: 0x04001FFA RID: 8186
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_I2 = new OpCode(OpCodeValues.Conv_I2, 6953637);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="int32" />.</summary>
		// Token: 0x04001FFB RID: 8187
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_I4 = new OpCode(OpCodeValues.Conv_I4, 6953637);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="int64" />.</summary>
		// Token: 0x04001FFC RID: 8188
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_I8 = new OpCode(OpCodeValues.Conv_I8, 7084709);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="float32" />.</summary>
		// Token: 0x04001FFD RID: 8189
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_R4 = new OpCode(OpCodeValues.Conv_R4, 7215781);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="float64" />.</summary>
		// Token: 0x04001FFE RID: 8190
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_R8 = new OpCode(OpCodeValues.Conv_R8, 7346853);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="unsigned int32" />, and extends it to <see langword="int32" />.</summary>
		// Token: 0x04001FFF RID: 8191
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_U4 = new OpCode(OpCodeValues.Conv_U4, 6953637);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="unsigned int64" />, and extends it to <see langword="int64" />.</summary>
		// Token: 0x04002000 RID: 8192
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_U8 = new OpCode(OpCodeValues.Conv_U8, 7084709);

		/// <summary>Calls a late-bound method on an object, pushing the return value onto the evaluation stack.</summary>
		// Token: 0x04002001 RID: 8193
		[__DynamicallyInvokable]
		public static readonly OpCode Callvirt = new OpCode(OpCodeValues.Callvirt, 7841348);

		/// <summary>Copies the value type located at the address of an object (type <see langword="&amp;" />, <see langword="" /> or <see langword="native int" />) to the address of the destination object (type <see langword="&amp;" />, <see langword="" /> or <see langword="native int" />).</summary>
		// Token: 0x04002002 RID: 8194
		[__DynamicallyInvokable]
		public static readonly OpCode Cpobj = new OpCode(OpCodeValues.Cpobj, -530295123);

		/// <summary>Copies the value type object pointed to by an address to the top of the evaluation stack.</summary>
		// Token: 0x04002003 RID: 8195
		[__DynamicallyInvokable]
		public static readonly OpCode Ldobj = new OpCode(OpCodeValues.Ldobj, 6698669);

		/// <summary>Pushes a new object reference to a string literal stored in the metadata.</summary>
		// Token: 0x04002004 RID: 8196
		[__DynamicallyInvokable]
		public static readonly OpCode Ldstr = new OpCode(OpCodeValues.Ldstr, 275908266);

		/// <summary>Creates a new object or a new instance of a value type, pushing an object reference (type <see langword="O" />) onto the evaluation stack.</summary>
		// Token: 0x04002005 RID: 8197
		[__DynamicallyInvokable]
		public static readonly OpCode Newobj = new OpCode(OpCodeValues.Newobj, 276014660);

		/// <summary>Attempts to cast an object passed by reference to the specified class.</summary>
		// Token: 0x04002006 RID: 8198
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public static readonly OpCode Castclass = new OpCode(OpCodeValues.Castclass, 7513773);

		/// <summary>Tests whether an object reference (type <see langword="O" />) is an instance of a particular class.</summary>
		// Token: 0x04002007 RID: 8199
		[__DynamicallyInvokable]
		public static readonly OpCode Isinst = new OpCode(OpCodeValues.Isinst, 6989485);

		/// <summary>Converts the unsigned integer value on top of the evaluation stack to <see langword="float32" />.</summary>
		// Token: 0x04002008 RID: 8200
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_R_Un = new OpCode(OpCodeValues.Conv_R_Un, 7346853);

		/// <summary>Converts the boxed representation of a value type to its unboxed form.</summary>
		// Token: 0x04002009 RID: 8201
		[__DynamicallyInvokable]
		public static readonly OpCode Unbox = new OpCode(OpCodeValues.Unbox, 6990509);

		/// <summary>Throws the exception object currently on the evaluation stack.</summary>
		// Token: 0x0400200A RID: 8202
		[__DynamicallyInvokable]
		public static readonly OpCode Throw = new OpCode(OpCodeValues.Throw, -245061883);

		/// <summary>Finds the value of a field in the object whose reference is currently on the evaluation stack.</summary>
		// Token: 0x0400200B RID: 8203
		[__DynamicallyInvokable]
		public static readonly OpCode Ldfld = new OpCode(OpCodeValues.Ldfld, 6727329);

		/// <summary>Finds the address of a field in the object whose reference is currently on the evaluation stack.</summary>
		// Token: 0x0400200C RID: 8204
		[__DynamicallyInvokable]
		public static readonly OpCode Ldflda = new OpCode(OpCodeValues.Ldflda, 6989473);

		/// <summary>Replaces the value stored in the field of an object reference or pointer with a new value.</summary>
		// Token: 0x0400200D RID: 8205
		[__DynamicallyInvokable]
		public static readonly OpCode Stfld = new OpCode(OpCodeValues.Stfld, -530270559);

		/// <summary>Pushes the value of a static field onto the evaluation stack.</summary>
		// Token: 0x0400200E RID: 8206
		[__DynamicallyInvokable]
		public static readonly OpCode Ldsfld = new OpCode(OpCodeValues.Ldsfld, 275121825);

		/// <summary>Pushes the address of a static field onto the evaluation stack.</summary>
		// Token: 0x0400200F RID: 8207
		[__DynamicallyInvokable]
		public static readonly OpCode Ldsflda = new OpCode(OpCodeValues.Ldsflda, 275383969);

		/// <summary>Replaces the value of a static field with a value from the evaluation stack.</summary>
		// Token: 0x04002010 RID: 8208
		[__DynamicallyInvokable]
		public static readonly OpCode Stsfld = new OpCode(OpCodeValues.Stsfld, -261876063);

		/// <summary>Copies a value of a specified type from the evaluation stack into a supplied memory address.</summary>
		// Token: 0x04002011 RID: 8209
		[__DynamicallyInvokable]
		public static readonly OpCode Stobj = new OpCode(OpCodeValues.Stobj, -530298195);

		/// <summary>Converts the unsigned value on top of the evaluation stack to signed <see langword="int8" /> and extends it to <see langword="int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002012 RID: 8210
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_I1_Un = new OpCode(OpCodeValues.Conv_Ovf_I1_Un, 6953637);

		/// <summary>Converts the unsigned value on top of the evaluation stack to signed <see langword="int16" /> and extends it to <see langword="int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002013 RID: 8211
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_I2_Un = new OpCode(OpCodeValues.Conv_Ovf_I2_Un, 6953637);

		/// <summary>Converts the unsigned value on top of the evaluation stack to signed <see langword="int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002014 RID: 8212
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_I4_Un = new OpCode(OpCodeValues.Conv_Ovf_I4_Un, 6953637);

		/// <summary>Converts the unsigned value on top of the evaluation stack to signed <see langword="int64" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002015 RID: 8213
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_I8_Un = new OpCode(OpCodeValues.Conv_Ovf_I8_Un, 7084709);

		/// <summary>Converts the unsigned value on top of the evaluation stack to <see langword="unsigned int8" /> and extends it to <see langword="int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002016 RID: 8214
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_U1_Un = new OpCode(OpCodeValues.Conv_Ovf_U1_Un, 6953637);

		/// <summary>Converts the unsigned value on top of the evaluation stack to <see langword="unsigned int16" /> and extends it to <see langword="int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002017 RID: 8215
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_U2_Un = new OpCode(OpCodeValues.Conv_Ovf_U2_Un, 6953637);

		/// <summary>Converts the unsigned value on top of the evaluation stack to <see langword="unsigned int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002018 RID: 8216
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_U4_Un = new OpCode(OpCodeValues.Conv_Ovf_U4_Un, 6953637);

		/// <summary>Converts the unsigned value on top of the evaluation stack to <see langword="unsigned int64" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002019 RID: 8217
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_U8_Un = new OpCode(OpCodeValues.Conv_Ovf_U8_Un, 7084709);

		/// <summary>Converts the unsigned value on top of the evaluation stack to signed <see langword="native int" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x0400201A RID: 8218
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_I_Un = new OpCode(OpCodeValues.Conv_Ovf_I_Un, 6953637);

		/// <summary>Converts the unsigned value on top of the evaluation stack to <see langword="unsigned native int" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x0400201B RID: 8219
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_U_Un = new OpCode(OpCodeValues.Conv_Ovf_U_Un, 6953637);

		/// <summary>Converts a value type to an object reference (type <see langword="O" />).</summary>
		// Token: 0x0400201C RID: 8220
		[__DynamicallyInvokable]
		public static readonly OpCode Box = new OpCode(OpCodeValues.Box, 7477933);

		/// <summary>Pushes an object reference to a new zero-based, one-dimensional array whose elements are of a specific type onto the evaluation stack.</summary>
		// Token: 0x0400201D RID: 8221
		[__DynamicallyInvokable]
		public static readonly OpCode Newarr = new OpCode(OpCodeValues.Newarr, 7485101);

		/// <summary>Pushes the number of elements of a zero-based, one-dimensional array onto the evaluation stack.</summary>
		// Token: 0x0400201E RID: 8222
		[__DynamicallyInvokable]
		public static readonly OpCode Ldlen = new OpCode(OpCodeValues.Ldlen, 6989477);

		/// <summary>Loads the address of the array element at a specified array index onto the top of the evaluation stack as type <see langword="&amp;" /> (managed pointer).</summary>
		// Token: 0x0400201F RID: 8223
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelema = new OpCode(OpCodeValues.Ldelema, -261437779);

		/// <summary>Loads the element with type <see langword="int8" /> at a specified array index onto the top of the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04002020 RID: 8224
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_I1 = new OpCode(OpCodeValues.Ldelem_I1, -261437787);

		/// <summary>Loads the element with type <see langword="unsigned int8" /> at a specified array index onto the top of the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04002021 RID: 8225
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_U1 = new OpCode(OpCodeValues.Ldelem_U1, -261437787);

		/// <summary>Loads the element with type <see langword="int16" /> at a specified array index onto the top of the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04002022 RID: 8226
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_I2 = new OpCode(OpCodeValues.Ldelem_I2, -261437787);

		/// <summary>Loads the element with type <see langword="unsigned int16" /> at a specified array index onto the top of the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04002023 RID: 8227
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_U2 = new OpCode(OpCodeValues.Ldelem_U2, -261437787);

		/// <summary>Loads the element with type <see langword="int32" /> at a specified array index onto the top of the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04002024 RID: 8228
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_I4 = new OpCode(OpCodeValues.Ldelem_I4, -261437787);

		/// <summary>Loads the element with type <see langword="unsigned int32" /> at a specified array index onto the top of the evaluation stack as an <see langword="int32" />.</summary>
		// Token: 0x04002025 RID: 8229
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_U4 = new OpCode(OpCodeValues.Ldelem_U4, -261437787);

		/// <summary>Loads the element with type <see langword="int64" /> at a specified array index onto the top of the evaluation stack as an <see langword="int64" />.</summary>
		// Token: 0x04002026 RID: 8230
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_I8 = new OpCode(OpCodeValues.Ldelem_I8, -261306715);

		/// <summary>Loads the element with type <see langword="native int" /> at a specified array index onto the top of the evaluation stack as a <see langword="native int" />.</summary>
		// Token: 0x04002027 RID: 8231
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_I = new OpCode(OpCodeValues.Ldelem_I, -261437787);

		/// <summary>Loads the element with type <see langword="float32" /> at a specified array index onto the top of the evaluation stack as type <see langword="F" /> (float).</summary>
		// Token: 0x04002028 RID: 8232
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_R4 = new OpCode(OpCodeValues.Ldelem_R4, -261175643);

		/// <summary>Loads the element with type <see langword="float64" /> at a specified array index onto the top of the evaluation stack as type <see langword="F" /> (float).</summary>
		// Token: 0x04002029 RID: 8233
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_R8 = new OpCode(OpCodeValues.Ldelem_R8, -261044571);

		/// <summary>Loads the element containing an object reference at a specified array index onto the top of the evaluation stack as type <see langword="O" /> (object reference).</summary>
		// Token: 0x0400202A RID: 8234
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem_Ref = new OpCode(OpCodeValues.Ldelem_Ref, -260913499);

		/// <summary>Replaces the array element at a given index with the <see langword="native int" /> value on the evaluation stack.</summary>
		// Token: 0x0400202B RID: 8235
		[__DynamicallyInvokable]
		public static readonly OpCode Stelem_I = new OpCode(OpCodeValues.Stelem_I, -798697819);

		/// <summary>Replaces the array element at a given index with the <see langword="int8" /> value on the evaluation stack.</summary>
		// Token: 0x0400202C RID: 8236
		[__DynamicallyInvokable]
		public static readonly OpCode Stelem_I1 = new OpCode(OpCodeValues.Stelem_I1, -798697819);

		/// <summary>Replaces the array element at a given index with the <see langword="int16" /> value on the evaluation stack.</summary>
		// Token: 0x0400202D RID: 8237
		[__DynamicallyInvokable]
		public static readonly OpCode Stelem_I2 = new OpCode(OpCodeValues.Stelem_I2, -798697819);

		/// <summary>Replaces the array element at a given index with the <see langword="int32" /> value on the evaluation stack.</summary>
		// Token: 0x0400202E RID: 8238
		[__DynamicallyInvokable]
		public static readonly OpCode Stelem_I4 = new OpCode(OpCodeValues.Stelem_I4, -798697819);

		/// <summary>Replaces the array element at a given index with the <see langword="int64" /> value on the evaluation stack.</summary>
		// Token: 0x0400202F RID: 8239
		[__DynamicallyInvokable]
		public static readonly OpCode Stelem_I8 = new OpCode(OpCodeValues.Stelem_I8, -798693723);

		/// <summary>Replaces the array element at a given index with the <see langword="float32" /> value on the evaluation stack.</summary>
		// Token: 0x04002030 RID: 8240
		[__DynamicallyInvokable]
		public static readonly OpCode Stelem_R4 = new OpCode(OpCodeValues.Stelem_R4, -798689627);

		/// <summary>Replaces the array element at a given index with the <see langword="float64" /> value on the evaluation stack.</summary>
		// Token: 0x04002031 RID: 8241
		[__DynamicallyInvokable]
		public static readonly OpCode Stelem_R8 = new OpCode(OpCodeValues.Stelem_R8, -798685531);

		/// <summary>Replaces the array element at a given index with the object ref value (type <see langword="O" />) on the evaluation stack.</summary>
		// Token: 0x04002032 RID: 8242
		[__DynamicallyInvokable]
		public static readonly OpCode Stelem_Ref = new OpCode(OpCodeValues.Stelem_Ref, -798681435);

		/// <summary>Loads the element at a specified array index onto the top of the evaluation stack as the type specified in the instruction.</summary>
		// Token: 0x04002033 RID: 8243
		[__DynamicallyInvokable]
		public static readonly OpCode Ldelem = new OpCode(OpCodeValues.Ldelem, -261699923);

		/// <summary>Replaces the array element at a given index with the value on the evaluation stack, whose type is specified in the instruction.</summary>
		// Token: 0x04002034 RID: 8244
		[__DynamicallyInvokable]
		public static readonly OpCode Stelem = new OpCode(OpCodeValues.Stelem, 6669997);

		/// <summary>Converts the boxed representation of a type specified in the instruction to its unboxed form.</summary>
		// Token: 0x04002035 RID: 8245
		[__DynamicallyInvokable]
		public static readonly OpCode Unbox_Any = new OpCode(OpCodeValues.Unbox_Any, 6727341);

		/// <summary>Converts the signed value on top of the evaluation stack to signed <see langword="int8" /> and extends it to <see langword="int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002036 RID: 8246
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_I1 = new OpCode(OpCodeValues.Conv_Ovf_I1, 6953637);

		/// <summary>Converts the signed value on top of the evaluation stack to <see langword="unsigned int8" /> and extends it to <see langword="int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002037 RID: 8247
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_U1 = new OpCode(OpCodeValues.Conv_Ovf_U1, 6953637);

		/// <summary>Converts the signed value on top of the evaluation stack to signed <see langword="int16" /> and extending it to <see langword="int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002038 RID: 8248
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_I2 = new OpCode(OpCodeValues.Conv_Ovf_I2, 6953637);

		/// <summary>Converts the signed value on top of the evaluation stack to <see langword="unsigned int16" /> and extends it to <see langword="int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002039 RID: 8249
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_U2 = new OpCode(OpCodeValues.Conv_Ovf_U2, 6953637);

		/// <summary>Converts the signed value on top of the evaluation stack to signed <see langword="int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x0400203A RID: 8250
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_I4 = new OpCode(OpCodeValues.Conv_Ovf_I4, 6953637);

		/// <summary>Converts the signed value on top of the evaluation stack to <see langword="unsigned int32" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x0400203B RID: 8251
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_U4 = new OpCode(OpCodeValues.Conv_Ovf_U4, 6953637);

		/// <summary>Converts the signed value on top of the evaluation stack to signed <see langword="int64" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x0400203C RID: 8252
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_I8 = new OpCode(OpCodeValues.Conv_Ovf_I8, 7084709);

		/// <summary>Converts the signed value on top of the evaluation stack to <see langword="unsigned int64" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x0400203D RID: 8253
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_U8 = new OpCode(OpCodeValues.Conv_Ovf_U8, 7084709);

		/// <summary>Retrieves the address (type <see langword="&amp;" />) embedded in a typed reference.</summary>
		// Token: 0x0400203E RID: 8254
		[__DynamicallyInvokable]
		public static readonly OpCode Refanyval = new OpCode(OpCodeValues.Refanyval, 6953645);

		/// <summary>Throws <see cref="T:System.ArithmeticException" /> if value is not a finite number.</summary>
		// Token: 0x0400203F RID: 8255
		[__DynamicallyInvokable]
		public static readonly OpCode Ckfinite = new OpCode(OpCodeValues.Ckfinite, 7346853);

		/// <summary>Pushes a typed reference to an instance of a specific type onto the evaluation stack.</summary>
		// Token: 0x04002040 RID: 8256
		[__DynamicallyInvokable]
		public static readonly OpCode Mkrefany = new OpCode(OpCodeValues.Mkrefany, 6699693);

		/// <summary>Converts a metadata token to its runtime representation, pushing it onto the evaluation stack.</summary>
		// Token: 0x04002041 RID: 8257
		[__DynamicallyInvokable]
		public static readonly OpCode Ldtoken = new OpCode(OpCodeValues.Ldtoken, 275385004);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="unsigned int16" />, and extends it to <see langword="int32" />.</summary>
		// Token: 0x04002042 RID: 8258
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_U2 = new OpCode(OpCodeValues.Conv_U2, 6953637);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="unsigned int8" />, and extends it to <see langword="int32" />.</summary>
		// Token: 0x04002043 RID: 8259
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_U1 = new OpCode(OpCodeValues.Conv_U1, 6953637);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="native int" />.</summary>
		// Token: 0x04002044 RID: 8260
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_I = new OpCode(OpCodeValues.Conv_I, 6953637);

		/// <summary>Converts the signed value on top of the evaluation stack to signed <see langword="native int" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002045 RID: 8261
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_I = new OpCode(OpCodeValues.Conv_Ovf_I, 6953637);

		/// <summary>Converts the signed value on top of the evaluation stack to <see langword="unsigned native int" />, throwing <see cref="T:System.OverflowException" /> on overflow.</summary>
		// Token: 0x04002046 RID: 8262
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_Ovf_U = new OpCode(OpCodeValues.Conv_Ovf_U, 6953637);

		/// <summary>Adds two integers, performs an overflow check, and pushes the result onto the evaluation stack.</summary>
		// Token: 0x04002047 RID: 8263
		[__DynamicallyInvokable]
		public static readonly OpCode Add_Ovf = new OpCode(OpCodeValues.Add_Ovf, -261739867);

		/// <summary>Adds two unsigned integer values, performs an overflow check, and pushes the result onto the evaluation stack.</summary>
		// Token: 0x04002048 RID: 8264
		[__DynamicallyInvokable]
		public static readonly OpCode Add_Ovf_Un = new OpCode(OpCodeValues.Add_Ovf_Un, -261739867);

		/// <summary>Multiplies two integer values, performs an overflow check, and pushes the result onto the evaluation stack.</summary>
		// Token: 0x04002049 RID: 8265
		[__DynamicallyInvokable]
		public static readonly OpCode Mul_Ovf = new OpCode(OpCodeValues.Mul_Ovf, -261739867);

		/// <summary>Multiplies two unsigned integer values, performs an overflow check, and pushes the result onto the evaluation stack.</summary>
		// Token: 0x0400204A RID: 8266
		[__DynamicallyInvokable]
		public static readonly OpCode Mul_Ovf_Un = new OpCode(OpCodeValues.Mul_Ovf_Un, -261739867);

		/// <summary>Subtracts one integer value from another, performs an overflow check, and pushes the result onto the evaluation stack.</summary>
		// Token: 0x0400204B RID: 8267
		[__DynamicallyInvokable]
		public static readonly OpCode Sub_Ovf = new OpCode(OpCodeValues.Sub_Ovf, -261739867);

		/// <summary>Subtracts one unsigned integer value from another, performs an overflow check, and pushes the result onto the evaluation stack.</summary>
		// Token: 0x0400204C RID: 8268
		[__DynamicallyInvokable]
		public static readonly OpCode Sub_Ovf_Un = new OpCode(OpCodeValues.Sub_Ovf_Un, -261739867);

		/// <summary>Transfers control from the <see langword="fault" /> or <see langword="finally" /> clause of an exception block back to the Common Language Infrastructure (CLI) exception handler.</summary>
		// Token: 0x0400204D RID: 8269
		[__DynamicallyInvokable]
		public static readonly OpCode Endfinally = new OpCode(OpCodeValues.Endfinally, 23333605);

		/// <summary>Exits a protected region of code, unconditionally transferring control to a specific target instruction.</summary>
		// Token: 0x0400204E RID: 8270
		[__DynamicallyInvokable]
		public static readonly OpCode Leave = new OpCode(OpCodeValues.Leave, 23333376);

		/// <summary>Exits a protected region of code, unconditionally transferring control to a target instruction (short form).</summary>
		// Token: 0x0400204F RID: 8271
		[__DynamicallyInvokable]
		public static readonly OpCode Leave_S = new OpCode(OpCodeValues.Leave_S, 23333391);

		/// <summary>Stores a value of type <see langword="native int" /> at a supplied address.</summary>
		// Token: 0x04002050 RID: 8272
		[__DynamicallyInvokable]
		public static readonly OpCode Stind_I = new OpCode(OpCodeValues.Stind_I, -530294107);

		/// <summary>Converts the value on top of the evaluation stack to <see langword="unsigned native int" />, and extends it to <see langword="native int" />.</summary>
		// Token: 0x04002051 RID: 8273
		[__DynamicallyInvokable]
		public static readonly OpCode Conv_U = new OpCode(OpCodeValues.Conv_U, 6953637);

		/// <summary>This is a reserved instruction.</summary>
		// Token: 0x04002052 RID: 8274
		[__DynamicallyInvokable]
		public static readonly OpCode Prefix7 = new OpCode(OpCodeValues.Prefix7, 6554757);

		/// <summary>This is a reserved instruction.</summary>
		// Token: 0x04002053 RID: 8275
		[__DynamicallyInvokable]
		public static readonly OpCode Prefix6 = new OpCode(OpCodeValues.Prefix6, 6554757);

		/// <summary>This is a reserved instruction.</summary>
		// Token: 0x04002054 RID: 8276
		[__DynamicallyInvokable]
		public static readonly OpCode Prefix5 = new OpCode(OpCodeValues.Prefix5, 6554757);

		/// <summary>This is a reserved instruction.</summary>
		// Token: 0x04002055 RID: 8277
		[__DynamicallyInvokable]
		public static readonly OpCode Prefix4 = new OpCode(OpCodeValues.Prefix4, 6554757);

		/// <summary>This is a reserved instruction.</summary>
		// Token: 0x04002056 RID: 8278
		[__DynamicallyInvokable]
		public static readonly OpCode Prefix3 = new OpCode(OpCodeValues.Prefix3, 6554757);

		/// <summary>This is a reserved instruction.</summary>
		// Token: 0x04002057 RID: 8279
		[__DynamicallyInvokable]
		public static readonly OpCode Prefix2 = new OpCode(OpCodeValues.Prefix2, 6554757);

		/// <summary>This is a reserved instruction.</summary>
		// Token: 0x04002058 RID: 8280
		[__DynamicallyInvokable]
		public static readonly OpCode Prefix1 = new OpCode(OpCodeValues.Prefix1, 6554757);

		/// <summary>This is a reserved instruction.</summary>
		// Token: 0x04002059 RID: 8281
		[__DynamicallyInvokable]
		public static readonly OpCode Prefixref = new OpCode(OpCodeValues.Prefixref, 6554757);

		/// <summary>Returns an unmanaged pointer to the argument list of the current method.</summary>
		// Token: 0x0400205A RID: 8282
		[__DynamicallyInvokable]
		public static readonly OpCode Arglist = new OpCode(OpCodeValues.Arglist, 279579301);

		/// <summary>Compares two values. If they are equal, the integer value 1 <see langword="(int32" />) is pushed onto the evaluation stack; otherwise 0 (<see langword="int32" />) is pushed onto the evaluation stack.</summary>
		// Token: 0x0400205B RID: 8283
		[__DynamicallyInvokable]
		public static readonly OpCode Ceq = new OpCode(OpCodeValues.Ceq, -257283419);

		/// <summary>Compares two values. If the first value is greater than the second, the integer value 1 <see langword="(int32" />) is pushed onto the evaluation stack; otherwise 0 (<see langword="int32" />) is pushed onto the evaluation stack.</summary>
		// Token: 0x0400205C RID: 8284
		[__DynamicallyInvokable]
		public static readonly OpCode Cgt = new OpCode(OpCodeValues.Cgt, -257283419);

		/// <summary>Compares two unsigned or unordered values. If the first value is greater than the second, the integer value 1 <see langword="(int32" />) is pushed onto the evaluation stack; otherwise 0 (<see langword="int32" />) is pushed onto the evaluation stack.</summary>
		// Token: 0x0400205D RID: 8285
		[__DynamicallyInvokable]
		public static readonly OpCode Cgt_Un = new OpCode(OpCodeValues.Cgt_Un, -257283419);

		/// <summary>Compares two values. If the first value is less than the second, the integer value 1 <see langword="(int32" />) is pushed onto the evaluation stack; otherwise 0 (<see langword="int32" />) is pushed onto the evaluation stack.</summary>
		// Token: 0x0400205E RID: 8286
		[__DynamicallyInvokable]
		public static readonly OpCode Clt = new OpCode(OpCodeValues.Clt, -257283419);

		/// <summary>Compares the unsigned or unordered values <paramref name="value1" /> and <paramref name="value2" />. If <paramref name="value1" /> is less than <paramref name="value2" />, then the integer value 1 <see langword="(int32" />) is pushed onto the evaluation stack; otherwise 0 (<see langword="int32" />) is pushed onto the evaluation stack.</summary>
		// Token: 0x0400205F RID: 8287
		[__DynamicallyInvokable]
		public static readonly OpCode Clt_Un = new OpCode(OpCodeValues.Clt_Un, -257283419);

		/// <summary>Pushes an unmanaged pointer (type <see langword="native int" />) to the native code implementing a specific method onto the evaluation stack.</summary>
		// Token: 0x04002060 RID: 8288
		[__DynamicallyInvokable]
		public static readonly OpCode Ldftn = new OpCode(OpCodeValues.Ldftn, 279579300);

		/// <summary>Pushes an unmanaged pointer (type <see langword="native int" />) to the native code implementing a particular virtual method associated with a specified object onto the evaluation stack.</summary>
		// Token: 0x04002061 RID: 8289
		[__DynamicallyInvokable]
		public static readonly OpCode Ldvirtftn = new OpCode(OpCodeValues.Ldvirtftn, 11184804);

		/// <summary>Loads an argument (referenced by a specified index value) onto the stack.</summary>
		// Token: 0x04002062 RID: 8290
		[__DynamicallyInvokable]
		public static readonly OpCode Ldarg = new OpCode(OpCodeValues.Ldarg, 279317166);

		/// <summary>Load an argument address onto the evaluation stack.</summary>
		// Token: 0x04002063 RID: 8291
		[__DynamicallyInvokable]
		public static readonly OpCode Ldarga = new OpCode(OpCodeValues.Ldarga, 279579310);

		/// <summary>Stores the value on top of the evaluation stack in the argument slot at a specified index.</summary>
		// Token: 0x04002064 RID: 8292
		[__DynamicallyInvokable]
		public static readonly OpCode Starg = new OpCode(OpCodeValues.Starg, -257680722);

		/// <summary>Loads the local variable at a specific index onto the evaluation stack.</summary>
		// Token: 0x04002065 RID: 8293
		[__DynamicallyInvokable]
		public static readonly OpCode Ldloc = new OpCode(OpCodeValues.Ldloc, 279317166);

		/// <summary>Loads the address of the local variable at a specific index onto the evaluation stack.</summary>
		// Token: 0x04002066 RID: 8294
		[__DynamicallyInvokable]
		public static readonly OpCode Ldloca = new OpCode(OpCodeValues.Ldloca, 279579310);

		/// <summary>Pops the current value from the top of the evaluation stack and stores it in a the local variable list at a specified index.</summary>
		// Token: 0x04002067 RID: 8295
		[__DynamicallyInvokable]
		public static readonly OpCode Stloc = new OpCode(OpCodeValues.Stloc, -257680722);

		/// <summary>Allocates a certain number of bytes from the local dynamic memory pool and pushes the address (a transient pointer, type <see langword="*" />) of the first allocated byte onto the evaluation stack.</summary>
		// Token: 0x04002068 RID: 8296
		[__DynamicallyInvokable]
		public static readonly OpCode Localloc = new OpCode(OpCodeValues.Localloc, 11156133);

		/// <summary>Transfers control from the <see langword="filter" /> clause of an exception back to the Common Language Infrastructure (CLI) exception handler.</summary>
		// Token: 0x04002069 RID: 8297
		[__DynamicallyInvokable]
		public static readonly OpCode Endfilter = new OpCode(OpCodeValues.Endfilter, -240895259);

		/// <summary>Indicates that an address currently atop the evaluation stack might not be aligned to the natural size of the immediately following <see langword="ldind" />, <see langword="stind" />, <see langword="ldfld" />, <see langword="stfld" />, <see langword="ldobj" />, <see langword="stobj" />, <see langword="initblk" />, or <see langword="cpblk" /> instruction.</summary>
		// Token: 0x0400206A RID: 8298
		[__DynamicallyInvokable]
		public static readonly OpCode Unaligned = new OpCode(OpCodeValues.Unaligned_, 10750096);

		/// <summary>Specifies that an address currently atop the evaluation stack might be volatile, and the results of reading that location cannot be cached or that multiple stores to that location cannot be suppressed.</summary>
		// Token: 0x0400206B RID: 8299
		[__DynamicallyInvokable]
		public static readonly OpCode Volatile = new OpCode(OpCodeValues.Volatile_, 10750085);

		/// <summary>Performs a postfixed method call instruction such that the current method's stack frame is removed before the actual call instruction is executed.</summary>
		// Token: 0x0400206C RID: 8300
		[__DynamicallyInvokable]
		public static readonly OpCode Tailcall = new OpCode(OpCodeValues.Tail_, 10750085);

		/// <summary>Initializes each field of the value type at a specified address to a null reference or a 0 of the appropriate primitive type.</summary>
		// Token: 0x0400206D RID: 8301
		[__DynamicallyInvokable]
		public static readonly OpCode Initobj = new OpCode(OpCodeValues.Initobj, -257673555);

		/// <summary>Constrains the type on which a virtual method call is made.</summary>
		// Token: 0x0400206E RID: 8302
		[__DynamicallyInvokable]
		public static readonly OpCode Constrained = new OpCode(OpCodeValues.Constrained_, 10750093);

		/// <summary>Copies a specified number bytes from a source address to a destination address.</summary>
		// Token: 0x0400206F RID: 8303
		[__DynamicallyInvokable]
		public static readonly OpCode Cpblk = new OpCode(OpCodeValues.Cpblk, -794527067);

		/// <summary>Initializes a specified block of memory at a specific address to a given size and initial value.</summary>
		// Token: 0x04002070 RID: 8304
		[__DynamicallyInvokable]
		public static readonly OpCode Initblk = new OpCode(OpCodeValues.Initblk, -794527067);

		/// <summary>Rethrows the current exception.</summary>
		// Token: 0x04002071 RID: 8305
		[__DynamicallyInvokable]
		public static readonly OpCode Rethrow = new OpCode(OpCodeValues.Rethrow, 27526917);

		/// <summary>Pushes the size, in bytes, of a supplied value type onto the evaluation stack.</summary>
		// Token: 0x04002072 RID: 8306
		[__DynamicallyInvokable]
		public static readonly OpCode Sizeof = new OpCode(OpCodeValues.Sizeof, 279579309);

		/// <summary>Retrieves the type token embedded in a typed reference.</summary>
		// Token: 0x04002073 RID: 8307
		[__DynamicallyInvokable]
		public static readonly OpCode Refanytype = new OpCode(OpCodeValues.Refanytype, 11147941);

		/// <summary>Specifies that the subsequent array address operation performs no type check at run time, and that it returns a managed pointer whose mutability is restricted.</summary>
		// Token: 0x04002074 RID: 8308
		[__DynamicallyInvokable]
		public static readonly OpCode Readonly = new OpCode(OpCodeValues.Readonly_, 10750085);
	}
}
