using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000FE RID: 254
	[NullableContext(2)]
	[Nullable(0)]
	internal class XObjectWrapper : IXmlNode
	{
		// Token: 0x06000D03 RID: 3331 RVA: 0x0003345E File Offset: 0x0003165E
		public XObjectWrapper(XObject xmlObject)
		{
			this._xmlObject = xmlObject;
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000D04 RID: 3332 RVA: 0x0003346D File Offset: 0x0003166D
		public object WrappedNode
		{
			get
			{
				return this._xmlObject;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000D05 RID: 3333 RVA: 0x00033475 File Offset: 0x00031675
		public virtual XmlNodeType NodeType
		{
			get
			{
				XObject xmlObject = this._xmlObject;
				if (xmlObject == null)
				{
					return XmlNodeType.None;
				}
				return xmlObject.NodeType;
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000D06 RID: 3334 RVA: 0x00033488 File Offset: 0x00031688
		public virtual string LocalName
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000D07 RID: 3335 RVA: 0x0003348B File Offset: 0x0003168B
		[Nullable(1)]
		public virtual List<IXmlNode> ChildNodes
		{
			[NullableContext(1)]
			get
			{
				return XmlNodeConverter.EmptyChildNodes;
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000D08 RID: 3336 RVA: 0x00033492 File Offset: 0x00031692
		[Nullable(1)]
		public virtual List<IXmlNode> Attributes
		{
			[NullableContext(1)]
			get
			{
				return XmlNodeConverter.EmptyChildNodes;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000D09 RID: 3337 RVA: 0x00033499 File Offset: 0x00031699
		public virtual IXmlNode ParentNode
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000D0A RID: 3338 RVA: 0x0003349C File Offset: 0x0003169C
		// (set) Token: 0x06000D0B RID: 3339 RVA: 0x0003349F File Offset: 0x0003169F
		public virtual string Value
		{
			get
			{
				return null;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x000334A6 File Offset: 0x000316A6
		[NullableContext(1)]
		public virtual IXmlNode AppendChild(IXmlNode newChild)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000D0D RID: 3341 RVA: 0x000334AD File Offset: 0x000316AD
		public virtual string NamespaceUri
		{
			get
			{
				return null;
			}
		}

		// Token: 0x040003EF RID: 1007
		private readonly XObject _xmlObject;
	}
}
