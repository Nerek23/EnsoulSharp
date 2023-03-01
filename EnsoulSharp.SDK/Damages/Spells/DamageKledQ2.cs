using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001E3 RID: 483
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kayn", SpellSlot.Q, 2)]
	public class DamageKledQ2 : DamageSpell
	{
		// Token: 0x06000BC5 RID: 3013 RVA: 0x0003CFEC File Offset: 0x0003B1EC
		public DamageKledQ2()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x0003D009 File Offset: 0x0003B209
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKledQ2.damages[level] + 0.8 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006E6 RID: 1766
		private static readonly double[] damages = new double[]
		{
			35.0,
			50.0,
			65.0,
			80.0,
			95.0
		};
	}
}
