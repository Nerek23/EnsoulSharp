using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001AC RID: 428
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Illaoi", SpellSlot.W, 0)]
	public class DamageIllaoiW : DamageSpell
	{
		// Token: 0x06000B22 RID: 2850 RVA: 0x0003BCAE File Offset: 0x00039EAE
		public DamageIllaoiW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0003BCC4 File Offset: 0x00039EC4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageIllaoiW.damages[level] + 0.04 * (double)source.TotalAttackDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x040006A9 RID: 1705
		private static readonly double[] damages = new double[]
		{
			0.03,
			0.035,
			0.04,
			0.045,
			0.05
		};
	}
}
