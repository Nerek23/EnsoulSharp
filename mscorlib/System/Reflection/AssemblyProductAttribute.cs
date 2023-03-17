using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Defines a product name custom attribute for an assembly manifest.</summary>
	// Token: 0x02000589 RID: 1417
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyProductAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyProductAttribute" /> class.</summary>
		/// <param name="product">The product name information.</param>
		// Token: 0x06004336 RID: 17206 RVA: 0x000F7997 File Offset: 0x000F5B97
		[__DynamicallyInvokable]
		public AssemblyProductAttribute(string product)
		{
			this.m_product = product;
		}

		/// <summary>Gets product name information.</summary>
		/// <returns>A string containing the product name.</returns>
		// Token: 0x170009FA RID: 2554
		// (get) Token: 0x06004337 RID: 17207 RVA: 0x000F79A6 File Offset: 0x000F5BA6
		[__DynamicallyInvokable]
		public string Product
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_product;
			}
		}

		// Token: 0x04001B44 RID: 6980
		private string m_product;
	}
}
