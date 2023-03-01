﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq
{
	// Token: 0x020000BA RID: 186
	[NullableContext(1)]
	[Nullable(0)]
	public class JConstructor : JContainer
	{
		// Token: 0x060009A6 RID: 2470 RVA: 0x00028238 File Offset: 0x00026438
		public override async Task WriteToAsync(JsonWriter writer, CancellationToken cancellationToken, params JsonConverter[] converters)
		{
			await writer.WriteStartConstructorAsync(this._name ?? string.Empty, cancellationToken).ConfigureAwait(false);
			for (int i = 0; i < this._values.Count; i++)
			{
				await this._values[i].WriteToAsync(writer, cancellationToken, converters).ConfigureAwait(false);
			}
			await writer.WriteEndConstructorAsync(cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x00028295 File Offset: 0x00026495
		public new static Task<JConstructor> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default(CancellationToken))
		{
			return JConstructor.LoadAsync(reader, null, cancellationToken);
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x000282A0 File Offset: 0x000264A0
		public new static async Task<JConstructor> LoadAsync(JsonReader reader, [Nullable(2)] JsonLoadSettings settings, CancellationToken cancellationToken = default(CancellationToken))
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
					throw JsonReaderException.Create(reader, "Error reading JConstructor from JsonReader.");
				}
			}
			await reader.MoveToContentAsync(cancellationToken).ConfigureAwait(false);
			if (reader.TokenType != JsonToken.StartConstructor)
			{
				throw JsonReaderException.Create(reader, "Error reading JConstructor from JsonReader. Current JsonReader item is not a constructor: {0}".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
			}
			JConstructor c = new JConstructor((string)reader.Value);
			c.SetLineInfo(reader as IJsonLineInfo, settings);
			await c.ReadTokenFromAsync(reader, settings, cancellationToken).ConfigureAwait(false);
			return c;
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060009A9 RID: 2473 RVA: 0x000282F5 File Offset: 0x000264F5
		protected override IList<JToken> ChildrenTokens
		{
			get
			{
				return this._values;
			}
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x000282FD File Offset: 0x000264FD
		[NullableContext(2)]
		internal override int IndexOfItem(JToken item)
		{
			if (item == null)
			{
				return -1;
			}
			return this._values.IndexOfReference(item);
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00028310 File Offset: 0x00026510
		internal override void MergeItem(object content, [Nullable(2)] JsonMergeSettings settings)
		{
			JConstructor jconstructor = content as JConstructor;
			if (jconstructor == null)
			{
				return;
			}
			if (jconstructor.Name != null)
			{
				this.Name = jconstructor.Name;
			}
			JContainer.MergeEnumerableContent(this, jconstructor, settings);
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x00028344 File Offset: 0x00026544
		// (set) Token: 0x060009AD RID: 2477 RVA: 0x0002834C File Offset: 0x0002654C
		[Nullable(2)]
		public string Name
		{
			[NullableContext(2)]
			get
			{
				return this._name;
			}
			[NullableContext(2)]
			set
			{
				this._name = value;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x00028355 File Offset: 0x00026555
		public override JTokenType Type
		{
			get
			{
				return JTokenType.Constructor;
			}
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x00028358 File Offset: 0x00026558
		public JConstructor()
		{
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0002836B File Offset: 0x0002656B
		public JConstructor(JConstructor other) : base(other)
		{
			this._name = other.Name;
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0002838B File Offset: 0x0002658B
		public JConstructor(string name, params object[] content) : this(name, content)
		{
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x00028395 File Offset: 0x00026595
		public JConstructor(string name, object content) : this(name)
		{
			this.Add(content);
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x000283A5 File Offset: 0x000265A5
		public JConstructor(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException("Constructor name cannot be empty.", "name");
			}
			this._name = name;
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x000283E8 File Offset: 0x000265E8
		internal override bool DeepEquals(JToken node)
		{
			JConstructor jconstructor = node as JConstructor;
			return jconstructor != null && this._name == jconstructor.Name && base.ContentsEqual(jconstructor);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0002841B File Offset: 0x0002661B
		internal override JToken CloneToken()
		{
			return new JConstructor(this);
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00028424 File Offset: 0x00026624
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
		{
			writer.WriteStartConstructor(this._name);
			int count = this._values.Count;
			for (int i = 0; i < count; i++)
			{
				this._values[i].WriteTo(writer, converters);
			}
			writer.WriteEndConstructor();
		}

		// Token: 0x170001C3 RID: 451
		[Nullable(2)]
		public override JToken this[object key]
		{
			[return: Nullable(2)]
			get
			{
				ValidationUtils.ArgumentNotNull(key, "key");
				if (key is int)
				{
					int index = (int)key;
					return this.GetItem(index);
				}
				throw new ArgumentException("Accessed JConstructor values with invalid key value: {0}. Argument position index expected.".FormatWith(CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(key)));
			}
			[param: Nullable(2)]
			set
			{
				ValidationUtils.ArgumentNotNull(key, "key");
				if (key is int)
				{
					int index = (int)key;
					this.SetItem(index, value);
					return;
				}
				throw new ArgumentException("Set JConstructor values with invalid key value: {0}. Argument position index expected.".FormatWith(CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(key)));
			}
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x00028508 File Offset: 0x00026708
		internal override int GetDeepHashCode()
		{
			string name = this._name;
			return ((name != null) ? name.GetHashCode() : 0) ^ base.ContentsHashCode();
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x00028523 File Offset: 0x00026723
		public new static JConstructor Load(JsonReader reader)
		{
			return JConstructor.Load(reader, null);
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0002852C File Offset: 0x0002672C
		public new static JConstructor Load(JsonReader reader, [Nullable(2)] JsonLoadSettings settings)
		{
			if (reader.TokenType == JsonToken.None && !reader.Read())
			{
				throw JsonReaderException.Create(reader, "Error reading JConstructor from JsonReader.");
			}
			reader.MoveToContent();
			if (reader.TokenType != JsonToken.StartConstructor)
			{
				throw JsonReaderException.Create(reader, "Error reading JConstructor from JsonReader. Current JsonReader item is not a constructor: {0}".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
			}
			JConstructor jconstructor = new JConstructor((string)reader.Value);
			jconstructor.SetLineInfo(reader as IJsonLineInfo, settings);
			jconstructor.ReadTokenFrom(reader, settings);
			return jconstructor;
		}

		// Token: 0x0400035E RID: 862
		[Nullable(2)]
		private string _name;

		// Token: 0x0400035F RID: 863
		private readonly List<JToken> _values = new List<JToken>();
	}
}
