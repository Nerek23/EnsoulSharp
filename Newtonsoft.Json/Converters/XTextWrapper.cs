using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000FA RID: 250
	[NullableContext(2)]
	[Nullable(0)]
	internal class XTextWrapper : XObjectWrapper
	{
		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000CED RID: 3309 RVA: 0x000331E1 File Offset: 0x000313E1
		[Nullable(1)]
		private XText Text
		{
			[NullableContext(1)]
			get
			{
				return (XText)base.WrappedNode;
			}
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x000331EE File Offset: 0x000313EE
		[NullableContext(1)]
		public XTextWrapper(XText text) : base(text)
		{
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000CEF RID: 3311 RVA: 0x000331F7 File Offset: 0x000313F7
		// (set) Token: 0x06000CF0 RID: 3312 RVA: 0x00033204 File Offset: 0x00031404
		public override string Value
		{
			get
			{
				return this.Text.Value;
			}
			set
			{
				this.Text.Value = value;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x00033212 File Offset: 0x00031412
		public override IXmlNode ParentNode
		{
			get
			{
				if (this.Text.Parent == null)
				{
					return null;
				}
				return XContainerWrapper.WrapNode(this.Text.Parent);
			}
		}
	}
}
