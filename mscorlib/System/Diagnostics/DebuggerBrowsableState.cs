using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	/// <summary>Provides display instructions for the debugger.</summary>
	// Token: 0x020003BF RID: 959
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public enum DebuggerBrowsableState
	{
		/// <summary>Never show the element.</summary>
		// Token: 0x040015E9 RID: 5609
		[__DynamicallyInvokable]
		Never,
		/// <summary>Show the element as collapsed.</summary>
		// Token: 0x040015EA RID: 5610
		[__DynamicallyInvokable]
		Collapsed = 2,
		/// <summary>Do not display the root element; display the child elements if the element is a collection or array of items.</summary>
		// Token: 0x040015EB RID: 5611
		[__DynamicallyInvokable]
		RootHidden
	}
}
