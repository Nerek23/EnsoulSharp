using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000209 RID: 521
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lillia", SpellSlot.W, 1)]
	public class DamageLilliaW2 : DamageSpell
	{
		// Token: 0x06000C36 RID: 3126 RVA: 0x0003DC23 File Offset: 0x0003BE23
		public DamageLilliaW2()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x0003DC40 File Offset: 0x0003BE40
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageLilliaW2.damages[level] + 1.05 * (double)source.TotalMagicalDamage;
			if (target.Type != GameObjectType.AIMinionClient)
			{
				return num;
			}
			return num * 0.5;
		}

		// Token: 0x0400070D RID: 1805
		private static readonly double[] damages = new double[]
		{
			240.0,
			300.0,
			360.0,
			420.0,
			480.0
		};
	}
}
