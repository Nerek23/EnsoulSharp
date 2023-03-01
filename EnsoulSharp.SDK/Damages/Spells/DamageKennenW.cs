using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001F0 RID: 496
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kennen", SpellSlot.W, 0)]
	public class DamageKennenW : DamageSpell
	{
		// Token: 0x06000BEB RID: 3051 RVA: 0x0003D409 File Offset: 0x0003B609
		public DamageKennenW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0003D41F File Offset: 0x0003B61F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKennenW.damages[level] + DamageKennenW.damagePercents[level] * (double)source.GetBonusPhysicalDamage() + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006F3 RID: 1779
		private static readonly double[] damages = new double[]
		{
			35.0,
			45.0,
			55.0,
			65.0,
			75.0
		};

		// Token: 0x040006F4 RID: 1780
		private static readonly double[] damagePercents = new double[]
		{
			0.8,
			0.9,
			1.0,
			1.1,
			1.2
		};
	}
}
