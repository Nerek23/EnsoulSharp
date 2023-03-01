using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000311 RID: 785
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Velkoz", SpellSlot.W, 0)]
	public class DamageVelkozW : DamageSpell
	{
		// Token: 0x06000F4C RID: 3916 RVA: 0x00043318 File Offset: 0x00041518
		public DamageVelkozW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x0004332E File Offset: 0x0004152E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVelkozW.damages[level] + DamageVelkozW.doubledamages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000830 RID: 2096
		private static readonly double[] damages = new double[]
		{
			30.0,
			50.0,
			70.0,
			90.0,
			110.0
		};

		// Token: 0x04000831 RID: 2097
		private static readonly double[] doubledamages = new double[]
		{
			45.0,
			75.0,
			105.0,
			135.0,
			165.0
		};
	}
}
