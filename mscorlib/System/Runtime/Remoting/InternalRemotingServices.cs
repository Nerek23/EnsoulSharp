using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.Remoting
{
	/// <summary>Defines utility methods for use by the .NET Framework remoting infrastructure.</summary>
	// Token: 0x0200079E RID: 1950
	[SecurityCritical]
	[ComVisible(true)]
	public class InternalRemotingServices
	{
		/// <summary>Sends a message concerning a remoting channel to an unmanaged debugger.</summary>
		/// <param name="s">A string to place in the message.</param>
		// Token: 0x06005566 RID: 21862 RVA: 0x0012E5C9 File Offset: 0x0012C7C9
		[SecurityCritical]
		[Conditional("_LOGGING")]
		public static void DebugOutChnl(string s)
		{
			Message.OutToUnmanagedDebugger("CHNL:" + s + "\n");
		}

		/// <summary>Sends any number of messages concerning remoting channels to an internal debugger.</summary>
		/// <param name="messages">An array of type <see cref="T:System.Object" /> that contains any number of messages.</param>
		// Token: 0x06005567 RID: 21863 RVA: 0x0012E5E0 File Offset: 0x0012C7E0
		[Conditional("_LOGGING")]
		public static void RemotingTrace(params object[] messages)
		{
		}

		/// <summary>Instructs an internal debugger to check for a condition and display a message if the condition is <see langword="false" />.</summary>
		/// <param name="condition">
		///   <see langword="true" /> to prevent a message from being displayed; otherwise, <see langword="false" />.</param>
		/// <param name="message">The message to display if <paramref name="condition" /> is <see langword="false" />.</param>
		// Token: 0x06005568 RID: 21864 RVA: 0x0012E5E2 File Offset: 0x0012C7E2
		[Conditional("_DEBUG")]
		public static void RemotingAssert(bool condition, string message)
		{
		}

		/// <summary>Sets internal identifying information for a remoted server object for each method call from client to server.</summary>
		/// <param name="m">A <see cref="T:System.Runtime.Remoting.Messaging.MethodCall" /> that represents a method call on a remote object.</param>
		/// <param name="srvID">Internal identifying information for a remoted server object.</param>
		// Token: 0x06005569 RID: 21865 RVA: 0x0012E5E4 File Offset: 0x0012C7E4
		[SecurityCritical]
		[CLSCompliant(false)]
		public static void SetServerIdentity(MethodCall m, object srvID)
		{
			((IInternalMessage)m).ServerIdentityObject = (ServerIdentity)srvID;
		}

		// Token: 0x0600556A RID: 21866 RVA: 0x0012E600 File Offset: 0x0012C800
		internal static RemotingMethodCachedData GetReflectionCachedData(MethodBase mi)
		{
			RuntimeMethodInfo runtimeMethodInfo;
			if ((runtimeMethodInfo = (mi as RuntimeMethodInfo)) != null)
			{
				return runtimeMethodInfo.RemotingCache;
			}
			RuntimeConstructorInfo runtimeConstructorInfo;
			if ((runtimeConstructorInfo = (mi as RuntimeConstructorInfo)) != null)
			{
				return runtimeConstructorInfo.RemotingCache;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeReflectionObject"));
		}

		// Token: 0x0600556B RID: 21867 RVA: 0x0012E64E File Offset: 0x0012C84E
		internal static RemotingTypeCachedData GetReflectionCachedData(RuntimeType type)
		{
			return type.RemotingCache;
		}

		// Token: 0x0600556C RID: 21868 RVA: 0x0012E658 File Offset: 0x0012C858
		internal static RemotingCachedData GetReflectionCachedData(MemberInfo mi)
		{
			MethodBase mi2;
			if ((mi2 = (mi as MethodBase)) != null)
			{
				return InternalRemotingServices.GetReflectionCachedData(mi2);
			}
			RuntimeType type;
			if ((type = (mi as RuntimeType)) != null)
			{
				return InternalRemotingServices.GetReflectionCachedData(type);
			}
			RuntimeFieldInfo runtimeFieldInfo;
			if ((runtimeFieldInfo = (mi as RuntimeFieldInfo)) != null)
			{
				return runtimeFieldInfo.RemotingCache;
			}
			SerializationFieldInfo serializationFieldInfo;
			if ((serializationFieldInfo = (mi as SerializationFieldInfo)) != null)
			{
				return serializationFieldInfo.RemotingCache;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeReflectionObject"));
		}

		// Token: 0x0600556D RID: 21869 RVA: 0x0012E6D8 File Offset: 0x0012C8D8
		internal static RemotingCachedData GetReflectionCachedData(RuntimeParameterInfo reflectionObject)
		{
			return reflectionObject.RemotingCache;
		}

		/// <summary>Gets an appropriate SOAP-related attribute for the specified class member or method parameter.</summary>
		/// <param name="reflectionObject">A class member or method parameter.</param>
		/// <returns>The SOAP-related attribute for the specified class member or method parameter.</returns>
		// Token: 0x0600556E RID: 21870 RVA: 0x0012E6E0 File Offset: 0x0012C8E0
		[SecurityCritical]
		public static SoapAttribute GetCachedSoapAttribute(object reflectionObject)
		{
			MemberInfo memberInfo = reflectionObject as MemberInfo;
			RuntimeParameterInfo runtimeParameterInfo = reflectionObject as RuntimeParameterInfo;
			if (memberInfo != null)
			{
				return InternalRemotingServices.GetReflectionCachedData(memberInfo).GetSoapAttribute();
			}
			if (runtimeParameterInfo != null)
			{
				return InternalRemotingServices.GetReflectionCachedData(runtimeParameterInfo).GetSoapAttribute();
			}
			return null;
		}
	}
}
