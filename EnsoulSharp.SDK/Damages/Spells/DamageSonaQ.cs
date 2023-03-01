using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002BF RID: 703
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sona", SpellSlot.Q, 0)]
	public class DamageSonaQ : DamageSpell
	{
		// Token: 0x06000E56 RID: 3670 RVA: 0x0004177D File Offset: 0x0003F97D
		public DamageSonaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x00041793 File Offset: 0x0003F993
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSonaQ.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007D6 RID: 2006
		private static readonly double[] damages = new double[]
		{
			50.0,
			80.0,
			110.0,
			140.0,
			170.0
		};
	}
}
