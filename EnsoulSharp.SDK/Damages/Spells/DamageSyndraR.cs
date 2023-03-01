using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002D2 RID: 722
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Syndra", SpellSlot.R, 0)]
	public class DamageSyndraR : DamageSpell
	{
		// Token: 0x06000E8F RID: 3727 RVA: 0x00041D3A File Offset: 0x0003FF3A
		public DamageSyndraR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x00041D50 File Offset: 0x0003FF50
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageSyndraR.damages[level] + 0.17 * (double)source.TotalMagicalDamage) * (double)source.Spellbook.GetSpell(SpellSlot.R).Ammo;
		}

		// Token: 0x040007E9 RID: 2025
		private static readonly double[] damages = new double[]
		{
			90.0,
			130.0,
			170.0
		};
	}
}
