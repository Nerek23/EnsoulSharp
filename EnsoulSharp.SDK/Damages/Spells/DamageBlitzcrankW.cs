using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000F4 RID: 244
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Blitzcrank", SpellSlot.W, 0)]
	public class DamageBlitzcrankW : DamageSpell
	{
		// Token: 0x060008EC RID: 2284 RVA: 0x00037E78 File Offset: 0x00036078
		public DamageBlitzcrankW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00037E90 File Offset: 0x00036090
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = (double)target.MaxHealth * 0.01;
			if (target.Type == GameObjectType.AIMinionClient)
			{
				num += (double)(60 + 7 * (source.Level - 1));
			}
			return num;
		}
	}
}
