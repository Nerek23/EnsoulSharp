using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	/// <summary>Indicates that the implementing message sink will be provided by dynamically registered properties.</summary>
	// Token: 0x020007EB RID: 2027
	[ComVisible(true)]
	public interface IDynamicMessageSink
	{
		/// <summary>Indicates that a call is starting.</summary>
		/// <param name="reqMsg">A request message.</param>
		/// <param name="bCliSide">A value of <see langword="true" /> if the method is invoked on the client side and <see langword="false" /> if the method is on the server side.</param>
		/// <param name="bAsync">A value of <see langword="true" /> if this is an asynchronic call and <see langword="false" /> if it is a synchronic call.</param>
		// Token: 0x060057C2 RID: 22466
		[SecurityCritical]
		void ProcessMessageStart(IMessage reqMsg, bool bCliSide, bool bAsync);

		/// <summary>Indicates that a call is returning.</summary>
		/// <param name="replyMsg">A reply message.</param>
		/// <param name="bCliSide">A value of <see langword="true" /> if the method is invoked on the client side and <see langword="false" /> if it is invoked on the server side.</param>
		/// <param name="bAsync">A value of <see langword="true" /> if this is an asynchronic call and <see langword="false" /> if it is a synchronic call.</param>
		// Token: 0x060057C3 RID: 22467
		[SecurityCritical]
		void ProcessMessageFinish(IMessage replyMsg, bool bCliSide, bool bAsync);
	}
}
