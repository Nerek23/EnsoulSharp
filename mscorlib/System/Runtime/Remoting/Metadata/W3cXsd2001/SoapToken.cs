using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XML <see langword="token" /> type.</summary>
	// Token: 0x020007C5 RID: 1989
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapToken : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E74 RID: 3700
		// (get) Token: 0x060056B3 RID: 22195 RVA: 0x00131B93 File Offset: 0x0012FD93
		public static string XsdType
		{
			get
			{
				return "token";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x060056B4 RID: 22196 RVA: 0x00131B9A File Offset: 0x0012FD9A
		public string GetXsdType()
		{
			return SoapToken.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapToken" /> class.</summary>
		// Token: 0x060056B5 RID: 22197 RVA: 0x00131BA1 File Offset: 0x0012FDA1
		public SoapToken()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapToken" /> class with an XML <see langword="token" />.</summary>
		/// <param name="value">A <see cref="T:System.String" /> that contains an XML <see langword="token" />.</param>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">One of the following:  
		///
		/// <paramref name="value" /> contains invalid characters (0xD or 0x9).  
		///
		/// <paramref name="value" /> [0] or <paramref name="value" /> [ <paramref name="value" />.Length - 1] contains white space.  
		///
		/// <paramref name="value" /> contains any spaces.</exception>
		// Token: 0x060056B6 RID: 22198 RVA: 0x00131BA9 File Offset: 0x0012FDA9
		public SoapToken(string value)
		{
			this._value = this.Validate(value);
		}

		/// <summary>Gets or sets an XML <see langword="token" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains an XML <see langword="token" />.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">One of the following: <paramref name="value" /> contains invalid characters (0xD or 0x9).  
		///
		/// <paramref name="value" /> [0] or <paramref name="value" /> [ <paramref name="value" />.Length - 1] contains white space.  
		///
		/// <paramref name="value" /> contains any spaces.</exception>
		// Token: 0x17000E75 RID: 3701
		// (get) Token: 0x060056B7 RID: 22199 RVA: 0x00131BBE File Offset: 0x0012FDBE
		// (set) Token: 0x060056B8 RID: 22200 RVA: 0x00131BC6 File Offset: 0x0012FDC6
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

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapToken.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapToken.Value" />.</returns>
		// Token: 0x060056B9 RID: 22201 RVA: 0x00131BD5 File Offset: 0x0012FDD5
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapToken" /> object.</summary>
		/// <param name="value">The <see langword="String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapToken" /> object that is obtained from <paramref name="value" />.</returns>
		// Token: 0x060056BA RID: 22202 RVA: 0x00131BE2 File Offset: 0x0012FDE2
		public static SoapToken Parse(string value)
		{
			return new SoapToken(value);
		}

		// Token: 0x060056BB RID: 22203 RVA: 0x00131BEC File Offset: 0x0012FDEC
		private string Validate(string value)
		{
			if (value == null || value.Length == 0)
			{
				return value;
			}
			char[] anyOf = new char[]
			{
				'\r',
				'\t'
			};
			int num = value.LastIndexOfAny(anyOf);
			if (num > -1)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid", new object[]
				{
					"xsd:token",
					value
				}));
			}
			if (value.Length > 0 && (char.IsWhiteSpace(value[0]) || char.IsWhiteSpace(value[value.Length - 1])))
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid", new object[]
				{
					"xsd:token",
					value
				}));
			}
			num = value.IndexOf("  ");
			if (num > -1)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid", new object[]
				{
					"xsd:token",
					value
				}));
			}
			return value;
		}

		// Token: 0x0400276A RID: 10090
		private string _value;
	}
}
