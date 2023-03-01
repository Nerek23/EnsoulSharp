using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002E1 RID: 737
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Teemo", SpellSlot.E, 0)]
	public class DamageTeemoE : DamageSpell
	{
		// Token: 0x06000EBC RID: 3772 RVA: 0x000422FA File Offset: 0x000404FA
		public DamageTeemoE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x00042310 File Offset: 0x00040510
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTeemoE.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007F9 RID: 2041
		private static readonly double[] damages = new double[]
		{
			14.0,
			25.0,
			36.0,
			47.0,
			58.0
		};
	}
}
