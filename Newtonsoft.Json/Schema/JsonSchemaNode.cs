using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Newtonsoft.Json.Schema
{
	// Token: 0x020000AD RID: 173
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	internal class JsonSchemaNode
	{
		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x00027172 File Offset: 0x00025372
		public string Id { get; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600094F RID: 2383 RVA: 0x0002717A File Offset: 0x0002537A
		public ReadOnlyCollection<JsonSchema> Schemas { get; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x00027182 File Offset: 0x00025382
		public Dictionary<string, JsonSchemaNode> Properties { get; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x0002718A File Offset: 0x0002538A
		public Dictionary<string, JsonSchemaNode> PatternProperties { get; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x00027192 File Offset: 0x00025392
		public List<JsonSchemaNode> Items { get; }

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x0002719A File Offset: 0x0002539A
		// (set) Token: 0x06000954 RID: 2388 RVA: 0x000271A2 File Offset: 0x000253A2
		public JsonSchemaNode AdditionalProperties { get; set; }

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x000271AB File Offset: 0x000253AB
		// (set) Token: 0x06000956 RID: 2390 RVA: 0x000271B3 File Offset: 0x000253B3
		public JsonSchemaNode AdditionalItems { get; set; }

		// Token: 0x06000957 RID: 2391 RVA: 0x000271BC File Offset: 0x000253BC
		public JsonSchemaNode(JsonSchema schema)
		{
			this.Schemas = new ReadOnlyCollection<JsonSchema>(new JsonSchema[]
			{
				schema
			});
			this.Properties = new Dictionary<string, JsonSchemaNode>();
			this.PatternProperties = new Dictionary<string, JsonSchemaNode>();
			this.Items = new List<JsonSchemaNode>();
			this.Id = JsonSchemaNode.GetId(this.Schemas);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00027218 File Offset: 0x00025418
		private JsonSchemaNode(JsonSchemaNode source, JsonSchema schema)
		{
			this.Schemas = new ReadOnlyCollection<JsonSchema>(source.Schemas.Union(new JsonSchema[]
			{
				schema
			}).ToList<JsonSchema>());
			this.Properties = new Dictionary<string, JsonSchemaNode>(source.Properties);
			this.PatternProperties = new Dictionary<string, JsonSchemaNode>(source.PatternProperties);
			this.Items = new List<JsonSchemaNode>(source.Items);
			this.AdditionalProperties = source.AdditionalProperties;
			this.AdditionalItems = source.AdditionalItems;
			this.Id = JsonSchemaNode.GetId(this.Schemas);
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x000272AC File Offset: 0x000254AC
		public JsonSchemaNode Combine(JsonSchema schema)
		{
			return new JsonSchemaNode(this, schema);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x000272B8 File Offset: 0x000254B8
		public static string GetId(IEnumerable<JsonSchema> schemata)
		{
			return string.Join("-", (from s in schemata
			select s.InternalId).OrderBy((string id) => id, StringComparer.Ordinal));
		}
	}
}
