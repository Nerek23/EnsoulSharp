using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000254 RID: 596
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Olaf", SpellSlot.E, 0)]
	public class DamageOlafE : DamageSpell
	{
		// Token: 0x06000D16 RID: 3350 RVA: 0x0003F3DA File Offset: 0x0003D5DA
		public DamageOlafE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x0003F3F0 File Offset: 0x0003D5F0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageOlafE.damages[level] + 0.5 * (double)source.TotalAttackDamage;
		}

		// Token: 0x0400075B RID: 1883
		private static readonly double[] damages = new double[]
		{
			70.0,
			115.0,
			160.0,
			205.0,
			250.0
		};
	}
}
