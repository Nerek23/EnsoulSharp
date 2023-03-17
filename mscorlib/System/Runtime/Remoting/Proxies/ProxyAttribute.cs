using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Proxies
{
	/// <summary>Indicates that an object type requires a custom proxy.</summary>
	// Token: 0x020007D0 RID: 2000
	[SecurityCritical]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class ProxyAttribute : Attribute, IContextAttribute
	{
		/// <summary>Creates either an uninitialized <see cref="T:System.MarshalByRefObject" /> or a transparent proxy, depending on whether the specified type can exist in the current context.</summary>
		/// <param name="serverType">The object type to create an instance of.</param>
		/// <returns>An uninitialized <see cref="T:System.MarshalByRefObject" /> or a transparent proxy.</returns>
		// Token: 0x0600570D RID: 22285 RVA: 0x00131FBC File Offset: 0x001301BC
		[SecurityCritical]
		public virtual MarshalByRefObject CreateInstance(Type serverType)
		{
			if (serverType == null)
			{
				throw new ArgumentNullException("serverType");
			}
			RuntimeType runtimeType = serverType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			if (!serverType.IsContextful)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Activation_MBR_ProxyAttribute"));
			}
			if (serverType.IsAbstract)
			{
				throw new RemotingException(Environment.GetResourceString("Acc_CreateAbst"));
			}
			return this.CreateInstanceInternal(runtimeType);
		}

		// Token: 0x0600570E RID: 22286 RVA: 0x00132034 File Offset: 0x00130234
		internal MarshalByRefObject CreateInstanceInternal(RuntimeType serverType)
		{
			return ActivationServices.CreateInstance(serverType);
		}

		/// <summary>Creates an instance of a remoting proxy for a remote object described by the specified <see cref="T:System.Runtime.Remoting.ObjRef" />, and located on the server.</summary>
		/// <param name="objRef">The object reference to the remote object for which to create a proxy.</param>
		/// <param name="serverType">The type of the server where the remote object is located.</param>
		/// <param name="serverObject">The server object.</param>
		/// <param name="serverContext">The context in which the server object is located.</param>
		/// <returns>The new instance of remoting proxy for the remote object that is described in the specified <see cref="T:System.Runtime.Remoting.ObjRef" />.</returns>
		// Token: 0x0600570F RID: 22287 RVA: 0x0013203C File Offset: 0x0013023C
		[SecurityCritical]
		public virtual RealProxy CreateProxy(ObjRef objRef, Type serverType, object serverObject, Context serverContext)
		{
			RemotingProxy remotingProxy = new RemotingProxy(serverType);
			if (serverContext != null)
			{
				RealProxy.SetStubData(remotingProxy, serverContext.InternalContextID);
			}
			if (objRef != null && objRef.GetServerIdentity().IsAllocated)
			{
				remotingProxy.SetSrvInfo(objRef.GetServerIdentity(), objRef.GetDomainID());
			}
			remotingProxy.Initialized = true;
			if (!serverType.IsContextful && !serverType.IsMarshalByRef && serverContext != null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Activation_MBR_ProxyAttribute"));
			}
			return remotingProxy;
		}

		/// <summary>Checks the specified context.</summary>
		/// <param name="ctx">The context to be verified.</param>
		/// <param name="msg">The message for the remote call.</param>
		/// <returns>The specified context.</returns>
		// Token: 0x06005710 RID: 22288 RVA: 0x001320B9 File Offset: 0x001302B9
		[SecurityCritical]
		[ComVisible(true)]
		public bool IsContextOK(Context ctx, IConstructionCallMessage msg)
		{
			return true;
		}

		/// <summary>Gets properties for a new context.</summary>
		/// <param name="msg">The message for which the context is to be retrieved.</param>
		// Token: 0x06005711 RID: 22289 RVA: 0x001320BC File Offset: 0x001302BC
		[SecurityCritical]
		[ComVisible(true)]
		public void GetPropertiesForNewContext(IConstructionCallMessage msg)
		{
		}
	}
}
