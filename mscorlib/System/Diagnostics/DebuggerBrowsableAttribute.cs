using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	/// <summary>Determines if and how a member is displayed in the debugger variable windows. This class cannot be inherited.</summary>
	// Token: 0x020003C0 RID: 960
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DebuggerBrowsableAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerBrowsableAttribute" /> class.</summary>
		/// <param name="state">One of the <see cref="T:System.Diagnostics.DebuggerBrowsableState" /> values that specifies how to display the member.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="state" /> is not one of the <see cref="T:System.Diagnostics.DebuggerBrowsableState" /> values.</exception>
		// Token: 0x060031EF RID: 12783 RVA: 0x000C01A8 File Offset: 0x000BE3A8
		[__DynamicallyInvokable]
		public DebuggerBrowsableAttribute(DebuggerBrowsableState state)
		{
			if (state < DebuggerBrowsableState.Never || state > DebuggerBrowsableState.RootHidden)
			{
				throw new ArgumentOutOfRangeException("state");
			}
			this.state = state;
		}

		/// <summary>Gets the display state for the attribute.</summary>
		/// <returns>One of the <see cref="T:System.Diagnostics.DebuggerBrowsableState" /> values.</returns>
		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x060031F0 RID: 12784 RVA: 0x000C01CA File Offset: 0x000BE3CA
		[__DynamicallyInvokable]
		public DebuggerBrowsableState State
		{
			[__DynamicallyInvokable]
			get
			{
				return this.state;
			}
		}

		// Token: 0x040015EC RID: 5612
		private DebuggerBrowsableState state;
	}
}
