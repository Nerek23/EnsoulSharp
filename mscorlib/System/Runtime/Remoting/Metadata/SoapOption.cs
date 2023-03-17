using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata
{
	/// <summary>Specifies the SOAP configuration options for use with the <see cref="T:System.Runtime.Remoting.Metadata.SoapTypeAttribute" /> class.</summary>
	// Token: 0x020007A8 RID: 1960
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum SoapOption
	{
		/// <summary>The default option indicating that no extra options are selected.</summary>
		// Token: 0x04002710 RID: 10000
		None = 0,
		/// <summary>Indicates that type will always be included on SOAP elements. This option is useful when performing SOAP interop with SOAP implementations that require types on all elements.</summary>
		// Token: 0x04002711 RID: 10001
		AlwaysIncludeTypes = 1,
		/// <summary>Indicates that the output SOAP string type in a SOAP Envelope is using the <see langword="XSD" /> prefix, and that the resulting XML does not have an ID attribute for the string.</summary>
		// Token: 0x04002712 RID: 10002
		XsdString = 2,
		/// <summary>Indicates that SOAP will be generated without references. This option is currently not implemented.</summary>
		// Token: 0x04002713 RID: 10003
		EmbedAll = 4,
		/// <summary>Public reserved option for temporary interop conditions; the use will change.</summary>
		// Token: 0x04002714 RID: 10004
		Option1 = 8,
		/// <summary>Public reserved option for temporary interop conditions; the use will change.</summary>
		// Token: 0x04002715 RID: 10005
		Option2 = 16
	}
}
