using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200029A RID: 666
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rumble", SpellSlot.E, 1)]
	public class DamageRumbleE1 : DamageSpell
	{
		// Token: 0x06000DE7 RID: 3559 RVA: 0x00040A4C File Offset: 0x0003EC4C
		public DamageRumbleE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x00040A69 File Offset: 0x0003EC69
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRumbleE1.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007A9 RID: 1961
		private static readonly double[] damages = new double[]
		{
			90.0,
			127.5,
			165.0,
			202.5,
			240.0
		};
	}
}
