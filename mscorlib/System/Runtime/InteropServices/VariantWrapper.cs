using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Marshals data of type <see langword="VT_VARIANT | VT_BYREF" /> from managed to unmanaged code. This class cannot be inherited.</summary>
	// Token: 0x02000934 RID: 2356
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class VariantWrapper
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.VariantWrapper" /> class for the specified <see cref="T:System.Object" /> parameter.</summary>
		/// <param name="obj">The object to marshal.</param>
		// Token: 0x06006105 RID: 24837 RVA: 0x0014AC36 File Offset: 0x00148E36
		[__DynamicallyInvokable]
		public VariantWrapper(object obj)
		{
			this.m_WrappedObject = obj;
		}

		/// <summary>Gets the object wrapped by the <see cref="T:System.Runtime.InteropServices.VariantWrapper" /> object.</summary>
		/// <returns>The object wrapped by the <see cref="T:System.Runtime.InteropServices.VariantWrapper" /> object.</returns>
		// Token: 0x170010FE RID: 4350
		// (get) Token: 0x06006106 RID: 24838 RVA: 0x0014AC45 File Offset: 0x00148E45
		[__DynamicallyInvokable]
		public object WrappedObject
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_WrappedObject;
			}
		}

		// Token: 0x04002AD5 RID: 10965
		private object m_WrappedObject;
	}
}
