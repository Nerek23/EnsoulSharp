using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x0200005B RID: 91
	[NullableContext(1)]
	[Nullable(0)]
	internal static class ILGeneratorExtensions
	{
		// Token: 0x06000540 RID: 1344 RVA: 0x00016594 File Offset: 0x00014794
		public static void PushInstance(this ILGenerator generator, Type type)
		{
			generator.Emit(OpCodes.Ldarg_0);
			if (type.IsValueType())
			{
				generator.Emit(OpCodes.Unbox, type);
				return;
			}
			generator.Emit(OpCodes.Castclass, type);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x000165C2 File Offset: 0x000147C2
		public static void PushArrayInstance(this ILGenerator generator, int argsIndex, int arrayIndex)
		{
			generator.Emit(OpCodes.Ldarg, argsIndex);
			generator.Emit(OpCodes.Ldc_I4, arrayIndex);
			generator.Emit(OpCodes.Ldelem_Ref);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x000165E7 File Offset: 0x000147E7
		public static void BoxIfNeeded(this ILGenerator generator, Type type)
		{
			if (type.IsValueType())
			{
				generator.Emit(OpCodes.Box, type);
				return;
			}
			generator.Emit(OpCodes.Castclass, type);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001660A File Offset: 0x0001480A
		public static void UnboxIfNeeded(this ILGenerator generator, Type type)
		{
			if (type.IsValueType())
			{
				generator.Emit(OpCodes.Unbox_Any, type);
				return;
			}
			generator.Emit(OpCodes.Castclass, type);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0001662D File Offset: 0x0001482D
		public static void CallMethod(this ILGenerator generator, MethodInfo methodInfo)
		{
			if (methodInfo.IsFinal || !methodInfo.IsVirtual)
			{
				generator.Emit(OpCodes.Call, methodInfo);
				return;
			}
			generator.Emit(OpCodes.Callvirt, methodInfo);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00016658 File Offset: 0x00014858
		public static void Return(this ILGenerator generator)
		{
			generator.Emit(OpCodes.Ret);
		}
	}
}
