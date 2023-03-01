using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000299 RID: 665
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rumble", SpellSlot.E, 0)]
	public class DamageRumbleE : DamageSpell
	{
		// Token: 0x06000DE4 RID: 3556 RVA: 0x00040A03 File Offset: 0x0003EC03
		public DamageRumbleE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x00040A19 File Offset: 0x0003EC19
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRumbleE.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007A8 RID: 1960
		private static readonly double[] damages = new double[]
		{
			60.0,
			85.0,
			110.0,
			135.0,
			160.0
		};
	}
}
