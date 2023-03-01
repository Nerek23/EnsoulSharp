using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Linq
{
	// Token: 0x020000C1 RID: 193
	[NullableContext(1)]
	[Nullable(0)]
	public class JRaw : JValue
	{
		// Token: 0x06000AA9 RID: 2729 RVA: 0x0002AAF0 File Offset: 0x00028CF0
		public static async Task<JRaw> CreateAsync(JsonReader reader, CancellationToken cancellationToken = default(CancellationToken))
		{
			JRaw result;
			using (StringWriter sw = new StringWriter(CultureInfo.InvariantCulture))
			{
				using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
				{
					await jsonWriter.WriteTokenSyncReadingAsync(reader, cancellationToken).ConfigureAwait(false);
					result = new JRaw(sw.ToString());
				}
			}
			return result;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x0002AB3D File Offset: 0x00028D3D
		public JRaw(JRaw other) : base(other)
		{
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0002AB46 File Offset: 0x00028D46
		[NullableContext(2)]
		public JRaw(object rawJson) : base(rawJson, JTokenType.Raw)
		{
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x0002AB54 File Offset: 0x00028D54
		public static JRaw Create(JsonReader reader)
		{
			JRaw result;
			using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
			{
				using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
				{
					jsonTextWriter.WriteToken(reader);
					result = new JRaw(stringWriter.ToString());
				}
			}
			return result;
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x0002ABBC File Offset: 0x00028DBC
		internal override JToken CloneToken()
		{
			return new JRaw(this);
		}
	}
}
