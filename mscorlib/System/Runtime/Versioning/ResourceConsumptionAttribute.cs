using System;
using System.Diagnostics;

namespace System.Runtime.Versioning
{
	/// <summary>Specifies the resource consumed by the member of a class. This class cannot be inherited.</summary>
	// Token: 0x020006F2 RID: 1778
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
	[Conditional("RESOURCE_ANNOTATION_WORK")]
	public sealed class ResourceConsumptionAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Versioning.ResourceConsumptionAttribute" /> class specifying the scope of the consumed resource.</summary>
		/// <param name="resourceScope">The <see cref="T:System.Runtime.Versioning.ResourceScope" /> for the consumed resource.</param>
		// Token: 0x06005037 RID: 20535 RVA: 0x0011A2B7 File Offset: 0x001184B7
		public ResourceConsumptionAttribute(ResourceScope resourceScope)
		{
			this._resourceScope = resourceScope;
			this._consumptionScope = this._resourceScope;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Versioning.ResourceConsumptionAttribute" /> class specifying the scope of the consumed resource and the scope of how it is consumed.</summary>
		/// <param name="resourceScope">The <see cref="T:System.Runtime.Versioning.ResourceScope" /> for the consumed resource.</param>
		/// <param name="consumptionScope">The <see cref="T:System.Runtime.Versioning.ResourceScope" /> used by this member.</param>
		// Token: 0x06005038 RID: 20536 RVA: 0x0011A2D2 File Offset: 0x001184D2
		public ResourceConsumptionAttribute(ResourceScope resourceScope, ResourceScope consumptionScope)
		{
			this._resourceScope = resourceScope;
			this._consumptionScope = consumptionScope;
		}

		/// <summary>Gets the resource scope for the consumed resource.</summary>
		/// <returns>A <see cref="T:System.Runtime.Versioning.ResourceScope" /> object specifying the resource scope of the consumed member.</returns>
		// Token: 0x17000D53 RID: 3411
		// (get) Token: 0x06005039 RID: 20537 RVA: 0x0011A2E8 File Offset: 0x001184E8
		public ResourceScope ResourceScope
		{
			get
			{
				return this._resourceScope;
			}
		}

		/// <summary>Gets the consumption scope for this member.</summary>
		/// <returns>A <see cref="T:System.Runtime.Versioning.ResourceScope" /> object specifying the resource scope used by this member.</returns>
		// Token: 0x17000D54 RID: 3412
		// (get) Token: 0x0600503A RID: 20538 RVA: 0x0011A2F0 File Offset: 0x001184F0
		public ResourceScope ConsumptionScope
		{
			get
			{
				return this._consumptionScope;
			}
		}

		// Token: 0x04002354 RID: 9044
		private ResourceScope _consumptionScope;

		// Token: 0x04002355 RID: 9045
		private ResourceScope _resourceScope;
	}
}
