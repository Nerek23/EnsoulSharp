using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000223 RID: 547
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Malphite", SpellSlot.E, 0)]
	public class DamageMalphiteE : DamageSpell
	{
		// Token: 0x06000C84 RID: 3204 RVA: 0x0003E413 File Offset: 0x0003C613
		public DamageMalphiteE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x0003E429 File Offset: 0x0003C629
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMalphiteE.damages[level] + 0.6 * (double)source.TotalMagicalDamage + 0.4 * (double)source.Armor;
		}

		// Token: 0x04000728 RID: 1832
		private static readonly double[] damages = new double[]
		{
			70.0,
			110.0,
			150.0,
			190.0,
			230.0
		};
	}
}
