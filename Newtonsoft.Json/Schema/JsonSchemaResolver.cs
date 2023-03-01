using System;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.Json.Schema
{
	// Token: 0x020000AF RID: 175
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	public class JsonSchemaResolver
	{
		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600095D RID: 2397 RVA: 0x0002732D File Offset: 0x0002552D
		// (set) Token: 0x0600095E RID: 2398 RVA: 0x00027335 File Offset: 0x00025535
		public IList<JsonSchema> LoadedSchemas { get; protected set; }

		// Token: 0x0600095F RID: 2399 RVA: 0x0002733E File Offset: 0x0002553E
		public JsonSchemaResolver()
		{
			this.LoadedSchemas = new List<JsonSchema>();
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00027354 File Offset: 0x00025554
		public virtual JsonSchema GetSchema(string reference)
		{
			JsonSchema jsonSchema = this.LoadedSchemas.SingleOrDefault((JsonSchema s) => string.Equals(s.Id, reference, StringComparison.Ordinal));
			if (jsonSchema == null)
			{
				jsonSchema = this.LoadedSchemas.SingleOrDefault((JsonSchema s) => string.Equals(s.Location, reference, StringComparison.Ordinal));
			}
			return jsonSchema;
		}
	}
}
