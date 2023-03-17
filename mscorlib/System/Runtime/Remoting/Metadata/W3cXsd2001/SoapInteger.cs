using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XSD <see langword="integer" /> type.</summary>
	// Token: 0x020007BC RID: 1980
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapInteger : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E60 RID: 3680
		// (get) Token: 0x06005664 RID: 22116 RVA: 0x0013153C File Offset: 0x0012F73C
		public static string XsdType
		{
			get
			{
				return "integer";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x06005665 RID: 22117 RVA: 0x00131543 File Offset: 0x0012F743
		public string GetXsdType()
		{
			return SoapInteger.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapInteger" /> class.</summary>
		// Token: 0x06005666 RID: 22118 RVA: 0x0013154A File Offset: 0x0012F74A
		public SoapInteger()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapInteger" /> class with a <see cref="T:System.Decimal" /> value.</summary>
		/// <param name="value">A <see cref="T:System.Decimal" /> value to initialize the current instance.</param>
		// Token: 0x06005667 RID: 22119 RVA: 0x00131552 File Offset: 0x0012F752
		public SoapInteger(decimal value)
		{
			this._value = decimal.Truncate(value);
		}

		/// <summary>Gets or sets the numeric value of the current instance.</summary>
		/// <returns>A <see cref="T:System.Decimal" /> that indicates the numeric value of the current instance.</returns>
		// Token: 0x17000E61 RID: 3681
		// (get) Token: 0x06005668 RID: 22120 RVA: 0x00131566 File Offset: 0x0012F766
		// (set) Token: 0x06005669 RID: 22121 RVA: 0x0013156E File Offset: 0x0012F76E
		public decimal Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = decimal.Truncate(value);
			}
		}

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapInteger.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapInteger.Value" />.</returns>
		// Token: 0x0600566A RID: 22122 RVA: 0x0013157C File Offset: 0x0012F77C
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapInteger" /> object.</summary>
		/// <param name="value">The <see cref="T:System.String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapInteger" /> object that is obtained from <paramref name="value" />.</returns>
		// Token: 0x0600566B RID: 22123 RVA: 0x0013158E File Offset: 0x0012F78E
		public static SoapInteger Parse(string value)
		{
			return new SoapInteger(decimal.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture));
		}

		// Token: 0x0400275F RID: 10079
		private decimal _value;
	}
}
