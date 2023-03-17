using System;

namespace System.Diagnostics.Contracts
{
	/// <summary>Indicates that a type or method is pure, that is, it does not make any visible state changes.</summary>
	// Token: 0x020003DD RID: 989
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = false, Inherited = true)]
	[__DynamicallyInvokable]
	public sealed class PureAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Contracts.PureAttribute" /> class.</summary>
		// Token: 0x060032CD RID: 13005 RVA: 0x000C1C67 File Offset: 0x000BFE67
		[__DynamicallyInvokable]
		public PureAttribute()
		{
		}
	}
}
