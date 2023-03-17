using System;

namespace System.Diagnostics.Contracts
{
	/// <summary>Specifies the type of contract that failed.</summary>
	// Token: 0x020003E9 RID: 1001
	[__DynamicallyInvokable]
	public enum ContractFailureKind
	{
		/// <summary>A <see cref="Overload:System.Diagnostics.Contracts.Contract.Requires" /> contract failed.</summary>
		// Token: 0x04001656 RID: 5718
		[__DynamicallyInvokable]
		Precondition,
		/// <summary>An <see cref="Overload:System.Diagnostics.Contracts.Contract.Ensures" /> contract failed.</summary>
		// Token: 0x04001657 RID: 5719
		[__DynamicallyInvokable]
		Postcondition,
		/// <summary>An <see cref="Overload:System.Diagnostics.Contracts.Contract.EnsuresOnThrow" /> contract failed.</summary>
		// Token: 0x04001658 RID: 5720
		[__DynamicallyInvokable]
		PostconditionOnException,
		/// <summary>An <see cref="Overload:System.Diagnostics.Contracts.Contract.Invariant" /> contract failed.</summary>
		// Token: 0x04001659 RID: 5721
		[__DynamicallyInvokable]
		Invariant,
		/// <summary>An <see cref="Overload:System.Diagnostics.Contracts.Contract.Assert" /> contract failed.</summary>
		// Token: 0x0400165A RID: 5722
		[__DynamicallyInvokable]
		Assert,
		/// <summary>An <see cref="Overload:System.Diagnostics.Contracts.Contract.Assume" /> contract failed.</summary>
		// Token: 0x0400165B RID: 5723
		[__DynamicallyInvokable]
		Assume
	}
}
