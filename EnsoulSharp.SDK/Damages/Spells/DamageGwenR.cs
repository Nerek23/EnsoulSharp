using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000FA RID: 250
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gwen", SpellSlot.R, 0)]
	public class DamageGwenR : DamageSpell
	{
		// Token: 0x060008FD RID: 2301 RVA: 0x0003809B File Offset: 0x0003629B
		public DamageGwenR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x000380B4 File Offset: 0x000362B4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGwenR.damages[level] + 0.72 * (double)source.TotalMagicalDamage + (0.09 + (double)(source.TotalMagicalDamage / 100f) * 0.072) * (double)target.MaxHealth;
		}

		// Token: 0x040005DB RID: 1499
		private static readonly double[] damages = new double[]
		{
			270.0,
			495.0,
			720.0
		};
	}
}
