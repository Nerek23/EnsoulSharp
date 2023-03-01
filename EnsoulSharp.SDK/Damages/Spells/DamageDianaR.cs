using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000163 RID: 355
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Diana", SpellSlot.R, 0)]
	public class DamageDianaR : DamageSpell
	{
		// Token: 0x06000A41 RID: 2625 RVA: 0x0003A4F6 File Offset: 0x000386F6
		public DamageDianaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x0003A50C File Offset: 0x0003870C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageDianaR.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000657 RID: 1623
		private static readonly double[] damages = new double[]
		{
			200.0,
			300.0,
			400.0
		};
	}
}
