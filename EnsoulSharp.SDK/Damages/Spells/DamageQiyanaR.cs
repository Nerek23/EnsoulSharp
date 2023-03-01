using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000261 RID: 609
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Qiyana", SpellSlot.R, 0)]
	public class DamageQiyanaR : DamageSpell
	{
		// Token: 0x06000D3D RID: 3389 RVA: 0x0003F792 File Offset: 0x0003D992
		public DamageQiyanaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x0003F7A8 File Offset: 0x0003D9A8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageQiyanaR.damages[level] + 1.7 * (double)source.GetBonusAaDamage() + DamageQiyanaR.damagePercents[level] * (double)target.MaxHealth;
		}

		// Token: 0x04000768 RID: 1896
		private static readonly double[] damages = new double[]
		{
			100.0,
			200.0,
			300.0
		};

		// Token: 0x04000769 RID: 1897
		private static readonly double[] damagePercents = new double[]
		{
			0.1,
			0.12,
			0.14
		};
	}
}
