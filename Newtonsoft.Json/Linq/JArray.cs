﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq
{
	// Token: 0x020000B9 RID: 185
	[NullableContext(1)]
	[Nullable(0)]
	public class JArray : JContainer, IList<JToken>, ICollection<JToken>, IEnumerable<JToken>, IEnumerable
	{
		// Token: 0x06000983 RID: 2435 RVA: 0x00027E48 File Offset: 0x00026048
		public override async Task WriteToAsync(JsonWriter writer, CancellationToken cancellationToken, params JsonConverter[] converters)
		{
			await writer.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);
			for (int i = 0; i < this._values.Count; i++)
			{
				await this._values[i].WriteToAsync(writer, cancellationToken, converters).ConfigureAwait(false);
			}
			await writer.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x00027EA5 File Offset: 0x000260A5
		public new static Task<JArray> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default(CancellationToken))
		{
			return JArray.LoadAsync(reader, null, cancellationToken);
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x00027EB0 File Offset: 0x000260B0
		public new static async Task<JArray> LoadAsync(JsonReader reader, [Nullable(2)] JsonLoadSettings settings, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (reader.TokenType == JsonToken.None)
			{
				ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter configuredTaskAwaiter = reader.ReadAsync(cancellationToken).ConfigureAwait(false).GetAwaiter();
				if (!configuredTaskAwaiter.IsCompleted)
				{
					await configuredTaskAwaiter;
					ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter configuredTaskAwaiter2;
					configuredTaskAwaiter = configuredTaskAwaiter2;
					configuredTaskAwaiter2 = default(ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter);
				}
				if (!configuredTaskAwaiter.GetResult())
				{
					throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader.");
				}
			}
			await reader.MoveToContentAsync(cancellationToken).ConfigureAwait(false);
			if (reader.TokenType != JsonToken.StartArray)
			{
				throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader. Current JsonReader item is not an array: {0}".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
			}
			JArray a = new JArray();
			a.SetLineInfo(reader as IJsonLineInfo, settings);
			await a.ReadTokenFromAsync(reader, settings, cancellationToken).ConfigureAwait(false);
			return a;
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00027F05 File Offset: 0x00026105
		protected override IList<JToken> ChildrenTokens
		{
			get
			{
				return this._values;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000987 RID: 2439 RVA: 0x00027F0D File Offset: 0x0002610D
		public override JTokenType Type
		{
			get
			{
				return JTokenType.Array;
			}
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x00027F10 File Offset: 0x00026110
		public JArray()
		{
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x00027F23 File Offset: 0x00026123
		public JArray(JArray other) : base(other)
		{
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00027F37 File Offset: 0x00026137
		public JArray(params object[] content) : this(content)
		{
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x00027F40 File Offset: 0x00026140
		public JArray(object content)
		{
			this.Add(content);
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00027F5C File Offset: 0x0002615C
		internal override bool DeepEquals(JToken node)
		{
			JArray jarray = node as JArray;
			return jarray != null && base.ContentsEqual(jarray);
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00027F7C File Offset: 0x0002617C
		internal override JToken CloneToken()
		{
			return new JArray(this);
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00027F84 File Offset: 0x00026184
		public new static JArray Load(JsonReader reader)
		{
			return JArray.Load(reader, null);
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00027F90 File Offset: 0x00026190
		public new static JArray Load(JsonReader reader, [Nullable(2)] JsonLoadSettings settings)
		{
			if (reader.TokenType == JsonToken.None && !reader.Read())
			{
				throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader.");
			}
			reader.MoveToContent();
			if (reader.TokenType != JsonToken.StartArray)
			{
				throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader. Current JsonReader item is not an array: {0}".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
			}
			JArray jarray = new JArray();
			jarray.SetLineInfo(reader as IJsonLineInfo, settings);
			jarray.ReadTokenFrom(reader, settings);
			return jarray;
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00028004 File Offset: 0x00026204
		public new static JArray Parse(string json)
		{
			return JArray.Parse(json, null);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00028010 File Offset: 0x00026210
		public new static JArray Parse(string json, [Nullable(2)] JsonLoadSettings settings)
		{
			JArray result;
			using (JsonReader jsonReader = new JsonTextReader(new StringReader(json)))
			{
				JArray jarray = JArray.Load(jsonReader, settings);
				while (jsonReader.Read())
				{
				}
				result = jarray;
			}
			return result;
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x00028058 File Offset: 0x00026258
		public new static JArray FromObject(object o)
		{
			return JArray.FromObject(o, JsonSerializer.CreateDefault());
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00028068 File Offset: 0x00026268
		public new static JArray FromObject(object o, JsonSerializer jsonSerializer)
		{
			JToken jtoken = JToken.FromObjectInternal(o, jsonSerializer);
			if (jtoken.Type != JTokenType.Array)
			{
				throw new ArgumentException("Object serialized to {0}. JArray instance expected.".FormatWith(CultureInfo.InvariantCulture, jtoken.Type));
			}
			return (JArray)jtoken;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x000280AC File Offset: 0x000262AC
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
		{
			writer.WriteStartArray();
			for (int i = 0; i < this._values.Count; i++)
			{
				this._values[i].WriteTo(writer, converters);
			}
			writer.WriteEndArray();
		}

		// Token: 0x170001BD RID: 445
		[Nullable(2)]
		public override JToken this[object key]
		{
			[return: Nullable(2)]
			get
			{
				ValidationUtils.ArgumentNotNull(key, "key");
				if (!(key is int))
				{
					throw new ArgumentException("Accessed JArray values with invalid key value: {0}. Int32 array index expected.".FormatWith(CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(key)));
				}
				return this.GetItem((int)key);
			}
			[param: Nullable(2)]
			set
			{
				ValidationUtils.ArgumentNotNull(key, "key");
				if (!(key is int))
				{
					throw new ArgumentException("Set JArray values with invalid key value: {0}. Int32 array index expected.".FormatWith(CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(key)));
				}
				this.SetItem((int)key, value);
			}
		}

		// Token: 0x170001BE RID: 446
		public JToken this[int index]
		{
			get
			{
				return this.GetItem(index);
			}
			set
			{
				this.SetItem(index, value);
			}
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0002817A File Offset: 0x0002637A
		[NullableContext(2)]
		internal override int IndexOfItem(JToken item)
		{
			if (item == null)
			{
				return -1;
			}
			return this._values.IndexOfReference(item);
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00028190 File Offset: 0x00026390
		internal override void MergeItem(object content, [Nullable(2)] JsonMergeSettings settings)
		{
			IEnumerable enumerable = (base.IsMultiContent(content) || content is JArray) ? ((IEnumerable)content) : null;
			if (enumerable == null)
			{
				return;
			}
			JContainer.MergeEnumerableContent(this, enumerable, settings);
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x000281C4 File Offset: 0x000263C4
		public int IndexOf(JToken item)
		{
			return this.IndexOfItem(item);
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x000281CD File Offset: 0x000263CD
		public void Insert(int index, JToken item)
		{
			this.InsertItem(index, item, false);
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x000281D8 File Offset: 0x000263D8
		public void RemoveAt(int index)
		{
			this.RemoveItemAt(index);
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x000281E4 File Offset: 0x000263E4
		public IEnumerator<JToken> GetEnumerator()
		{
			return this.Children().GetEnumerator();
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x000281FF File Offset: 0x000263FF
		public void Add(JToken item)
		{
			this.Add(item);
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x00028208 File Offset: 0x00026408
		public void Clear()
		{
			this.ClearItems();
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x00028210 File Offset: 0x00026410
		public bool Contains(JToken item)
		{
			return this.ContainsItem(item);
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00028219 File Offset: 0x00026419
		public void CopyTo(JToken[] array, int arrayIndex)
		{
			this.CopyItemsTo(array, arrayIndex);
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060009A3 RID: 2467 RVA: 0x00028223 File Offset: 0x00026423
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x00028226 File Offset: 0x00026426
		public bool Remove(JToken item)
		{
			return this.RemoveItem(item);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0002822F File Offset: 0x0002642F
		internal override int GetDeepHashCode()
		{
			return base.ContentsHashCode();
		}

		// Token: 0x0400035D RID: 861
		private readonly List<JToken> _values = new List<JToken>();
	}
}
