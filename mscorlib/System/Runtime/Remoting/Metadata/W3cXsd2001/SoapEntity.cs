using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XML <see langword="ENTITY" /> attribute.</summary>
	// Token: 0x020007CF RID: 1999
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapEntity : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E88 RID: 3720
		// (get) Token: 0x06005704 RID: 22276 RVA: 0x00131F69 File Offset: 0x00130169
		public static string XsdType
		{
			get
			{
				return "ENTITY";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x06005705 RID: 22277 RVA: 0x00131F70 File Offset: 0x00130170
		public string GetXsdType()
		{
			return SoapEntity.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntity" /> class.</summary>
		// Token: 0x06005706 RID: 22278 RVA: 0x00131F77 File Offset: 0x00130177
		public SoapEntity()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntity" /> class with an XML <see langword="ENTITY" /> attribute.</summary>
		/// <param name="value">A <see cref="T:System.String" /> that contains an XML <see langword="ENTITY" /> attribute.</param>
		// Token: 0x06005707 RID: 22279 RVA: 0x00131F7F File Offset: 0x0013017F
		public SoapEntity(string value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets an XML <see langword="ENTITY" /> attribute.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains an XML <see langword="ENTITY" /> attribute.</returns>
		// Token: 0x17000E89 RID: 3721
		// (get) Token: 0x06005708 RID: 22280 RVA: 0x00131F8E File Offset: 0x0013018E
		// (set) Token: 0x06005709 RID: 22281 RVA: 0x00131F96 File Offset: 0x00130196
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

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntity.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntity.Value" />.</returns>
		// Token: 0x0600570A RID: 22282 RVA: 0x00131F9F File Offset: 0x0013019F
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntity" /> object.</summary>
		/// <param name="value">The <see langword="String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapEntities" /> object that is obtained from <paramref name="value" />.</returns>
		// Token: 0x0600570B RID: 22283 RVA: 0x00131FAC File Offset: 0x001301AC
		public static SoapEntity Parse(string value)
		{
			return new SoapEntity(value);
		}

		// Token: 0x04002774 RID: 10100
		private string _value;
	}
}
