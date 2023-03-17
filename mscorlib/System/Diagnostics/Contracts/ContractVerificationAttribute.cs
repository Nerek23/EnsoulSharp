using System;

namespace System.Diagnostics.Contracts
{
	/// <summary>Instructs analysis tools to assume the correctness of an assembly, type, or member without performing static verification.</summary>
	// Token: 0x020003E3 RID: 995
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property)]
	[__DynamicallyInvokable]
	public sealed class ContractVerificationAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Contracts.ContractVerificationAttribute" /> class.</summary>
		/// <param name="value">
		///   <see langword="true" /> to require verification; otherwise, <see langword="false" />.</param>
		// Token: 0x060032D5 RID: 13013 RVA: 0x000C1CB5 File Offset: 0x000BFEB5
		[__DynamicallyInvokable]
		public ContractVerificationAttribute(bool value)
		{
			this._value = value;
		}

		/// <summary>Gets the value that indicates whether to verify the contract of the target.</summary>
		/// <returns>
		///   <see langword="true" /> if verification is required; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x060032D6 RID: 13014 RVA: 0x000C1CC4 File Offset: 0x000BFEC4
		[__DynamicallyInvokable]
		public bool Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._value;
			}
		}

		// Token: 0x0400164E RID: 5710
		private bool _value;
	}
}
