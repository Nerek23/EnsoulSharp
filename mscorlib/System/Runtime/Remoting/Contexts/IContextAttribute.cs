using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	/// <summary>Identifies a context attribute.</summary>
	// Token: 0x020007DF RID: 2015
	[ComVisible(true)]
	public interface IContextAttribute
	{
		/// <summary>Returns a Boolean value indicating whether the specified context meets the context attribute's requirements.</summary>
		/// <param name="ctx">The context to check against the current context attribute.</param>
		/// <param name="msg">The construction call, parameters of which need to be checked against the current context.</param>
		/// <returns>
		///   <see langword="true" /> if the passed in context is okay; otherwise, <see langword="false" />.</returns>
		// Token: 0x060057A0 RID: 22432
		[SecurityCritical]
		bool IsContextOK(Context ctx, IConstructionCallMessage msg);

		/// <summary>Returns context properties to the caller in the given message.</summary>
		/// <param name="msg">The <see cref="T:System.Runtime.Remoting.Activation.IConstructionCallMessage" /> to which to add the context properties.</param>
		// Token: 0x060057A1 RID: 22433
		[SecurityCritical]
		void GetPropertiesForNewContext(IConstructionCallMessage msg);
	}
}
