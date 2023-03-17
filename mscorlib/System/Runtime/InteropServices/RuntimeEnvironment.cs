using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace System.Runtime.InteropServices
{
	/// <summary>Provides a collection of <see langword="static" /> methods that return information about the common language runtime environment.</summary>
	// Token: 0x02000927 RID: 2343
	[ComVisible(true)]
	public class RuntimeEnvironment
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.RuntimeEnvironment" /> class.</summary>
		// Token: 0x06006094 RID: 24724 RVA: 0x00149A60 File Offset: 0x00147C60
		[Obsolete("Do not create instances of the RuntimeEnvironment class.  Call the static methods directly on this type instead", true)]
		public RuntimeEnvironment()
		{
		}

		// Token: 0x06006095 RID: 24725
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string GetModuleFileName();

		// Token: 0x06006096 RID: 24726
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string GetDeveloperPath();

		// Token: 0x06006097 RID: 24727
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string GetHostBindingFile();

		// Token: 0x06006098 RID: 24728
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void _GetSystemVersion(StringHandleOnStack retVer);

		/// <summary>Tests whether the specified assembly is loaded in the global assembly cache.</summary>
		/// <param name="a">The assembly to test.</param>
		/// <returns>
		///   <see langword="true" /> if the assembly is loaded in the global assembly cache; otherwise, <see langword="false" />.</returns>
		// Token: 0x06006099 RID: 24729 RVA: 0x00149A68 File Offset: 0x00147C68
		public static bool FromGlobalAccessCache(Assembly a)
		{
			return a.GlobalAssemblyCache;
		}

		/// <summary>Gets the version number of the common language runtime that is running the current process.</summary>
		/// <returns>A string containing the version number of the common language runtime.</returns>
		// Token: 0x0600609A RID: 24730 RVA: 0x00149A70 File Offset: 0x00147C70
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetSystemVersion()
		{
			string result = null;
			RuntimeEnvironment._GetSystemVersion(JitHelpers.GetStringHandleOnStack(ref result));
			return result;
		}

		/// <summary>Returns the directory where the common language runtime is installed.</summary>
		/// <returns>A string that contains the path to the directory where the common language runtime is installed.</returns>
		// Token: 0x0600609B RID: 24731 RVA: 0x00149A8C File Offset: 0x00147C8C
		[SecuritySafeCritical]
		public static string GetRuntimeDirectory()
		{
			string runtimeDirectoryImpl = RuntimeEnvironment.GetRuntimeDirectoryImpl();
			new FileIOPermission(FileIOPermissionAccess.PathDiscovery, runtimeDirectoryImpl).Demand();
			return runtimeDirectoryImpl;
		}

		// Token: 0x0600609C RID: 24732
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string GetRuntimeDirectoryImpl();

		/// <summary>Gets the path to the system configuration file.</summary>
		/// <returns>The path to the system configuration file.</returns>
		// Token: 0x170010EC RID: 4332
		// (get) Token: 0x0600609D RID: 24733 RVA: 0x00149AAC File Offset: 0x00147CAC
		public static string SystemConfigurationFile
		{
			[SecuritySafeCritical]
			get
			{
				StringBuilder stringBuilder = new StringBuilder(260);
				stringBuilder.Append(RuntimeEnvironment.GetRuntimeDirectory());
				stringBuilder.Append(AppDomainSetup.RuntimeConfigurationFile);
				string text = stringBuilder.ToString();
				new FileIOPermission(FileIOPermissionAccess.PathDiscovery, text).Demand();
				return text;
			}
		}

		// Token: 0x0600609E RID: 24734
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern IntPtr GetRuntimeInterfaceImpl([MarshalAs(UnmanagedType.LPStruct)] [In] Guid clsid, [MarshalAs(UnmanagedType.LPStruct)] [In] Guid riid);

		/// <summary>Returns the specified interface on the specified class.</summary>
		/// <param name="clsid">The identifier for the desired class.</param>
		/// <param name="riid">The identifier for the desired interface.</param>
		/// <returns>An unmanaged pointer to the requested interface.</returns>
		/// <exception cref="T:System.Runtime.InteropServices.COMException">IUnknown::QueryInterface failure.</exception>
		// Token: 0x0600609F RID: 24735 RVA: 0x00149AF0 File Offset: 0x00147CF0
		[SecurityCritical]
		[ComVisible(false)]
		public static IntPtr GetRuntimeInterfaceAsIntPtr(Guid clsid, Guid riid)
		{
			return RuntimeEnvironment.GetRuntimeInterfaceImpl(clsid, riid);
		}

		/// <summary>Returns an instance of a type that represents a COM object by a pointer to its <see langword="IUnknown" /> interface.</summary>
		/// <param name="clsid">The identifier for the desired class.</param>
		/// <param name="riid">The identifier for the desired interface.</param>
		/// <returns>An object that represents the specified unmanaged COM object.</returns>
		/// <exception cref="T:System.Runtime.InteropServices.COMException">IUnknown::QueryInterface failure.</exception>
		// Token: 0x060060A0 RID: 24736 RVA: 0x00149AFC File Offset: 0x00147CFC
		[SecurityCritical]
		[ComVisible(false)]
		public static object GetRuntimeInterfaceAsObject(Guid clsid, Guid riid)
		{
			IntPtr intPtr = IntPtr.Zero;
			object objectForIUnknown;
			try
			{
				intPtr = RuntimeEnvironment.GetRuntimeInterfaceImpl(clsid, riid);
				objectForIUnknown = Marshal.GetObjectForIUnknown(intPtr);
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.Release(intPtr);
				}
			}
			return objectForIUnknown;
		}
	}
}
