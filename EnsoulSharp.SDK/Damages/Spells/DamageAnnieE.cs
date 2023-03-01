using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000128 RID: 296
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Annie", SpellSlot.E, 0)]
	public class DamageAnnieE : DamageSpell
	{
		// Token: 0x06000987 RID: 2439 RVA: 0x000390DB File Offset: 0x000372DB
		public DamageAnnieE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x000390F1 File Offset: 0x000372F1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAnnieE.damages[level] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000610 RID: 1552
		private static readonly double[] damages = new double[]
		{
			20.0,
			30.0,
			40.0,
			50.0,
			60.0
		};
	}
}
