using System;

namespace Newtonsoft.Json.Linq
{
	// Token: 0x020000C2 RID: 194
	public class JsonLoadSettings
	{
		// Token: 0x06000AAE RID: 2734 RVA: 0x0002ABC4 File Offset: 0x00028DC4
		public JsonLoadSettings()
		{
			this._lineInfoHandling = LineInfoHandling.Load;
			this._commentHandling = CommentHandling.Ignore;
			this._duplicatePropertyNameHandling = DuplicatePropertyNameHandling.Replace;
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000AAF RID: 2735 RVA: 0x0002ABE1 File Offset: 0x00028DE1
		// (set) Token: 0x06000AB0 RID: 2736 RVA: 0x0002ABE9 File Offset: 0x00028DE9
		public CommentHandling CommentHandling
		{
			get
			{
				return this._commentHandling;
			}
			set
			{
				if (value < CommentHandling.Ignore || value > CommentHandling.Load)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._commentHandling = value;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000AB1 RID: 2737 RVA: 0x0002AC05 File Offset: 0x00028E05
		// (set) Token: 0x06000AB2 RID: 2738 RVA: 0x0002AC0D File Offset: 0x00028E0D
		public LineInfoHandling LineInfoHandling
		{
			get
			{
				return this._lineInfoHandling;
			}
			set
			{
				if (value < LineInfoHandling.Ignore || value > LineInfoHandling.Load)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._lineInfoHandling = value;
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000AB3 RID: 2739 RVA: 0x0002AC29 File Offset: 0x00028E29
		// (set) Token: 0x06000AB4 RID: 2740 RVA: 0x0002AC31 File Offset: 0x00028E31
		public DuplicatePropertyNameHandling DuplicatePropertyNameHandling
		{
			get
			{
				return this._duplicatePropertyNameHandling;
			}
			set
			{
				if (value < DuplicatePropertyNameHandling.Replace || value > DuplicatePropertyNameHandling.Error)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._duplicatePropertyNameHandling = value;
			}
		}

		// Token: 0x0400036E RID: 878
		private CommentHandling _commentHandling;

		// Token: 0x0400036F RID: 879
		private LineInfoHandling _lineInfoHandling;

		// Token: 0x04000370 RID: 880
		private DuplicatePropertyNameHandling _duplicatePropertyNameHandling;
	}
}
