using System;

namespace Newtonsoft.Json.Linq
{
	// Token: 0x020000C3 RID: 195
	public class JsonMergeSettings
	{
		// Token: 0x06000AB5 RID: 2741 RVA: 0x0002AC4D File Offset: 0x00028E4D
		public JsonMergeSettings()
		{
			this._propertyNameComparison = StringComparison.Ordinal;
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x0002AC5C File Offset: 0x00028E5C
		// (set) Token: 0x06000AB7 RID: 2743 RVA: 0x0002AC64 File Offset: 0x00028E64
		public MergeArrayHandling MergeArrayHandling
		{
			get
			{
				return this._mergeArrayHandling;
			}
			set
			{
				if (value < MergeArrayHandling.Concat || value > MergeArrayHandling.Merge)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._mergeArrayHandling = value;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x0002AC80 File Offset: 0x00028E80
		// (set) Token: 0x06000AB9 RID: 2745 RVA: 0x0002AC88 File Offset: 0x00028E88
		public MergeNullValueHandling MergeNullValueHandling
		{
			get
			{
				return this._mergeNullValueHandling;
			}
			set
			{
				if (value < MergeNullValueHandling.Ignore || value > MergeNullValueHandling.Merge)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._mergeNullValueHandling = value;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000ABA RID: 2746 RVA: 0x0002ACA4 File Offset: 0x00028EA4
		// (set) Token: 0x06000ABB RID: 2747 RVA: 0x0002ACAC File Offset: 0x00028EAC
		public StringComparison PropertyNameComparison
		{
			get
			{
				return this._propertyNameComparison;
			}
			set
			{
				if (value < StringComparison.CurrentCulture || value > StringComparison.OrdinalIgnoreCase)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._propertyNameComparison = value;
			}
		}

		// Token: 0x04000371 RID: 881
		private MergeArrayHandling _mergeArrayHandling;

		// Token: 0x04000372 RID: 882
		private MergeNullValueHandling _mergeNullValueHandling;

		// Token: 0x04000373 RID: 883
		private StringComparison _propertyNameComparison;
	}
}
