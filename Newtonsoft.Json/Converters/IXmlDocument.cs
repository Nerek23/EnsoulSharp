using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000F2 RID: 242
	[NullableContext(1)]
	internal interface IXmlDocument : IXmlNode
	{
		// Token: 0x06000CAA RID: 3242
		IXmlNode CreateComment([Nullable(2)] string text);

		// Token: 0x06000CAB RID: 3243
		IXmlNode CreateTextNode([Nullable(2)] string text);

		// Token: 0x06000CAC RID: 3244
		IXmlNode CreateCDataSection([Nullable(2)] string data);

		// Token: 0x06000CAD RID: 3245
		IXmlNode CreateWhitespace([Nullable(2)] string text);

		// Token: 0x06000CAE RID: 3246
		IXmlNode CreateSignificantWhitespace([Nullable(2)] string text);

		// Token: 0x06000CAF RID: 3247
		[NullableContext(2)]
		[return: Nullable(1)]
		IXmlNode CreateXmlDeclaration(string version, string encoding, string standalone);

		// Token: 0x06000CB0 RID: 3248
		[NullableContext(2)]
		[return: Nullable(1)]
		IXmlNode CreateXmlDocumentType(string name, string publicId, string systemId, string internalSubset);

		// Token: 0x06000CB1 RID: 3249
		IXmlNode CreateProcessingInstruction(string target, [Nullable(2)] string data);

		// Token: 0x06000CB2 RID: 3250
		IXmlElement CreateElement(string elementName);

		// Token: 0x06000CB3 RID: 3251
		IXmlElement CreateElement(string qualifiedName, string namespaceUri);

		// Token: 0x06000CB4 RID: 3252
		IXmlNode CreateAttribute(string name, [Nullable(2)] string value);

		// Token: 0x06000CB5 RID: 3253
		IXmlNode CreateAttribute(string qualifiedName, string namespaceUri, [Nullable(2)] string value);

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000CB6 RID: 3254
		[Nullable(2)]
		IXmlElement DocumentElement { [NullableContext(2)] get; }
	}
}
