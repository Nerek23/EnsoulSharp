using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200020D RID: 525
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lillia", SpellSlot.W, 0)]
	public class DamageLilliaW : DamageSpell
	{
		// Token: 0x06000C42 RID: 3138 RVA: 0x0003DD7F File Offset: 0x0003BF7F
		public DamageLilliaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x0003DD98 File Offset: 0x0003BF98
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageLilliaW.damages[level] + 0.35 * (double)source.TotalMagicalDamage;
			if (target.Type != GameObjectType.AIMinionClient)
			{
				return num;
			}
			return num * 0.5;
		}

		// Token: 0x04000711 RID: 1809
		private static readonly double[] damages = new double[]
		{
			80.0,
			100.0,
			120.0,
			140.0,
			160.0
		};
	}
}
