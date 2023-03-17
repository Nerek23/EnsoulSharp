using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XSD <see langword="date" /> type.</summary>
	// Token: 0x020007B4 RID: 1972
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapDate : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E4D RID: 3661
		// (get) Token: 0x06005613 RID: 22035 RVA: 0x00130D46 File Offset: 0x0012EF46
		public static string XsdType
		{
			get
			{
				return "date";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x06005614 RID: 22036 RVA: 0x00130D4D File Offset: 0x0012EF4D
		public string GetXsdType()
		{
			return SoapDate.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDate" /> class.</summary>
		// Token: 0x06005615 RID: 22037 RVA: 0x00130D54 File Offset: 0x0012EF54
		public SoapDate()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDate" /> class with a specified <see cref="T:System.DateTime" /> object.</summary>
		/// <param name="value">A <see cref="T:System.DateTime" /> object to initialize the current instance.</param>
		// Token: 0x06005616 RID: 22038 RVA: 0x00130D7C File Offset: 0x0012EF7C
		public SoapDate(DateTime value)
		{
			this._value = value;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDate" /> class with a specified <see cref="T:System.DateTime" /> object and an integer that indicates whether <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDate.Value" /> is a positive or negative value.</summary>
		/// <param name="value">A <see cref="T:System.DateTime" /> object to initialize the current instance.</param>
		/// <param name="sign">An integer that indicates whether <paramref name="value" /> is positive.</param>
		// Token: 0x06005617 RID: 22039 RVA: 0x00130DAC File Offset: 0x0012EFAC
		public SoapDate(DateTime value, int sign)
		{
			this._value = value;
			this._sign = sign;
		}

		/// <summary>Gets or sets the date and time of the current instance.</summary>
		/// <returns>The <see cref="T:System.DateTime" /> object that contains the date and time of the current instance.</returns>
		// Token: 0x17000E4E RID: 3662
		// (get) Token: 0x06005618 RID: 22040 RVA: 0x00130DE0 File Offset: 0x0012EFE0
		// (set) Token: 0x06005619 RID: 22041 RVA: 0x00130DE8 File Offset: 0x0012EFE8
		public DateTime Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value.Date;
			}
		}

		/// <summary>Gets or sets whether the date and time of the current instance is positive or negative.</summary>
		/// <returns>An integer that indicates whether <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDate.Value" /> is positive or negative.</returns>
		// Token: 0x17000E4F RID: 3663
		// (get) Token: 0x0600561A RID: 22042 RVA: 0x00130DF7 File Offset: 0x0012EFF7
		// (set) Token: 0x0600561B RID: 22043 RVA: 0x00130DFF File Offset: 0x0012EFFF
		public int Sign
		{
			get
			{
				return this._sign;
			}
			set
			{
				this._sign = value;
			}
		}

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDate.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDate.Value" /> in the format "yyyy-MM-dd" or "'-'yyyy-MM-dd" if <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDate.Sign" /> is negative.</returns>
		// Token: 0x0600561C RID: 22044 RVA: 0x00130E08 File Offset: 0x0012F008
		public override string ToString()
		{
			if (this._sign < 0)
			{
				return this._value.ToString("'-'yyyy-MM-dd", CultureInfo.InvariantCulture);
			}
			return this._value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDate" /> object.</summary>
		/// <param name="value">The <see cref="T:System.String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDate" /> object that is obtained from <paramref name="value" />.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">
		///   <paramref name="value" /> does not contain a date and time that corresponds to any of the recognized format patterns.</exception>
		// Token: 0x0600561D RID: 22045 RVA: 0x00130E40 File Offset: 0x0012F040
		public static SoapDate Parse(string value)
		{
			int sign = 0;
			if (value[0] == '-')
			{
				sign = -1;
			}
			return new SoapDate(DateTime.ParseExact(value, SoapDate.formats, CultureInfo.InvariantCulture, DateTimeStyles.None), sign);
		}

		// Token: 0x0400274D RID: 10061
		private DateTime _value = DateTime.MinValue.Date;

		// Token: 0x0400274E RID: 10062
		private int _sign;

		// Token: 0x0400274F RID: 10063
		private static string[] formats = new string[]
		{
			"yyyy-MM-dd",
			"'+'yyyy-MM-dd",
			"'-'yyyy-MM-dd",
			"yyyy-MM-ddzzz",
			"'+'yyyy-MM-ddzzz",
			"'-'yyyy-MM-ddzzz"
		};
	}
}
