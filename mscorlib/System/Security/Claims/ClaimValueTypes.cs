using System;
using System.Runtime.InteropServices;

namespace System.Security.Claims
{
	/// <summary>Defines claim value types according to the type URIs defined by W3C and OASIS. This class cannot be inherited.</summary>
	// Token: 0x020002F3 RID: 755
	[ComVisible(false)]
	public static class ClaimValueTypes
	{
		// Token: 0x04000F2C RID: 3884
		private const string XmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";

		/// <summary>A URI that represents the <see langword="base64Binary" /> XML data type.</summary>
		// Token: 0x04000F2D RID: 3885
		public const string Base64Binary = "http://www.w3.org/2001/XMLSchema#base64Binary";

		/// <summary>A URI that represents the <see langword="base64Octet" /> XML data type.</summary>
		// Token: 0x04000F2E RID: 3886
		public const string Base64Octet = "http://www.w3.org/2001/XMLSchema#base64Octet";

		/// <summary>A URI that represents the <see langword="boolean" /> XML data type.</summary>
		// Token: 0x04000F2F RID: 3887
		public const string Boolean = "http://www.w3.org/2001/XMLSchema#boolean";

		/// <summary>A URI that represents the <see langword="date" /> XML data type.</summary>
		// Token: 0x04000F30 RID: 3888
		public const string Date = "http://www.w3.org/2001/XMLSchema#date";

		/// <summary>A URI that represents the <see langword="dateTime" /> XML data type.</summary>
		// Token: 0x04000F31 RID: 3889
		public const string DateTime = "http://www.w3.org/2001/XMLSchema#dateTime";

		/// <summary>A URI that represents the <see langword="double" /> XML data type.</summary>
		// Token: 0x04000F32 RID: 3890
		public const string Double = "http://www.w3.org/2001/XMLSchema#double";

		/// <summary>A URI that represents the <see langword="fqbn" /> XML data type.</summary>
		// Token: 0x04000F33 RID: 3891
		public const string Fqbn = "http://www.w3.org/2001/XMLSchema#fqbn";

		/// <summary>A URI that represents the <see langword="hexBinary" /> XML data type.</summary>
		// Token: 0x04000F34 RID: 3892
		public const string HexBinary = "http://www.w3.org/2001/XMLSchema#hexBinary";

		/// <summary>A URI that represents the <see langword="integer" /> XML data type.</summary>
		// Token: 0x04000F35 RID: 3893
		public const string Integer = "http://www.w3.org/2001/XMLSchema#integer";

		/// <summary>A URI that represents the <see langword="integer32" /> XML data type.</summary>
		// Token: 0x04000F36 RID: 3894
		public const string Integer32 = "http://www.w3.org/2001/XMLSchema#integer32";

		/// <summary>A URI that represents the <see langword="integer64" /> XML data type.</summary>
		// Token: 0x04000F37 RID: 3895
		public const string Integer64 = "http://www.w3.org/2001/XMLSchema#integer64";

		/// <summary>A URI that represents the <see langword="sid" /> XML data type.</summary>
		// Token: 0x04000F38 RID: 3896
		public const string Sid = "http://www.w3.org/2001/XMLSchema#sid";

		/// <summary>A URI that represents the <see langword="string" /> XML data type.</summary>
		// Token: 0x04000F39 RID: 3897
		public const string String = "http://www.w3.org/2001/XMLSchema#string";

		/// <summary>A URI that represents the <see langword="time" /> XML data type.</summary>
		// Token: 0x04000F3A RID: 3898
		public const string Time = "http://www.w3.org/2001/XMLSchema#time";

		/// <summary>A URI that represents the <see langword="uinteger32" /> XML data type.</summary>
		// Token: 0x04000F3B RID: 3899
		public const string UInteger32 = "http://www.w3.org/2001/XMLSchema#uinteger32";

		/// <summary>A URI that represents the <see langword="uinteger64" /> XML data type.</summary>
		// Token: 0x04000F3C RID: 3900
		public const string UInteger64 = "http://www.w3.org/2001/XMLSchema#uinteger64";

		// Token: 0x04000F3D RID: 3901
		private const string SoapSchemaNamespace = "http://schemas.xmlsoap.org/";

		/// <summary>A URI that represents the <see langword="dns" /> SOAP data type.</summary>
		// Token: 0x04000F3E RID: 3902
		public const string DnsName = "http://schemas.xmlsoap.org/claims/dns";

		/// <summary>A URI that represents the <see langword="emailaddress" /> SOAP data type.</summary>
		// Token: 0x04000F3F RID: 3903
		public const string Email = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";

		/// <summary>A URI that represents the <see langword="rsa" /> SOAP data type.</summary>
		// Token: 0x04000F40 RID: 3904
		public const string Rsa = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/rsa";

		/// <summary>A URI that represents the <see langword="UPN" /> SOAP data type.</summary>
		// Token: 0x04000F41 RID: 3905
		public const string UpnName = "http://schemas.xmlsoap.org/claims/UPN";

		// Token: 0x04000F42 RID: 3906
		private const string XmlSignatureConstantsNamespace = "http://www.w3.org/2000/09/xmldsig#";

		/// <summary>A URI that represents the <see langword="DSAKeyValue" /> XML Signature data type.</summary>
		// Token: 0x04000F43 RID: 3907
		public const string DsaKeyValue = "http://www.w3.org/2000/09/xmldsig#DSAKeyValue";

		/// <summary>A URI that represents the <see langword="KeyInfo" /> XML Signature data type.</summary>
		// Token: 0x04000F44 RID: 3908
		public const string KeyInfo = "http://www.w3.org/2000/09/xmldsig#KeyInfo";

		/// <summary>A URI that represents the <see langword="RSAKeyValue" /> XML Signature data type.</summary>
		// Token: 0x04000F45 RID: 3909
		public const string RsaKeyValue = "http://www.w3.org/2000/09/xmldsig#RSAKeyValue";

		// Token: 0x04000F46 RID: 3910
		private const string XQueryOperatorsNameSpace = "http://www.w3.org/TR/2002/WD-xquery-operators-20020816";

		/// <summary>A URI that represents the <see langword="daytimeDuration" /> XQuery data type.</summary>
		// Token: 0x04000F47 RID: 3911
		public const string DaytimeDuration = "http://www.w3.org/TR/2002/WD-xquery-operators-20020816#dayTimeDuration";

		/// <summary>A URI that represents the <see langword="yearMonthDuration" /> XQuery data type.</summary>
		// Token: 0x04000F48 RID: 3912
		public const string YearMonthDuration = "http://www.w3.org/TR/2002/WD-xquery-operators-20020816#yearMonthDuration";

		// Token: 0x04000F49 RID: 3913
		private const string Xacml10Namespace = "urn:oasis:names:tc:xacml:1.0";

		/// <summary>A URI that represents the <see langword="rfc822Name" /> XACML 1.0 data type.</summary>
		// Token: 0x04000F4A RID: 3914
		public const string Rfc822Name = "urn:oasis:names:tc:xacml:1.0:data-type:rfc822Name";

		/// <summary>A URI that represents the <see langword="x500Name" /> XACML 1.0 data type.</summary>
		// Token: 0x04000F4B RID: 3915
		public const string X500Name = "urn:oasis:names:tc:xacml:1.0:data-type:x500Name";
	}
}
