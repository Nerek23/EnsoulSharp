using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x0200006F RID: 111
	[NullableContext(1)]
	[Nullable(0)]
	internal static class TypeExtensions
	{
		// Token: 0x060005F4 RID: 1524 RVA: 0x00019550 File Offset: 0x00017750
		public static MethodInfo Method(this Delegate d)
		{
			return d.Method;
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00019558 File Offset: 0x00017758
		public static MemberTypes MemberType(this MemberInfo memberInfo)
		{
			return memberInfo.MemberType;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00019560 File Offset: 0x00017760
		public static bool ContainsGenericParameters(this Type type)
		{
			return type.ContainsGenericParameters;
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00019568 File Offset: 0x00017768
		public static bool IsInterface(this Type type)
		{
			return type.IsInterface;
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x00019570 File Offset: 0x00017770
		public static bool IsGenericType(this Type type)
		{
			return type.IsGenericType;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00019578 File Offset: 0x00017778
		public static bool IsGenericTypeDefinition(this Type type)
		{
			return type.IsGenericTypeDefinition;
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00019580 File Offset: 0x00017780
		public static Type BaseType(this Type type)
		{
			return type.BaseType;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00019588 File Offset: 0x00017788
		public static Assembly Assembly(this Type type)
		{
			return type.Assembly;
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00019590 File Offset: 0x00017790
		public static bool IsEnum(this Type type)
		{
			return type.IsEnum;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00019598 File Offset: 0x00017798
		public static bool IsClass(this Type type)
		{
			return type.IsClass;
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x000195A0 File Offset: 0x000177A0
		public static bool IsSealed(this Type type)
		{
			return type.IsSealed;
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x000195A8 File Offset: 0x000177A8
		public static bool IsAbstract(this Type type)
		{
			return type.IsAbstract;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x000195B0 File Offset: 0x000177B0
		public static bool IsVisible(this Type type)
		{
			return type.IsVisible;
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x000195B8 File Offset: 0x000177B8
		public static bool IsValueType(this Type type)
		{
			return type.IsValueType;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x000195C0 File Offset: 0x000177C0
		public static bool IsPrimitive(this Type type)
		{
			return type.IsPrimitive;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x000195C8 File Offset: 0x000177C8
		public static bool AssignableToTypeName(this Type type, string fullTypeName, bool searchInterfaces, [Nullable(2)] [NotNullWhen(true)] out Type match)
		{
			Type type2 = type;
			while (type2 != null)
			{
				if (string.Equals(type2.FullName, fullTypeName, StringComparison.Ordinal))
				{
					match = type2;
					return true;
				}
				type2 = type2.BaseType();
			}
			if (searchInterfaces)
			{
				Type[] interfaces = type.GetInterfaces();
				for (int i = 0; i < interfaces.Length; i++)
				{
					if (string.Equals(interfaces[i].Name, fullTypeName, StringComparison.Ordinal))
					{
						match = type;
						return true;
					}
				}
			}
			match = null;
			return false;
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00019630 File Offset: 0x00017830
		public static bool AssignableToTypeName(this Type type, string fullTypeName, bool searchInterfaces)
		{
			Type type2;
			return type.AssignableToTypeName(fullTypeName, searchInterfaces, out type2);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00019648 File Offset: 0x00017848
		public static bool ImplementInterface(this Type type, Type interfaceType)
		{
			Type type2 = type;
			while (type2 != null)
			{
				foreach (Type type3 in ((IEnumerable<Type>)type2.GetInterfaces()))
				{
					if (type3 == interfaceType || (type3 != null && type3.ImplementInterface(interfaceType)))
					{
						return true;
					}
				}
				type2 = type2.BaseType();
			}
			return false;
		}
	}
}
