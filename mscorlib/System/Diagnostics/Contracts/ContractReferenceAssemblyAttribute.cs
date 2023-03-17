using System;

namespace System.Diagnostics.Contracts
{
	/// <summary>Specifies that an assembly is a reference assembly that contains contracts.</summary>
	// Token: 0x020003E1 RID: 993
	[AttributeUsage(AttributeTargets.Assembly)]
	[__DynamicallyInvokable]
	public sealed class ContractReferenceAssemblyAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Contracts.ContractReferenceAssemblyAttribute" /> class.</summary>
		// Token: 0x060032D3 RID: 13011 RVA: 0x000C1CA5 File Offset: 0x000BFEA5
		[__DynamicallyInvokable]
		public ContractReferenceAssemblyAttribute()
		{
		}
	}
}
