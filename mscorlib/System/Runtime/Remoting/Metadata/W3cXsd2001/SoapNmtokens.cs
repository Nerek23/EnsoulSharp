using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XML <see langword="NMTOKENS" /> attribute.</summary>
	// Token: 0x020007CB RID: 1995
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapNmtokens : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E80 RID: 3712
		// (get) Token: 0x060056E4 RID: 22244 RVA: 0x00131E3D File Offset: 0x0013003D
		public static string XsdType
		{
			get
			{
				return "NMTOKENS";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x060056E5 RID: 22245 RVA: 0x00131E44 File Offset: 0x00130044
		public string GetXsdType()
		{
			return SoapNmtokens.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNmtokens" /> class.</summary>
		// Token: 0x060056E6 RID: 22246 RVA: 0x00131E4B File Offset: 0x0013004B
		public SoapNmtokens()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNmtokens" /> class with an XML <see langword="NMTOKENS" /> attribute.</summary>
		/// <param name="value">A <see cref="T:System.String" /> that contains an XML <see langword="NMTOKENS" /> attribute.</param>
		// Token: 0x060056E7 RID: 22247 RVA: 0x00131E53 File Offset: 0x00130053
		public SoapNmtokens(string value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets an XML <see langword="NMTOKENS" /> attribute.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains an XML <see langword="NMTOKENS" /> attribute.</returns>
		// Token: 0x17000E81 RID: 3713
		// (get) Token: 0x060056E8 RID: 22248 RVA: 0x00131E62 File Offset: 0x00130062
		// (set) Token: 0x060056E9 RID: 22249 RVA: 0x00131E6A File Offset: 0x0013006A
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

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNmtokens.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNmtokens.Value" />.</returns>
		// Token: 0x060056EA RID: 22250 RVA: 0x00131E73 File Offset: 0x00130073
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNmtokens" /> object.</summary>
		/// <param name="value">The <see langword="String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNmtokens" /> object that is obtained from <paramref name="value" />.</returns>
		// Token: 0x060056EB RID: 22251 RVA: 0x00131E80 File Offset: 0x00130080
		public static SoapNmtokens Parse(string value)
		{
			return new SoapNmtokens(value);
		}

		// Token: 0x04002770 RID: 10096
		private string _value;
	}
}
