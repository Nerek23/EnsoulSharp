using System;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000212 RID: 530
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public class PropertyBindingAttribute : Attribute
	{
		// Token: 0x06000B96 RID: 2966 RVA: 0x00020DF0 File Offset: 0x0001EFF0
		public PropertyBindingAttribute(int order, string min, string max, string defaultValue) : this(PropertyType.Unknown, order, min, max, defaultValue)
		{
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00020DFE File Offset: 0x0001EFFE
		public PropertyBindingAttribute(PropertyType bindingType, int order, string min, string max, string defaultValue)
		{
			this.bindingType = bindingType;
			this.order = order;
			this.min = min;
			this.max = max;
			this.defaultValue = defaultValue;
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x00020E2B File Offset: 0x0001F02B
		public PropertyType BindingType
		{
			get
			{
				return this.bindingType;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x00020E33 File Offset: 0x0001F033
		public int Order
		{
			get
			{
				return this.order;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000B9A RID: 2970 RVA: 0x00020E3B File Offset: 0x0001F03B
		// (set) Token: 0x06000B9B RID: 2971 RVA: 0x00020E43 File Offset: 0x0001F043
		public string DisplayName { get; set; }

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000B9C RID: 2972 RVA: 0x00020E4C File Offset: 0x0001F04C
		// (set) Token: 0x06000B9D RID: 2973 RVA: 0x00020E54 File Offset: 0x0001F054
		public PropertyType Type { get; set; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x00020E5D File Offset: 0x0001F05D
		public string Min
		{
			get
			{
				return this.min;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x00020E65 File Offset: 0x0001F065
		public string Max
		{
			get
			{
				return this.max;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x00020E6D File Offset: 0x0001F06D
		public string Default
		{
			get
			{
				return this.defaultValue;
			}
		}

		// Token: 0x040006A5 RID: 1701
		private readonly PropertyType bindingType;

		// Token: 0x040006A6 RID: 1702
		private readonly int order;

		// Token: 0x040006A7 RID: 1703
		private readonly string min;

		// Token: 0x040006A8 RID: 1704
		private readonly string max;

		// Token: 0x040006A9 RID: 1705
		private readonly string defaultValue;
	}
}
