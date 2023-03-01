using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001CD RID: 461
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kalista", SpellSlot.Q, 0)]
	public class DamageKalistaQ : DamageSpell
	{
		// Token: 0x06000B84 RID: 2948 RVA: 0x0003C7FF File Offset: 0x0003A9FF
		public DamageKalistaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0003C815 File Offset: 0x0003AA15
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKalistaQ.damages[level] + (double)source.TotalAttackDamage;
		}

		// Token: 0x040006CE RID: 1742
		private static readonly double[] damages = new double[]
		{
			20.0,
			85.0,
			150.0,
			215.0,
			280.0
		};
	}
}
