using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XSD <see langword="base64Binary" /> type.</summary>
	// Token: 0x020007BB RID: 1979
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapBase64Binary : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E5E RID: 3678
		// (get) Token: 0x0600565C RID: 22108 RVA: 0x0013147C File Offset: 0x0012F67C
		public static string XsdType
		{
			get
			{
				return "base64Binary";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x0600565D RID: 22109 RVA: 0x00131483 File Offset: 0x0012F683
		public string GetXsdType()
		{
			return SoapBase64Binary.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapBase64Binary" /> class.</summary>
		// Token: 0x0600565E RID: 22110 RVA: 0x0013148A File Offset: 0x0012F68A
		public SoapBase64Binary()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapBase64Binary" /> class with the binary representation of a 64-bit number.</summary>
		/// <param name="value">A <see cref="T:System.Byte" /> array that contains a 64-bit number.</param>
		// Token: 0x0600565F RID: 22111 RVA: 0x00131492 File Offset: 0x0012F692
		public SoapBase64Binary(byte[] value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets the binary representation of a 64-bit number.</summary>
		/// <returns>A <see cref="T:System.Byte" /> array that contains the binary representation of a 64-bit number.</returns>
		// Token: 0x17000E5F RID: 3679
		// (get) Token: 0x06005660 RID: 22112 RVA: 0x001314A1 File Offset: 0x0012F6A1
		// (set) Token: 0x06005661 RID: 22113 RVA: 0x001314A9 File Offset: 0x0012F6A9
		public byte[] Value
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

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapBase64Binary.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapBase64Binary.Value" />.</returns>
		// Token: 0x06005662 RID: 22114 RVA: 0x001314B2 File Offset: 0x0012F6B2
		public override string ToString()
		{
			if (this._value == null)
			{
				return null;
			}
			return SoapType.LineFeedsBin64(Convert.ToBase64String(this._value));
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapBase64Binary" /> object.</summary>
		/// <param name="value">The <see langword="String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapBase64Binary" /> object that is obtained from <paramref name="value" />.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">One of the following:  
		///
		/// <paramref name="value" /> is <see langword="null" />.  
		///
		/// The length of <paramref name="value" /> is less than 4.  
		///
		/// The length of <paramref name="value" /> is not a multiple of 4.</exception>
		// Token: 0x06005663 RID: 22115 RVA: 0x001314D0 File Offset: 0x0012F6D0
		public static SoapBase64Binary Parse(string value)
		{
			if (value == null || value.Length == 0)
			{
				return new SoapBase64Binary(new byte[0]);
			}
			byte[] value2;
			try
			{
				value2 = Convert.FromBase64String(SoapType.FilterBin64(value));
			}
			catch (Exception)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "base64Binary", value));
			}
			return new SoapBase64Binary(value2);
		}

		// Token: 0x0400275E RID: 10078
		private byte[] _value;
	}
}
