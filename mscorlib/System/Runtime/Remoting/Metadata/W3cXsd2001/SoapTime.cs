using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XSD <see langword="time" /> type.</summary>
	// Token: 0x020007B3 RID: 1971
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapTime : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E4B RID: 3659
		// (get) Token: 0x0600560A RID: 22026 RVA: 0x00130B98 File Offset: 0x0012ED98
		public static string XsdType
		{
			get
			{
				return "time";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x0600560B RID: 22027 RVA: 0x00130B9F File Offset: 0x0012ED9F
		public string GetXsdType()
		{
			return SoapTime.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapTime" /> class.</summary>
		// Token: 0x0600560C RID: 22028 RVA: 0x00130BA6 File Offset: 0x0012EDA6
		public SoapTime()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapTime" /> class with a specified <see cref="T:System.DateTime" /> object.</summary>
		/// <param name="value">A <see cref="T:System.DateTime" /> object to initialize the current instance.</param>
		// Token: 0x0600560D RID: 22029 RVA: 0x00130BB9 File Offset: 0x0012EDB9
		public SoapTime(DateTime value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets the date and time of the current instance.</summary>
		/// <returns>The <see cref="T:System.DateTime" /> object that contains the date and time of the current instance.</returns>
		// Token: 0x17000E4C RID: 3660
		// (get) Token: 0x0600560E RID: 22030 RVA: 0x00130BD3 File Offset: 0x0012EDD3
		// (set) Token: 0x0600560F RID: 22031 RVA: 0x00130BDB File Offset: 0x0012EDDB
		public DateTime Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = new DateTime(1, 1, 1, value.Hour, value.Minute, value.Second, value.Millisecond);
			}
		}

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapTime.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapTime.Value" /> in the format "HH:mm:ss.fffzzz".</returns>
		// Token: 0x06005610 RID: 22032 RVA: 0x00130C07 File Offset: 0x0012EE07
		public override string ToString()
		{
			return this._value.ToString("HH:mm:ss.fffffffzzz", CultureInfo.InvariantCulture);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapTime" /> object.</summary>
		/// <param name="value">The <see cref="T:System.String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapTime" /> object that is obtained from <paramref name="value" />.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">
		///   <paramref name="value" /> does not contain a date and time that corresponds to any of the recognized format patterns.</exception>
		// Token: 0x06005611 RID: 22033 RVA: 0x00130C20 File Offset: 0x0012EE20
		public static SoapTime Parse(string value)
		{
			string s = value;
			if (value.EndsWith("Z", StringComparison.Ordinal))
			{
				s = value.Substring(0, value.Length - 1) + "-00:00";
			}
			return new SoapTime(DateTime.ParseExact(s, SoapTime.formats, CultureInfo.InvariantCulture, DateTimeStyles.None));
		}

		// Token: 0x0400274B RID: 10059
		private DateTime _value = DateTime.MinValue;

		// Token: 0x0400274C RID: 10060
		private static string[] formats = new string[]
		{
			"HH:mm:ss.fffffffzzz",
			"HH:mm:ss.ffff",
			"HH:mm:ss.ffffzzz",
			"HH:mm:ss.fff",
			"HH:mm:ss.fffzzz",
			"HH:mm:ss.ff",
			"HH:mm:ss.ffzzz",
			"HH:mm:ss.f",
			"HH:mm:ss.fzzz",
			"HH:mm:ss",
			"HH:mm:sszzz",
			"HH:mm:ss.fffff",
			"HH:mm:ss.fffffzzz",
			"HH:mm:ss.ffffff",
			"HH:mm:ss.ffffffzzz",
			"HH:mm:ss.fffffff",
			"HH:mm:ss.ffffffff",
			"HH:mm:ss.ffffffffzzz",
			"HH:mm:ss.fffffffff",
			"HH:mm:ss.fffffffffzzz",
			"HH:mm:ss.fffffffff",
			"HH:mm:ss.fffffffffzzz"
		};
	}
}
