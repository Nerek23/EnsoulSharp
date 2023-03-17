using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XSD <see langword="gDay" /> type.</summary>
	// Token: 0x020007B8 RID: 1976
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapDay : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E58 RID: 3672
		// (get) Token: 0x06005640 RID: 22080 RVA: 0x00131190 File Offset: 0x0012F390
		public static string XsdType
		{
			get
			{
				return "gDay";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x06005641 RID: 22081 RVA: 0x00131197 File Offset: 0x0012F397
		public string GetXsdType()
		{
			return SoapDay.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDay" /> class.</summary>
		// Token: 0x06005642 RID: 22082 RVA: 0x0013119E File Offset: 0x0012F39E
		public SoapDay()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDay" /> class with a specified <see cref="T:System.DateTime" /> object.</summary>
		/// <param name="value">A <see cref="T:System.DateTime" /> object to initialize the current instance.</param>
		// Token: 0x06005643 RID: 22083 RVA: 0x001311B1 File Offset: 0x0012F3B1
		public SoapDay(DateTime value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets the date and time of the current instance.</summary>
		/// <returns>The <see cref="T:System.DateTime" /> object that contains the date and time of the current instance.</returns>
		// Token: 0x17000E59 RID: 3673
		// (get) Token: 0x06005644 RID: 22084 RVA: 0x001311CB File Offset: 0x0012F3CB
		// (set) Token: 0x06005645 RID: 22085 RVA: 0x001311D3 File Offset: 0x0012F3D3
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

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDay.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDay.Value" /> in the format "---dd".</returns>
		// Token: 0x06005646 RID: 22086 RVA: 0x001311DC File Offset: 0x0012F3DC
		public override string ToString()
		{
			return this._value.ToString("---dd", CultureInfo.InvariantCulture);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDay" /> object.</summary>
		/// <param name="value">The <see cref="T:System.String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDay" /> object that is obtained from <paramref name="value" />.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">
		///   <paramref name="value" /> does not contain a date and time that corresponds to any of the recognized format patterns.</exception>
		// Token: 0x06005647 RID: 22087 RVA: 0x001311F3 File Offset: 0x0012F3F3
		public static SoapDay Parse(string value)
		{
			return new SoapDay(DateTime.ParseExact(value, SoapDay.formats, CultureInfo.InvariantCulture, DateTimeStyles.None));
		}

		// Token: 0x04002758 RID: 10072
		private DateTime _value = DateTime.MinValue;

		// Token: 0x04002759 RID: 10073
		private static string[] formats = new string[]
		{
			"---dd",
			"---ddzzz"
		};
	}
}
