using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XML <see langword="ENTITIES" /> attribute.</summary>
	// Token: 0x020007C9 RID: 1993
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapEntities : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E7C RID: 3708
		// (get) Token: 0x060056D4 RID: 22228 RVA: 0x00131DA7 File Offset: 0x0012FFA7
		public static string XsdType
		{
			get
			{
				return "ENTITIES";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x060056D5 RID: 22229 RVA: 0x00131DAE File Offset: 0x0012FFAE
		public string GetXsdType()
		{
			return SoapEntities.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntities" /> class.</summary>
		// Token: 0x060056D6 RID: 22230 RVA: 0x00131DB5 File Offset: 0x0012FFB5
		public SoapEntities()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntities" /> class with an XML <see langword="ENTITIES" /> attribute.</summary>
		/// <param name="value">A <see cref="T:System.String" /> that contains an XML <see langword="ENTITIES" /> attribute.</param>
		// Token: 0x060056D7 RID: 22231 RVA: 0x00131DBD File Offset: 0x0012FFBD
		public SoapEntities(string value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets an XML <see langword="ENTITIES" /> attribute.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains an XML <see langword="ENTITIES" /> attribute.</returns>
		// Token: 0x17000E7D RID: 3709
		// (get) Token: 0x060056D8 RID: 22232 RVA: 0x00131DCC File Offset: 0x0012FFCC
		// (set) Token: 0x060056D9 RID: 22233 RVA: 0x00131DD4 File Offset: 0x0012FFD4
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

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntities.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntities.Value" />.</returns>
		// Token: 0x060056DA RID: 22234 RVA: 0x00131DDD File Offset: 0x0012FFDD
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntities" /> object.</summary>
		/// <param name="value">The <see langword="String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntities" /> object that is obtained from <paramref name="value" />.</returns>
		// Token: 0x060056DB RID: 22235 RVA: 0x00131DEA File Offset: 0x0012FFEA
		public static SoapEntities Parse(string value)
		{
			return new SoapEntities(value);
		}

		// Token: 0x0400276E RID: 10094
		private string _value;
	}
}
