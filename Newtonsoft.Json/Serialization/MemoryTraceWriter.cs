using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x0200009B RID: 155
	[NullableContext(1)]
	[Nullable(0)]
	public class MemoryTraceWriter : ITraceWriter
	{
		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x00023941 File Offset: 0x00021B41
		// (set) Token: 0x0600081A RID: 2074 RVA: 0x00023949 File Offset: 0x00021B49
		public TraceLevel LevelFilter { get; set; }

		// Token: 0x0600081B RID: 2075 RVA: 0x00023952 File Offset: 0x00021B52
		public MemoryTraceWriter()
		{
			this.LevelFilter = TraceLevel.Verbose;
			this._traceMessages = new Queue<string>();
			this._lock = new object();
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00023978 File Offset: 0x00021B78
		public void Trace(TraceLevel level, string message, [Nullable(2)] Exception ex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff", CultureInfo.InvariantCulture));
			stringBuilder.Append(" ");
			stringBuilder.Append(level.ToString("g"));
			stringBuilder.Append(" ");
			stringBuilder.Append(message);
			string item = stringBuilder.ToString();
			object @lock = this._lock;
			lock (@lock)
			{
				if (this._traceMessages.Count >= 1000)
				{
					this._traceMessages.Dequeue();
				}
				this._traceMessages.Enqueue(item);
			}
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00023A3C File Offset: 0x00021C3C
		public IEnumerable<string> GetTraceMessages()
		{
			return this._traceMessages;
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00023A44 File Offset: 0x00021C44
		public override string ToString()
		{
			object @lock = this._lock;
			string result;
			lock (@lock)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string value in this._traceMessages)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.Append(value);
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x040002C1 RID: 705
		private readonly Queue<string> _traceMessages;

		// Token: 0x040002C2 RID: 706
		private readonly object _lock;
	}
}
