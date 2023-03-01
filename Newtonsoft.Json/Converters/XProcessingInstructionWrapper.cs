using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000FC RID: 252
	[NullableContext(2)]
	[Nullable(0)]
	internal class XProcessingInstructionWrapper : XObjectWrapper
	{
		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x00033285 File Offset: 0x00031485
		[Nullable(1)]
		private XProcessingInstruction ProcessingInstruction
		{
			[NullableContext(1)]
			get
			{
				return (XProcessingInstruction)base.WrappedNode;
			}
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x00033292 File Offset: 0x00031492
		[NullableContext(1)]
		public XProcessingInstructionWrapper(XProcessingInstruction processingInstruction) : base(processingInstruction)
		{
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x0003329B File Offset: 0x0003149B
		public override string LocalName
		{
			get
			{
				return this.ProcessingInstruction.Target;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x000332A8 File Offset: 0x000314A8
		// (set) Token: 0x06000CFB RID: 3323 RVA: 0x000332B5 File Offset: 0x000314B5
		public override string Value
		{
			get
			{
				return this.ProcessingInstruction.Data;
			}
			set
			{
				this.ProcessingInstruction.Data = value;
			}
		}
	}
}
