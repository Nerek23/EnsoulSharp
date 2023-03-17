using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XSD <see langword="gMonth" /> type.</summary>
	// Token: 0x020007B9 RID: 1977
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapMonth : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E5A RID: 3674
		// (get) Token: 0x06005649 RID: 22089 RVA: 0x00131228 File Offset: 0x0012F428
		public static string XsdType
		{
			get
			{
				return "gMonth";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x0600564A RID: 22090 RVA: 0x0013122F File Offset: 0x0012F42F
		public string GetXsdType()
		{
			return SoapMonth.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapMonth" /> class.</summary>
		// Token: 0x0600564B RID: 22091 RVA: 0x00131236 File Offset: 0x0012F436
		public SoapMonth()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapMonth" /> class with a specified <see cref="T:System.DateTime" /> object.</summary>
		/// <param name="value">A <see cref="T:System.DateTime" /> object to initialize the current instance.</param>
		// Token: 0x0600564C RID: 22092 RVA: 0x00131249 File Offset: 0x0012F449
		public SoapMonth(DateTime value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets the date and time of the current instance.</summary>
		/// <returns>The <see cref="T:System.DateTime" /> object that contains the date and time of the current instance.</returns>
		// Token: 0x17000E5B RID: 3675
		// (get) Token: 0x0600564D RID: 22093 RVA: 0x00131263 File Offset: 0x0012F463
		// (set) Token: 0x0600564E RID: 22094 RVA: 0x0013126B File Offset: 0x0012F46B
		public DateTime Value
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

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapMonth.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapMonth.Value" /> in the format "--MM--".</returns>
		// Token: 0x0600564F RID: 22095 RVA: 0x00131274 File Offset: 0x0012F474
		public override string ToString()
		{
			return this._value.ToString("--MM--", CultureInfo.InvariantCulture);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapMonth" /> object.</summary>
		/// <param name="value">The <see langword="String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDay" /> object that is obtained from <paramref name="value" />.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">
		///   <paramref name="value" /> does not contain a date and time that corresponds to any of the recognized format patterns.</exception>
		// Token: 0x06005650 RID: 22096 RVA: 0x0013128B File Offset: 0x0012F48B
		public static SoapMonth Parse(string value)
		{
			return new SoapMonth(DateTime.ParseExact(value, SoapMonth.formats, CultureInfo.InvariantCulture, DateTimeStyles.None));
		}

		// Token: 0x0400275A RID: 10074
		private DateTime _value = DateTime.MinValue;

		// Token: 0x0400275B RID: 10075
		private static string[] formats = new string[]
		{
			"--MM--",
			"--MM--zzz"
		};
	}
}
