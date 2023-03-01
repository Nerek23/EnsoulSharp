using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002D7 RID: 727
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("TahmKench", SpellSlot.R, 0)]
	public class DamageTahmKenchR : DamageSpell
	{
		// Token: 0x06000E9E RID: 3742 RVA: 0x00041EB3 File Offset: 0x000400B3
		public DamageTahmKenchR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x00041EC9 File Offset: 0x000400C9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTahmKenchR.damages[level] + (double)((0.15f + source.TotalMagicalDamage / 100f * 0.07f) * target.MaxHealth);
		}

		// Token: 0x040007EE RID: 2030
		private static readonly double[] damages = new double[]
		{
			100.0,
			250.0,
			400.0
		};
	}
}
