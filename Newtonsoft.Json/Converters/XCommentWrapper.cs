using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000FB RID: 251
	[NullableContext(2)]
	[Nullable(0)]
	internal class XCommentWrapper : XObjectWrapper
	{
		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x00033233 File Offset: 0x00031433
		[Nullable(1)]
		private XComment Text
		{
			[NullableContext(1)]
			get
			{
				return (XComment)base.WrappedNode;
			}
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x00033240 File Offset: 0x00031440
		[NullableContext(1)]
		public XCommentWrapper(XComment text) : base(text)
		{
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x00033249 File Offset: 0x00031449
		// (set) Token: 0x06000CF5 RID: 3317 RVA: 0x00033256 File Offset: 0x00031456
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

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x00033264 File Offset: 0x00031464
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
