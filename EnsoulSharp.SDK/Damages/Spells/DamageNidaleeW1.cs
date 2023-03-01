using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200024C RID: 588
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nidalee", SpellSlot.W, 1)]
	public class DamageNidaleeW1 : DamageSpell
	{
		// Token: 0x06000CFE RID: 3326 RVA: 0x0003F126 File Offset: 0x0003D326
		public DamageNidaleeW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x0003F144 File Offset: 0x0003D344
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			int num = source.Spellbook.GetSpell(SpellSlot.R).Level;
			if (num == 0)
			{
				num = 1;
			}
			return DamageNidaleeW1.damages[num - 1] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000752 RID: 1874
		private static readonly double[] damages = new double[]
		{
			60.0,
			110.0,
			160.0,
			210.0
		};
	}
}
