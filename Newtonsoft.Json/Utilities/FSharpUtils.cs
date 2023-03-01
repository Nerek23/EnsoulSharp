using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x0200005A RID: 90
	[NullableContext(1)]
	[Nullable(0)]
	internal class FSharpUtils
	{
		// Token: 0x06000523 RID: 1315 RVA: 0x000161D0 File Offset: 0x000143D0
		private FSharpUtils(Assembly fsharpCoreAssembly)
		{
			this.FSharpCoreAssembly = fsharpCoreAssembly;
			Type type = fsharpCoreAssembly.GetType("Microsoft.FSharp.Reflection.FSharpType");
			MethodInfo methodWithNonPublicFallback = FSharpUtils.GetMethodWithNonPublicFallback(type, "IsUnion", BindingFlags.Static | BindingFlags.Public);
			this.IsUnion = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>(methodWithNonPublicFallback);
			MethodInfo methodWithNonPublicFallback2 = FSharpUtils.GetMethodWithNonPublicFallback(type, "GetUnionCases", BindingFlags.Static | BindingFlags.Public);
			this.GetUnionCases = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>(methodWithNonPublicFallback2);
			Type type2 = fsharpCoreAssembly.GetType("Microsoft.FSharp.Reflection.FSharpValue");
			this.PreComputeUnionTagReader = FSharpUtils.CreateFSharpFuncCall(type2, "PreComputeUnionTagReader");
			this.PreComputeUnionReader = FSharpUtils.CreateFSharpFuncCall(type2, "PreComputeUnionReader");
			this.PreComputeUnionConstructor = FSharpUtils.CreateFSharpFuncCall(type2, "PreComputeUnionConstructor");
			Type type3 = fsharpCoreAssembly.GetType("Microsoft.FSharp.Reflection.UnionCaseInfo");
			this.GetUnionCaseInfoName = JsonTypeReflector.ReflectionDelegateFactory.CreateGet<object>(type3.GetProperty("Name"));
			this.GetUnionCaseInfoTag = JsonTypeReflector.ReflectionDelegateFactory.CreateGet<object>(type3.GetProperty("Tag"));
			this.GetUnionCaseInfoDeclaringType = JsonTypeReflector.ReflectionDelegateFactory.CreateGet<object>(type3.GetProperty("DeclaringType"));
			this.GetUnionCaseInfoFields = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>(type3.GetMethod("GetFields"));
			Type type4 = fsharpCoreAssembly.GetType("Microsoft.FSharp.Collections.ListModule");
			this._ofSeq = type4.GetMethod("OfSeq");
			this._mapType = fsharpCoreAssembly.GetType("Microsoft.FSharp.Collections.FSharpMap`2");
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x00016319 File Offset: 0x00014519
		public static FSharpUtils Instance
		{
			get
			{
				return FSharpUtils._instance;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x00016320 File Offset: 0x00014520
		// (set) Token: 0x06000526 RID: 1318 RVA: 0x00016328 File Offset: 0x00014528
		public Assembly FSharpCoreAssembly { get; private set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x00016331 File Offset: 0x00014531
		// (set) Token: 0x06000528 RID: 1320 RVA: 0x00016339 File Offset: 0x00014539
		[Nullable(new byte[]
		{
			1,
			2,
			1
		})]
		public MethodCall<object, object> IsUnion { [return: Nullable(new byte[]
		{
			1,
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			1,
			2,
			1
		})] private set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x00016342 File Offset: 0x00014542
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x0001634A File Offset: 0x0001454A
		[Nullable(new byte[]
		{
			1,
			2,
			1
		})]
		public MethodCall<object, object> GetUnionCases { [return: Nullable(new byte[]
		{
			1,
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			1,
			2,
			1
		})] private set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x00016353 File Offset: 0x00014553
		// (set) Token: 0x0600052C RID: 1324 RVA: 0x0001635B File Offset: 0x0001455B
		[Nullable(new byte[]
		{
			1,
			2,
			1
		})]
		public MethodCall<object, object> PreComputeUnionTagReader { [return: Nullable(new byte[]
		{
			1,
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			1,
			2,
			1
		})] private set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x00016364 File Offset: 0x00014564
		// (set) Token: 0x0600052E RID: 1326 RVA: 0x0001636C File Offset: 0x0001456C
		[Nullable(new byte[]
		{
			1,
			2,
			1
		})]
		public MethodCall<object, object> PreComputeUnionReader { [return: Nullable(new byte[]
		{
			1,
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			1,
			2,
			1
		})] private set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x00016375 File Offset: 0x00014575
		// (set) Token: 0x06000530 RID: 1328 RVA: 0x0001637D File Offset: 0x0001457D
		[Nullable(new byte[]
		{
			1,
			2,
			1
		})]
		public MethodCall<object, object> PreComputeUnionConstructor { [return: Nullable(new byte[]
		{
			1,
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			1,
			2,
			1
		})] private set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x00016386 File Offset: 0x00014586
		// (set) Token: 0x06000532 RID: 1330 RVA: 0x0001638E File Offset: 0x0001458E
		public Func<object, object> GetUnionCaseInfoDeclaringType { get; private set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x00016397 File Offset: 0x00014597
		// (set) Token: 0x06000534 RID: 1332 RVA: 0x0001639F File Offset: 0x0001459F
		public Func<object, object> GetUnionCaseInfoName { get; private set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x000163A8 File Offset: 0x000145A8
		// (set) Token: 0x06000536 RID: 1334 RVA: 0x000163B0 File Offset: 0x000145B0
		public Func<object, object> GetUnionCaseInfoTag { get; private set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x000163B9 File Offset: 0x000145B9
		// (set) Token: 0x06000538 RID: 1336 RVA: 0x000163C1 File Offset: 0x000145C1
		[Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		public MethodCall<object, object> GetUnionCaseInfoFields { [return: Nullable(new byte[]
		{
			1,
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			1,
			1,
			2
		})] private set; }

		// Token: 0x06000539 RID: 1337 RVA: 0x000163CC File Offset: 0x000145CC
		public static void EnsureInitialized(Assembly fsharpCoreAssembly)
		{
			if (FSharpUtils._instance == null)
			{
				object @lock = FSharpUtils.Lock;
				lock (@lock)
				{
					if (FSharpUtils._instance == null)
					{
						FSharpUtils._instance = new FSharpUtils(fsharpCoreAssembly);
					}
				}
			}
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00016420 File Offset: 0x00014620
		private static MethodInfo GetMethodWithNonPublicFallback(Type type, string methodName, BindingFlags bindingFlags)
		{
			MethodInfo method = type.GetMethod(methodName, bindingFlags);
			if (method == null && (bindingFlags & BindingFlags.NonPublic) != BindingFlags.NonPublic)
			{
				method = type.GetMethod(methodName, bindingFlags | BindingFlags.NonPublic);
			}
			return method;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00016454 File Offset: 0x00014654
		[return: Nullable(new byte[]
		{
			1,
			2,
			1
		})]
		private static MethodCall<object, object> CreateFSharpFuncCall(Type type, string methodName)
		{
			MethodInfo methodWithNonPublicFallback = FSharpUtils.GetMethodWithNonPublicFallback(type, methodName, BindingFlags.Static | BindingFlags.Public);
			MethodInfo method = methodWithNonPublicFallback.ReturnType.GetMethod("Invoke", BindingFlags.Instance | BindingFlags.Public);
			MethodCall<object, object> call = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>(methodWithNonPublicFallback);
			MethodCall<object, object> invoke = JsonTypeReflector.ReflectionDelegateFactory.CreateMethodCall<object>(method);
			return ([Nullable(2)] object target, [Nullable(new byte[]
			{
				1,
				2
			})] object[] args) => new FSharpFunction(call(target, args), invoke);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x000164B0 File Offset: 0x000146B0
		public ObjectConstructor<object> CreateSeq(Type t)
		{
			MethodInfo method = this._ofSeq.MakeGenericMethod(new Type[]
			{
				t
			});
			return JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor(method);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x000164DE File Offset: 0x000146DE
		public ObjectConstructor<object> CreateMap(Type keyType, Type valueType)
		{
			return (ObjectConstructor<object>)typeof(FSharpUtils).GetMethod("BuildMapCreator").MakeGenericMethod(new Type[]
			{
				keyType,
				valueType
			}).Invoke(this, null);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00016514 File Offset: 0x00014714
		[NullableContext(2)]
		[return: Nullable(1)]
		public ObjectConstructor<object> BuildMapCreator<TKey, TValue>()
		{
			ConstructorInfo constructor = this._mapType.MakeGenericType(new Type[]
			{
				typeof(TKey),
				typeof(TValue)
			}).GetConstructor(new Type[]
			{
				typeof(IEnumerable<Tuple<TKey, TValue>>)
			});
			ObjectConstructor<object> ctorDelegate = JsonTypeReflector.ReflectionDelegateFactory.CreateParameterizedConstructor(constructor);
			return delegate([Nullable(new byte[]
			{
				1,
				2
			})] object[] args)
			{
				IEnumerable<Tuple<TKey, TValue>> enumerable = from kv in (IEnumerable<KeyValuePair<TKey, TValue>>)args[0]
				select new Tuple<TKey, TValue>(kv.Key, kv.Value);
				return ctorDelegate(new object[]
				{
					enumerable
				});
			};
		}

		// Token: 0x040001CC RID: 460
		private static readonly object Lock = new object();

		// Token: 0x040001CD RID: 461
		[Nullable(2)]
		private static FSharpUtils _instance;

		// Token: 0x040001CE RID: 462
		private MethodInfo _ofSeq;

		// Token: 0x040001CF RID: 463
		private Type _mapType;

		// Token: 0x040001DA RID: 474
		public const string FSharpSetTypeName = "FSharpSet`1";

		// Token: 0x040001DB RID: 475
		public const string FSharpListTypeName = "FSharpList`1";

		// Token: 0x040001DC RID: 476
		public const string FSharpMapTypeName = "FSharpMap`2";
	}
}
