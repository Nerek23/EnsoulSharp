using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000211 RID: 529
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Neeko", SpellSlot.R, 0)]
	public class DamageNeekoR : DamageSpell
	{
		// Token: 0x06000C4E RID: 3150 RVA: 0x0003DECF File Offset: 0x0003C0CF
		public DamageNeekoR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x0003DEE5 File Offset: 0x0003C0E5
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNeekoR.damages[level] + 1.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000715 RID: 1813
		private static readonly double[] damages = new double[]
		{
			200.0,
			425.0,
			650.0
		};
	}
}
