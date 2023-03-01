using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000319 RID: 793
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vi", SpellSlot.R, 0)]
	public class DamageViR : DamageSpell
	{
		// Token: 0x06000F64 RID: 3940 RVA: 0x0004359E File Offset: 0x0004179E
		public DamageViR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x000435B4 File Offset: 0x000417B4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageViR.damages[level] + 1.1 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x04000839 RID: 2105
		private static readonly double[] damages = new double[]
		{
			150.0,
			325.0,
			500.0
		};
	}
}
