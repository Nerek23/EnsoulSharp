using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000FF RID: 255
	[NullableContext(2)]
	[Nullable(0)]
	internal class XAttributeWrapper : XObjectWrapper
	{
		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000D0E RID: 3342 RVA: 0x000334B0 File Offset: 0x000316B0
		[Nullable(1)]
		private XAttribute Attribute
		{
			[NullableContext(1)]
			get
			{
				return (XAttribute)base.WrappedNode;
			}
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x000334BD File Offset: 0x000316BD
		[NullableContext(1)]
		public XAttributeWrapper(XAttribute attribute) : base(attribute)
		{
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000D10 RID: 3344 RVA: 0x000334C6 File Offset: 0x000316C6
		// (set) Token: 0x06000D11 RID: 3345 RVA: 0x000334D3 File Offset: 0x000316D3
		public override string Value
		{
			get
			{
				return this.Attribute.Value;
			}
			set
			{
				this.Attribute.Value = value;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000D12 RID: 3346 RVA: 0x000334E1 File Offset: 0x000316E1
		public override string LocalName
		{
			get
			{
				return this.Attribute.Name.LocalName;
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000D13 RID: 3347 RVA: 0x000334F3 File Offset: 0x000316F3
		public override string NamespaceUri
		{
			get
			{
				return this.Attribute.Name.NamespaceName;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000D14 RID: 3348 RVA: 0x00033505 File Offset: 0x00031705
		public override IXmlNode ParentNode
		{
			get
			{
				if (this.Attribute.Parent == null)
				{
					return null;
				}
				return XContainerWrapper.WrapNode(this.Attribute.Parent);
			}
		}
	}
}
