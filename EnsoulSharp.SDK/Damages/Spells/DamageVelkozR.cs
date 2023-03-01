using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000310 RID: 784
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Velkoz", SpellSlot.R, 0)]
	public class DamageVelkozR : DamageSpell
	{
		// Token: 0x06000F49 RID: 3913 RVA: 0x00043295 File Offset: 0x00041495
		public DamageVelkozR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x000432AC File Offset: 0x000414AC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			if (!target.HasBuff("velkozresearchedstack"))
			{
				return source.CalculateMagicDamage(target, DamageVelkozR.damages[level] + 1.25 * (double)source.TotalMagicalDamage);
			}
			return DamageVelkozR.damages[level] + 1.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400082F RID: 2095
		private static readonly double[] damages = new double[]
		{
			450.0,
			625.0,
			800.0
		};
	}
}
