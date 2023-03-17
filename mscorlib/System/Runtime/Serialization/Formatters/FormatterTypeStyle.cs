using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization.Formatters
{
	/// <summary>Indicates the format in which type descriptions are laid out in the serialized stream.</summary>
	// Token: 0x02000730 RID: 1840
	[ComVisible(true)]
	[Serializable]
	public enum FormatterTypeStyle
	{
		/// <summary>Indicates that types can be stated only for arrays of objects, object members of type <see cref="T:System.Object" />, and <see cref="T:System.Runtime.Serialization.ISerializable" /> non-primitive value types.</summary>
		// Token: 0x04002412 RID: 9234
		TypesWhenNeeded,
		/// <summary>Indicates that types can be given to all object members and <see cref="T:System.Runtime.Serialization.ISerializable" /> object members.</summary>
		// Token: 0x04002413 RID: 9235
		TypesAlways,
		/// <summary>Indicates that strings can be given in the XSD format rather than SOAP. No string IDs are transmitted.</summary>
		// Token: 0x04002414 RID: 9236
		XsdString
	}
}
