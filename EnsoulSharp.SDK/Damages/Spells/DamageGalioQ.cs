using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200018A RID: 394
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Galio", SpellSlot.Q, 0)]
	public class DamageGalioQ : DamageSpell
	{
		// Token: 0x06000AB6 RID: 2742 RVA: 0x0003B238 File Offset: 0x00039438
		public DamageGalioQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0003B24E File Offset: 0x0003944E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGalioQ.damages[level] + 0.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000685 RID: 1669
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
