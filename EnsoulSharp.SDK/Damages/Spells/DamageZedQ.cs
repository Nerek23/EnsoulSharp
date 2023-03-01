using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000344 RID: 836
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zed", SpellSlot.Q, 0)]
	public class DamageZedQ : DamageSpell
	{
		// Token: 0x06000FE5 RID: 4069 RVA: 0x00044398 File Offset: 0x00042598
		public DamageZedQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x000443AE File Offset: 0x000425AE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZedQ.damages[level] + 1.1 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000869 RID: 2153
		private static readonly double[] damages = new double[]
		{
			80.0,
			115.0,
			150.0,
			185.0,
			220.0
		};
	}
}
