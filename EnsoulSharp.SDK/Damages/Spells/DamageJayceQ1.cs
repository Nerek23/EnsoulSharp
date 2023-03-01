using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001BF RID: 447
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jayce", SpellSlot.Q, 1)]
	public class DamageJayceQ1 : DamageSpell
	{
		// Token: 0x06000B5B RID: 2907 RVA: 0x0003C2D9 File Offset: 0x0003A4D9
		public DamageJayceQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x0003C2F6 File Offset: 0x0003A4F6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJayceQ1.damages[level] + (double)(1f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x040006BD RID: 1725
		private static readonly double[] damages = new double[]
		{
			55.0,
			110.0,
			165.0,
			220.0,
			275.0,
			330.0
		};
	}
}
