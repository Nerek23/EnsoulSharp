using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000FD RID: 253
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gwen", SpellSlot.R, 1)]
	public class DamageGwenR1 : DamageSpell
	{
		// Token: 0x06000906 RID: 2310 RVA: 0x00038224 File Offset: 0x00036424
		public DamageGwenR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00038244 File Offset: 0x00036444
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGwenR1.damages[level] + 0.08 * (double)source.TotalMagicalDamage + (0.01 + (double)(source.TotalMagicalDamage / 100f * 0.008f)) * (double)target.MaxHealth;
		}

		// Token: 0x040005DE RID: 1502
		private static readonly double[] damages = new double[]
		{
			35.0,
			65.0,
			95.0
		};
	}
}
