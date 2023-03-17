using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Reflection.Emit
{
	/// <summary>Defines and represents a dynamic method that can be compiled, executed, and discarded. Discarded methods are available for garbage collection.</summary>
	// Token: 0x0200060B RID: 1547
	[ComVisible(true)]
	public sealed class DynamicMethod : MethodInfo
	{
		// Token: 0x06004912 RID: 18706 RVA: 0x00107CFD File Offset: 0x00105EFD
		private DynamicMethod()
		{
		}

		/// <summary>Initializes an anonymously hosted dynamic method, specifying the method name, return type, and parameter types.</summary>
		/// <param name="name">The name of the dynamic method. This can be a zero-length string, but it cannot be <see langword="null" />.</param>
		/// <param name="returnType">A <see cref="T:System.Type" /> object that specifies the return type of the dynamic method, or <see langword="null" /> if the method has no return type.</param>
		/// <param name="parameterTypes">An array of <see cref="T:System.Type" /> objects specifying the types of the parameters of the dynamic method, or <see langword="null" /> if the method has no parameters.</param>
		/// <exception cref="T:System.ArgumentException">An element of <paramref name="parameterTypes" /> is <see langword="null" /> or <see cref="T:System.Void" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="returnType" /> is a type for which <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x06004913 RID: 18707 RVA: 0x00107D08 File Offset: 0x00105F08
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, null, false, true, ref stackCrawlMark);
		}

		/// <summary>Initializes an anonymously hosted dynamic method, specifying the method name, return type, parameter types, and whether just-in-time (JIT) visibility checks should be skipped for types and members accessed by the Microsoft intermediate language (MSIL) of the dynamic method.</summary>
		/// <param name="name">The name of the dynamic method. This can be a zero-length string, but it cannot be <see langword="null" />.</param>
		/// <param name="returnType">A <see cref="T:System.Type" /> object that specifies the return type of the dynamic method, or <see langword="null" /> if the method has no return type.</param>
		/// <param name="parameterTypes">An array of <see cref="T:System.Type" /> objects specifying the types of the parameters of the dynamic method, or <see langword="null" /> if the method has no parameters.</param>
		/// <param name="restrictedSkipVisibility">
		///   <see langword="true" /> to skip JIT visibility checks on types and members accessed by the MSIL of the dynamic method, with this restriction: the trust level of the assemblies that contain those types and members must be equal to or less than the trust level of the call stack that emits the dynamic method; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.ArgumentException">An element of <paramref name="parameterTypes" /> is <see langword="null" /> or <see cref="T:System.Void" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="returnType" /> is a type for which <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x06004914 RID: 18708 RVA: 0x00107D30 File Offset: 0x00105F30
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes, bool restrictedSkipVisibility)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, null, restrictedSkipVisibility, true, ref stackCrawlMark);
		}

		/// <summary>Creates a dynamic method that is global to a module, specifying the method name, return type, parameter types, and module.</summary>
		/// <param name="name">The name of the dynamic method. This can be a zero-length string, but it cannot be <see langword="null" />.</param>
		/// <param name="returnType">A <see cref="T:System.Type" /> object that specifies the return type of the dynamic method, or <see langword="null" /> if the method has no return type.</param>
		/// <param name="parameterTypes">An array of <see cref="T:System.Type" /> objects specifying the types of the parameters of the dynamic method, or <see langword="null" /> if the method has no parameters.</param>
		/// <param name="m">A <see cref="T:System.Reflection.Module" /> representing the module with which the dynamic method is to be logically associated.</param>
		/// <exception cref="T:System.ArgumentException">An element of <paramref name="parameterTypes" /> is <see langword="null" /> or <see cref="T:System.Void" />.  
		///  -or-  
		///  <paramref name="m" /> is a module that provides anonymous hosting for dynamic methods.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="m" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="returnType" /> is a type for which <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x06004915 RID: 18709 RVA: 0x00107D58 File Offset: 0x00105F58
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes, Module m)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(m, ref stackCrawlMark, false);
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, m, false, false, ref stackCrawlMark);
		}

		/// <summary>Creates a dynamic method that is global to a module, specifying the method name, return type, parameter types, module, and whether just-in-time (JIT) visibility checks should be skipped for types and members accessed by the Microsoft intermediate language (MSIL) of the dynamic method.</summary>
		/// <param name="name">The name of the dynamic method. This can be a zero-length string, but it cannot be <see langword="null" />.</param>
		/// <param name="returnType">A <see cref="T:System.Type" /> object that specifies the return type of the dynamic method, or <see langword="null" /> if the method has no return type.</param>
		/// <param name="parameterTypes">An array of <see cref="T:System.Type" /> objects specifying the types of the parameters of the dynamic method, or <see langword="null" /> if the method has no parameters.</param>
		/// <param name="m">A <see cref="T:System.Reflection.Module" /> representing the module with which the dynamic method is to be logically associated.</param>
		/// <param name="skipVisibility">
		///   <see langword="true" /> to skip JIT visibility checks on types and members accessed by the MSIL of the dynamic method.</param>
		/// <exception cref="T:System.ArgumentException">An element of <paramref name="parameterTypes" /> is <see langword="null" /> or <see cref="T:System.Void" />.  
		///  -or-  
		///  <paramref name="m" /> is a module that provides anonymous hosting for dynamic methods.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="m" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="returnType" /> is a type for which <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x06004916 RID: 18710 RVA: 0x00107D8C File Offset: 0x00105F8C
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes, Module m, bool skipVisibility)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(m, ref stackCrawlMark, skipVisibility);
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, m, skipVisibility, false, ref stackCrawlMark);
		}

		/// <summary>Creates a dynamic method that is global to a module, specifying the method name, attributes, calling convention, return type, parameter types, module, and whether just-in-time (JIT) visibility checks should be skipped for types and members accessed by the Microsoft intermediate language (MSIL) of the dynamic method.</summary>
		/// <param name="name">The name of the dynamic method. This can be a zero-length string, but it cannot be <see langword="null" />.</param>
		/// <param name="attributes">A bitwise combination of <see cref="T:System.Reflection.MethodAttributes" /> values that specifies the attributes of the dynamic method. The only combination allowed is <see cref="F:System.Reflection.MethodAttributes.Public" /> and <see cref="F:System.Reflection.MethodAttributes.Static" />.</param>
		/// <param name="callingConvention">The calling convention for the dynamic method. Must be <see cref="F:System.Reflection.CallingConventions.Standard" />.</param>
		/// <param name="returnType">A <see cref="T:System.Type" /> object that specifies the return type of the dynamic method, or <see langword="null" /> if the method has no return type.</param>
		/// <param name="parameterTypes">An array of <see cref="T:System.Type" /> objects specifying the types of the parameters of the dynamic method, or <see langword="null" /> if the method has no parameters.</param>
		/// <param name="m">A <see cref="T:System.Reflection.Module" /> representing the module with which the dynamic method is to be logically associated.</param>
		/// <param name="skipVisibility">
		///   <see langword="true" /> to skip JIT visibility checks on types and members accessed by the MSIL of the dynamic method; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.ArgumentException">An element of <paramref name="parameterTypes" /> is <see langword="null" /> or <see cref="T:System.Void" />.  
		///  -or-  
		///  <paramref name="m" /> is a module that provides anonymous hosting for dynamic methods.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="m" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="attributes" /> is a combination of flags other than <see cref="F:System.Reflection.MethodAttributes.Public" /> and <see cref="F:System.Reflection.MethodAttributes.Static" />.  
		/// -or-  
		/// <paramref name="callingConvention" /> is not <see cref="F:System.Reflection.CallingConventions.Standard" />.  
		/// -or-  
		/// <paramref name="returnType" /> is a type for which <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x06004917 RID: 18711 RVA: 0x00107DC4 File Offset: 0x00105FC4
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, Module m, bool skipVisibility)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(m, ref stackCrawlMark, skipVisibility);
			this.Init(name, attributes, callingConvention, returnType, parameterTypes, null, m, skipVisibility, false, ref stackCrawlMark);
		}

		/// <summary>Creates a dynamic method, specifying the method name, return type, parameter types, and the type with which the dynamic method is logically associated.</summary>
		/// <param name="name">The name of the dynamic method. This can be a zero-length string, but it cannot be <see langword="null" />.</param>
		/// <param name="returnType">A <see cref="T:System.Type" /> object that specifies the return type of the dynamic method, or <see langword="null" /> if the method has no return type.</param>
		/// <param name="parameterTypes">An array of <see cref="T:System.Type" /> objects specifying the types of the parameters of the dynamic method, or <see langword="null" /> if the method has no parameters.</param>
		/// <param name="owner">A <see cref="T:System.Type" /> with which the dynamic method is logically associated. The dynamic method has access to all members of the type.</param>
		/// <exception cref="T:System.ArgumentException">An element of <paramref name="parameterTypes" /> is <see langword="null" /> or <see cref="T:System.Void" />.  
		///  -or-  
		///  <paramref name="owner" /> is an interface, an array, an open generic type, or a type parameter of a generic type or method.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="owner" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="returnType" /> is <see langword="null" />, or is a type for which <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x06004918 RID: 18712 RVA: 0x00107DFC File Offset: 0x00105FFC
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes, Type owner)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(owner, ref stackCrawlMark, false);
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, owner, null, false, false, ref stackCrawlMark);
		}

		/// <summary>Creates a dynamic method, specifying the method name, return type, parameter types, the type with which the dynamic method is logically associated, and whether just-in-time (JIT) visibility checks should be skipped for types and members accessed by the Microsoft intermediate language (MSIL) of the dynamic method.</summary>
		/// <param name="name">The name of the dynamic method. This can be a zero-length string, but it cannot be <see langword="null" />.</param>
		/// <param name="returnType">A <see cref="T:System.Type" /> object that specifies the return type of the dynamic method, or <see langword="null" /> if the method has no return type.</param>
		/// <param name="parameterTypes">An array of <see cref="T:System.Type" /> objects specifying the types of the parameters of the dynamic method, or <see langword="null" /> if the method has no parameters.</param>
		/// <param name="owner">A <see cref="T:System.Type" /> with which the dynamic method is logically associated. The dynamic method has access to all members of the type.</param>
		/// <param name="skipVisibility">
		///   <see langword="true" /> to skip JIT visibility checks on types and members accessed by the MSIL of the dynamic method; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.ArgumentException">An element of <paramref name="parameterTypes" /> is <see langword="null" /> or <see cref="T:System.Void" />.  
		///  -or-  
		///  <paramref name="owner" /> is an interface, an array, an open generic type, or a type parameter of a generic type or method.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="owner" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="returnType" /> is <see langword="null" />, or is a type for which <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x06004919 RID: 18713 RVA: 0x00107E30 File Offset: 0x00106030
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, Type returnType, Type[] parameterTypes, Type owner, bool skipVisibility)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(owner, ref stackCrawlMark, skipVisibility);
			this.Init(name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, owner, null, skipVisibility, false, ref stackCrawlMark);
		}

		/// <summary>Creates a dynamic method, specifying the method name, attributes, calling convention, return type, parameter types, the type with which the dynamic method is logically associated, and whether just-in-time (JIT) visibility checks should be skipped for types and members accessed by the Microsoft intermediate language (MSIL) of the dynamic method.</summary>
		/// <param name="name">The name of the dynamic method. This can be a zero-length string, but it cannot be <see langword="null" />.</param>
		/// <param name="attributes">A bitwise combination of <see cref="T:System.Reflection.MethodAttributes" /> values that specifies the attributes of the dynamic method. The only combination allowed is <see cref="F:System.Reflection.MethodAttributes.Public" /> and <see cref="F:System.Reflection.MethodAttributes.Static" />.</param>
		/// <param name="callingConvention">The calling convention for the dynamic method. Must be <see cref="F:System.Reflection.CallingConventions.Standard" />.</param>
		/// <param name="returnType">A <see cref="T:System.Type" /> object that specifies the return type of the dynamic method, or <see langword="null" /> if the method has no return type.</param>
		/// <param name="parameterTypes">An array of <see cref="T:System.Type" /> objects specifying the types of the parameters of the dynamic method, or <see langword="null" /> if the method has no parameters.</param>
		/// <param name="owner">A <see cref="T:System.Type" /> with which the dynamic method is logically associated. The dynamic method has access to all members of the type.</param>
		/// <param name="skipVisibility">
		///   <see langword="true" /> to skip JIT visibility checks on types and members accessed by the MSIL of the dynamic method; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.ArgumentException">An element of <paramref name="parameterTypes" /> is <see langword="null" /> or <see cref="T:System.Void" />.  
		///  -or-  
		///  <paramref name="owner" /> is an interface, an array, an open generic type, or a type parameter of a generic type or method.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="owner" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="attributes" /> is a combination of flags other than <see cref="F:System.Reflection.MethodAttributes.Public" /> and <see cref="F:System.Reflection.MethodAttributes.Static" />.  
		/// -or-  
		/// <paramref name="callingConvention" /> is not <see cref="F:System.Reflection.CallingConventions.Standard" />.  
		/// -or-  
		/// <paramref name="returnType" /> is a type for which <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x0600491A RID: 18714 RVA: 0x00107E68 File Offset: 0x00106068
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public DynamicMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, Type owner, bool skipVisibility)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.PerformSecurityCheck(owner, ref stackCrawlMark, skipVisibility);
			this.Init(name, attributes, callingConvention, returnType, parameterTypes, owner, null, skipVisibility, false, ref stackCrawlMark);
		}

		// Token: 0x0600491B RID: 18715 RVA: 0x00107EA0 File Offset: 0x001060A0
		private static void CheckConsistency(MethodAttributes attributes, CallingConventions callingConvention)
		{
			if ((attributes & ~MethodAttributes.MemberAccessMask) != MethodAttributes.Static)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicMethodFlags"));
			}
			if ((attributes & MethodAttributes.MemberAccessMask) != MethodAttributes.Public)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicMethodFlags"));
			}
			if (callingConvention != CallingConventions.Standard && callingConvention != CallingConventions.VarArgs)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicMethodFlags"));
			}
			if (callingConvention == CallingConventions.VarArgs)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicMethodFlags"));
			}
		}

		// Token: 0x0600491C RID: 18716 RVA: 0x00107F08 File Offset: 0x00106108
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static RuntimeModule GetDynamicMethodsModule()
		{
			if (DynamicMethod.s_anonymouslyHostedDynamicMethodsModule != null)
			{
				return DynamicMethod.s_anonymouslyHostedDynamicMethodsModule;
			}
			object obj = DynamicMethod.s_anonymouslyHostedDynamicMethodsModuleLock;
			lock (obj)
			{
				if (DynamicMethod.s_anonymouslyHostedDynamicMethodsModule != null)
				{
					return DynamicMethod.s_anonymouslyHostedDynamicMethodsModule;
				}
				ConstructorInfo constructor = typeof(SecurityTransparentAttribute).GetConstructor(Type.EmptyTypes);
				CustomAttributeBuilder item = new CustomAttributeBuilder(constructor, EmptyArray<object>.Value);
				List<CustomAttributeBuilder> list = new List<CustomAttributeBuilder>();
				list.Add(item);
				ConstructorInfo constructor2 = typeof(SecurityRulesAttribute).GetConstructor(new Type[]
				{
					typeof(SecurityRuleSet)
				});
				CustomAttributeBuilder item2 = new CustomAttributeBuilder(constructor2, new object[]
				{
					SecurityRuleSet.Level1
				});
				list.Add(item2);
				AssemblyName name = new AssemblyName("Anonymously Hosted DynamicMethods Assembly");
				StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMe;
				AssemblyBuilder assemblyBuilder = AssemblyBuilder.InternalDefineDynamicAssembly(name, AssemblyBuilderAccess.Run, null, null, null, null, null, ref stackCrawlMark, list, SecurityContextSource.CurrentAssembly);
				AppDomain.PublishAnonymouslyHostedDynamicMethodsAssembly(assemblyBuilder.GetNativeHandle());
				DynamicMethod.s_anonymouslyHostedDynamicMethodsModule = (InternalModuleBuilder)assemblyBuilder.ManifestModule;
			}
			return DynamicMethod.s_anonymouslyHostedDynamicMethodsModule;
		}

		// Token: 0x0600491D RID: 18717 RVA: 0x00108038 File Offset: 0x00106238
		[SecurityCritical]
		private void Init(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] signature, Type owner, Module m, bool skipVisibility, bool transparentMethod, ref StackCrawlMark stackMark)
		{
			DynamicMethod.CheckConsistency(attributes, callingConvention);
			if (signature != null)
			{
				this.m_parameterTypes = new RuntimeType[signature.Length];
				for (int i = 0; i < signature.Length; i++)
				{
					if (signature[i] == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Arg_InvalidTypeInSignature"));
					}
					this.m_parameterTypes[i] = (signature[i].UnderlyingSystemType as RuntimeType);
					if (this.m_parameterTypes[i] == null || this.m_parameterTypes[i] == null || this.m_parameterTypes[i] == (RuntimeType)typeof(void))
					{
						throw new ArgumentException(Environment.GetResourceString("Arg_InvalidTypeInSignature"));
					}
				}
			}
			else
			{
				this.m_parameterTypes = new RuntimeType[0];
			}
			this.m_returnType = ((returnType == null) ? ((RuntimeType)typeof(void)) : (returnType.UnderlyingSystemType as RuntimeType));
			if (this.m_returnType == null || this.m_returnType == null || this.m_returnType.IsByRef)
			{
				throw new NotSupportedException(Environment.GetResourceString("Arg_InvalidTypeInRetType"));
			}
			if (transparentMethod)
			{
				this.m_module = DynamicMethod.GetDynamicMethodsModule();
				if (skipVisibility)
				{
					this.m_restrictedSkipVisibility = true;
				}
				this.m_creationContext = CompressedStack.Capture();
			}
			else
			{
				if (m != null)
				{
					this.m_module = m.ModuleHandle.GetRuntimeModule();
				}
				else
				{
					RuntimeType runtimeType = null;
					if (owner != null)
					{
						runtimeType = (owner.UnderlyingSystemType as RuntimeType);
					}
					if (runtimeType != null)
					{
						if (runtimeType.HasElementType || runtimeType.ContainsGenericParameters || runtimeType.IsGenericParameter || runtimeType.IsInterface)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_InvalidTypeForDynamicMethod"));
						}
						this.m_typeOwner = runtimeType;
						this.m_module = runtimeType.GetRuntimeModule();
					}
				}
				this.m_skipVisibility = skipVisibility;
			}
			this.m_ilGenerator = null;
			this.m_fInitLocals = true;
			this.m_methodHandle = null;
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (AppDomain.ProfileAPICheck)
			{
				if (this.m_creatorAssembly == null)
				{
					this.m_creatorAssembly = RuntimeAssembly.GetExecutingAssembly(ref stackMark);
				}
				if (this.m_creatorAssembly != null && !this.m_creatorAssembly.IsFrameworkAssembly())
				{
					this.m_profileAPICheck = true;
				}
			}
			this.m_dynMethod = new DynamicMethod.RTDynamicMethod(this, name, attributes, callingConvention);
		}

		// Token: 0x0600491E RID: 18718 RVA: 0x0010828C File Offset: 0x0010648C
		[SecurityCritical]
		private void PerformSecurityCheck(Module m, ref StackCrawlMark stackMark, bool skipVisibility)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			ModuleBuilder moduleBuilder = m as ModuleBuilder;
			RuntimeModule left;
			if (moduleBuilder != null)
			{
				left = moduleBuilder.InternalModule;
			}
			else
			{
				left = (m as RuntimeModule);
			}
			if (left == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeModule"), "m");
			}
			if (left == DynamicMethod.s_anonymouslyHostedDynamicMethodsModule)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidValue"), "m");
			}
			if (skipVisibility)
			{
				new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Demand();
			}
			RuntimeType callerType = RuntimeMethodHandle.GetCallerType(ref stackMark);
			this.m_creatorAssembly = callerType.GetRuntimeAssembly();
			if (m.Assembly != this.m_creatorAssembly)
			{
				CodeAccessSecurityEngine.ReflectionTargetDemandHelper(PermissionType.SecurityControlEvidence, m.Assembly.PermissionSet);
			}
		}

		// Token: 0x0600491F RID: 18719 RVA: 0x00108358 File Offset: 0x00106558
		[SecurityCritical]
		private void PerformSecurityCheck(Type owner, ref StackCrawlMark stackMark, bool skipVisibility)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}
			RuntimeType runtimeType = owner as RuntimeType;
			if (runtimeType == null)
			{
				runtimeType = (owner.UnderlyingSystemType as RuntimeType);
			}
			if (runtimeType == null)
			{
				throw new ArgumentNullException("owner", Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			RuntimeType callerType = RuntimeMethodHandle.GetCallerType(ref stackMark);
			if (skipVisibility)
			{
				new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Demand();
			}
			else if (callerType != runtimeType)
			{
				new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Demand();
			}
			this.m_creatorAssembly = callerType.GetRuntimeAssembly();
			if (runtimeType.Assembly != this.m_creatorAssembly)
			{
				CodeAccessSecurityEngine.ReflectionTargetDemandHelper(PermissionType.SecurityControlEvidence, owner.Assembly.PermissionSet);
			}
		}

		/// <summary>Completes the dynamic method and creates a delegate that can be used to execute it.</summary>
		/// <param name="delegateType">A delegate type whose signature matches that of the dynamic method.</param>
		/// <returns>A delegate of the specified type, which can be used to execute the dynamic method.</returns>
		/// <exception cref="T:System.InvalidOperationException">The dynamic method has no method body.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="delegateType" /> has the wrong number of parameters or the wrong parameter types.</exception>
		// Token: 0x06004920 RID: 18720 RVA: 0x00108410 File Offset: 0x00106610
		[SecuritySafeCritical]
		[ComVisible(true)]
		public sealed override Delegate CreateDelegate(Type delegateType)
		{
			if (this.m_restrictedSkipVisibility)
			{
				this.GetMethodDescriptor();
				RuntimeHelpers._CompileMethod(this.m_methodHandle);
			}
			MulticastDelegate multicastDelegate = (MulticastDelegate)Delegate.CreateDelegateNoSecurityCheck(delegateType, null, this.GetMethodDescriptor());
			multicastDelegate.StoreDynamicMethod(this.GetMethodInfo());
			return multicastDelegate;
		}

		/// <summary>Completes the dynamic method and creates a delegate that can be used to execute it, specifying the delegate type and an object the delegate is bound to.</summary>
		/// <param name="delegateType">A delegate type whose signature matches that of the dynamic method, minus the first parameter.</param>
		/// <param name="target">An object the delegate is bound to. Must be of the same type as the first parameter of the dynamic method.</param>
		/// <returns>A delegate of the specified type, which can be used to execute the dynamic method with the specified target object.</returns>
		/// <exception cref="T:System.InvalidOperationException">The dynamic method has no method body.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="target" /> is not the same type as the first parameter of the dynamic method, and is not assignable to that type.  
		/// -or-  
		/// <paramref name="delegateType" /> has the wrong number of parameters or the wrong parameter types.</exception>
		// Token: 0x06004921 RID: 18721 RVA: 0x00108458 File Offset: 0x00106658
		[SecuritySafeCritical]
		[ComVisible(true)]
		public sealed override Delegate CreateDelegate(Type delegateType, object target)
		{
			if (this.m_restrictedSkipVisibility)
			{
				this.GetMethodDescriptor();
				RuntimeHelpers._CompileMethod(this.m_methodHandle);
			}
			MulticastDelegate multicastDelegate = (MulticastDelegate)Delegate.CreateDelegateNoSecurityCheck(delegateType, target, this.GetMethodDescriptor());
			multicastDelegate.StoreDynamicMethod(this.GetMethodInfo());
			return multicastDelegate;
		}

		// Token: 0x17000B7A RID: 2938
		// (get) Token: 0x06004922 RID: 18722 RVA: 0x0010849F File Offset: 0x0010669F
		// (set) Token: 0x06004923 RID: 18723 RVA: 0x001084A7 File Offset: 0x001066A7
		internal bool ProfileAPICheck
		{
			get
			{
				return this.m_profileAPICheck;
			}
			[FriendAccessAllowed]
			set
			{
				this.m_profileAPICheck = value;
			}
		}

		// Token: 0x06004924 RID: 18724 RVA: 0x001084B0 File Offset: 0x001066B0
		[SecurityCritical]
		internal RuntimeMethodHandle GetMethodDescriptor()
		{
			if (this.m_methodHandle == null)
			{
				lock (this)
				{
					if (this.m_methodHandle == null)
					{
						if (this.m_DynamicILInfo != null)
						{
							this.m_DynamicILInfo.GetCallableMethod(this.m_module, this);
						}
						else
						{
							if (this.m_ilGenerator == null || this.m_ilGenerator.ILOffset == 0)
							{
								throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadEmptyMethodBody", new object[]
								{
									this.Name
								}));
							}
							this.m_ilGenerator.GetCallableMethod(this.m_module, this);
						}
					}
				}
			}
			return new RuntimeMethodHandle(this.m_methodHandle);
		}

		/// <summary>Returns the signature of the method, represented as a string.</summary>
		/// <returns>A string representing the method signature.</returns>
		// Token: 0x06004925 RID: 18725 RVA: 0x00108568 File Offset: 0x00106768
		public override string ToString()
		{
			return this.m_dynMethod.ToString();
		}

		/// <summary>Gets the name of the dynamic method.</summary>
		/// <returns>The simple name of the method.</returns>
		// Token: 0x17000B7B RID: 2939
		// (get) Token: 0x06004926 RID: 18726 RVA: 0x00108575 File Offset: 0x00106775
		public override string Name
		{
			get
			{
				return this.m_dynMethod.Name;
			}
		}

		/// <summary>Gets the type that declares the method, which is always <see langword="null" /> for dynamic methods.</summary>
		/// <returns>Always <see langword="null" />.</returns>
		// Token: 0x17000B7C RID: 2940
		// (get) Token: 0x06004927 RID: 18727 RVA: 0x00108582 File Offset: 0x00106782
		public override Type DeclaringType
		{
			get
			{
				return this.m_dynMethod.DeclaringType;
			}
		}

		/// <summary>Gets the class that was used in reflection to obtain the method.</summary>
		/// <returns>Always <see langword="null" />.</returns>
		// Token: 0x17000B7D RID: 2941
		// (get) Token: 0x06004928 RID: 18728 RVA: 0x0010858F File Offset: 0x0010678F
		public override Type ReflectedType
		{
			get
			{
				return this.m_dynMethod.ReflectedType;
			}
		}

		/// <summary>Gets the module with which the dynamic method is logically associated.</summary>
		/// <returns>The <see cref="T:System.Reflection.Module" /> with which the current dynamic method is associated.</returns>
		// Token: 0x17000B7E RID: 2942
		// (get) Token: 0x06004929 RID: 18729 RVA: 0x0010859C File Offset: 0x0010679C
		public override Module Module
		{
			get
			{
				return this.m_dynMethod.Module;
			}
		}

		/// <summary>Not supported for dynamic methods.</summary>
		/// <returns>Not supported for dynamic methods.</returns>
		/// <exception cref="T:System.InvalidOperationException">Not allowed for dynamic methods.</exception>
		// Token: 0x17000B7F RID: 2943
		// (get) Token: 0x0600492A RID: 18730 RVA: 0x001085A9 File Offset: 0x001067A9
		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotAllowedInDynamicMethod"));
			}
		}

		/// <summary>Gets the attributes specified when the dynamic method was created.</summary>
		/// <returns>A bitwise combination of the <see cref="T:System.Reflection.MethodAttributes" /> values representing the attributes for the method.</returns>
		// Token: 0x17000B80 RID: 2944
		// (get) Token: 0x0600492B RID: 18731 RVA: 0x001085BA File Offset: 0x001067BA
		public override MethodAttributes Attributes
		{
			get
			{
				return this.m_dynMethod.Attributes;
			}
		}

		/// <summary>Gets the calling convention specified when the dynamic method was created.</summary>
		/// <returns>One of the <see cref="T:System.Reflection.CallingConventions" /> values that indicates the calling convention of the method.</returns>
		// Token: 0x17000B81 RID: 2945
		// (get) Token: 0x0600492C RID: 18732 RVA: 0x001085C7 File Offset: 0x001067C7
		public override CallingConventions CallingConvention
		{
			get
			{
				return this.m_dynMethod.CallingConvention;
			}
		}

		/// <summary>Returns the base implementation for the method.</summary>
		/// <returns>The base implementation of the method.</returns>
		// Token: 0x0600492D RID: 18733 RVA: 0x001085D4 File Offset: 0x001067D4
		public override MethodInfo GetBaseDefinition()
		{
			return this;
		}

		/// <summary>Returns the parameters of the dynamic method.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.ParameterInfo" /> objects that represent the parameters of the dynamic method.</returns>
		// Token: 0x0600492E RID: 18734 RVA: 0x001085D7 File Offset: 0x001067D7
		public override ParameterInfo[] GetParameters()
		{
			return this.m_dynMethod.GetParameters();
		}

		/// <summary>Returns the implementation flags for the method.</summary>
		/// <returns>A bitwise combination of <see cref="T:System.Reflection.MethodImplAttributes" /> values representing the implementation flags for the method.</returns>
		// Token: 0x0600492F RID: 18735 RVA: 0x001085E4 File Offset: 0x001067E4
		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			return this.m_dynMethod.GetMethodImplementationFlags();
		}

		/// <summary>Gets a value that indicates whether the current dynamic method is security-critical or security-safe-critical, and therefore can perform critical operations.</summary>
		/// <returns>
		///   <see langword="true" /> if the current dynamic method is security-critical or security-safe-critical; <see langword="false" /> if it is transparent.</returns>
		/// <exception cref="T:System.InvalidOperationException">The dynamic method doesn't have a method body.</exception>
		// Token: 0x17000B82 RID: 2946
		// (get) Token: 0x06004930 RID: 18736 RVA: 0x001085F4 File Offset: 0x001067F4
		public override bool IsSecurityCritical
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_methodHandle != null)
				{
					return RuntimeMethodHandle.IsSecurityCritical(this.m_methodHandle);
				}
				if (this.m_typeOwner != null)
				{
					RuntimeAssembly runtimeAssembly = this.m_typeOwner.Assembly as RuntimeAssembly;
					return runtimeAssembly.IsAllSecurityCritical();
				}
				RuntimeAssembly runtimeAssembly2 = this.m_module.Assembly as RuntimeAssembly;
				return runtimeAssembly2.IsAllSecurityCritical();
			}
		}

		/// <summary>Gets a value that indicates whether the current dynamic method is security-safe-critical at the current trust level; that is, whether it can perform critical operations and can be accessed by transparent code.</summary>
		/// <returns>
		///   <see langword="true" /> if the dynamic method is security-safe-critical at the current trust level; <see langword="false" /> if it is security-critical or transparent.</returns>
		/// <exception cref="T:System.InvalidOperationException">The dynamic method doesn't have a method body.</exception>
		// Token: 0x17000B83 RID: 2947
		// (get) Token: 0x06004931 RID: 18737 RVA: 0x00108654 File Offset: 0x00106854
		public override bool IsSecuritySafeCritical
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_methodHandle != null)
				{
					return RuntimeMethodHandle.IsSecuritySafeCritical(this.m_methodHandle);
				}
				if (this.m_typeOwner != null)
				{
					RuntimeAssembly runtimeAssembly = this.m_typeOwner.Assembly as RuntimeAssembly;
					return runtimeAssembly.IsAllPublicAreaSecuritySafeCritical();
				}
				RuntimeAssembly runtimeAssembly2 = this.m_module.Assembly as RuntimeAssembly;
				return runtimeAssembly2.IsAllSecuritySafeCritical();
			}
		}

		/// <summary>Gets a value that indicates whether the current dynamic method is transparent at the current trust level, and therefore cannot perform critical operations.</summary>
		/// <returns>
		///   <see langword="true" /> if the dynamic method is security-transparent at the current trust level; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.InvalidOperationException">The dynamic method doesn't have a method body.</exception>
		// Token: 0x17000B84 RID: 2948
		// (get) Token: 0x06004932 RID: 18738 RVA: 0x001086B4 File Offset: 0x001068B4
		public override bool IsSecurityTransparent
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_methodHandle != null)
				{
					return RuntimeMethodHandle.IsSecurityTransparent(this.m_methodHandle);
				}
				if (this.m_typeOwner != null)
				{
					RuntimeAssembly runtimeAssembly = this.m_typeOwner.Assembly as RuntimeAssembly;
					return !runtimeAssembly.IsAllSecurityCritical();
				}
				RuntimeAssembly runtimeAssembly2 = this.m_module.Assembly as RuntimeAssembly;
				return !runtimeAssembly2.IsAllSecurityCritical();
			}
		}

		/// <summary>Invokes the dynamic method using the specified parameters, under the constraints of the specified binder, with the specified culture information.</summary>
		/// <param name="obj">This parameter is ignored for dynamic methods, because they are static. Specify <see langword="null" />.</param>
		/// <param name="invokeAttr">A bitwise combination of <see cref="T:System.Reflection.BindingFlags" /> values.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see cref="T:System.Reflection.MemberInfo" /> objects through reflection. If <paramref name="binder" /> is <see langword="null" />, the default binder is used. For more details, see <see cref="T:System.Reflection.Binder" />.</param>
		/// <param name="parameters">An argument list. This is an array of arguments with the same number, order, and type as the parameters of the method to be invoked. If there are no parameters this parameter should be <see langword="null" />.</param>
		/// <param name="culture">An instance of <see cref="T:System.Globalization.CultureInfo" /> used to govern the coercion of types. If this is <see langword="null" />, the <see cref="T:System.Globalization.CultureInfo" /> for the current thread is used. For example, this information is needed to correctly convert a <see cref="T:System.String" /> that represents 1000 to a <see cref="T:System.Double" /> value, because 1000 is represented differently by different cultures.</param>
		/// <returns>A <see cref="T:System.Object" /> containing the return value of the invoked method.</returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="F:System.Reflection.CallingConventions.VarArgs" /> calling convention is not supported.</exception>
		/// <exception cref="T:System.Reflection.TargetParameterCountException">The number of elements in <paramref name="parameters" /> does not match the number of parameters in the dynamic method.</exception>
		/// <exception cref="T:System.ArgumentException">The type of one or more elements of <paramref name="parameters" /> does not match the type of the corresponding parameter of the dynamic method.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The dynamic method is associated with a module, is not anonymously hosted, and was constructed with <paramref name="skipVisibility" /> set to <see langword="false" />, but the dynamic method accesses members that are not <see langword="public" /> or <see langword="internal" /> (<see langword="Friend" /> in Visual Basic).  
		///  -or-  
		///  The dynamic method is anonymously hosted and was constructed with <paramref name="skipVisibility" /> set to <see langword="false" />, but it accesses members that are not <see langword="public" />.  
		///  -or-  
		///  The dynamic method contains unverifiable code. See the "Verification" section in Remarks for <see cref="T:System.Reflection.Emit.DynamicMethod" />.</exception>
		// Token: 0x06004933 RID: 18739 RVA: 0x00108718 File Offset: 0x00106918
		[SecuritySafeCritical]
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			if ((this.CallingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_CallToVarArg"));
			}
			RuntimeMethodHandle methodDescriptor = this.GetMethodDescriptor();
			Signature signature = new Signature(this.m_methodHandle, this.m_parameterTypes, this.m_returnType, this.CallingConvention);
			int num = signature.Arguments.Length;
			int num2 = (parameters != null) ? parameters.Length : 0;
			if (num != num2)
			{
				throw new TargetParameterCountException(Environment.GetResourceString("Arg_ParmCnt"));
			}
			object result;
			if (num2 > 0)
			{
				object[] array = base.CheckArguments(parameters, binder, invokeAttr, culture, signature);
				result = RuntimeMethodHandle.InvokeMethod(null, array, signature, false);
				for (int i = 0; i < array.Length; i++)
				{
					parameters[i] = array[i];
				}
			}
			else
			{
				result = RuntimeMethodHandle.InvokeMethod(null, null, signature, false);
			}
			GC.KeepAlive(this);
			return result;
		}

		/// <summary>Returns the custom attributes of the specified type that have been applied to the method.</summary>
		/// <param name="attributeType">A <see cref="T:System.Type" /> representing the type of custom attribute to return.</param>
		/// <param name="inherit">
		///   <see langword="true" /> to search the method's inheritance chain to find the custom attributes; <see langword="false" /> to check only the current method.</param>
		/// <returns>An array of objects representing the attributes of the method that are of type <paramref name="attributeType" /> or derive from type <paramref name="attributeType" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		// Token: 0x06004934 RID: 18740 RVA: 0x001087E2 File Offset: 0x001069E2
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.m_dynMethod.GetCustomAttributes(attributeType, inherit);
		}

		/// <summary>Returns all the custom attributes defined for the method.</summary>
		/// <param name="inherit">
		///   <see langword="true" /> to search the method's inheritance chain to find the custom attributes; <see langword="false" /> to check only the current method.</param>
		/// <returns>An array of objects representing all the custom attributes of the method.</returns>
		// Token: 0x06004935 RID: 18741 RVA: 0x001087F1 File Offset: 0x001069F1
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.m_dynMethod.GetCustomAttributes(inherit);
		}

		/// <summary>Indicates whether the specified custom attribute type is defined.</summary>
		/// <param name="attributeType">A <see cref="T:System.Type" /> representing the type of custom attribute to search for.</param>
		/// <param name="inherit">
		///   <see langword="true" /> to search the method's inheritance chain to find the custom attributes; <see langword="false" /> to check only the current method.</param>
		/// <returns>
		///   <see langword="true" /> if the specified custom attribute type is defined; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004936 RID: 18742 RVA: 0x001087FF File Offset: 0x001069FF
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.m_dynMethod.IsDefined(attributeType, inherit);
		}

		/// <summary>Gets the type of return value for the dynamic method.</summary>
		/// <returns>A <see cref="T:System.Type" /> representing the type of the return value of the current method; <see cref="T:System.Void" /> if the method has no return type.</returns>
		// Token: 0x17000B85 RID: 2949
		// (get) Token: 0x06004937 RID: 18743 RVA: 0x0010880E File Offset: 0x00106A0E
		public override Type ReturnType
		{
			get
			{
				return this.m_dynMethod.ReturnType;
			}
		}

		/// <summary>Gets the return parameter of the dynamic method.</summary>
		/// <returns>Always <see langword="null" />.</returns>
		// Token: 0x17000B86 RID: 2950
		// (get) Token: 0x06004938 RID: 18744 RVA: 0x0010881B File Offset: 0x00106A1B
		public override ParameterInfo ReturnParameter
		{
			get
			{
				return this.m_dynMethod.ReturnParameter;
			}
		}

		/// <summary>Gets the custom attributes of the return type for the dynamic method.</summary>
		/// <returns>An <see cref="T:System.Reflection.ICustomAttributeProvider" /> representing the custom attributes of the return type for the dynamic method.</returns>
		// Token: 0x17000B87 RID: 2951
		// (get) Token: 0x06004939 RID: 18745 RVA: 0x00108828 File Offset: 0x00106A28
		public override ICustomAttributeProvider ReturnTypeCustomAttributes
		{
			get
			{
				return this.m_dynMethod.ReturnTypeCustomAttributes;
			}
		}

		/// <summary>Defines a parameter of the dynamic method.</summary>
		/// <param name="position">The position of the parameter in the parameter list. Parameters are indexed beginning with the number 1 for the first parameter.</param>
		/// <param name="attributes">A bitwise combination of <see cref="T:System.Reflection.ParameterAttributes" /> values that specifies the attributes of the parameter.</param>
		/// <param name="parameterName">The name of the parameter. The name can be a zero-length string.</param>
		/// <returns>Always returns <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The method has no parameters.  
		///  -or-  
		///  <paramref name="position" /> is less than 0.  
		///  -or-  
		///  <paramref name="position" /> is greater than the number of the method's parameters.</exception>
		// Token: 0x0600493A RID: 18746 RVA: 0x00108838 File Offset: 0x00106A38
		public ParameterBuilder DefineParameter(int position, ParameterAttributes attributes, string parameterName)
		{
			if (position < 0 || position > this.m_parameterTypes.Length)
			{
				throw new ArgumentOutOfRangeException(Environment.GetResourceString("ArgumentOutOfRange_ParamSequence"));
			}
			position--;
			if (position >= 0)
			{
				ParameterInfo[] array = this.m_dynMethod.LoadParameters();
				array[position].SetName(parameterName);
				array[position].SetAttributes(attributes);
			}
			return null;
		}

		/// <summary>Returns a <see cref="T:System.Reflection.Emit.DynamicILInfo" /> object that can be used to generate a method body from metadata tokens, scopes, and Microsoft intermediate language (MSIL) streams.</summary>
		/// <returns>A <see cref="T:System.Reflection.Emit.DynamicILInfo" /> object that can be used to generate a method body from metadata tokens, scopes, and MSIL streams.</returns>
		// Token: 0x0600493B RID: 18747 RVA: 0x0010888C File Offset: 0x00106A8C
		[SecuritySafeCritical]
		public DynamicILInfo GetDynamicILInfo()
		{
			new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
			if (this.m_DynamicILInfo != null)
			{
				return this.m_DynamicILInfo;
			}
			return this.GetDynamicILInfo(new DynamicScope());
		}

		// Token: 0x0600493C RID: 18748 RVA: 0x001088B4 File Offset: 0x00106AB4
		[SecurityCritical]
		internal DynamicILInfo GetDynamicILInfo(DynamicScope scope)
		{
			if (this.m_DynamicILInfo == null)
			{
				byte[] signature = SignatureHelper.GetMethodSigHelper(null, this.CallingConvention, this.ReturnType, null, null, this.m_parameterTypes, null, null).GetSignature(true);
				this.m_DynamicILInfo = new DynamicILInfo(scope, this, signature);
			}
			return this.m_DynamicILInfo;
		}

		/// <summary>Returns a Microsoft intermediate language (MSIL) generator for the method with a default MSIL stream size of 64 bytes.</summary>
		/// <returns>An <see cref="T:System.Reflection.Emit.ILGenerator" /> object for the method.</returns>
		// Token: 0x0600493D RID: 18749 RVA: 0x00108900 File Offset: 0x00106B00
		public ILGenerator GetILGenerator()
		{
			return this.GetILGenerator(64);
		}

		/// <summary>Returns a Microsoft intermediate language (MSIL) generator for the method with the specified MSIL stream size.</summary>
		/// <param name="streamSize">The size of the MSIL stream, in bytes.</param>
		/// <returns>An <see cref="T:System.Reflection.Emit.ILGenerator" /> object for the method, with the specified MSIL stream size.</returns>
		// Token: 0x0600493E RID: 18750 RVA: 0x0010890C File Offset: 0x00106B0C
		[SecuritySafeCritical]
		public ILGenerator GetILGenerator(int streamSize)
		{
			if (this.m_ilGenerator == null)
			{
				byte[] signature = SignatureHelper.GetMethodSigHelper(null, this.CallingConvention, this.ReturnType, null, null, this.m_parameterTypes, null, null).GetSignature(true);
				this.m_ilGenerator = new DynamicILGenerator(this, signature, streamSize);
			}
			return this.m_ilGenerator;
		}

		/// <summary>Gets or sets a value indicating whether the local variables in the method are zero-initialized.</summary>
		/// <returns>
		///   <see langword="true" /> if the local variables in the method are zero-initialized; otherwise, <see langword="false" />. The default is <see langword="true" />.</returns>
		// Token: 0x17000B88 RID: 2952
		// (get) Token: 0x0600493F RID: 18751 RVA: 0x00108958 File Offset: 0x00106B58
		// (set) Token: 0x06004940 RID: 18752 RVA: 0x00108960 File Offset: 0x00106B60
		public bool InitLocals
		{
			get
			{
				return this.m_fInitLocals;
			}
			set
			{
				this.m_fInitLocals = value;
			}
		}

		// Token: 0x06004941 RID: 18753 RVA: 0x00108969 File Offset: 0x00106B69
		internal MethodInfo GetMethodInfo()
		{
			return this.m_dynMethod;
		}

		// Token: 0x04001DE2 RID: 7650
		private RuntimeType[] m_parameterTypes;

		// Token: 0x04001DE3 RID: 7651
		internal IRuntimeMethodInfo m_methodHandle;

		// Token: 0x04001DE4 RID: 7652
		private RuntimeType m_returnType;

		// Token: 0x04001DE5 RID: 7653
		private DynamicILGenerator m_ilGenerator;

		// Token: 0x04001DE6 RID: 7654
		private DynamicILInfo m_DynamicILInfo;

		// Token: 0x04001DE7 RID: 7655
		private bool m_fInitLocals;

		// Token: 0x04001DE8 RID: 7656
		private RuntimeModule m_module;

		// Token: 0x04001DE9 RID: 7657
		internal bool m_skipVisibility;

		// Token: 0x04001DEA RID: 7658
		internal RuntimeType m_typeOwner;

		// Token: 0x04001DEB RID: 7659
		private DynamicMethod.RTDynamicMethod m_dynMethod;

		// Token: 0x04001DEC RID: 7660
		internal DynamicResolver m_resolver;

		// Token: 0x04001DED RID: 7661
		private bool m_profileAPICheck;

		// Token: 0x04001DEE RID: 7662
		private RuntimeAssembly m_creatorAssembly;

		// Token: 0x04001DEF RID: 7663
		internal bool m_restrictedSkipVisibility;

		// Token: 0x04001DF0 RID: 7664
		internal CompressedStack m_creationContext;

		// Token: 0x04001DF1 RID: 7665
		private static volatile InternalModuleBuilder s_anonymouslyHostedDynamicMethodsModule;

		// Token: 0x04001DF2 RID: 7666
		private static readonly object s_anonymouslyHostedDynamicMethodsModuleLock = new object();

		// Token: 0x02000C0C RID: 3084
		internal class RTDynamicMethod : MethodInfo
		{
			// Token: 0x06006F24 RID: 28452 RVA: 0x0017E440 File Offset: 0x0017C640
			private RTDynamicMethod()
			{
			}

			// Token: 0x06006F25 RID: 28453 RVA: 0x0017E448 File Offset: 0x0017C648
			internal RTDynamicMethod(DynamicMethod owner, string name, MethodAttributes attributes, CallingConventions callingConvention)
			{
				this.m_owner = owner;
				this.m_name = name;
				this.m_attributes = attributes;
				this.m_callingConvention = callingConvention;
			}

			// Token: 0x06006F26 RID: 28454 RVA: 0x0017E46D File Offset: 0x0017C66D
			public override string ToString()
			{
				return this.ReturnType.FormatTypeName() + " " + base.FormatNameAndSig();
			}

			// Token: 0x17001327 RID: 4903
			// (get) Token: 0x06006F27 RID: 28455 RVA: 0x0017E48A File Offset: 0x0017C68A
			public override string Name
			{
				get
				{
					return this.m_name;
				}
			}

			// Token: 0x17001328 RID: 4904
			// (get) Token: 0x06006F28 RID: 28456 RVA: 0x0017E492 File Offset: 0x0017C692
			public override Type DeclaringType
			{
				get
				{
					return null;
				}
			}

			// Token: 0x17001329 RID: 4905
			// (get) Token: 0x06006F29 RID: 28457 RVA: 0x0017E495 File Offset: 0x0017C695
			public override Type ReflectedType
			{
				get
				{
					return null;
				}
			}

			// Token: 0x1700132A RID: 4906
			// (get) Token: 0x06006F2A RID: 28458 RVA: 0x0017E498 File Offset: 0x0017C698
			public override Module Module
			{
				get
				{
					return this.m_owner.m_module;
				}
			}

			// Token: 0x1700132B RID: 4907
			// (get) Token: 0x06006F2B RID: 28459 RVA: 0x0017E4A5 File Offset: 0x0017C6A5
			public override RuntimeMethodHandle MethodHandle
			{
				get
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotAllowedInDynamicMethod"));
				}
			}

			// Token: 0x1700132C RID: 4908
			// (get) Token: 0x06006F2C RID: 28460 RVA: 0x0017E4B6 File Offset: 0x0017C6B6
			public override MethodAttributes Attributes
			{
				get
				{
					return this.m_attributes;
				}
			}

			// Token: 0x1700132D RID: 4909
			// (get) Token: 0x06006F2D RID: 28461 RVA: 0x0017E4BE File Offset: 0x0017C6BE
			public override CallingConventions CallingConvention
			{
				get
				{
					return this.m_callingConvention;
				}
			}

			// Token: 0x06006F2E RID: 28462 RVA: 0x0017E4C6 File Offset: 0x0017C6C6
			public override MethodInfo GetBaseDefinition()
			{
				return this;
			}

			// Token: 0x06006F2F RID: 28463 RVA: 0x0017E4CC File Offset: 0x0017C6CC
			public override ParameterInfo[] GetParameters()
			{
				ParameterInfo[] array = this.LoadParameters();
				ParameterInfo[] array2 = new ParameterInfo[array.Length];
				Array.Copy(array, array2, array.Length);
				return array2;
			}

			// Token: 0x06006F30 RID: 28464 RVA: 0x0017E4F4 File Offset: 0x0017C6F4
			public override MethodImplAttributes GetMethodImplementationFlags()
			{
				return MethodImplAttributes.NoInlining;
			}

			// Token: 0x06006F31 RID: 28465 RVA: 0x0017E4F7 File Offset: 0x0017C6F7
			public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"), "this");
			}

			// Token: 0x06006F32 RID: 28466 RVA: 0x0017E510 File Offset: 0x0017C710
			public override object[] GetCustomAttributes(Type attributeType, bool inherit)
			{
				if (attributeType == null)
				{
					throw new ArgumentNullException("attributeType");
				}
				if (attributeType.IsAssignableFrom(typeof(MethodImplAttribute)))
				{
					return new object[]
					{
						new MethodImplAttribute(this.GetMethodImplementationFlags())
					};
				}
				return EmptyArray<object>.Value;
			}

			// Token: 0x06006F33 RID: 28467 RVA: 0x0017E55D File Offset: 0x0017C75D
			public override object[] GetCustomAttributes(bool inherit)
			{
				return new object[]
				{
					new MethodImplAttribute(this.GetMethodImplementationFlags())
				};
			}

			// Token: 0x06006F34 RID: 28468 RVA: 0x0017E573 File Offset: 0x0017C773
			public override bool IsDefined(Type attributeType, bool inherit)
			{
				if (attributeType == null)
				{
					throw new ArgumentNullException("attributeType");
				}
				return attributeType.IsAssignableFrom(typeof(MethodImplAttribute));
			}

			// Token: 0x1700132E RID: 4910
			// (get) Token: 0x06006F35 RID: 28469 RVA: 0x0017E59E File Offset: 0x0017C79E
			public override bool IsSecurityCritical
			{
				get
				{
					return this.m_owner.IsSecurityCritical;
				}
			}

			// Token: 0x1700132F RID: 4911
			// (get) Token: 0x06006F36 RID: 28470 RVA: 0x0017E5AB File Offset: 0x0017C7AB
			public override bool IsSecuritySafeCritical
			{
				get
				{
					return this.m_owner.IsSecuritySafeCritical;
				}
			}

			// Token: 0x17001330 RID: 4912
			// (get) Token: 0x06006F37 RID: 28471 RVA: 0x0017E5B8 File Offset: 0x0017C7B8
			public override bool IsSecurityTransparent
			{
				get
				{
					return this.m_owner.IsSecurityTransparent;
				}
			}

			// Token: 0x17001331 RID: 4913
			// (get) Token: 0x06006F38 RID: 28472 RVA: 0x0017E5C5 File Offset: 0x0017C7C5
			public override Type ReturnType
			{
				get
				{
					return this.m_owner.m_returnType;
				}
			}

			// Token: 0x17001332 RID: 4914
			// (get) Token: 0x06006F39 RID: 28473 RVA: 0x0017E5D2 File Offset: 0x0017C7D2
			public override ParameterInfo ReturnParameter
			{
				get
				{
					return null;
				}
			}

			// Token: 0x17001333 RID: 4915
			// (get) Token: 0x06006F3A RID: 28474 RVA: 0x0017E5D5 File Offset: 0x0017C7D5
			public override ICustomAttributeProvider ReturnTypeCustomAttributes
			{
				get
				{
					return this.GetEmptyCAHolder();
				}
			}

			// Token: 0x06006F3B RID: 28475 RVA: 0x0017E5E0 File Offset: 0x0017C7E0
			internal ParameterInfo[] LoadParameters()
			{
				if (this.m_parameters == null)
				{
					Type[] parameterTypes = this.m_owner.m_parameterTypes;
					ParameterInfo[] array = new ParameterInfo[parameterTypes.Length];
					for (int i = 0; i < parameterTypes.Length; i++)
					{
						array[i] = new RuntimeParameterInfo(this, null, parameterTypes[i], i);
					}
					if (this.m_parameters == null)
					{
						this.m_parameters = array;
					}
				}
				return this.m_parameters;
			}

			// Token: 0x06006F3C RID: 28476 RVA: 0x0017E63B File Offset: 0x0017C83B
			private ICustomAttributeProvider GetEmptyCAHolder()
			{
				return new DynamicMethod.RTDynamicMethod.EmptyCAHolder();
			}

			// Token: 0x0400366E RID: 13934
			internal DynamicMethod m_owner;

			// Token: 0x0400366F RID: 13935
			private ParameterInfo[] m_parameters;

			// Token: 0x04003670 RID: 13936
			private string m_name;

			// Token: 0x04003671 RID: 13937
			private MethodAttributes m_attributes;

			// Token: 0x04003672 RID: 13938
			private CallingConventions m_callingConvention;

			// Token: 0x02000CD7 RID: 3287
			private class EmptyCAHolder : ICustomAttributeProvider
			{
				// Token: 0x060070F7 RID: 28919 RVA: 0x001849C7 File Offset: 0x00182BC7
				internal EmptyCAHolder()
				{
				}

				// Token: 0x060070F8 RID: 28920 RVA: 0x001849CF File Offset: 0x00182BCF
				object[] ICustomAttributeProvider.GetCustomAttributes(Type attributeType, bool inherit)
				{
					return EmptyArray<object>.Value;
				}

				// Token: 0x060070F9 RID: 28921 RVA: 0x001849D6 File Offset: 0x00182BD6
				object[] ICustomAttributeProvider.GetCustomAttributes(bool inherit)
				{
					return EmptyArray<object>.Value;
				}

				// Token: 0x060070FA RID: 28922 RVA: 0x001849DD File Offset: 0x00182BDD
				bool ICustomAttributeProvider.IsDefined(Type attributeType, bool inherit)
				{
					return false;
				}
			}
		}
	}
}
