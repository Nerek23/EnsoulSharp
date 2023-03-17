using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	/// <summary>Defines and represents a module in a dynamic assembly.</summary>
	// Token: 0x02000624 RID: 1572
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_ModuleBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public class ModuleBuilder : Module, _ModuleBuilder
	{
		// Token: 0x06004AEC RID: 19180
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr nCreateISymWriterForDynamicModule(Module module, string filename);

		// Token: 0x06004AED RID: 19181 RVA: 0x0010E7C4 File Offset: 0x0010C9C4
		internal static string UnmangleTypeName(string typeName)
		{
			int num = typeName.Length - 1;
			for (;;)
			{
				num = typeName.LastIndexOf('+', num);
				if (num == -1)
				{
					break;
				}
				bool flag = true;
				int num2 = num;
				while (typeName[--num2] == '\\')
				{
					flag = !flag;
				}
				if (flag)
				{
					break;
				}
				num = num2;
			}
			return typeName.Substring(num + 1);
		}

		// Token: 0x17000BD8 RID: 3032
		// (get) Token: 0x06004AEE RID: 19182 RVA: 0x0010E812 File Offset: 0x0010CA12
		internal AssemblyBuilder ContainingAssemblyBuilder
		{
			get
			{
				return this.m_assemblyBuilder;
			}
		}

		// Token: 0x06004AEF RID: 19183 RVA: 0x0010E81A File Offset: 0x0010CA1A
		internal ModuleBuilder(AssemblyBuilder assemblyBuilder, InternalModuleBuilder internalModuleBuilder)
		{
			this.m_internalModuleBuilder = internalModuleBuilder;
			this.m_assemblyBuilder = assemblyBuilder;
		}

		// Token: 0x06004AF0 RID: 19184 RVA: 0x0010E830 File Offset: 0x0010CA30
		internal void AddType(string name, Type type)
		{
			this.m_TypeBuilderDict.Add(name, type);
		}

		// Token: 0x06004AF1 RID: 19185 RVA: 0x0010E840 File Offset: 0x0010CA40
		internal void CheckTypeNameConflict(string strTypeName, Type enclosingType)
		{
			Type type = null;
			if (this.m_TypeBuilderDict.TryGetValue(strTypeName, out type) && type.DeclaringType == enclosingType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_DuplicateTypeName"));
			}
		}

		// Token: 0x06004AF2 RID: 19186 RVA: 0x0010E878 File Offset: 0x0010CA78
		private Type GetType(string strFormat, Type baseType)
		{
			if (strFormat == null || strFormat.Equals(string.Empty))
			{
				return baseType;
			}
			char[] bFormat = strFormat.ToCharArray();
			return SymbolType.FormCompoundType(bFormat, baseType, 0);
		}

		// Token: 0x06004AF3 RID: 19187 RVA: 0x0010E8A6 File Offset: 0x0010CAA6
		internal void CheckContext(params Type[][] typess)
		{
			this.ContainingAssemblyBuilder.CheckContext(typess);
		}

		// Token: 0x06004AF4 RID: 19188 RVA: 0x0010E8B4 File Offset: 0x0010CAB4
		internal void CheckContext(params Type[] types)
		{
			this.ContainingAssemblyBuilder.CheckContext(types);
		}

		// Token: 0x06004AF5 RID: 19189
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int GetTypeRef(RuntimeModule module, string strFullName, RuntimeModule refedModule, string strRefedModuleFileName, int tkResolution);

		// Token: 0x06004AF6 RID: 19190
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int GetMemberRef(RuntimeModule module, RuntimeModule refedModule, int tr, int defToken);

		// Token: 0x06004AF7 RID: 19191 RVA: 0x0010E8C2 File Offset: 0x0010CAC2
		[SecurityCritical]
		private int GetMemberRef(Module refedModule, int tr, int defToken)
		{
			return ModuleBuilder.GetMemberRef(this.GetNativeHandle(), ModuleBuilder.GetRuntimeModuleFromModule(refedModule).GetNativeHandle(), tr, defToken);
		}

		// Token: 0x06004AF8 RID: 19192
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int GetMemberRefFromSignature(RuntimeModule module, int tr, string methodName, byte[] signature, int length);

		// Token: 0x06004AF9 RID: 19193 RVA: 0x0010E8DC File Offset: 0x0010CADC
		[SecurityCritical]
		private int GetMemberRefFromSignature(int tr, string methodName, byte[] signature, int length)
		{
			return ModuleBuilder.GetMemberRefFromSignature(this.GetNativeHandle(), tr, methodName, signature, length);
		}

		// Token: 0x06004AFA RID: 19194
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int GetMemberRefOfMethodInfo(RuntimeModule module, int tr, IRuntimeMethodInfo method);

		// Token: 0x06004AFB RID: 19195 RVA: 0x0010E8F0 File Offset: 0x0010CAF0
		[SecurityCritical]
		private int GetMemberRefOfMethodInfo(int tr, RuntimeMethodInfo method)
		{
			if (this.ContainingAssemblyBuilder.ProfileAPICheck && (method.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
				{
					method.FullName
				}));
			}
			return ModuleBuilder.GetMemberRefOfMethodInfo(this.GetNativeHandle(), tr, method);
		}

		// Token: 0x06004AFC RID: 19196 RVA: 0x0010E944 File Offset: 0x0010CB44
		[SecurityCritical]
		private int GetMemberRefOfMethodInfo(int tr, RuntimeConstructorInfo method)
		{
			if (this.ContainingAssemblyBuilder.ProfileAPICheck && (method.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
				{
					method.FullName
				}));
			}
			return ModuleBuilder.GetMemberRefOfMethodInfo(this.GetNativeHandle(), tr, method);
		}

		// Token: 0x06004AFD RID: 19197
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int GetMemberRefOfFieldInfo(RuntimeModule module, int tkType, RuntimeTypeHandle declaringType, int tkField);

		// Token: 0x06004AFE RID: 19198 RVA: 0x0010E998 File Offset: 0x0010CB98
		[SecurityCritical]
		private int GetMemberRefOfFieldInfo(int tkType, RuntimeTypeHandle declaringType, RuntimeFieldInfo runtimeField)
		{
			if (this.ContainingAssemblyBuilder.ProfileAPICheck)
			{
				RtFieldInfo rtFieldInfo = runtimeField as RtFieldInfo;
				if (rtFieldInfo != null && (rtFieldInfo.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						rtFieldInfo.FullName
					}));
				}
			}
			return ModuleBuilder.GetMemberRefOfFieldInfo(this.GetNativeHandle(), tkType, declaringType, runtimeField.MetadataToken);
		}

		// Token: 0x06004AFF RID: 19199
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int GetTokenFromTypeSpec(RuntimeModule pModule, byte[] signature, int length);

		// Token: 0x06004B00 RID: 19200 RVA: 0x0010E9FF File Offset: 0x0010CBFF
		[SecurityCritical]
		private int GetTokenFromTypeSpec(byte[] signature, int length)
		{
			return ModuleBuilder.GetTokenFromTypeSpec(this.GetNativeHandle(), signature, length);
		}

		// Token: 0x06004B01 RID: 19201
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int GetArrayMethodToken(RuntimeModule module, int tkTypeSpec, string methodName, byte[] signature, int sigLength);

		// Token: 0x06004B02 RID: 19202
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int GetStringConstant(RuntimeModule module, string str, int length);

		// Token: 0x06004B03 RID: 19203
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void PreSavePEFile(RuntimeModule module, int portableExecutableKind, int imageFileMachine);

		// Token: 0x06004B04 RID: 19204
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void SavePEFile(RuntimeModule module, string fileName, int entryPoint, int isExe, bool isManifestFile);

		// Token: 0x06004B05 RID: 19205
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddResource(RuntimeModule module, string strName, byte[] resBytes, int resByteCount, int tkFile, int attribute, int portableExecutableKind, int imageFileMachine);

		// Token: 0x06004B06 RID: 19206
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void SetModuleName(RuntimeModule module, string strModuleName);

		// Token: 0x06004B07 RID: 19207
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetFieldRVAContent(RuntimeModule module, int fdToken, byte[] data, int length);

		// Token: 0x06004B08 RID: 19208
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void DefineNativeResourceFile(RuntimeModule module, string strFilename, int portableExecutableKind, int ImageFileMachine);

		// Token: 0x06004B09 RID: 19209
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void DefineNativeResourceBytes(RuntimeModule module, byte[] pbResource, int cbResource, int portableExecutableKind, int imageFileMachine);

		// Token: 0x06004B0A RID: 19210 RVA: 0x0010EA10 File Offset: 0x0010CC10
		[SecurityCritical]
		internal void DefineNativeResource(PortableExecutableKinds portableExecutableKind, ImageFileMachine imageFileMachine)
		{
			string strResourceFileName = this.m_moduleData.m_strResourceFileName;
			byte[] resourceBytes = this.m_moduleData.m_resourceBytes;
			if (strResourceFileName != null)
			{
				ModuleBuilder.DefineNativeResourceFile(this.GetNativeHandle(), strResourceFileName, (int)portableExecutableKind, (int)imageFileMachine);
				return;
			}
			if (resourceBytes != null)
			{
				ModuleBuilder.DefineNativeResourceBytes(this.GetNativeHandle(), resourceBytes, resourceBytes.Length, (int)portableExecutableKind, (int)imageFileMachine);
			}
		}

		// Token: 0x06004B0B RID: 19211 RVA: 0x0010EA5C File Offset: 0x0010CC5C
		internal virtual Type FindTypeBuilderWithName(string strTypeName, bool ignoreCase)
		{
			if (ignoreCase)
			{
				using (Dictionary<string, Type>.KeyCollection.Enumerator enumerator = this.m_TypeBuilderDict.Keys.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						string text = enumerator.Current;
						if (string.Compare(text, strTypeName, StringComparison.OrdinalIgnoreCase) == 0)
						{
							return this.m_TypeBuilderDict[text];
						}
					}
					goto IL_62;
				}
			}
			Type result;
			if (this.m_TypeBuilderDict.TryGetValue(strTypeName, out result))
			{
				return result;
			}
			IL_62:
			return null;
		}

		// Token: 0x06004B0C RID: 19212 RVA: 0x0010EAE0 File Offset: 0x0010CCE0
		internal void SetEntryPoint(MethodToken entryPoint)
		{
			this.m_EntryPoint = entryPoint;
		}

		// Token: 0x06004B0D RID: 19213 RVA: 0x0010EAEC File Offset: 0x0010CCEC
		[SecurityCritical]
		internal void PreSave(string fileName, PortableExecutableKinds portableExecutableKind, ImageFileMachine imageFileMachine)
		{
			if (this.m_moduleData.m_isSaved)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Environment.GetResourceString("InvalidOperation_ModuleHasBeenSaved"), this.m_moduleData.m_strModuleName));
			}
			if (!this.m_moduleData.m_fGlobalBeenCreated && this.m_moduleData.m_fHasGlobal)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_GlobalFunctionNotBaked"));
			}
			foreach (Type type in this.m_TypeBuilderDict.Values)
			{
				TypeBuilder typeBuilder;
				if (type is TypeBuilder)
				{
					typeBuilder = (TypeBuilder)type;
				}
				else
				{
					EnumBuilder enumBuilder = (EnumBuilder)type;
					typeBuilder = enumBuilder.m_typeBuilder;
				}
				if (!typeBuilder.IsCreated())
				{
					throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, Environment.GetResourceString("NotSupported_NotAllTypesAreBaked"), typeBuilder.FullName));
				}
			}
			ModuleBuilder.PreSavePEFile(this.GetNativeHandle(), (int)portableExecutableKind, (int)imageFileMachine);
		}

		// Token: 0x06004B0E RID: 19214 RVA: 0x0010EBF0 File Offset: 0x0010CDF0
		[SecurityCritical]
		internal void Save(string fileName, bool isAssemblyFile, PortableExecutableKinds portableExecutableKind, ImageFileMachine imageFileMachine)
		{
			if (this.m_moduleData.m_embeddedRes != null)
			{
				for (ResWriterData resWriterData = this.m_moduleData.m_embeddedRes; resWriterData != null; resWriterData = resWriterData.m_nextResWriter)
				{
					if (resWriterData.m_resWriter != null)
					{
						resWriterData.m_resWriter.Generate();
					}
					byte[] array = new byte[resWriterData.m_memoryStream.Length];
					resWriterData.m_memoryStream.Flush();
					resWriterData.m_memoryStream.Position = 0L;
					resWriterData.m_memoryStream.Read(array, 0, array.Length);
					ModuleBuilder.AddResource(this.GetNativeHandle(), resWriterData.m_strName, array, array.Length, this.m_moduleData.FileToken, (int)resWriterData.m_attribute, (int)portableExecutableKind, (int)imageFileMachine);
				}
			}
			this.DefineNativeResource(portableExecutableKind, imageFileMachine);
			PEFileKinds isExe = isAssemblyFile ? this.ContainingAssemblyBuilder.m_assemblyData.m_peFileKind : PEFileKinds.Dll;
			ModuleBuilder.SavePEFile(this.GetNativeHandle(), fileName, this.m_EntryPoint.Token, (int)isExe, isAssemblyFile);
			this.m_moduleData.m_isSaved = true;
		}

		// Token: 0x06004B0F RID: 19215 RVA: 0x0010ECE4 File Offset: 0x0010CEE4
		[SecurityCritical]
		private int GetTypeRefNested(Type type, Module refedModule, string strRefedModuleFileName)
		{
			Type declaringType = type.DeclaringType;
			int tkResolution = 0;
			string text = type.FullName;
			if (declaringType != null)
			{
				tkResolution = this.GetTypeRefNested(declaringType, refedModule, strRefedModuleFileName);
				text = ModuleBuilder.UnmangleTypeName(text);
			}
			if (this.ContainingAssemblyBuilder.ProfileAPICheck)
			{
				RuntimeType runtimeType = type as RuntimeType;
				if (runtimeType != null && (runtimeType.InvocationFlags & INVOCATION_FLAGS.INVOCATION_FLAGS_NON_W8P_FX_API) != INVOCATION_FLAGS.INVOCATION_FLAGS_UNKNOWN)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_APIInvalidForCurrentContext", new object[]
					{
						runtimeType.FullName
					}));
				}
			}
			return ModuleBuilder.GetTypeRef(this.GetNativeHandle(), text, ModuleBuilder.GetRuntimeModuleFromModule(refedModule).GetNativeHandle(), strRefedModuleFileName, tkResolution);
		}

		// Token: 0x06004B10 RID: 19216 RVA: 0x0010ED7C File Offset: 0x0010CF7C
		[SecurityCritical]
		internal MethodToken InternalGetConstructorToken(ConstructorInfo con, bool usingRef)
		{
			if (con == null)
			{
				throw new ArgumentNullException("con");
			}
			ConstructorBuilder constructorBuilder;
			int str;
			ConstructorOnTypeBuilderInstantiation constructorOnTypeBuilderInstantiation;
			RuntimeConstructorInfo method;
			if ((constructorBuilder = (con as ConstructorBuilder)) != null)
			{
				if (!usingRef && constructorBuilder.Module.Equals(this))
				{
					return constructorBuilder.GetToken();
				}
				int token = this.GetTypeTokenInternal(con.ReflectedType).Token;
				str = this.GetMemberRef(con.ReflectedType.Module, token, constructorBuilder.GetToken().Token);
			}
			else if ((constructorOnTypeBuilderInstantiation = (con as ConstructorOnTypeBuilderInstantiation)) != null)
			{
				if (usingRef)
				{
					throw new InvalidOperationException();
				}
				int token = this.GetTypeTokenInternal(con.DeclaringType).Token;
				str = this.GetMemberRef(con.DeclaringType.Module, token, constructorOnTypeBuilderInstantiation.MetadataTokenInternal);
			}
			else if ((method = (con as RuntimeConstructorInfo)) != null && !con.ReflectedType.IsArray)
			{
				int token = this.GetTypeTokenInternal(con.ReflectedType).Token;
				str = this.GetMemberRefOfMethodInfo(token, method);
			}
			else
			{
				ParameterInfo[] parameters = con.GetParameters();
				if (parameters == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidConstructorInfo"));
				}
				int num = parameters.Length;
				Type[] array = new Type[num];
				Type[][] array2 = new Type[num][];
				Type[][] array3 = new Type[num][];
				for (int i = 0; i < num; i++)
				{
					if (parameters[i] == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_InvalidConstructorInfo"));
					}
					array[i] = parameters[i].ParameterType;
					array2[i] = parameters[i].GetRequiredCustomModifiers();
					array3[i] = parameters[i].GetOptionalCustomModifiers();
				}
				int token = this.GetTypeTokenInternal(con.ReflectedType).Token;
				SignatureHelper methodSigHelper = SignatureHelper.GetMethodSigHelper(this, con.CallingConvention, null, null, null, array, array2, array3);
				int length;
				byte[] signature = methodSigHelper.InternalGetSignature(out length);
				str = this.GetMemberRefFromSignature(token, con.Name, signature, length);
			}
			return new MethodToken(str);
		}

		// Token: 0x06004B11 RID: 19217 RVA: 0x0010EF7D File Offset: 0x0010D17D
		[SecurityCritical]
		internal void Init(string strModuleName, string strFileName, int tkFile)
		{
			this.m_moduleData = new ModuleBuilderData(this, strModuleName, strFileName, tkFile);
			this.m_TypeBuilderDict = new Dictionary<string, Type>();
		}

		// Token: 0x06004B12 RID: 19218 RVA: 0x0010EF99 File Offset: 0x0010D199
		[SecurityCritical]
		internal void ModifyModuleName(string name)
		{
			this.m_moduleData.ModifyModuleName(name);
			ModuleBuilder.SetModuleName(this.GetNativeHandle(), name);
		}

		// Token: 0x06004B13 RID: 19219 RVA: 0x0010EFB3 File Offset: 0x0010D1B3
		internal void SetSymWriter(ISymbolWriter writer)
		{
			this.m_iSymWriter = writer;
		}

		// Token: 0x17000BD9 RID: 3033
		// (get) Token: 0x06004B14 RID: 19220 RVA: 0x0010EFBC File Offset: 0x0010D1BC
		internal object SyncRoot
		{
			get
			{
				return this.ContainingAssemblyBuilder.SyncRoot;
			}
		}

		// Token: 0x17000BDA RID: 3034
		// (get) Token: 0x06004B15 RID: 19221 RVA: 0x0010EFC9 File Offset: 0x0010D1C9
		internal InternalModuleBuilder InternalModule
		{
			get
			{
				return this.m_internalModuleBuilder;
			}
		}

		// Token: 0x06004B16 RID: 19222 RVA: 0x0010EFD1 File Offset: 0x0010D1D1
		internal override ModuleHandle GetModuleHandle()
		{
			return new ModuleHandle(this.GetNativeHandle());
		}

		// Token: 0x06004B17 RID: 19223 RVA: 0x0010EFDE File Offset: 0x0010D1DE
		internal RuntimeModule GetNativeHandle()
		{
			return this.InternalModule.GetNativeHandle();
		}

		// Token: 0x06004B18 RID: 19224 RVA: 0x0010EFEC File Offset: 0x0010D1EC
		private static RuntimeModule GetRuntimeModuleFromModule(Module m)
		{
			ModuleBuilder moduleBuilder = m as ModuleBuilder;
			if (moduleBuilder != null)
			{
				return moduleBuilder.InternalModule;
			}
			return m as RuntimeModule;
		}

		// Token: 0x06004B19 RID: 19225 RVA: 0x0010F018 File Offset: 0x0010D218
		[SecurityCritical]
		private int GetMemberRefToken(MethodBase method, IEnumerable<Type> optionalParameterTypes)
		{
			int cGenericParameters = 0;
			if (method.IsGenericMethod)
			{
				if (!method.IsGenericMethodDefinition)
				{
					throw new InvalidOperationException();
				}
				cGenericParameters = method.GetGenericArguments().Length;
			}
			if (optionalParameterTypes != null && (method.CallingConvention & CallingConventions.VarArgs) == (CallingConventions)0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotAVarArgCallingConvention"));
			}
			MethodInfo methodInfo = method as MethodInfo;
			Type[] parameterTypes;
			Type methodBaseReturnType;
			if (method.DeclaringType.IsGenericType)
			{
				MethodOnTypeBuilderInstantiation methodOnTypeBuilderInstantiation;
				MethodBase methodBase;
				ConstructorOnTypeBuilderInstantiation constructorOnTypeBuilderInstantiation;
				if ((methodOnTypeBuilderInstantiation = (method as MethodOnTypeBuilderInstantiation)) != null)
				{
					methodBase = methodOnTypeBuilderInstantiation.m_method;
				}
				else if ((constructorOnTypeBuilderInstantiation = (method as ConstructorOnTypeBuilderInstantiation)) != null)
				{
					methodBase = constructorOnTypeBuilderInstantiation.m_ctor;
				}
				else if (method is MethodBuilder || method is ConstructorBuilder)
				{
					methodBase = method;
				}
				else if (method.IsGenericMethod)
				{
					methodBase = methodInfo.GetGenericMethodDefinition();
					methodBase = methodBase.Module.ResolveMethod(method.MetadataToken, (methodBase.DeclaringType != null) ? methodBase.DeclaringType.GetGenericArguments() : null, methodBase.GetGenericArguments());
				}
				else
				{
					methodBase = method.Module.ResolveMethod(method.MetadataToken, (method.DeclaringType != null) ? method.DeclaringType.GetGenericArguments() : null, null);
				}
				parameterTypes = methodBase.GetParameterTypes();
				methodBaseReturnType = MethodBuilder.GetMethodBaseReturnType(methodBase);
			}
			else
			{
				parameterTypes = method.GetParameterTypes();
				methodBaseReturnType = MethodBuilder.GetMethodBaseReturnType(method);
			}
			int length;
			byte[] signature = this.GetMemberRefSignature(method.CallingConvention, methodBaseReturnType, parameterTypes, optionalParameterTypes, cGenericParameters).InternalGetSignature(out length);
			int tr;
			if (method.DeclaringType.IsGenericType)
			{
				int length2;
				byte[] signature2 = SignatureHelper.GetTypeSigToken(this, method.DeclaringType).InternalGetSignature(out length2);
				tr = this.GetTokenFromTypeSpec(signature2, length2);
			}
			else if (!method.Module.Equals(this))
			{
				tr = this.GetTypeToken(method.DeclaringType).Token;
			}
			else if (methodInfo != null)
			{
				tr = this.GetMethodToken(methodInfo).Token;
			}
			else
			{
				tr = this.GetConstructorToken(method as ConstructorInfo).Token;
			}
			return this.GetMemberRefFromSignature(tr, method.Name, signature, length);
		}

		// Token: 0x06004B1A RID: 19226 RVA: 0x0010F220 File Offset: 0x0010D420
		[SecurityCritical]
		internal SignatureHelper GetMemberRefSignature(CallingConventions call, Type returnType, Type[] parameterTypes, IEnumerable<Type> optionalParameterTypes, int cGenericParameters)
		{
			int num = (parameterTypes == null) ? 0 : parameterTypes.Length;
			SignatureHelper methodSigHelper = SignatureHelper.GetMethodSigHelper(this, call, returnType, cGenericParameters);
			for (int i = 0; i < num; i++)
			{
				methodSigHelper.AddArgument(parameterTypes[i]);
			}
			if (optionalParameterTypes != null)
			{
				int num2 = 0;
				foreach (Type clsArgument in optionalParameterTypes)
				{
					if (num2 == 0)
					{
						methodSigHelper.AddSentinel();
					}
					methodSigHelper.AddArgument(clsArgument);
					num2++;
				}
			}
			return methodSigHelper;
		}

		/// <summary>Returns a value that indicates whether this instance is equal to the specified object.</summary>
		/// <param name="obj">An object to compare with this instance, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> equals the type and value of this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004B1B RID: 19227 RVA: 0x0010F2B0 File Offset: 0x0010D4B0
		public override bool Equals(object obj)
		{
			return this.InternalModule.Equals(obj);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x06004B1C RID: 19228 RVA: 0x0010F2BE File Offset: 0x0010D4BE
		public override int GetHashCode()
		{
			return this.InternalModule.GetHashCode();
		}

		/// <summary>Returns all the custom attributes that have been applied to the current <see cref="T:System.Reflection.Emit.ModuleBuilder" />.</summary>
		/// <param name="inherit">This argument is ignored for objects of this type.</param>
		/// <returns>An array that contains the custom attributes; the array is empty if there are no attributes.</returns>
		// Token: 0x06004B1D RID: 19229 RVA: 0x0010F2CB File Offset: 0x0010D4CB
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.InternalModule.GetCustomAttributes(inherit);
		}

		/// <summary>Returns all the custom attributes that have been applied to the current <see cref="T:System.Reflection.Emit.ModuleBuilder" />, and that derive from a specified attribute type.</summary>
		/// <param name="attributeType">The base type from which attributes derive.</param>
		/// <param name="inherit">This argument is ignored for objects of this type.</param>
		/// <returns>An array that contains the custom attributes that are derived, at any level, from <paramref name="attributeType" />; the array is empty if there are no such attributes.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not a <see cref="T:System.Type" /> object supplied by the runtime. For example, <paramref name="attributeType" /> is a <see cref="T:System.Reflection.Emit.TypeBuilder" /> object.</exception>
		// Token: 0x06004B1E RID: 19230 RVA: 0x0010F2D9 File Offset: 0x0010D4D9
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.InternalModule.GetCustomAttributes(attributeType, inherit);
		}

		/// <summary>Returns a value that indicates whether the specified attribute type has been applied to this module.</summary>
		/// <param name="attributeType">The type of custom attribute to test for.</param>
		/// <param name="inherit">This argument is ignored for objects of this type.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instances of <paramref name="attributeType" /> have been applied to this module; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not a <see cref="T:System.Type" /> object supplied by the runtime. For example, <paramref name="attributeType" /> is a <see cref="T:System.Reflection.Emit.TypeBuilder" /> object.</exception>
		// Token: 0x06004B1F RID: 19231 RVA: 0x0010F2E8 File Offset: 0x0010D4E8
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.InternalModule.IsDefined(attributeType, inherit);
		}

		/// <summary>Returns information about the attributes that have been applied to the current <see cref="T:System.Reflection.Emit.ModuleBuilder" />, expressed as <see cref="T:System.Reflection.CustomAttributeData" /> objects.</summary>
		/// <returns>A generic list of <see cref="T:System.Reflection.CustomAttributeData" /> objects representing data about the attributes that have been applied to the current module.</returns>
		// Token: 0x06004B20 RID: 19232 RVA: 0x0010F2F7 File Offset: 0x0010D4F7
		public override IList<CustomAttributeData> GetCustomAttributesData()
		{
			return this.InternalModule.GetCustomAttributesData();
		}

		/// <summary>Returns all the classes defined within this module.</summary>
		/// <returns>An array that contains the types defined within the module that is reflected by this instance.</returns>
		/// <exception cref="T:System.Reflection.ReflectionTypeLoadException">One or more classes in a module could not be loaded.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06004B21 RID: 19233 RVA: 0x0010F304 File Offset: 0x0010D504
		public override Type[] GetTypes()
		{
			object syncRoot = this.SyncRoot;
			Type[] typesNoLock;
			lock (syncRoot)
			{
				typesNoLock = this.GetTypesNoLock();
			}
			return typesNoLock;
		}

		// Token: 0x06004B22 RID: 19234 RVA: 0x0010F348 File Offset: 0x0010D548
		internal Type[] GetTypesNoLock()
		{
			int count = this.m_TypeBuilderDict.Count;
			Type[] array = new Type[this.m_TypeBuilderDict.Count];
			int num = 0;
			foreach (Type type in this.m_TypeBuilderDict.Values)
			{
				EnumBuilder enumBuilder = type as EnumBuilder;
				TypeBuilder typeBuilder;
				if (enumBuilder != null)
				{
					typeBuilder = enumBuilder.m_typeBuilder;
				}
				else
				{
					typeBuilder = (TypeBuilder)type;
				}
				if (typeBuilder.IsCreated())
				{
					array[num++] = typeBuilder.UnderlyingSystemType;
				}
				else
				{
					array[num++] = type;
				}
			}
			return array;
		}

		/// <summary>Gets the named type defined in the module.</summary>
		/// <param name="className">The name of the <see cref="T:System.Type" /> to get.</param>
		/// <returns>The requested type, if the type is defined in this module; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">Length of <paramref name="className" /> is zero or is greater than 1023.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="className" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.SecurityException">The requested <see cref="T:System.Type" /> is non-public and the caller does not have <see cref="T:System.Security.Permissions.ReflectionPermission" /> to reflect non-public objects outside the current assembly.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		/// <exception cref="T:System.TypeLoadException">An error is encountered while loading the <see cref="T:System.Type" />.</exception>
		// Token: 0x06004B23 RID: 19235 RVA: 0x0010F404 File Offset: 0x0010D604
		[ComVisible(true)]
		public override Type GetType(string className)
		{
			return this.GetType(className, false, false);
		}

		/// <summary>Gets the named type defined in the module, optionally ignoring the case of the type name.</summary>
		/// <param name="className">The name of the <see cref="T:System.Type" /> to get.</param>
		/// <param name="ignoreCase">If <see langword="true" />, the search is case-insensitive. If <see langword="false" />, the search is case-sensitive.</param>
		/// <returns>The requested type, if the type is defined in this module; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">Length of <paramref name="className" /> is zero or is greater than 1023.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="className" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.SecurityException">The requested <see cref="T:System.Type" /> is non-public and the caller does not have <see cref="T:System.Security.Permissions.ReflectionPermission" /> to reflect non-public objects outside the current assembly.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		// Token: 0x06004B24 RID: 19236 RVA: 0x0010F40F File Offset: 0x0010D60F
		[ComVisible(true)]
		public override Type GetType(string className, bool ignoreCase)
		{
			return this.GetType(className, false, ignoreCase);
		}

		/// <summary>Gets the named type defined in the module, optionally ignoring the case of the type name. Optionally throws an exception if the type is not found.</summary>
		/// <param name="className">The name of the <see cref="T:System.Type" /> to get.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw an exception if the type cannot be found; <see langword="false" /> to return <see langword="null" />.</param>
		/// <param name="ignoreCase">If <see langword="true" />, the search is case-insensitive. If <see langword="false" />, the search is case-sensitive.</param>
		/// <returns>The specified type, if the type is declared in this module; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">Length of <paramref name="className" /> is zero or is greater than 1023.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="className" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.SecurityException">The requested <see cref="T:System.Type" /> is non-public and the caller does not have <see cref="T:System.Security.Permissions.ReflectionPermission" /> to reflect non-public objects outside the current assembly.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and the specified type is not found.</exception>
		// Token: 0x06004B25 RID: 19237 RVA: 0x0010F41C File Offset: 0x0010D61C
		[ComVisible(true)]
		public override Type GetType(string className, bool throwOnError, bool ignoreCase)
		{
			object syncRoot = this.SyncRoot;
			Type typeNoLock;
			lock (syncRoot)
			{
				typeNoLock = this.GetTypeNoLock(className, throwOnError, ignoreCase);
			}
			return typeNoLock;
		}

		// Token: 0x06004B26 RID: 19238 RVA: 0x0010F464 File Offset: 0x0010D664
		private Type GetTypeNoLock(string className, bool throwOnError, bool ignoreCase)
		{
			Type type = this.InternalModule.GetType(className, throwOnError, ignoreCase);
			if (type != null)
			{
				return type;
			}
			string text = null;
			string text2 = null;
			int num;
			for (int i = 0; i <= className.Length; i = num + 1)
			{
				num = className.IndexOfAny(new char[]
				{
					'[',
					'*',
					'&'
				}, i);
				if (num == -1)
				{
					text = className;
					text2 = null;
					break;
				}
				int num2 = 0;
				int num3 = num - 1;
				while (num3 >= 0 && className[num3] == '\\')
				{
					num2++;
					num3--;
				}
				if (num2 % 2 != 1)
				{
					text = className.Substring(0, num);
					text2 = className.Substring(num);
					break;
				}
			}
			if (text == null)
			{
				text = className;
				text2 = null;
			}
			text = text.Replace("\\\\", "\\").Replace("\\[", "[").Replace("\\*", "*").Replace("\\&", "&");
			if (text2 != null)
			{
				type = this.InternalModule.GetType(text, false, ignoreCase);
			}
			if (type == null)
			{
				type = this.FindTypeBuilderWithName(text, ignoreCase);
				if (type == null && this.Assembly is AssemblyBuilder)
				{
					List<ModuleBuilder> moduleBuilderList = this.ContainingAssemblyBuilder.m_assemblyData.m_moduleBuilderList;
					int count = moduleBuilderList.Count;
					int num4 = 0;
					while (num4 < count && type == null)
					{
						ModuleBuilder moduleBuilder = moduleBuilderList[num4];
						type = moduleBuilder.FindTypeBuilderWithName(text, ignoreCase);
						num4++;
					}
				}
				if (type == null)
				{
					return null;
				}
			}
			if (text2 == null)
			{
				return type;
			}
			return this.GetType(text2, type);
		}

		/// <summary>Gets a <see langword="String" /> representing the fully qualified name and path to this module.</summary>
		/// <returns>The fully qualified module name.</returns>
		// Token: 0x17000BDB RID: 3035
		// (get) Token: 0x06004B27 RID: 19239 RVA: 0x0010F5F0 File Offset: 0x0010D7F0
		public override string FullyQualifiedName
		{
			[SecuritySafeCritical]
			get
			{
				string text = this.m_moduleData.m_strFileName;
				if (text == null)
				{
					return null;
				}
				if (this.ContainingAssemblyBuilder.m_assemblyData.m_strDir != null)
				{
					text = Path.Combine(this.ContainingAssemblyBuilder.m_assemblyData.m_strDir, text);
					text = Path.UnsafeGetFullPath(text);
				}
				if (this.ContainingAssemblyBuilder.m_assemblyData.m_strDir != null && text != null)
				{
					new FileIOPermission(FileIOPermissionAccess.PathDiscovery, text).Demand();
				}
				return text;
			}
		}

		/// <summary>Returns the signature blob identified by a metadata token.</summary>
		/// <param name="metadataToken">A metadata token that identifies a signature in the module.</param>
		/// <returns>An array of bytes representing the signature blob.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a valid <see langword="MemberRef" />, <see langword="MethodDef" />, <see langword="TypeSpec" />, signature, or <see langword="FieldDef" /> token in the scope of the current module.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x06004B28 RID: 19240 RVA: 0x0010F660 File Offset: 0x0010D860
		public override byte[] ResolveSignature(int metadataToken)
		{
			return this.InternalModule.ResolveSignature(metadataToken);
		}

		/// <summary>Returns the method or constructor identified by the specified metadata token, in the context defined by the specified generic type parameters.</summary>
		/// <param name="metadataToken">A metadata token that identifies a method or constructor in the module.</param>
		/// <param name="genericTypeArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="genericMethodArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodBase" /> object representing the method that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a method or constructor in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="MethodSpec" /> whose signature contains element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method), and the necessary generic type arguments were not supplied for either or both of <paramref name="genericTypeArguments" /> and <paramref name="genericMethodArguments" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x06004B29 RID: 19241 RVA: 0x0010F66E File Offset: 0x0010D86E
		public override MethodBase ResolveMethod(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			return this.InternalModule.ResolveMethod(metadataToken, genericTypeArguments, genericMethodArguments);
		}

		/// <summary>Returns the field identified by the specified metadata token, in the context defined by the specified generic type parameters.</summary>
		/// <param name="metadataToken">A metadata token that identifies a field in the module.</param>
		/// <param name="genericTypeArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="genericMethodArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.Reflection.FieldInfo" /> object representing the field that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a field in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> identifies a field whose parent <see langword="TypeSpec" /> has a signature containing element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method), and the necessary generic type arguments were not supplied for either or both of <paramref name="genericTypeArguments" /> and <paramref name="genericMethodArguments" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x06004B2A RID: 19242 RVA: 0x0010F67E File Offset: 0x0010D87E
		public override FieldInfo ResolveField(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			return this.InternalModule.ResolveField(metadataToken, genericTypeArguments, genericMethodArguments);
		}

		/// <summary>Returns the type identified by the specified metadata token, in the context defined by the specified generic type parameters.</summary>
		/// <param name="metadataToken">A metadata token that identifies a type in the module.</param>
		/// <param name="genericTypeArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="genericMethodArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.Type" /> object representing the type that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a type in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="TypeSpec" /> whose signature contains element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method), and the necessary generic type arguments were not supplied for either or both of <paramref name="genericTypeArguments" /> and <paramref name="genericMethodArguments" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x06004B2B RID: 19243 RVA: 0x0010F68E File Offset: 0x0010D88E
		public override Type ResolveType(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			return this.InternalModule.ResolveType(metadataToken, genericTypeArguments, genericMethodArguments);
		}

		/// <summary>Returns the type or member identified by the specified metadata token, in the context defined by the specified generic type parameters.</summary>
		/// <param name="metadataToken">A metadata token that identifies a type or member in the module.</param>
		/// <param name="genericTypeArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="genericMethodArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.Reflection.MemberInfo" /> object representing the type or member that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a type or member in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="MethodSpec" /> or <see langword="TypeSpec" /> whose signature contains element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method), and the necessary generic type arguments were not supplied for either or both of <paramref name="genericTypeArguments" /> and <paramref name="genericMethodArguments" />.  
		/// -or-  
		/// <paramref name="metadataToken" /> identifies a property or event.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x06004B2C RID: 19244 RVA: 0x0010F69E File Offset: 0x0010D89E
		public override MemberInfo ResolveMember(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			return this.InternalModule.ResolveMember(metadataToken, genericTypeArguments, genericMethodArguments);
		}

		/// <summary>Returns the string identified by the specified metadata token.</summary>
		/// <param name="metadataToken">A metadata token that identifies a string in the string heap of the module.</param>
		/// <returns>A <see cref="T:System.String" /> containing a string value from the metadata string heap.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a string in the scope of the current module.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x06004B2D RID: 19245 RVA: 0x0010F6AE File Offset: 0x0010D8AE
		public override string ResolveString(int metadataToken)
		{
			return this.InternalModule.ResolveString(metadataToken);
		}

		/// <summary>Gets a pair of values indicating the nature of the code in a module and the platform targeted by the module.</summary>
		/// <param name="peKind">When this method returns, a combination of the <see cref="T:System.Reflection.PortableExecutableKinds" /> values indicating the nature of the code in the module.</param>
		/// <param name="machine">When this method returns, one of the <see cref="T:System.Reflection.ImageFileMachine" /> values indicating the platform targeted by the module.</param>
		// Token: 0x06004B2E RID: 19246 RVA: 0x0010F6BC File Offset: 0x0010D8BC
		public override void GetPEKind(out PortableExecutableKinds peKind, out ImageFileMachine machine)
		{
			this.InternalModule.GetPEKind(out peKind, out machine);
		}

		/// <summary>Gets the metadata stream version.</summary>
		/// <returns>A 32-bit integer representing the metadata stream version. The high-order two bytes represent the major version number, and the low-order two bytes represent the minor version number.</returns>
		// Token: 0x17000BDC RID: 3036
		// (get) Token: 0x06004B2F RID: 19247 RVA: 0x0010F6CB File Offset: 0x0010D8CB
		public override int MDStreamVersion
		{
			get
			{
				return this.InternalModule.MDStreamVersion;
			}
		}

		/// <summary>Gets a universally unique identifier (UUID) that can be used to distinguish between two versions of a module.</summary>
		/// <returns>A <see cref="T:System.Guid" /> that can be used to distinguish between two versions of a module.</returns>
		// Token: 0x17000BDD RID: 3037
		// (get) Token: 0x06004B30 RID: 19248 RVA: 0x0010F6D8 File Offset: 0x0010D8D8
		public override Guid ModuleVersionId
		{
			get
			{
				return this.InternalModule.ModuleVersionId;
			}
		}

		/// <summary>Gets a token that identifies the current dynamic module in metadata.</summary>
		/// <returns>An integer token that identifies the current module in metadata.</returns>
		// Token: 0x17000BDE RID: 3038
		// (get) Token: 0x06004B31 RID: 19249 RVA: 0x0010F6E5 File Offset: 0x0010D8E5
		public override int MetadataToken
		{
			get
			{
				return this.InternalModule.MetadataToken;
			}
		}

		/// <summary>Gets a value indicating whether the object is a resource.</summary>
		/// <returns>
		///   <see langword="true" /> if the object is a resource; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004B32 RID: 19250 RVA: 0x0010F6F2 File Offset: 0x0010D8F2
		public override bool IsResource()
		{
			return this.InternalModule.IsResource();
		}

		/// <summary>Returns all fields defined in the .sdata region of the portable executable (PE) file that match the specified binding flags.</summary>
		/// <param name="bindingFlags">A combination of the <see langword="BindingFlags" /> bit flags used to control the search.</param>
		/// <returns>An array of fields that match the specified flags; the array is empty if no such fields exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06004B33 RID: 19251 RVA: 0x0010F6FF File Offset: 0x0010D8FF
		public override FieldInfo[] GetFields(BindingFlags bindingFlags)
		{
			return this.InternalModule.GetFields(bindingFlags);
		}

		/// <summary>Returns a module-level field, defined in the .sdata region of the portable executable (PE) file, that has the specified name and binding attributes.</summary>
		/// <param name="name">The field name.</param>
		/// <param name="bindingAttr">A combination of the <see langword="BindingFlags" /> bit flags used to control the search.</param>
		/// <returns>A field that has the specified name and binding attributes, or <see langword="null" /> if the field does not exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06004B34 RID: 19252 RVA: 0x0010F70D File Offset: 0x0010D90D
		public override FieldInfo GetField(string name, BindingFlags bindingAttr)
		{
			return this.InternalModule.GetField(name, bindingAttr);
		}

		/// <summary>Returns all the methods that have been defined at the module level for the current <see cref="T:System.Reflection.Emit.ModuleBuilder" />, and that match the specified binding flags.</summary>
		/// <param name="bindingFlags">A combination of <see langword="BindingFlags" /> bit flags used to control the search.</param>
		/// <returns>An array that contains all the module-level methods that match <paramref name="bindingFlags" />.</returns>
		// Token: 0x06004B35 RID: 19253 RVA: 0x0010F71C File Offset: 0x0010D91C
		public override MethodInfo[] GetMethods(BindingFlags bindingFlags)
		{
			return this.InternalModule.GetMethods(bindingFlags);
		}

		/// <summary>Returns the module-level method that matches the specified criteria.</summary>
		/// <param name="name">The method name.</param>
		/// <param name="bindingAttr">A combination of <see langword="BindingFlags" /> bit flags used to control the search.</param>
		/// <param name="binder">An object that implements <see langword="Binder" />, containing properties related to this method.</param>
		/// <param name="callConvention">The calling convention for the method.</param>
		/// <param name="types">The parameter types of the method.</param>
		/// <param name="modifiers">An array of parameter modifiers used to make binding work with parameter signatures in which the types have been modified.</param>
		/// <returns>A method that is defined at the module level, and matches the specified criteria; or <see langword="null" /> if such a method does not exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />, <paramref name="types" /> is <see langword="null" />, or an element of <paramref name="types" /> is <see langword="null" />.</exception>
		// Token: 0x06004B36 RID: 19254 RVA: 0x0010F72A File Offset: 0x0010D92A
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			return this.InternalModule.GetMethodInternal(name, bindingAttr, binder, callConvention, types, modifiers);
		}

		/// <summary>Gets a string that represents the name of the dynamic module.</summary>
		/// <returns>The name of the dynamic module.</returns>
		// Token: 0x17000BDF RID: 3039
		// (get) Token: 0x06004B37 RID: 19255 RVA: 0x0010F740 File Offset: 0x0010D940
		public override string ScopeName
		{
			get
			{
				return this.InternalModule.ScopeName;
			}
		}

		/// <summary>A string that indicates that this is an in-memory module.</summary>
		/// <returns>Text that indicates that this is an in-memory module.</returns>
		// Token: 0x17000BE0 RID: 3040
		// (get) Token: 0x06004B38 RID: 19256 RVA: 0x0010F74D File Offset: 0x0010D94D
		public override string Name
		{
			get
			{
				return this.InternalModule.Name;
			}
		}

		/// <summary>Gets the dynamic assembly that defined this instance of <see cref="T:System.Reflection.Emit.ModuleBuilder" />.</summary>
		/// <returns>The dynamic assembly that defined the current dynamic module.</returns>
		// Token: 0x17000BE1 RID: 3041
		// (get) Token: 0x06004B39 RID: 19257 RVA: 0x0010F75A File Offset: 0x0010D95A
		public override Assembly Assembly
		{
			get
			{
				return this.m_assemblyBuilder;
			}
		}

		/// <summary>Returns an <see cref="T:System.Security.Cryptography.X509Certificates.X509Certificate" /> object corresponding to the certificate included in the Authenticode signature of the assembly which this module belongs to. If the assembly has not been Authenticode signed, <see langword="null" /> is returned.</summary>
		/// <returns>A certificate, or <see langword="null" /> if the assembly to which this module belongs has not been Authenticode signed.</returns>
		// Token: 0x06004B3A RID: 19258 RVA: 0x0010F762 File Offset: 0x0010D962
		public override X509Certificate GetSignerCertificate()
		{
			return this.InternalModule.GetSignerCertificate();
		}

		/// <summary>Constructs a <see langword="TypeBuilder" /> for a private type with the specified name in this module.</summary>
		/// <param name="name">The full path of the type, including the namespace. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <returns>A private type with the specified name.</returns>
		/// <exception cref="T:System.ArgumentException">A type with the given name exists in the parent assembly of this module.  
		///  -or-  
		///  Nested type attributes are set on a type that is not nested.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004B3B RID: 19259 RVA: 0x0010F770 File Offset: 0x0010D970
		[SecuritySafeCritical]
		public TypeBuilder DefineType(string name)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineTypeNoLock(name, TypeAttributes.NotPublic, null, null, PackingSize.Unspecified, 0);
			}
			return result;
		}

		/// <summary>Constructs a <see langword="TypeBuilder" /> given the type name and the type attributes.</summary>
		/// <param name="name">The full path of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attributes of the defined type.</param>
		/// <returns>A <see langword="TypeBuilder" /> created with all of the requested attributes.</returns>
		/// <exception cref="T:System.ArgumentException">A type with the given name exists in the parent assembly of this module.  
		///  -or-  
		///  Nested type attributes are set on a type that is not nested.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004B3C RID: 19260 RVA: 0x0010F7B8 File Offset: 0x0010D9B8
		[SecuritySafeCritical]
		public TypeBuilder DefineType(string name, TypeAttributes attr)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineTypeNoLock(name, attr, null, null, PackingSize.Unspecified, 0);
			}
			return result;
		}

		/// <summary>Constructs a <see langword="TypeBuilder" /> given type name, its attributes, and the type that the defined type extends.</summary>
		/// <param name="name">The full path of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attribute to be associated with the type.</param>
		/// <param name="parent">The type that the defined type extends.</param>
		/// <returns>A <see langword="TypeBuilder" /> created with all of the requested attributes.</returns>
		/// <exception cref="T:System.ArgumentException">A type with the given name exists in the parent assembly of this module.  
		///  -or-  
		///  Nested type attributes are set on a type that is not nested.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004B3D RID: 19261 RVA: 0x0010F800 File Offset: 0x0010DA00
		[SecuritySafeCritical]
		public TypeBuilder DefineType(string name, TypeAttributes attr, Type parent)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				this.CheckContext(new Type[]
				{
					parent
				});
				result = this.DefineTypeNoLock(name, attr, parent, null, PackingSize.Unspecified, 0);
			}
			return result;
		}

		/// <summary>Constructs a <see langword="TypeBuilder" /> given the type name, the attributes, the type that the defined type extends, and the total size of the type.</summary>
		/// <param name="name">The full path of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attributes of the defined type.</param>
		/// <param name="parent">The type that the defined type extends.</param>
		/// <param name="typesize">The total size of the type.</param>
		/// <returns>A <see langword="TypeBuilder" /> object.</returns>
		/// <exception cref="T:System.ArgumentException">A type with the given name exists in the parent assembly of this module.  
		///  -or-  
		///  Nested type attributes are set on a type that is not nested.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004B3E RID: 19262 RVA: 0x0010F858 File Offset: 0x0010DA58
		[SecuritySafeCritical]
		public TypeBuilder DefineType(string name, TypeAttributes attr, Type parent, int typesize)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineTypeNoLock(name, attr, parent, null, PackingSize.Unspecified, typesize);
			}
			return result;
		}

		/// <summary>Constructs a <see langword="TypeBuilder" /> given the type name, attributes, the type that the defined type extends, the packing size of the defined type, and the total size of the defined type.</summary>
		/// <param name="name">The full path of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attributes of the defined type.</param>
		/// <param name="parent">The type that the defined type extends.</param>
		/// <param name="packingSize">The packing size of the type.</param>
		/// <param name="typesize">The total size of the type.</param>
		/// <returns>A <see langword="TypeBuilder" /> created with all of the requested attributes.</returns>
		/// <exception cref="T:System.ArgumentException">A type with the given name exists in the parent assembly of this module.  
		///  -or-  
		///  Nested type attributes are set on a type that is not nested.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004B3F RID: 19263 RVA: 0x0010F8A4 File Offset: 0x0010DAA4
		[SecuritySafeCritical]
		public TypeBuilder DefineType(string name, TypeAttributes attr, Type parent, PackingSize packingSize, int typesize)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineTypeNoLock(name, attr, parent, null, packingSize, typesize);
			}
			return result;
		}

		/// <summary>Constructs a <see langword="TypeBuilder" /> given the type name, attributes, the type that the defined type extends, and the interfaces that the defined type implements.</summary>
		/// <param name="name">The full path of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attributes to be associated with the type.</param>
		/// <param name="parent">The type that the defined type extends.</param>
		/// <param name="interfaces">The list of interfaces that the type implements.</param>
		/// <returns>A <see langword="TypeBuilder" /> created with all of the requested attributes.</returns>
		/// <exception cref="T:System.ArgumentException">A type with the given name exists in the parent assembly of this module.  
		///  -or-  
		///  Nested type attributes are set on a type that is not nested.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004B40 RID: 19264 RVA: 0x0010F8F0 File Offset: 0x0010DAF0
		[SecuritySafeCritical]
		[ComVisible(true)]
		public TypeBuilder DefineType(string name, TypeAttributes attr, Type parent, Type[] interfaces)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineTypeNoLock(name, attr, parent, interfaces, PackingSize.Unspecified, 0);
			}
			return result;
		}

		// Token: 0x06004B41 RID: 19265 RVA: 0x0010F93C File Offset: 0x0010DB3C
		[SecurityCritical]
		private TypeBuilder DefineTypeNoLock(string name, TypeAttributes attr, Type parent, Type[] interfaces, PackingSize packingSize, int typesize)
		{
			return new TypeBuilder(name, attr, parent, interfaces, this, packingSize, typesize, null);
		}

		/// <summary>Constructs a <see langword="TypeBuilder" /> given the type name, the attributes, the type that the defined type extends, and the packing size of the type.</summary>
		/// <param name="name">The full path of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attributes of the defined type.</param>
		/// <param name="parent">The type that the defined type extends.</param>
		/// <param name="packsize">The packing size of the type.</param>
		/// <returns>A <see langword="TypeBuilder" /> object.</returns>
		/// <exception cref="T:System.ArgumentException">A type with the given name exists in the parent assembly of this module.  
		///  -or-  
		///  Nested type attributes are set on a type that is not nested.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004B42 RID: 19266 RVA: 0x0010F950 File Offset: 0x0010DB50
		[SecuritySafeCritical]
		public TypeBuilder DefineType(string name, TypeAttributes attr, Type parent, PackingSize packsize)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineTypeNoLock(name, attr, parent, packsize);
			}
			return result;
		}

		// Token: 0x06004B43 RID: 19267 RVA: 0x0010F998 File Offset: 0x0010DB98
		[SecurityCritical]
		private TypeBuilder DefineTypeNoLock(string name, TypeAttributes attr, Type parent, PackingSize packsize)
		{
			return new TypeBuilder(name, attr, parent, null, this, packsize, 0, null);
		}

		/// <summary>Defines an enumeration type that is a value type with a single non-static field called <paramref name="value__" /> of the specified type.</summary>
		/// <param name="name">The full path of the enumeration type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="visibility">The type attributes for the enumeration. The attributes are any bits defined by <see cref="F:System.Reflection.TypeAttributes.VisibilityMask" />.</param>
		/// <param name="underlyingType">The underlying type for the enumeration. This must be a built-in integer type.</param>
		/// <returns>The defined enumeration.</returns>
		/// <exception cref="T:System.ArgumentException">Attributes other than visibility attributes are provided.  
		///  -or-  
		///  An enumeration with the given name exists in the parent assembly of this module.  
		///  -or-  
		///  The visibility attributes do not match the scope of the enumeration. For example, <see cref="F:System.Reflection.TypeAttributes.NestedPublic" /> is specified for <paramref name="visibility" />, but the enumeration is not a nested type.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004B44 RID: 19268 RVA: 0x0010F9A8 File Offset: 0x0010DBA8
		[SecuritySafeCritical]
		public EnumBuilder DefineEnum(string name, TypeAttributes visibility, Type underlyingType)
		{
			this.CheckContext(new Type[]
			{
				underlyingType
			});
			object syncRoot = this.SyncRoot;
			EnumBuilder result;
			lock (syncRoot)
			{
				EnumBuilder enumBuilder = this.DefineEnumNoLock(name, visibility, underlyingType);
				this.m_TypeBuilderDict[name] = enumBuilder;
				result = enumBuilder;
			}
			return result;
		}

		// Token: 0x06004B45 RID: 19269 RVA: 0x0010FA0C File Offset: 0x0010DC0C
		[SecurityCritical]
		private EnumBuilder DefineEnumNoLock(string name, TypeAttributes visibility, Type underlyingType)
		{
			return new EnumBuilder(name, underlyingType, visibility, this);
		}

		/// <summary>Defines the named managed embedded resource to be stored in this module.</summary>
		/// <param name="name">The name of the resource. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="description">The description of the resource.</param>
		/// <returns>A resource writer for the defined resource.</returns>
		/// <exception cref="T:System.ArgumentException">Length of <paramref name="name" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is null.</exception>
		/// <exception cref="T:System.InvalidOperationException">This module is transient.  
		///  -or-  
		///  The containing assembly is not persistable.</exception>
		// Token: 0x06004B46 RID: 19270 RVA: 0x0010FA17 File Offset: 0x0010DC17
		public IResourceWriter DefineResource(string name, string description)
		{
			return this.DefineResource(name, description, ResourceAttributes.Public);
		}

		/// <summary>Defines the named managed embedded resource with the given attributes that is to be stored in this module.</summary>
		/// <param name="name">The name of the resource. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="description">The description of the resource.</param>
		/// <param name="attribute">The resource attributes.</param>
		/// <returns>A resource writer for the defined resource.</returns>
		/// <exception cref="T:System.ArgumentException">Length of <paramref name="name" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is null.</exception>
		/// <exception cref="T:System.InvalidOperationException">This module is transient.  
		///  -or-  
		///  The containing assembly is not persistable.</exception>
		// Token: 0x06004B47 RID: 19271 RVA: 0x0010FA24 File Offset: 0x0010DC24
		public IResourceWriter DefineResource(string name, string description, ResourceAttributes attribute)
		{
			object syncRoot = this.SyncRoot;
			IResourceWriter result;
			lock (syncRoot)
			{
				result = this.DefineResourceNoLock(name, description, attribute);
			}
			return result;
		}

		// Token: 0x06004B48 RID: 19272 RVA: 0x0010FA6C File Offset: 0x0010DC6C
		private IResourceWriter DefineResourceNoLock(string name, string description, ResourceAttributes attribute)
		{
			if (this.IsTransient())
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadResourceContainer"));
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (this.m_assemblyBuilder.IsPersistable())
			{
				this.m_assemblyBuilder.m_assemblyData.CheckResNameConflict(name);
				MemoryStream memoryStream = new MemoryStream();
				ResourceWriter resourceWriter = new ResourceWriter(memoryStream);
				ResWriterData resWriterData = new ResWriterData(resourceWriter, memoryStream, name, string.Empty, string.Empty, attribute);
				resWriterData.m_nextResWriter = this.m_moduleData.m_embeddedRes;
				this.m_moduleData.m_embeddedRes = resWriterData;
				return resourceWriter;
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadResourceContainer"));
		}

		/// <summary>Defines a binary large object (BLOB) that represents a manifest resource to be embedded in the dynamic assembly.</summary>
		/// <param name="name">The case-sensitive name for the resource.</param>
		/// <param name="stream">A stream that contains the bytes for the resource.</param>
		/// <param name="attribute">An enumeration value that specifies whether the resource is public or private.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="stream" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is a zero-length string.</exception>
		/// <exception cref="T:System.InvalidOperationException">The dynamic assembly that contains the current module is transient; that is, no file name was specified when <see cref="M:System.Reflection.Emit.AssemblyBuilder.DefineDynamicModule(System.String,System.String)" /> was called.</exception>
		// Token: 0x06004B49 RID: 19273 RVA: 0x0010FB2C File Offset: 0x0010DD2C
		public void DefineManifestResource(string name, Stream stream, ResourceAttributes attribute)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.DefineManifestResourceNoLock(name, stream, attribute);
			}
		}

		// Token: 0x06004B4A RID: 19274 RVA: 0x0010FB8C File Offset: 0x0010DD8C
		private void DefineManifestResourceNoLock(string name, Stream stream, ResourceAttributes attribute)
		{
			if (this.IsTransient())
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadResourceContainer"));
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (this.m_assemblyBuilder.IsPersistable())
			{
				this.m_assemblyBuilder.m_assemblyData.CheckResNameConflict(name);
				ResWriterData resWriterData = new ResWriterData(null, stream, name, string.Empty, string.Empty, attribute);
				resWriterData.m_nextResWriter = this.m_moduleData.m_embeddedRes;
				this.m_moduleData.m_embeddedRes = resWriterData;
				return;
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadResourceContainer"));
		}

		/// <summary>Defines an unmanaged embedded resource given an opaque binary large object (BLOB) of bytes.</summary>
		/// <param name="resource">An opaque BLOB that represents an unmanaged resource</param>
		/// <exception cref="T:System.ArgumentException">An unmanaged resource has already been defined in the module's assembly.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="resource" /> is <see langword="null" />.</exception>
		// Token: 0x06004B4B RID: 19275 RVA: 0x0010FC3C File Offset: 0x0010DE3C
		public void DefineUnmanagedResource(byte[] resource)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.DefineUnmanagedResourceInternalNoLock(resource);
			}
		}

		// Token: 0x06004B4C RID: 19276 RVA: 0x0010FC80 File Offset: 0x0010DE80
		internal void DefineUnmanagedResourceInternalNoLock(byte[] resource)
		{
			if (resource == null)
			{
				throw new ArgumentNullException("resource");
			}
			if (this.m_moduleData.m_strResourceFileName != null || this.m_moduleData.m_resourceBytes != null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NativeResourceAlreadyDefined"));
			}
			this.m_moduleData.m_resourceBytes = new byte[resource.Length];
			Array.Copy(resource, this.m_moduleData.m_resourceBytes, resource.Length);
		}

		/// <summary>Defines an unmanaged resource given the name of Win32 resource file.</summary>
		/// <param name="resourceFileName">The name of the unmanaged resource file.</param>
		/// <exception cref="T:System.ArgumentException">An unmanaged resource has already been defined in the module's assembly.  
		///  -or-  
		///  <paramref name="resourceFileName" /> is the empty string ("").</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="resourceFileName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="resourceFileName" /> is not found.  
		/// -or-  
		/// <paramref name="resourceFileName" /> is a directory.</exception>
		// Token: 0x06004B4D RID: 19277 RVA: 0x0010FCEC File Offset: 0x0010DEEC
		[SecuritySafeCritical]
		public void DefineUnmanagedResource(string resourceFileName)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.DefineUnmanagedResourceFileInternalNoLock(resourceFileName);
			}
		}

		// Token: 0x06004B4E RID: 19278 RVA: 0x0010FD30 File Offset: 0x0010DF30
		[SecurityCritical]
		internal void DefineUnmanagedResourceFileInternalNoLock(string resourceFileName)
		{
			if (resourceFileName == null)
			{
				throw new ArgumentNullException("resourceFileName");
			}
			if (this.m_moduleData.m_resourceBytes != null || this.m_moduleData.m_strResourceFileName != null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NativeResourceAlreadyDefined"));
			}
			string text = Path.UnsafeGetFullPath(resourceFileName);
			new FileIOPermission(FileIOPermissionAccess.Read, text).Demand();
			new EnvironmentPermission(PermissionState.Unrestricted).Assert();
			try
			{
				if (!File.UnsafeExists(resourceFileName))
				{
					throw new FileNotFoundException(Environment.GetResourceString("IO.FileNotFound_FileName", new object[]
					{
						resourceFileName
					}), resourceFileName);
				}
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
			this.m_moduleData.m_strResourceFileName = text;
		}

		/// <summary>Defines a global method with the specified name, attributes, return type, and parameter types.</summary>
		/// <param name="name">The name of the method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the method. <paramref name="attributes" /> must include <see cref="F:System.Reflection.MethodAttributes.Static" />.</param>
		/// <param name="returnType">The return type of the method.</param>
		/// <param name="parameterTypes">The types of the method's parameters.</param>
		/// <returns>The defined global method.</returns>
		/// <exception cref="T:System.ArgumentException">The method is not static. That is, <paramref name="attributes" /> does not include <see cref="F:System.Reflection.MethodAttributes.Static" />.  
		///  -or-  
		///  The length of <paramref name="name" /> is zero  
		///  -or-  
		///  An element in the <see cref="T:System.Type" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.ModuleBuilder.CreateGlobalFunctions" /> has been previously called.</exception>
		// Token: 0x06004B4F RID: 19279 RVA: 0x0010FDDC File Offset: 0x0010DFDC
		public MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, Type returnType, Type[] parameterTypes)
		{
			return this.DefineGlobalMethod(name, attributes, CallingConventions.Standard, returnType, parameterTypes);
		}

		/// <summary>Defines a global method with the specified name, attributes, calling convention, return type, and parameter types.</summary>
		/// <param name="name">The name of the method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the method. <paramref name="attributes" /> must include <see cref="F:System.Reflection.MethodAttributes.Static" />.</param>
		/// <param name="callingConvention">The calling convention for the method.</param>
		/// <param name="returnType">The return type of the method.</param>
		/// <param name="parameterTypes">The types of the method's parameters.</param>
		/// <returns>The defined global method.</returns>
		/// <exception cref="T:System.ArgumentException">The method is not static. That is, <paramref name="attributes" /> does not include <see cref="F:System.Reflection.MethodAttributes.Static" />.  
		///  -or-  
		///  An element in the <see cref="T:System.Type" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.ModuleBuilder.CreateGlobalFunctions" /> has been previously called.</exception>
		// Token: 0x06004B50 RID: 19280 RVA: 0x0010FDEC File Offset: 0x0010DFEC
		public MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
		{
			return this.DefineGlobalMethod(name, attributes, callingConvention, returnType, null, null, parameterTypes, null, null);
		}

		/// <summary>Defines a global method with the specified name, attributes, calling convention, return type, custom modifiers for the return type, parameter types, and custom modifiers for the parameter types.</summary>
		/// <param name="name">The name of the method. <paramref name="name" /> cannot contain embedded null characters.</param>
		/// <param name="attributes">The attributes of the method. <paramref name="attributes" /> must include <see cref="F:System.Reflection.MethodAttributes.Static" />.</param>
		/// <param name="callingConvention">The calling convention for the method.</param>
		/// <param name="returnType">The return type of the method.</param>
		/// <param name="requiredReturnTypeCustomModifiers">An array of types representing the required custom modifiers for the return type, such as <see cref="T:System.Runtime.CompilerServices.IsConst" /> or <see cref="T:System.Runtime.CompilerServices.IsBoxed" />. If the return type has no required custom modifiers, specify <see langword="null" />.</param>
		/// <param name="optionalReturnTypeCustomModifiers">An array of types representing the optional custom modifiers for the return type, such as <see cref="T:System.Runtime.CompilerServices.IsConst" /> or <see cref="T:System.Runtime.CompilerServices.IsBoxed" />. If the return type has no optional custom modifiers, specify <see langword="null" />.</param>
		/// <param name="parameterTypes">The types of the method's parameters.</param>
		/// <param name="requiredParameterTypeCustomModifiers">An array of arrays of types. Each array of types represents the required custom modifiers for the corresponding parameter of the global method. If a particular argument has no required custom modifiers, specify <see langword="null" /> instead of an array of types. If the global method has no arguments, or if none of the arguments have required custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <param name="optionalParameterTypeCustomModifiers">An array of arrays of types. Each array of types represents the optional custom modifiers for the corresponding parameter. If a particular argument has no optional custom modifiers, specify <see langword="null" /> instead of an array of types. If the global method has no arguments, or if none of the arguments have optional custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <returns>The defined global method.</returns>
		/// <exception cref="T:System.ArgumentException">The method is not static. That is, <paramref name="attributes" /> does not include <see cref="F:System.Reflection.MethodAttributes.Static" />.  
		///  -or-  
		///  An element in the <see cref="T:System.Type" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="M:System.Reflection.Emit.ModuleBuilder.CreateGlobalFunctions" /> method has been previously called.</exception>
		// Token: 0x06004B51 RID: 19281 RVA: 0x0010FE0C File Offset: 0x0010E00C
		public MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] requiredReturnTypeCustomModifiers, Type[] optionalReturnTypeCustomModifiers, Type[] parameterTypes, Type[][] requiredParameterTypeCustomModifiers, Type[][] optionalParameterTypeCustomModifiers)
		{
			object syncRoot = this.SyncRoot;
			MethodBuilder result;
			lock (syncRoot)
			{
				result = this.DefineGlobalMethodNoLock(name, attributes, callingConvention, returnType, requiredReturnTypeCustomModifiers, optionalReturnTypeCustomModifiers, parameterTypes, requiredParameterTypeCustomModifiers, optionalParameterTypeCustomModifiers);
			}
			return result;
		}

		// Token: 0x06004B52 RID: 19282 RVA: 0x0010FE60 File Offset: 0x0010E060
		private MethodBuilder DefineGlobalMethodNoLock(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] requiredReturnTypeCustomModifiers, Type[] optionalReturnTypeCustomModifiers, Type[] parameterTypes, Type[][] requiredParameterTypeCustomModifiers, Type[][] optionalParameterTypeCustomModifiers)
		{
			if (this.m_moduleData.m_fGlobalBeenCreated)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_GlobalsHaveBeenCreated"));
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if ((attributes & MethodAttributes.Static) == MethodAttributes.PrivateScope)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_GlobalFunctionHasToBeStatic"));
			}
			this.CheckContext(new Type[]
			{
				returnType
			});
			this.CheckContext(new Type[][]
			{
				requiredReturnTypeCustomModifiers,
				optionalReturnTypeCustomModifiers,
				parameterTypes
			});
			this.CheckContext(requiredParameterTypeCustomModifiers);
			this.CheckContext(optionalParameterTypeCustomModifiers);
			this.m_moduleData.m_fHasGlobal = true;
			return this.m_moduleData.m_globalTypeBuilder.DefineMethod(name, attributes, callingConvention, returnType, requiredReturnTypeCustomModifiers, optionalReturnTypeCustomModifiers, parameterTypes, requiredParameterTypeCustomModifiers, optionalParameterTypeCustomModifiers);
		}

		/// <summary>Defines a <see langword="PInvoke" /> method with the specified name, the name of the DLL in which the method is defined, the attributes of the method, the calling convention of the method, the return type of the method, the types of the parameters of the method, and the <see langword="PInvoke" /> flags.</summary>
		/// <param name="name">The name of the <see langword="PInvoke" /> method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="dllName">The name of the DLL in which the <see langword="PInvoke" /> method is defined.</param>
		/// <param name="attributes">The attributes of the method.</param>
		/// <param name="callingConvention">The method's calling convention.</param>
		/// <param name="returnType">The method's return type.</param>
		/// <param name="parameterTypes">The types of the method's parameters.</param>
		/// <param name="nativeCallConv">The native calling convention.</param>
		/// <param name="nativeCharSet">The method's native character set.</param>
		/// <returns>The defined <see langword="PInvoke" /> method.</returns>
		/// <exception cref="T:System.ArgumentException">The method is not static or if the containing type is an interface.  
		///  -or-  
		///  The method is abstract.  
		///  -or-  
		///  The method was previously defined.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> or <paramref name="dllName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /></exception>
		// Token: 0x06004B53 RID: 19283 RVA: 0x0010FF34 File Offset: 0x0010E134
		public MethodBuilder DefinePInvokeMethod(string name, string dllName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			return this.DefinePInvokeMethod(name, dllName, name, attributes, callingConvention, returnType, parameterTypes, nativeCallConv, nativeCharSet);
		}

		/// <summary>Defines a <see langword="PInvoke" /> method with the specified name, the name of the DLL in which the method is defined, the attributes of the method, the calling convention of the method, the return type of the method, the types of the parameters of the method, and the <see langword="PInvoke" /> flags.</summary>
		/// <param name="name">The name of the <see langword="PInvoke" /> method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="dllName">The name of the DLL in which the <see langword="PInvoke" /> method is defined.</param>
		/// <param name="entryName">The name of the entry point in the DLL.</param>
		/// <param name="attributes">The attributes of the method.</param>
		/// <param name="callingConvention">The method's calling convention.</param>
		/// <param name="returnType">The method's return type.</param>
		/// <param name="parameterTypes">The types of the method's parameters.</param>
		/// <param name="nativeCallConv">The native calling convention.</param>
		/// <param name="nativeCharSet">The method's native character set.</param>
		/// <returns>The defined <see langword="PInvoke" /> method.</returns>
		/// <exception cref="T:System.ArgumentException">The method is not static or if the containing type is an interface or if the method is abstract of if the method was previously defined.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> or <paramref name="dllName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /></exception>
		// Token: 0x06004B54 RID: 19284 RVA: 0x0010FF58 File Offset: 0x0010E158
		public MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			object syncRoot = this.SyncRoot;
			MethodBuilder result;
			lock (syncRoot)
			{
				result = this.DefinePInvokeMethodNoLock(name, dllName, entryName, attributes, callingConvention, returnType, parameterTypes, nativeCallConv, nativeCharSet);
			}
			return result;
		}

		// Token: 0x06004B55 RID: 19285 RVA: 0x0010FFAC File Offset: 0x0010E1AC
		private MethodBuilder DefinePInvokeMethodNoLock(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			if ((attributes & MethodAttributes.Static) == MethodAttributes.PrivateScope)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_GlobalFunctionHasToBeStatic"));
			}
			this.CheckContext(new Type[]
			{
				returnType
			});
			this.CheckContext(parameterTypes);
			this.m_moduleData.m_fHasGlobal = true;
			return this.m_moduleData.m_globalTypeBuilder.DefinePInvokeMethod(name, dllName, entryName, attributes, callingConvention, returnType, parameterTypes, nativeCallConv, nativeCharSet);
		}

		/// <summary>Completes the global function definitions and global data definitions for this dynamic module.</summary>
		/// <exception cref="T:System.InvalidOperationException">This method was called previously.</exception>
		// Token: 0x06004B56 RID: 19286 RVA: 0x00110014 File Offset: 0x0010E214
		public void CreateGlobalFunctions()
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.CreateGlobalFunctionsNoLock();
			}
		}

		// Token: 0x06004B57 RID: 19287 RVA: 0x00110054 File Offset: 0x0010E254
		private void CreateGlobalFunctionsNoLock()
		{
			if (this.m_moduleData.m_fGlobalBeenCreated)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotADebugModule"));
			}
			this.m_moduleData.m_globalTypeBuilder.CreateType();
			this.m_moduleData.m_fGlobalBeenCreated = true;
		}

		/// <summary>Defines an initialized data field in the .sdata section of the portable executable (PE) file.</summary>
		/// <param name="name">The name used to refer to the data. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="data">The binary large object (BLOB) of data.</param>
		/// <param name="attributes">The attributes for the field. The default is <see langword="Static" />.</param>
		/// <returns>A field to reference the data.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.  
		///  -or-  
		///  The size of <paramref name="data" /> is less than or equal to zero or greater than or equal to 0x3f0000.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> or <paramref name="data" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.ModuleBuilder.CreateGlobalFunctions" /> has been previously called.</exception>
		// Token: 0x06004B58 RID: 19288 RVA: 0x00110090 File Offset: 0x0010E290
		public FieldBuilder DefineInitializedData(string name, byte[] data, FieldAttributes attributes)
		{
			object syncRoot = this.SyncRoot;
			FieldBuilder result;
			lock (syncRoot)
			{
				result = this.DefineInitializedDataNoLock(name, data, attributes);
			}
			return result;
		}

		// Token: 0x06004B59 RID: 19289 RVA: 0x001100D8 File Offset: 0x0010E2D8
		private FieldBuilder DefineInitializedDataNoLock(string name, byte[] data, FieldAttributes attributes)
		{
			if (this.m_moduleData.m_fGlobalBeenCreated)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_GlobalsHaveBeenCreated"));
			}
			this.m_moduleData.m_fHasGlobal = true;
			return this.m_moduleData.m_globalTypeBuilder.DefineInitializedData(name, data, attributes);
		}

		/// <summary>Defines an uninitialized data field in the .sdata section of the portable executable (PE) file.</summary>
		/// <param name="name">The name used to refer to the data. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="size">The size of the data field.</param>
		/// <param name="attributes">The attributes for the field.</param>
		/// <returns>A field to reference the data.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.  
		///  -or-  
		///  <paramref name="size" /> is less than or equal to zero, or greater than or equal to 0x003f0000.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.ModuleBuilder.CreateGlobalFunctions" /> has been previously called.</exception>
		// Token: 0x06004B5A RID: 19290 RVA: 0x00110118 File Offset: 0x0010E318
		public FieldBuilder DefineUninitializedData(string name, int size, FieldAttributes attributes)
		{
			object syncRoot = this.SyncRoot;
			FieldBuilder result;
			lock (syncRoot)
			{
				result = this.DefineUninitializedDataNoLock(name, size, attributes);
			}
			return result;
		}

		// Token: 0x06004B5B RID: 19291 RVA: 0x00110160 File Offset: 0x0010E360
		private FieldBuilder DefineUninitializedDataNoLock(string name, int size, FieldAttributes attributes)
		{
			if (this.m_moduleData.m_fGlobalBeenCreated)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_GlobalsHaveBeenCreated"));
			}
			this.m_moduleData.m_fHasGlobal = true;
			return this.m_moduleData.m_globalTypeBuilder.DefineUninitializedData(name, size, attributes);
		}

		// Token: 0x06004B5C RID: 19292 RVA: 0x0011019E File Offset: 0x0010E39E
		[SecurityCritical]
		internal TypeToken GetTypeTokenInternal(Type type)
		{
			return this.GetTypeTokenInternal(type, false);
		}

		// Token: 0x06004B5D RID: 19293 RVA: 0x001101A8 File Offset: 0x0010E3A8
		[SecurityCritical]
		private TypeToken GetTypeTokenInternal(Type type, bool getGenericDefinition)
		{
			object syncRoot = this.SyncRoot;
			TypeToken typeTokenWorkerNoLock;
			lock (syncRoot)
			{
				typeTokenWorkerNoLock = this.GetTypeTokenWorkerNoLock(type, getGenericDefinition);
			}
			return typeTokenWorkerNoLock;
		}

		/// <summary>Returns the token used to identify the specified type within this module.</summary>
		/// <param name="type">The type object that represents the class type.</param>
		/// <returns>The token used to identify the given type within this module.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="type" /> is a <see langword="ByRef" /> type.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="type" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">This is a non-transient module that references a transient module.</exception>
		// Token: 0x06004B5E RID: 19294 RVA: 0x001101EC File Offset: 0x0010E3EC
		[SecuritySafeCritical]
		public TypeToken GetTypeToken(Type type)
		{
			return this.GetTypeTokenInternal(type, true);
		}

		// Token: 0x06004B5F RID: 19295 RVA: 0x001101F8 File Offset: 0x0010E3F8
		[SecurityCritical]
		private TypeToken GetTypeTokenWorkerNoLock(Type type, bool getGenericDefinition)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.CheckContext(new Type[]
			{
				type
			});
			if (type.IsByRef)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_CannotGetTypeTokenForByRef"));
			}
			if ((type.IsGenericType && (!type.IsGenericTypeDefinition || !getGenericDefinition)) || type.IsGenericParameter || type.IsArray || type.IsPointer)
			{
				int length;
				byte[] signature = SignatureHelper.GetTypeSigToken(this, type).InternalGetSignature(out length);
				return new TypeToken(this.GetTokenFromTypeSpec(signature, length));
			}
			Module module = type.Module;
			if (module.Equals(this))
			{
				EnumBuilder enumBuilder = type as EnumBuilder;
				TypeBuilder typeBuilder;
				if (enumBuilder != null)
				{
					typeBuilder = enumBuilder.m_typeBuilder;
				}
				else
				{
					typeBuilder = (type as TypeBuilder);
				}
				if (typeBuilder != null)
				{
					return typeBuilder.TypeToken;
				}
				GenericTypeParameterBuilder genericTypeParameterBuilder;
				if ((genericTypeParameterBuilder = (type as GenericTypeParameterBuilder)) != null)
				{
					return new TypeToken(genericTypeParameterBuilder.MetadataTokenInternal);
				}
				return new TypeToken(this.GetTypeRefNested(type, this, string.Empty));
			}
			else
			{
				ModuleBuilder moduleBuilder = module as ModuleBuilder;
				bool flag = (moduleBuilder != null) ? moduleBuilder.IsTransient() : ((RuntimeModule)module).IsTransientInternal();
				if (!this.IsTransient() && flag)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadTransientModuleReference"));
				}
				string strRefedModuleFileName = string.Empty;
				if (module.Assembly.Equals(this.Assembly))
				{
					if (moduleBuilder == null)
					{
						moduleBuilder = this.ContainingAssemblyBuilder.GetModuleBuilder((InternalModuleBuilder)module);
					}
					strRefedModuleFileName = moduleBuilder.m_moduleData.m_strFileName;
				}
				return new TypeToken(this.GetTypeRefNested(type, module, strRefedModuleFileName));
			}
		}

		/// <summary>Returns the token used to identify the type with the specified name.</summary>
		/// <param name="name">The name of the class, including the namespace.</param>
		/// <returns>The token used to identify the type with the specified name within this module.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is the empty string ("").  
		/// -or-  
		/// <paramref name="name" /> represents a <see langword="ByRef" /> type.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// The type specified by <paramref name="name" /> could not be found.</exception>
		/// <exception cref="T:System.InvalidOperationException">This is a non-transient module that references a transient module.</exception>
		// Token: 0x06004B60 RID: 19296 RVA: 0x00110399 File Offset: 0x0010E599
		public TypeToken GetTypeToken(string name)
		{
			return this.GetTypeToken(this.InternalModule.GetType(name, false, true));
		}

		/// <summary>Returns the token used to identify the specified method within this module.</summary>
		/// <param name="method">The method to get a token for.</param>
		/// <returns>The token used to identify the specified method within this module.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="method" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The declaring type for the method is not in this module.</exception>
		// Token: 0x06004B61 RID: 19297 RVA: 0x001103B0 File Offset: 0x0010E5B0
		[SecuritySafeCritical]
		public MethodToken GetMethodToken(MethodInfo method)
		{
			object syncRoot = this.SyncRoot;
			MethodToken methodTokenNoLock;
			lock (syncRoot)
			{
				methodTokenNoLock = this.GetMethodTokenNoLock(method, true);
			}
			return methodTokenNoLock;
		}

		// Token: 0x06004B62 RID: 19298 RVA: 0x001103F4 File Offset: 0x0010E5F4
		[SecurityCritical]
		internal MethodToken GetMethodTokenInternal(MethodInfo method)
		{
			object syncRoot = this.SyncRoot;
			MethodToken methodTokenNoLock;
			lock (syncRoot)
			{
				methodTokenNoLock = this.GetMethodTokenNoLock(method, false);
			}
			return methodTokenNoLock;
		}

		// Token: 0x06004B63 RID: 19299 RVA: 0x00110438 File Offset: 0x0010E638
		[SecurityCritical]
		private MethodToken GetMethodTokenNoLock(MethodInfo method, bool getGenericTypeDefinition)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			MethodBuilder methodBuilder;
			int str;
			if ((methodBuilder = (method as MethodBuilder)) != null)
			{
				int metadataTokenInternal = methodBuilder.MetadataTokenInternal;
				if (method.Module.Equals(this))
				{
					return new MethodToken(metadataTokenInternal);
				}
				if (method.DeclaringType == null)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotImportGlobalFromDifferentModule"));
				}
				int tr = getGenericTypeDefinition ? this.GetTypeToken(method.DeclaringType).Token : this.GetTypeTokenInternal(method.DeclaringType).Token;
				str = this.GetMemberRef(method.DeclaringType.Module, tr, metadataTokenInternal);
			}
			else
			{
				if (method is MethodOnTypeBuilderInstantiation)
				{
					return new MethodToken(this.GetMemberRefToken(method, null));
				}
				SymbolMethod symbolMethod;
				if ((symbolMethod = (method as SymbolMethod)) != null)
				{
					if (symbolMethod.GetModule() == this)
					{
						return symbolMethod.GetToken();
					}
					return symbolMethod.GetToken(this);
				}
				else
				{
					Type declaringType = method.DeclaringType;
					if (declaringType == null)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotImportGlobalFromDifferentModule"));
					}
					if (declaringType.IsArray)
					{
						ParameterInfo[] parameters = method.GetParameters();
						Type[] array = new Type[parameters.Length];
						for (int i = 0; i < parameters.Length; i++)
						{
							array[i] = parameters[i].ParameterType;
						}
						return this.GetArrayMethodToken(declaringType, method.Name, method.CallingConvention, method.ReturnType, array);
					}
					RuntimeMethodInfo method2;
					if ((method2 = (method as RuntimeMethodInfo)) != null)
					{
						int tr = getGenericTypeDefinition ? this.GetTypeToken(method.DeclaringType).Token : this.GetTypeTokenInternal(method.DeclaringType).Token;
						str = this.GetMemberRefOfMethodInfo(tr, method2);
					}
					else
					{
						ParameterInfo[] parameters2 = method.GetParameters();
						Type[] array2 = new Type[parameters2.Length];
						Type[][] array3 = new Type[array2.Length][];
						Type[][] array4 = new Type[array2.Length][];
						for (int j = 0; j < parameters2.Length; j++)
						{
							array2[j] = parameters2[j].ParameterType;
							array3[j] = parameters2[j].GetRequiredCustomModifiers();
							array4[j] = parameters2[j].GetOptionalCustomModifiers();
						}
						int tr = getGenericTypeDefinition ? this.GetTypeToken(method.DeclaringType).Token : this.GetTypeTokenInternal(method.DeclaringType).Token;
						SignatureHelper methodSigHelper;
						try
						{
							methodSigHelper = SignatureHelper.GetMethodSigHelper(this, method.CallingConvention, method.ReturnType, method.ReturnParameter.GetRequiredCustomModifiers(), method.ReturnParameter.GetOptionalCustomModifiers(), array2, array3, array4);
						}
						catch (NotImplementedException)
						{
							methodSigHelper = SignatureHelper.GetMethodSigHelper(this, method.ReturnType, array2);
						}
						int length;
						byte[] signature = methodSigHelper.InternalGetSignature(out length);
						str = this.GetMemberRefFromSignature(tr, method.Name, signature, length);
					}
				}
			}
			return new MethodToken(str);
		}

		/// <summary>Returns the token used to identify the constructor that has the specified attributes and parameter types within this module.</summary>
		/// <param name="constructor">The constructor to get a token for.</param>
		/// <param name="optionalParameterTypes">A collection of the types of the optional parameters to the constructor.</param>
		/// <returns>The token used to identify the specified constructor within this module.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="constructor" /> is <see langword="null" />.</exception>
		// Token: 0x06004B64 RID: 19300 RVA: 0x0011071C File Offset: 0x0010E91C
		[SecuritySafeCritical]
		public MethodToken GetConstructorToken(ConstructorInfo constructor, IEnumerable<Type> optionalParameterTypes)
		{
			if (constructor == null)
			{
				throw new ArgumentNullException("constructor");
			}
			object syncRoot = this.SyncRoot;
			MethodToken result;
			lock (syncRoot)
			{
				result = new MethodToken(this.GetMethodTokenInternal(constructor, optionalParameterTypes, false));
			}
			return result;
		}

		/// <summary>Returns the token used to identify the method that has the specified attributes and parameter types within this module.</summary>
		/// <param name="method">The method to get a token for.</param>
		/// <param name="optionalParameterTypes">A collection of the types of the optional parameters to the method.</param>
		/// <returns>The token used to identify the specified method within this module.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="method" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The declaring type for the method is not in this module.</exception>
		// Token: 0x06004B65 RID: 19301 RVA: 0x0011077C File Offset: 0x0010E97C
		[SecuritySafeCritical]
		public MethodToken GetMethodToken(MethodInfo method, IEnumerable<Type> optionalParameterTypes)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			object syncRoot = this.SyncRoot;
			MethodToken result;
			lock (syncRoot)
			{
				result = new MethodToken(this.GetMethodTokenInternal(method, optionalParameterTypes, true));
			}
			return result;
		}

		// Token: 0x06004B66 RID: 19302 RVA: 0x001107DC File Offset: 0x0010E9DC
		[SecurityCritical]
		internal int GetMethodTokenInternal(MethodBase method, IEnumerable<Type> optionalParameterTypes, bool useMethodDef)
		{
			MethodInfo methodInfo = method as MethodInfo;
			int num;
			if (method.IsGenericMethod)
			{
				MethodInfo methodInfo2 = methodInfo;
				bool isGenericMethodDefinition = methodInfo.IsGenericMethodDefinition;
				if (!isGenericMethodDefinition)
				{
					methodInfo2 = methodInfo.GetGenericMethodDefinition();
				}
				if (!this.Equals(methodInfo2.Module) || (methodInfo2.DeclaringType != null && methodInfo2.DeclaringType.IsGenericType))
				{
					num = this.GetMemberRefToken(methodInfo2, null);
				}
				else
				{
					num = this.GetMethodTokenInternal(methodInfo2).Token;
				}
				if (isGenericMethodDefinition && useMethodDef)
				{
					return num;
				}
				int sigLength;
				byte[] signature = SignatureHelper.GetMethodSpecSigHelper(this, methodInfo.GetGenericArguments()).InternalGetSignature(out sigLength);
				num = TypeBuilder.DefineMethodSpec(this.GetNativeHandle(), num, signature, sigLength);
			}
			else if ((method.CallingConvention & CallingConventions.VarArgs) == (CallingConventions)0 && (method.DeclaringType == null || !method.DeclaringType.IsGenericType))
			{
				if (methodInfo != null)
				{
					num = this.GetMethodTokenInternal(methodInfo).Token;
				}
				else
				{
					num = this.GetConstructorToken(method as ConstructorInfo).Token;
				}
			}
			else
			{
				num = this.GetMemberRefToken(method, optionalParameterTypes);
			}
			return num;
		}

		/// <summary>Returns the token for the named method on an array class.</summary>
		/// <param name="arrayClass">The object for the array.</param>
		/// <param name="methodName">A string that contains the name of the method.</param>
		/// <param name="callingConvention">The calling convention for the method.</param>
		/// <param name="returnType">The return type of the method.</param>
		/// <param name="parameterTypes">The types of the parameters of the method.</param>
		/// <returns>The token for the named method on an array class.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="arrayClass" /> is not an array.  
		/// -or-  
		/// The length of <paramref name="methodName" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="arrayClass" /> or <paramref name="methodName" /> is <see langword="null" />.</exception>
		// Token: 0x06004B67 RID: 19303 RVA: 0x001108E8 File Offset: 0x0010EAE8
		[SecuritySafeCritical]
		public MethodToken GetArrayMethodToken(Type arrayClass, string methodName, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
		{
			object syncRoot = this.SyncRoot;
			MethodToken arrayMethodTokenNoLock;
			lock (syncRoot)
			{
				arrayMethodTokenNoLock = this.GetArrayMethodTokenNoLock(arrayClass, methodName, callingConvention, returnType, parameterTypes);
			}
			return arrayMethodTokenNoLock;
		}

		// Token: 0x06004B68 RID: 19304 RVA: 0x00110934 File Offset: 0x0010EB34
		[SecurityCritical]
		private MethodToken GetArrayMethodTokenNoLock(Type arrayClass, string methodName, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
		{
			if (arrayClass == null)
			{
				throw new ArgumentNullException("arrayClass");
			}
			if (methodName == null)
			{
				throw new ArgumentNullException("methodName");
			}
			if (methodName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "methodName");
			}
			if (!arrayClass.IsArray)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_HasToBeArrayClass"));
			}
			this.CheckContext(new Type[]
			{
				returnType,
				arrayClass
			});
			this.CheckContext(parameterTypes);
			SignatureHelper methodSigHelper = SignatureHelper.GetMethodSigHelper(this, callingConvention, returnType, null, null, parameterTypes, null, null);
			int sigLength;
			byte[] signature = methodSigHelper.InternalGetSignature(out sigLength);
			TypeToken typeTokenInternal = this.GetTypeTokenInternal(arrayClass);
			return new MethodToken(ModuleBuilder.GetArrayMethodToken(this.GetNativeHandle(), typeTokenInternal.Token, methodName, signature, sigLength));
		}

		/// <summary>Returns the named method on an array class.</summary>
		/// <param name="arrayClass">An array class.</param>
		/// <param name="methodName">The name of a method on the array class.</param>
		/// <param name="callingConvention">The method's calling convention.</param>
		/// <param name="returnType">The return type of the method.</param>
		/// <param name="parameterTypes">The types of the method's parameters.</param>
		/// <returns>The named method on an array class.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="arrayClass" /> is not an array.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="arrayClass" /> or <paramref name="methodName" /> is <see langword="null" />.</exception>
		// Token: 0x06004B69 RID: 19305 RVA: 0x001109F0 File Offset: 0x0010EBF0
		[SecuritySafeCritical]
		public MethodInfo GetArrayMethod(Type arrayClass, string methodName, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
		{
			this.CheckContext(new Type[]
			{
				returnType,
				arrayClass
			});
			this.CheckContext(parameterTypes);
			MethodToken arrayMethodToken = this.GetArrayMethodToken(arrayClass, methodName, callingConvention, returnType, parameterTypes);
			return new SymbolMethod(this, arrayMethodToken, arrayClass, methodName, callingConvention, returnType, parameterTypes);
		}

		/// <summary>Returns the token used to identify the specified constructor within this module.</summary>
		/// <param name="con">The constructor to get a token for.</param>
		/// <returns>The token used to identify the specified constructor within this module.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> is <see langword="null" />.</exception>
		// Token: 0x06004B6A RID: 19306 RVA: 0x00110A36 File Offset: 0x0010EC36
		[SecuritySafeCritical]
		[ComVisible(true)]
		public MethodToken GetConstructorToken(ConstructorInfo con)
		{
			return this.InternalGetConstructorToken(con, false);
		}

		/// <summary>Returns the token used to identify the specified field within this module.</summary>
		/// <param name="field">The field to get a token for.</param>
		/// <returns>The token used to identify the specified field within this module.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="field" /> is <see langword="null" />.</exception>
		// Token: 0x06004B6B RID: 19307 RVA: 0x00110A40 File Offset: 0x0010EC40
		[SecuritySafeCritical]
		public FieldToken GetFieldToken(FieldInfo field)
		{
			object syncRoot = this.SyncRoot;
			FieldToken fieldTokenNoLock;
			lock (syncRoot)
			{
				fieldTokenNoLock = this.GetFieldTokenNoLock(field);
			}
			return fieldTokenNoLock;
		}

		// Token: 0x06004B6C RID: 19308 RVA: 0x00110A84 File Offset: 0x0010EC84
		[SecurityCritical]
		private FieldToken GetFieldTokenNoLock(FieldInfo field)
		{
			if (field == null)
			{
				throw new ArgumentNullException("con");
			}
			FieldBuilder fieldBuilder;
			int field2;
			RuntimeFieldInfo runtimeField;
			FieldOnTypeBuilderInstantiation fieldOnTypeBuilderInstantiation;
			if ((fieldBuilder = (field as FieldBuilder)) != null)
			{
				if (field.DeclaringType != null && field.DeclaringType.IsGenericType)
				{
					int length;
					byte[] signature = SignatureHelper.GetTypeSigToken(this, field.DeclaringType).InternalGetSignature(out length);
					int num = this.GetTokenFromTypeSpec(signature, length);
					field2 = this.GetMemberRef(this, num, fieldBuilder.GetToken().Token);
				}
				else
				{
					if (fieldBuilder.Module.Equals(this))
					{
						return fieldBuilder.GetToken();
					}
					if (field.DeclaringType == null)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotImportGlobalFromDifferentModule"));
					}
					int num = this.GetTypeTokenInternal(field.DeclaringType).Token;
					field2 = this.GetMemberRef(field.ReflectedType.Module, num, fieldBuilder.GetToken().Token);
				}
			}
			else if ((runtimeField = (field as RuntimeFieldInfo)) != null)
			{
				if (field.DeclaringType == null)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotImportGlobalFromDifferentModule"));
				}
				if (field.DeclaringType != null && field.DeclaringType.IsGenericType)
				{
					int length2;
					byte[] signature2 = SignatureHelper.GetTypeSigToken(this, field.DeclaringType).InternalGetSignature(out length2);
					int num = this.GetTokenFromTypeSpec(signature2, length2);
					field2 = this.GetMemberRefOfFieldInfo(num, field.DeclaringType.GetTypeHandleInternal(), runtimeField);
				}
				else
				{
					int num = this.GetTypeTokenInternal(field.DeclaringType).Token;
					field2 = this.GetMemberRefOfFieldInfo(num, field.DeclaringType.GetTypeHandleInternal(), runtimeField);
				}
			}
			else if ((fieldOnTypeBuilderInstantiation = (field as FieldOnTypeBuilderInstantiation)) != null)
			{
				FieldInfo fieldInfo = fieldOnTypeBuilderInstantiation.FieldInfo;
				int length3;
				byte[] signature3 = SignatureHelper.GetTypeSigToken(this, field.DeclaringType).InternalGetSignature(out length3);
				int num = this.GetTokenFromTypeSpec(signature3, length3);
				field2 = this.GetMemberRef(fieldInfo.ReflectedType.Module, num, fieldOnTypeBuilderInstantiation.MetadataTokenInternal);
			}
			else
			{
				int num = this.GetTypeTokenInternal(field.ReflectedType).Token;
				SignatureHelper fieldSigHelper = SignatureHelper.GetFieldSigHelper(this);
				fieldSigHelper.AddArgument(field.FieldType, field.GetRequiredCustomModifiers(), field.GetOptionalCustomModifiers());
				int length4;
				byte[] signature4 = fieldSigHelper.InternalGetSignature(out length4);
				field2 = this.GetMemberRefFromSignature(num, field.Name, signature4, length4);
			}
			return new FieldToken(field2, field.GetType());
		}

		/// <summary>Returns the token of the given string in the module's constant pool.</summary>
		/// <param name="str">The string to add to the module's constant pool.</param>
		/// <returns>The token of the string in the constant pool.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="str" /> is <see langword="null" />.</exception>
		// Token: 0x06004B6D RID: 19309 RVA: 0x00110CF4 File Offset: 0x0010EEF4
		[SecuritySafeCritical]
		public StringToken GetStringConstant(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			return new StringToken(ModuleBuilder.GetStringConstant(this.GetNativeHandle(), str, str.Length));
		}

		/// <summary>Defines a token for the signature that is defined by the specified <see cref="T:System.Reflection.Emit.SignatureHelper" />.</summary>
		/// <param name="sigHelper">The signature.</param>
		/// <returns>A token for the defined signature.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="sigHelper" /> is <see langword="null" />.</exception>
		// Token: 0x06004B6E RID: 19310 RVA: 0x00110D1C File Offset: 0x0010EF1C
		[SecuritySafeCritical]
		public SignatureToken GetSignatureToken(SignatureHelper sigHelper)
		{
			if (sigHelper == null)
			{
				throw new ArgumentNullException("sigHelper");
			}
			int sigLength;
			byte[] signature = sigHelper.InternalGetSignature(out sigLength);
			return new SignatureToken(TypeBuilder.GetTokenFromSig(this.GetNativeHandle(), signature, sigLength), this);
		}

		/// <summary>Defines a token for the signature that has the specified character array and signature length.</summary>
		/// <param name="sigBytes">The signature binary large object (BLOB).</param>
		/// <param name="sigLength">The length of the signature BLOB.</param>
		/// <returns>A token for the specified signature.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="sigBytes" /> is <see langword="null" />.</exception>
		// Token: 0x06004B6F RID: 19311 RVA: 0x00110D54 File Offset: 0x0010EF54
		[SecuritySafeCritical]
		public SignatureToken GetSignatureToken(byte[] sigBytes, int sigLength)
		{
			if (sigBytes == null)
			{
				throw new ArgumentNullException("sigBytes");
			}
			byte[] array = new byte[sigBytes.Length];
			Array.Copy(sigBytes, array, sigBytes.Length);
			return new SignatureToken(TypeBuilder.GetTokenFromSig(this.GetNativeHandle(), array, sigLength), this);
		}

		/// <summary>Applies a custom attribute to this module by using a specified binary large object (BLOB) that represents the attribute.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="binaryAttribute">A byte BLOB representing the attribute.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> or <paramref name="binaryAttribute" /> is <see langword="null" />.</exception>
		// Token: 0x06004B70 RID: 19312 RVA: 0x00110D98 File Offset: 0x0010EF98
		[SecuritySafeCritical]
		[ComVisible(true)]
		public void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			if (con == null)
			{
				throw new ArgumentNullException("con");
			}
			if (binaryAttribute == null)
			{
				throw new ArgumentNullException("binaryAttribute");
			}
			TypeBuilder.DefineCustomAttribute(this, 1, this.GetConstructorToken(con).Token, binaryAttribute, false, false);
		}

		/// <summary>Applies a custom attribute to this module by using a custom attribute builder.</summary>
		/// <param name="customBuilder">An instance of a helper class that specifies the custom attribute to apply.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="customBuilder" /> is <see langword="null" />.</exception>
		// Token: 0x06004B71 RID: 19313 RVA: 0x00110DE0 File Offset: 0x0010EFE0
		[SecuritySafeCritical]
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (customBuilder == null)
			{
				throw new ArgumentNullException("customBuilder");
			}
			customBuilder.CreateCustomAttribute(this, 1);
		}

		/// <summary>Returns the symbol writer associated with this dynamic module.</summary>
		/// <returns>The symbol writer associated with this dynamic module.</returns>
		// Token: 0x06004B72 RID: 19314 RVA: 0x00110DF8 File Offset: 0x0010EFF8
		public ISymbolWriter GetSymWriter()
		{
			return this.m_iSymWriter;
		}

		/// <summary>Defines a document for source.</summary>
		/// <param name="url">The URL for the document.</param>
		/// <param name="language">The GUID that identifies the document language. This can be <see cref="F:System.Guid.Empty" />.</param>
		/// <param name="languageVendor">The GUID that identifies the document language vendor. This can be <see cref="F:System.Guid.Empty" />.</param>
		/// <param name="documentType">The GUID that identifies the document type. This can be <see cref="F:System.Guid.Empty" />.</param>
		/// <returns>The defined document.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="url" /> is <see langword="null" />. This is a change from earlier versions of the .NET Framework.</exception>
		/// <exception cref="T:System.InvalidOperationException">This method is called on a dynamic module that is not a debug module.</exception>
		// Token: 0x06004B73 RID: 19315 RVA: 0x00110E00 File Offset: 0x0010F000
		public ISymbolDocumentWriter DefineDocument(string url, Guid language, Guid languageVendor, Guid documentType)
		{
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			object syncRoot = this.SyncRoot;
			ISymbolDocumentWriter result;
			lock (syncRoot)
			{
				result = this.DefineDocumentNoLock(url, language, languageVendor, documentType);
			}
			return result;
		}

		// Token: 0x06004B74 RID: 19316 RVA: 0x00110E58 File Offset: 0x0010F058
		private ISymbolDocumentWriter DefineDocumentNoLock(string url, Guid language, Guid languageVendor, Guid documentType)
		{
			if (this.m_iSymWriter == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotADebugModule"));
			}
			return this.m_iSymWriter.DefineDocument(url, language, languageVendor, documentType);
		}

		/// <summary>Sets the user entry point.</summary>
		/// <param name="entryPoint">The user entry point.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="entryPoint" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">This method is called on a dynamic module that is not a debug module.  
		///  -or-  
		///  <paramref name="entryPoint" /> is not contained in this dynamic module.</exception>
		// Token: 0x06004B75 RID: 19317 RVA: 0x00110E84 File Offset: 0x0010F084
		[SecuritySafeCritical]
		public void SetUserEntryPoint(MethodInfo entryPoint)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.SetUserEntryPointNoLock(entryPoint);
			}
		}

		// Token: 0x06004B76 RID: 19318 RVA: 0x00110EC8 File Offset: 0x0010F0C8
		[SecurityCritical]
		private void SetUserEntryPointNoLock(MethodInfo entryPoint)
		{
			if (entryPoint == null)
			{
				throw new ArgumentNullException("entryPoint");
			}
			if (this.m_iSymWriter == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotADebugModule"));
			}
			if (entryPoint.DeclaringType != null)
			{
				if (!entryPoint.Module.Equals(this))
				{
					throw new InvalidOperationException(Environment.GetResourceString("Argument_NotInTheSameModuleBuilder"));
				}
			}
			else
			{
				MethodBuilder methodBuilder = entryPoint as MethodBuilder;
				if (methodBuilder != null && methodBuilder.GetModuleBuilder() != this)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Argument_NotInTheSameModuleBuilder"));
				}
			}
			SymbolToken userEntryPoint = new SymbolToken(this.GetMethodTokenInternal(entryPoint).Token);
			this.m_iSymWriter.SetUserEntryPoint(userEntryPoint);
		}

		/// <summary>This method does nothing.</summary>
		/// <param name="name">The name of the custom attribute</param>
		/// <param name="data">An opaque binary large object (BLOB) of bytes that represents the value of the custom attribute.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="url" /> is <see langword="null" />.</exception>
		// Token: 0x06004B77 RID: 19319 RVA: 0x00110F80 File Offset: 0x0010F180
		public void SetSymCustomAttribute(string name, byte[] data)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.SetSymCustomAttributeNoLock(name, data);
			}
		}

		// Token: 0x06004B78 RID: 19320 RVA: 0x00110FC4 File Offset: 0x0010F1C4
		private void SetSymCustomAttributeNoLock(string name, byte[] data)
		{
			if (this.m_iSymWriter == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotADebugModule"));
			}
		}

		/// <summary>Returns a value that indicates whether this dynamic module is transient.</summary>
		/// <returns>
		///   <see langword="true" /> if this dynamic module is transient; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004B79 RID: 19321 RVA: 0x00110FDE File Offset: 0x0010F1DE
		public bool IsTransient()
		{
			return this.InternalModule.IsTransientInternal();
		}

		/// <summary>For a description of this member, see <see cref="M:System.Runtime.InteropServices._ModuleBuilder.GetTypeInfoCount(System.UInt32@)" />.</summary>
		/// <param name="pcTInfo">The location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004B7A RID: 19322 RVA: 0x00110FEB File Offset: 0x0010F1EB
		void _ModuleBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>For a description of this member, see <see cref="M:System.Runtime.InteropServices._ModuleBuilder.GetTypeInfo(System.UInt32,System.UInt32,System.IntPtr)" />.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">A pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004B7B RID: 19323 RVA: 0x00110FF2 File Offset: 0x0010F1F2
		void _ModuleBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>For a description of this member, see <see cref="M:System.Runtime.InteropServices._ModuleBuilder.GetIDsOfNames(System.Guid@,System.IntPtr,System.UInt32,System.UInt32,System.IntPtr)" />.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array which receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004B7C RID: 19324 RVA: 0x00110FF9 File Offset: 0x0010F1F9
		void _ModuleBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		/// <summary>For a description of this member, see <see cref="M:System.Runtime.InteropServices._ModuleBuilder.Invoke(System.UInt32,System.Guid@,System.UInt32,System.Int16,System.IntPtr,System.IntPtr,System.IntPtr,System.IntPtr)" />.</summary>
		/// <param name="dispIdMember">The member ID.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">Pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">Pointer to the location where the result is to be stored.</param>
		/// <param name="pExcepInfo">Pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004B7D RID: 19325 RVA: 0x00111000 File Offset: 0x0010F200
		void _ModuleBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04001E9A RID: 7834
		private Dictionary<string, Type> m_TypeBuilderDict;

		// Token: 0x04001E9B RID: 7835
		private ISymbolWriter m_iSymWriter;

		// Token: 0x04001E9C RID: 7836
		internal ModuleBuilderData m_moduleData;

		// Token: 0x04001E9D RID: 7837
		private MethodToken m_EntryPoint;

		// Token: 0x04001E9E RID: 7838
		internal InternalModuleBuilder m_internalModuleBuilder;

		// Token: 0x04001E9F RID: 7839
		private AssemblyBuilder m_assemblyBuilder;
	}
}
