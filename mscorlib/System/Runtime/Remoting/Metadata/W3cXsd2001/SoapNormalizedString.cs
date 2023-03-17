using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XML <see langword="normalizedString" /> type.</summary>
	// Token: 0x020007C4 RID: 1988
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapNormalizedString : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E72 RID: 3698
		// (get) Token: 0x060056AA RID: 22186 RVA: 0x00131ADF File Offset: 0x0012FCDF
		public static string XsdType
		{
			get
			{
				return "normalizedString";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x060056AB RID: 22187 RVA: 0x00131AE6 File Offset: 0x0012FCE6
		public string GetXsdType()
		{
			return SoapNormalizedString.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNormalizedString" /> class.</summary>
		// Token: 0x060056AC RID: 22188 RVA: 0x00131AED File Offset: 0x0012FCED
		public SoapNormalizedString()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNormalizedString" /> class with a normalized string.</summary>
		/// <param name="value">A <see cref="T:System.String" /> object that contains a normalized string.</param>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">
		///   <paramref name="value" /> contains invalid characters (0xD, 0xA, or 0x9).</exception>
		// Token: 0x060056AD RID: 22189 RVA: 0x00131AF5 File Offset: 0x0012FCF5
		public SoapNormalizedString(string value)
		{
			this._value = this.Validate(value);
		}

		/// <summary>Gets or sets a normalized string.</summary>
		/// <returns>A <see cref="T:System.String" /> object that contains a normalized string.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">
		///   <paramref name="value" /> contains invalid characters (0xD, 0xA, or 0x9).</exception>
		// Token: 0x17000E73 RID: 3699
		// (get) Token: 0x060056AE RID: 22190 RVA: 0x00131B0A File Offset: 0x0012FD0A
		// (set) Token: 0x060056AF RID: 22191 RVA: 0x00131B12 File Offset: 0x0012FD12
		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = this.Validate(value);
			}
		}

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNormalizedString.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNormalizedString.Value" /> in the format "&lt;![CDATA[" + <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNormalizedString.Value" /> + "]]&gt;".</returns>
		// Token: 0x060056B0 RID: 22192 RVA: 0x00131B21 File Offset: 0x0012FD21
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNormalizedString" /> object.</summary>
		/// <param name="value">The <see langword="String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNormalizedString" /> object obtained from <paramref name="value" />.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">
		///   <paramref name="value" /> contains invalid characters (0xD, 0xA, or 0x9).</exception>
		// Token: 0x060056B1 RID: 22193 RVA: 0x00131B2E File Offset: 0x0012FD2E
		public static SoapNormalizedString Parse(string value)
		{
			return new SoapNormalizedString(value);
		}

		// Token: 0x060056B2 RID: 22194 RVA: 0x00131B38 File Offset: 0x0012FD38
		private string Validate(string value)
		{
			if (value == null || value.Length == 0)
			{
				return value;
			}
			char[] anyOf = new char[]
			{
				'\r',
				'\n',
				'\t'
			};
			int num = value.LastIndexOfAny(anyOf);
			if (num > -1)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid", new object[]
				{
					"xsd:normalizedString",
					value
				}));
			}
			return value;
		}

		// Token: 0x04002769 RID: 10089
		private string _value;
	}
}
