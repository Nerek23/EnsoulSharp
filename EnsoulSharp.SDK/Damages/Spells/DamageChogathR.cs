using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000154 RID: 340
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Chogath", SpellSlot.R, 0)]
	public class DamageChogathR : DamageSpell
	{
		// Token: 0x06000A0A RID: 2570 RVA: 0x00039F94 File Offset: 0x00038194
		public DamageChogathR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00039FAC File Offset: 0x000381AC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double result = DamageChogathR.damages[level] + 0.5 * (double)source.TotalMagicalDamage + 0.1 * (double)source.BonusHealth;
			if (target.Type == GameObjectType.AIMinionClient)
			{
				result = 1200.0 + 0.5 * (double)source.TotalMagicalDamage + 0.1 * (double)source.BonusHealth;
			}
			return result;
		}

		// Token: 0x04000642 RID: 1602
		private static readonly double[] damages = new double[]
		{
			300.0,
			475.0,
			650.0
		};
	}
}
