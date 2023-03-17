using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting
{
	/// <summary>Provides various static methods for configuring the remoting infrastructure.</summary>
	// Token: 0x02000792 RID: 1938
	[ComVisible(true)]
	public static class RemotingConfiguration
	{
		/// <summary>Reads the configuration file and configures the remoting infrastructure. <see cref="M:System.Runtime.Remoting.RemotingConfiguration.Configure(System.String)" /> is obsolete. Please use <see cref="M:System.Runtime.Remoting.RemotingConfiguration.Configure(System.String,System.Boolean)" /> instead.</summary>
		/// <param name="filename">The name of the remoting configuration file. Can be <see langword="null" />.</param>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054B4 RID: 21684 RVA: 0x0012C262 File Offset: 0x0012A462
		[SecuritySafeCritical]
		[Obsolete("Use System.Runtime.Remoting.RemotingConfiguration.Configure(string fileName, bool ensureSecurity) instead.", false)]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void Configure(string filename)
		{
			RemotingConfiguration.Configure(filename, false);
		}

		/// <summary>Reads the configuration file and configures the remoting infrastructure.</summary>
		/// <param name="filename">The name of the remoting configuration file. Can be <see langword="null" />.</param>
		/// <param name="ensureSecurity">If set to <see langword="true" /> security is required. If set to <see langword="false" />, security is not required but still may be used.</param>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054B5 RID: 21685 RVA: 0x0012C26B File Offset: 0x0012A46B
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void Configure(string filename, bool ensureSecurity)
		{
			RemotingConfigHandler.DoConfiguration(filename, ensureSecurity);
			RemotingServices.InternalSetRemoteActivationConfigured();
		}

		/// <summary>Gets or sets the name of a remoting application.</summary>
		/// <returns>The name of a remoting application.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels. This exception is thrown only when setting the property value.</exception>
		// Token: 0x17000E0E RID: 3598
		// (get) Token: 0x060054B6 RID: 21686 RVA: 0x0012C279 File Offset: 0x0012A479
		// (set) Token: 0x060054B7 RID: 21687 RVA: 0x0012C289 File Offset: 0x0012A489
		public static string ApplicationName
		{
			get
			{
				if (!RemotingConfigHandler.HasApplicationNameBeenSet())
				{
					return null;
				}
				return RemotingConfigHandler.ApplicationName;
			}
			[SecuritySafeCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				RemotingConfigHandler.ApplicationName = value;
			}
		}

		/// <summary>Gets the ID of the currently executing application.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains the ID of the currently executing application.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000E0F RID: 3599
		// (get) Token: 0x060054B8 RID: 21688 RVA: 0x0012C291 File Offset: 0x0012A491
		public static string ApplicationId
		{
			[SecurityCritical]
			get
			{
				return Identity.AppDomainUniqueId;
			}
		}

		/// <summary>Gets the ID of the currently executing process.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains the ID of the currently executing process.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000E10 RID: 3600
		// (get) Token: 0x060054B9 RID: 21689 RVA: 0x0012C298 File Offset: 0x0012A498
		public static string ProcessId
		{
			[SecurityCritical]
			get
			{
				return Identity.ProcessGuid;
			}
		}

		/// <summary>Gets or sets value that indicates how custom errors are handled.</summary>
		/// <returns>A member of the <see cref="T:System.Runtime.Remoting.CustomErrorsModes" /> enumeration that indicates how custom errors are handled.</returns>
		// Token: 0x17000E11 RID: 3601
		// (get) Token: 0x060054BA RID: 21690 RVA: 0x0012C29F File Offset: 0x0012A49F
		// (set) Token: 0x060054BB RID: 21691 RVA: 0x0012C2A6 File Offset: 0x0012A4A6
		public static CustomErrorsModes CustomErrorsMode
		{
			get
			{
				return RemotingConfigHandler.CustomErrorsMode;
			}
			[SecuritySafeCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				RemotingConfigHandler.CustomErrorsMode = value;
			}
		}

		/// <summary>Indicates whether the server channels in this application domain return filtered or complete exception information to local or remote callers.</summary>
		/// <param name="isLocalRequest">
		///   <see langword="true" /> to specify local callers; <see langword="false" /> to specify remote callers.</param>
		/// <returns>
		///   <see langword="true" /> if only filtered exception information is returned to local or remote callers, as specified by the <paramref name="isLocalRequest" /> parameter; <see langword="false" /> if complete exception information is returned.</returns>
		// Token: 0x060054BC RID: 21692 RVA: 0x0012C2B0 File Offset: 0x0012A4B0
		public static bool CustomErrorsEnabled(bool isLocalRequest)
		{
			switch (RemotingConfiguration.CustomErrorsMode)
			{
			case CustomErrorsModes.On:
				return true;
			case CustomErrorsModes.Off:
				return false;
			case CustomErrorsModes.RemoteOnly:
				return !isLocalRequest;
			default:
				return true;
			}
		}

		/// <summary>Registers a specified object type on the service end as a type that can be activated on request from a client.</summary>
		/// <param name="type">The <see cref="T:System.Type" /> of object to register.</param>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054BD RID: 21693 RVA: 0x0012C2E4 File Offset: 0x0012A4E4
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterActivatedServiceType(Type type)
		{
			ActivatedServiceTypeEntry entry = new ActivatedServiceTypeEntry(type);
			RemotingConfiguration.RegisterActivatedServiceType(entry);
		}

		/// <summary>Registers an object type recorded in the provided <see cref="T:System.Runtime.Remoting.ActivatedServiceTypeEntry" /> on the service end as one that can be activated on request from a client.</summary>
		/// <param name="entry">Configuration settings for the client-activated type.</param>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054BE RID: 21694 RVA: 0x0012C2FE File Offset: 0x0012A4FE
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterActivatedServiceType(ActivatedServiceTypeEntry entry)
		{
			RemotingConfigHandler.RegisterActivatedServiceType(entry);
			if (!RemotingConfiguration.s_ListeningForActivationRequests)
			{
				RemotingConfiguration.s_ListeningForActivationRequests = true;
				ActivationServices.StartListeningForRemoteRequests();
			}
		}

		/// <summary>Registers an object <see cref="T:System.Type" /> on the service end as a well-known type, using the given parameters to initialize a new instance of <see cref="T:System.Runtime.Remoting.WellKnownServiceTypeEntry" />.</summary>
		/// <param name="type">The object <see cref="T:System.Type" />.</param>
		/// <param name="objectUri">The object URI.</param>
		/// <param name="mode">The activation mode of the well-known object type being registered. (See <see cref="T:System.Runtime.Remoting.WellKnownObjectMode" />.)</param>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054BF RID: 21695 RVA: 0x0012C31C File Offset: 0x0012A51C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterWellKnownServiceType(Type type, string objectUri, WellKnownObjectMode mode)
		{
			WellKnownServiceTypeEntry entry = new WellKnownServiceTypeEntry(type, objectUri, mode);
			RemotingConfiguration.RegisterWellKnownServiceType(entry);
		}

		/// <summary>Registers an object <see cref="T:System.Type" /> recorded in the provided <see cref="T:System.Runtime.Remoting.WellKnownServiceTypeEntry" /> on the service end as a well-known type.</summary>
		/// <param name="entry">Configuration settings for the well-known type.</param>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054C0 RID: 21696 RVA: 0x0012C338 File Offset: 0x0012A538
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterWellKnownServiceType(WellKnownServiceTypeEntry entry)
		{
			RemotingConfigHandler.RegisterWellKnownServiceType(entry);
		}

		/// <summary>Registers an object <see cref="T:System.Type" /> on the client end as a type that can be activated on the server, using the given parameters to initialize a new instance of the <see cref="T:System.Runtime.Remoting.ActivatedClientTypeEntry" /> class.</summary>
		/// <param name="type">The object <see cref="T:System.Type" />.</param>
		/// <param name="appUrl">URL of the application where this type is activated.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="typeName" /> or <paramref name="URI" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054C1 RID: 21697 RVA: 0x0012C340 File Offset: 0x0012A540
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterActivatedClientType(Type type, string appUrl)
		{
			ActivatedClientTypeEntry entry = new ActivatedClientTypeEntry(type, appUrl);
			RemotingConfiguration.RegisterActivatedClientType(entry);
		}

		/// <summary>Registers an object <see cref="T:System.Type" /> recorded in the provided <see cref="T:System.Runtime.Remoting.ActivatedClientTypeEntry" /> on the client end as a type that can be activated on the server.</summary>
		/// <param name="entry">Configuration settings for the client-activated type.</param>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054C2 RID: 21698 RVA: 0x0012C35B File Offset: 0x0012A55B
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterActivatedClientType(ActivatedClientTypeEntry entry)
		{
			RemotingConfigHandler.RegisterActivatedClientType(entry);
			RemotingServices.InternalSetRemoteActivationConfigured();
		}

		/// <summary>Registers an object <see cref="T:System.Type" /> on the client end as a well-known type that can be activated on the server, using the given parameters to initialize a new instance of the <see cref="T:System.Runtime.Remoting.WellKnownClientTypeEntry" /> class.</summary>
		/// <param name="type">The object <see cref="T:System.Type" />.</param>
		/// <param name="objectUrl">URL of a well-known client object.</param>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054C3 RID: 21699 RVA: 0x0012C368 File Offset: 0x0012A568
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterWellKnownClientType(Type type, string objectUrl)
		{
			WellKnownClientTypeEntry entry = new WellKnownClientTypeEntry(type, objectUrl);
			RemotingConfiguration.RegisterWellKnownClientType(entry);
		}

		/// <summary>Registers an object <see cref="T:System.Type" /> recorded in the provided <see cref="T:System.Runtime.Remoting.WellKnownClientTypeEntry" /> on the client end as a well-known type that can be activated on the server.</summary>
		/// <param name="entry">Configuration settings for the well-known type.</param>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054C4 RID: 21700 RVA: 0x0012C383 File Offset: 0x0012A583
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterWellKnownClientType(WellKnownClientTypeEntry entry)
		{
			RemotingConfigHandler.RegisterWellKnownClientType(entry);
			RemotingServices.InternalSetRemoteActivationConfigured();
		}

		/// <summary>Retrieves an array of object types registered on the service end that can be activated on request from a client.</summary>
		/// <returns>An array of object types registered on the service end that can be activated on request from a client.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054C5 RID: 21701 RVA: 0x0012C390 File Offset: 0x0012A590
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static ActivatedServiceTypeEntry[] GetRegisteredActivatedServiceTypes()
		{
			return RemotingConfigHandler.GetRegisteredActivatedServiceTypes();
		}

		/// <summary>Retrieves an array of object types registered on the service end as well-known types.</summary>
		/// <returns>An array of object types registered on the service end as well-known types.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054C6 RID: 21702 RVA: 0x0012C397 File Offset: 0x0012A597
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static WellKnownServiceTypeEntry[] GetRegisteredWellKnownServiceTypes()
		{
			return RemotingConfigHandler.GetRegisteredWellKnownServiceTypes();
		}

		/// <summary>Retrieves an array of object types registered on the client as types that will be activated remotely.</summary>
		/// <returns>An array of object types registered on the client as types that will be activated remotely.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054C7 RID: 21703 RVA: 0x0012C39E File Offset: 0x0012A59E
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static ActivatedClientTypeEntry[] GetRegisteredActivatedClientTypes()
		{
			return RemotingConfigHandler.GetRegisteredActivatedClientTypes();
		}

		/// <summary>Retrieves an array of object types registered on the client end as well-known types.</summary>
		/// <returns>An array of object types registered on the client end as well-known types.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054C8 RID: 21704 RVA: 0x0012C3A5 File Offset: 0x0012A5A5
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static WellKnownClientTypeEntry[] GetRegisteredWellKnownClientTypes()
		{
			return RemotingConfigHandler.GetRegisteredWellKnownClientTypes();
		}

		/// <summary>Checks whether the specified object <see cref="T:System.Type" /> is registered as a remotely activated client type.</summary>
		/// <param name="svrType">The object type to check.</param>
		/// <returns>The <see cref="T:System.Runtime.Remoting.ActivatedClientTypeEntry" /> that corresponds to the specified object type.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054C9 RID: 21705 RVA: 0x0012C3AC File Offset: 0x0012A5AC
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static ActivatedClientTypeEntry IsRemotelyActivatedClientType(Type svrType)
		{
			if (svrType == null)
			{
				throw new ArgumentNullException("svrType");
			}
			RuntimeType runtimeType = svrType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			return RemotingConfigHandler.IsRemotelyActivatedClientType(runtimeType);
		}

		/// <summary>Checks whether the object specified by its type name and assembly name is registered as a remotely activated client type.</summary>
		/// <param name="typeName">The type name of the object to check.</param>
		/// <param name="assemblyName">The assembly name of the object to check.</param>
		/// <returns>The <see cref="T:System.Runtime.Remoting.ActivatedClientTypeEntry" /> that corresponds to the specified object type.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054CA RID: 21706 RVA: 0x0012C3F3 File Offset: 0x0012A5F3
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static ActivatedClientTypeEntry IsRemotelyActivatedClientType(string typeName, string assemblyName)
		{
			return RemotingConfigHandler.IsRemotelyActivatedClientType(typeName, assemblyName);
		}

		/// <summary>Checks whether the specified object <see cref="T:System.Type" /> is registered as a well-known client type.</summary>
		/// <param name="svrType">The object <see cref="T:System.Type" /> to check.</param>
		/// <returns>The <see cref="T:System.Runtime.Remoting.WellKnownClientTypeEntry" /> that corresponds to the specified object type.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054CB RID: 21707 RVA: 0x0012C3FC File Offset: 0x0012A5FC
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static WellKnownClientTypeEntry IsWellKnownClientType(Type svrType)
		{
			if (svrType == null)
			{
				throw new ArgumentNullException("svrType");
			}
			RuntimeType runtimeType = svrType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			return RemotingConfigHandler.IsWellKnownClientType(runtimeType);
		}

		/// <summary>Checks whether the object specified by its type name and assembly name is registered as a well-known client type.</summary>
		/// <param name="typeName">The type name of the object to check.</param>
		/// <param name="assemblyName">The assembly name of the object to check.</param>
		/// <returns>The <see cref="T:System.Runtime.Remoting.WellKnownClientTypeEntry" /> that corresponds to the specified object type.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054CC RID: 21708 RVA: 0x0012C443 File Offset: 0x0012A643
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static WellKnownClientTypeEntry IsWellKnownClientType(string typeName, string assemblyName)
		{
			return RemotingConfigHandler.IsWellKnownClientType(typeName, assemblyName);
		}

		/// <summary>Returns a Boolean value that indicates whether the specified <see cref="T:System.Type" /> is allowed to be client activated.</summary>
		/// <param name="svrType">The object <see cref="T:System.Type" /> to check.</param>
		/// <returns>
		///   <see langword="true" /> if the specified <see cref="T:System.Type" /> is allowed to be client activated; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x060054CD RID: 21709 RVA: 0x0012C44C File Offset: 0x0012A64C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static bool IsActivationAllowed(Type svrType)
		{
			RuntimeType runtimeType = svrType as RuntimeType;
			if (svrType != null && runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			return RemotingConfigHandler.IsActivationAllowed(runtimeType);
		}

		// Token: 0x040026C1 RID: 9921
		private static volatile bool s_ListeningForActivationRequests;
	}
}
