using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001A1 RID: 417
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Hecarim", SpellSlot.Q, 0)]
	public class DamageHecarimQ : DamageSpell
	{
		// Token: 0x06000AFB RID: 2811 RVA: 0x0003B9E1 File Offset: 0x00039BE1
		public DamageHecarimQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0003B9F8 File Offset: 0x00039BF8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageHecarimQ.damages[level] + 0.9 * (double)source.GetBonusPhysicalDamage();
			if (target.Type != GameObjectType.AIMinionClient)
			{
				return num;
			}
			return 0.6 * num;
		}

		// Token: 0x040006A1 RID: 1697
		private static readonly double[] damages = new double[]
		{
			60.0,
			85.0,
			110.0,
			135.0,
			160.0
		};
	}
}
