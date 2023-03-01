using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000219 RID: 537
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lissandra", SpellSlot.R, 0)]
	public class DamageLissandraR : DamageSpell
	{
		// Token: 0x06000C66 RID: 3174 RVA: 0x0003E117 File Offset: 0x0003C317
		public DamageLissandraR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x0003E12D File Offset: 0x0003C32D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLissandraR.damages[level] + 0.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400071D RID: 1821
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
