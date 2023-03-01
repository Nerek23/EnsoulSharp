using System;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x02000097 RID: 151
	[NullableContext(1)]
	[Nullable(0)]
	internal class JsonSerializerProxy : JsonSerializer
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060007BC RID: 1980 RVA: 0x00022F79 File Offset: 0x00021179
		// (remove) Token: 0x060007BD RID: 1981 RVA: 0x00022F87 File Offset: 0x00021187
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public override event EventHandler<ErrorEventArgs> Error
		{
			add
			{
				this._serializer.Error += value;
			}
			remove
			{
				this._serializer.Error -= value;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x00022F95 File Offset: 0x00021195
		// (set) Token: 0x060007BF RID: 1983 RVA: 0x00022FA2 File Offset: 0x000211A2
		[Nullable(2)]
		public override IReferenceResolver ReferenceResolver
		{
			[NullableContext(2)]
			get
			{
				return this._serializer.ReferenceResolver;
			}
			[NullableContext(2)]
			set
			{
				this._serializer.ReferenceResolver = value;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060007C0 RID: 1984 RVA: 0x00022FB0 File Offset: 0x000211B0
		// (set) Token: 0x060007C1 RID: 1985 RVA: 0x00022FBD File Offset: 0x000211BD
		[Nullable(2)]
		public override ITraceWriter TraceWriter
		{
			[NullableContext(2)]
			get
			{
				return this._serializer.TraceWriter;
			}
			[NullableContext(2)]
			set
			{
				this._serializer.TraceWriter = value;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x00022FCB File Offset: 0x000211CB
		// (set) Token: 0x060007C3 RID: 1987 RVA: 0x00022FD8 File Offset: 0x000211D8
		[Nullable(2)]
		public override IEqualityComparer EqualityComparer
		{
			[NullableContext(2)]
			get
			{
				return this._serializer.EqualityComparer;
			}
			[NullableContext(2)]
			set
			{
				this._serializer.EqualityComparer = value;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x00022FE6 File Offset: 0x000211E6
		public override JsonConverterCollection Converters
		{
			get
			{
				return this._serializer.Converters;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060007C5 RID: 1989 RVA: 0x00022FF3 File Offset: 0x000211F3
		// (set) Token: 0x060007C6 RID: 1990 RVA: 0x00023000 File Offset: 0x00021200
		public override DefaultValueHandling DefaultValueHandling
		{
			get
			{
				return this._serializer.DefaultValueHandling;
			}
			set
			{
				this._serializer.DefaultValueHandling = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x0002300E File Offset: 0x0002120E
		// (set) Token: 0x060007C8 RID: 1992 RVA: 0x0002301B File Offset: 0x0002121B
		public override IContractResolver ContractResolver
		{
			get
			{
				return this._serializer.ContractResolver;
			}
			set
			{
				this._serializer.ContractResolver = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060007C9 RID: 1993 RVA: 0x00023029 File Offset: 0x00021229
		// (set) Token: 0x060007CA RID: 1994 RVA: 0x00023036 File Offset: 0x00021236
		public override MissingMemberHandling MissingMemberHandling
		{
			get
			{
				return this._serializer.MissingMemberHandling;
			}
			set
			{
				this._serializer.MissingMemberHandling = value;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060007CB RID: 1995 RVA: 0x00023044 File Offset: 0x00021244
		// (set) Token: 0x060007CC RID: 1996 RVA: 0x00023051 File Offset: 0x00021251
		public override NullValueHandling NullValueHandling
		{
			get
			{
				return this._serializer.NullValueHandling;
			}
			set
			{
				this._serializer.NullValueHandling = value;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x0002305F File Offset: 0x0002125F
		// (set) Token: 0x060007CE RID: 1998 RVA: 0x0002306C File Offset: 0x0002126C
		public override ObjectCreationHandling ObjectCreationHandling
		{
			get
			{
				return this._serializer.ObjectCreationHandling;
			}
			set
			{
				this._serializer.ObjectCreationHandling = value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x0002307A File Offset: 0x0002127A
		// (set) Token: 0x060007D0 RID: 2000 RVA: 0x00023087 File Offset: 0x00021287
		public override ReferenceLoopHandling ReferenceLoopHandling
		{
			get
			{
				return this._serializer.ReferenceLoopHandling;
			}
			set
			{
				this._serializer.ReferenceLoopHandling = value;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060007D1 RID: 2001 RVA: 0x00023095 File Offset: 0x00021295
		// (set) Token: 0x060007D2 RID: 2002 RVA: 0x000230A2 File Offset: 0x000212A2
		public override PreserveReferencesHandling PreserveReferencesHandling
		{
			get
			{
				return this._serializer.PreserveReferencesHandling;
			}
			set
			{
				this._serializer.PreserveReferencesHandling = value;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x000230B0 File Offset: 0x000212B0
		// (set) Token: 0x060007D4 RID: 2004 RVA: 0x000230BD File Offset: 0x000212BD
		public override TypeNameHandling TypeNameHandling
		{
			get
			{
				return this._serializer.TypeNameHandling;
			}
			set
			{
				this._serializer.TypeNameHandling = value;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x000230CB File Offset: 0x000212CB
		// (set) Token: 0x060007D6 RID: 2006 RVA: 0x000230D8 File Offset: 0x000212D8
		public override MetadataPropertyHandling MetadataPropertyHandling
		{
			get
			{
				return this._serializer.MetadataPropertyHandling;
			}
			set
			{
				this._serializer.MetadataPropertyHandling = value;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060007D7 RID: 2007 RVA: 0x000230E6 File Offset: 0x000212E6
		// (set) Token: 0x060007D8 RID: 2008 RVA: 0x000230F3 File Offset: 0x000212F3
		[Obsolete("TypeNameAssemblyFormat is obsolete. Use TypeNameAssemblyFormatHandling instead.")]
		public override FormatterAssemblyStyle TypeNameAssemblyFormat
		{
			get
			{
				return this._serializer.TypeNameAssemblyFormat;
			}
			set
			{
				this._serializer.TypeNameAssemblyFormat = value;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060007D9 RID: 2009 RVA: 0x00023101 File Offset: 0x00021301
		// (set) Token: 0x060007DA RID: 2010 RVA: 0x0002310E File Offset: 0x0002130E
		public override TypeNameAssemblyFormatHandling TypeNameAssemblyFormatHandling
		{
			get
			{
				return this._serializer.TypeNameAssemblyFormatHandling;
			}
			set
			{
				this._serializer.TypeNameAssemblyFormatHandling = value;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x0002311C File Offset: 0x0002131C
		// (set) Token: 0x060007DC RID: 2012 RVA: 0x00023129 File Offset: 0x00021329
		public override ConstructorHandling ConstructorHandling
		{
			get
			{
				return this._serializer.ConstructorHandling;
			}
			set
			{
				this._serializer.ConstructorHandling = value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060007DD RID: 2013 RVA: 0x00023137 File Offset: 0x00021337
		// (set) Token: 0x060007DE RID: 2014 RVA: 0x00023144 File Offset: 0x00021344
		[Obsolete("Binder is obsolete. Use SerializationBinder instead.")]
		public override SerializationBinder Binder
		{
			get
			{
				return this._serializer.Binder;
			}
			set
			{
				this._serializer.Binder = value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x00023152 File Offset: 0x00021352
		// (set) Token: 0x060007E0 RID: 2016 RVA: 0x0002315F File Offset: 0x0002135F
		public override ISerializationBinder SerializationBinder
		{
			get
			{
				return this._serializer.SerializationBinder;
			}
			set
			{
				this._serializer.SerializationBinder = value;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x0002316D File Offset: 0x0002136D
		// (set) Token: 0x060007E2 RID: 2018 RVA: 0x0002317A File Offset: 0x0002137A
		public override StreamingContext Context
		{
			get
			{
				return this._serializer.Context;
			}
			set
			{
				this._serializer.Context = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x00023188 File Offset: 0x00021388
		// (set) Token: 0x060007E4 RID: 2020 RVA: 0x00023195 File Offset: 0x00021395
		public override Formatting Formatting
		{
			get
			{
				return this._serializer.Formatting;
			}
			set
			{
				this._serializer.Formatting = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x000231A3 File Offset: 0x000213A3
		// (set) Token: 0x060007E6 RID: 2022 RVA: 0x000231B0 File Offset: 0x000213B0
		public override DateFormatHandling DateFormatHandling
		{
			get
			{
				return this._serializer.DateFormatHandling;
			}
			set
			{
				this._serializer.DateFormatHandling = value;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x000231BE File Offset: 0x000213BE
		// (set) Token: 0x060007E8 RID: 2024 RVA: 0x000231CB File Offset: 0x000213CB
		public override DateTimeZoneHandling DateTimeZoneHandling
		{
			get
			{
				return this._serializer.DateTimeZoneHandling;
			}
			set
			{
				this._serializer.DateTimeZoneHandling = value;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x000231D9 File Offset: 0x000213D9
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x000231E6 File Offset: 0x000213E6
		public override DateParseHandling DateParseHandling
		{
			get
			{
				return this._serializer.DateParseHandling;
			}
			set
			{
				this._serializer.DateParseHandling = value;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x000231F4 File Offset: 0x000213F4
		// (set) Token: 0x060007EC RID: 2028 RVA: 0x00023201 File Offset: 0x00021401
		public override FloatFormatHandling FloatFormatHandling
		{
			get
			{
				return this._serializer.FloatFormatHandling;
			}
			set
			{
				this._serializer.FloatFormatHandling = value;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x0002320F File Offset: 0x0002140F
		// (set) Token: 0x060007EE RID: 2030 RVA: 0x0002321C File Offset: 0x0002141C
		public override FloatParseHandling FloatParseHandling
		{
			get
			{
				return this._serializer.FloatParseHandling;
			}
			set
			{
				this._serializer.FloatParseHandling = value;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x0002322A File Offset: 0x0002142A
		// (set) Token: 0x060007F0 RID: 2032 RVA: 0x00023237 File Offset: 0x00021437
		public override StringEscapeHandling StringEscapeHandling
		{
			get
			{
				return this._serializer.StringEscapeHandling;
			}
			set
			{
				this._serializer.StringEscapeHandling = value;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x00023245 File Offset: 0x00021445
		// (set) Token: 0x060007F2 RID: 2034 RVA: 0x00023252 File Offset: 0x00021452
		public override string DateFormatString
		{
			get
			{
				return this._serializer.DateFormatString;
			}
			set
			{
				this._serializer.DateFormatString = value;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x00023260 File Offset: 0x00021460
		// (set) Token: 0x060007F4 RID: 2036 RVA: 0x0002326D File Offset: 0x0002146D
		public override CultureInfo Culture
		{
			get
			{
				return this._serializer.Culture;
			}
			set
			{
				this._serializer.Culture = value;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x0002327B File Offset: 0x0002147B
		// (set) Token: 0x060007F6 RID: 2038 RVA: 0x00023288 File Offset: 0x00021488
		public override int? MaxDepth
		{
			get
			{
				return this._serializer.MaxDepth;
			}
			set
			{
				this._serializer.MaxDepth = value;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x00023296 File Offset: 0x00021496
		// (set) Token: 0x060007F8 RID: 2040 RVA: 0x000232A3 File Offset: 0x000214A3
		public override bool CheckAdditionalContent
		{
			get
			{
				return this._serializer.CheckAdditionalContent;
			}
			set
			{
				this._serializer.CheckAdditionalContent = value;
			}
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x000232B1 File Offset: 0x000214B1
		internal JsonSerializerInternalBase GetInternalSerializer()
		{
			if (this._serializerReader != null)
			{
				return this._serializerReader;
			}
			return this._serializerWriter;
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x000232C8 File Offset: 0x000214C8
		public JsonSerializerProxy(JsonSerializerInternalReader serializerReader)
		{
			ValidationUtils.ArgumentNotNull(serializerReader, "serializerReader");
			this._serializerReader = serializerReader;
			this._serializer = serializerReader.Serializer;
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x000232EE File Offset: 0x000214EE
		public JsonSerializerProxy(JsonSerializerInternalWriter serializerWriter)
		{
			ValidationUtils.ArgumentNotNull(serializerWriter, "serializerWriter");
			this._serializerWriter = serializerWriter;
			this._serializer = serializerWriter.Serializer;
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x00023314 File Offset: 0x00021514
		[NullableContext(2)]
		internal override object DeserializeInternal([Nullable(1)] JsonReader reader, Type objectType)
		{
			if (this._serializerReader != null)
			{
				return this._serializerReader.Deserialize(reader, objectType, false);
			}
			return this._serializer.Deserialize(reader, objectType);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0002333A File Offset: 0x0002153A
		internal override void PopulateInternal(JsonReader reader, object target)
		{
			if (this._serializerReader != null)
			{
				this._serializerReader.Populate(reader, target);
				return;
			}
			this._serializer.Populate(reader, target);
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0002335F File Offset: 0x0002155F
		[NullableContext(2)]
		internal override void SerializeInternal([Nullable(1)] JsonWriter jsonWriter, object value, Type rootType)
		{
			if (this._serializerWriter != null)
			{
				this._serializerWriter.Serialize(jsonWriter, value, rootType);
				return;
			}
			this._serializer.Serialize(jsonWriter, value);
		}

		// Token: 0x040002B1 RID: 689
		[Nullable(2)]
		private readonly JsonSerializerInternalReader _serializerReader;

		// Token: 0x040002B2 RID: 690
		[Nullable(2)]
		private readonly JsonSerializerInternalWriter _serializerWriter;

		// Token: 0x040002B3 RID: 691
		private readonly JsonSerializer _serializer;
	}
}
