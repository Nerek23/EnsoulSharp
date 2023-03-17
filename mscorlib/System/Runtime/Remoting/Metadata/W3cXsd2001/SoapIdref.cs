using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XML <see langword="IDREFS" /> attribute.</summary>
	// Token: 0x020007CE RID: 1998
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapIdref : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E86 RID: 3718
		// (get) Token: 0x060056FC RID: 22268 RVA: 0x00131F1E File Offset: 0x0013011E
		public static string XsdType
		{
			get
			{
				return "IDREF";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x060056FD RID: 22269 RVA: 0x00131F25 File Offset: 0x00130125
		public string GetXsdType()
		{
			return SoapIdref.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapIdref" /> class.</summary>
		// Token: 0x060056FE RID: 22270 RVA: 0x00131F2C File Offset: 0x0013012C
		public SoapIdref()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapIdref" /> class with an XML <see langword="IDREF" /> attribute.</summary>
		/// <param name="value">A <see cref="T:System.String" /> that contains an XML <see langword="IDREF" /> attribute.</param>
		// Token: 0x060056FF RID: 22271 RVA: 0x00131F34 File Offset: 0x00130134
		public SoapIdref(string value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets an XML <see langword="IDREF" /> attribute.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains an XML <see langword="IDREF" /> attribute.</returns>
		// Token: 0x17000E87 RID: 3719
		// (get) Token: 0x06005700 RID: 22272 RVA: 0x00131F43 File Offset: 0x00130143
		// (set) Token: 0x06005701 RID: 22273 RVA: 0x00131F4B File Offset: 0x0013014B
		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapIdref.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapIdref.Value" />.</returns>
		// Token: 0x06005702 RID: 22274 RVA: 0x00131F54 File Offset: 0x00130154
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapIdrefs" /> object.</summary>
		/// <param name="value">The <see langword="String" /> to convert.</param>
		/// <returns>A <see cref="T:System.String" /> obtained from <paramref name="value" />.</returns>
		// Token: 0x06005703 RID: 22275 RVA: 0x00131F61 File Offset: 0x00130161
		public static SoapIdref Parse(string value)
		{
			return new SoapIdref(value);
		}

		// Token: 0x04002773 RID: 10099
		private string _value;
	}
}
