using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000337 RID: 823
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Yorick", SpellSlot.E, 0)]
	public class DamageYorickE : DamageSpell
	{
		// Token: 0x06000FBE RID: 4030 RVA: 0x00043F36 File Offset: 0x00042136
		public DamageYorickE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x00043F4C File Offset: 0x0004214C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYorickE.damages[level] + 0.7 * (double)source.TotalMagicalDamage + 0.15 * (double)target.Health;
		}

		// Token: 0x04000859 RID: 2137
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0,
			175.0,
			210.0
		};
	}
}
