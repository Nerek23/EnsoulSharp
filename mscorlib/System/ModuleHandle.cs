using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace System
{
	/// <summary>Represents a runtime handle for a module.</summary>
	// Token: 0x02000139 RID: 313
	[ComVisible(true)]
	public struct ModuleHandle
	{
		// Token: 0x060012A8 RID: 4776 RVA: 0x000379D4 File Offset: 0x00035BD4
		private static ModuleHandle GetEmptyMH()
		{
			return default(ModuleHandle);
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x000379EA File Offset: 0x00035BEA
		internal ModuleHandle(RuntimeModule module)
		{
			this.m_ptr = module;
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x000379F3 File Offset: 0x00035BF3
		internal RuntimeModule GetRuntimeModule()
		{
			return this.m_ptr;
		}

		// Token: 0x060012AB RID: 4779 RVA: 0x000379FB File Offset: 0x00035BFB
		internal bool IsNullHandle()
		{
			return this.m_ptr == null;
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
		// Token: 0x060012AC RID: 4780 RVA: 0x00037A09 File Offset: 0x00035C09
		public override int GetHashCode()
		{
			if (!(this.m_ptr != null))
			{
				return 0;
			}
			return this.m_ptr.GetHashCode();
		}

		/// <summary>Returns a <see cref="T:System.Boolean" /> value indicating whether the specified object is a <see cref="T:System.ModuleHandle" /> structure, and equal to the current <see cref="T:System.ModuleHandle" />.</summary>
		/// <param name="obj">The object to be compared with the current <see cref="T:System.ModuleHandle" /> structure.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is a <see cref="T:System.ModuleHandle" /> structure, and is equal to the current <see cref="T:System.ModuleHandle" /> structure; otherwise, <see langword="false" />.</returns>
		// Token: 0x060012AD RID: 4781 RVA: 0x00037A28 File Offset: 0x00035C28
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public override bool Equals(object obj)
		{
			if (!(obj is ModuleHandle))
			{
				return false;
			}
			ModuleHandle moduleHandle = (ModuleHandle)obj;
			return moduleHandle.m_ptr == this.m_ptr;
		}

		/// <summary>Returns a <see cref="T:System.Boolean" /> value indicating whether the specified <see cref="T:System.ModuleHandle" /> structure is equal to the current <see cref="T:System.ModuleHandle" />.</summary>
		/// <param name="handle">The <see cref="T:System.ModuleHandle" /> structure to be compared with the current <see cref="T:System.ModuleHandle" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="handle" /> is equal to the current <see cref="T:System.ModuleHandle" /> structure; otherwise <see langword="false" />.</returns>
		// Token: 0x060012AE RID: 4782 RVA: 0x00037A57 File Offset: 0x00035C57
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public bool Equals(ModuleHandle handle)
		{
			return handle.m_ptr == this.m_ptr;
		}

		/// <summary>Tests whether two <see cref="T:System.ModuleHandle" /> structures are equal.</summary>
		/// <param name="left">The <see cref="T:System.ModuleHandle" /> structure to the left of the equality operator.</param>
		/// <param name="right">The <see cref="T:System.ModuleHandle" /> structure to the right of the equality operator.</param>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.ModuleHandle" /> structures are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x060012AF RID: 4783 RVA: 0x00037A6A File Offset: 0x00035C6A
		public static bool operator ==(ModuleHandle left, ModuleHandle right)
		{
			return left.Equals(right);
		}

		/// <summary>Tests whether two <see cref="T:System.ModuleHandle" /> structures are unequal.</summary>
		/// <param name="left">The <see cref="T:System.ModuleHandle" /> structure to the left of the inequality operator.</param>
		/// <param name="right">The <see cref="T:System.ModuleHandle" /> structure to the right of the inequality operator.</param>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.ModuleHandle" /> structures are unequal; otherwise, <see langword="false" />.</returns>
		// Token: 0x060012B0 RID: 4784 RVA: 0x00037A74 File Offset: 0x00035C74
		public static bool operator !=(ModuleHandle left, ModuleHandle right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060012B1 RID: 4785
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IRuntimeMethodInfo GetDynamicMethod(DynamicMethod method, RuntimeModule module, string name, byte[] sig, Resolver resolver);

		// Token: 0x060012B2 RID: 4786
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int GetToken(RuntimeModule module);

		// Token: 0x060012B3 RID: 4787 RVA: 0x00037A81 File Offset: 0x00035C81
		private static void ValidateModulePointer(RuntimeModule module)
		{
			if (module == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NullModuleHandle"));
			}
		}

		/// <summary>Returns a runtime type handle for the type identified by the specified metadata token.</summary>
		/// <param name="typeToken">A metadata token that identifies a type in the module.</param>
		/// <returns>A <see cref="T:System.RuntimeTypeHandle" /> for the type identified by <paramref name="typeToken" />.</returns>
		// Token: 0x060012B4 RID: 4788 RVA: 0x00037A9C File Offset: 0x00035C9C
		public RuntimeTypeHandle GetRuntimeTypeHandleFromMetadataToken(int typeToken)
		{
			return this.ResolveTypeHandle(typeToken);
		}

		/// <summary>Returns a runtime type handle for the type identified by the specified metadata token.</summary>
		/// <param name="typeToken">A metadata token that identifies a type in the module.</param>
		/// <returns>A <see cref="T:System.RuntimeTypeHandle" /> for the type identified by <paramref name="typeToken" />.</returns>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="typeToken" /> is not a valid metadata token for a type in the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is not a token for a type in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="TypeSpec" /> whose signature contains element type <see langword="var" /> or <see langword="mvar" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The method is called on an empty type handle.</exception>
		// Token: 0x060012B5 RID: 4789 RVA: 0x00037AA5 File Offset: 0x00035CA5
		public RuntimeTypeHandle ResolveTypeHandle(int typeToken)
		{
			return new RuntimeTypeHandle(ModuleHandle.ResolveTypeHandleInternal(this.GetRuntimeModule(), typeToken, null, null));
		}

		/// <summary>Returns a runtime type handle for the type identified by the specified metadata token, specifying the generic type arguments of the type and method where the token is in scope.</summary>
		/// <param name="typeToken">A metadata token that identifies a type in the module.</param>
		/// <param name="typeInstantiationContext">An array of <see cref="T:System.RuntimeTypeHandle" /> structures representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="methodInstantiationContext">An array of <see cref="T:System.RuntimeTypeHandle" /> structures objects representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.RuntimeTypeHandle" /> for the type identified by <paramref name="typeToken" />.</returns>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="typeToken" /> is not a valid metadata token for a type in the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is not a token for a type in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="TypeSpec" /> whose signature contains element type <see langword="var" /> or <see langword="mvar" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The method is called on an empty type handle.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="typeToken" /> is not a valid token.</exception>
		// Token: 0x060012B6 RID: 4790 RVA: 0x00037ABA File Offset: 0x00035CBA
		public RuntimeTypeHandle ResolveTypeHandle(int typeToken, RuntimeTypeHandle[] typeInstantiationContext, RuntimeTypeHandle[] methodInstantiationContext)
		{
			return new RuntimeTypeHandle(ModuleHandle.ResolveTypeHandleInternal(this.GetRuntimeModule(), typeToken, typeInstantiationContext, methodInstantiationContext));
		}

		// Token: 0x060012B7 RID: 4791 RVA: 0x00037AD0 File Offset: 0x00035CD0
		[SecuritySafeCritical]
		internal unsafe static RuntimeType ResolveTypeHandleInternal(RuntimeModule module, int typeToken, RuntimeTypeHandle[] typeInstantiationContext, RuntimeTypeHandle[] methodInstantiationContext)
		{
			ModuleHandle.ValidateModulePointer(module);
			if (!ModuleHandle.GetMetadataImport(module).IsValidToken(typeToken))
			{
				throw new ArgumentOutOfRangeException("metadataToken", Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					typeToken,
					new ModuleHandle(module)
				}));
			}
			int typeInstCount;
			IntPtr[] array = RuntimeTypeHandle.CopyRuntimeTypeHandles(typeInstantiationContext, out typeInstCount);
			int methodInstCount;
			IntPtr[] array2 = RuntimeTypeHandle.CopyRuntimeTypeHandles(methodInstantiationContext, out methodInstCount);
			fixed (IntPtr* ptr = array)
			{
				fixed (IntPtr* ptr2 = array2)
				{
					RuntimeType result = null;
					ModuleHandle.ResolveType(module, typeToken, ptr, typeInstCount, ptr2, methodInstCount, JitHelpers.GetObjectHandleOnStack<RuntimeType>(ref result));
					GC.KeepAlive(typeInstantiationContext);
					GC.KeepAlive(methodInstantiationContext);
					return result;
				}
			}
		}

		// Token: 0x060012B8 RID: 4792
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private unsafe static extern void ResolveType(RuntimeModule module, int typeToken, IntPtr* typeInstArgs, int typeInstCount, IntPtr* methodInstArgs, int methodInstCount, ObjectHandleOnStack type);

		/// <summary>Returns a runtime method handle for the method or constructor identified by the specified metadata token.</summary>
		/// <param name="methodToken">A metadata token that identifies a method or constructor in the module.</param>
		/// <returns>A <see cref="T:System.RuntimeMethodHandle" /> for the method or constructor identified by <paramref name="methodToken" />.</returns>
		// Token: 0x060012B9 RID: 4793 RVA: 0x00037B98 File Offset: 0x00035D98
		public RuntimeMethodHandle GetRuntimeMethodHandleFromMetadataToken(int methodToken)
		{
			return this.ResolveMethodHandle(methodToken);
		}

		/// <summary>Returns a runtime method handle for the method or constructor identified by the specified metadata token.</summary>
		/// <param name="methodToken">A metadata token that identifies a method or constructor in the module.</param>
		/// <returns>A <see cref="T:System.RuntimeMethodHandle" /> for the method or constructor identified by <paramref name="methodToken" />.</returns>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="methodToken" /> is not a valid metadata token for a method in the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is not a token for a method or constructor in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="MethodSpec" /> whose signature contains element type <see langword="var" /> or <see langword="mvar" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The method is called on an empty method handle.</exception>
		// Token: 0x060012BA RID: 4794 RVA: 0x00037BA1 File Offset: 0x00035DA1
		public RuntimeMethodHandle ResolveMethodHandle(int methodToken)
		{
			return this.ResolveMethodHandle(methodToken, null, null);
		}

		// Token: 0x060012BB RID: 4795 RVA: 0x00037BAC File Offset: 0x00035DAC
		internal static IRuntimeMethodInfo ResolveMethodHandleInternal(RuntimeModule module, int methodToken)
		{
			return ModuleHandle.ResolveMethodHandleInternal(module, methodToken, null, null);
		}

		/// <summary>Returns a runtime method handle for the method or constructor identified by the specified metadata token, specifying the generic type arguments of the type and method where the token is in scope.</summary>
		/// <param name="methodToken">A metadata token that identifies a method or constructor in the module.</param>
		/// <param name="typeInstantiationContext">An array of <see cref="T:System.RuntimeTypeHandle" /> structures representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="methodInstantiationContext">An array of <see cref="T:System.RuntimeTypeHandle" /> structures representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.RuntimeMethodHandle" /> for the method or constructor identified by <paramref name="methodToken" />.</returns>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="methodToken" /> is not a valid metadata token for a method in the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is not a token for a method or constructor in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="MethodSpec" /> whose signature contains element type <see langword="var" /> or <see langword="mvar" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The method is called on an empty method handle.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="methodToken" /> is not a valid token.</exception>
		// Token: 0x060012BC RID: 4796 RVA: 0x00037BB7 File Offset: 0x00035DB7
		public RuntimeMethodHandle ResolveMethodHandle(int methodToken, RuntimeTypeHandle[] typeInstantiationContext, RuntimeTypeHandle[] methodInstantiationContext)
		{
			return new RuntimeMethodHandle(ModuleHandle.ResolveMethodHandleInternal(this.GetRuntimeModule(), methodToken, typeInstantiationContext, methodInstantiationContext));
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x00037BCC File Offset: 0x00035DCC
		[SecuritySafeCritical]
		internal static IRuntimeMethodInfo ResolveMethodHandleInternal(RuntimeModule module, int methodToken, RuntimeTypeHandle[] typeInstantiationContext, RuntimeTypeHandle[] methodInstantiationContext)
		{
			int typeInstCount;
			IntPtr[] typeInstantiationContext2 = RuntimeTypeHandle.CopyRuntimeTypeHandles(typeInstantiationContext, out typeInstCount);
			int methodInstCount;
			IntPtr[] methodInstantiationContext2 = RuntimeTypeHandle.CopyRuntimeTypeHandles(methodInstantiationContext, out methodInstCount);
			RuntimeMethodHandleInternal runtimeMethodHandleInternal = ModuleHandle.ResolveMethodHandleInternalCore(module, methodToken, typeInstantiationContext2, typeInstCount, methodInstantiationContext2, methodInstCount);
			IRuntimeMethodInfo result = new RuntimeMethodInfoStub(runtimeMethodHandleInternal, RuntimeMethodHandle.GetLoaderAllocator(runtimeMethodHandleInternal));
			GC.KeepAlive(typeInstantiationContext);
			GC.KeepAlive(methodInstantiationContext);
			return result;
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x00037C18 File Offset: 0x00035E18
		[SecurityCritical]
		internal unsafe static RuntimeMethodHandleInternal ResolveMethodHandleInternalCore(RuntimeModule module, int methodToken, IntPtr[] typeInstantiationContext, int typeInstCount, IntPtr[] methodInstantiationContext, int methodInstCount)
		{
			ModuleHandle.ValidateModulePointer(module);
			if (!ModuleHandle.GetMetadataImport(module.GetNativeHandle()).IsValidToken(methodToken))
			{
				throw new ArgumentOutOfRangeException("metadataToken", Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					methodToken,
					new ModuleHandle(module)
				}));
			}
			fixed (IntPtr* ptr = typeInstantiationContext)
			{
				fixed (IntPtr* ptr2 = methodInstantiationContext)
				{
					return ModuleHandle.ResolveMethod(module.GetNativeHandle(), methodToken, ptr, typeInstCount, ptr2, methodInstCount);
				}
			}
		}

		// Token: 0x060012BF RID: 4799
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private unsafe static extern RuntimeMethodHandleInternal ResolveMethod(RuntimeModule module, int methodToken, IntPtr* typeInstArgs, int typeInstCount, IntPtr* methodInstArgs, int methodInstCount);

		/// <summary>Returns a runtime handle for the field identified by the specified metadata token.</summary>
		/// <param name="fieldToken">A metadata token that identifies a field in the module.</param>
		/// <returns>A <see cref="T:System.RuntimeFieldHandle" /> for the field identified by <paramref name="fieldToken" />.</returns>
		// Token: 0x060012C0 RID: 4800 RVA: 0x00037CB8 File Offset: 0x00035EB8
		public RuntimeFieldHandle GetRuntimeFieldHandleFromMetadataToken(int fieldToken)
		{
			return this.ResolveFieldHandle(fieldToken);
		}

		/// <summary>Returns a runtime handle for the field identified by the specified metadata token.</summary>
		/// <param name="fieldToken">A metadata token that identifies a field in the module.</param>
		/// <returns>A <see cref="T:System.RuntimeFieldHandle" /> for the field identified by <paramref name="fieldToken" />.</returns>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is not a token for a field in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> identifies a field whose parent <see langword="TypeSpec" /> has a signature containing element type <see langword="var" /> or <see langword="mvar" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The method is called on an empty field handle.</exception>
		// Token: 0x060012C1 RID: 4801 RVA: 0x00037CC1 File Offset: 0x00035EC1
		public RuntimeFieldHandle ResolveFieldHandle(int fieldToken)
		{
			return new RuntimeFieldHandle(ModuleHandle.ResolveFieldHandleInternal(this.GetRuntimeModule(), fieldToken, null, null));
		}

		/// <summary>Returns a runtime field handle for the field identified by the specified metadata token, specifying the generic type arguments of the type and method where the token is in scope.</summary>
		/// <param name="fieldToken">A metadata token that identifies a field in the module.</param>
		/// <param name="typeInstantiationContext">An array of <see cref="T:System.RuntimeTypeHandle" /> structures representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="methodInstantiationContext">An array of <see cref="T:System.RuntimeTypeHandle" /> structures representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.RuntimeFieldHandle" /> for the field identified by <paramref name="fieldToken" />.</returns>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is not a token for a field in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> identifies a field whose parent <see langword="TypeSpec" /> has a signature containing element type <see langword="var" /> or <see langword="mvar" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The method is called on an empty field handle.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="fieldToken" /> is not a valid token.</exception>
		// Token: 0x060012C2 RID: 4802 RVA: 0x00037CD6 File Offset: 0x00035ED6
		public RuntimeFieldHandle ResolveFieldHandle(int fieldToken, RuntimeTypeHandle[] typeInstantiationContext, RuntimeTypeHandle[] methodInstantiationContext)
		{
			return new RuntimeFieldHandle(ModuleHandle.ResolveFieldHandleInternal(this.GetRuntimeModule(), fieldToken, typeInstantiationContext, methodInstantiationContext));
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x00037CEC File Offset: 0x00035EEC
		[SecuritySafeCritical]
		internal unsafe static IRuntimeFieldInfo ResolveFieldHandleInternal(RuntimeModule module, int fieldToken, RuntimeTypeHandle[] typeInstantiationContext, RuntimeTypeHandle[] methodInstantiationContext)
		{
			ModuleHandle.ValidateModulePointer(module);
			if (!ModuleHandle.GetMetadataImport(module.GetNativeHandle()).IsValidToken(fieldToken))
			{
				throw new ArgumentOutOfRangeException("metadataToken", Environment.GetResourceString("Argument_InvalidToken", new object[]
				{
					fieldToken,
					new ModuleHandle(module)
				}));
			}
			int typeInstCount;
			IntPtr[] array = RuntimeTypeHandle.CopyRuntimeTypeHandles(typeInstantiationContext, out typeInstCount);
			int methodInstCount;
			IntPtr[] array2 = RuntimeTypeHandle.CopyRuntimeTypeHandles(methodInstantiationContext, out methodInstCount);
			fixed (IntPtr* ptr = array)
			{
				fixed (IntPtr* ptr2 = array2)
				{
					IRuntimeFieldInfo result = null;
					ModuleHandle.ResolveField(module.GetNativeHandle(), fieldToken, ptr, typeInstCount, ptr2, methodInstCount, JitHelpers.GetObjectHandleOnStack<IRuntimeFieldInfo>(ref result));
					GC.KeepAlive(typeInstantiationContext);
					GC.KeepAlive(methodInstantiationContext);
					return result;
				}
			}
		}

		// Token: 0x060012C4 RID: 4804
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private unsafe static extern void ResolveField(RuntimeModule module, int fieldToken, IntPtr* typeInstArgs, int typeInstCount, IntPtr* methodInstArgs, int methodInstCount, ObjectHandleOnStack retField);

		// Token: 0x060012C5 RID: 4805
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern bool _ContainsPropertyMatchingHash(RuntimeModule module, int propertyToken, uint hash);

		// Token: 0x060012C6 RID: 4806 RVA: 0x00037DBE File Offset: 0x00035FBE
		[SecurityCritical]
		internal static bool ContainsPropertyMatchingHash(RuntimeModule module, int propertyToken, uint hash)
		{
			return ModuleHandle._ContainsPropertyMatchingHash(module.GetNativeHandle(), propertyToken, hash);
		}

		// Token: 0x060012C7 RID: 4807
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetAssembly(RuntimeModule handle, ObjectHandleOnStack retAssembly);

		// Token: 0x060012C8 RID: 4808 RVA: 0x00037DD0 File Offset: 0x00035FD0
		[SecuritySafeCritical]
		internal static RuntimeAssembly GetAssembly(RuntimeModule module)
		{
			RuntimeAssembly result = null;
			ModuleHandle.GetAssembly(module.GetNativeHandle(), JitHelpers.GetObjectHandleOnStack<RuntimeAssembly>(ref result));
			return result;
		}

		// Token: 0x060012C9 RID: 4809
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void GetModuleType(RuntimeModule handle, ObjectHandleOnStack type);

		// Token: 0x060012CA RID: 4810 RVA: 0x00037DF4 File Offset: 0x00035FF4
		[SecuritySafeCritical]
		internal static RuntimeType GetModuleType(RuntimeModule module)
		{
			RuntimeType result = null;
			ModuleHandle.GetModuleType(module.GetNativeHandle(), JitHelpers.GetObjectHandleOnStack<RuntimeType>(ref result));
			return result;
		}

		// Token: 0x060012CB RID: 4811
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetPEKind(RuntimeModule handle, out int peKind, out int machine);

		// Token: 0x060012CC RID: 4812 RVA: 0x00037E18 File Offset: 0x00036018
		[SecuritySafeCritical]
		internal static void GetPEKind(RuntimeModule module, out PortableExecutableKinds peKind, out ImageFileMachine machine)
		{
			int num;
			int num2;
			ModuleHandle.GetPEKind(module.GetNativeHandle(), out num, out num2);
			peKind = (PortableExecutableKinds)num;
			machine = (ImageFileMachine)num2;
		}

		// Token: 0x060012CD RID: 4813
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int GetMDStreamVersion(RuntimeModule module);

		/// <summary>Gets the metadata stream version.</summary>
		/// <returns>A 32-bit integer representing the metadata stream version. The high-order two bytes represent the major version number, and the low-order two bytes represent the minor version number.</returns>
		// Token: 0x170001FA RID: 506
		// (get) Token: 0x060012CE RID: 4814 RVA: 0x00037E3A File Offset: 0x0003603A
		public int MDStreamVersion
		{
			[SecuritySafeCritical]
			get
			{
				return ModuleHandle.GetMDStreamVersion(this.GetRuntimeModule().GetNativeHandle());
			}
		}

		// Token: 0x060012CF RID: 4815
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr _GetMetadataImport(RuntimeModule module);

		// Token: 0x060012D0 RID: 4816 RVA: 0x00037E4C File Offset: 0x0003604C
		[SecurityCritical]
		internal static MetadataImport GetMetadataImport(RuntimeModule module)
		{
			return new MetadataImport(ModuleHandle._GetMetadataImport(module.GetNativeHandle()), module);
		}

		/// <summary>Represents an empty module handle.</summary>
		// Token: 0x04000675 RID: 1653
		public static readonly ModuleHandle EmptyHandle = ModuleHandle.GetEmptyMH();

		// Token: 0x04000676 RID: 1654
		private RuntimeModule m_ptr;
	}
}
