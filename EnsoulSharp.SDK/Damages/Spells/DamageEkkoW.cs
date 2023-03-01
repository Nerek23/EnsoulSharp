using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200016D RID: 365
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ekko", SpellSlot.W, 0)]
	public class DamageEkkoW : DamageSpell
	{
		// Token: 0x06000A5F RID: 2655 RVA: 0x0003A87E File Offset: 0x00038A7E
		public DamageEkkoW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0003A894 File Offset: 0x00038A94
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = (0.03 + (double)(source.TotalMagicalDamage / 100f) * 0.03) * (double)(target.MaxHealth - target.Health);
			if (target.Type != GameObjectType.AIMinionClient)
			{
				return num;
			}
			return Math.Min(150.0, Math.Max(15.0, num));
		}
	}
}
