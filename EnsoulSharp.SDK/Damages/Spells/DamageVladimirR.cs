using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200031E RID: 798
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vladimir", SpellSlot.R, 0)]
	public class DamageVladimirR : DamageSpell
	{
		// Token: 0x06000F73 RID: 3955 RVA: 0x00043736 File Offset: 0x00041936
		public DamageVladimirR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x0004374C File Offset: 0x0004194C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVladimirR.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400083E RID: 2110
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
