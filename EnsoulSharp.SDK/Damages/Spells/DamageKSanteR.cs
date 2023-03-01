using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000FF RID: 255
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("KSante", SpellSlot.R, 0)]
	public class DamageKSanteR : DamageSpell
	{
		// Token: 0x0600090C RID: 2316 RVA: 0x00038315 File Offset: 0x00036515
		public DamageKSanteR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0003832B File Offset: 0x0003652B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKSanteR.damages[level] + 0.2 * (double)source.TotalAttackDamage;
		}

		// Token: 0x040005E0 RID: 1504
		private static readonly double[] damages = new double[]
		{
			35.0,
			70.0,
			105.0
		};
	}
}
