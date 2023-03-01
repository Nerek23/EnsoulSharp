using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000FC RID: 252
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gwen", SpellSlot.R, 2)]
	public class DamageGwenR2 : DamageSpell
	{
		// Token: 0x06000903 RID: 2307 RVA: 0x000381A0 File Offset: 0x000363A0
		public DamageGwenR2()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 2;
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x000381C0 File Offset: 0x000363C0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGwenR2.damages[level] + 0.24 * (double)source.TotalMagicalDamage + (0.03 + (double)(source.TotalMagicalDamage / 100f * 0.024f)) * (double)target.MaxHealth;
		}

		// Token: 0x040005DD RID: 1501
		private static readonly double[] damages = new double[]
		{
			90.0,
			165.0,
			240.0
		};
	}
}
