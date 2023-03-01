using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json
{
	// Token: 0x0200002F RID: 47
	[NullableContext(1)]
	[Nullable(0)]
	public class JsonTextWriter : JsonWriter
	{
		// Token: 0x0600025F RID: 607 RVA: 0x0000A0DA File Offset: 0x000082DA
		public override Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.FlushAsync(cancellationToken);
			}
			return this.DoFlushAsync(cancellationToken);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000A0F3 File Offset: 0x000082F3
		internal Task DoFlushAsync(CancellationToken cancellationToken)
		{
			return cancellationToken.CancelIfRequestedAsync() ?? this._writer.FlushAsync();
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000A10A File Offset: 0x0000830A
		protected override Task WriteValueDelimiterAsync(CancellationToken cancellationToken)
		{
			if (!this._safeAsync)
			{
				return base.WriteValueDelimiterAsync(cancellationToken);
			}
			return this.DoWriteValueDelimiterAsync(cancellationToken);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000A123 File Offset: 0x00008323
		internal Task DoWriteValueDelimiterAsync(CancellationToken cancellationToken)
		{
			return this._writer.WriteAsync(',', cancellationToken);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000A133 File Offset: 0x00008333
		protected override Task WriteEndAsync(JsonToken token, CancellationToken cancellationToken)
		{
			if (!this._safeAsync)
			{
				return base.WriteEndAsync(token, cancellationToken);
			}
			return this.DoWriteEndAsync(token, cancellationToken);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000A150 File Offset: 0x00008350
		internal Task DoWriteEndAsync(JsonToken token, CancellationToken cancellationToken)
		{
			switch (token)
			{
			case JsonToken.EndObject:
				return this._writer.WriteAsync('}', cancellationToken);
			case JsonToken.EndArray:
				return this._writer.WriteAsync(']', cancellationToken);
			case JsonToken.EndConstructor:
				return this._writer.WriteAsync(')', cancellationToken);
			default:
				throw JsonWriterException.Create(this, "Invalid JsonToken: " + token.ToString(), null);
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000A1BF File Offset: 0x000083BF
		public override Task CloseAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.CloseAsync(cancellationToken);
			}
			return this.DoCloseAsync(cancellationToken);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000A1D8 File Offset: 0x000083D8
		internal async Task DoCloseAsync(CancellationToken cancellationToken)
		{
			if (base.Top == 0)
			{
				cancellationToken.ThrowIfCancellationRequested();
			}
			while (base.Top > 0)
			{
				await this.WriteEndAsync(cancellationToken).ConfigureAwait(false);
			}
			this.CloseBufferAndWriter();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000A225 File Offset: 0x00008425
		public override Task WriteEndAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteEndAsync(cancellationToken);
			}
			return base.WriteEndInternalAsync(cancellationToken);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000A23E File Offset: 0x0000843E
		protected override Task WriteIndentAsync(CancellationToken cancellationToken)
		{
			if (!this._safeAsync)
			{
				return base.WriteIndentAsync(cancellationToken);
			}
			return this.DoWriteIndentAsync(cancellationToken);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000A258 File Offset: 0x00008458
		internal Task DoWriteIndentAsync(CancellationToken cancellationToken)
		{
			int num = base.Top * this._indentation;
			int num2 = this.SetIndentChars();
			if (num <= 12)
			{
				return this._writer.WriteAsync(this._indentChars, 0, num2 + num, cancellationToken);
			}
			return this.WriteIndentAsync(num, num2, cancellationToken);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000A2A0 File Offset: 0x000084A0
		private async Task WriteIndentAsync(int currentIndentCount, int newLineLen, CancellationToken cancellationToken)
		{
			await this._writer.WriteAsync(this._indentChars, 0, newLineLen + Math.Min(currentIndentCount, 12), cancellationToken).ConfigureAwait(false);
			while ((currentIndentCount -= 12) > 0)
			{
				await this._writer.WriteAsync(this._indentChars, newLineLen, Math.Min(currentIndentCount, 12), cancellationToken).ConfigureAwait(false);
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000A300 File Offset: 0x00008500
		private Task WriteValueInternalAsync(JsonToken token, string value, CancellationToken cancellationToken)
		{
			Task task = base.InternalWriteValueAsync(token, cancellationToken);
			if (task.IsCompletedSucessfully())
			{
				return this._writer.WriteAsync(value, cancellationToken);
			}
			return this.WriteValueInternalAsync(task, value, cancellationToken);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000A338 File Offset: 0x00008538
		private async Task WriteValueInternalAsync(Task task, string value, CancellationToken cancellationToken)
		{
			await task.ConfigureAwait(false);
			await this._writer.WriteAsync(value, cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000A395 File Offset: 0x00008595
		protected override Task WriteIndentSpaceAsync(CancellationToken cancellationToken)
		{
			if (!this._safeAsync)
			{
				return base.WriteIndentSpaceAsync(cancellationToken);
			}
			return this.DoWriteIndentSpaceAsync(cancellationToken);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000A3AE File Offset: 0x000085AE
		internal Task DoWriteIndentSpaceAsync(CancellationToken cancellationToken)
		{
			return this._writer.WriteAsync(' ', cancellationToken);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000A3BE File Offset: 0x000085BE
		public override Task WriteRawAsync([Nullable(2)] string json, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteRawAsync(json, cancellationToken);
			}
			return this.DoWriteRawAsync(json, cancellationToken);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000A3D9 File Offset: 0x000085D9
		internal Task DoWriteRawAsync([Nullable(2)] string json, CancellationToken cancellationToken)
		{
			return this._writer.WriteAsync(json, cancellationToken);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000A3E8 File Offset: 0x000085E8
		public override Task WriteNullAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteNullAsync(cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000A401 File Offset: 0x00008601
		internal Task DoWriteNullAsync(CancellationToken cancellationToken)
		{
			return this.WriteValueInternalAsync(JsonToken.Null, JsonConvert.Null, cancellationToken);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000A414 File Offset: 0x00008614
		private Task WriteDigitsAsync(ulong uvalue, bool negative, CancellationToken cancellationToken)
		{
			if (uvalue <= 9UL & !negative)
			{
				return this._writer.WriteAsync((char)(48UL + uvalue), cancellationToken);
			}
			int count = this.WriteNumberToBuffer(uvalue, negative);
			return this._writer.WriteAsync(this._writeBuffer, 0, count, cancellationToken);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000A464 File Offset: 0x00008664
		private Task WriteIntegerValueAsync(ulong uvalue, bool negative, CancellationToken cancellationToken)
		{
			Task task = base.InternalWriteValueAsync(JsonToken.Integer, cancellationToken);
			if (task.IsCompletedSucessfully())
			{
				return this.WriteDigitsAsync(uvalue, negative, cancellationToken);
			}
			return this.WriteIntegerValueAsync(task, uvalue, negative, cancellationToken);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000A498 File Offset: 0x00008698
		private async Task WriteIntegerValueAsync(Task task, ulong uvalue, bool negative, CancellationToken cancellationToken)
		{
			await task.ConfigureAwait(false);
			await this.WriteDigitsAsync(uvalue, negative, cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000A500 File Offset: 0x00008700
		internal Task WriteIntegerValueAsync(long value, CancellationToken cancellationToken)
		{
			bool flag = value < 0L;
			if (flag)
			{
				value = -value;
			}
			return this.WriteIntegerValueAsync((ulong)value, flag, cancellationToken);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000A523 File Offset: 0x00008723
		internal Task WriteIntegerValueAsync(ulong uvalue, CancellationToken cancellationToken)
		{
			return this.WriteIntegerValueAsync(uvalue, false, cancellationToken);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000A530 File Offset: 0x00008730
		private Task WriteEscapedStringAsync(string value, bool quote, CancellationToken cancellationToken)
		{
			return JavaScriptUtils.WriteEscapedJavaScriptStringAsync(this._writer, value, this._quoteChar, quote, this._charEscapeFlags, base.StringEscapeHandling, this, this._writeBuffer, cancellationToken);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000A564 File Offset: 0x00008764
		public override Task WritePropertyNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WritePropertyNameAsync(name, cancellationToken);
			}
			return this.DoWritePropertyNameAsync(name, cancellationToken);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000A580 File Offset: 0x00008780
		internal Task DoWritePropertyNameAsync(string name, CancellationToken cancellationToken)
		{
			Task task = base.InternalWritePropertyNameAsync(name, cancellationToken);
			if (!task.IsCompletedSucessfully())
			{
				return this.DoWritePropertyNameAsync(task, name, cancellationToken);
			}
			task = this.WriteEscapedStringAsync(name, this._quoteName, cancellationToken);
			if (task.IsCompletedSucessfully())
			{
				return this._writer.WriteAsync(':', cancellationToken);
			}
			return JavaScriptUtils.WriteCharAsync(task, this._writer, ':', cancellationToken);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000A5E0 File Offset: 0x000087E0
		private async Task DoWritePropertyNameAsync(Task task, string name, CancellationToken cancellationToken)
		{
			await task.ConfigureAwait(false);
			await this.WriteEscapedStringAsync(name, this._quoteName, cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync(':').ConfigureAwait(false);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000A63D File Offset: 0x0000883D
		public override Task WritePropertyNameAsync(string name, bool escape, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WritePropertyNameAsync(name, escape, cancellationToken);
			}
			return this.DoWritePropertyNameAsync(name, escape, cancellationToken);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000A65C File Offset: 0x0000885C
		internal async Task DoWritePropertyNameAsync(string name, bool escape, CancellationToken cancellationToken)
		{
			await base.InternalWritePropertyNameAsync(name, cancellationToken).ConfigureAwait(false);
			if (escape)
			{
				await this.WriteEscapedStringAsync(name, this._quoteName, cancellationToken).ConfigureAwait(false);
			}
			else
			{
				if (this._quoteName)
				{
					await this._writer.WriteAsync(this._quoteChar).ConfigureAwait(false);
				}
				await this._writer.WriteAsync(name, cancellationToken).ConfigureAwait(false);
				if (this._quoteName)
				{
					await this._writer.WriteAsync(this._quoteChar).ConfigureAwait(false);
				}
			}
			await this._writer.WriteAsync(':').ConfigureAwait(false);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000A6B9 File Offset: 0x000088B9
		public override Task WriteStartArrayAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteStartArrayAsync(cancellationToken);
			}
			return this.DoWriteStartArrayAsync(cancellationToken);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000A6D4 File Offset: 0x000088D4
		internal Task DoWriteStartArrayAsync(CancellationToken cancellationToken)
		{
			Task task = base.InternalWriteStartAsync(JsonToken.StartArray, JsonContainerType.Array, cancellationToken);
			if (task.IsCompletedSucessfully())
			{
				return this._writer.WriteAsync('[', cancellationToken);
			}
			return this.DoWriteStartArrayAsync(task, cancellationToken);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000A70C File Offset: 0x0000890C
		internal async Task DoWriteStartArrayAsync(Task task, CancellationToken cancellationToken)
		{
			await task.ConfigureAwait(false);
			await this._writer.WriteAsync('[', cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000A761 File Offset: 0x00008961
		public override Task WriteStartObjectAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteStartObjectAsync(cancellationToken);
			}
			return this.DoWriteStartObjectAsync(cancellationToken);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000A77C File Offset: 0x0000897C
		internal Task DoWriteStartObjectAsync(CancellationToken cancellationToken)
		{
			Task task = base.InternalWriteStartAsync(JsonToken.StartObject, JsonContainerType.Object, cancellationToken);
			if (task.IsCompletedSucessfully())
			{
				return this._writer.WriteAsync('{', cancellationToken);
			}
			return this.DoWriteStartObjectAsync(task, cancellationToken);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000A7B4 File Offset: 0x000089B4
		internal async Task DoWriteStartObjectAsync(Task task, CancellationToken cancellationToken)
		{
			await task.ConfigureAwait(false);
			await this._writer.WriteAsync('{', cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000A809 File Offset: 0x00008A09
		public override Task WriteStartConstructorAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteStartConstructorAsync(name, cancellationToken);
			}
			return this.DoWriteStartConstructorAsync(name, cancellationToken);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000A824 File Offset: 0x00008A24
		internal async Task DoWriteStartConstructorAsync(string name, CancellationToken cancellationToken)
		{
			await base.InternalWriteStartAsync(JsonToken.StartConstructor, JsonContainerType.Constructor, cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync("new ", cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync(name, cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync('(').ConfigureAwait(false);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000A879 File Offset: 0x00008A79
		public override Task WriteUndefinedAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteUndefinedAsync(cancellationToken);
			}
			return this.DoWriteUndefinedAsync(cancellationToken);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000A894 File Offset: 0x00008A94
		internal Task DoWriteUndefinedAsync(CancellationToken cancellationToken)
		{
			Task task = base.InternalWriteValueAsync(JsonToken.Undefined, cancellationToken);
			if (task.IsCompletedSucessfully())
			{
				return this._writer.WriteAsync(JsonConvert.Undefined, cancellationToken);
			}
			return this.DoWriteUndefinedAsync(task, cancellationToken);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000A8D0 File Offset: 0x00008AD0
		private async Task DoWriteUndefinedAsync(Task task, CancellationToken cancellationToken)
		{
			await task.ConfigureAwait(false);
			await this._writer.WriteAsync(JsonConvert.Undefined, cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000A925 File Offset: 0x00008B25
		public override Task WriteWhitespaceAsync(string ws, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteWhitespaceAsync(ws, cancellationToken);
			}
			return this.DoWriteWhitespaceAsync(ws, cancellationToken);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000A940 File Offset: 0x00008B40
		internal Task DoWriteWhitespaceAsync(string ws, CancellationToken cancellationToken)
		{
			base.InternalWriteWhitespace(ws);
			return this._writer.WriteAsync(ws, cancellationToken);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000A956 File Offset: 0x00008B56
		public override Task WriteValueAsync(bool value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000A971 File Offset: 0x00008B71
		internal Task DoWriteValueAsync(bool value, CancellationToken cancellationToken)
		{
			return this.WriteValueInternalAsync(JsonToken.Boolean, JsonConvert.ToString(value), cancellationToken);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000A982 File Offset: 0x00008B82
		public override Task WriteValueAsync(bool? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000A99D File Offset: 0x00008B9D
		internal Task DoWriteValueAsync(bool? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.DoWriteValueAsync(value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000A9BE File Offset: 0x00008BBE
		public override Task WriteValueAsync(byte value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.WriteIntegerValueAsync((long)((ulong)value), cancellationToken);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000A9DA File Offset: 0x00008BDA
		public override Task WriteValueAsync(byte? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000A9F5 File Offset: 0x00008BF5
		internal Task DoWriteValueAsync(byte? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.WriteIntegerValueAsync((long)((ulong)value.GetValueOrDefault()), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000AA17 File Offset: 0x00008C17
		public override Task WriteValueAsync([Nullable(2)] byte[] value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			if (value != null)
			{
				return this.WriteValueNonNullAsync(value, cancellationToken);
			}
			return this.WriteNullAsync(cancellationToken);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000AA40 File Offset: 0x00008C40
		internal async Task WriteValueNonNullAsync(byte[] value, CancellationToken cancellationToken)
		{
			await base.InternalWriteValueAsync(JsonToken.Bytes, cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync(this._quoteChar).ConfigureAwait(false);
			await this.Base64Encoder.EncodeAsync(value, 0, value.Length, cancellationToken).ConfigureAwait(false);
			await this.Base64Encoder.FlushAsync(cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync(this._quoteChar).ConfigureAwait(false);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000AA95 File Offset: 0x00008C95
		public override Task WriteValueAsync(char value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000AAB0 File Offset: 0x00008CB0
		internal Task DoWriteValueAsync(char value, CancellationToken cancellationToken)
		{
			return this.WriteValueInternalAsync(JsonToken.String, JsonConvert.ToString(value), cancellationToken);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000AAC1 File Offset: 0x00008CC1
		public override Task WriteValueAsync(char? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000AADC File Offset: 0x00008CDC
		internal Task DoWriteValueAsync(char? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.DoWriteValueAsync(value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000AAFD File Offset: 0x00008CFD
		public override Task WriteValueAsync(DateTime value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000AB18 File Offset: 0x00008D18
		internal async Task DoWriteValueAsync(DateTime value, CancellationToken cancellationToken)
		{
			await base.InternalWriteValueAsync(JsonToken.Date, cancellationToken).ConfigureAwait(false);
			value = DateTimeUtils.EnsureDateTime(value, base.DateTimeZoneHandling);
			if (StringUtils.IsNullOrEmpty(base.DateFormatString))
			{
				int count = this.WriteValueToBuffer(value);
				await this._writer.WriteAsync(this._writeBuffer, 0, count, cancellationToken).ConfigureAwait(false);
			}
			else
			{
				await this._writer.WriteAsync(this._quoteChar).ConfigureAwait(false);
				await this._writer.WriteAsync(value.ToString(base.DateFormatString, base.Culture), cancellationToken).ConfigureAwait(false);
				await this._writer.WriteAsync(this._quoteChar).ConfigureAwait(false);
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000AB6D File Offset: 0x00008D6D
		public override Task WriteValueAsync(DateTime? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000AB88 File Offset: 0x00008D88
		internal Task DoWriteValueAsync(DateTime? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.DoWriteValueAsync(value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000ABA9 File Offset: 0x00008DA9
		public override Task WriteValueAsync(DateTimeOffset value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000ABC4 File Offset: 0x00008DC4
		internal async Task DoWriteValueAsync(DateTimeOffset value, CancellationToken cancellationToken)
		{
			await base.InternalWriteValueAsync(JsonToken.Date, cancellationToken).ConfigureAwait(false);
			if (StringUtils.IsNullOrEmpty(base.DateFormatString))
			{
				int count = this.WriteValueToBuffer(value);
				await this._writer.WriteAsync(this._writeBuffer, 0, count, cancellationToken).ConfigureAwait(false);
			}
			else
			{
				await this._writer.WriteAsync(this._quoteChar).ConfigureAwait(false);
				await this._writer.WriteAsync(value.ToString(base.DateFormatString, base.Culture), cancellationToken).ConfigureAwait(false);
				await this._writer.WriteAsync(this._quoteChar).ConfigureAwait(false);
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000AC19 File Offset: 0x00008E19
		public override Task WriteValueAsync(DateTimeOffset? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000AC34 File Offset: 0x00008E34
		internal Task DoWriteValueAsync(DateTimeOffset? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.DoWriteValueAsync(value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000AC55 File Offset: 0x00008E55
		public override Task WriteValueAsync(decimal value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000AC70 File Offset: 0x00008E70
		internal Task DoWriteValueAsync(decimal value, CancellationToken cancellationToken)
		{
			return this.WriteValueInternalAsync(JsonToken.Float, JsonConvert.ToString(value), cancellationToken);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000AC80 File Offset: 0x00008E80
		public override Task WriteValueAsync(decimal? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000AC9B File Offset: 0x00008E9B
		internal Task DoWriteValueAsync(decimal? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.DoWriteValueAsync(value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000ACBC File Offset: 0x00008EBC
		public override Task WriteValueAsync(double value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.WriteValueAsync(value, false, cancellationToken);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000ACD8 File Offset: 0x00008ED8
		internal Task WriteValueAsync(double value, bool nullable, CancellationToken cancellationToken)
		{
			return this.WriteValueInternalAsync(JsonToken.Float, JsonConvert.ToString(value, base.FloatFormatHandling, this.QuoteChar, nullable), cancellationToken);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000ACF5 File Offset: 0x00008EF5
		public override Task WriteValueAsync(double? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			if (value == null)
			{
				return this.WriteNullAsync(cancellationToken);
			}
			return this.WriteValueAsync(value.GetValueOrDefault(), true, cancellationToken);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000AD28 File Offset: 0x00008F28
		public override Task WriteValueAsync(float value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.WriteValueAsync(value, false, cancellationToken);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000AD44 File Offset: 0x00008F44
		internal Task WriteValueAsync(float value, bool nullable, CancellationToken cancellationToken)
		{
			return this.WriteValueInternalAsync(JsonToken.Float, JsonConvert.ToString(value, base.FloatFormatHandling, this.QuoteChar, nullable), cancellationToken);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000AD61 File Offset: 0x00008F61
		public override Task WriteValueAsync(float? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			if (value == null)
			{
				return this.WriteNullAsync(cancellationToken);
			}
			return this.WriteValueAsync(value.GetValueOrDefault(), true, cancellationToken);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000AD94 File Offset: 0x00008F94
		public override Task WriteValueAsync(Guid value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000ADB0 File Offset: 0x00008FB0
		internal async Task DoWriteValueAsync(Guid value, CancellationToken cancellationToken)
		{
			await base.InternalWriteValueAsync(JsonToken.String, cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync(this._quoteChar).ConfigureAwait(false);
			await this._writer.WriteAsync(value.ToString("D", CultureInfo.InvariantCulture), cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync(this._quoteChar).ConfigureAwait(false);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000AE05 File Offset: 0x00009005
		public override Task WriteValueAsync(Guid? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000AE20 File Offset: 0x00009020
		internal Task DoWriteValueAsync(Guid? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.DoWriteValueAsync(value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000AE41 File Offset: 0x00009041
		public override Task WriteValueAsync(int value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.WriteIntegerValueAsync((long)value, cancellationToken);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000AE5D File Offset: 0x0000905D
		public override Task WriteValueAsync(int? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000AE78 File Offset: 0x00009078
		internal Task DoWriteValueAsync(int? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.WriteIntegerValueAsync((long)value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000AE9A File Offset: 0x0000909A
		public override Task WriteValueAsync(long value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.WriteIntegerValueAsync(value, cancellationToken);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000AEB5 File Offset: 0x000090B5
		public override Task WriteValueAsync(long? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000AED0 File Offset: 0x000090D0
		internal Task DoWriteValueAsync(long? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.WriteIntegerValueAsync(value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000AEF1 File Offset: 0x000090F1
		internal Task WriteValueAsync(BigInteger value, CancellationToken cancellationToken)
		{
			return this.WriteValueInternalAsync(JsonToken.Integer, value.ToString(CultureInfo.InvariantCulture), cancellationToken);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000AF08 File Offset: 0x00009108
		public override Task WriteValueAsync([Nullable(2)] object value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			if (value == null)
			{
				return this.WriteNullAsync(cancellationToken);
			}
			if (value is BigInteger)
			{
				BigInteger value2 = (BigInteger)value;
				return this.WriteValueAsync(value2, cancellationToken);
			}
			return JsonWriter.WriteValueAsync(this, ConvertUtils.GetTypeCode(value.GetType()), value, cancellationToken);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000AF5C File Offset: 0x0000915C
		[CLSCompliant(false)]
		public override Task WriteValueAsync(sbyte value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.WriteIntegerValueAsync((long)value, cancellationToken);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000AF78 File Offset: 0x00009178
		[CLSCompliant(false)]
		public override Task WriteValueAsync(sbyte? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000AF93 File Offset: 0x00009193
		internal Task DoWriteValueAsync(sbyte? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.WriteIntegerValueAsync((long)value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000AFB5 File Offset: 0x000091B5
		public override Task WriteValueAsync(short value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.WriteIntegerValueAsync((long)value, cancellationToken);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000AFD1 File Offset: 0x000091D1
		public override Task WriteValueAsync(short? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000AFEC File Offset: 0x000091EC
		internal Task DoWriteValueAsync(short? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.WriteIntegerValueAsync((long)value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000B00E File Offset: 0x0000920E
		public override Task WriteValueAsync([Nullable(2)] string value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000B02C File Offset: 0x0000922C
		internal Task DoWriteValueAsync([Nullable(2)] string value, CancellationToken cancellationToken)
		{
			Task task = base.InternalWriteValueAsync(JsonToken.String, cancellationToken);
			if (!task.IsCompletedSucessfully())
			{
				return this.DoWriteValueAsync(task, value, cancellationToken);
			}
			if (value != null)
			{
				return this.WriteEscapedStringAsync(value, true, cancellationToken);
			}
			return this._writer.WriteAsync(JsonConvert.Null, cancellationToken);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000B074 File Offset: 0x00009274
		private async Task DoWriteValueAsync(Task task, [Nullable(2)] string value, CancellationToken cancellationToken)
		{
			await task.ConfigureAwait(false);
			await((value == null) ? this._writer.WriteAsync(JsonConvert.Null, cancellationToken) : this.WriteEscapedStringAsync(value, true, cancellationToken)).ConfigureAwait(false);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000B0D1 File Offset: 0x000092D1
		public override Task WriteValueAsync(TimeSpan value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000B0EC File Offset: 0x000092EC
		internal async Task DoWriteValueAsync(TimeSpan value, CancellationToken cancellationToken)
		{
			await base.InternalWriteValueAsync(JsonToken.String, cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync(this._quoteChar, cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync(value.ToString(null, CultureInfo.InvariantCulture), cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync(this._quoteChar, cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000B141 File Offset: 0x00009341
		public override Task WriteValueAsync(TimeSpan? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000B15C File Offset: 0x0000935C
		internal Task DoWriteValueAsync(TimeSpan? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.DoWriteValueAsync(value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000B17D File Offset: 0x0000937D
		[CLSCompliant(false)]
		public override Task WriteValueAsync(uint value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.WriteIntegerValueAsync((long)((ulong)value), cancellationToken);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000B199 File Offset: 0x00009399
		[CLSCompliant(false)]
		public override Task WriteValueAsync(uint? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000B1B4 File Offset: 0x000093B4
		internal Task DoWriteValueAsync(uint? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.WriteIntegerValueAsync((long)((ulong)value.GetValueOrDefault()), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000B1D6 File Offset: 0x000093D6
		[CLSCompliant(false)]
		public override Task WriteValueAsync(ulong value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.WriteIntegerValueAsync(value, cancellationToken);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000B1F1 File Offset: 0x000093F1
		[CLSCompliant(false)]
		public override Task WriteValueAsync(ulong? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000B20C File Offset: 0x0000940C
		internal Task DoWriteValueAsync(ulong? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.WriteIntegerValueAsync(value.GetValueOrDefault(), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000B22D File Offset: 0x0000942D
		public override Task WriteValueAsync([Nullable(2)] Uri value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			if (!(value == null))
			{
				return this.WriteValueNotNullAsync(value, cancellationToken);
			}
			return this.WriteNullAsync(cancellationToken);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000B25C File Offset: 0x0000945C
		internal Task WriteValueNotNullAsync(Uri value, CancellationToken cancellationToken)
		{
			Task task = base.InternalWriteValueAsync(JsonToken.String, cancellationToken);
			if (task.IsCompletedSucessfully())
			{
				return this.WriteEscapedStringAsync(value.OriginalString, true, cancellationToken);
			}
			return this.WriteValueNotNullAsync(task, value, cancellationToken);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000B294 File Offset: 0x00009494
		internal async Task WriteValueNotNullAsync(Task task, Uri value, CancellationToken cancellationToken)
		{
			await task.ConfigureAwait(false);
			await this.WriteEscapedStringAsync(value.OriginalString, true, cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000B2F1 File Offset: 0x000094F1
		[CLSCompliant(false)]
		public override Task WriteValueAsync(ushort value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.WriteIntegerValueAsync((long)((ulong)value), cancellationToken);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000B30D File Offset: 0x0000950D
		[CLSCompliant(false)]
		public override Task WriteValueAsync(ushort? value, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteValueAsync(value, cancellationToken);
			}
			return this.DoWriteValueAsync(value, cancellationToken);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000B328 File Offset: 0x00009528
		internal Task DoWriteValueAsync(ushort? value, CancellationToken cancellationToken)
		{
			if (value != null)
			{
				return this.WriteIntegerValueAsync((long)((ulong)value.GetValueOrDefault()), cancellationToken);
			}
			return this.DoWriteNullAsync(cancellationToken);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000B34A File Offset: 0x0000954A
		public override Task WriteCommentAsync([Nullable(2)] string text, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteCommentAsync(text, cancellationToken);
			}
			return this.DoWriteCommentAsync(text, cancellationToken);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000B368 File Offset: 0x00009568
		internal async Task DoWriteCommentAsync([Nullable(2)] string text, CancellationToken cancellationToken)
		{
			await base.InternalWriteCommentAsync(cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync("/*", cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync(text ?? string.Empty, cancellationToken).ConfigureAwait(false);
			await this._writer.WriteAsync("*/", cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000B3BD File Offset: 0x000095BD
		public override Task WriteEndArrayAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteEndArrayAsync(cancellationToken);
			}
			return base.InternalWriteEndAsync(JsonContainerType.Array, cancellationToken);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000B3D7 File Offset: 0x000095D7
		public override Task WriteEndConstructorAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteEndConstructorAsync(cancellationToken);
			}
			return base.InternalWriteEndAsync(JsonContainerType.Constructor, cancellationToken);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000B3F1 File Offset: 0x000095F1
		public override Task WriteEndObjectAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteEndObjectAsync(cancellationToken);
			}
			return base.InternalWriteEndAsync(JsonContainerType.Object, cancellationToken);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000B40B File Offset: 0x0000960B
		public override Task WriteRawValueAsync([Nullable(2)] string json, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!this._safeAsync)
			{
				return base.WriteRawValueAsync(json, cancellationToken);
			}
			return this.DoWriteRawValueAsync(json, cancellationToken);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000B428 File Offset: 0x00009628
		internal Task DoWriteRawValueAsync([Nullable(2)] string json, CancellationToken cancellationToken)
		{
			base.UpdateScopeWithFinishedValue();
			Task task = base.AutoCompleteAsync(JsonToken.Undefined, cancellationToken);
			if (task.IsCompletedSucessfully())
			{
				return this.WriteRawAsync(json, cancellationToken);
			}
			return this.DoWriteRawValueAsync(task, json, cancellationToken);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000B460 File Offset: 0x00009660
		private async Task DoWriteRawValueAsync(Task task, [Nullable(2)] string json, CancellationToken cancellationToken)
		{
			await task.ConfigureAwait(false);
			await this.WriteRawAsync(json, cancellationToken).ConfigureAwait(false);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000B4C0 File Offset: 0x000096C0
		internal char[] EnsureWriteBuffer(int length, int copyTo)
		{
			if (length < 35)
			{
				length = 35;
			}
			char[] writeBuffer = this._writeBuffer;
			if (writeBuffer == null)
			{
				return this._writeBuffer = BufferUtils.RentBuffer(this._arrayPool, length);
			}
			if (writeBuffer.Length >= length)
			{
				return writeBuffer;
			}
			char[] array = BufferUtils.RentBuffer(this._arrayPool, length);
			if (copyTo != 0)
			{
				Array.Copy(writeBuffer, array, copyTo);
			}
			BufferUtils.ReturnBuffer(this._arrayPool, writeBuffer);
			this._writeBuffer = array;
			return array;
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x0000B52A File Offset: 0x0000972A
		private Base64Encoder Base64Encoder
		{
			get
			{
				if (this._base64Encoder == null)
				{
					this._base64Encoder = new Base64Encoder(this._writer);
				}
				return this._base64Encoder;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x0000B54B File Offset: 0x0000974B
		// (set) Token: 0x060002DA RID: 730 RVA: 0x0000B553 File Offset: 0x00009753
		[Nullable(2)]
		public IArrayPool<char> ArrayPool
		{
			[NullableContext(2)]
			get
			{
				return this._arrayPool;
			}
			[NullableContext(2)]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this._arrayPool = value;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060002DB RID: 731 RVA: 0x0000B56A File Offset: 0x0000976A
		// (set) Token: 0x060002DC RID: 732 RVA: 0x0000B572 File Offset: 0x00009772
		public int Indentation
		{
			get
			{
				return this._indentation;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Indentation value must be greater than 0.");
				}
				this._indentation = value;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060002DD RID: 733 RVA: 0x0000B58A File Offset: 0x0000978A
		// (set) Token: 0x060002DE RID: 734 RVA: 0x0000B592 File Offset: 0x00009792
		public char QuoteChar
		{
			get
			{
				return this._quoteChar;
			}
			set
			{
				if (value != '"' && value != '\'')
				{
					throw new ArgumentException("Invalid JavaScript string quote character. Valid quote characters are ' and \".");
				}
				this._quoteChar = value;
				this.UpdateCharEscapeFlags();
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060002DF RID: 735 RVA: 0x0000B5B6 File Offset: 0x000097B6
		// (set) Token: 0x060002E0 RID: 736 RVA: 0x0000B5BE File Offset: 0x000097BE
		public char IndentChar
		{
			get
			{
				return this._indentChar;
			}
			set
			{
				if (value != this._indentChar)
				{
					this._indentChar = value;
					this._indentChars = null;
				}
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x0000B5D7 File Offset: 0x000097D7
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x0000B5DF File Offset: 0x000097DF
		public bool QuoteName
		{
			get
			{
				return this._quoteName;
			}
			set
			{
				this._quoteName = value;
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000B5E8 File Offset: 0x000097E8
		public JsonTextWriter(TextWriter textWriter)
		{
			if (textWriter == null)
			{
				throw new ArgumentNullException("textWriter");
			}
			this._writer = textWriter;
			this._quoteChar = '"';
			this._quoteName = true;
			this._indentChar = ' ';
			this._indentation = 2;
			this.UpdateCharEscapeFlags();
			this._safeAsync = (base.GetType() == typeof(JsonTextWriter));
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000B64F File Offset: 0x0000984F
		public override void Flush()
		{
			this._writer.Flush();
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000B65C File Offset: 0x0000985C
		public override void Close()
		{
			base.Close();
			this.CloseBufferAndWriter();
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000B66A File Offset: 0x0000986A
		private void CloseBufferAndWriter()
		{
			if (this._writeBuffer != null)
			{
				BufferUtils.ReturnBuffer(this._arrayPool, this._writeBuffer);
				this._writeBuffer = null;
			}
			if (base.CloseOutput)
			{
				TextWriter writer = this._writer;
				if (writer == null)
				{
					return;
				}
				writer.Close();
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000B6A4 File Offset: 0x000098A4
		public override void WriteStartObject()
		{
			base.InternalWriteStart(JsonToken.StartObject, JsonContainerType.Object);
			this._writer.Write('{');
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000B6BB File Offset: 0x000098BB
		public override void WriteStartArray()
		{
			base.InternalWriteStart(JsonToken.StartArray, JsonContainerType.Array);
			this._writer.Write('[');
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000B6D2 File Offset: 0x000098D2
		public override void WriteStartConstructor(string name)
		{
			base.InternalWriteStart(JsonToken.StartConstructor, JsonContainerType.Constructor);
			this._writer.Write("new ");
			this._writer.Write(name);
			this._writer.Write('(');
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000B708 File Offset: 0x00009908
		protected override void WriteEnd(JsonToken token)
		{
			switch (token)
			{
			case JsonToken.EndObject:
				this._writer.Write('}');
				return;
			case JsonToken.EndArray:
				this._writer.Write(']');
				return;
			case JsonToken.EndConstructor:
				this._writer.Write(')');
				return;
			default:
				throw JsonWriterException.Create(this, "Invalid JsonToken: " + token.ToString(), null);
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000B774 File Offset: 0x00009974
		public override void WritePropertyName(string name)
		{
			base.InternalWritePropertyName(name);
			this.WriteEscapedString(name, this._quoteName);
			this._writer.Write(':');
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000B798 File Offset: 0x00009998
		public override void WritePropertyName(string name, bool escape)
		{
			base.InternalWritePropertyName(name);
			if (escape)
			{
				this.WriteEscapedString(name, this._quoteName);
			}
			else
			{
				if (this._quoteName)
				{
					this._writer.Write(this._quoteChar);
				}
				this._writer.Write(name);
				if (this._quoteName)
				{
					this._writer.Write(this._quoteChar);
				}
			}
			this._writer.Write(':');
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000B809 File Offset: 0x00009A09
		internal override void OnStringEscapeHandlingChanged()
		{
			this.UpdateCharEscapeFlags();
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000B811 File Offset: 0x00009A11
		private void UpdateCharEscapeFlags()
		{
			this._charEscapeFlags = JavaScriptUtils.GetCharEscapeFlags(base.StringEscapeHandling, this._quoteChar);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000B82C File Offset: 0x00009A2C
		protected override void WriteIndent()
		{
			int num = base.Top * this._indentation;
			int num2 = this.SetIndentChars();
			this._writer.Write(this._indentChars, 0, num2 + Math.Min(num, 12));
			while ((num -= 12) > 0)
			{
				this._writer.Write(this._indentChars, num2, Math.Min(num, 12));
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000B890 File Offset: 0x00009A90
		private int SetIndentChars()
		{
			string newLine = this._writer.NewLine;
			int length = newLine.Length;
			bool flag = this._indentChars != null && this._indentChars.Length == 12 + length;
			if (flag)
			{
				for (int num = 0; num != length; num++)
				{
					if (newLine[num] != this._indentChars[num])
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				this._indentChars = (newLine + new string(this._indentChar, 12)).ToCharArray();
			}
			return length;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000B910 File Offset: 0x00009B10
		protected override void WriteValueDelimiter()
		{
			this._writer.Write(',');
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000B91F File Offset: 0x00009B1F
		protected override void WriteIndentSpace()
		{
			this._writer.Write(' ');
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000B92E File Offset: 0x00009B2E
		private void WriteValueInternal(string value, JsonToken token)
		{
			this._writer.Write(value);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000B93C File Offset: 0x00009B3C
		[NullableContext(2)]
		public override void WriteValue(object value)
		{
			if (value is BigInteger)
			{
				BigInteger bigInteger = (BigInteger)value;
				base.InternalWriteValue(JsonToken.Integer);
				this.WriteValueInternal(bigInteger.ToString(CultureInfo.InvariantCulture), JsonToken.String);
				return;
			}
			base.WriteValue(value);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000B97B File Offset: 0x00009B7B
		public override void WriteNull()
		{
			base.InternalWriteValue(JsonToken.Null);
			this.WriteValueInternal(JsonConvert.Null, JsonToken.Null);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000B992 File Offset: 0x00009B92
		public override void WriteUndefined()
		{
			base.InternalWriteValue(JsonToken.Undefined);
			this.WriteValueInternal(JsonConvert.Undefined, JsonToken.Undefined);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000B9A9 File Offset: 0x00009BA9
		[NullableContext(2)]
		public override void WriteRaw(string json)
		{
			base.InternalWriteRaw();
			this._writer.Write(json);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000B9BD File Offset: 0x00009BBD
		[NullableContext(2)]
		public override void WriteValue(string value)
		{
			base.InternalWriteValue(JsonToken.String);
			if (value == null)
			{
				this.WriteValueInternal(JsonConvert.Null, JsonToken.Null);
				return;
			}
			this.WriteEscapedString(value, true);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000B9E0 File Offset: 0x00009BE0
		private void WriteEscapedString(string value, bool quote)
		{
			this.EnsureWriteBuffer();
			JavaScriptUtils.WriteEscapedJavaScriptString(this._writer, value, this._quoteChar, quote, this._charEscapeFlags, base.StringEscapeHandling, this._arrayPool, ref this._writeBuffer);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000BA13 File Offset: 0x00009C13
		public override void WriteValue(int value)
		{
			base.InternalWriteValue(JsonToken.Integer);
			this.WriteIntegerValue(value);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000BA23 File Offset: 0x00009C23
		[CLSCompliant(false)]
		public override void WriteValue(uint value)
		{
			base.InternalWriteValue(JsonToken.Integer);
			this.WriteIntegerValue((long)((ulong)value));
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000BA34 File Offset: 0x00009C34
		public override void WriteValue(long value)
		{
			base.InternalWriteValue(JsonToken.Integer);
			this.WriteIntegerValue(value);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000BA44 File Offset: 0x00009C44
		[CLSCompliant(false)]
		public override void WriteValue(ulong value)
		{
			base.InternalWriteValue(JsonToken.Integer);
			this.WriteIntegerValue(value, false);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0000BA55 File Offset: 0x00009C55
		public override void WriteValue(float value)
		{
			base.InternalWriteValue(JsonToken.Float);
			this.WriteValueInternal(JsonConvert.ToString(value, base.FloatFormatHandling, this.QuoteChar, false), JsonToken.Float);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000BA78 File Offset: 0x00009C78
		public override void WriteValue(float? value)
		{
			if (value == null)
			{
				this.WriteNull();
				return;
			}
			base.InternalWriteValue(JsonToken.Float);
			this.WriteValueInternal(JsonConvert.ToString(value.GetValueOrDefault(), base.FloatFormatHandling, this.QuoteChar, true), JsonToken.Float);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000BAB1 File Offset: 0x00009CB1
		public override void WriteValue(double value)
		{
			base.InternalWriteValue(JsonToken.Float);
			this.WriteValueInternal(JsonConvert.ToString(value, base.FloatFormatHandling, this.QuoteChar, false), JsonToken.Float);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000BAD4 File Offset: 0x00009CD4
		public override void WriteValue(double? value)
		{
			if (value == null)
			{
				this.WriteNull();
				return;
			}
			base.InternalWriteValue(JsonToken.Float);
			this.WriteValueInternal(JsonConvert.ToString(value.GetValueOrDefault(), base.FloatFormatHandling, this.QuoteChar, true), JsonToken.Float);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000BB0D File Offset: 0x00009D0D
		public override void WriteValue(bool value)
		{
			base.InternalWriteValue(JsonToken.Boolean);
			this.WriteValueInternal(JsonConvert.ToString(value), JsonToken.Boolean);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000BB25 File Offset: 0x00009D25
		public override void WriteValue(short value)
		{
			base.InternalWriteValue(JsonToken.Integer);
			this.WriteIntegerValue((int)value);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000BB35 File Offset: 0x00009D35
		[CLSCompliant(false)]
		public override void WriteValue(ushort value)
		{
			base.InternalWriteValue(JsonToken.Integer);
			this.WriteIntegerValue((int)value);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000BB45 File Offset: 0x00009D45
		public override void WriteValue(char value)
		{
			base.InternalWriteValue(JsonToken.String);
			this.WriteValueInternal(JsonConvert.ToString(value), JsonToken.String);
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000BB5D File Offset: 0x00009D5D
		public override void WriteValue(byte value)
		{
			base.InternalWriteValue(JsonToken.Integer);
			this.WriteIntegerValue((int)value);
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000BB6D File Offset: 0x00009D6D
		[CLSCompliant(false)]
		public override void WriteValue(sbyte value)
		{
			base.InternalWriteValue(JsonToken.Integer);
			this.WriteIntegerValue((int)value);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000BB7D File Offset: 0x00009D7D
		public override void WriteValue(decimal value)
		{
			base.InternalWriteValue(JsonToken.Float);
			this.WriteValueInternal(JsonConvert.ToString(value), JsonToken.Float);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000BB94 File Offset: 0x00009D94
		public override void WriteValue(DateTime value)
		{
			base.InternalWriteValue(JsonToken.Date);
			value = DateTimeUtils.EnsureDateTime(value, base.DateTimeZoneHandling);
			if (StringUtils.IsNullOrEmpty(base.DateFormatString))
			{
				int count = this.WriteValueToBuffer(value);
				this._writer.Write(this._writeBuffer, 0, count);
				return;
			}
			this._writer.Write(this._quoteChar);
			this._writer.Write(value.ToString(base.DateFormatString, base.Culture));
			this._writer.Write(this._quoteChar);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000BC20 File Offset: 0x00009E20
		private int WriteValueToBuffer(DateTime value)
		{
			this.EnsureWriteBuffer();
			int num = 0;
			this._writeBuffer[num++] = this._quoteChar;
			num = DateTimeUtils.WriteDateTimeString(this._writeBuffer, num, value, null, value.Kind, base.DateFormatHandling);
			this._writeBuffer[num++] = this._quoteChar;
			return num;
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000BC80 File Offset: 0x00009E80
		[NullableContext(2)]
		public override void WriteValue(byte[] value)
		{
			if (value == null)
			{
				this.WriteNull();
				return;
			}
			base.InternalWriteValue(JsonToken.Bytes);
			this._writer.Write(this._quoteChar);
			this.Base64Encoder.Encode(value, 0, value.Length);
			this.Base64Encoder.Flush();
			this._writer.Write(this._quoteChar);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000BCDC File Offset: 0x00009EDC
		public override void WriteValue(DateTimeOffset value)
		{
			base.InternalWriteValue(JsonToken.Date);
			if (StringUtils.IsNullOrEmpty(base.DateFormatString))
			{
				int count = this.WriteValueToBuffer(value);
				this._writer.Write(this._writeBuffer, 0, count);
				return;
			}
			this._writer.Write(this._quoteChar);
			this._writer.Write(value.ToString(base.DateFormatString, base.Culture));
			this._writer.Write(this._quoteChar);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000BD5C File Offset: 0x00009F5C
		private int WriteValueToBuffer(DateTimeOffset value)
		{
			this.EnsureWriteBuffer();
			int num = 0;
			this._writeBuffer[num++] = this._quoteChar;
			num = DateTimeUtils.WriteDateTimeString(this._writeBuffer, num, (base.DateFormatHandling == DateFormatHandling.IsoDateFormat) ? value.DateTime : value.UtcDateTime, new TimeSpan?(value.Offset), DateTimeKind.Local, base.DateFormatHandling);
			this._writeBuffer[num++] = this._quoteChar;
			return num;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000BDD0 File Offset: 0x00009FD0
		public override void WriteValue(Guid value)
		{
			base.InternalWriteValue(JsonToken.String);
			string value2 = value.ToString("D", CultureInfo.InvariantCulture);
			this._writer.Write(this._quoteChar);
			this._writer.Write(value2);
			this._writer.Write(this._quoteChar);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000BE28 File Offset: 0x0000A028
		public override void WriteValue(TimeSpan value)
		{
			base.InternalWriteValue(JsonToken.String);
			string value2 = value.ToString(null, CultureInfo.InvariantCulture);
			this._writer.Write(this._quoteChar);
			this._writer.Write(value2);
			this._writer.Write(this._quoteChar);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000BE79 File Offset: 0x0000A079
		[NullableContext(2)]
		public override void WriteValue(Uri value)
		{
			if (value == null)
			{
				this.WriteNull();
				return;
			}
			base.InternalWriteValue(JsonToken.String);
			this.WriteEscapedString(value.OriginalString, true);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0000BEA0 File Offset: 0x0000A0A0
		[NullableContext(2)]
		public override void WriteComment(string text)
		{
			base.InternalWriteComment();
			this._writer.Write("/*");
			this._writer.Write(text);
			this._writer.Write("*/");
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0000BED4 File Offset: 0x0000A0D4
		public override void WriteWhitespace(string ws)
		{
			base.InternalWriteWhitespace(ws);
			this._writer.Write(ws);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0000BEE9 File Offset: 0x0000A0E9
		private void EnsureWriteBuffer()
		{
			if (this._writeBuffer == null)
			{
				this._writeBuffer = BufferUtils.RentBuffer(this._arrayPool, 35);
			}
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000BF08 File Offset: 0x0000A108
		private void WriteIntegerValue(long value)
		{
			if (value >= 0L && value <= 9L)
			{
				this._writer.Write((char)(48L + value));
				return;
			}
			bool flag = value < 0L;
			this.WriteIntegerValue((ulong)(flag ? (-(ulong)value) : value), flag);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000BF48 File Offset: 0x0000A148
		private void WriteIntegerValue(ulong value, bool negative)
		{
			if (!negative & value <= 9UL)
			{
				this._writer.Write((char)(48UL + value));
				return;
			}
			int count = this.WriteNumberToBuffer(value, negative);
			this._writer.Write(this._writeBuffer, 0, count);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000BF94 File Offset: 0x0000A194
		private int WriteNumberToBuffer(ulong value, bool negative)
		{
			if (value <= (ulong)-1)
			{
				return this.WriteNumberToBuffer((uint)value, negative);
			}
			this.EnsureWriteBuffer();
			int num = MathUtils.IntLength(value);
			if (negative)
			{
				num++;
				this._writeBuffer[0] = '-';
			}
			int num2 = num;
			do
			{
				ulong num3 = value / 10UL;
				ulong num4 = value - num3 * 10UL;
				this._writeBuffer[--num2] = (char)(48UL + num4);
				value = num3;
			}
			while (value != 0UL);
			return num;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000BFF8 File Offset: 0x0000A1F8
		private void WriteIntegerValue(int value)
		{
			if (value >= 0 && value <= 9)
			{
				this._writer.Write((char)(48 + value));
				return;
			}
			bool flag = value < 0;
			this.WriteIntegerValue((uint)(flag ? (-(uint)value) : value), flag);
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0000C034 File Offset: 0x0000A234
		private void WriteIntegerValue(uint value, bool negative)
		{
			if (!negative & value <= 9U)
			{
				this._writer.Write((char)(48U + value));
				return;
			}
			int count = this.WriteNumberToBuffer(value, negative);
			this._writer.Write(this._writeBuffer, 0, count);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000C080 File Offset: 0x0000A280
		private int WriteNumberToBuffer(uint value, bool negative)
		{
			this.EnsureWriteBuffer();
			int num = MathUtils.IntLength((ulong)value);
			if (negative)
			{
				num++;
				this._writeBuffer[0] = '-';
			}
			int num2 = num;
			do
			{
				uint num3 = value / 10U;
				uint num4 = value - num3 * 10U;
				this._writeBuffer[--num2] = (char)(48U + num4);
				value = num3;
			}
			while (value != 0U);
			return num;
		}

		// Token: 0x040000E0 RID: 224
		private readonly bool _safeAsync;

		// Token: 0x040000E1 RID: 225
		private const int IndentCharBufferSize = 12;

		// Token: 0x040000E2 RID: 226
		private readonly TextWriter _writer;

		// Token: 0x040000E3 RID: 227
		[Nullable(2)]
		private Base64Encoder _base64Encoder;

		// Token: 0x040000E4 RID: 228
		private char _indentChar;

		// Token: 0x040000E5 RID: 229
		private int _indentation;

		// Token: 0x040000E6 RID: 230
		private char _quoteChar;

		// Token: 0x040000E7 RID: 231
		private bool _quoteName;

		// Token: 0x040000E8 RID: 232
		[Nullable(2)]
		private bool[] _charEscapeFlags;

		// Token: 0x040000E9 RID: 233
		[Nullable(2)]
		private char[] _writeBuffer;

		// Token: 0x040000EA RID: 234
		[Nullable(2)]
		private IArrayPool<char> _arrayPool;

		// Token: 0x040000EB RID: 235
		[Nullable(2)]
		private char[] _indentChars;
	}
}
