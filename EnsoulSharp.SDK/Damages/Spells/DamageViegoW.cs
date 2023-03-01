using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000304 RID: 772
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Veigar", SpellSlot.W, 0)]
	public class DamageViegoW : DamageSpell
	{
		// Token: 0x06000F25 RID: 3877 RVA: 0x00042ED0 File Offset: 0x000410D0
		public DamageViegoW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x00042EE6 File Offset: 0x000410E6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageViegoW.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x04000822 RID: 2082
		private static readonly double[] damages = new double[]
		{
			80.0,
			135.0,
			190.0,
			245.0,
			300.0
		};
	}
}
