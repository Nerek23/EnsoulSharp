using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000176 RID: 374
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
	[MetadataAttribute]
	public class ExportDamageMetadataAttribute : ExportAttribute, IDamageSpellMetadata
	{
		// Token: 0x06000A79 RID: 2681 RVA: 0x0003ABD9 File Offset: 0x00038DD9
		public ExportDamageMetadataAttribute(string championName, SpellSlot slot, int stage = 0) : base(typeof(IDamageSpellMetadata))
		{
			this.ChampionName = championName;
			this.SpellSlot = slot;
			this.Stage = stage;
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000A7A RID: 2682 RVA: 0x0003AC00 File Offset: 0x00038E00
		public string ChampionName { get; }

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0003AC08 File Offset: 0x00038E08
		public SpellSlot SpellSlot { get; }

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000A7C RID: 2684 RVA: 0x0003AC10 File Offset: 0x00038E10
		public int Stage { get; }
	}
}
