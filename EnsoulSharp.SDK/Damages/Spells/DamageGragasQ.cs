using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000199 RID: 409
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gragas", SpellSlot.Q, 0)]
	public class DamageGragasQ : DamageSpell
	{
		// Token: 0x06000AE3 RID: 2787 RVA: 0x0003B74D File Offset: 0x0003994D
		public DamageGragasQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0003B764 File Offset: 0x00039964
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageGragasQ.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
			if (target.Type != GameObjectType.AIMinionClient)
			{
				return num;
			}
			return 0.7 * num;
		}

		// Token: 0x04000698 RID: 1688
		private static readonly double[] damages = new double[]
		{
			80.0,
			120.0,
			160.0,
			200.0,
			240.0
		};
	}
}
