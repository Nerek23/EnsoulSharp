using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000215 RID: 533
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Leona", SpellSlot.R, 0)]
	public class DamageLeonaR : DamageSpell
	{
		// Token: 0x06000C5A RID: 3162 RVA: 0x0003DFF3 File Offset: 0x0003C1F3
		public DamageLeonaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x0003E009 File Offset: 0x0003C209
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeonaR.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000719 RID: 1817
		private static readonly double[] damages = new double[]
		{
			100.0,
			175.0,
			250.0
		};
	}
}
