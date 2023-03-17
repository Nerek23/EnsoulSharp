﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace System
{
	/// <summary>Represents the base class for custom attributes.</summary>
	// Token: 0x020000AD RID: 173
	[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Attribute))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class Attribute : _Attribute
	{
		// Token: 0x060009CA RID: 2506 RVA: 0x0001F744 File Offset: 0x0001D944
		private static Attribute[] InternalGetCustomAttributes(PropertyInfo element, Type type, bool inherit)
		{
			Attribute[] array = (Attribute[])element.GetCustomAttributes(type, inherit);
			if (!inherit)
			{
				return array;
			}
			Dictionary<Type, AttributeUsageAttribute> types = new Dictionary<Type, AttributeUsageAttribute>(11);
			List<Attribute> list = new List<Attribute>();
			Attribute.CopyToArrayList(list, array, types);
			Type[] indexParameterTypes = Attribute.GetIndexParameterTypes(element);
			PropertyInfo parentDefinition = Attribute.GetParentDefinition(element, indexParameterTypes);
			while (parentDefinition != null)
			{
				array = Attribute.GetCustomAttributes(parentDefinition, type, false);
				Attribute.AddAttributesToList(list, array, types);
				parentDefinition = Attribute.GetParentDefinition(parentDefinition, indexParameterTypes);
			}
			Array array2 = Attribute.CreateAttributeArrayHelper(type, list.Count);
			Array.Copy(list.ToArray(), 0, array2, 0, list.Count);
			return (Attribute[])array2;
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x0001F7DC File Offset: 0x0001D9DC
		private static bool InternalIsDefined(PropertyInfo element, Type attributeType, bool inherit)
		{
			if (element.IsDefined(attributeType, inherit))
			{
				return true;
			}
			if (inherit)
			{
				AttributeUsageAttribute attributeUsageAttribute = Attribute.InternalGetAttributeUsage(attributeType);
				if (!attributeUsageAttribute.Inherited)
				{
					return false;
				}
				Type[] indexParameterTypes = Attribute.GetIndexParameterTypes(element);
				PropertyInfo parentDefinition = Attribute.GetParentDefinition(element, indexParameterTypes);
				while (parentDefinition != null)
				{
					if (parentDefinition.IsDefined(attributeType, false))
					{
						return true;
					}
					parentDefinition = Attribute.GetParentDefinition(parentDefinition, indexParameterTypes);
				}
			}
			return false;
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x0001F838 File Offset: 0x0001DA38
		private static PropertyInfo GetParentDefinition(PropertyInfo property, Type[] propertyParameters)
		{
			MethodInfo methodInfo = property.GetGetMethod(true);
			if (methodInfo == null)
			{
				methodInfo = property.GetSetMethod(true);
			}
			RuntimeMethodInfo runtimeMethodInfo = methodInfo as RuntimeMethodInfo;
			if (runtimeMethodInfo != null)
			{
				runtimeMethodInfo = runtimeMethodInfo.GetParentDefinition();
				if (runtimeMethodInfo != null)
				{
					return runtimeMethodInfo.DeclaringType.GetProperty(property.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, property.PropertyType, propertyParameters, null);
				}
			}
			return null;
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x0001F89C File Offset: 0x0001DA9C
		private static Attribute[] InternalGetCustomAttributes(EventInfo element, Type type, bool inherit)
		{
			Attribute[] array = (Attribute[])element.GetCustomAttributes(type, inherit);
			if (inherit)
			{
				Dictionary<Type, AttributeUsageAttribute> types = new Dictionary<Type, AttributeUsageAttribute>(11);
				List<Attribute> list = new List<Attribute>();
				Attribute.CopyToArrayList(list, array, types);
				EventInfo parentDefinition = Attribute.GetParentDefinition(element);
				while (parentDefinition != null)
				{
					array = Attribute.GetCustomAttributes(parentDefinition, type, false);
					Attribute.AddAttributesToList(list, array, types);
					parentDefinition = Attribute.GetParentDefinition(parentDefinition);
				}
				Array array2 = Attribute.CreateAttributeArrayHelper(type, list.Count);
				Array.Copy(list.ToArray(), 0, array2, 0, list.Count);
				return (Attribute[])array2;
			}
			return array;
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0001F928 File Offset: 0x0001DB28
		private static EventInfo GetParentDefinition(EventInfo ev)
		{
			MethodInfo addMethod = ev.GetAddMethod(true);
			RuntimeMethodInfo runtimeMethodInfo = addMethod as RuntimeMethodInfo;
			if (runtimeMethodInfo != null)
			{
				runtimeMethodInfo = runtimeMethodInfo.GetParentDefinition();
				if (runtimeMethodInfo != null)
				{
					return runtimeMethodInfo.DeclaringType.GetEvent(ev.Name);
				}
			}
			return null;
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0001F970 File Offset: 0x0001DB70
		private static bool InternalIsDefined(EventInfo element, Type attributeType, bool inherit)
		{
			if (element.IsDefined(attributeType, inherit))
			{
				return true;
			}
			if (inherit)
			{
				AttributeUsageAttribute attributeUsageAttribute = Attribute.InternalGetAttributeUsage(attributeType);
				if (!attributeUsageAttribute.Inherited)
				{
					return false;
				}
				EventInfo parentDefinition = Attribute.GetParentDefinition(element);
				while (parentDefinition != null)
				{
					if (parentDefinition.IsDefined(attributeType, false))
					{
						return true;
					}
					parentDefinition = Attribute.GetParentDefinition(parentDefinition);
				}
			}
			return false;
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0001F9C4 File Offset: 0x0001DBC4
		private static ParameterInfo GetParentDefinition(ParameterInfo param)
		{
			RuntimeMethodInfo runtimeMethodInfo = param.Member as RuntimeMethodInfo;
			if (runtimeMethodInfo != null)
			{
				runtimeMethodInfo = runtimeMethodInfo.GetParentDefinition();
				if (runtimeMethodInfo != null)
				{
					ParameterInfo[] parameters = runtimeMethodInfo.GetParameters();
					return parameters[param.Position];
				}
			}
			return null;
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x0001FA08 File Offset: 0x0001DC08
		private static Attribute[] InternalParamGetCustomAttributes(ParameterInfo param, Type type, bool inherit)
		{
			List<Type> list = new List<Type>();
			if (type == null)
			{
				type = typeof(Attribute);
			}
			object[] customAttributes = param.GetCustomAttributes(type, false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				Type type2 = customAttributes[i].GetType();
				AttributeUsageAttribute attributeUsageAttribute = Attribute.InternalGetAttributeUsage(type2);
				if (!attributeUsageAttribute.AllowMultiple)
				{
					list.Add(type2);
				}
			}
			Attribute[] array;
			if (customAttributes.Length == 0)
			{
				array = Attribute.CreateAttributeArrayHelper(type, 0);
			}
			else
			{
				array = (Attribute[])customAttributes;
			}
			if (param.Member.DeclaringType == null)
			{
				return array;
			}
			if (!inherit)
			{
				return array;
			}
			for (ParameterInfo parentDefinition = Attribute.GetParentDefinition(param); parentDefinition != null; parentDefinition = Attribute.GetParentDefinition(parentDefinition))
			{
				customAttributes = parentDefinition.GetCustomAttributes(type, false);
				int num = 0;
				for (int j = 0; j < customAttributes.Length; j++)
				{
					Type type3 = customAttributes[j].GetType();
					AttributeUsageAttribute attributeUsageAttribute2 = Attribute.InternalGetAttributeUsage(type3);
					if (attributeUsageAttribute2.Inherited && !list.Contains(type3))
					{
						if (!attributeUsageAttribute2.AllowMultiple)
						{
							list.Add(type3);
						}
						num++;
					}
					else
					{
						customAttributes[j] = null;
					}
				}
				Attribute[] array2 = Attribute.CreateAttributeArrayHelper(type, num);
				num = 0;
				for (int k = 0; k < customAttributes.Length; k++)
				{
					if (customAttributes[k] != null)
					{
						array2[num] = (Attribute)customAttributes[k];
						num++;
					}
				}
				Attribute[] array3 = array;
				array = Attribute.CreateAttributeArrayHelper(type, array3.Length + num);
				Array.Copy(array3, array, array3.Length);
				int num2 = array3.Length;
				for (int l = 0; l < array2.Length; l++)
				{
					array[num2 + l] = array2[l];
				}
			}
			return array;
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0001FB9C File Offset: 0x0001DD9C
		private static bool InternalParamIsDefined(ParameterInfo param, Type type, bool inherit)
		{
			if (param.IsDefined(type, false))
			{
				return true;
			}
			if (param.Member.DeclaringType == null || !inherit)
			{
				return false;
			}
			for (ParameterInfo parentDefinition = Attribute.GetParentDefinition(param); parentDefinition != null; parentDefinition = Attribute.GetParentDefinition(parentDefinition))
			{
				object[] customAttributes = parentDefinition.GetCustomAttributes(type, false);
				for (int i = 0; i < customAttributes.Length; i++)
				{
					Type type2 = customAttributes[i].GetType();
					AttributeUsageAttribute attributeUsageAttribute = Attribute.InternalGetAttributeUsage(type2);
					if (customAttributes[i] is Attribute && attributeUsageAttribute.Inherited)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0001FC20 File Offset: 0x0001DE20
		private static void CopyToArrayList(List<Attribute> attributeList, Attribute[] attributes, Dictionary<Type, AttributeUsageAttribute> types)
		{
			for (int i = 0; i < attributes.Length; i++)
			{
				attributeList.Add(attributes[i]);
				Type type = attributes[i].GetType();
				if (!types.ContainsKey(type))
				{
					types[type] = Attribute.InternalGetAttributeUsage(type);
				}
			}
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0001FC64 File Offset: 0x0001DE64
		private static Type[] GetIndexParameterTypes(PropertyInfo element)
		{
			ParameterInfo[] indexParameters = element.GetIndexParameters();
			if (indexParameters.Length != 0)
			{
				Type[] array = new Type[indexParameters.Length];
				for (int i = 0; i < indexParameters.Length; i++)
				{
					array[i] = indexParameters[i].ParameterType;
				}
				return array;
			}
			return Array.Empty<Type>();
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0001FCA8 File Offset: 0x0001DEA8
		private static void AddAttributesToList(List<Attribute> attributeList, Attribute[] attributes, Dictionary<Type, AttributeUsageAttribute> types)
		{
			for (int i = 0; i < attributes.Length; i++)
			{
				Type type = attributes[i].GetType();
				AttributeUsageAttribute attributeUsageAttribute = null;
				types.TryGetValue(type, out attributeUsageAttribute);
				if (attributeUsageAttribute == null)
				{
					attributeUsageAttribute = Attribute.InternalGetAttributeUsage(type);
					types[type] = attributeUsageAttribute;
					if (attributeUsageAttribute.Inherited)
					{
						attributeList.Add(attributes[i]);
					}
				}
				else if (attributeUsageAttribute.Inherited && attributeUsageAttribute.AllowMultiple)
				{
					attributeList.Add(attributes[i]);
				}
			}
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0001FD18 File Offset: 0x0001DF18
		private static AttributeUsageAttribute InternalGetAttributeUsage(Type type)
		{
			object[] customAttributes = type.GetCustomAttributes(typeof(AttributeUsageAttribute), false);
			if (customAttributes.Length == 1)
			{
				return (AttributeUsageAttribute)customAttributes[0];
			}
			if (customAttributes.Length == 0)
			{
				return AttributeUsageAttribute.Default;
			}
			throw new FormatException(Environment.GetResourceString("Format_AttributeUsage", new object[]
			{
				type
			}));
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0001FD69 File Offset: 0x0001DF69
		[SecuritySafeCritical]
		private static Attribute[] CreateAttributeArrayHelper(Type elementType, int elementCount)
		{
			return (Attribute[])Array.UnsafeCreateInstance(elementType, elementCount);
		}

		/// <summary>Retrieves an array of the custom attributes applied to a member of a type. Parameters specify the member, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.MemberInfo" /> class that describes a constructor, event, field, method, or property member of a class.</param>
		/// <param name="type">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes of type <paramref name="type" /> applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="type" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="type" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="element" /> is not a constructor, method, property, event, type, or field.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009D8 RID: 2520 RVA: 0x0001FD77 File Offset: 0x0001DF77
		[__DynamicallyInvokable]
		public static Attribute[] GetCustomAttributes(MemberInfo element, Type type)
		{
			return Attribute.GetCustomAttributes(element, type, true);
		}

		/// <summary>Retrieves an array of the custom attributes applied to a member of a type. Parameters specify the member, the type of the custom attribute to search for, and whether to search ancestors of the member.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.MemberInfo" /> class that describes a constructor, event, field, method, or property member of a class.</param>
		/// <param name="type">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of <paramref name="element" /> for custom attributes.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes of type <paramref name="type" /> applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="type" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="type" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="element" /> is not a constructor, method, property, event, type, or field.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009D9 RID: 2521 RVA: 0x0001FD84 File Offset: 0x0001DF84
		[__DynamicallyInvokable]
		public static Attribute[] GetCustomAttributes(MemberInfo element, Type type, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (!type.IsSubclassOf(typeof(Attribute)) && type != typeof(Attribute))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustHaveAttributeBaseClass"));
			}
			MemberTypes memberType = element.MemberType;
			if (memberType == MemberTypes.Event)
			{
				return Attribute.InternalGetCustomAttributes((EventInfo)element, type, inherit);
			}
			if (memberType == MemberTypes.Property)
			{
				return Attribute.InternalGetCustomAttributes((PropertyInfo)element, type, inherit);
			}
			return element.GetCustomAttributes(type, inherit) as Attribute[];
		}

		/// <summary>Retrieves an array of the custom attributes applied to a member of a type. A parameter specifies the member.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.MemberInfo" /> class that describes a constructor, event, field, method, or property member of a class.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="element" /> is not a constructor, method, property, event, type, or field.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009DA RID: 2522 RVA: 0x0001FE26 File Offset: 0x0001E026
		[__DynamicallyInvokable]
		public static Attribute[] GetCustomAttributes(MemberInfo element)
		{
			return Attribute.GetCustomAttributes(element, true);
		}

		/// <summary>Retrieves an array of the custom attributes applied to a member of a type. Parameters specify the member, the type of the custom attribute to search for, and whether to search ancestors of the member.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.MemberInfo" /> class that describes a constructor, event, field, method, or property member of a class.</param>
		/// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of <paramref name="element" /> for custom attributes.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="element" /> is not a constructor, method, property, event, type, or field.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009DB RID: 2523 RVA: 0x0001FE30 File Offset: 0x0001E030
		[__DynamicallyInvokable]
		public static Attribute[] GetCustomAttributes(MemberInfo element, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			MemberTypes memberType = element.MemberType;
			if (memberType == MemberTypes.Event)
			{
				return Attribute.InternalGetCustomAttributes((EventInfo)element, typeof(Attribute), inherit);
			}
			if (memberType == MemberTypes.Property)
			{
				return Attribute.InternalGetCustomAttributes((PropertyInfo)element, typeof(Attribute), inherit);
			}
			return element.GetCustomAttributes(typeof(Attribute), inherit) as Attribute[];
		}

		/// <summary>Determines whether any custom attributes are applied to a member of a type. Parameters specify the member, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.MemberInfo" /> class that describes a constructor, event, field, method, type, or property member of a class.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>
		///   <see langword="true" /> if a custom attribute of type <paramref name="attributeType" /> is applied to <paramref name="element" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="element" /> is not a constructor, method, property, event, type, or field.</exception>
		// Token: 0x060009DC RID: 2524 RVA: 0x0001FEA5 File Offset: 0x0001E0A5
		[__DynamicallyInvokable]
		public static bool IsDefined(MemberInfo element, Type attributeType)
		{
			return Attribute.IsDefined(element, attributeType, true);
		}

		/// <summary>Determines whether any custom attributes are applied to a member of a type. Parameters specify the member, the type of the custom attribute to search for, and whether to search ancestors of the member.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.MemberInfo" /> class that describes a constructor, event, field, method, type, or property member of a class.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of <paramref name="element" /> for custom attributes.</param>
		/// <returns>
		///   <see langword="true" /> if a custom attribute of type <paramref name="attributeType" /> is applied to <paramref name="element" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="element" /> is not a constructor, method, property, event, type, or field.</exception>
		// Token: 0x060009DD RID: 2525 RVA: 0x0001FEB0 File Offset: 0x0001E0B0
		[__DynamicallyInvokable]
		public static bool IsDefined(MemberInfo element, Type attributeType, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			if (!attributeType.IsSubclassOf(typeof(Attribute)) && attributeType != typeof(Attribute))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustHaveAttributeBaseClass"));
			}
			MemberTypes memberType = element.MemberType;
			if (memberType == MemberTypes.Event)
			{
				return Attribute.InternalIsDefined((EventInfo)element, attributeType, inherit);
			}
			if (memberType == MemberTypes.Property)
			{
				return Attribute.InternalIsDefined((PropertyInfo)element, attributeType, inherit);
			}
			return element.IsDefined(attributeType, inherit);
		}

		/// <summary>Retrieves a custom attribute applied to a member of a type. Parameters specify the member, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.MemberInfo" /> class that describes a constructor, event, field, method, or property member of a class.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>A reference to the single custom attribute of type <paramref name="attributeType" /> that is applied to <paramref name="element" />, or <see langword="null" /> if there is no such attribute.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="element" /> is not a constructor, method, property, event, type, or field.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one of the requested attributes was found.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009DE RID: 2526 RVA: 0x0001FF4D File Offset: 0x0001E14D
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(MemberInfo element, Type attributeType)
		{
			return Attribute.GetCustomAttribute(element, attributeType, true);
		}

		/// <summary>Retrieves a custom attribute applied to a member of a type. Parameters specify the member, the type of the custom attribute to search for, and whether to search ancestors of the member.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.MemberInfo" /> class that describes a constructor, event, field, method, or property member of a class.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of <paramref name="element" /> for custom attributes.</param>
		/// <returns>A reference to the single custom attribute of type <paramref name="attributeType" /> that is applied to <paramref name="element" />, or <see langword="null" /> if there is no such attribute.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="element" /> is not a constructor, method, property, event, type, or field.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one of the requested attributes was found.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009DF RID: 2527 RVA: 0x0001FF58 File Offset: 0x0001E158
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(MemberInfo element, Type attributeType, bool inherit)
		{
			Attribute[] customAttributes = Attribute.GetCustomAttributes(element, attributeType, inherit);
			if (customAttributes == null || customAttributes.Length == 0)
			{
				return null;
			}
			if (customAttributes.Length == 1)
			{
				return customAttributes[0];
			}
			throw new AmbiguousMatchException(Environment.GetResourceString("RFLCT.AmbigCust"));
		}

		/// <summary>Retrieves an array of the custom attributes applied to a method parameter. A parameter specifies the method parameter.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.ParameterInfo" /> class that describes a parameter of a member of a class.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009E0 RID: 2528 RVA: 0x0001FF90 File Offset: 0x0001E190
		[__DynamicallyInvokable]
		public static Attribute[] GetCustomAttributes(ParameterInfo element)
		{
			return Attribute.GetCustomAttributes(element, true);
		}

		/// <summary>Retrieves an array of the custom attributes applied to a method parameter. Parameters specify the method parameter, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.ParameterInfo" /> class that describes a parameter of a member of a class.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes of type <paramref name="attributeType" /> applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009E1 RID: 2529 RVA: 0x0001FF99 File Offset: 0x0001E199
		[__DynamicallyInvokable]
		public static Attribute[] GetCustomAttributes(ParameterInfo element, Type attributeType)
		{
			return Attribute.GetCustomAttributes(element, attributeType, true);
		}

		/// <summary>Retrieves an array of the custom attributes applied to a method parameter. Parameters specify the method parameter, the type of the custom attribute to search for, and whether to search ancestors of the method parameter.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.ParameterInfo" /> class that describes a parameter of a member of a class.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of <paramref name="element" /> for custom attributes.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes of type <paramref name="attributeType" /> applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009E2 RID: 2530 RVA: 0x0001FFA4 File Offset: 0x0001E1A4
		[__DynamicallyInvokable]
		public static Attribute[] GetCustomAttributes(ParameterInfo element, Type attributeType, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			if (!attributeType.IsSubclassOf(typeof(Attribute)) && attributeType != typeof(Attribute))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustHaveAttributeBaseClass"));
			}
			if (element.Member == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidParameterInfo"), "element");
			}
			MemberInfo member = element.Member;
			if (member.MemberType == MemberTypes.Method && inherit)
			{
				return Attribute.InternalParamGetCustomAttributes(element, attributeType, inherit);
			}
			return element.GetCustomAttributes(attributeType, inherit) as Attribute[];
		}

		/// <summary>Retrieves an array of the custom attributes applied to a method parameter. Parameters specify the method parameter, and whether to search ancestors of the method parameter.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.ParameterInfo" /> class that describes a parameter of a member of a class.</param>
		/// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of <paramref name="element" /> for custom attributes.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Reflection.ParameterInfo.Member" /> property of <paramref name="element" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009E3 RID: 2531 RVA: 0x00020054 File Offset: 0x0001E254
		[__DynamicallyInvokable]
		public static Attribute[] GetCustomAttributes(ParameterInfo element, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (element.Member == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidParameterInfo"), "element");
			}
			MemberInfo member = element.Member;
			if (member.MemberType == MemberTypes.Method && inherit)
			{
				return Attribute.InternalParamGetCustomAttributes(element, null, inherit);
			}
			return element.GetCustomAttributes(typeof(Attribute), inherit) as Attribute[];
		}

		/// <summary>Determines whether any custom attributes are applied to a method parameter. Parameters specify the method parameter, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.ParameterInfo" /> class that describes a parameter of a member of a class.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>
		///   <see langword="true" /> if a custom attribute of type <paramref name="attributeType" /> is applied to <paramref name="element" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		// Token: 0x060009E4 RID: 2532 RVA: 0x000200C5 File Offset: 0x0001E2C5
		[__DynamicallyInvokable]
		public static bool IsDefined(ParameterInfo element, Type attributeType)
		{
			return Attribute.IsDefined(element, attributeType, true);
		}

		/// <summary>Determines whether any custom attributes are applied to a method parameter. Parameters specify the method parameter, the type of the custom attribute to search for, and whether to search ancestors of the method parameter.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.ParameterInfo" /> class that describes a parameter of a member of a class.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of <paramref name="element" /> for custom attributes.</param>
		/// <returns>
		///   <see langword="true" /> if a custom attribute of type <paramref name="attributeType" /> is applied to <paramref name="element" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.ExecutionEngineException">
		///   <paramref name="element" /> is not a method, constructor, or type.</exception>
		// Token: 0x060009E5 RID: 2533 RVA: 0x000200D0 File Offset: 0x0001E2D0
		[__DynamicallyInvokable]
		public static bool IsDefined(ParameterInfo element, Type attributeType, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			if (!attributeType.IsSubclassOf(typeof(Attribute)) && attributeType != typeof(Attribute))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustHaveAttributeBaseClass"));
			}
			MemberInfo member = element.Member;
			MemberTypes memberType = member.MemberType;
			if (memberType == MemberTypes.Constructor)
			{
				return element.IsDefined(attributeType, false);
			}
			if (memberType == MemberTypes.Method)
			{
				return Attribute.InternalParamIsDefined(element, attributeType, inherit);
			}
			if (memberType != MemberTypes.Property)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidParamInfo"));
			}
			return element.IsDefined(attributeType, false);
		}

		/// <summary>Retrieves a custom attribute applied to a method parameter. Parameters specify the method parameter, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.ParameterInfo" /> class that describes a parameter of a member of a class.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>A reference to the single custom attribute of type <paramref name="attributeType" /> that is applied to <paramref name="element" />, or <see langword="null" /> if there is no such attribute.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one of the requested attributes was found.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009E6 RID: 2534 RVA: 0x0002017A File Offset: 0x0001E37A
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(ParameterInfo element, Type attributeType)
		{
			return Attribute.GetCustomAttribute(element, attributeType, true);
		}

		/// <summary>Retrieves a custom attribute applied to a method parameter. Parameters specify the method parameter, the type of the custom attribute to search for, and whether to search ancestors of the method parameter.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.ParameterInfo" /> class that describes a parameter of a member of a class.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">If <see langword="true" />, specifies to also search the ancestors of <paramref name="element" /> for custom attributes.</param>
		/// <returns>A reference to the single custom attribute of type <paramref name="attributeType" /> that is applied to <paramref name="element" />, or <see langword="null" /> if there is no such attribute.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one of the requested attributes was found.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		// Token: 0x060009E7 RID: 2535 RVA: 0x00020184 File Offset: 0x0001E384
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(ParameterInfo element, Type attributeType, bool inherit)
		{
			Attribute[] customAttributes = Attribute.GetCustomAttributes(element, attributeType, inherit);
			if (customAttributes == null || customAttributes.Length == 0)
			{
				return null;
			}
			if (customAttributes.Length == 0)
			{
				return null;
			}
			if (customAttributes.Length == 1)
			{
				return customAttributes[0];
			}
			throw new AmbiguousMatchException(Environment.GetResourceString("RFLCT.AmbigCust"));
		}

		/// <summary>Retrieves an array of the custom attributes applied to a module. Parameters specify the module, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Module" /> class that describes a portable executable file.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes of type <paramref name="attributeType" /> applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		// Token: 0x060009E8 RID: 2536 RVA: 0x000201C2 File Offset: 0x0001E3C2
		public static Attribute[] GetCustomAttributes(Module element, Type attributeType)
		{
			return Attribute.GetCustomAttributes(element, attributeType, true);
		}

		/// <summary>Retrieves an array of the custom attributes applied to a module. A parameter specifies the module.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Module" /> class that describes a portable executable file.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> is <see langword="null" />.</exception>
		// Token: 0x060009E9 RID: 2537 RVA: 0x000201CC File Offset: 0x0001E3CC
		public static Attribute[] GetCustomAttributes(Module element)
		{
			return Attribute.GetCustomAttributes(element, true);
		}

		/// <summary>Retrieves an array of the custom attributes applied to a module. Parameters specify the module, and an ignored search option.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Module" /> class that describes a portable executable file.</param>
		/// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		// Token: 0x060009EA RID: 2538 RVA: 0x000201D5 File Offset: 0x0001E3D5
		public static Attribute[] GetCustomAttributes(Module element, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (Attribute[])element.GetCustomAttributes(typeof(Attribute), inherit);
		}

		/// <summary>Retrieves an array of the custom attributes applied to a module. Parameters specify the module, the type of the custom attribute to search for, and an ignored search option.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Module" /> class that describes a portable executable file.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes of type <paramref name="attributeType" /> applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		// Token: 0x060009EB RID: 2539 RVA: 0x00020204 File Offset: 0x0001E404
		public static Attribute[] GetCustomAttributes(Module element, Type attributeType, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			if (!attributeType.IsSubclassOf(typeof(Attribute)) && attributeType != typeof(Attribute))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustHaveAttributeBaseClass"));
			}
			return (Attribute[])element.GetCustomAttributes(attributeType, inherit);
		}

		/// <summary>Determines whether any custom attributes of a specified type are applied to a module. Parameters specify the module, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Module" /> class that describes a portable executable file.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>
		///   <see langword="true" /> if a custom attribute of type <paramref name="attributeType" /> is applied to <paramref name="element" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		// Token: 0x060009EC RID: 2540 RVA: 0x0002027A File Offset: 0x0001E47A
		public static bool IsDefined(Module element, Type attributeType)
		{
			return Attribute.IsDefined(element, attributeType, false);
		}

		/// <summary>Determines whether any custom attributes are applied to a module. Parameters specify the module, the type of the custom attribute to search for, and an ignored search option.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Module" /> class that describes a portable executable file.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
		/// <returns>
		///   <see langword="true" /> if a custom attribute of type <paramref name="attributeType" /> is applied to <paramref name="element" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		// Token: 0x060009ED RID: 2541 RVA: 0x00020284 File Offset: 0x0001E484
		public static bool IsDefined(Module element, Type attributeType, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			if (!attributeType.IsSubclassOf(typeof(Attribute)) && attributeType != typeof(Attribute))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustHaveAttributeBaseClass"));
			}
			return element.IsDefined(attributeType, false);
		}

		/// <summary>Retrieves a custom attribute applied to a module. Parameters specify the module, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Module" /> class that describes a portable executable file.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>A reference to the single custom attribute of type <paramref name="attributeType" /> that is applied to <paramref name="element" />, or <see langword="null" /> if there is no such attribute.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one of the requested attributes was found.</exception>
		// Token: 0x060009EE RID: 2542 RVA: 0x000202F5 File Offset: 0x0001E4F5
		public static Attribute GetCustomAttribute(Module element, Type attributeType)
		{
			return Attribute.GetCustomAttribute(element, attributeType, true);
		}

		/// <summary>Retrieves a custom attribute applied to a module. Parameters specify the module, the type of the custom attribute to search for, and an ignored search option.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Module" /> class that describes a portable executable file.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
		/// <returns>A reference to the single custom attribute of type <paramref name="attributeType" /> that is applied to <paramref name="element" />, or <see langword="null" /> if there is no such attribute.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one of the requested attributes was found.</exception>
		// Token: 0x060009EF RID: 2543 RVA: 0x00020300 File Offset: 0x0001E500
		public static Attribute GetCustomAttribute(Module element, Type attributeType, bool inherit)
		{
			Attribute[] customAttributes = Attribute.GetCustomAttributes(element, attributeType, inherit);
			if (customAttributes == null || customAttributes.Length == 0)
			{
				return null;
			}
			if (customAttributes.Length == 1)
			{
				return customAttributes[0];
			}
			throw new AmbiguousMatchException(Environment.GetResourceString("RFLCT.AmbigCust"));
		}

		/// <summary>Retrieves an array of the custom attributes applied to an assembly. Parameters specify the assembly, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Assembly" /> class that describes a reusable collection of modules.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes of type <paramref name="attributeType" /> applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		// Token: 0x060009F0 RID: 2544 RVA: 0x00020338 File Offset: 0x0001E538
		[__DynamicallyInvokable]
		public static Attribute[] GetCustomAttributes(Assembly element, Type attributeType)
		{
			return Attribute.GetCustomAttributes(element, attributeType, true);
		}

		/// <summary>Retrieves an array of the custom attributes applied to an assembly. Parameters specify the assembly, the type of the custom attribute to search for, and an ignored search option.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Assembly" /> class that describes a reusable collection of modules.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes of type <paramref name="attributeType" /> applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		// Token: 0x060009F1 RID: 2545 RVA: 0x00020344 File Offset: 0x0001E544
		public static Attribute[] GetCustomAttributes(Assembly element, Type attributeType, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			if (!attributeType.IsSubclassOf(typeof(Attribute)) && attributeType != typeof(Attribute))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustHaveAttributeBaseClass"));
			}
			return (Attribute[])element.GetCustomAttributes(attributeType, inherit);
		}

		/// <summary>Retrieves an array of the custom attributes applied to an assembly. A parameter specifies the assembly.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Assembly" /> class that describes a reusable collection of modules.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> is <see langword="null" />.</exception>
		// Token: 0x060009F2 RID: 2546 RVA: 0x000203BA File Offset: 0x0001E5BA
		[__DynamicallyInvokable]
		public static Attribute[] GetCustomAttributes(Assembly element)
		{
			return Attribute.GetCustomAttributes(element, true);
		}

		/// <summary>Retrieves an array of the custom attributes applied to an assembly. Parameters specify the assembly, and an ignored search option.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Assembly" /> class that describes a reusable collection of modules.</param>
		/// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
		/// <returns>An <see cref="T:System.Attribute" /> array that contains the custom attributes applied to <paramref name="element" />, or an empty array if no such custom attributes exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		// Token: 0x060009F3 RID: 2547 RVA: 0x000203C3 File Offset: 0x0001E5C3
		public static Attribute[] GetCustomAttributes(Assembly element, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (Attribute[])element.GetCustomAttributes(typeof(Attribute), inherit);
		}

		/// <summary>Determines whether any custom attributes are applied to an assembly. Parameters specify the assembly, and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Assembly" /> class that describes a reusable collection of modules.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>
		///   <see langword="true" /> if a custom attribute of type <paramref name="attributeType" /> is applied to <paramref name="element" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		// Token: 0x060009F4 RID: 2548 RVA: 0x000203EF File Offset: 0x0001E5EF
		[__DynamicallyInvokable]
		public static bool IsDefined(Assembly element, Type attributeType)
		{
			return Attribute.IsDefined(element, attributeType, true);
		}

		/// <summary>Determines whether any custom attributes are applied to an assembly. Parameters specify the assembly, the type of the custom attribute to search for, and an ignored search option.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Assembly" /> class that describes a reusable collection of modules.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
		/// <returns>
		///   <see langword="true" /> if a custom attribute of type <paramref name="attributeType" /> is applied to <paramref name="element" />; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		// Token: 0x060009F5 RID: 2549 RVA: 0x000203FC File Offset: 0x0001E5FC
		public static bool IsDefined(Assembly element, Type attributeType, bool inherit)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			if (!attributeType.IsSubclassOf(typeof(Attribute)) && attributeType != typeof(Attribute))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustHaveAttributeBaseClass"));
			}
			return element.IsDefined(attributeType, false);
		}

		/// <summary>Retrieves a custom attribute applied to a specified assembly. Parameters specify the assembly and the type of the custom attribute to search for.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Assembly" /> class that describes a reusable collection of modules.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <returns>A reference to the single custom attribute of type <paramref name="attributeType" /> that is applied to <paramref name="element" />, or <see langword="null" /> if there is no such attribute.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one of the requested attributes was found.</exception>
		// Token: 0x060009F6 RID: 2550 RVA: 0x0002046D File Offset: 0x0001E66D
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(Assembly element, Type attributeType)
		{
			return Attribute.GetCustomAttribute(element, attributeType, true);
		}

		/// <summary>Retrieves a custom attribute applied to an assembly. Parameters specify the assembly, the type of the custom attribute to search for, and an ignored search option.</summary>
		/// <param name="element">An object derived from the <see cref="T:System.Reflection.Assembly" /> class that describes a reusable collection of modules.</param>
		/// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
		/// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
		/// <returns>A reference to the single custom attribute of type <paramref name="attributeType" /> that is applied to <paramref name="element" />, or <see langword="null" /> if there is no such attribute.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="element" /> or <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not derived from <see cref="T:System.Attribute" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one of the requested attributes was found.</exception>
		// Token: 0x060009F7 RID: 2551 RVA: 0x00020478 File Offset: 0x0001E678
		public static Attribute GetCustomAttribute(Assembly element, Type attributeType, bool inherit)
		{
			Attribute[] customAttributes = Attribute.GetCustomAttributes(element, attributeType, inherit);
			if (customAttributes == null || customAttributes.Length == 0)
			{
				return null;
			}
			if (customAttributes.Length == 1)
			{
				return customAttributes[0];
			}
			throw new AmbiguousMatchException(Environment.GetResourceString("RFLCT.AmbigCust"));
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Attribute" /> class.</summary>
		// Token: 0x060009F8 RID: 2552 RVA: 0x000204B0 File Offset: 0x0001E6B0
		[__DynamicallyInvokable]
		protected Attribute()
		{
		}

		/// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
		/// <param name="obj">An <see cref="T:System.Object" /> to compare with this instance or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> and this instance are of the same type and have identical field values; otherwise, <see langword="false" />.</returns>
		// Token: 0x060009F9 RID: 2553 RVA: 0x000204B8 File Offset: 0x0001E6B8
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			RuntimeType runtimeType = (RuntimeType)base.GetType();
			RuntimeType left = (RuntimeType)obj.GetType();
			if (left != runtimeType)
			{
				return false;
			}
			FieldInfo[] fields = runtimeType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			for (int i = 0; i < fields.Length; i++)
			{
				object thisValue = ((RtFieldInfo)fields[i]).UnsafeGetValue(this);
				object thatValue = ((RtFieldInfo)fields[i]).UnsafeGetValue(obj);
				if (!Attribute.AreFieldValuesEqual(thisValue, thatValue))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0002053C File Offset: 0x0001E73C
		private static bool AreFieldValuesEqual(object thisValue, object thatValue)
		{
			if (thisValue == null && thatValue == null)
			{
				return true;
			}
			if (thisValue == null || thatValue == null)
			{
				return false;
			}
			if (thisValue.GetType().IsArray)
			{
				if (!thisValue.GetType().Equals(thatValue.GetType()))
				{
					return false;
				}
				Array array = thisValue as Array;
				Array array2 = thatValue as Array;
				if (array.Length != array2.Length)
				{
					return false;
				}
				for (int i = 0; i < array.Length; i++)
				{
					if (!Attribute.AreFieldValuesEqual(array.GetValue(i), array2.GetValue(i)))
					{
						return false;
					}
				}
			}
			else if (!thisValue.Equals(thatValue))
			{
				return false;
			}
			return true;
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x060009FB RID: 2555 RVA: 0x000205D0 File Offset: 0x0001E7D0
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			Type type = base.GetType();
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			object obj = null;
			for (int i = 0; i < fields.Length; i++)
			{
				object obj2 = ((RtFieldInfo)fields[i]).UnsafeGetValue(this);
				if (obj2 != null && !obj2.GetType().IsArray)
				{
					obj = obj2;
				}
				if (obj != null)
				{
					break;
				}
			}
			if (obj != null)
			{
				return obj.GetHashCode();
			}
			return type.GetHashCode();
		}

		/// <summary>When implemented in a derived class, gets a unique identifier for this <see cref="T:System.Attribute" />.</summary>
		/// <returns>An <see cref="T:System.Object" /> that is a unique identifier for the attribute.</returns>
		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060009FC RID: 2556 RVA: 0x00020635 File Offset: 0x0001E835
		public virtual object TypeId
		{
			get
			{
				return base.GetType();
			}
		}

		/// <summary>When overridden in a derived class, returns a value that indicates whether this instance equals a specified object.</summary>
		/// <param name="obj">An <see cref="T:System.Object" /> to compare with this instance of <see cref="T:System.Attribute" />.</param>
		/// <returns>
		///   <see langword="true" /> if this instance equals <paramref name="obj" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060009FD RID: 2557 RVA: 0x0002063D File Offset: 0x0001E83D
		public virtual bool Match(object obj)
		{
			return this.Equals(obj);
		}

		/// <summary>When overridden in a derived class, indicates whether the value of this instance is the default value for the derived class.</summary>
		/// <returns>
		///   <see langword="true" /> if this instance is the default attribute for the class; otherwise, <see langword="false" />.</returns>
		// Token: 0x060009FE RID: 2558 RVA: 0x00020646 File Offset: 0x0001E846
		public virtual bool IsDefaultAttribute()
		{
			return false;
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060009FF RID: 2559 RVA: 0x00020649 File Offset: 0x0001E849
		void _Attribute.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06000A00 RID: 2560 RVA: 0x00020650 File Offset: 0x0001E850
		void _Attribute.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array that receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06000A01 RID: 2561 RVA: 0x00020657 File Offset: 0x0001E857
		void _Attribute.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">Identifies the member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">Pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">Pointer to the location where the result is to be stored.</param>
		/// <param name="pExcepInfo">Pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06000A02 RID: 2562 RVA: 0x0002065E File Offset: 0x0001E85E
		void _Attribute.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
