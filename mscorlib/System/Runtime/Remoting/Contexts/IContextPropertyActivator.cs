using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	/// <summary>Indicates that the implementing property is interested in participating in activation and might not have provided a message sink.</summary>
	// Token: 0x020007E1 RID: 2017
	[ComVisible(true)]
	public interface IContextPropertyActivator
	{
		/// <summary>Indicates whether it is all right to activate the object type indicated in the <paramref name="msg" /> parameter.</summary>
		/// <param name="msg">An <see cref="T:System.Runtime.Remoting.Activation.IConstructionCallMessage" />.</param>
		/// <returns>A Boolean value indicating whether the requested type can be activated.</returns>
		// Token: 0x060057A5 RID: 22437
		[SecurityCritical]
		bool IsOKToActivate(IConstructionCallMessage msg);

		/// <summary>Called on each client context property that has this interface, before the construction request leaves the client.</summary>
		/// <param name="msg">An <see cref="T:System.Runtime.Remoting.Activation.IConstructionCallMessage" />.</param>
		// Token: 0x060057A6 RID: 22438
		[SecurityCritical]
		void CollectFromClientContext(IConstructionCallMessage msg);

		/// <summary>Called on each client context property that has this interface, when the construction request returns to the client from the server.</summary>
		/// <param name="msg">An <see cref="T:System.Runtime.Remoting.Activation.IConstructionCallMessage" />.</param>
		/// <returns>
		///   <see langword="true" /> if successful; otherwise, <see langword="false" />.</returns>
		// Token: 0x060057A7 RID: 22439
		[SecurityCritical]
		bool DeliverClientContextToServerContext(IConstructionCallMessage msg);

		/// <summary>Called on each server context property that has this interface, before the construction response leaves the server for the client.</summary>
		/// <param name="msg">An <see cref="T:System.Runtime.Remoting.Activation.IConstructionReturnMessage" />.</param>
		// Token: 0x060057A8 RID: 22440
		[SecurityCritical]
		void CollectFromServerContext(IConstructionReturnMessage msg);

		/// <summary>Called on each client context property that has this interface, when the construction request returns to the client from the server.</summary>
		/// <param name="msg">An <see cref="T:System.Runtime.Remoting.Activation.IConstructionReturnMessage" />.</param>
		/// <returns>
		///   <see langword="true" /> if successful; otherwise, <see langword="false" />.</returns>
		// Token: 0x060057A9 RID: 22441
		[SecurityCritical]
		bool DeliverServerContextToClientContext(IConstructionReturnMessage msg);
	}
}
