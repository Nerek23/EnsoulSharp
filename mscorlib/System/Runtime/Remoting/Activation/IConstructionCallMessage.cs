using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	/// <summary>Represents the construction call request of an object.</summary>
	// Token: 0x0200086E RID: 2158
	[ComVisible(true)]
	public interface IConstructionCallMessage : IMethodCallMessage, IMethodMessage, IMessage
	{
		/// <summary>Gets or sets the activator that activates the remote object.</summary>
		/// <returns>The activator that activates the remote object.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000FF1 RID: 4081
		// (get) Token: 0x06005C0F RID: 23567
		// (set) Token: 0x06005C10 RID: 23568
		IActivator Activator { [SecurityCritical] get; [SecurityCritical] set; }

		/// <summary>Gets the call site activation attributes.</summary>
		/// <returns>The call site activation attributes.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000FF2 RID: 4082
		// (get) Token: 0x06005C11 RID: 23569
		object[] CallSiteActivationAttributes { [SecurityCritical] get; }

		/// <summary>Gets the full type name of the remote type to activate.</summary>
		/// <returns>The full type name of the remote type to activate.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000FF3 RID: 4083
		// (get) Token: 0x06005C12 RID: 23570
		string ActivationTypeName { [SecurityCritical] get; }

		/// <summary>Gets the type of the remote object to activate.</summary>
		/// <returns>The type of the remote object to activate.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000FF4 RID: 4084
		// (get) Token: 0x06005C13 RID: 23571
		Type ActivationType { [SecurityCritical] get; }

		/// <summary>Gets a list of context properties that define the context in which the object is to be created.</summary>
		/// <returns>A list of properties of the context in which to construct the object.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000FF5 RID: 4085
		// (get) Token: 0x06005C14 RID: 23572
		IList ContextProperties { [SecurityCritical] get; }
	}
}
