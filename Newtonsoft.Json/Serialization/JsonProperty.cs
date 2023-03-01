using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x02000092 RID: 146
	[NullableContext(2)]
	[Nullable(0)]
	public class JsonProperty
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x0001D3EC File Offset: 0x0001B5EC
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x0001D3F4 File Offset: 0x0001B5F4
		internal JsonContract PropertyContract { get; set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x0001D3FD File Offset: 0x0001B5FD
		// (set) Token: 0x0600071A RID: 1818 RVA: 0x0001D405 File Offset: 0x0001B605
		public string PropertyName
		{
			get
			{
				return this._propertyName;
			}
			set
			{
				this._propertyName = value;
				this._skipPropertyNameEscape = !JavaScriptUtils.ShouldEscapeJavaScriptString(this._propertyName, JavaScriptUtils.HtmlCharEscapeFlags);
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x0001D427 File Offset: 0x0001B627
		// (set) Token: 0x0600071C RID: 1820 RVA: 0x0001D42F File Offset: 0x0001B62F
		public Type DeclaringType { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x0001D438 File Offset: 0x0001B638
		// (set) Token: 0x0600071E RID: 1822 RVA: 0x0001D440 File Offset: 0x0001B640
		public int? Order { get; set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x0001D449 File Offset: 0x0001B649
		// (set) Token: 0x06000720 RID: 1824 RVA: 0x0001D451 File Offset: 0x0001B651
		public string UnderlyingName { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x0001D45A File Offset: 0x0001B65A
		// (set) Token: 0x06000722 RID: 1826 RVA: 0x0001D462 File Offset: 0x0001B662
		public IValueProvider ValueProvider { get; set; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x0001D46B File Offset: 0x0001B66B
		// (set) Token: 0x06000724 RID: 1828 RVA: 0x0001D473 File Offset: 0x0001B673
		public IAttributeProvider AttributeProvider { get; set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x0001D47C File Offset: 0x0001B67C
		// (set) Token: 0x06000726 RID: 1830 RVA: 0x0001D484 File Offset: 0x0001B684
		public Type PropertyType
		{
			get
			{
				return this._propertyType;
			}
			set
			{
				if (this._propertyType != value)
				{
					this._propertyType = value;
					this._hasGeneratedDefaultValue = false;
				}
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x0001D4A2 File Offset: 0x0001B6A2
		// (set) Token: 0x06000728 RID: 1832 RVA: 0x0001D4AA File Offset: 0x0001B6AA
		public JsonConverter Converter { get; set; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x0001D4B3 File Offset: 0x0001B6B3
		// (set) Token: 0x0600072A RID: 1834 RVA: 0x0001D4BB File Offset: 0x0001B6BB
		[Obsolete("MemberConverter is obsolete. Use Converter instead.")]
		public JsonConverter MemberConverter
		{
			get
			{
				return this.Converter;
			}
			set
			{
				this.Converter = value;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600072B RID: 1835 RVA: 0x0001D4C4 File Offset: 0x0001B6C4
		// (set) Token: 0x0600072C RID: 1836 RVA: 0x0001D4CC File Offset: 0x0001B6CC
		public bool Ignored { get; set; }

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x0001D4D5 File Offset: 0x0001B6D5
		// (set) Token: 0x0600072E RID: 1838 RVA: 0x0001D4DD File Offset: 0x0001B6DD
		public bool Readable { get; set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x0001D4E6 File Offset: 0x0001B6E6
		// (set) Token: 0x06000730 RID: 1840 RVA: 0x0001D4EE File Offset: 0x0001B6EE
		public bool Writable { get; set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000731 RID: 1841 RVA: 0x0001D4F7 File Offset: 0x0001B6F7
		// (set) Token: 0x06000732 RID: 1842 RVA: 0x0001D4FF File Offset: 0x0001B6FF
		public bool HasMemberAttribute { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x0001D508 File Offset: 0x0001B708
		// (set) Token: 0x06000734 RID: 1844 RVA: 0x0001D51A File Offset: 0x0001B71A
		public object DefaultValue
		{
			get
			{
				if (!this._hasExplicitDefaultValue)
				{
					return null;
				}
				return this._defaultValue;
			}
			set
			{
				this._hasExplicitDefaultValue = true;
				this._defaultValue = value;
			}
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0001D52A File Offset: 0x0001B72A
		internal object GetResolvedDefaultValue()
		{
			if (this._propertyType == null)
			{
				return null;
			}
			if (!this._hasExplicitDefaultValue && !this._hasGeneratedDefaultValue)
			{
				this._defaultValue = ReflectionUtils.GetDefaultValue(this._propertyType);
				this._hasGeneratedDefaultValue = true;
			}
			return this._defaultValue;
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x0001D56A File Offset: 0x0001B76A
		// (set) Token: 0x06000737 RID: 1847 RVA: 0x0001D577 File Offset: 0x0001B777
		public Required Required
		{
			get
			{
				return this._required.GetValueOrDefault();
			}
			set
			{
				this._required = new Required?(value);
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x0001D585 File Offset: 0x0001B785
		public bool IsRequiredSpecified
		{
			get
			{
				return this._required != null;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000739 RID: 1849 RVA: 0x0001D592 File Offset: 0x0001B792
		// (set) Token: 0x0600073A RID: 1850 RVA: 0x0001D59A File Offset: 0x0001B79A
		public bool? IsReference { get; set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600073B RID: 1851 RVA: 0x0001D5A3 File Offset: 0x0001B7A3
		// (set) Token: 0x0600073C RID: 1852 RVA: 0x0001D5AB File Offset: 0x0001B7AB
		public NullValueHandling? NullValueHandling { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600073D RID: 1853 RVA: 0x0001D5B4 File Offset: 0x0001B7B4
		// (set) Token: 0x0600073E RID: 1854 RVA: 0x0001D5BC File Offset: 0x0001B7BC
		public DefaultValueHandling? DefaultValueHandling { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x0001D5C5 File Offset: 0x0001B7C5
		// (set) Token: 0x06000740 RID: 1856 RVA: 0x0001D5CD File Offset: 0x0001B7CD
		public ReferenceLoopHandling? ReferenceLoopHandling { get; set; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x0001D5D6 File Offset: 0x0001B7D6
		// (set) Token: 0x06000742 RID: 1858 RVA: 0x0001D5DE File Offset: 0x0001B7DE
		public ObjectCreationHandling? ObjectCreationHandling { get; set; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x0001D5E7 File Offset: 0x0001B7E7
		// (set) Token: 0x06000744 RID: 1860 RVA: 0x0001D5EF File Offset: 0x0001B7EF
		public TypeNameHandling? TypeNameHandling { get; set; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x0001D5F8 File Offset: 0x0001B7F8
		// (set) Token: 0x06000746 RID: 1862 RVA: 0x0001D600 File Offset: 0x0001B800
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Predicate<object> ShouldSerialize { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x0001D609 File Offset: 0x0001B809
		// (set) Token: 0x06000748 RID: 1864 RVA: 0x0001D611 File Offset: 0x0001B811
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Predicate<object> ShouldDeserialize { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x0001D61A File Offset: 0x0001B81A
		// (set) Token: 0x0600074A RID: 1866 RVA: 0x0001D622 File Offset: 0x0001B822
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Predicate<object> GetIsSpecified { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600074B RID: 1867 RVA: 0x0001D62B File Offset: 0x0001B82B
		// (set) Token: 0x0600074C RID: 1868 RVA: 0x0001D633 File Offset: 0x0001B833
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		public Action<object, object> SetIsSpecified { [return: Nullable(new byte[]
		{
			2,
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			2
		})] set; }

		// Token: 0x0600074D RID: 1869 RVA: 0x0001D63C File Offset: 0x0001B83C
		[NullableContext(1)]
		public override string ToString()
		{
			return this.PropertyName ?? string.Empty;
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600074E RID: 1870 RVA: 0x0001D64D File Offset: 0x0001B84D
		// (set) Token: 0x0600074F RID: 1871 RVA: 0x0001D655 File Offset: 0x0001B855
		public JsonConverter ItemConverter { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x0001D65E File Offset: 0x0001B85E
		// (set) Token: 0x06000751 RID: 1873 RVA: 0x0001D666 File Offset: 0x0001B866
		public bool? ItemIsReference { get; set; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x0001D66F File Offset: 0x0001B86F
		// (set) Token: 0x06000753 RID: 1875 RVA: 0x0001D677 File Offset: 0x0001B877
		public TypeNameHandling? ItemTypeNameHandling { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x0001D680 File Offset: 0x0001B880
		// (set) Token: 0x06000755 RID: 1877 RVA: 0x0001D688 File Offset: 0x0001B888
		public ReferenceLoopHandling? ItemReferenceLoopHandling { get; set; }

		// Token: 0x06000756 RID: 1878 RVA: 0x0001D694 File Offset: 0x0001B894
		[NullableContext(1)]
		internal void WritePropertyName(JsonWriter writer)
		{
			string propertyName = this.PropertyName;
			if (this._skipPropertyNameEscape)
			{
				writer.WritePropertyName(propertyName, false);
				return;
			}
			writer.WritePropertyName(propertyName);
		}

		// Token: 0x04000287 RID: 647
		internal Required? _required;

		// Token: 0x04000288 RID: 648
		internal bool _hasExplicitDefaultValue;

		// Token: 0x04000289 RID: 649
		private object _defaultValue;

		// Token: 0x0400028A RID: 650
		private bool _hasGeneratedDefaultValue;

		// Token: 0x0400028B RID: 651
		private string _propertyName;

		// Token: 0x0400028C RID: 652
		internal bool _skipPropertyNameEscape;

		// Token: 0x0400028D RID: 653
		private Type _propertyType;
	}
}
