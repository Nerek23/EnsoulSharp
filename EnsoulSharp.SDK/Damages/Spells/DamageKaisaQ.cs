using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001CA RID: 458
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kaisa", SpellSlot.Q, 0)]
	public class DamageKaisaQ : DamageSpell
	{
		// Token: 0x06000B7B RID: 2939 RVA: 0x0003C683 File Offset: 0x0003A883
		public DamageKaisaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x0003C699 File Offset: 0x0003A899
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKaisaQ.damages[level] + 0.4 * (double)source.GetBonusPhysicalDamage() + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006C9 RID: 1737
		private static readonly double[] damages = new double[]
		{
			40.0,
			55.0,
			70.0,
			85.0,
			100.0
		};
	}
}
