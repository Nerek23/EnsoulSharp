using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using <CppImplementationDetails>;
using <CrtImplementationDetails>;
using EnsoulSharp.Native;
using EnsoulSharp.Native.Enums;

// Token: 0x02000001 RID: 1
internal class <Module>
{
	// Token: 0x06000001 RID: 1 RVA: 0x0000160C File Offset: 0x00000A0C
	internal unsafe static sbyte* get(StlString* A_0)
	{
		return (*(A_0 + 16) + 1 <= 16) ? A_0 : (*A_0);
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00010F34 File Offset: 0x00010334
	internal static void <CrtImplementationDetails>.ThrowNestedModuleLoadException(Exception innerException, Exception nestedException)
	{
		throw new ModuleLoadExceptionHandlerException("A nested exception occurred after the primary exception that caused the C++ module to fail to load.\n", innerException, nestedException);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00010930 File Offset: 0x0000FD30
	internal static void <CrtImplementationDetails>.ThrowModuleLoadException(string errorMessage)
	{
		throw new ModuleLoadException(errorMessage);
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00010944 File Offset: 0x0000FD44
	internal static void <CrtImplementationDetails>.ThrowModuleLoadException(string errorMessage, Exception innerException)
	{
		throw new ModuleLoadException(errorMessage, innerException);
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00010A60 File Offset: 0x0000FE60
	internal static void <CrtImplementationDetails>.RegisterModuleUninitializer(EventHandler handler)
	{
		ModuleUninitializer._ModuleUninitializer.AddHandler(handler);
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00010A78 File Offset: 0x0000FE78
	[SecuritySafeCritical]
	internal unsafe static Guid <CrtImplementationDetails>.FromGUID(_GUID* guid)
	{
		Guid result = new Guid((uint)(*guid), *(guid + 4), *(guid + 6), *(guid + 8), *(guid + 9), *(guid + 10), *(guid + 11), *(guid + 12), *(guid + 13), *(guid + 14), *(guid + 15));
		return result;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00010AC0 File Offset: 0x0000FEC0
	[SecurityCritical]
	internal unsafe static int __get_default_appdomain(IUnknown** ppUnk)
	{
		ICorRuntimeHost* ptr = null;
		int num;
		try
		{
			Guid riid = <Module>.<CrtImplementationDetails>.FromGUID(ref <Module>._GUID_cb2f6722_ab3a_11d2_9c40_00c04fa30a3e);
			ptr = (ICorRuntimeHost*)RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(<Module>.<CrtImplementationDetails>.FromGUID(ref <Module>._GUID_cb2f6723_ab3a_11d2_9c40_00c04fa30a3e), riid).ToPointer();
			goto IL_35;
		}
		catch (Exception e)
		{
			num = Marshal.GetHRForException(e);
		}
		if (num < 0)
		{
			return num;
		}
		IL_35:
		int num2 = *(*(int*)ptr + 52);
		num = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvStdcall)(System.IntPtr,IUnknown**), ptr, ppUnk, num2);
		ICorRuntimeHost* ptr2 = ptr;
		object obj = calli(System.UInt32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvStdcall)(System.IntPtr), ptr2, *(*(int*)ptr2 + 8));
		return num;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00010B3C File Offset: 0x0000FF3C
	internal unsafe static void __release_appdomain(IUnknown* ppUnk)
	{
		object obj = calli(System.UInt32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvStdcall)(System.IntPtr), ppUnk, *(*(int*)ppUnk + 8));
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00010B58 File Offset: 0x0000FF58
	[SecurityCritical]
	internal unsafe static AppDomain <CrtImplementationDetails>.GetDefaultDomain()
	{
		IUnknown* ptr = null;
		int num = <Module>.__get_default_appdomain(&ptr);
		if (num >= 0)
		{
			try
			{
				IntPtr pUnk = new IntPtr((void*)ptr);
				return (AppDomain)Marshal.GetObjectForIUnknown(pUnk);
			}
			finally
			{
				<Module>.__release_appdomain(ptr);
			}
		}
		Marshal.ThrowExceptionForHR(num);
		return null;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00010BB8 File Offset: 0x0000FFB8
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.DoCallBackInDefaultDomain(method function, void* cookie)
	{
		Guid riid = <Module>.<CrtImplementationDetails>.FromGUID(ref <Module>._GUID_90f1a06c_7712_4762_86b5_7a5eba6bdb02);
		ICLRRuntimeHost* ptr = (ICLRRuntimeHost*)RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(<Module>.<CrtImplementationDetails>.FromGUID(ref <Module>._GUID_90f1a06e_7712_4762_86b5_7a5eba6bdb02), riid).ToPointer();
		try
		{
			AppDomain appDomain = <Module>.<CrtImplementationDetails>.GetDefaultDomain();
			int num = *(*(int*)ptr + 32);
			int num2 = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvStdcall)(System.IntPtr,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong),System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvStdcall) (System.Void*),System.Void*), ptr, appDomain.Id, function, cookie, num);
			if (num2 < 0)
			{
				Marshal.ThrowExceptionForHR(num2);
			}
		}
		finally
		{
			ICLRRuntimeHost* ptr2 = ptr;
			object obj = calli(System.UInt32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvStdcall)(System.IntPtr), ptr2, *(*(int*)ptr2 + 8));
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00010C40 File Offset: 0x00010040
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool __scrt_is_safe_for_managed_code()
	{
		return (<Module>.__scrt_native_dllmain_reason <= 1U) ? 0 : 1;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00010C6C File Offset: 0x0001006C
	[SecuritySafeCritical]
	internal unsafe static int <CrtImplementationDetails>.DefaultDomain.DoNothing(void* cookie)
	{
		GC.KeepAlive(int.MaxValue);
		return 0;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00010C8C File Offset: 0x0001008C
	[SecuritySafeCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool <CrtImplementationDetails>.DefaultDomain.HasPerProcess()
	{
		if (<Module>.?hasPerProcess@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A == (TriBool)2)
		{
			void** ptr = (void**)(&<Module>.__xc_mp_a);
			if (ref <Module>.__xc_mp_a < ref <Module>.__xc_mp_z)
			{
				while (*(int*)ptr == 0)
				{
					ptr += 4 / sizeof(void*);
					if (ptr >= (void**)(&<Module>.__xc_mp_z))
					{
						goto IL_34;
					}
				}
				<Module>.?hasPerProcess@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A = (TriBool)(-1);
				return 1;
			}
			IL_34:
			<Module>.?hasPerProcess@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A = (TriBool)0;
			return 0;
		}
		return (<Module>.?hasPerProcess@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A == (TriBool)(-1)) ? 1 : 0;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00010CE0 File Offset: 0x000100E0
	[SecuritySafeCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool <CrtImplementationDetails>.DefaultDomain.HasNative()
	{
		if (<Module>.?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A == (TriBool)2)
		{
			void** ptr = (void**)(&<Module>.__xi_a);
			if (ref <Module>.__xi_a < ref <Module>.__xi_z)
			{
				while (*(int*)ptr == 0)
				{
					ptr += 4 / sizeof(void*);
					if (ptr >= (void**)(&<Module>.__xi_z))
					{
						goto IL_34;
					}
				}
				<Module>.?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A = (TriBool)(-1);
				return 1;
			}
			IL_34:
			void** ptr2 = (void**)(&<Module>.__xc_a);
			if (ref <Module>.__xc_a < ref <Module>.__xc_z)
			{
				while (*(int*)ptr2 == 0)
				{
					ptr2 += 4 / sizeof(void*);
					if (ptr2 >= (void**)(&<Module>.__xc_z))
					{
						goto IL_60;
					}
				}
				<Module>.?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A = (TriBool)(-1);
				return 1;
			}
			IL_60:
			<Module>.?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A = (TriBool)0;
			return 0;
		}
		return (<Module>.?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A == (TriBool)(-1)) ? 1 : 0;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00010D60 File Offset: 0x00010160
	[SecuritySafeCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool <CrtImplementationDetails>.DefaultDomain.NeedsInitialization()
	{
		int num;
		if ((<Module>.<CrtImplementationDetails>.DefaultDomain.HasPerProcess() != null && !<Module>.?InitializedPerProcess@DefaultDomain@<CrtImplementationDetails>@@2_NA) || (<Module>.<CrtImplementationDetails>.DefaultDomain.HasNative() != null && !<Module>.?InitializedNative@DefaultDomain@<CrtImplementationDetails>@@2_NA && <Module>.__scrt_current_native_startup_state == (__scrt_native_startup_state)0))
		{
			num = 1;
		}
		else
		{
			num = 0;
		}
		return (byte)num;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00010D98 File Offset: 0x00010198
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool <CrtImplementationDetails>.DefaultDomain.NeedsUninitialization()
	{
		return <Module>.?Entered@DefaultDomain@<CrtImplementationDetails>@@2_NA;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00010DAC File Offset: 0x000101AC
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.DefaultDomain.Initialize()
	{
		<Module>.<CrtImplementationDetails>.DoCallBackInDefaultDomain(<Module>.__unep@?DoNothing@DefaultDomain@<CrtImplementationDetails>@@$$FCGJPAX@Z, null);
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00001000 File Offset: 0x00000400
	internal static void ??__E?Initialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA@@YMXXZ()
	{
		<Module>.?Initialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA = 0;
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00001014 File Offset: 0x00000414
	internal static void ??__E?Uninitialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA@@YMXXZ()
	{
		<Module>.?Uninitialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA = 0;
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00001028 File Offset: 0x00000428
	internal static void ??__E?IsDefaultDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2_NA@@YMXXZ()
	{
		<Module>.?IsDefaultDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2_NA = false;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x0000103C File Offset: 0x0000043C
	internal static void ??__E?InitializedVtables@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A@@YMXXZ()
	{
		<Module>.?InitializedVtables@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)0;
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00001050 File Offset: 0x00000450
	internal static void ??__E?InitializedNative@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A@@YMXXZ()
	{
		<Module>.?InitializedNative@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)0;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00001064 File Offset: 0x00000464
	internal static void ??__E?InitializedPerProcess@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A@@YMXXZ()
	{
		<Module>.?InitializedPerProcess@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)0;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00001078 File Offset: 0x00000478
	internal static void ??__E?InitializedPerAppDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A@@YMXXZ()
	{
		<Module>.?InitializedPerAppDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)0;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00010F88 File Offset: 0x00010388
	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializeVtables(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load during vtable initialization.\n");
		<Module>.?InitializedVtables@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)1;
		<Module>._initterm_m((method*)(&<Module>.__xi_vt_a), (method*)(&<Module>.__xi_vt_z));
		<Module>.?InitializedVtables@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)2;
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00010FBC File Offset: 0x000103BC
	[SecuritySafeCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializeDefaultAppDomain(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load while attempting to initialize the default appdomain.\n");
		<Module>.<CrtImplementationDetails>.DefaultDomain.Initialize();
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00010FDC File Offset: 0x000103DC
	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializeNative(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load during native initialization.\n");
		<Module>.__security_init_cookie();
		<Module>.?InitializedNative@DefaultDomain@<CrtImplementationDetails>@@2_NA = true;
		if (<Module>.__scrt_is_safe_for_managed_code() == null)
		{
			<Module>.abort();
		}
		if (<Module>.__scrt_current_native_startup_state == (__scrt_native_startup_state)1)
		{
			<Module>.abort();
		}
		if (<Module>.__scrt_current_native_startup_state == (__scrt_native_startup_state)0)
		{
			<Module>.?InitializedNative@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)1;
			<Module>.__scrt_current_native_startup_state = (__scrt_native_startup_state)1;
			if (<Module>._initterm_e((method*)(&<Module>.__xi_a), (method*)(&<Module>.__xi_z)) != 0)
			{
				<Module>.<CrtImplementationDetails>.ThrowModuleLoadException(<Module>.gcroot<System::String\u0020^>..P$AAVString@System@@(A_0));
			}
			<Module>._initterm((method*)(&<Module>.__xc_a), (method*)(&<Module>.__xc_z));
			<Module>.__scrt_current_native_startup_state = (__scrt_native_startup_state)2;
			<Module>.?InitializedNativeFromCCTOR@DefaultDomain@<CrtImplementationDetails>@@2_NA = true;
			<Module>.?InitializedNative@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)2;
		}
	}

	// Token: 0x0600001C RID: 28 RVA: 0x0001106C File Offset: 0x0001046C
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializePerProcess(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load during process initialization.\n");
		<Module>.?InitializedPerProcess@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)1;
		<Module>._initatexit_m();
		<Module>._initterm_m((method*)(&<Module>.__xc_mp_a), (method*)(&<Module>.__xc_mp_z));
		<Module>.?InitializedPerProcess@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)2;
		<Module>.?InitializedPerProcess@DefaultDomain@<CrtImplementationDetails>@@2_NA = true;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x000110AC File Offset: 0x000104AC
	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializePerAppDomain(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load during appdomain initialization.\n");
		<Module>.?InitializedPerAppDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)1;
		<Module>._initatexit_app_domain();
		<Module>._initterm_m((method*)(&<Module>.__xc_ma_a), (method*)(&<Module>.__xc_ma_z));
		<Module>.?InitializedPerAppDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)2;
	}

	// Token: 0x0600001E RID: 30 RVA: 0x000110E8 File Offset: 0x000104E8
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializeUninitializer(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load during registration for the unload events.\n");
		<Module>.<CrtImplementationDetails>.RegisterModuleUninitializer(new EventHandler(<Module>.<CrtImplementationDetails>.LanguageSupport.DomainUnload));
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00011114 File Offset: 0x00010514
	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[DebuggerStepThrough]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport._Initialize(LanguageSupport* A_0)
	{
		<Module>.?IsDefaultDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2_NA = AppDomain.CurrentDomain.IsDefaultAppDomain();
		if (<Module>.?IsDefaultDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2_NA)
		{
			<Module>.?Entered@DefaultDomain@<CrtImplementationDetails>@@2_NA = true;
		}
		void* ptr = <Module>._getFiberPtrId();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			while (num2 == 0)
			{
				try
				{
				}
				finally
				{
					IntPtr comparand = (IntPtr)0;
					IntPtr value = (IntPtr)ptr;
					IntPtr value2 = Interlocked.CompareExchange(ref <Module>.__scrt_native_startup_lock, value, comparand);
					void* ptr2 = (void*)value2;
					if (ptr2 == null)
					{
						num2 = 1;
					}
					else if (ptr2 == ptr)
					{
						num = 1;
						num2 = 1;
					}
				}
				if (num2 == 0)
				{
					<Module>.Sleep(1000);
				}
			}
			<Module>.<CrtImplementationDetails>.LanguageSupport.InitializeVtables(A_0);
			if (<Module>.?IsDefaultDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2_NA)
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport.InitializeNative(A_0);
				<Module>.<CrtImplementationDetails>.LanguageSupport.InitializePerProcess(A_0);
			}
			else if (<Module>.<CrtImplementationDetails>.DefaultDomain.NeedsInitialization() != null)
			{
				num3 = 1;
			}
		}
		finally
		{
			if (num == 0)
			{
				IntPtr value3 = (IntPtr)0;
				Interlocked.Exchange(ref <Module>.__scrt_native_startup_lock, value3);
			}
		}
		if (num3 != 0)
		{
			<Module>.<CrtImplementationDetails>.LanguageSupport.InitializeDefaultAppDomain(A_0);
		}
		<Module>.<CrtImplementationDetails>.LanguageSupport.InitializePerAppDomain(A_0);
		<Module>.?Initialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA = 1;
		<Module>.<CrtImplementationDetails>.LanguageSupport.InitializeUninitializer(A_0);
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00010DC4 File Offset: 0x000101C4
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.LanguageSupport.UninitializeAppDomain()
	{
		<Module>._app_exit_callback();
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00010DD8 File Offset: 0x000101D8
	[SecurityCritical]
	internal unsafe static int <CrtImplementationDetails>.LanguageSupport._UninitializeDefaultDomain(void* cookie)
	{
		<Module>._exit_callback();
		<Module>.?InitializedPerProcess@DefaultDomain@<CrtImplementationDetails>@@2_NA = false;
		if (<Module>.?InitializedNativeFromCCTOR@DefaultDomain@<CrtImplementationDetails>@@2_NA)
		{
			<Module>._cexit();
			<Module>.__scrt_current_native_startup_state = (__scrt_native_startup_state)0;
			<Module>.?InitializedNativeFromCCTOR@DefaultDomain@<CrtImplementationDetails>@@2_NA = false;
		}
		<Module>.?InitializedNative@DefaultDomain@<CrtImplementationDetails>@@2_NA = false;
		return 0;
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00010E10 File Offset: 0x00010210
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.LanguageSupport.UninitializeDefaultDomain()
	{
		if (<Module>.<CrtImplementationDetails>.DefaultDomain.NeedsUninitialization() != null)
		{
			if (AppDomain.CurrentDomain.IsDefaultAppDomain())
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport._UninitializeDefaultDomain(null);
			}
			else
			{
				<Module>.<CrtImplementationDetails>.DoCallBackInDefaultDomain(<Module>.__unep@?_UninitializeDefaultDomain@LanguageSupport@<CrtImplementationDetails>@@$$FCGJPAX@Z, null);
			}
		}
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00010E44 File Offset: 0x00010244
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	[PrePrepareMethod]
	internal static void <CrtImplementationDetails>.LanguageSupport.DomainUnload(object A_0, EventArgs A_1)
	{
		if (<Module>.?Initialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA != 0 && Interlocked.Exchange(ref <Module>.?Uninitialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA, 1) == 0)
		{
			byte b = (Interlocked.Decrement(ref <Module>.?Count@AllDomains@<CrtImplementationDetails>@@2HA) == 0) ? 1 : 0;
			<Module>.<CrtImplementationDetails>.LanguageSupport.UninitializeAppDomain();
			if (b != 0)
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport.UninitializeDefaultDomain();
			}
		}
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00011238 File Offset: 0x00010638
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.Cleanup(LanguageSupport* A_0, Exception innerException)
	{
		try
		{
			bool flag = ((Interlocked.Decrement(ref <Module>.?Count@AllDomains@<CrtImplementationDetails>@@2HA) == 0) ? 1 : 0) != 0;
			<Module>.<CrtImplementationDetails>.LanguageSupport.UninitializeAppDomain();
			if (flag)
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport.UninitializeDefaultDomain();
			}
		}
		catch (Exception nestedException)
		{
			<Module>.<CrtImplementationDetails>.ThrowNestedModuleLoadException(innerException, nestedException);
		}
		catch (object obj)
		{
			<Module>.<CrtImplementationDetails>.ThrowNestedModuleLoadException(innerException, null);
		}
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000112AC File Offset: 0x000106AC
	[SecurityCritical]
	internal unsafe static LanguageSupport* <CrtImplementationDetails>.LanguageSupport.{ctor}(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.{ctor}(A_0);
		return A_0;
	}

	// Token: 0x06000026 RID: 38 RVA: 0x000112C4 File Offset: 0x000106C4
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.{dtor}(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.{dtor}(A_0);
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000112D8 File Offset: 0x000106D8
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.Initialize(LanguageSupport* A_0)
	{
		bool flag = false;
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load.\n");
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
			}
			finally
			{
				Interlocked.Increment(ref <Module>.?Count@AllDomains@<CrtImplementationDetails>@@2HA);
				flag = true;
			}
			<Module>.<CrtImplementationDetails>.LanguageSupport._Initialize(A_0);
		}
		catch (Exception innerException)
		{
			if (flag)
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport.Cleanup(A_0, innerException);
			}
			<Module>.<CrtImplementationDetails>.ThrowModuleLoadException(<Module>.gcroot<System::String\u0020^>..P$AAVString@System@@(A_0), innerException);
		}
		catch (object obj)
		{
			if (flag)
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport.Cleanup(A_0, null);
			}
			<Module>.<CrtImplementationDetails>.ThrowModuleLoadException(<Module>.gcroot<System::String\u0020^>..P$AAVString@System@@(A_0), null);
		}
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00011394 File Offset: 0x00010794
	[DebuggerStepThrough]
	[SecurityCritical]
	static unsafe <Module>()
	{
		LanguageSupport languageSupport;
		<Module>.<CrtImplementationDetails>.LanguageSupport.{ctor}(ref languageSupport);
		try
		{
			<Module>.<CrtImplementationDetails>.LanguageSupport.Initialize(ref languageSupport);
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(<CrtImplementationDetails>.LanguageSupport.{dtor}), (void*)(&languageSupport));
			throw;
		}
		<Module>.<CrtImplementationDetails>.LanguageSupport.{dtor}(ref languageSupport);
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00010E80 File Offset: 0x00010280
	[SecuritySafeCritical]
	internal unsafe static string P$AAVString@System@@(gcroot<System::String\u0020^>* A_0)
	{
		IntPtr value = new IntPtr(*A_0);
		return ((GCHandle)value).Target;
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00010EA4 File Offset: 0x000102A4
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static gcroot<System::String\u0020^>* =(gcroot<System::String\u0020^>* A_0, string t)
	{
		IntPtr value = new IntPtr(*A_0);
		((GCHandle)value).Target = t;
		return A_0;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00010ECC File Offset: 0x000102CC
	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void {dtor}(gcroot<System::String\u0020^>* A_0)
	{
		IntPtr value = new IntPtr(*A_0);
		((GCHandle)value).Free();
		*A_0 = 0;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00010EF4 File Offset: 0x000102F4
	[SecuritySafeCritical]
	[DebuggerStepThrough]
	internal unsafe static gcroot<System::String\u0020^>* {ctor}(gcroot<System::String\u0020^>* A_0)
	{
		*A_0 = ((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return A_0;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00011414 File Offset: 0x00010814
	[HandleProcessCorruptedStateExceptions]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static void ___CxxCallUnwindDtor(method pDtor, void* pThis)
	{
		try
		{
			calli(System.Void(System.Void*), pThis, pDtor);
		}
		catch when (endfilter(<Module>.__FrameUnwindFilter(Marshal.GetExceptionPointers()) != null))
		{
		}
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00011458 File Offset: 0x00010858
	[SecurityCritical]
	[DebuggerStepThrough]
	internal static ValueType <CrtImplementationDetails>.AtExitLock._handle()
	{
		if (<Module>.?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PAXA != null)
		{
			IntPtr value = new IntPtr(<Module>.?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PAXA);
			return GCHandle.FromIntPtr(value);
		}
		return null;
	}

	// Token: 0x0600002F RID: 47 RVA: 0x000116F8 File Offset: 0x00010AF8
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.AtExitLock._lock_Construct(object value)
	{
		<Module>.?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PAXA = null;
		<Module>.<CrtImplementationDetails>.AtExitLock._lock_Set(value);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00011488 File Offset: 0x00010888
	[SecurityCritical]
	[DebuggerStepThrough]
	internal static void <CrtImplementationDetails>.AtExitLock._lock_Set(object value)
	{
		ValueType valueType = <Module>.<CrtImplementationDetails>.AtExitLock._handle();
		if (valueType == null)
		{
			valueType = GCHandle.Alloc(value);
			<Module>.?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PAXA = GCHandle.ToIntPtr((GCHandle)valueType).ToPointer();
		}
		else
		{
			((GCHandle)valueType).Target = value;
		}
	}

	// Token: 0x06000031 RID: 49 RVA: 0x000114D8 File Offset: 0x000108D8
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static object <CrtImplementationDetails>.AtExitLock._lock_Get()
	{
		ValueType valueType = <Module>.<CrtImplementationDetails>.AtExitLock._handle();
		if (valueType != null)
		{
			return ((GCHandle)valueType).Target;
		}
		return null;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x000114FC File Offset: 0x000108FC
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.AtExitLock._lock_Destruct()
	{
		ValueType valueType = <Module>.<CrtImplementationDetails>.AtExitLock._handle();
		if (valueType != null)
		{
			((GCHandle)valueType).Free();
			<Module>.?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PAXA = null;
		}
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00011524 File Offset: 0x00010924
	[SecurityCritical]
	[DebuggerStepThrough]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool <CrtImplementationDetails>.AtExitLock.IsInitialized()
	{
		return (<Module>.<CrtImplementationDetails>.AtExitLock._lock_Get() != null) ? 1 : 0;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00011714 File Offset: 0x00010B14
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.AtExitLock.AddRef()
	{
		if (<Module>.<CrtImplementationDetails>.AtExitLock.IsInitialized() == null)
		{
			<Module>.<CrtImplementationDetails>.AtExitLock._lock_Construct(new object());
			<Module>.?_ref_count@AtExitLock@<CrtImplementationDetails>@@$$Q0HA = 0;
		}
		<Module>.?_ref_count@AtExitLock@<CrtImplementationDetails>@@$$Q0HA++;
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00011540 File Offset: 0x00010940
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.AtExitLock.RemoveRef()
	{
		<Module>.?_ref_count@AtExitLock@<CrtImplementationDetails>@@$$Q0HA--;
		if (<Module>.?_ref_count@AtExitLock@<CrtImplementationDetails>@@$$Q0HA == 0)
		{
			<Module>.<CrtImplementationDetails>.AtExitLock._lock_Destruct();
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00011744 File Offset: 0x00010B44
	[SecurityCritical]
	[DebuggerStepThrough]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool __alloc_global_lock()
	{
		<Module>.<CrtImplementationDetails>.AtExitLock.AddRef();
		return <Module>.<CrtImplementationDetails>.AtExitLock.IsInitialized();
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00011568 File Offset: 0x00010968
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void __dealloc_global_lock()
	{
		<Module>.<CrtImplementationDetails>.AtExitLock.RemoveRef();
	}

	// Token: 0x06000038 RID: 56 RVA: 0x0001157C File Offset: 0x0001097C
	[SecurityCritical]
	internal unsafe static void _exit_callback()
	{
		if (<Module>.?A0x373b8c5b.__exit_list_size != 0U)
		{
			method* ptr = (method*)<Module>.DecodePointer((void*)<Module>.?A0x373b8c5b.__onexitbegin_m);
			method* ptr2 = (method*)<Module>.DecodePointer((void*)<Module>.?A0x373b8c5b.__onexitend_m);
			if (ptr != -1 && ptr != null && ptr2 != null)
			{
				method* ptr3 = ptr;
				method* ptr4 = ptr2;
				for (;;)
				{
					ptr2 -= 4 / sizeof(method);
					if (ptr2 < ptr)
					{
						break;
					}
					if (*(int*)ptr2 != <Module>.EncodePointer(null))
					{
						void* ptr5 = <Module>.DecodePointer(*(int*)ptr2);
						*(int*)ptr2 = <Module>.EncodePointer(null);
						calli(System.Void(), ptr5);
						method* ptr6 = (method*)<Module>.DecodePointer((void*)<Module>.?A0x373b8c5b.__onexitbegin_m);
						method* ptr7 = (method*)<Module>.DecodePointer((void*)<Module>.?A0x373b8c5b.__onexitend_m);
						if (ptr3 != ptr6 || ptr4 != ptr7)
						{
							ptr3 = ptr6;
							ptr = ptr6;
							ptr4 = ptr7;
							ptr2 = ptr7;
						}
					}
				}
				IntPtr hglobal = new IntPtr((void*)ptr);
				Marshal.FreeHGlobal(hglobal);
			}
			<Module>.?A0x373b8c5b.__dealloc_global_lock();
		}
	}

	// Token: 0x06000039 RID: 57 RVA: 0x0001175C File Offset: 0x00010B5C
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static int _initatexit_m()
	{
		int result = 0;
		if (<Module>.?A0x373b8c5b.__alloc_global_lock() == 1)
		{
			<Module>.?A0x373b8c5b.__onexitbegin_m = (method*)<Module>.EncodePointer(Marshal.AllocHGlobal(128).ToPointer());
			<Module>.?A0x373b8c5b.__onexitend_m = <Module>.?A0x373b8c5b.__onexitbegin_m;
			<Module>.?A0x373b8c5b.__exit_list_size = 32U;
			result = 1;
		}
		return result;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x000117A4 File Offset: 0x00010BA4
	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static int _initatexit_app_domain()
	{
		if (<Module>.?A0x373b8c5b.__alloc_global_lock() == 1)
		{
			<Module>.__onexitbegin_app_domain = (method*)<Module>.EncodePointer(Marshal.AllocHGlobal(128).ToPointer());
			<Module>.__onexitend_app_domain = <Module>.__onexitbegin_app_domain;
			<Module>.__exit_list_size_app_domain = 32U;
		}
		return 1;
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00011620 File Offset: 0x00010A20
	[HandleProcessCorruptedStateExceptions]
	[SecurityCritical]
	internal unsafe static void _app_exit_callback()
	{
		if (<Module>.__exit_list_size_app_domain != 0U)
		{
			method* ptr = (method*)<Module>.DecodePointer((void*)<Module>.__onexitbegin_app_domain);
			method* ptr2 = (method*)<Module>.DecodePointer((void*)<Module>.__onexitend_app_domain);
			try
			{
				if (ptr != -1 && ptr != null && ptr2 != null)
				{
					method* ptr3 = ptr;
					method* ptr4 = ptr2;
					for (;;)
					{
						do
						{
							ptr2 -= 4 / sizeof(method);
						}
						while (ptr2 >= ptr && *(int*)ptr2 == <Module>.EncodePointer(null));
						if (ptr2 < ptr)
						{
							break;
						}
						method system.Void_u0020() = <Module>.DecodePointer(*(int*)ptr2);
						*(int*)ptr2 = <Module>.EncodePointer(null);
						calli(System.Void(), system.Void_u0020());
						method* ptr5 = (method*)<Module>.DecodePointer((void*)<Module>.__onexitbegin_app_domain);
						method* ptr6 = (method*)<Module>.DecodePointer((void*)<Module>.__onexitend_app_domain);
						if (ptr3 != ptr5 || ptr4 != ptr6)
						{
							ptr3 = ptr5;
							ptr = ptr5;
							ptr4 = ptr6;
							ptr2 = ptr6;
						}
					}
				}
			}
			finally
			{
				IntPtr hglobal = new IntPtr((void*)ptr);
				Marshal.FreeHGlobal(hglobal);
				<Module>.?A0x373b8c5b.__dealloc_global_lock();
			}
		}
	}

	// Token: 0x0600003C RID: 60
	[SuppressUnmanagedCodeSecurity]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	[DllImport("KERNEL32.dll")]
	public unsafe static extern void* DecodePointer(void* _Ptr);

	// Token: 0x0600003D RID: 61
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[DllImport("KERNEL32.dll")]
	public unsafe static extern void* EncodePointer(void* _Ptr);

	// Token: 0x0600003E RID: 62 RVA: 0x000117E8 File Offset: 0x00010BE8
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static int _initterm_e(method* pfbegin, method* pfend)
	{
		int num = 0;
		if (pfbegin < pfend)
		{
			while (num == 0)
			{
				uint num2 = (uint)(*(int*)pfbegin);
				if (num2 != 0U)
				{
					num = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvCdecl)(), num2);
				}
				pfbegin += 4 / sizeof(method);
				if (pfbegin >= pfend)
				{
					break;
				}
			}
		}
		return num;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00011818 File Offset: 0x00010C18
	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void _initterm(method* pfbegin, method* pfend)
	{
		if (pfbegin < pfend)
		{
			do
			{
				uint num = (uint)(*(int*)pfbegin);
				if (num != 0U)
				{
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(), num);
				}
				pfbegin += 4 / sizeof(method);
			}
			while (pfbegin < pfend);
		}
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00011840 File Offset: 0x00010C40
	[DebuggerStepThrough]
	internal static ModuleHandle <CrtImplementationDetails>.ThisModule.Handle()
	{
		return typeof(ThisModule).Module.ModuleHandle;
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00011890 File Offset: 0x00010C90
	[DebuggerStepThrough]
	[SecurityCritical]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static void _initterm_m(method* pfbegin, method* pfend)
	{
		if (pfbegin < pfend)
		{
			do
			{
				uint num = (uint)(*(int*)pfbegin);
				if (num != 0U)
				{
					object obj = calli(System.Void modopt(System.Runtime.CompilerServices.IsConst)*(), <Module>.<CrtImplementationDetails>.ThisModule.ResolveMethod<void\u0020const\u0020*\u0020__clrcall(void)>(num));
				}
				pfbegin += 4 / sizeof(method);
			}
			while (pfbegin < pfend);
		}
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00011864 File Offset: 0x00010C64
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static method <CrtImplementationDetails>.ThisModule.ResolveMethod<void\u0020const\u0020*\u0020__clrcall(void)>(method methodToken)
	{
		return <Module>.<CrtImplementationDetails>.ThisModule.Handle().ResolveMethodHandle(methodToken).GetFunctionPointer().ToPointer();
	}

	// Token: 0x06000043 RID: 67 RVA: 0x0001190A File Offset: 0x00010D0A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool GetAntiAFK();

	// Token: 0x06000044 RID: 68 RVA: 0x00011910 File Offset: 0x00010D10
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void SetAntiAFK([MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x06000045 RID: 69 RVA: 0x00011916 File Offset: 0x00010D16
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern AntiDisconnectFlags GetAntiDisconnectFlags();

	// Token: 0x06000046 RID: 70 RVA: 0x0001191C File Offset: 0x00010D1C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void SetAntiDisconnectFlags(AntiDisconnectFlags);

	// Token: 0x06000047 RID: 71 RVA: 0x00011922 File Offset: 0x00010D22
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool GetConsole();

	// Token: 0x06000048 RID: 72 RVA: 0x00011928 File Offset: 0x00010D28
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void SetConsole([MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x06000049 RID: 73 RVA: 0x0001192E File Offset: 0x00010D2E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool GetDisableDrawings();

	// Token: 0x0600004A RID: 74 RVA: 0x00011934 File Offset: 0x00010D34
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void SetDisableDrawings([MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x0600004B RID: 75 RVA: 0x0001193A File Offset: 0x00010D3A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool GetDisablePrints();

	// Token: 0x0600004C RID: 76 RVA: 0x00011940 File Offset: 0x00010D40
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void SetDisablePrints([MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x0600004D RID: 77 RVA: 0x00011946 File Offset: 0x00010D46
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool GetHideDrawingsFromCapture();

	// Token: 0x0600004E RID: 78 RVA: 0x0001194C File Offset: 0x00010D4C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void SetHideDrawingsFromCapture([MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x0600004F RID: 79 RVA: 0x00011952 File Offset: 0x00010D52
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool GetZoomHack();

	// Token: 0x06000050 RID: 80 RVA: 0x00011958 File Offset: 0x00010D58
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void SetZoomHack([MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x06000051 RID: 81 RVA: 0x000119CA File Offset: 0x00010DCA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*)>*, void*);

	// Token: 0x06000052 RID: 82 RVA: 0x00011DB4 File Offset: 0x000111B4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*)>*, void*);

	// Token: 0x06000053 RID: 83 RVA: 0x000119B8 File Offset: 0x00010DB8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,char\u0020const\u0020*,bool\u0020*)>*, void*);

	// Token: 0x06000054 RID: 84 RVA: 0x00011DAE File Offset: 0x000111AE
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,char\u0020const\u0020*,bool\u0020*)>*, void*);

	// Token: 0x06000055 RID: 85 RVA: 0x000119AC File Offset: 0x00010DAC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::StlArray<EnsoulSharp::Native::Vector3f>\u0020*,bool,float)>*, void*);

	// Token: 0x06000056 RID: 86 RVA: 0x00011DA8 File Offset: 0x000111A8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::StlArray<EnsoulSharp::Native::Vector3f>\u0020*,bool,float)>*, void*);

	// Token: 0x06000057 RID: 87 RVA: 0x000119A0 File Offset: 0x00010DA0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::IssuedOrder,EnsoulSharp::Native::Vector3f\u0020*,EnsoulSharp::Native::AttackableUnit\u0020*,bool,bool,bool\u0020*)>*, void*);

	// Token: 0x06000058 RID: 88 RVA: 0x00011DA2 File Offset: 0x000111A2
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::IssuedOrder,EnsoulSharp::Native::Vector3f\u0020*,EnsoulSharp::Native::AttackableUnit\u0020*,bool,bool,bool\u0020*)>*, void*);

	// Token: 0x06000059 RID: 89 RVA: 0x00011994 File Offset: 0x00010D94
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::SpellCastInfo\u0020*)>*, void*);

	// Token: 0x0600005A RID: 90 RVA: 0x00011D9C File Offset: 0x0001119C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::SpellCastInfo\u0020*)>*, void*);

	// Token: 0x0600005B RID: 91 RVA: 0x00011982 File Offset: 0x00010D82
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::BuffInstanceClient\u0020*)>*, void*);

	// Token: 0x0600005C RID: 92 RVA: 0x00011D96 File Offset: 0x00011196
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::BuffInstanceClient\u0020*)>*, void*);

	// Token: 0x0600005D RID: 93 RVA: 0x00011976 File Offset: 0x00010D76
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,unsigned\u0020int)>*, void*);

	// Token: 0x0600005E RID: 94 RVA: 0x00011D90 File Offset: 0x00011190
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,unsigned\u0020int)>*, void*);

	// Token: 0x0600005F RID: 95 RVA: 0x00011A72 File Offset: 0x00010E72
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern UnitInfoComponent* Get(TScrambleWrapper<EnsoulSharp::Native::UnitInfoComponent\u0020*,EnsoulSharp::Native::UnitInfoComponent,unsigned\u0020int,0>*, UnitInfoComponent*);

	// Token: 0x06000060 RID: 96 RVA: 0x00011A5A File Offset: 0x00010E5A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern MovementControllerClient* Get(TScrambleWrapper<EnsoulSharp::Native::MovementControllerClient\u0020*,EnsoulSharp::Native::MovementControllerClient,unsigned\u0020int,0>*, MovementControllerClient*);

	// Token: 0x06000061 RID: 97 RVA: 0x00011B14 File Offset: 0x00010F14
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float Get(TScrambleWrapper<float,float,unsigned\u0020int,0>*, float);

	// Token: 0x06000062 RID: 98 RVA: 0x00012570 File Offset: 0x00011970
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int _stricmp(sbyte*, sbyte*);

	// Token: 0x06000063 RID: 99 RVA: 0x00011D48 File Offset: 0x00011148
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellDataResource** GetDataResource(SpellData*);

	// Token: 0x06000064 RID: 100 RVA: 0x00011A4E File Offset: 0x00010E4E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetTargetFacing(FacingDirection*);

	// Token: 0x06000065 RID: 101 RVA: 0x00011DC0 File Offset: 0x000111C0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlVector<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffInstanceClient>\u0020>* GetSpellBuffs(BuffManager*);

	// Token: 0x06000066 RID: 102 RVA: 0x00011D54 File Offset: 0x00011154
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlAString* {ctor}(StlAString*);

	// Token: 0x06000067 RID: 103 RVA: 0x00011D66 File Offset: 0x00011166
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void {dtor}(StlAString*);

	// Token: 0x06000068 RID: 104 RVA: 0x00011D42 File Offset: 0x00011142
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellDataClient** GetSpellDataClient(SpellDataInstClient*);

	// Token: 0x06000069 RID: 105 RVA: 0x00011AFC File Offset: 0x00010EFC
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsCastObjectWindingUp(Spellbook*);

	// Token: 0x0600006A RID: 106 RVA: 0x00011AA8 File Offset: 0x00010EA8
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ItemInInventory** GetItemInInventory(InventorySlot*);

	// Token: 0x0600006B RID: 107 RVA: 0x00011B56 File Offset: 0x00010F56
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool CanAttack(CharacterState*);

	// Token: 0x0600006C RID: 108 RVA: 0x00011B5C File Offset: 0x00010F5C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool CanCast(CharacterState*);

	// Token: 0x0600006D RID: 109 RVA: 0x00011B62 File Offset: 0x00010F62
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool CanMove(CharacterState*);

	// Token: 0x0600006E RID: 110 RVA: 0x00011B68 File Offset: 0x00010F68
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool CanWalk(CharacterState*);

	// Token: 0x0600006F RID: 111 RVA: 0x00011B6E File Offset: 0x00010F6E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsAsleep(CharacterState*);

	// Token: 0x06000070 RID: 112 RVA: 0x00011B74 File Offset: 0x00010F74
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsCharmed(CharacterState*);

	// Token: 0x06000071 RID: 113 RVA: 0x00011B7A File Offset: 0x00010F7A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsClickproofToEnemies(CharacterState*);

	// Token: 0x06000072 RID: 114 RVA: 0x00011B80 File Offset: 0x00010F80
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsCursorAllowedWhileUntargetable(CharacterState*);

	// Token: 0x06000073 RID: 115 RVA: 0x00011B86 File Offset: 0x00010F86
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsDodgingMissiles(CharacterState*);

	// Token: 0x06000074 RID: 116 RVA: 0x00011B8C File Offset: 0x00010F8C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsFeared(CharacterState*);

	// Token: 0x06000075 RID: 117 RVA: 0x00011B92 File Offset: 0x00010F92
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsFleeing(CharacterState*);

	// Token: 0x06000076 RID: 118 RVA: 0x00011B98 File Offset: 0x00010F98
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsForceRenderParticles(CharacterState*);

	// Token: 0x06000077 RID: 119 RVA: 0x00011B9E File Offset: 0x00010F9E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsGhosted(CharacterState*);

	// Token: 0x06000078 RID: 120 RVA: 0x00011BA4 File Offset: 0x00010FA4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsGhostedForAllies(CharacterState*);

	// Token: 0x06000079 RID: 121 RVA: 0x00011BAA File Offset: 0x00010FAA
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsGrounded(CharacterState*);

	// Token: 0x0600007A RID: 122 RVA: 0x00011BB0 File Offset: 0x00010FB0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsNearSight(CharacterState*);

	// Token: 0x0600007B RID: 123 RVA: 0x00011BB6 File Offset: 0x00010FB6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsNoRender(CharacterState*);

	// Token: 0x0600007C RID: 124 RVA: 0x00011BBC File Offset: 0x00010FBC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsObscured(CharacterState*);

	// Token: 0x0600007D RID: 125 RVA: 0x00011BC2 File Offset: 0x00010FC2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsRevealSpecificUnit(CharacterState*);

	// Token: 0x0600007E RID: 126 RVA: 0x00011BC8 File Offset: 0x00010FC8
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsSelectable(CharacterState*);

	// Token: 0x0600007F RID: 127 RVA: 0x00011BCE File Offset: 0x00010FCE
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsSlowed(CharacterState*);

	// Token: 0x06000080 RID: 128 RVA: 0x00011BD4 File Offset: 0x00010FD4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsStealthed(CharacterState*);

	// Token: 0x06000081 RID: 129 RVA: 0x00011BDA File Offset: 0x00010FDA
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsStunned(CharacterState*);

	// Token: 0x06000082 RID: 130 RVA: 0x00011BE0 File Offset: 0x00010FE0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsSuppressed(CharacterState*);

	// Token: 0x06000083 RID: 131 RVA: 0x00011BE6 File Offset: 0x00010FE6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsTaunted(CharacterState*);

	// Token: 0x06000084 RID: 132 RVA: 0x00011D00 File Offset: 0x00011100
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool CanUseObject(AIBaseCommon*, AttackableUnit*);

	// Token: 0x06000085 RID: 133 RVA: 0x00011A90 File Offset: 0x00010E90
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellData* GetBasicAttack(AIBaseCommon*);

	// Token: 0x06000086 RID: 134 RVA: 0x00011B3E File Offset: 0x00010F3E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetCharacterBaseHealth(AIBaseCommon*);

	// Token: 0x06000087 RID: 135 RVA: 0x00011CFA File Offset: 0x000110FA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void PushCharacterData(AIBaseCommon*, int);

	// Token: 0x06000088 RID: 136 RVA: 0x00011D06 File Offset: 0x00011106
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool UseObject(AIBaseCommon*, AttackableUnit*);

	// Token: 0x06000089 RID: 137 RVA: 0x00011B1A File Offset: 0x00010F1A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TScrambleWrapper<float,float,unsigned\u0020int,0>* GetExpGiveRadius(AIBaseCommon*);

	// Token: 0x0600008A RID: 138 RVA: 0x00011B50 File Offset: 0x00010F50
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern CharacterState* GetCharState(AIBaseCommon*);

	// Token: 0x0600008B RID: 139 RVA: 0x00011BEC File Offset: 0x00010FEC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern CharacterIntermediate* GetCharInter(AIBaseCommon*);

	// Token: 0x0600008C RID: 140 RVA: 0x00011A96 File Offset: 0x00010E96
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlArray<unsigned\u0020int>* GetPetObjectIds(AIBaseCommon*);

	// Token: 0x0600008D RID: 141 RVA: 0x00011B20 File Offset: 0x00010F20
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Gold* GetGold(AIBaseCommon*);

	// Token: 0x0600008E RID: 142 RVA: 0x00011A48 File Offset: 0x00010E48
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern FacingDirection* GetDirection(AIBaseCommon*);

	// Token: 0x0600008F RID: 143 RVA: 0x00011AD8 File Offset: 0x00010ED8
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern CharacterStateIndicatorIndexData* GetCharacterStateIndicatorIndex(AIBaseCommon*);

	// Token: 0x06000090 RID: 144 RVA: 0x00011A9C File Offset: 0x00010E9C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern BaseInventory** GetInventory(AIBaseCommon*);

	// Token: 0x06000091 RID: 145 RVA: 0x00011ACC File Offset: 0x00010ECC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern CombatType* GetCombatType(AIBaseCommon*);

	// Token: 0x06000092 RID: 146 RVA: 0x00011DBA File Offset: 0x000111BA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern BuffManagerClient* GetSpellBuffsClient(AIBaseCommon*);

	// Token: 0x06000093 RID: 147 RVA: 0x00011AF6 File Offset: 0x00010EF6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellbookClient* GetSpellbook(AIBaseCommon*);

	// Token: 0x06000094 RID: 148 RVA: 0x00011A3C File Offset: 0x00010E3C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern CharacterData** GetCharacterData(AIBaseCommon*);

	// Token: 0x06000095 RID: 149 RVA: 0x00011B0E File Offset: 0x00010F0E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TScrambleWrapper<float,float,unsigned\u0020int,0>* GetDeathDuration(AIBaseCommon*);

	// Token: 0x06000096 RID: 150 RVA: 0x00011A54 File Offset: 0x00010E54
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TScrambleWrapper<EnsoulSharp::Native::MovementControllerClient\u0020*,EnsoulSharp::Native::MovementControllerClient,unsigned\u0020int,0>* GetMovementController(AIBaseCommon*);

	// Token: 0x06000097 RID: 151 RVA: 0x00011D0C File Offset: 0x0001110C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern IGameCalculationOwner** GetGameCalculationOwner(AIBaseCommon*);

	// Token: 0x06000098 RID: 152 RVA: 0x00011A36 File Offset: 0x00010E36
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlString* GetCharacterName(AIBaseCommon*);

	// Token: 0x06000099 RID: 153 RVA: 0x00011B26 File Offset: 0x00010F26
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetValue(Gold*);

	// Token: 0x0600009A RID: 154 RVA: 0x00011B2C File Offset: 0x00010F2C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetTotal(Gold*);

	// Token: 0x0600009B RID: 155 RVA: 0x00011D2A File Offset: 0x0001112A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* {ctor}(Vector3f*, float, float, float);

	// Token: 0x0600009C RID: 156 RVA: 0x00011AC6 File Offset: 0x00010EC6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsValid(Vector3f*);

	// Token: 0x0600009D RID: 157 RVA: 0x000119E2 File Offset: 0x00010DE2
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetX(Vector3f*);

	// Token: 0x0600009E RID: 158 RVA: 0x000119EE File Offset: 0x00010DEE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetY(Vector3f*);

	// Token: 0x0600009F RID: 159 RVA: 0x000119E8 File Offset: 0x00010DE8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetZ(Vector3f*);

	// Token: 0x060000A0 RID: 160 RVA: 0x00011D8A File Offset: 0x0001118A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ClassId GetType(GameObject*);

	// Token: 0x060000A1 RID: 161 RVA: 0x00011A2A File Offset: 0x00010E2A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetID(GameObject*);

	// Token: 0x060000A2 RID: 162 RVA: 0x00011A30 File Offset: 0x00010E30
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetNetworkID(GameObject*);

	// Token: 0x060000A3 RID: 163 RVA: 0x00011D24 File Offset: 0x00011124
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetPosition(GameObject*);

	// Token: 0x060000A4 RID: 164 RVA: 0x00011D5A File Offset: 0x0001115A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern IGameCalculationVtbl* GetVftable(IGameCalculation*);

	// Token: 0x060000A5 RID: 165 RVA: 0x00011DD2 File Offset: 0x000111D2
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern sbyte* GetScriptName(ScriptBase*);

	// Token: 0x060000A6 RID: 166 RVA: 0x00011A24 File Offset: 0x00010E24
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellData** GetSData(SpellCastInfo*);

	// Token: 0x060000A7 RID: 167 RVA: 0x00011A1E File Offset: 0x00010E1E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetSpellLevel(SpellCastInfo*);

	// Token: 0x060000A8 RID: 168 RVA: 0x00011A18 File Offset: 0x00010E18
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetMissileNetworkID(SpellCastInfo*);

	// Token: 0x060000A9 RID: 169 RVA: 0x000119FA File Offset: 0x00010DFA
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetSpellCastLaunchPos(SpellCastInfo*);

	// Token: 0x060000AA RID: 170 RVA: 0x000119F4 File Offset: 0x00010DF4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetTargetPosition(SpellCastInfo*);

	// Token: 0x060000AB RID: 171 RVA: 0x000119DC File Offset: 0x00010DDC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetTargetEndPosition(SpellCastInfo*);

	// Token: 0x060000AC RID: 172 RVA: 0x000119D6 File Offset: 0x00010DD6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint** GetTargetObjID(SpellCastInfo*);

	// Token: 0x060000AD RID: 173 RVA: 0x00011A0C File Offset: 0x00010E0C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetDesignerCastTime(SpellCastInfo*);

	// Token: 0x060000AE RID: 174 RVA: 0x00011A12 File Offset: 0x00010E12
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetExtraTimeForCast(SpellCastInfo*);

	// Token: 0x060000AF RID: 175 RVA: 0x00011A06 File Offset: 0x00010E06
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetDesignerTotalTime(SpellCastInfo*);

	// Token: 0x060000B0 RID: 176 RVA: 0x00011A00 File Offset: 0x00010E00
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellSlot* GetSlot(SpellCastInfo*);

	// Token: 0x060000B1 RID: 177 RVA: 0x00011CE2 File Offset: 0x000110E2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetTotalAbilityPower(CharacterIntermediate*);

	// Token: 0x060000B2 RID: 178 RVA: 0x00011CDC File Offset: 0x000110DC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetTotalAttackDamage(CharacterIntermediate*);

	// Token: 0x060000B3 RID: 179 RVA: 0x00011BF2 File Offset: 0x00010FF2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetAbilityHasteMod(CharacterIntermediate*);

	// Token: 0x060000B4 RID: 180 RVA: 0x00011BF8 File Offset: 0x00010FF8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentCooldownMod(CharacterIntermediate*);

	// Token: 0x060000B5 RID: 181 RVA: 0x00011BFE File Offset: 0x00010FFE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetFlatMagicDamageMod(CharacterIntermediate*);

	// Token: 0x060000B6 RID: 182 RVA: 0x00011C04 File Offset: 0x00011004
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentMagicDamageMod(CharacterIntermediate*);

	// Token: 0x060000B7 RID: 183 RVA: 0x00011C0A File Offset: 0x0001100A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetBaseAbilityDamage(CharacterIntermediate*);

	// Token: 0x060000B8 RID: 184 RVA: 0x00011C10 File Offset: 0x00011010
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetFlatPhysicalDamageMod(CharacterIntermediate*);

	// Token: 0x060000B9 RID: 185 RVA: 0x00011C16 File Offset: 0x00011016
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentPhysicalDamageMod(CharacterIntermediate*);

	// Token: 0x060000BA RID: 186 RVA: 0x00011C1C File Offset: 0x0001101C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentBonusPhysicalDamageMod(CharacterIntermediate*);

	// Token: 0x060000BB RID: 187 RVA: 0x00011C22 File Offset: 0x00011022
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentBasePhysicalDamageAsFlatBonusMod(CharacterIntermediate*);

	// Token: 0x060000BC RID: 188 RVA: 0x00011C28 File Offset: 0x00011028
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetBaseAttackDamage(CharacterIntermediate*);

	// Token: 0x060000BD RID: 189 RVA: 0x00011C2E File Offset: 0x0001102E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentLifeStealMod(CharacterIntermediate*);

	// Token: 0x060000BE RID: 190 RVA: 0x00011C34 File Offset: 0x00011034
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentAttackSpeedMod(CharacterIntermediate*);

	// Token: 0x060000BF RID: 191 RVA: 0x00011C3A File Offset: 0x0001103A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetAttackSpeedMod(CharacterIntermediate*);

	// Token: 0x060000C0 RID: 192 RVA: 0x00011C40 File Offset: 0x00011040
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetFlatCritChanceMod(CharacterIntermediate*);

	// Token: 0x060000C1 RID: 193 RVA: 0x00011C46 File Offset: 0x00011046
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetFlatCritDamageMod(CharacterIntermediate*);

	// Token: 0x060000C2 RID: 194 RVA: 0x00011C4C File Offset: 0x0001104C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentCritDamageMod(CharacterIntermediate*);

	// Token: 0x060000C3 RID: 195 RVA: 0x00011C52 File Offset: 0x00011052
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCritDamageMultiplier(CharacterIntermediate*);

	// Token: 0x060000C4 RID: 196 RVA: 0x00011C58 File Offset: 0x00011058
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCrit(CharacterIntermediate*);

	// Token: 0x060000C5 RID: 197 RVA: 0x00011C5E File Offset: 0x0001105E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetArmor(CharacterIntermediate*);

	// Token: 0x060000C6 RID: 198 RVA: 0x00011C64 File Offset: 0x00011064
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetBonusArmor(CharacterIntermediate*);

	// Token: 0x060000C7 RID: 199 RVA: 0x00011C6A File Offset: 0x0001106A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetSpellBlock(CharacterIntermediate*);

	// Token: 0x060000C8 RID: 200 RVA: 0x00011C70 File Offset: 0x00011070
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetBonusSpellBlock(CharacterIntermediate*);

	// Token: 0x060000C9 RID: 201 RVA: 0x00011C76 File Offset: 0x00011076
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetBasePARRegenRate(CharacterIntermediate*);

	// Token: 0x060000CA RID: 202 RVA: 0x00011C7C File Offset: 0x0001107C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPARRegenRate(CharacterIntermediate*);

	// Token: 0x060000CB RID: 203 RVA: 0x00011C82 File Offset: 0x00011082
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetBaseHPRegenRate(CharacterIntermediate*);

	// Token: 0x060000CC RID: 204 RVA: 0x00011C88 File Offset: 0x00011088
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetHPRegenRate(CharacterIntermediate*);

	// Token: 0x060000CD RID: 205 RVA: 0x00011C8E File Offset: 0x0001108E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMoveSpeed(CharacterIntermediate*);

	// Token: 0x060000CE RID: 206 RVA: 0x00011C94 File Offset: 0x00011094
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetAttackRange(CharacterIntermediate*);

	// Token: 0x060000CF RID: 207 RVA: 0x00011C9A File Offset: 0x0001109A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetFlatArmorPenetrationMod(CharacterIntermediate*);

	// Token: 0x060000D0 RID: 208 RVA: 0x00011CA0 File Offset: 0x000110A0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetFlatMagicPenetrationMod(CharacterIntermediate*);

	// Token: 0x060000D1 RID: 209 RVA: 0x00011CA6 File Offset: 0x000110A6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentArmorPenetrationMod(CharacterIntermediate*);

	// Token: 0x060000D2 RID: 210 RVA: 0x00011CAC File Offset: 0x000110AC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentMagicPenetrationMod(CharacterIntermediate*);

	// Token: 0x060000D3 RID: 211 RVA: 0x00011CB2 File Offset: 0x000110B2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentBonusArmorPenetrationMod(CharacterIntermediate*);

	// Token: 0x060000D4 RID: 212 RVA: 0x00011CB8 File Offset: 0x000110B8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentBonusMagicPenetrationMod(CharacterIntermediate*);

	// Token: 0x060000D5 RID: 213 RVA: 0x00011CBE File Offset: 0x000110BE
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPhysicalLethality(CharacterIntermediate*);

	// Token: 0x060000D6 RID: 214 RVA: 0x00011CC4 File Offset: 0x000110C4
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMagicLethality(CharacterIntermediate*);

	// Token: 0x060000D7 RID: 215 RVA: 0x00011CCA File Offset: 0x000110CA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentSpellVampMod(CharacterIntermediate*);

	// Token: 0x060000D8 RID: 216 RVA: 0x00011CD0 File Offset: 0x000110D0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentOmnivampMod(CharacterIntermediate*);

	// Token: 0x060000D9 RID: 217 RVA: 0x00011CD6 File Offset: 0x000110D6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPercentPhysicalVampMod(CharacterIntermediate*);

	// Token: 0x060000DA RID: 218 RVA: 0x00011AD2 File Offset: 0x00010ED2
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetCharacterSkinID(CharacterData*);

	// Token: 0x060000DB RID: 219 RVA: 0x00011CE8 File Offset: 0x000110E8
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern CharacterRecord** GetCharRecord(CharacterData*);

	// Token: 0x060000DC RID: 220 RVA: 0x00011A42 File Offset: 0x00010E42
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlString* GetSkinName(CharacterData*);

	// Token: 0x060000DD RID: 221 RVA: 0x00011AA2 File Offset: 0x00010EA2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern InventorySlot** GetInventory(HeroInventoryCommon*);

	// Token: 0x060000DE RID: 222 RVA: 0x00011A78 File Offset: 0x00010E78
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetDrawBasePosition(UnitInfoComponent*, Vector3f*);

	// Token: 0x060000DF RID: 223 RVA: 0x00011A7E File Offset: 0x00010E7E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector2f* GetHealthBarScreenPosition(UnitInfoComponent*, Vector2f*);

	// Token: 0x060000E0 RID: 224 RVA: 0x00011B32 File Offset: 0x00010F32
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Health* GetHealth(AttackableUnit*);

	// Token: 0x060000E1 RID: 225 RVA: 0x00011CEE File Offset: 0x000110EE
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetBaseHP(CharacterRecord*);

	// Token: 0x060000E2 RID: 226 RVA: 0x00011CF4 File Offset: 0x000110F4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetBaseMoveSpeed(CharacterRecord*);

	// Token: 0x060000E3 RID: 227 RVA: 0x00011D1E File Offset: 0x0001111E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern NavigationPath* {ctor}(NavigationPath*);

	// Token: 0x060000E4 RID: 228 RVA: 0x00011D3C File Offset: 0x0001113C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void {dtor}(NavigationPath*);

	// Token: 0x060000E5 RID: 229 RVA: 0x00011ABA File Offset: 0x00010EBA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetNextWaypointIndex(NavigationPath*);

	// Token: 0x060000E6 RID: 230 RVA: 0x00011AC0 File Offset: 0x00010EC0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlArray<EnsoulSharp::Native::Vector3f>* GetWaypointList(NavigationPath*);

	// Token: 0x060000E7 RID: 231 RVA: 0x00011B02 File Offset: 0x00010F02
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetOverrideable(NavigationPath*);

	// Token: 0x060000E8 RID: 232 RVA: 0x00011B08 File Offset: 0x00010F08
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPathOverrideSpeed(NavigationPath*);

	// Token: 0x060000E9 RID: 233 RVA: 0x00011D6C File Offset: 0x0001116C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetResult(IGameCalculationVtbl*, IGameCalculationOwner*, IGameCalculationDataSource*, SpellSlot, int);

	// Token: 0x060000EA RID: 234 RVA: 0x00011D60 File Offset: 0x00011160
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void GetStringResult(IGameCalculationVtbl*, IGameCalculationOwner*, IGameCalculationDataSource*, SpellSlot, int, CalculationDisplayMode, StlAString*);

	// Token: 0x060000EB RID: 235 RVA: 0x00011B38 File Offset: 0x00010F38
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMax(Health*);

	// Token: 0x060000EC RID: 236 RVA: 0x0001196A File Offset: 0x00010D6A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventAdapter* GetInstance();

	// Token: 0x060000ED RID: 237 RVA: 0x00011970 File Offset: 0x00010D70
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,unsigned\u0020int)>* GetAIBaseClientAggroHandler(EventAdapter*);

	// Token: 0x060000EE RID: 238 RVA: 0x0001197C File Offset: 0x00010D7C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::BuffInstanceClient\u0020*)>* GetAIBaseClientBuffAddHandler(EventAdapter*);

	// Token: 0x060000EF RID: 239 RVA: 0x00011988 File Offset: 0x00010D88
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::BuffInstanceClient\u0020*)>* GetAIBaseClientBuffRemoveHandler(EventAdapter*);

	// Token: 0x060000F0 RID: 240 RVA: 0x0001198E File Offset: 0x00010D8E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::SpellCastInfo\u0020*)>* GetAIBaseClientDoCastHandler(EventAdapter*);

	// Token: 0x060000F1 RID: 241 RVA: 0x0001199A File Offset: 0x00010D9A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::IssuedOrder,EnsoulSharp::Native::Vector3f\u0020*,EnsoulSharp::Native::AttackableUnit\u0020*,bool,bool,bool\u0020*)>* GetAIBaseClientIssueOrderHandler(EventAdapter*);

	// Token: 0x060000F2 RID: 242 RVA: 0x000119A6 File Offset: 0x00010DA6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::StlArray<EnsoulSharp::Native::Vector3f>\u0020*,bool,float)>* GetAIBaseClientNewPathHandler(EventAdapter*);

	// Token: 0x060000F3 RID: 243 RVA: 0x000119B2 File Offset: 0x00010DB2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,char\u0020const\u0020*,bool\u0020*)>* GetAIBaseClientPlayAnimationHandler(EventAdapter*);

	// Token: 0x060000F4 RID: 244 RVA: 0x000119BE File Offset: 0x00010DBE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*,EnsoulSharp::Native::SpellCastInfo\u0020*)>* GetAIBaseClientProcessSpellCastHandler(EventAdapter*);

	// Token: 0x060000F5 RID: 245 RVA: 0x000119C4 File Offset: 0x00010DC4
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*)>* GetAIBaseClientVisibleEnterHandler(EventAdapter*);

	// Token: 0x060000F6 RID: 246 RVA: 0x000119D0 File Offset: 0x00010DD0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIBaseClient\u0020*)>* GetAIBaseClientVisibleLeaveHandler(EventAdapter*);

	// Token: 0x060000F7 RID: 247 RVA: 0x00011A60 File Offset: 0x00010E60
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern PathControllerClient** GetPathController(MovementControllerCommon*);

	// Token: 0x060000F8 RID: 248 RVA: 0x00011B44 File Offset: 0x00010F44
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float ComputeCharacterAttackCastDelay(AIBaseClient*);

	// Token: 0x060000F9 RID: 249 RVA: 0x00011B4A File Offset: 0x00010F4A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float ComputeCharacterAttackDelay(AIBaseClient*);

	// Token: 0x060000FA RID: 250 RVA: 0x00011AEA File Offset: 0x00010EEA
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsHPBarRendered(AIBaseClient*);

	// Token: 0x060000FB RID: 251 RVA: 0x00011AF0 File Offset: 0x00010EF0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsInvulnerableVisual(AIBaseClient*);

	// Token: 0x060000FC RID: 252 RVA: 0x00011D72 File Offset: 0x00011172
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IssueOrder(AIBaseClient*, Vector3f*, AttackableUnit*, IssuedOrder, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x060000FD RID: 253 RVA: 0x00011A6C File Offset: 0x00010E6C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TScrambleWrapper<EnsoulSharp::Native::UnitInfoComponent\u0020*,EnsoulSharp::Native::UnitInfoComponent,unsigned\u0020int,0>* GetUnitInfoComponent(AIBaseClient*);

	// Token: 0x060000FE RID: 254 RVA: 0x00011D84 File Offset: 0x00011184
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlVector<EnsoulSharp::Native::GameObjectContainer::GObjectEntry>* GetObjectArray(GameObjectContainer*);

	// Token: 0x060000FF RID: 255 RVA: 0x00011ADE File Offset: 0x00010EDE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetIndex(CharacterStateIndicatorIndexData*);

	// Token: 0x06000100 RID: 256 RVA: 0x00011AE4 File Offset: 0x00010EE4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetActive(CharacterStateIndicatorIndexData*);

	// Token: 0x06000101 RID: 257 RVA: 0x00011D18 File Offset: 0x00011118
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetAbilityResourceTotal(IGameCalculationOwnerVtbl*, AbilityResourceType, OutputType);

	// Token: 0x06000102 RID: 258 RVA: 0x00011D30 File Offset: 0x00011130
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool CreatePath(PathControllerCommon*, Vector3f*, Vector3f*, NavigationPath*);

	// Token: 0x06000103 RID: 259 RVA: 0x00011D36 File Offset: 0x00011136
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void SmoothPath(PathControllerCommon*, NavigationPath*);

	// Token: 0x06000104 RID: 260 RVA: 0x00011AAE File Offset: 0x00010EAE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetPathActive(PathControllerCommon*);

	// Token: 0x06000105 RID: 261 RVA: 0x00011AB4 File Offset: 0x00010EB4
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern NavigationPath* GetPath(PathControllerCommon*);

	// Token: 0x06000106 RID: 262 RVA: 0x00011A66 File Offset: 0x00010E66
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetPosition(PathControllerCommon*);

	// Token: 0x06000107 RID: 263 RVA: 0x00011D4E File Offset: 0x0001114E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlVectorMap<unsigned\u0020int,EnsoulSharp::Native::StlUniquePtr<EnsoulSharp::Native::IGameCalculation>\u0020>* GetSpellCalculations(SpellDataResource*);

	// Token: 0x06000108 RID: 264 RVA: 0x00011D78 File Offset: 0x00011178
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ObjectManager* GetInstance();

	// Token: 0x06000109 RID: 265 RVA: 0x0001195E File Offset: 0x00010D5E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern GameObject* GetUnitByIndex(uint);

	// Token: 0x0600010A RID: 266 RVA: 0x00011964 File Offset: 0x00010D64
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern GameObject* GetUnitByNetworkId(uint);

	// Token: 0x0600010B RID: 267 RVA: 0x00011D7E File Offset: 0x0001117E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern GameObjectContainer* GetGameObjectContainer(ObjectManager*);

	// Token: 0x0600010C RID: 268 RVA: 0x00011D12 File Offset: 0x00011112
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern IGameCalculationOwnerVtbl* GetVftable(IGameCalculationOwner*);

	// Token: 0x0600010D RID: 269 RVA: 0x00011A84 File Offset: 0x00010E84
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetX(Vector2f*);

	// Token: 0x0600010E RID: 270 RVA: 0x00011A8A File Offset: 0x00010E8A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetY(Vector2f*);

	// Token: 0x0600010F RID: 271 RVA: 0x00011DD8 File Offset: 0x000111D8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int GetCount(BuffInstance*);

	// Token: 0x06000110 RID: 272 RVA: 0x00011DC6 File Offset: 0x000111C6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsActive(BuffInstance*);

	// Token: 0x06000111 RID: 273 RVA: 0x00011DDE File Offset: 0x000111DE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern BuffType* GetType(BuffInstance*);

	// Token: 0x06000112 RID: 274 RVA: 0x00011DCC File Offset: 0x000111CC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ScriptBaseBuff** GetScript(BuffInstance*);

	// Token: 0x06000113 RID: 275 RVA: 0x00011DEA File Offset: 0x000111EA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIHeroClient\u0020*,int)>*, void*);

	// Token: 0x06000114 RID: 276 RVA: 0x00011E62 File Offset: 0x00011262
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIHeroClient\u0020*,int)>*, void*);

	// Token: 0x06000115 RID: 277 RVA: 0x00011DF6 File Offset: 0x000111F6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetEvolvePoints(EvolutionState*);

	// Token: 0x06000116 RID: 278 RVA: 0x00011E56 File Offset: 0x00011256
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern BuyItemResult BuyItem(HeroInventoryCommon*, int);

	// Token: 0x06000117 RID: 279 RVA: 0x00011E6E File Offset: 0x0001126E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern AvatarCommon* GetAvatarCommon(AvatarClient*);

	// Token: 0x06000118 RID: 280 RVA: 0x00011E74 File Offset: 0x00011274
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlVector<EnsoulSharp::Native::BasePerkInfo>* GetPerkInfos(AvatarCommon*);

	// Token: 0x06000119 RID: 281 RVA: 0x00011E20 File Offset: 0x00011220
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HeroStatsCollection* GetStats(AIHeroClient*);

	// Token: 0x0600011A RID: 282 RVA: 0x00011E14 File Offset: 0x00011214
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float ExpToCurrentLevel(Experience*);

	// Token: 0x0600011B RID: 283 RVA: 0x00011E1A File Offset: 0x0001121A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float ExpToNextLevel(Experience*);

	// Token: 0x0600011C RID: 284 RVA: 0x00011E0E File Offset: 0x0001120E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetExp(Experience*);

	// Token: 0x0600011D RID: 285 RVA: 0x00011E08 File Offset: 0x00011208
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetLevel(Experience*);

	// Token: 0x0600011E RID: 286 RVA: 0x00011E02 File Offset: 0x00011202
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetSpellTrainingPoints(Experience*);

	// Token: 0x0600011F RID: 287 RVA: 0x00011DE4 File Offset: 0x000111E4
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIHeroClient\u0020*,int)>* GetAIHeroClientLevelUpHandler(EventAdapter*);

	// Token: 0x06000120 RID: 288 RVA: 0x00011E2C File Offset: 0x0001122C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetValue(HeroStatIntRounded*);

	// Token: 0x06000121 RID: 289 RVA: 0x00011E5C File Offset: 0x0001125C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void RemoveItemClient(HeroInventoryClient*, int);

	// Token: 0x06000122 RID: 290 RVA: 0x00011DF0 File Offset: 0x000111F0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EvolutionState* GetEvolution(AIHero*);

	// Token: 0x06000123 RID: 291 RVA: 0x00011DFC File Offset: 0x000111FC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Experience* GetExperience(AIHero*);

	// Token: 0x06000124 RID: 292 RVA: 0x00011E50 File Offset: 0x00011250
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HeroInventoryClient* GetHeroInventory(AIHero*);

	// Token: 0x06000125 RID: 293 RVA: 0x00011E68 File Offset: 0x00011268
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern AvatarClient* GetAvatar(AIHero*);

	// Token: 0x06000126 RID: 294 RVA: 0x00011E26 File Offset: 0x00011226
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HeroStatIntRounded* GetMinionsKilled(HeroStatsCollection*);

	// Token: 0x06000127 RID: 295 RVA: 0x00011E32 File Offset: 0x00011232
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HeroStatIntRounded* GetNeutralMinionsKilled(HeroStatsCollection*);

	// Token: 0x06000128 RID: 296 RVA: 0x00011E38 File Offset: 0x00011238
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HeroStatInt* GetNumChampionKills(HeroStatsCollection*);

	// Token: 0x06000129 RID: 297 RVA: 0x00011E44 File Offset: 0x00011244
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HeroStatInt* GetNumDeaths(HeroStatsCollection*);

	// Token: 0x0600012A RID: 298 RVA: 0x00011E4A File Offset: 0x0001124A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HeroStatInt* GetNumAssists(HeroStatsCollection*);

	// Token: 0x0600012B RID: 299 RVA: 0x00011E86 File Offset: 0x00011286
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetPerkId(BasePerk*);

	// Token: 0x0600012C RID: 300 RVA: 0x00011E80 File Offset: 0x00011280
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern sbyte** GetPerkName(BasePerk*);

	// Token: 0x0600012D RID: 301 RVA: 0x00011E7A File Offset: 0x0001127A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Perk** GetPerk(BasePerkInfo*);

	// Token: 0x0600012E RID: 302 RVA: 0x00011E3E File Offset: 0x0001123E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetValue(HeroStatInt*);

	// Token: 0x0600012F RID: 303 RVA: 0x00011E92 File Offset: 0x00011292
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AttackableUnit\u0020*,EnsoulSharp::Native::StlString\u0020*,EnsoulSharp::Native::StlString\u0020*)>*, void*);

	// Token: 0x06000130 RID: 304 RVA: 0x00011F28 File Offset: 0x00011328
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AttackableUnit\u0020*,EnsoulSharp::Native::StlString\u0020*,EnsoulSharp::Native::StlString\u0020*)>*, void*);

	// Token: 0x06000131 RID: 305 RVA: 0x00011E9E File Offset: 0x0001129E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int Get(TScrambleWrapper<int,int,unsigned\u0020int,0>*, int);

	// Token: 0x06000132 RID: 306 RVA: 0x00011F1C File Offset: 0x0001131C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Glow(AttackableUnit*, uint, int, int);

	// Token: 0x06000133 RID: 307 RVA: 0x00011EB0 File Offset: 0x000112B0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsInvulnerable(AttackableUnit*);

	// Token: 0x06000134 RID: 308 RVA: 0x00011EB6 File Offset: 0x000112B6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsTargetable(AttackableUnit*);

	// Token: 0x06000135 RID: 309 RVA: 0x00011F22 File Offset: 0x00011322
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsTargetableToTeam(AttackableUnit*, TeamId);

	// Token: 0x06000136 RID: 310 RVA: 0x00011EBC File Offset: 0x000112BC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern NetVisibilityObjectClient* GetNetVisibility(AttackableUnit*);

	// Token: 0x06000137 RID: 311 RVA: 0x00011EC8 File Offset: 0x000112C8
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TScrambleWrapper<float,float,unsigned\u0020int,0>* GetTimeOfDeath(AttackableUnit*);

	// Token: 0x06000138 RID: 312 RVA: 0x00011EE6 File Offset: 0x000112E6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern AbilityResource* GetAbilityResources(AttackableUnit*);

	// Token: 0x06000139 RID: 313 RVA: 0x00011E98 File Offset: 0x00011298
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TScrambleWrapper<int,int,unsigned\u0020int,0>* GetIsPhysicalImmune(AttackableUnit*);

	// Token: 0x0600013A RID: 314 RVA: 0x00011EA4 File Offset: 0x000112A4
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TScrambleWrapper<int,int,unsigned\u0020int,0>* GetIsMagicImmune(AttackableUnit*);

	// Token: 0x0600013B RID: 315 RVA: 0x00011EAA File Offset: 0x000112AA
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TScrambleWrapper<int,int,unsigned\u0020int,0>* GetIsLifestealImmune(AttackableUnit*);

	// Token: 0x0600013C RID: 316 RVA: 0x00011F0A File Offset: 0x0001130A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlString* GetArmorMaterial(AttackableUnit*);

	// Token: 0x0600013D RID: 317 RVA: 0x00011F10 File Offset: 0x00011310
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlString* GetWeaponMaterial(AttackableUnit*);

	// Token: 0x0600013E RID: 318 RVA: 0x00011F16 File Offset: 0x00011316
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlWeakPtr<EnsoulSharp::Native::GameObject\u0020*>* GetGoldRedirectTarget(AttackableUnit*);

	// Token: 0x0600013F RID: 319 RVA: 0x00011ED4 File Offset: 0x000112D4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetOverrideCollisionRadius(AttackableUnit*);

	// Token: 0x06000140 RID: 320 RVA: 0x00011ECE File Offset: 0x000112CE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetOverrideCollisionHeight(AttackableUnit*);

	// Token: 0x06000141 RID: 321 RVA: 0x00011EDA File Offset: 0x000112DA
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPathfindingCollisionRadius(AttackableUnit*);

	// Token: 0x06000142 RID: 322 RVA: 0x00011EE0 File Offset: 0x000112E0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCurrent(Health*);

	// Token: 0x06000143 RID: 323 RVA: 0x00011EF8 File Offset: 0x000112F8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetAllShield(Health*);

	// Token: 0x06000144 RID: 324 RVA: 0x00011EFE File Offset: 0x000112FE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPhysicalShield(Health*);

	// Token: 0x06000145 RID: 325 RVA: 0x00011F04 File Offset: 0x00011304
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMagicalShield(Health*);

	// Token: 0x06000146 RID: 326 RVA: 0x00011EEC File Offset: 0x000112EC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCurrent(AbilityResource*);

	// Token: 0x06000147 RID: 327 RVA: 0x00011EF2 File Offset: 0x000112F2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMax(AbilityResource*);

	// Token: 0x06000148 RID: 328 RVA: 0x00011E8C File Offset: 0x0001128C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AttackableUnit\u0020*,EnsoulSharp::Native::StlString\u0020*,EnsoulSharp::Native::StlString\u0020*)>* GetAttackableUnitTeleportHandler(EventAdapter*);

	// Token: 0x06000149 RID: 329 RVA: 0x00011EC2 File Offset: 0x000112C2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetVisible(NetVisibilityObjectClient*);

	// Token: 0x0600014A RID: 330 RVA: 0x00011F52 File Offset: 0x00011352
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern GameObject* GetCaster(BuffScriptInstance*);

	// Token: 0x0600014B RID: 331 RVA: 0x00011F4C File Offset: 0x0001134C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlArray<EnsoulSharp::Native::StlSharedPtr<EnsoulSharp::Native::BuffScriptInstance>\u0020>* GetStack(BuffScriptInstanceStack*);

	// Token: 0x0600014C RID: 332 RVA: 0x00011F34 File Offset: 0x00011334
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsPositive(BuffInstance*);

	// Token: 0x0600014D RID: 333 RVA: 0x00011F3A File Offset: 0x0001133A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetStartTime(BuffInstance*);

	// Token: 0x0600014E RID: 334 RVA: 0x00011F2E File Offset: 0x0001132E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetEndTime(BuffInstance*);

	// Token: 0x0600014F RID: 335 RVA: 0x00011F46 File Offset: 0x00011346
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern BuffScriptInstanceStack* GetStack(BuffInstance*);

	// Token: 0x06000150 RID: 336 RVA: 0x00011F40 File Offset: 0x00011340
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetToolTipVars(BuffInstance*);

	// Token: 0x06000151 RID: 337 RVA: 0x00011F58 File Offset: 0x00011358
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern IconSlotInfo* GetSoulSlotIconInfo(UIMetricMultiDragonKillsSRX*);

	// Token: 0x06000152 RID: 338 RVA: 0x00011F5E File Offset: 0x0001135E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlArray<EnsoulSharp::Native::IconSlotInfo>* GetTeamSlotsIconInfo(UIMetricMultiDragonKillsSRX*);

	// Token: 0x06000153 RID: 339 RVA: 0x00011F64 File Offset: 0x00011364
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetIconId(IconSlotInfo*);

	// Token: 0x06000154 RID: 340 RVA: 0x00011F6A File Offset: 0x0001136A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TeamId* GetIconTeam(IconSlotInfo*);

	// Token: 0x06000155 RID: 341 RVA: 0x00011F70 File Offset: 0x00011370
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetIsIconSoul(IconSlotInfo*);

	// Token: 0x06000156 RID: 342 RVA: 0x00011F7C File Offset: 0x0001137C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(void)>*, void*);

	// Token: 0x06000157 RID: 343 RVA: 0x00012066 File Offset: 0x00011466
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(void)>*, void*);

	// Token: 0x06000158 RID: 344 RVA: 0x00012042 File Offset: 0x00011442
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TacticalMap* GetInstance();

	// Token: 0x06000159 RID: 345 RVA: 0x0001205A File Offset: 0x0001145A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool ToMapCoord(TacticalMap*, Vector3f*, float*, float*);

	// Token: 0x0600015A RID: 346 RVA: 0x0001204E File Offset: 0x0001144E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void ToWorldCoord(TacticalMap*, float, float, Vector3f*);

	// Token: 0x0600015B RID: 347 RVA: 0x00011FD0 File Offset: 0x000113D0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern DX9Device* GetInstance();

	// Token: 0x0600015C RID: 348 RVA: 0x00011FD6 File Offset: 0x000113D6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern IDirect3DDevice9** GetDevice(DX9Device*);

	// Token: 0x0600015D RID: 349 RVA: 0x00012048 File Offset: 0x00011448
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* {ctor}(Vector3f*);

	// Token: 0x0600015E RID: 350 RVA: 0x00012024 File Offset: 0x00011424
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void DrawCircle(float, float, float, float, float, int, [MarshalAs(UnmanagedType.U1)] bool, [MarshalAs(UnmanagedType.U1)] bool, uint);

	// Token: 0x0600015F RID: 351 RVA: 0x0001201E File Offset: 0x0001141E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void DrawCircle(float, float, float, float, float, [MarshalAs(UnmanagedType.U1)] bool, uint);

	// Token: 0x06000160 RID: 352 RVA: 0x00012030 File Offset: 0x00011430
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void DrawLine(float, float, float, float, float, uint);

	// Token: 0x06000161 RID: 353 RVA: 0x00012036 File Offset: 0x00011436
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void DrawText(float, float, char*, uint);

	// Token: 0x06000162 RID: 354 RVA: 0x0001203C File Offset: 0x0001143C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern tagSIZE MeasureText(char*);

	// Token: 0x06000163 RID: 355 RVA: 0x00011FFA File Offset: 0x000113FA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern IDXGISwapChain** GetSwapChain(WindowSwapChain*);

	// Token: 0x06000164 RID: 356 RVA: 0x00011FC4 File Offset: 0x000113C4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern r3dRenderLayer* GetInstance();

	// Token: 0x06000165 RID: 357 RVA: 0x0001202A File Offset: 0x0001142A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void DrawCircularRangeIndicator(Vector3f*, float, uint);

	// Token: 0x06000166 RID: 358 RVA: 0x00012006 File Offset: 0x00011406
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern _D3DMATRIX* GetCamera(r3dRenderLayer*, _D3DMATRIX*);

	// Token: 0x06000167 RID: 359 RVA: 0x00012000 File Offset: 0x00011400
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern _D3DMATRIX* GetProj(r3dRenderLayer*, _D3DMATRIX*);

	// Token: 0x06000168 RID: 360 RVA: 0x00012060 File Offset: 0x00011460
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool r3dProjectToScreen(Vector3f*, Vector3f*);

	// Token: 0x06000169 RID: 361 RVA: 0x00012054 File Offset: 0x00011454
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool ScreenToWorld(float, float, Vector3f*);

	// Token: 0x0600016A RID: 362 RVA: 0x00011FCA File Offset: 0x000113CA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern X3DPlatform* GetPlatform(r3dRenderLayer*);

	// Token: 0x0600016B RID: 363 RVA: 0x0001200C File Offset: 0x0001140C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern X3DPresentParams* Getr3dpp(r3dRenderLayer*);

	// Token: 0x0600016C RID: 364 RVA: 0x00011FDC File Offset: 0x000113DC
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern DX11Device* GetInstance();

	// Token: 0x0600016D RID: 365 RVA: 0x00011FE2 File Offset: 0x000113E2
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ID3D11Device** GetDevice(DX11Device*);

	// Token: 0x0600016E RID: 366 RVA: 0x00011FF4 File Offset: 0x000113F4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern WindowSwapChain* GetDefaultWindowSwapChain(DX11Device*);

	// Token: 0x0600016F RID: 367 RVA: 0x00011FE8 File Offset: 0x000113E8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern PerThreadState* GetMainThreadState(DX11Device*);

	// Token: 0x06000170 RID: 368 RVA: 0x00012012 File Offset: 0x00011412
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetBackBufferWidth(X3DPresentParams*);

	// Token: 0x06000171 RID: 369 RVA: 0x00012018 File Offset: 0x00011418
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetBackBufferHeight(X3DPresentParams*);

	// Token: 0x06000172 RID: 370 RVA: 0x00011F76 File Offset: 0x00011376
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingDrawHandler(EventAdapter*);

	// Token: 0x06000173 RID: 371 RVA: 0x00011F82 File Offset: 0x00011382
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingBeginSceneHandler(EventAdapter*);

	// Token: 0x06000174 RID: 372 RVA: 0x00011F88 File Offset: 0x00011388
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingEndSceneHandler(EventAdapter*);

	// Token: 0x06000175 RID: 373 RVA: 0x00011F8E File Offset: 0x0001138E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingFlushDrawHandler(EventAdapter*);

	// Token: 0x06000176 RID: 374 RVA: 0x00011F94 File Offset: 0x00011394
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingFlushEndSceneHandler(EventAdapter*);

	// Token: 0x06000177 RID: 375 RVA: 0x00011F9A File Offset: 0x0001139A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingPreResetHandler(EventAdapter*);

	// Token: 0x06000178 RID: 376 RVA: 0x00011FA0 File Offset: 0x000113A0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingPostResetHandler(EventAdapter*);

	// Token: 0x06000179 RID: 377 RVA: 0x00011FA6 File Offset: 0x000113A6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingPresentHandler(EventAdapter*);

	// Token: 0x0600017A RID: 378 RVA: 0x00011FAC File Offset: 0x000113AC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingRenderMouseOversHandler(EventAdapter*);

	// Token: 0x0600017B RID: 379 RVA: 0x00011FB2 File Offset: 0x000113B2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingD3D11PresentHandler(EventAdapter*);

	// Token: 0x0600017C RID: 380 RVA: 0x00011FB8 File Offset: 0x000113B8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingD3D11PreResizeBuffersHandler(EventAdapter*);

	// Token: 0x0600017D RID: 381 RVA: 0x00011FBE File Offset: 0x000113BE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetDrawingD3D11PostResizeBuffersHandler(EventAdapter*);

	// Token: 0x0600017E RID: 382 RVA: 0x00011FEE File Offset: 0x000113EE
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ID3D11DeviceContext** GetDeviceContext(PerThreadState*);

	// Token: 0x0600017F RID: 383 RVA: 0x00012072 File Offset: 0x00011472
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern _D3DMATRIX* GetOrientation(InstanceProxy*);

	// Token: 0x06000180 RID: 384 RVA: 0x00012078 File Offset: 0x00011478
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetRestartTime(InstanceProxy*);

	// Token: 0x06000181 RID: 385 RVA: 0x0001206C File Offset: 0x0001146C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern InstanceProxy** GetFXParticleEmitter(EffectEmitter*);

	// Token: 0x06000182 RID: 386 RVA: 0x000120B4 File Offset: 0x000114B4
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(HWND__\u0020*,unsigned\u0020int,unsigned\u0020int,long,bool\u0020*)>*, void*);

	// Token: 0x06000183 RID: 387 RVA: 0x000121C8 File Offset: 0x000115C8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(HWND__\u0020*,unsigned\u0020int,unsigned\u0020int,long,bool\u0020*)>*, void*);

	// Token: 0x06000184 RID: 388 RVA: 0x000120A8 File Offset: 0x000114A8
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(char\u0020const\u0020*,bool,bool\u0020*)>*, void*);

	// Token: 0x06000185 RID: 389 RVA: 0x000121C2 File Offset: 0x000115C2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(char\u0020const\u0020*,bool,bool\u0020*)>*, void*);

	// Token: 0x06000186 RID: 390 RVA: 0x0001209C File Offset: 0x0001149C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(char\u0020const\u0020*,unsigned\u0020int,bool\u0020*)>*, void*);

	// Token: 0x06000187 RID: 391 RVA: 0x000121BC File Offset: 0x000115BC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(char\u0020const\u0020*,unsigned\u0020int,bool\u0020*)>*, void*);

	// Token: 0x06000188 RID: 392 RVA: 0x00012090 File Offset: 0x00011490
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::DefaultPacket\u0020*,bool\u0020*)>*, void*);

	// Token: 0x06000189 RID: 393 RVA: 0x000121B6 File Offset: 0x000115B6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::DefaultPacket\u0020*,bool\u0020*)>*, void*);

	// Token: 0x0600018A RID: 394 RVA: 0x00012084 File Offset: 0x00011484
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(enum\u0020EnsoulSharp::Native::Enums::EventsNames,EnsoulSharp::Native::BaseParams\u0020*)>*, void*);

	// Token: 0x0600018B RID: 395 RVA: 0x000121B0 File Offset: 0x000115B0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(enum\u0020EnsoulSharp::Native::Enums::EventsNames,EnsoulSharp::Native::BaseParams\u0020*)>*, void*);

	// Token: 0x0600018C RID: 396 RVA: 0x000120EA File Offset: 0x000114EA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Zoom* GetInstance();

	// Token: 0x0600018D RID: 397 RVA: 0x000120F0 File Offset: 0x000114F0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetDesired(Zoom*);

	// Token: 0x0600018E RID: 398 RVA: 0x000121AA File Offset: 0x000115AA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsInFoW(Vector3f*);

	// Token: 0x0600018F RID: 399 RVA: 0x000120C6 File Offset: 0x000114C6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Serializable* GetSerialize(DefaultPacket*);

	// Token: 0x06000190 RID: 400 RVA: 0x000120D8 File Offset: 0x000114D8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern DefaultPacketHeader* GetHeader(DefaultPacket*);

	// Token: 0x06000191 RID: 401 RVA: 0x0001214A File Offset: 0x0001154A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HudCursorTargetLogic* GetInstance();

	// Token: 0x06000192 RID: 402 RVA: 0x00012150 File Offset: 0x00011550
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetCursorTargetPosRaw(HudCursorTargetLogic*);

	// Token: 0x06000193 RID: 403 RVA: 0x00012108 File Offset: 0x00011508
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern FramerateInformation* GetInstance();

	// Token: 0x06000194 RID: 404 RVA: 0x0001210E File Offset: 0x0001150E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern double GetMovingAverageFps(FramerateInformation*);

	// Token: 0x06000195 RID: 405 RVA: 0x000120C0 File Offset: 0x000114C0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetOtherNetworkID(BaseParams*);

	// Token: 0x06000196 RID: 406 RVA: 0x00012120 File Offset: 0x00011520
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern FrameClockFacade* GetInstance();

	// Token: 0x06000197 RID: 407 RVA: 0x00012126 File Offset: 0x00011526
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetFrameStartTimeSecs(FrameClockFacade*);

	// Token: 0x06000198 RID: 408 RVA: 0x0001213E File Offset: 0x0001153E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern GameClient* GetInstance();

	// Token: 0x06000199 RID: 409 RVA: 0x00012144 File Offset: 0x00011544
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern GameState* GetCurrentGameState(GameClient*);

	// Token: 0x0600019A RID: 410 RVA: 0x0001219E File Offset: 0x0001159E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EmoteRadialViewController* GetInstance();

	// Token: 0x0600019B RID: 411 RVA: 0x000121A4 File Offset: 0x000115A4
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void FireEventForSlot(EmoteRadialViewController*, SummonerEmoteSlot);

	// Token: 0x0600019C RID: 412 RVA: 0x000120D2 File Offset: 0x000114D2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint GetEstimatedSize(SerializableVtbl*);

	// Token: 0x0600019D RID: 413 RVA: 0x00012156 File Offset: 0x00011556
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern sbyte* GetBuildVersion();

	// Token: 0x0600019E RID: 414 RVA: 0x000120CC File Offset: 0x000114CC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SerializableVtbl* GetVftable(Serializable*);

	// Token: 0x0600019F RID: 415 RVA: 0x00012186 File Offset: 0x00011586
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SmartPingClientManager* GetInstance();

	// Token: 0x060001A0 RID: 416 RVA: 0x0001218C File Offset: 0x0001158C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void CallCurrentPing(SmartPingClientManager*, Vector2f*, uint, PingCategory);

	// Token: 0x060001A1 RID: 417 RVA: 0x00012132 File Offset: 0x00011532
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern GameSessionInfo* GetInstance();

	// Token: 0x060001A2 RID: 418 RVA: 0x00012138 File Offset: 0x00011538
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern MapId* GetMapID(GameSessionInfo*);

	// Token: 0x060001A3 RID: 419 RVA: 0x0001207E File Offset: 0x0001147E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(enum\u0020EnsoulSharp::Native::Enums::EventsNames,EnsoulSharp::Native::BaseParams\u0020*)>* GetGameNotifyHandler(EventAdapter*);

	// Token: 0x060001A4 RID: 420 RVA: 0x0001208A File Offset: 0x0001148A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::DefaultPacket\u0020*,bool\u0020*)>* GetGameProcessPacketHandler(EventAdapter*);

	// Token: 0x060001A5 RID: 421 RVA: 0x00012096 File Offset: 0x00011496
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(char\u0020const\u0020*,unsigned\u0020int,bool\u0020*)>* GetGameDisplayChatHandler(EventAdapter*);

	// Token: 0x060001A6 RID: 422 RVA: 0x000120A2 File Offset: 0x000114A2
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(char\u0020const\u0020*,bool,bool\u0020*)>* GetGameSendChatHandler(EventAdapter*);

	// Token: 0x060001A7 RID: 423 RVA: 0x000120AE File Offset: 0x000114AE
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(HWND__\u0020*,unsigned\u0020int,unsigned\u0020int,long,bool\u0020*)>* GetGameWndProcHandler(EventAdapter*);

	// Token: 0x060001A8 RID: 424 RVA: 0x000120BA File Offset: 0x000114BA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(void)>* GetGameUpdateHandler(EventAdapter*);

	// Token: 0x060001A9 RID: 425 RVA: 0x000120F6 File Offset: 0x000114F6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern CameraConfig* GetInstance();

	// Token: 0x060001AA RID: 426 RVA: 0x000120FC File Offset: 0x000114FC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetZoomMinDistance(CameraConfig*);

	// Token: 0x060001AB RID: 427 RVA: 0x00012102 File Offset: 0x00011502
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetZoomMaxDistance(CameraConfig*);

	// Token: 0x060001AC RID: 428 RVA: 0x0001215C File Offset: 0x0001155C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ChatViewController* GetInstance();

	// Token: 0x060001AD RID: 429 RVA: 0x00012162 File Offset: 0x00011562
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void DisplayChat(ChatViewController*, sbyte*, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x060001AE RID: 430 RVA: 0x000120E4 File Offset: 0x000114E4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ushort* GetEventID(DefaultPacketHeader*);

	// Token: 0x060001AF RID: 431 RVA: 0x000120DE File Offset: 0x000114DE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetFromID(DefaultPacketHeader*);

	// Token: 0x060001B0 RID: 432 RVA: 0x0001212C File Offset: 0x0001152C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HWND__* GetMainWndHandle();

	// Token: 0x060001B1 RID: 433 RVA: 0x00012174 File Offset: 0x00011574
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern MenuGUI* GetInstance();

	// Token: 0x060001B2 RID: 434 RVA: 0x00012192 File Offset: 0x00011592
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool DoDisplayChampMasteryBadge(MenuGUI*);

	// Token: 0x060001B3 RID: 435 RVA: 0x00012198 File Offset: 0x00011598
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool DoEmote(MenuGUI*, EmoteId);

	// Token: 0x060001B4 RID: 436 RVA: 0x00012180 File Offset: 0x00011580
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void PingMiniMap(MenuGUI*, Vector2f*, uint, uint, PingCategory, [MarshalAs(UnmanagedType.U1)] bool, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x060001B5 RID: 437 RVA: 0x0001216E File Offset: 0x0001156E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern AIHeroClient* GetPlayer();

	// Token: 0x060001B6 RID: 438 RVA: 0x0001217A File Offset: 0x0001157A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector2f* {ctor}(Vector2f*, float, float);

	// Token: 0x060001B7 RID: 439 RVA: 0x00012114 File Offset: 0x00011514
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern MultiplayerClient* GetInstance();

	// Token: 0x060001B8 RID: 440 RVA: 0x0001211A File Offset: 0x0001151A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint CurrentRoundTripTimeMS(MultiplayerClient*);

	// Token: 0x060001B9 RID: 441 RVA: 0x00012168 File Offset: 0x00011568
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool SendChat(MultiplayerClient*, sbyte*, [MarshalAs(UnmanagedType.U1)] bool, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x060001BA RID: 442 RVA: 0x000121F2 File Offset: 0x000115F2
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*,char\u0020const\u0020*,int,int)>*, void*);

	// Token: 0x060001BB RID: 443 RVA: 0x0001224C File Offset: 0x0001164C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*,char\u0020const\u0020*,int,int)>*, void*);

	// Token: 0x060001BC RID: 444 RVA: 0x000121E6 File Offset: 0x000115E6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*,char\u0020const\u0020*,float,float)>*, void*);

	// Token: 0x060001BD RID: 445 RVA: 0x00012246 File Offset: 0x00011646
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*,char\u0020const\u0020*,float,float)>*, void*);

	// Token: 0x060001BE RID: 446 RVA: 0x000121D4 File Offset: 0x000115D4
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*)>*, void*);

	// Token: 0x060001BF RID: 447 RVA: 0x00012240 File Offset: 0x00011640
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*)>*, void*);

	// Token: 0x060001C0 RID: 448 RVA: 0x00012234 File Offset: 0x00011634
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Get(TScrambleWrapper<bool,bool,unsigned\u0020int,0>*, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x060001C1 RID: 449 RVA: 0x00012210 File Offset: 0x00011610
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void SetName(GameObject*, sbyte*);

	// Token: 0x060001C2 RID: 450 RVA: 0x00012222 File Offset: 0x00011622
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern GameObjectVtbl* GetVftable(GameObject*);

	// Token: 0x060001C3 RID: 451 RVA: 0x0001221C File Offset: 0x0001161C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TeamId* GetTeamID(GameObject*);

	// Token: 0x060001C4 RID: 452 RVA: 0x0001220A File Offset: 0x0001160A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlString* GetName(GameObject*);

	// Token: 0x060001C5 RID: 453 RVA: 0x000121F8 File Offset: 0x000115F8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Box* GetBoundingBox(GameObject*);

	// Token: 0x060001C6 RID: 454 RVA: 0x0001223A File Offset: 0x0001163A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TScrambleWrapper<bool,bool,unsigned\u0020int,0>* GetIsVisibleOnScreen(GameObject*);

	// Token: 0x060001C7 RID: 455 RVA: 0x00012216 File Offset: 0x00011616
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetPreviousPosition(GameObject*);

	// Token: 0x060001C8 RID: 456 RVA: 0x0001222E File Offset: 0x0001162E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TScrambleWrapper<bool,bool,unsigned\u0020int,0>* GetDead(GameObject*);

	// Token: 0x060001C9 RID: 457 RVA: 0x00012204 File Offset: 0x00011604
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetMin(Box*);

	// Token: 0x060001CA RID: 458 RVA: 0x000121FE File Offset: 0x000115FE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetMax(Box*);

	// Token: 0x060001CB RID: 459 RVA: 0x000121CE File Offset: 0x000115CE
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*)>* GetGameObjectCreateHandler(EventAdapter*);

	// Token: 0x060001CC RID: 460 RVA: 0x000121DA File Offset: 0x000115DA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*)>* GetGameObjectDeleteHandler(EventAdapter*);

	// Token: 0x060001CD RID: 461 RVA: 0x000121E0 File Offset: 0x000115E0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*,char\u0020const\u0020*,float,float)>* GetGameObjectFloatPropertyChangeHandler(EventAdapter*);

	// Token: 0x060001CE RID: 462 RVA: 0x000121EC File Offset: 0x000115EC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::GameObject\u0020*,char\u0020const\u0020*,int,int)>* GetGameObjectIntegerPropertyChangeHandler(EventAdapter*);

	// Token: 0x060001CF RID: 463 RVA: 0x00012228 File Offset: 0x00011628
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetBoundingRadius(GameObjectVtbl*);

	// Token: 0x060001D0 RID: 464 RVA: 0x0001229A File Offset: 0x0001169A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ClientCameraPositionClient* GetInstance();

	// Token: 0x060001D1 RID: 465 RVA: 0x000122A0 File Offset: 0x000116A0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void SetLockedInternal(ClientCameraPositionClient*, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x060001D2 RID: 466 RVA: 0x00012252 File Offset: 0x00011652
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ScoreboardViewController* GetInstance();

	// Token: 0x060001D3 RID: 467 RVA: 0x00012258 File Offset: 0x00011658
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlUniquePtr<EnsoulSharp::Native::ScoreboardTeamScoresDefinitions>* GetTeamScoresDefinitions(ScoreboardViewController*);

	// Token: 0x060001D4 RID: 468 RVA: 0x000122A6 File Offset: 0x000116A6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void UpdateGroundAttackMode(HudCursorTargetLogic*, ClickType, Vector3f*);

	// Token: 0x060001D5 RID: 469 RVA: 0x0001228E File Offset: 0x0001168E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HudUnitStats* GetInstance();

	// Token: 0x060001D6 RID: 470 RVA: 0x00012294 File Offset: 0x00011694
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void OnPing(HudUnitStats*, uint, uint);

	// Token: 0x060001D7 RID: 471 RVA: 0x00012264 File Offset: 0x00011664
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HudSpellLogic* GetInstance();

	// Token: 0x060001D8 RID: 472 RVA: 0x00012288 File Offset: 0x00011688
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void HandleSpellPingClick(HudSpellLogic*, AIHero*, SpellSlot);

	// Token: 0x060001D9 RID: 473 RVA: 0x0001226A File Offset: 0x0001166A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellDataClient** GetSpell(HudSpellLogic*);

	// Token: 0x060001DA RID: 474 RVA: 0x0001227C File Offset: 0x0001167C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HudPlayerResourceBars* GetInstance();

	// Token: 0x060001DB RID: 475 RVA: 0x00012282 File Offset: 0x00011682
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void OnPing(HudPlayerResourceBars*, PingResourceType);

	// Token: 0x060001DC RID: 476 RVA: 0x00012270 File Offset: 0x00011670
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HudSelectLogic* GetInstance();

	// Token: 0x060001DD RID: 477 RVA: 0x00012276 File Offset: 0x00011676
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetTargetChampionsOnly(HudSelectLogic*);

	// Token: 0x060001DE RID: 478 RVA: 0x0001225E File Offset: 0x0001165E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern UIMetricMultiDragonKillsSRX* GetDragonTracker(ScoreboardTeamScoresDefinitions*);

	// Token: 0x060001DF RID: 479 RVA: 0x000122B8 File Offset: 0x000116B8
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern byte* GetCountInSlot(InventorySlot*);

	// Token: 0x060001E0 RID: 480 RVA: 0x000122BE File Offset: 0x000116BE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetPurchaseTime(InventorySlot*);

	// Token: 0x060001E1 RID: 481 RVA: 0x000122AC File Offset: 0x000116AC
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ItemData** GetItemData(ItemInInventory*);

	// Token: 0x060001E2 RID: 482 RVA: 0x000122C4 File Offset: 0x000116C4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ushort* GetSpellCharges(ItemInInventory*);

	// Token: 0x060001E3 RID: 483 RVA: 0x000122CA File Offset: 0x000116CA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetInvestedGoldAmount(ItemInInventory*);

	// Token: 0x060001E4 RID: 484 RVA: 0x000122B2 File Offset: 0x000116B2
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetItemID(ItemData*);

	// Token: 0x060001E5 RID: 485 RVA: 0x00012306 File Offset: 0x00011706
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ItemManager* GetInstance();

	// Token: 0x060001E6 RID: 486 RVA: 0x0001230C File Offset: 0x0001170C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern ItemData* Get(ItemManager*, uint);

	// Token: 0x060001E7 RID: 487 RVA: 0x00012312 File Offset: 0x00011712
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlVector<EnsoulSharp::Native::ItemData\u0020*>* GetAllItemData(ItemManager*);

	// Token: 0x060001E8 RID: 488 RVA: 0x000122FA File Offset: 0x000116FA
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern sbyte* Translate(sbyte*);

	// Token: 0x060001E9 RID: 489 RVA: 0x000122D0 File Offset: 0x000116D0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetRequiredLevel(ItemData*);

	// Token: 0x060001EA RID: 490 RVA: 0x000122D6 File Offset: 0x000116D6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetMaxStack(ItemData*);

	// Token: 0x060001EB RID: 491 RVA: 0x000122DC File Offset: 0x000116DC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetPrice(ItemData*);

	// Token: 0x060001EC RID: 492 RVA: 0x000122E2 File Offset: 0x000116E2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetUsableInStore(ItemData*);

	// Token: 0x060001ED RID: 493 RVA: 0x000122E8 File Offset: 0x000116E8
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetCanBeSold(ItemData*);

	// Token: 0x060001EE RID: 494 RVA: 0x000122EE File Offset: 0x000116EE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetSellBackModifier(ItemData*);

	// Token: 0x060001EF RID: 495 RVA: 0x000122F4 File Offset: 0x000116F4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern sbyte** GetDisplayName(ItemData*);

	// Token: 0x060001F0 RID: 496 RVA: 0x00012300 File Offset: 0x00011700
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern sbyte** GetSpellName(ItemData*);

	// Token: 0x060001F1 RID: 497 RVA: 0x0001232A File Offset: 0x0001172A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetIsShown(ScoreboardViewController*);

	// Token: 0x060001F2 RID: 498 RVA: 0x00012330 File Offset: 0x00011730
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetShopIsOpen(HeroInventoryCommon*);

	// Token: 0x060001F3 RID: 499 RVA: 0x0001231E File Offset: 0x0001171E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetTextRegionEnabled(HudTextEdit*);

	// Token: 0x060001F4 RID: 500 RVA: 0x00012318 File Offset: 0x00011718
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern HudTextEdit* GetTextEdit(ChatViewController*);

	// Token: 0x060001F5 RID: 501 RVA: 0x00012324 File Offset: 0x00011724
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetIsActivated(ChatViewController*);

	// Token: 0x060001F6 RID: 502 RVA: 0x0001233C File Offset: 0x0001173C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::MissileClient\u0020*,int\u0020*,int\u0020*)>*, void*);

	// Token: 0x060001F7 RID: 503 RVA: 0x00012384 File Offset: 0x00011784
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::MissileClient\u0020*,int\u0020*,int\u0020*)>*, void*);

	// Token: 0x060001F8 RID: 504 RVA: 0x00012348 File Offset: 0x00011748
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetCasterObjID(SpellCastInfo*);

	// Token: 0x060001F9 RID: 505 RVA: 0x00012354 File Offset: 0x00011754
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetMovementStartPosition(MissileMovement*);

	// Token: 0x060001FA RID: 506 RVA: 0x0001235A File Offset: 0x0001175A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetTargetPosition(MissileMovement*);

	// Token: 0x060001FB RID: 507 RVA: 0x00012366 File Offset: 0x00011766
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetSpeed(MissileMovement*);

	// Token: 0x060001FC RID: 508 RVA: 0x00012372 File Offset: 0x00011772
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetIsComplete(MissileMovement*);

	// Token: 0x060001FD RID: 509 RVA: 0x00012336 File Offset: 0x00011736
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::MissileClient\u0020*,int\u0020*,int\u0020*)>* GetMissileClientCommitMovementHandler(EventAdapter*);

	// Token: 0x060001FE RID: 510 RVA: 0x0001237E File Offset: 0x0001177E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsVisible(Missile*);

	// Token: 0x060001FF RID: 511 RVA: 0x00012342 File Offset: 0x00011742
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellCastInfo* GetCastInfo(Missile*);

	// Token: 0x06000200 RID: 512 RVA: 0x0001234E File Offset: 0x0001174E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern MissileMovement** GetMovement(Missile*);

	// Token: 0x06000201 RID: 513 RVA: 0x00012360 File Offset: 0x00011760
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetStartTime(Missile*);

	// Token: 0x06000202 RID: 514 RVA: 0x0001236C File Offset: 0x0001176C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetWidth(Missile*);

	// Token: 0x06000203 RID: 515 RVA: 0x00012378 File Offset: 0x00011778
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetDestroyed(Missile*);

	// Token: 0x06000204 RID: 516 RVA: 0x0001238A File Offset: 0x0001178A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern CollisionFlags GetCollisionFlags(float, float);

	// Token: 0x06000205 RID: 517 RVA: 0x00012390 File Offset: 0x00011790
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void SetCollisionFlags(float, float, CollisionFlags);

	// Token: 0x06000206 RID: 518 RVA: 0x00012396 File Offset: 0x00011796
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern NavGrid* GetInstance();

	// Token: 0x06000207 RID: 519 RVA: 0x000123AE File Offset: 0x000117AE
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetHeightForValidPosition(NavGrid*, float, float);

	// Token: 0x06000208 RID: 520 RVA: 0x0001239C File Offset: 0x0001179C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsWallOfType(NavGrid*, float, float, CollisionFlags, float);

	// Token: 0x06000209 RID: 521 RVA: 0x000123A2 File Offset: 0x000117A2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* CellToWorld(NavGrid*, Vector3f*, int, int);

	// Token: 0x0600020A RID: 522 RVA: 0x000123A8 File Offset: 0x000117A8
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector2f* WorldToCell(NavGrid*, Vector2f*, float, float);

	// Token: 0x0600020B RID: 523 RVA: 0x000123B4 File Offset: 0x000117B4
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsWater(NavGrid*, int, int);

	// Token: 0x0600020C RID: 524 RVA: 0x000123C6 File Offset: 0x000117C6
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetTimerExpiry(NeutralMinionCampCommon*);

	// Token: 0x0600020D RID: 525 RVA: 0x000123D2 File Offset: 0x000117D2
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlVector<unsigned\u0020int>* GetOrderRewards(NeutralMinionCampCommon*);

	// Token: 0x0600020E RID: 526 RVA: 0x000123CC File Offset: 0x000117CC
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlVector<unsigned\u0020int>* GetChaosRewards(NeutralMinionCampCommon*);

	// Token: 0x0600020F RID: 527 RVA: 0x000123C0 File Offset: 0x000117C0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TeamId* GetSoulTeamOwner(NeutralMinionCampCommon*);

	// Token: 0x06000210 RID: 528 RVA: 0x000123BA File Offset: 0x000117BA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern uint* GetSoulName(NeutralMinionCampCommon*);

	// Token: 0x06000211 RID: 529 RVA: 0x000123F6 File Offset: 0x000117F6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::SpellSlot,EnsoulSharp::Native::Vector3f\u0020*,bool,bool\u0020*)>*, void*);

	// Token: 0x06000212 RID: 530 RVA: 0x00012480 File Offset: 0x00011880
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::SpellSlot,EnsoulSharp::Native::Vector3f\u0020*,bool,bool\u0020*)>*, void*);

	// Token: 0x06000213 RID: 531 RVA: 0x000123EA File Offset: 0x000117EA
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,bool,bool,bool\u0020*,bool,unsigned\u0020int,unsigned\u0020int)>*, void*);

	// Token: 0x06000214 RID: 532 RVA: 0x0001247A File Offset: 0x0001187A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,bool,bool,bool\u0020*,bool,unsigned\u0020int,unsigned\u0020int)>*, void*);

	// Token: 0x06000215 RID: 533 RVA: 0x000123DE File Offset: 0x000117DE
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Remove(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::SpellSlot,EnsoulSharp::Native::Vector3f\u0020*,EnsoulSharp::Native::Vector3f\u0020*,unsigned\u0020int,bool\u0020*)>*, void*);

	// Token: 0x06000216 RID: 534 RVA: 0x00012474 File Offset: 0x00011874
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void Add(EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::SpellSlot,EnsoulSharp::Native::Vector3f\u0020*,EnsoulSharp::Native::Vector3f\u0020*,unsigned\u0020int,bool\u0020*)>*, void*);

	// Token: 0x06000217 RID: 535 RVA: 0x000123FC File Offset: 0x000117FC
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern AIBaseClient* GetOwner(Spellbook*);

	// Token: 0x06000218 RID: 536 RVA: 0x00012408 File Offset: 0x00011808
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellInstance** GetSpellcastingObject(Spellbook*);

	// Token: 0x06000219 RID: 537 RVA: 0x00012420 File Offset: 0x00011820
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetIsCastingSpell(Spellbook*);

	// Token: 0x0600021A RID: 538 RVA: 0x000123D8 File Offset: 0x000117D8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::SpellSlot,EnsoulSharp::Native::Vector3f\u0020*,EnsoulSharp::Native::Vector3f\u0020*,unsigned\u0020int,bool\u0020*)>* GetSpellbookCastSpellHandler(EventAdapter*);

	// Token: 0x0600021B RID: 539 RVA: 0x000123E4 File Offset: 0x000117E4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,bool,bool,bool\u0020*,bool,unsigned\u0020int,unsigned\u0020int)>* GetSpellbookStopCastHandler(EventAdapter*);

	// Token: 0x0600021C RID: 540 RVA: 0x000123F0 File Offset: 0x000117F0
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::SpellSlot,EnsoulSharp::Native::Vector3f\u0020*,bool,bool\u0020*)>* GetSpellbookUpdateChargedSpellHandler(EventAdapter*);

	// Token: 0x0600021D RID: 541 RVA: 0x0001243E File Offset: 0x0001183E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool SpellWasCast(SpellInstance*);

	// Token: 0x0600021E RID: 542 RVA: 0x00012426 File Offset: 0x00011826
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsAutoAttack(SpellInstance*);

	// Token: 0x0600021F RID: 543 RVA: 0x0001242C File Offset: 0x0001182C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsChanneling(SpellInstance*);

	// Token: 0x06000220 RID: 544 RVA: 0x00012432 File Offset: 0x00011832
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsCharging(SpellInstance*);

	// Token: 0x06000221 RID: 545 RVA: 0x00012438 File Offset: 0x00011838
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool IsStopped(SpellInstance*);

	// Token: 0x06000222 RID: 546 RVA: 0x00012414 File Offset: 0x00011814
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetSpellCastTime(SpellInstance*);

	// Token: 0x06000223 RID: 547 RVA: 0x0001241A File Offset: 0x0001181A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float GetSpellEndTime(SpellInstance*);

	// Token: 0x06000224 RID: 548 RVA: 0x0001240E File Offset: 0x0001180E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellCastInfo* GetCastInfo(SpellInstance*);

	// Token: 0x06000225 RID: 549 RVA: 0x0001246E File Offset: 0x0001186E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellUseFlags CanUseSpell(SpellbookClient*, SpellSlot);

	// Token: 0x06000226 RID: 550 RVA: 0x00012450 File Offset: 0x00011850
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool CastSpell(SpellbookClient*, SpellSlot, Vector3f, Vector3f, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x06000227 RID: 551 RVA: 0x00012456 File Offset: 0x00011856
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool CastSpell(SpellbookClient*, SpellSlot, Vector3f, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x06000228 RID: 552 RVA: 0x0001244A File Offset: 0x0001184A
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool CastSpell(SpellbookClient*, SpellSlot, GameObject*, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x06000229 RID: 553 RVA: 0x00012444 File Offset: 0x00011844
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool CastSpell(SpellbookClient*, SpellSlot, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x0600022A RID: 554 RVA: 0x00012462 File Offset: 0x00011862
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void EvolveSpell(SpellbookClient*, SpellSlot);

	// Token: 0x0600022B RID: 555 RVA: 0x0001245C File Offset: 0x0001185C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool UpdateChargedSpell(SpellbookClient*, SpellSlot, Vector3f, [MarshalAs(UnmanagedType.U1)] bool, [MarshalAs(UnmanagedType.U1)] bool);

	// Token: 0x0600022C RID: 556 RVA: 0x00012468 File Offset: 0x00011868
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void UpgradeSpell(SpellbookClient*, SpellSlot);

	// Token: 0x0600022D RID: 557 RVA: 0x00012402 File Offset: 0x00011802
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellDataInstClient** GetSpellsDataClient(SpellbookClient*);

	// Token: 0x0600022E RID: 558 RVA: 0x00012486 File Offset: 0x00011886
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern StlString* GetName(SpellData*);

	// Token: 0x0600022F RID: 559 RVA: 0x000124EC File Offset: 0x000118EC
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern TargetingType GetTargetingType(SpellDataResource*);

	// Token: 0x06000230 RID: 560 RVA: 0x000124A4 File Offset: 0x000118A4
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCooldownTime(SpellDataResource*);

	// Token: 0x06000231 RID: 561 RVA: 0x0001249E File Offset: 0x0001189E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetUseMinimapTargeting(SpellDataResource*);

	// Token: 0x06000232 RID: 562 RVA: 0x00012498 File Offset: 0x00011898
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetUseChargeChanneling(SpellDataResource*);

	// Token: 0x06000233 RID: 563 RVA: 0x0001248C File Offset: 0x0001188C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetCanMoveWhileChanneling(SpellDataResource*);

	// Token: 0x06000234 RID: 564 RVA: 0x00012492 File Offset: 0x00011892
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetIsToggleSpell(SpellDataResource*);

	// Token: 0x06000235 RID: 565 RVA: 0x000124AA File Offset: 0x000118AA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCastRange(SpellDataResource*);

	// Token: 0x06000236 RID: 566 RVA: 0x000124B0 File Offset: 0x000118B0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCastRangeDisplayOverride(SpellDataResource*);

	// Token: 0x06000237 RID: 567 RVA: 0x000124B6 File Offset: 0x000118B6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCastRadius(SpellDataResource*);

	// Token: 0x06000238 RID: 568 RVA: 0x000124BC File Offset: 0x000118BC
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCastRadiusSecondary(SpellDataResource*);

	// Token: 0x06000239 RID: 569 RVA: 0x000124C2 File Offset: 0x000118C2
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCastConeAngle(SpellDataResource*);

	// Token: 0x0600023A RID: 570 RVA: 0x000124C8 File Offset: 0x000118C8
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCastConeDistance(SpellDataResource*);

	// Token: 0x0600023B RID: 571 RVA: 0x000124D4 File Offset: 0x000118D4
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern CastType* GetCastType(SpellDataResource*);

	// Token: 0x0600023C RID: 572 RVA: 0x000124CE File Offset: 0x000118CE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCastFrame(SpellDataResource*);

	// Token: 0x0600023D RID: 573 RVA: 0x000124DA File Offset: 0x000118DA
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMissileSpeed(SpellDataResource*);

	// Token: 0x0600023E RID: 574 RVA: 0x000124E0 File Offset: 0x000118E0
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetLineWidth(SpellDataResource*);

	// Token: 0x0600023F RID: 575 RVA: 0x000124E6 File Offset: 0x000118E6
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetLineDragLength(SpellDataResource*);

	// Token: 0x06000240 RID: 576 RVA: 0x000124F2 File Offset: 0x000118F2
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMana(SpellDataResource*);

	// Token: 0x06000241 RID: 577 RVA: 0x00012510 File Offset: 0x00011910
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetNumericalDisplayActive(SpellVisualData*);

	// Token: 0x06000242 RID: 578 RVA: 0x00012516 File Offset: 0x00011916
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetCurrentNumericalDisplay(SpellVisualData*);

	// Token: 0x06000243 RID: 579 RVA: 0x000124F8 File Offset: 0x000118F8
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetLevel(SpellDataInst*);

	// Token: 0x06000244 RID: 580 RVA: 0x000124FE File Offset: 0x000118FE
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern bool* GetLearned(SpellDataInst*);

	// Token: 0x06000245 RID: 581 RVA: 0x00012504 File Offset: 0x00011904
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetCooldownExpires(SpellDataInst*);

	// Token: 0x06000246 RID: 582 RVA: 0x0001250A File Offset: 0x0001190A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellVisualData* GetVisualData(SpellDataInst*);

	// Token: 0x06000247 RID: 583 RVA: 0x0001251C File Offset: 0x0001191C
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int* GetCurrentAmmo(SpellDataInst*);

	// Token: 0x06000248 RID: 584 RVA: 0x00012522 File Offset: 0x00011922
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetTimeForNextAmmoRecharge(SpellDataInst*);

	// Token: 0x06000249 RID: 585 RVA: 0x00012528 File Offset: 0x00011928
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetTotalAmmoRechargeTime(SpellDataInst*);

	// Token: 0x0600024A RID: 586 RVA: 0x0001252E File Offset: 0x0001192E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern SpellToggleState* GetToggleState(SpellDataInst*);

	// Token: 0x0600024B RID: 587 RVA: 0x00012534 File Offset: 0x00011934
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetTotalCooldown(SpellDataInst*);

	// Token: 0x0600024C RID: 588 RVA: 0x0001253A File Offset: 0x0001193A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetToolTipVars(SpellDataInst*);

	// Token: 0x0600024D RID: 589 RVA: 0x00012540 File Offset: 0x00011940
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern sbyte* GetIconUsed(SpellDataInst*);

	// Token: 0x0600024E RID: 590 RVA: 0x00012552 File Offset: 0x00011952
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMapTopLeftX(TacticalMap*);

	// Token: 0x0600024F RID: 591 RVA: 0x0001254C File Offset: 0x0001194C
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMapTopLeftY(TacticalMap*);

	// Token: 0x06000250 RID: 592 RVA: 0x0001255E File Offset: 0x0001195E
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMapWidth(TacticalMap*);

	// Token: 0x06000251 RID: 593 RVA: 0x00012558 File Offset: 0x00011958
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern float* GetMapHeight(TacticalMap*);

	// Token: 0x06000252 RID: 594 RVA: 0x00012546 File Offset: 0x00011946
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern Vector3f* GetCenterWorldPos(TacticalMap*);

	// Token: 0x06000253 RID: 595 RVA: 0x00010C60 File Offset: 0x00010060
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void* _getFiberPtrId();

	// Token: 0x06000254 RID: 596 RVA: 0x000118FE File Offset: 0x00010CFE
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void _cexit();

	// Token: 0x06000255 RID: 597 RVA: 0x00012564 File Offset: 0x00011964
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void Sleep(uint);

	// Token: 0x06000256 RID: 598 RVA: 0x00012576 File Offset: 0x00011976
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void abort();

	// Token: 0x06000257 RID: 599 RVA: 0x0000FF2E File Offset: 0x0000F32E
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal static extern void __security_init_cookie();

	// Token: 0x06000258 RID: 600 RVA: 0x0001256A File Offset: 0x0001196A
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int __FrameUnwindFilter(_EXCEPTION_POINTERS*);

	// Token: 0x04000001 RID: 1 RVA: 0x00013984 File Offset: 0x00012384
	internal static __s_GUID _GUID_cb2f6723_ab3a_11d2_9c40_00c04fa30a3e;

	// Token: 0x04000002 RID: 2
	[FixedAddressValueType]
	internal static Progress ?InitializedPerProcess@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A;

	// Token: 0x04000003 RID: 3 RVA: 0x00013900 File Offset: 0x00012300
	internal static method ?InitializedPerProcess$initializer$@CurrentDomain@<CrtImplementationDetails>@@$$Q2P6MXXZA;

	// Token: 0x04000004 RID: 4 RVA: 0x00013974 File Offset: 0x00012374
	internal static __s_GUID _GUID_cb2f6722_ab3a_11d2_9c40_00c04fa30a3e;

	// Token: 0x04000005 RID: 5 RVA: 0x00013994 File Offset: 0x00012394
	internal static __s_GUID _GUID_90f1a06c_7712_4762_86b5_7a5eba6bdb02;

	// Token: 0x04000006 RID: 6 RVA: 0x000139A4 File Offset: 0x000123A4
	internal static __s_GUID _GUID_90f1a06e_7712_4762_86b5_7a5eba6bdb02;

	// Token: 0x04000007 RID: 7
	[FixedAddressValueType]
	internal static int ?Uninitialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA;

	// Token: 0x04000008 RID: 8
	[FixedAddressValueType]
	internal static Progress ?InitializedPerAppDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A;

	// Token: 0x04000009 RID: 9 RVA: 0x000433A0 File Offset: 0x000419A0
	internal static bool ?Entered@DefaultDomain@<CrtImplementationDetails>@@2_NA;

	// Token: 0x0400000A RID: 10 RVA: 0x00043020 File Offset: 0x00041620
	internal static TriBool ?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A;

	// Token: 0x0400000B RID: 11 RVA: 0x000433A3 File Offset: 0x000419A3
	internal static bool ?InitializedPerProcess@DefaultDomain@<CrtImplementationDetails>@@2_NA;

	// Token: 0x0400000C RID: 12 RVA: 0x0004339C File Offset: 0x0004199C
	internal static int ?Count@AllDomains@<CrtImplementationDetails>@@2HA;

	// Token: 0x0400000D RID: 13
	[FixedAddressValueType]
	internal static int ?Initialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA;

	// Token: 0x0400000E RID: 14
	[FixedAddressValueType]
	internal static Progress ?InitializedNative@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A;

	// Token: 0x0400000F RID: 15 RVA: 0x000433A2 File Offset: 0x000419A2
	internal static bool ?InitializedNativeFromCCTOR@DefaultDomain@<CrtImplementationDetails>@@2_NA;

	// Token: 0x04000010 RID: 16
	[FixedAddressValueType]
	internal static bool ?IsDefaultDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2_NA;

	// Token: 0x04000011 RID: 17
	[FixedAddressValueType]
	internal static Progress ?InitializedVtables@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A;

	// Token: 0x04000012 RID: 18 RVA: 0x000433A1 File Offset: 0x000419A1
	internal static bool ?InitializedNative@DefaultDomain@<CrtImplementationDetails>@@2_NA;

	// Token: 0x04000013 RID: 19 RVA: 0x0004301C File Offset: 0x0004161C
	internal static TriBool ?hasPerProcess@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A;

	// Token: 0x04000014 RID: 20 RVA: 0x00013910 File Offset: 0x00012310
	internal static $ArrayType$$$BY00Q6MPBXXZ __xc_mp_z;

	// Token: 0x04000015 RID: 21 RVA: 0x00013918 File Offset: 0x00012318
	internal static $ArrayType$$$BY00Q6MPBXXZ __xi_vt_z;

	// Token: 0x04000016 RID: 22 RVA: 0x000138F4 File Offset: 0x000122F4
	internal static method ?IsDefaultDomain$initializer$@CurrentDomain@<CrtImplementationDetails>@@$$Q2P6MXXZA;

	// Token: 0x04000017 RID: 23 RVA: 0x000138E8 File Offset: 0x000122E8
	internal static $ArrayType$$$BY00Q6MPBXXZ __xc_ma_a;

	// Token: 0x04000018 RID: 24 RVA: 0x00013908 File Offset: 0x00012308
	internal static $ArrayType$$$BY00Q6MPBXXZ __xc_ma_z;

	// Token: 0x04000019 RID: 25 RVA: 0x000138EC File Offset: 0x000122EC
	internal static method ?Initialized$initializer$@CurrentDomain@<CrtImplementationDetails>@@$$Q2P6MXXZA;

	// Token: 0x0400001A RID: 26 RVA: 0x00013904 File Offset: 0x00012304
	internal static method ?InitializedPerAppDomain$initializer$@CurrentDomain@<CrtImplementationDetails>@@$$Q2P6MXXZA;

	// Token: 0x0400001B RID: 27 RVA: 0x00013914 File Offset: 0x00012314
	internal static $ArrayType$$$BY00Q6MPBXXZ __xi_vt_a;

	// Token: 0x0400001C RID: 28 RVA: 0x000138FC File Offset: 0x000122FC
	internal static method ?InitializedNative$initializer$@CurrentDomain@<CrtImplementationDetails>@@$$Q2P6MXXZA;

	// Token: 0x0400001D RID: 29 RVA: 0x0001390C File Offset: 0x0001230C
	internal static $ArrayType$$$BY00Q6MPBXXZ __xc_mp_a;

	// Token: 0x0400001E RID: 30 RVA: 0x000138F8 File Offset: 0x000122F8
	internal static method ?InitializedVtables$initializer$@CurrentDomain@<CrtImplementationDetails>@@$$Q2P6MXXZA;

	// Token: 0x0400001F RID: 31 RVA: 0x000138F0 File Offset: 0x000122F0
	internal static method ?Uninitialized$initializer$@CurrentDomain@<CrtImplementationDetails>@@$$Q2P6MXXZA;

	// Token: 0x04000020 RID: 32 RVA: 0x000139B4 File Offset: 0x000123B4
	public unsafe static int** __unep@?DoNothing@DefaultDomain@<CrtImplementationDetails>@@$$FCGJPAX@Z;

	// Token: 0x04000021 RID: 33 RVA: 0x000139B8 File Offset: 0x000123B8
	public unsafe static int** __unep@?_UninitializeDefaultDomain@LanguageSupport@<CrtImplementationDetails>@@$$FCGJPAX@Z;

	// Token: 0x04000022 RID: 34 RVA: 0x000434D0 File Offset: 0x00041AD0
	internal unsafe static method* __onexitbegin_m;

	// Token: 0x04000023 RID: 35 RVA: 0x000434CC File Offset: 0x00041ACC
	internal static uint __exit_list_size;

	// Token: 0x04000024 RID: 36
	[FixedAddressValueType]
	internal unsafe static method* __onexitend_app_domain;

	// Token: 0x04000025 RID: 37
	[FixedAddressValueType]
	internal unsafe static void* ?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PAXA;

	// Token: 0x04000026 RID: 38
	[FixedAddressValueType]
	internal static int ?_ref_count@AtExitLock@<CrtImplementationDetails>@@$$Q0HA;

	// Token: 0x04000027 RID: 39 RVA: 0x000434D4 File Offset: 0x00041AD4
	internal unsafe static method* __onexitend_m;

	// Token: 0x04000028 RID: 40
	[FixedAddressValueType]
	internal static uint __exit_list_size_app_domain;

	// Token: 0x04000029 RID: 41
	[FixedAddressValueType]
	internal unsafe static method* __onexitbegin_app_domain;

	// Token: 0x0400002A RID: 42 RVA: 0x000138D4 File Offset: 0x000122D4
	internal static $ArrayType$$$BY0A@P6AHXZ __xi_z;

	// Token: 0x0400002B RID: 43 RVA: 0x00043050 File Offset: 0x00041650
	internal static __scrt_native_startup_state __scrt_current_native_startup_state;

	// Token: 0x0400002C RID: 44 RVA: 0x00043054 File Offset: 0x00041654
	internal unsafe static void* __scrt_native_startup_lock;

	// Token: 0x0400002D RID: 45 RVA: 0x000138C8 File Offset: 0x000122C8
	internal static $ArrayType$$$BY0A@P6AXXZ __xc_a;

	// Token: 0x0400002E RID: 46 RVA: 0x000138D0 File Offset: 0x000122D0
	internal static $ArrayType$$$BY0A@P6AHXZ __xi_a;

	// Token: 0x0400002F RID: 47 RVA: 0x00043004 File Offset: 0x00041604
	internal static uint __scrt_native_dllmain_reason;

	// Token: 0x04000030 RID: 48 RVA: 0x000138CC File Offset: 0x000122CC
	internal static $ArrayType$$$BY0A@P6AXXZ __xc_z;
}
