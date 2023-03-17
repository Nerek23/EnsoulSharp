using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	/// <summary>Indicates that the implementing property should be registered at runtime through the <see cref="M:System.Runtime.Remoting.Contexts.Context.RegisterDynamicProperty(System.Runtime.Remoting.Contexts.IDynamicProperty,System.ContextBoundObject,System.Runtime.Remoting.Contexts.Context)" /> method.</summary>
	// Token: 0x020007EA RID: 2026
	[ComVisible(true)]
	public interface IDynamicProperty
	{
		/// <summary>Gets the name of the dynamic property.</summary>
		/// <returns>The name of the dynamic property.</returns>
		// Token: 0x17000EA5 RID: 3749
		// (get) Token: 0x060057C1 RID: 22465
		string Name { [SecurityCritical] get; }
	}
}
