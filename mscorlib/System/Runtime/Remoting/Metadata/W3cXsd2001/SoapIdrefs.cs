using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XML <see langword="IDREFS" /> attribute.</summary>
	// Token: 0x020007C8 RID: 1992
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapIdrefs : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E7A RID: 3706
		// (get) Token: 0x060056CC RID: 22220 RVA: 0x00131D5C File Offset: 0x0012FF5C
		public static string XsdType
		{
			get
			{
				return "IDREFS";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x060056CD RID: 22221 RVA: 0x00131D63 File Offset: 0x0012FF63
		public string GetXsdType()
		{
			return SoapIdrefs.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapIdrefs" /> class.</summary>
		// Token: 0x060056CE RID: 22222 RVA: 0x00131D6A File Offset: 0x0012FF6A
		public SoapIdrefs()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapIdrefs" /> class with an XML <see langword="IDREFS" /> attribute.</summary>
		/// <param name="value">A <see cref="T:System.String" /> that contains an XML <see langword="IDREFS" /> attribute.</param>
		// Token: 0x060056CF RID: 22223 RVA: 0x00131D72 File Offset: 0x0012FF72
		public SoapIdrefs(string value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets an XML <see langword="IDREFS" /> attribute.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains an XML <see langword="IDREFS" /> attribute.</returns>
		// Token: 0x17000E7B RID: 3707
		// (get) Token: 0x060056D0 RID: 22224 RVA: 0x00131D81 File Offset: 0x0012FF81
		// (set) Token: 0x060056D1 RID: 22225 RVA: 0x00131D89 File Offset: 0x0012FF89
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

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapIdrefs.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapIdrefs.Value" />.</returns>
		// Token: 0x060056D2 RID: 22226 RVA: 0x00131D92 File Offset: 0x0012FF92
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapIdrefs" /> object.</summary>
		/// <param name="value">The <see langword="String" /> to convert.</param>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <paramref name="value" />.</returns>
		// Token: 0x060056D3 RID: 22227 RVA: 0x00131D9F File Offset: 0x0012FF9F
		public static SoapIdrefs Parse(string value)
		{
			return new SoapIdrefs(value);
		}

		// Token: 0x0400276D RID: 10093
		private string _value;
	}
}
