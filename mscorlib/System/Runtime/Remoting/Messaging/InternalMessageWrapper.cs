using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Wraps remoting data for passing between message sinks, either for requests from client to server or for the subsequent responses.</summary>
	// Token: 0x02000845 RID: 2117
	[SecurityCritical]
	[ComVisible(true)]
	public class InternalMessageWrapper
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Messaging.InternalMessageWrapper" /> class.</summary>
		/// <param name="msg">A message that acts either as an outgoing method call on a remote object, or as the subsequent response.</param>
		// Token: 0x06005ADE RID: 23262 RVA: 0x0013E080 File Offset: 0x0013C280
		public InternalMessageWrapper(IMessage msg)
		{
			this.WrappedMessage = msg;
		}

		// Token: 0x06005ADF RID: 23263 RVA: 0x0013E090 File Offset: 0x0013C290
		[SecurityCritical]
		internal object GetIdentityObject()
		{
			IInternalMessage internalMessage = this.WrappedMessage as IInternalMessage;
			if (internalMessage != null)
			{
				return internalMessage.IdentityObject;
			}
			InternalMessageWrapper internalMessageWrapper = this.WrappedMessage as InternalMessageWrapper;
			if (internalMessageWrapper != null)
			{
				return internalMessageWrapper.GetIdentityObject();
			}
			return null;
		}

		// Token: 0x06005AE0 RID: 23264 RVA: 0x0013E0CC File Offset: 0x0013C2CC
		[SecurityCritical]
		internal object GetServerIdentityObject()
		{
			IInternalMessage internalMessage = this.WrappedMessage as IInternalMessage;
			if (internalMessage != null)
			{
				return internalMessage.ServerIdentityObject;
			}
			InternalMessageWrapper internalMessageWrapper = this.WrappedMessage as InternalMessageWrapper;
			if (internalMessageWrapper != null)
			{
				return internalMessageWrapper.GetServerIdentityObject();
			}
			return null;
		}

		/// <summary>Represents the request or response <see cref="T:System.Runtime.Remoting.Messaging.IMethodMessage" /> interface that is wrapped by the message wrapper.</summary>
		// Token: 0x040028D8 RID: 10456
		protected IMessage WrappedMessage;
	}
}
