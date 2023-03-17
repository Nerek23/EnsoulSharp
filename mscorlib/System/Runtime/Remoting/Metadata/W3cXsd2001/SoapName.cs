using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XML <see langword="Name" /> type.</summary>
	// Token: 0x020007C7 RID: 1991
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapName : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E78 RID: 3704
		// (get) Token: 0x060056C4 RID: 22212 RVA: 0x00131D11 File Offset: 0x0012FF11
		public static string XsdType
		{
			get
			{
				return "Name";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x060056C5 RID: 22213 RVA: 0x00131D18 File Offset: 0x0012FF18
		public string GetXsdType()
		{
			return SoapName.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapName" /> class.</summary>
		// Token: 0x060056C6 RID: 22214 RVA: 0x00131D1F File Offset: 0x0012FF1F
		public SoapName()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapName" /> class with an XML <see langword="Name" /> type.</summary>
		/// <param name="value">A <see cref="T:System.String" /> that contains an XML <see langword="Name" /> type.</param>
		// Token: 0x060056C7 RID: 22215 RVA: 0x00131D27 File Offset: 0x0012FF27
		public SoapName(string value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets an XML <see langword="Name" /> type.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains an XML <see langword="Name" /> type.</returns>
		// Token: 0x17000E79 RID: 3705
		// (get) Token: 0x060056C8 RID: 22216 RVA: 0x00131D36 File Offset: 0x0012FF36
		// (set) Token: 0x060056C9 RID: 22217 RVA: 0x00131D3E File Offset: 0x0012FF3E
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

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapName.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapName.Value" />.</returns>
		// Token: 0x060056CA RID: 22218 RVA: 0x00131D47 File Offset: 0x0012FF47
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapName" /> object.</summary>
		/// <param name="value">The <see langword="String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapName" /> object that is obtained from <paramref name="value" />.</returns>
		// Token: 0x060056CB RID: 22219 RVA: 0x00131D54 File Offset: 0x0012FF54
		public static SoapName Parse(string value)
		{
			return new SoapName(value);
		}

		// Token: 0x0400276C RID: 10092
		private string _value;
	}
}
