using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x02000090 RID: 144
	[NullableContext(2)]
	[Nullable(0)]
	public class JsonObjectContract : JsonContainerContract
	{
		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060006FA RID: 1786 RVA: 0x0001D04E File Offset: 0x0001B24E
		// (set) Token: 0x060006FB RID: 1787 RVA: 0x0001D056 File Offset: 0x0001B256
		public MemberSerialization MemberSerialization { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x0001D05F File Offset: 0x0001B25F
		// (set) Token: 0x060006FD RID: 1789 RVA: 0x0001D067 File Offset: 0x0001B267
		public MissingMemberHandling? MissingMemberHandling { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x0001D070 File Offset: 0x0001B270
		// (set) Token: 0x060006FF RID: 1791 RVA: 0x0001D078 File Offset: 0x0001B278
		public Required? ItemRequired { get; set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x0001D081 File Offset: 0x0001B281
		// (set) Token: 0x06000701 RID: 1793 RVA: 0x0001D089 File Offset: 0x0001B289
		public NullValueHandling? ItemNullValueHandling { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000702 RID: 1794 RVA: 0x0001D092 File Offset: 0x0001B292
		[Nullable(1)]
		public JsonPropertyCollection Properties { [NullableContext(1)] get; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x0001D09A File Offset: 0x0001B29A
		[Nullable(1)]
		public JsonPropertyCollection CreatorParameters
		{
			[NullableContext(1)]
			get
			{
				if (this._creatorParameters == null)
				{
					this._creatorParameters = new JsonPropertyCollection(base.UnderlyingType);
				}
				return this._creatorParameters;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000704 RID: 1796 RVA: 0x0001D0BB File Offset: 0x0001B2BB
		// (set) Token: 0x06000705 RID: 1797 RVA: 0x0001D0C3 File Offset: 0x0001B2C3
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public ObjectConstructor<object> OverrideCreator
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return this._overrideCreator;
			}
			[param: Nullable(new byte[]
			{
				2,
				1
			})]
			set
			{
				this._overrideCreator = value;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x0001D0CC File Offset: 0x0001B2CC
		// (set) Token: 0x06000707 RID: 1799 RVA: 0x0001D0D4 File Offset: 0x0001B2D4
		[Nullable(new byte[]
		{
			2,
			1
		})]
		internal ObjectConstructor<object> ParameterizedCreator
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return this._parameterizedCreator;
			}
			[param: Nullable(new byte[]
			{
				2,
				1
			})]
			set
			{
				this._parameterizedCreator = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x0001D0DD File Offset: 0x0001B2DD
		// (set) Token: 0x06000709 RID: 1801 RVA: 0x0001D0E5 File Offset: 0x0001B2E5
		public ExtensionDataSetter ExtensionDataSetter { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600070A RID: 1802 RVA: 0x0001D0EE File Offset: 0x0001B2EE
		// (set) Token: 0x0600070B RID: 1803 RVA: 0x0001D0F6 File Offset: 0x0001B2F6
		public ExtensionDataGetter ExtensionDataGetter { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600070C RID: 1804 RVA: 0x0001D0FF File Offset: 0x0001B2FF
		// (set) Token: 0x0600070D RID: 1805 RVA: 0x0001D107 File Offset: 0x0001B307
		public Type ExtensionDataValueType
		{
			get
			{
				return this._extensionDataValueType;
			}
			set
			{
				this._extensionDataValueType = value;
				this.ExtensionDataIsJToken = (value != null && typeof(JToken).IsAssignableFrom(value));
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600070E RID: 1806 RVA: 0x0001D132 File Offset: 0x0001B332
		// (set) Token: 0x0600070F RID: 1807 RVA: 0x0001D13A File Offset: 0x0001B33A
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Func<string, string> ExtensionDataNameResolver { [return: Nullable(new byte[]
		{
			2,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1
		})] set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000710 RID: 1808 RVA: 0x0001D144 File Offset: 0x0001B344
		internal bool HasRequiredOrDefaultValueProperties
		{
			get
			{
				if (this._hasRequiredOrDefaultValueProperties == null)
				{
					this._hasRequiredOrDefaultValueProperties = new bool?(false);
					if (this.ItemRequired.GetValueOrDefault(Required.Default) != Required.Default)
					{
						this._hasRequiredOrDefaultValueProperties = new bool?(true);
					}
					else
					{
						foreach (JsonProperty jsonProperty in this.Properties)
						{
							if (jsonProperty.Required == Required.Default)
							{
								DefaultValueHandling? defaultValueHandling = jsonProperty.DefaultValueHandling & DefaultValueHandling.Populate;
								DefaultValueHandling defaultValueHandling2 = DefaultValueHandling.Populate;
								if (!(defaultValueHandling.GetValueOrDefault() == defaultValueHandling2 & defaultValueHandling != null))
								{
									continue;
								}
							}
							this._hasRequiredOrDefaultValueProperties = new bool?(true);
							break;
						}
					}
				}
				return this._hasRequiredOrDefaultValueProperties.GetValueOrDefault();
			}
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0001D230 File Offset: 0x0001B430
		[NullableContext(1)]
		public JsonObjectContract(Type underlyingType) : base(underlyingType)
		{
			this.ContractType = JsonContractType.Object;
			this.Properties = new JsonPropertyCollection(base.UnderlyingType);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0001D251 File Offset: 0x0001B451
		[NullableContext(1)]
		[SecuritySafeCritical]
		internal object GetUninitializedObject()
		{
			if (!JsonTypeReflector.FullyTrusted)
			{
				throw new JsonException("Insufficient permissions. Creating an uninitialized '{0}' type requires full trust.".FormatWith(CultureInfo.InvariantCulture, this.NonNullableUnderlyingType));
			}
			return FormatterServices.GetUninitializedObject(this.NonNullableUnderlyingType);
		}

		// Token: 0x0400027F RID: 639
		internal bool ExtensionDataIsJToken;

		// Token: 0x04000280 RID: 640
		private bool? _hasRequiredOrDefaultValueProperties;

		// Token: 0x04000281 RID: 641
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ObjectConstructor<object> _overrideCreator;

		// Token: 0x04000282 RID: 642
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ObjectConstructor<object> _parameterizedCreator;

		// Token: 0x04000283 RID: 643
		private JsonPropertyCollection _creatorParameters;

		// Token: 0x04000284 RID: 644
		private Type _extensionDataValueType;
	}
}
