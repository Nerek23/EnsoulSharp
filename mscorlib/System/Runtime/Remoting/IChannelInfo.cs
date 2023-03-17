using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting
{
	/// <summary>Provides custom channel information that is carried along with the <see cref="T:System.Runtime.Remoting.ObjRef" />.</summary>
	// Token: 0x02000789 RID: 1929
	[ComVisible(true)]
	public interface IChannelInfo
	{
		/// <summary>Gets or sets the channel data for each channel.</summary>
		/// <returns>The channel data for each channel.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000DFF RID: 3583
		// (get) Token: 0x06005468 RID: 21608
		// (set) Token: 0x06005469 RID: 21609
		object[] ChannelData { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
