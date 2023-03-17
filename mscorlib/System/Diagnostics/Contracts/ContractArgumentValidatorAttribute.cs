using System;

namespace System.Diagnostics.Contracts
{
	/// <summary>Enables the factoring of legacy <see langword="if-then-throw" /> code into separate methods for reuse, and provides full control over thrown exceptions and arguments.</summary>
	// Token: 0x020003E5 RID: 997
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	[Conditional("CONTRACTS_FULL")]
	[__DynamicallyInvokable]
	public sealed class ContractArgumentValidatorAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Contracts.ContractArgumentValidatorAttribute" /> class.</summary>
		// Token: 0x060032D9 RID: 13017 RVA: 0x000C1CE3 File Offset: 0x000BFEE3
		[__DynamicallyInvokable]
		public ContractArgumentValidatorAttribute()
		{
		}
	}
}
