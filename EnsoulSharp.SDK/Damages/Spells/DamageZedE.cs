using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000343 RID: 835
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zed", SpellSlot.E, 0)]
	public class DamageZedE : DamageSpell
	{
		// Token: 0x06000FE2 RID: 4066 RVA: 0x0004434F File Offset: 0x0004254F
		public DamageZedE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x00044365 File Offset: 0x00042565
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZedE.damages[level] + 0.65 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000868 RID: 2152
		private static readonly double[] damages = new double[]
		{
			70.0,
			90.0,
			110.0,
			130.0,
			150.0
		};
	}
}
