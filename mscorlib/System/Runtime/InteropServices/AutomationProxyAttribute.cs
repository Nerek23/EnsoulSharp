using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Specifies whether the type should be marshaled using the Automation marshaler or a custom proxy and stub.</summary>
	// Token: 0x0200090B RID: 2315
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	public sealed class AutomationProxyAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.AutomationProxyAttribute" /> class.</summary>
		/// <param name="val">
		///   <see langword="true" /> if the class should be marshaled using the Automation Marshaler; <see langword="false" /> if a proxy stub marshaler should be used.</param>
		// Token: 0x06005F2E RID: 24366 RVA: 0x00147384 File Offset: 0x00145584
		public AutomationProxyAttribute(bool val)
		{
			this._val = val;
		}

		/// <summary>Gets a value indicating the type of marshaler to use.</summary>
		/// <returns>
		///   <see langword="true" /> if the class should be marshaled using the Automation Marshaler; <see langword="false" /> if a proxy stub marshaler should be used.</returns>
		// Token: 0x170010CF RID: 4303
		// (get) Token: 0x06005F2F RID: 24367 RVA: 0x00147393 File Offset: 0x00145593
		public bool Value
		{
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A67 RID: 10855
		internal bool _val;
	}
}
