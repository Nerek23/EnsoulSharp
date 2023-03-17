using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	/// <summary>Provides the basic functionality for a remoting activator class.</summary>
	// Token: 0x0200086C RID: 2156
	[ComVisible(true)]
	public interface IActivator
	{
		/// <summary>Gets or sets the next activator in the chain.</summary>
		/// <returns>The next activator in the chain.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000FEF RID: 4079
		// (get) Token: 0x06005C0B RID: 23563
		// (set) Token: 0x06005C0C RID: 23564
		IActivator NextActivator { [SecurityCritical] get; [SecurityCritical] set; }

		/// <summary>Creates an instance of the object that is specified in the provided <see cref="T:System.Runtime.Remoting.Activation.IConstructionCallMessage" />.</summary>
		/// <param name="msg">The information about the object that is needed to activate it, stored in a <see cref="T:System.Runtime.Remoting.Activation.IConstructionCallMessage" />.</param>
		/// <returns>Status of the object activation contained in a <see cref="T:System.Runtime.Remoting.Activation.IConstructionReturnMessage" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005C0D RID: 23565
		[SecurityCritical]
		IConstructionReturnMessage Activate(IConstructionCallMessage msg);

		/// <summary>Gets the <see cref="T:System.Runtime.Remoting.Activation.ActivatorLevel" /> where this activator is active.</summary>
		/// <returns>The <see cref="T:System.Runtime.Remoting.Activation.ActivatorLevel" /> where this activator is active.</returns>
		// Token: 0x17000FF0 RID: 4080
		// (get) Token: 0x06005C0E RID: 23566
		ActivatorLevel Level { [SecurityCritical] get; }
	}
}
