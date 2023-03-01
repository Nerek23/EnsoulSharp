using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001E7 RID: 487
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kayn", SpellSlot.R, 0)]
	public class DamageKaynR : DamageSpell
	{
		// Token: 0x06000BD1 RID: 3025 RVA: 0x0003D144 File Offset: 0x0003B344
		public DamageKaynR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x0003D15A File Offset: 0x0003B35A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKaynR.damages[level] + 1.75 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x040006EB RID: 1771
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
