using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x02000060 RID: 96
	[NullableContext(1)]
	[Nullable(0)]
	internal class LateBoundReflectionDelegateFactory : ReflectionDelegateFactory
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0001734F File Offset: 0x0001554F
		internal static ReflectionDelegateFactory Instance
		{
			get
			{
				return LateBoundReflectionDelegateFactory._instance;
			}
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00017358 File Offset: 0x00015558
		public override ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method)
		{
			ValidationUtils.ArgumentNotNull(method, "method");
			ConstructorInfo c = method as ConstructorInfo;
			if (c != null)
			{
				return ([Nullable(new byte[]
				{
					1,
					2
				})] object[] a) => c.Invoke(a);
			}
			return ([Nullable(new byte[]
			{
				1,
				2
			})] object[] a) => method.Invoke(null, a);
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x000173B4 File Offset: 0x000155B4
		[return: Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		public override MethodCall<T, object> CreateMethodCall<[Nullable(2)] T>(MethodBase method)
		{
			ValidationUtils.ArgumentNotNull(method, "method");
			ConstructorInfo c = method as ConstructorInfo;
			if (c != null)
			{
				return (T o, [Nullable(new byte[]
				{
					1,
					2
				})] object[] a) => c.Invoke(a);
			}
			return (T o, [Nullable(new byte[]
			{
				1,
				2
			})] object[] a) => method.Invoke(o, a);
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00017410 File Offset: 0x00015610
		public override Func<T> CreateDefaultConstructor<[Nullable(2)] T>(Type type)
		{
			ValidationUtils.ArgumentNotNull(type, "type");
			if (type.IsValueType())
			{
				return () => (T)((object)Activator.CreateInstance(type));
			}
			ConstructorInfo constructorInfo = ReflectionUtils.GetDefaultConstructor(type, true);
			return () => (T)((object)constructorInfo.Invoke(null));
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x00017472 File Offset: 0x00015672
		[return: Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		public override Func<T, object> CreateGet<[Nullable(2)] T>(PropertyInfo propertyInfo)
		{
			ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
			return (T o) => propertyInfo.GetValue(o, null);
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0001749B File Offset: 0x0001569B
		[return: Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		public override Func<T, object> CreateGet<[Nullable(2)] T>(FieldInfo fieldInfo)
		{
			ValidationUtils.ArgumentNotNull(fieldInfo, "fieldInfo");
			return (T o) => fieldInfo.GetValue(o);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x000174C4 File Offset: 0x000156C4
		[return: Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		public override Action<T, object> CreateSet<[Nullable(2)] T>(FieldInfo fieldInfo)
		{
			ValidationUtils.ArgumentNotNull(fieldInfo, "fieldInfo");
			return delegate(T o, [Nullable(2)] object v)
			{
				fieldInfo.SetValue(o, v);
			};
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x000174ED File Offset: 0x000156ED
		[return: Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		public override Action<T, object> CreateSet<[Nullable(2)] T>(PropertyInfo propertyInfo)
		{
			ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
			return delegate(T o, [Nullable(2)] object v)
			{
				propertyInfo.SetValue(o, v, null);
			};
		}

		// Token: 0x040001F9 RID: 505
		private static readonly LateBoundReflectionDelegateFactory _instance = new LateBoundReflectionDelegateFactory();
	}
}
