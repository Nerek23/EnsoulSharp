using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200030F RID: 783
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Velkoz", SpellSlot.Q, 0)]
	public class DamageVelkozQ : DamageSpell
	{
		// Token: 0x06000F46 RID: 3910 RVA: 0x0004324C File Offset: 0x0004144C
		public DamageVelkozQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x00043262 File Offset: 0x00041462
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVelkozQ.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400082E RID: 2094
		private static readonly double[] damages = new double[]
		{
			80.0,
			120.0,
			160.0,
			200.0,
			240.0
		};
	}
}
