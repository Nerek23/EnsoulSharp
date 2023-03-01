using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json
{
	// Token: 0x0200002C RID: 44
	[NullableContext(2)]
	[Nullable(0)]
	public class JsonSerializerSettings
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000197 RID: 407 RVA: 0x00005D31 File Offset: 0x00003F31
		// (set) Token: 0x06000198 RID: 408 RVA: 0x00005D3E File Offset: 0x00003F3E
		public ReferenceLoopHandling ReferenceLoopHandling
		{
			get
			{
				return this._referenceLoopHandling.GetValueOrDefault();
			}
			set
			{
				this._referenceLoopHandling = new ReferenceLoopHandling?(value);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000199 RID: 409 RVA: 0x00005D4C File Offset: 0x00003F4C
		// (set) Token: 0x0600019A RID: 410 RVA: 0x00005D59 File Offset: 0x00003F59
		public MissingMemberHandling MissingMemberHandling
		{
			get
			{
				return this._missingMemberHandling.GetValueOrDefault();
			}
			set
			{
				this._missingMemberHandling = new MissingMemberHandling?(value);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00005D67 File Offset: 0x00003F67
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00005D74 File Offset: 0x00003F74
		public ObjectCreationHandling ObjectCreationHandling
		{
			get
			{
				return this._objectCreationHandling.GetValueOrDefault();
			}
			set
			{
				this._objectCreationHandling = new ObjectCreationHandling?(value);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00005D82 File Offset: 0x00003F82
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00005D8F File Offset: 0x00003F8F
		public NullValueHandling NullValueHandling
		{
			get
			{
				return this._nullValueHandling.GetValueOrDefault();
			}
			set
			{
				this._nullValueHandling = new NullValueHandling?(value);
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00005D9D File Offset: 0x00003F9D
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x00005DAA File Offset: 0x00003FAA
		public DefaultValueHandling DefaultValueHandling
		{
			get
			{
				return this._defaultValueHandling.GetValueOrDefault();
			}
			set
			{
				this._defaultValueHandling = new DefaultValueHandling?(value);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00005DB8 File Offset: 0x00003FB8
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x00005DC0 File Offset: 0x00003FC0
		[Nullable(1)]
		public IList<JsonConverter> Converters { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00005DC9 File Offset: 0x00003FC9
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x00005DD6 File Offset: 0x00003FD6
		public PreserveReferencesHandling PreserveReferencesHandling
		{
			get
			{
				return this._preserveReferencesHandling.GetValueOrDefault();
			}
			set
			{
				this._preserveReferencesHandling = new PreserveReferencesHandling?(value);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00005DE4 File Offset: 0x00003FE4
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00005DF1 File Offset: 0x00003FF1
		public TypeNameHandling TypeNameHandling
		{
			get
			{
				return this._typeNameHandling.GetValueOrDefault();
			}
			set
			{
				this._typeNameHandling = new TypeNameHandling?(value);
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00005DFF File Offset: 0x00003FFF
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x00005E0C File Offset: 0x0000400C
		public MetadataPropertyHandling MetadataPropertyHandling
		{
			get
			{
				return this._metadataPropertyHandling.GetValueOrDefault();
			}
			set
			{
				this._metadataPropertyHandling = new MetadataPropertyHandling?(value);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00005E1A File Offset: 0x0000401A
		// (set) Token: 0x060001AA RID: 426 RVA: 0x00005E22 File Offset: 0x00004022
		[Obsolete("TypeNameAssemblyFormat is obsolete. Use TypeNameAssemblyFormatHandling instead.")]
		public FormatterAssemblyStyle TypeNameAssemblyFormat
		{
			get
			{
				return (FormatterAssemblyStyle)this.TypeNameAssemblyFormatHandling;
			}
			set
			{
				this.TypeNameAssemblyFormatHandling = (TypeNameAssemblyFormatHandling)value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00005E2B File Offset: 0x0000402B
		// (set) Token: 0x060001AC RID: 428 RVA: 0x00005E38 File Offset: 0x00004038
		public TypeNameAssemblyFormatHandling TypeNameAssemblyFormatHandling
		{
			get
			{
				return this._typeNameAssemblyFormatHandling.GetValueOrDefault();
			}
			set
			{
				this._typeNameAssemblyFormatHandling = new TypeNameAssemblyFormatHandling?(value);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00005E46 File Offset: 0x00004046
		// (set) Token: 0x060001AE RID: 430 RVA: 0x00005E53 File Offset: 0x00004053
		public ConstructorHandling ConstructorHandling
		{
			get
			{
				return this._constructorHandling.GetValueOrDefault();
			}
			set
			{
				this._constructorHandling = new ConstructorHandling?(value);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00005E61 File Offset: 0x00004061
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x00005E69 File Offset: 0x00004069
		public IContractResolver ContractResolver { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00005E72 File Offset: 0x00004072
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x00005E7A File Offset: 0x0000407A
		public IEqualityComparer EqualityComparer { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00005E83 File Offset: 0x00004083
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x00005E98 File Offset: 0x00004098
		[Obsolete("ReferenceResolver property is obsolete. Use the ReferenceResolverProvider property to set the IReferenceResolver: settings.ReferenceResolverProvider = () => resolver")]
		public IReferenceResolver ReferenceResolver
		{
			get
			{
				Func<IReferenceResolver> referenceResolverProvider = this.ReferenceResolverProvider;
				if (referenceResolverProvider == null)
				{
					return null;
				}
				return referenceResolverProvider();
			}
			set
			{
				this.ReferenceResolverProvider = ((value != null) ? (() => value) : null);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00005ECF File Offset: 0x000040CF
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x00005ED7 File Offset: 0x000040D7
		public Func<IReferenceResolver> ReferenceResolverProvider { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00005EE0 File Offset: 0x000040E0
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00005EE8 File Offset: 0x000040E8
		public ITraceWriter TraceWriter { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00005EF4 File Offset: 0x000040F4
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00005F2B File Offset: 0x0000412B
		[Obsolete("Binder is obsolete. Use SerializationBinder instead.")]
		public SerializationBinder Binder
		{
			get
			{
				if (this.SerializationBinder == null)
				{
					return null;
				}
				SerializationBinderAdapter serializationBinderAdapter = this.SerializationBinder as SerializationBinderAdapter;
				if (serializationBinderAdapter != null)
				{
					return serializationBinderAdapter.SerializationBinder;
				}
				throw new InvalidOperationException("Cannot get SerializationBinder because an ISerializationBinder was previously set.");
			}
			set
			{
				this.SerializationBinder = ((value == null) ? null : new SerializationBinderAdapter(value));
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00005F3F File Offset: 0x0000413F
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00005F47 File Offset: 0x00004147
		public ISerializationBinder SerializationBinder { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00005F50 File Offset: 0x00004150
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00005F58 File Offset: 0x00004158
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public EventHandler<ErrorEventArgs> Error { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00005F64 File Offset: 0x00004164
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00005F8E File Offset: 0x0000418E
		public StreamingContext Context
		{
			get
			{
				StreamingContext? context = this._context;
				if (context == null)
				{
					return JsonSerializerSettings.DefaultContext;
				}
				return context.GetValueOrDefault();
			}
			set
			{
				this._context = new StreamingContext?(value);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00005F9C File Offset: 0x0000419C
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00005FAD File Offset: 0x000041AD
		[Nullable(1)]
		public string DateFormatString
		{
			[NullableContext(1)]
			get
			{
				return this._dateFormatString ?? "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";
			}
			[NullableContext(1)]
			set
			{
				this._dateFormatString = value;
				this._dateFormatStringSet = true;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00005FBD File Offset: 0x000041BD
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00005FC8 File Offset: 0x000041C8
		public int? MaxDepth
		{
			get
			{
				return this._maxDepth;
			}
			set
			{
				int? num = value;
				int num2 = 0;
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					throw new ArgumentException("Value must be positive.", "value");
				}
				this._maxDepth = value;
				this._maxDepthSet = true;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x0000600E File Offset: 0x0000420E
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x0000601B File Offset: 0x0000421B
		public Formatting Formatting
		{
			get
			{
				return this._formatting.GetValueOrDefault();
			}
			set
			{
				this._formatting = new Formatting?(value);
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00006029 File Offset: 0x00004229
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00006036 File Offset: 0x00004236
		public DateFormatHandling DateFormatHandling
		{
			get
			{
				return this._dateFormatHandling.GetValueOrDefault();
			}
			set
			{
				this._dateFormatHandling = new DateFormatHandling?(value);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00006044 File Offset: 0x00004244
		// (set) Token: 0x060001CA RID: 458 RVA: 0x0000606A File Offset: 0x0000426A
		public DateTimeZoneHandling DateTimeZoneHandling
		{
			get
			{
				DateTimeZoneHandling? dateTimeZoneHandling = this._dateTimeZoneHandling;
				if (dateTimeZoneHandling == null)
				{
					return DateTimeZoneHandling.RoundtripKind;
				}
				return dateTimeZoneHandling.GetValueOrDefault();
			}
			set
			{
				this._dateTimeZoneHandling = new DateTimeZoneHandling?(value);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00006078 File Offset: 0x00004278
		// (set) Token: 0x060001CC RID: 460 RVA: 0x0000609E File Offset: 0x0000429E
		public DateParseHandling DateParseHandling
		{
			get
			{
				DateParseHandling? dateParseHandling = this._dateParseHandling;
				if (dateParseHandling == null)
				{
					return DateParseHandling.DateTime;
				}
				return dateParseHandling.GetValueOrDefault();
			}
			set
			{
				this._dateParseHandling = new DateParseHandling?(value);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001CD RID: 461 RVA: 0x000060AC File Offset: 0x000042AC
		// (set) Token: 0x060001CE RID: 462 RVA: 0x000060B9 File Offset: 0x000042B9
		public FloatFormatHandling FloatFormatHandling
		{
			get
			{
				return this._floatFormatHandling.GetValueOrDefault();
			}
			set
			{
				this._floatFormatHandling = new FloatFormatHandling?(value);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001CF RID: 463 RVA: 0x000060C7 File Offset: 0x000042C7
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x000060D4 File Offset: 0x000042D4
		public FloatParseHandling FloatParseHandling
		{
			get
			{
				return this._floatParseHandling.GetValueOrDefault();
			}
			set
			{
				this._floatParseHandling = new FloatParseHandling?(value);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x000060E2 File Offset: 0x000042E2
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x000060EF File Offset: 0x000042EF
		public StringEscapeHandling StringEscapeHandling
		{
			get
			{
				return this._stringEscapeHandling.GetValueOrDefault();
			}
			set
			{
				this._stringEscapeHandling = new StringEscapeHandling?(value);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x000060FD File Offset: 0x000042FD
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x0000610E File Offset: 0x0000430E
		[Nullable(1)]
		public CultureInfo Culture
		{
			[NullableContext(1)]
			get
			{
				return this._culture ?? JsonSerializerSettings.DefaultCulture;
			}
			[NullableContext(1)]
			set
			{
				this._culture = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00006117 File Offset: 0x00004317
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00006124 File Offset: 0x00004324
		public bool CheckAdditionalContent
		{
			get
			{
				return this._checkAdditionalContent.GetValueOrDefault();
			}
			set
			{
				this._checkAdditionalContent = new bool?(value);
			}
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00006149 File Offset: 0x00004349
		[DebuggerStepThrough]
		public JsonSerializerSettings()
		{
			this.Converters = new List<JsonConverter>();
		}

		// Token: 0x04000092 RID: 146
		internal const ReferenceLoopHandling DefaultReferenceLoopHandling = ReferenceLoopHandling.Error;

		// Token: 0x04000093 RID: 147
		internal const MissingMemberHandling DefaultMissingMemberHandling = MissingMemberHandling.Ignore;

		// Token: 0x04000094 RID: 148
		internal const NullValueHandling DefaultNullValueHandling = NullValueHandling.Include;

		// Token: 0x04000095 RID: 149
		internal const DefaultValueHandling DefaultDefaultValueHandling = DefaultValueHandling.Include;

		// Token: 0x04000096 RID: 150
		internal const ObjectCreationHandling DefaultObjectCreationHandling = ObjectCreationHandling.Auto;

		// Token: 0x04000097 RID: 151
		internal const PreserveReferencesHandling DefaultPreserveReferencesHandling = PreserveReferencesHandling.None;

		// Token: 0x04000098 RID: 152
		internal const ConstructorHandling DefaultConstructorHandling = ConstructorHandling.Default;

		// Token: 0x04000099 RID: 153
		internal const TypeNameHandling DefaultTypeNameHandling = TypeNameHandling.None;

		// Token: 0x0400009A RID: 154
		internal const MetadataPropertyHandling DefaultMetadataPropertyHandling = MetadataPropertyHandling.Default;

		// Token: 0x0400009B RID: 155
		internal static readonly StreamingContext DefaultContext = default(StreamingContext);

		// Token: 0x0400009C RID: 156
		internal const Formatting DefaultFormatting = Formatting.None;

		// Token: 0x0400009D RID: 157
		internal const DateFormatHandling DefaultDateFormatHandling = DateFormatHandling.IsoDateFormat;

		// Token: 0x0400009E RID: 158
		internal const DateTimeZoneHandling DefaultDateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;

		// Token: 0x0400009F RID: 159
		internal const DateParseHandling DefaultDateParseHandling = DateParseHandling.DateTime;

		// Token: 0x040000A0 RID: 160
		internal const FloatParseHandling DefaultFloatParseHandling = FloatParseHandling.Double;

		// Token: 0x040000A1 RID: 161
		internal const FloatFormatHandling DefaultFloatFormatHandling = FloatFormatHandling.String;

		// Token: 0x040000A2 RID: 162
		internal const StringEscapeHandling DefaultStringEscapeHandling = StringEscapeHandling.Default;

		// Token: 0x040000A3 RID: 163
		internal const TypeNameAssemblyFormatHandling DefaultTypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple;

		// Token: 0x040000A4 RID: 164
		[Nullable(1)]
		internal static readonly CultureInfo DefaultCulture = CultureInfo.InvariantCulture;

		// Token: 0x040000A5 RID: 165
		internal const bool DefaultCheckAdditionalContent = false;

		// Token: 0x040000A6 RID: 166
		[Nullable(1)]
		internal const string DefaultDateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

		// Token: 0x040000A7 RID: 167
		internal Formatting? _formatting;

		// Token: 0x040000A8 RID: 168
		internal DateFormatHandling? _dateFormatHandling;

		// Token: 0x040000A9 RID: 169
		internal DateTimeZoneHandling? _dateTimeZoneHandling;

		// Token: 0x040000AA RID: 170
		internal DateParseHandling? _dateParseHandling;

		// Token: 0x040000AB RID: 171
		internal FloatFormatHandling? _floatFormatHandling;

		// Token: 0x040000AC RID: 172
		internal FloatParseHandling? _floatParseHandling;

		// Token: 0x040000AD RID: 173
		internal StringEscapeHandling? _stringEscapeHandling;

		// Token: 0x040000AE RID: 174
		internal CultureInfo _culture;

		// Token: 0x040000AF RID: 175
		internal bool? _checkAdditionalContent;

		// Token: 0x040000B0 RID: 176
		internal int? _maxDepth;

		// Token: 0x040000B1 RID: 177
		internal bool _maxDepthSet;

		// Token: 0x040000B2 RID: 178
		internal string _dateFormatString;

		// Token: 0x040000B3 RID: 179
		internal bool _dateFormatStringSet;

		// Token: 0x040000B4 RID: 180
		internal TypeNameAssemblyFormatHandling? _typeNameAssemblyFormatHandling;

		// Token: 0x040000B5 RID: 181
		internal DefaultValueHandling? _defaultValueHandling;

		// Token: 0x040000B6 RID: 182
		internal PreserveReferencesHandling? _preserveReferencesHandling;

		// Token: 0x040000B7 RID: 183
		internal NullValueHandling? _nullValueHandling;

		// Token: 0x040000B8 RID: 184
		internal ObjectCreationHandling? _objectCreationHandling;

		// Token: 0x040000B9 RID: 185
		internal MissingMemberHandling? _missingMemberHandling;

		// Token: 0x040000BA RID: 186
		internal ReferenceLoopHandling? _referenceLoopHandling;

		// Token: 0x040000BB RID: 187
		internal StreamingContext? _context;

		// Token: 0x040000BC RID: 188
		internal ConstructorHandling? _constructorHandling;

		// Token: 0x040000BD RID: 189
		internal TypeNameHandling? _typeNameHandling;

		// Token: 0x040000BE RID: 190
		internal MetadataPropertyHandling? _metadataPropertyHandling;
	}
}
