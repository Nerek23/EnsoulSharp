using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Implements the <see cref="T:System.Runtime.Remoting.Activation.IConstructionReturnMessage" /> interface to create a message that responds to a call to instantiate a remote object.</summary>
	// Token: 0x02000841 RID: 2113
	[SecurityCritical]
	[CLSCompliant(false)]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	[Serializable]
	public class ConstructionResponse : MethodResponse, IConstructionReturnMessage, IMethodReturnMessage, IMethodMessage, IMessage
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Messaging.ConstructionResponse" /> class from an array of remoting headers and a request message.</summary>
		/// <param name="h">An array of remoting headers that contain key-value pairs. This array is used to initialize <see cref="T:System.Runtime.Remoting.Messaging.ConstructionResponse" /> fields for those headers that belong to the namespace "http://schemas.microsoft.com/clr/soap/messageProperties".</param>
		/// <param name="mcm">A request message that constitutes a constructor call on a remote object.</param>
		// Token: 0x06005AB0 RID: 23216 RVA: 0x0013D6BD File Offset: 0x0013B8BD
		public ConstructionResponse(Header[] h, IMethodCallMessage mcm) : base(h, mcm)
		{
		}

		// Token: 0x06005AB1 RID: 23217 RVA: 0x0013D6C7 File Offset: 0x0013B8C7
		internal ConstructionResponse(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		/// <summary>Gets an <see cref="T:System.Collections.IDictionary" /> interface that represents a collection of the remoting message's properties.</summary>
		/// <returns>An <see cref="T:System.Collections.IDictionary" /> interface that represents a collection of the remoting message's properties.</returns>
		// Token: 0x17000F91 RID: 3985
		// (get) Token: 0x06005AB2 RID: 23218 RVA: 0x0013D6D4 File Offset: 0x0013B8D4
		public override IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				IDictionary externalProperties;
				lock (this)
				{
					if (this.InternalProperties == null)
					{
						this.InternalProperties = new Hashtable();
					}
					if (this.ExternalProperties == null)
					{
						this.ExternalProperties = new CRMDictionary(this, this.InternalProperties);
					}
					externalProperties = this.ExternalProperties;
				}
				return externalProperties;
			}
		}
	}
}
