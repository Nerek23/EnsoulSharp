using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000226 RID: 550
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Malzahar", SpellSlot.E, 0)]
	public class DamageMalzaharE : DamageSpell
	{
		// Token: 0x06000C8D RID: 3213 RVA: 0x0003E500 File Offset: 0x0003C700
		public DamageMalzaharE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x0003E516 File Offset: 0x0003C716
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMalzaharE.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400072B RID: 1835
		private static readonly double[] damages = new double[]
		{
			80.0,
			115.0,
			150.0,
			185.0,
			220.0
		};
	}
}
