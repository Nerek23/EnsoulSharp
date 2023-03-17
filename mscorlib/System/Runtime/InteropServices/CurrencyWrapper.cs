using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Wraps objects the marshaler should marshal as a <see langword="VT_CY" />.</summary>
	// Token: 0x02000930 RID: 2352
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class CurrencyWrapper
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.CurrencyWrapper" /> class with the <see langword="Decimal" /> to be wrapped and marshaled as type <see langword="VT_CY" />.</summary>
		/// <param name="obj">The <see langword="Decimal" /> to be wrapped and marshaled as <see langword="VT_CY" />.</param>
		// Token: 0x060060FA RID: 24826 RVA: 0x0014AB46 File Offset: 0x00148D46
		[__DynamicallyInvokable]
		public CurrencyWrapper(decimal obj)
		{
			this.m_WrappedObject = obj;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.CurrencyWrapper" /> class with the object containing the <see langword="Decimal" /> to be wrapped and marshaled as type <see langword="VT_CY" />.</summary>
		/// <param name="obj">The object containing the <see langword="Decimal" /> to be wrapped and marshaled as <see langword="VT_CY" />.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="obj" /> parameter is not a <see cref="T:System.Decimal" /> type.</exception>
		// Token: 0x060060FB RID: 24827 RVA: 0x0014AB55 File Offset: 0x00148D55
		[__DynamicallyInvokable]
		public CurrencyWrapper(object obj)
		{
			if (!(obj is decimal))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeDecimal"), "obj");
			}
			this.m_WrappedObject = (decimal)obj;
		}

		/// <summary>Gets the wrapped object to be marshaled as type <see langword="VT_CY" />.</summary>
		/// <returns>The wrapped object to be marshaled as type <see langword="VT_CY" />.</returns>
		// Token: 0x170010FA RID: 4346
		// (get) Token: 0x060060FC RID: 24828 RVA: 0x0014AB86 File Offset: 0x00148D86
		[__DynamicallyInvokable]
		public decimal WrappedObject
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_WrappedObject;
			}
		}

		// Token: 0x04002AD1 RID: 10961
		private decimal m_WrappedObject;
	}
}
