using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001BE RID: 446
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jayce", SpellSlot.Q, 0)]
	public class DamageJayceQ : DamageSpell
	{
		// Token: 0x06000B58 RID: 2904 RVA: 0x0003C290 File Offset: 0x0003A490
		public DamageJayceQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x0003C2A6 File Offset: 0x0003A4A6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJayceQ.damages[level] + 1.2 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006BC RID: 1724
		private static readonly double[] damages = new double[]
		{
			60.0,
			110.0,
			160.0,
			210.0,
			260.0,
			310.0
		};
	}
}
