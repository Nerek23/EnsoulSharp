using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Hosting;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Threading;

namespace System
{
	/// <summary>Provides a managed equivalent of an unmanaged host.</summary>
	// Token: 0x0200009B RID: 155
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class AppDomainManager : MarshalByRefObject
	{
		/// <summary>Returns a new or existing application domain.</summary>
		/// <param name="friendlyName">The friendly name of the domain.</param>
		/// <param name="securityInfo">An object that contains evidence mapped through the security policy to establish a top-of-stack permission set.</param>
		/// <param name="appDomainInfo">An object that contains application domain initialization information.</param>
		/// <returns>A new or existing application domain.</returns>
		// Token: 0x0600088C RID: 2188 RVA: 0x0001D41D File Offset: 0x0001B61D
		[SecurityCritical]
		public virtual AppDomain CreateDomain(string friendlyName, Evidence securityInfo, AppDomainSetup appDomainInfo)
		{
			return AppDomainManager.CreateDomainHelper(friendlyName, securityInfo, appDomainInfo);
		}

		/// <summary>Provides a helper method to create an application domain.</summary>
		/// <param name="friendlyName">The friendly name of the domain.</param>
		/// <param name="securityInfo">An object that contains evidence mapped through the security policy to establish a top-of-stack permission set.</param>
		/// <param name="appDomainInfo">An object that contains application domain initialization information.</param>
		/// <returns>A newly created application domain.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="friendlyName" /> is <see langword="null" />.</exception>
		// Token: 0x0600088D RID: 2189 RVA: 0x0001D428 File Offset: 0x0001B628
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Demand, ControlAppDomain = true)]
		protected static AppDomain CreateDomainHelper(string friendlyName, Evidence securityInfo, AppDomainSetup appDomainInfo)
		{
			if (friendlyName == null)
			{
				throw new ArgumentNullException(Environment.GetResourceString("ArgumentNull_String"));
			}
			if (securityInfo != null)
			{
				new SecurityPermission(SecurityPermissionFlag.ControlEvidence).Demand();
				AppDomain.CheckDomainCreationEvidence(appDomainInfo, securityInfo);
			}
			if (appDomainInfo == null)
			{
				appDomainInfo = new AppDomainSetup();
			}
			if (appDomainInfo.AppDomainManagerAssembly == null || appDomainInfo.AppDomainManagerType == null)
			{
				string appDomainManagerAssembly;
				string appDomainManagerType;
				AppDomain.CurrentDomain.GetAppDomainManagerType(out appDomainManagerAssembly, out appDomainManagerType);
				if (appDomainInfo.AppDomainManagerAssembly == null)
				{
					appDomainInfo.AppDomainManagerAssembly = appDomainManagerAssembly;
				}
				if (appDomainInfo.AppDomainManagerType == null)
				{
					appDomainInfo.AppDomainManagerType = appDomainManagerType;
				}
			}
			if (appDomainInfo.TargetFrameworkName == null)
			{
				appDomainInfo.TargetFrameworkName = AppDomain.CurrentDomain.GetTargetFrameworkName();
			}
			return AppDomain.nCreateDomain(friendlyName, appDomainInfo, securityInfo, (securityInfo == null) ? AppDomain.CurrentDomain.InternalEvidence : null, AppDomain.CurrentDomain.GetSecurityDescriptor());
		}

		/// <summary>Initializes the new application domain.</summary>
		/// <param name="appDomainInfo">An object that contains application domain initialization information.</param>
		// Token: 0x0600088E RID: 2190 RVA: 0x0001D4DE File Offset: 0x0001B6DE
		[SecurityCritical]
		public virtual void InitializeNewDomain(AppDomainSetup appDomainInfo)
		{
		}

		/// <summary>Gets the initialization flags for custom application domain managers.</summary>
		/// <returns>A bitwise combination of the enumeration values that describe the initialization action to perform. The default is <see cref="F:System.AppDomainManagerInitializationOptions.None" />.</returns>
		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600088F RID: 2191 RVA: 0x0001D4E0 File Offset: 0x0001B6E0
		// (set) Token: 0x06000890 RID: 2192 RVA: 0x0001D4E8 File Offset: 0x0001B6E8
		public AppDomainManagerInitializationOptions InitializationFlags
		{
			get
			{
				return this.m_flags;
			}
			set
			{
				this.m_flags = value;
			}
		}

		/// <summary>Gets the application activator that handles the activation of add-ins and manifest-based applications for the domain.</summary>
		/// <returns>The application activator.</returns>
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000891 RID: 2193 RVA: 0x0001D4F1 File Offset: 0x0001B6F1
		public virtual ApplicationActivator ApplicationActivator
		{
			get
			{
				if (this.m_appActivator == null)
				{
					this.m_appActivator = new ApplicationActivator();
				}
				return this.m_appActivator;
			}
		}

		/// <summary>Gets the host security manager that participates in security decisions for the application domain.</summary>
		/// <returns>The host security manager.</returns>
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000892 RID: 2194 RVA: 0x0001D50C File Offset: 0x0001B70C
		public virtual HostSecurityManager HostSecurityManager
		{
			get
			{
				return null;
			}
		}

		/// <summary>Gets the host execution context manager that manages the flow of the execution context.</summary>
		/// <returns>The host execution context manager.</returns>
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x0001D50F File Offset: 0x0001B70F
		public virtual HostExecutionContextManager HostExecutionContextManager
		{
			get
			{
				return HostExecutionContextManager.GetInternalHostExecutionContextManager();
			}
		}

		// Token: 0x06000894 RID: 2196
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetEntryAssembly(ObjectHandleOnStack retAssembly);

		/// <summary>Gets the entry assembly for an application.</summary>
		/// <returns>The entry assembly for the application.</returns>
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000895 RID: 2197 RVA: 0x0001D518 File Offset: 0x0001B718
		public virtual Assembly EntryAssembly
		{
			[SecurityCritical]
			get
			{
				if (this.m_entryAssembly == null)
				{
					AppDomain currentDomain = AppDomain.CurrentDomain;
					if (currentDomain.IsDefaultAppDomain() && currentDomain.ActivationContext != null)
					{
						ManifestRunner manifestRunner = new ManifestRunner(currentDomain, currentDomain.ActivationContext);
						this.m_entryAssembly = manifestRunner.EntryAssembly;
					}
					else
					{
						RuntimeAssembly entryAssembly = null;
						AppDomainManager.GetEntryAssembly(JitHelpers.GetObjectHandleOnStack<RuntimeAssembly>(ref entryAssembly));
						this.m_entryAssembly = entryAssembly;
					}
				}
				return this.m_entryAssembly;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000896 RID: 2198 RVA: 0x0001D57F File Offset: 0x0001B77F
		internal static AppDomainManager CurrentAppDomainManager
		{
			[SecurityCritical]
			get
			{
				return AppDomain.CurrentDomain.DomainManager;
			}
		}

		/// <summary>Indicates whether the specified operation is allowed in the application domain.</summary>
		/// <param name="state">A subclass of <see cref="T:System.Security.SecurityState" /> that identifies the operation whose security status is requested.</param>
		/// <returns>
		///   <see langword="true" /> if the host allows the operation specified by <paramref name="state" /> to be performed in the application domain; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000897 RID: 2199 RVA: 0x0001D58B File Offset: 0x0001B78B
		public virtual bool CheckSecuritySettings(SecurityState state)
		{
			return false;
		}

		// Token: 0x06000898 RID: 2200
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasHost();

		// Token: 0x06000899 RID: 2201
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void RegisterWithHost(IntPtr appDomainManager);

		// Token: 0x0600089A RID: 2202 RVA: 0x0001D590 File Offset: 0x0001B790
		internal void RegisterWithHost()
		{
			if (AppDomainManager.HasHost())
			{
				IntPtr intPtr = IntPtr.Zero;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					intPtr = Marshal.GetIUnknownForObject(this);
					AppDomainManager.RegisterWithHost(intPtr);
				}
				finally
				{
					if (!intPtr.IsNull())
					{
						Marshal.Release(intPtr);
					}
				}
			}
		}

		// Token: 0x040003A0 RID: 928
		private AppDomainManagerInitializationOptions m_flags;

		// Token: 0x040003A1 RID: 929
		private ApplicationActivator m_appActivator;

		// Token: 0x040003A2 RID: 930
		private Assembly m_entryAssembly;
	}
}
