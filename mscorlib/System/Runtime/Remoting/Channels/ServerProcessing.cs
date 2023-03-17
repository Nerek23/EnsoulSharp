using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Indicates the status of the server message processing.</summary>
	// Token: 0x02000819 RID: 2073
	[ComVisible(true)]
	[Serializable]
	public enum ServerProcessing
	{
		/// <summary>The server synchronously processed the message.</summary>
		// Token: 0x0400283D RID: 10301
		Complete,
		/// <summary>The message was dispatched and no response can be sent.</summary>
		// Token: 0x0400283E RID: 10302
		OneWay,
		/// <summary>The call was dispatched asynchronously, which indicates that the sink must store response data on the stack for later processing.</summary>
		// Token: 0x0400283F RID: 10303
		Async
	}
}
