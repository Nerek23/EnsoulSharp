using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200020A RID: 522
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("MonkeyKing", SpellSlot.R, 1)]
	public class DamageMonkeyKingRA : DamageSpell
	{
		// Token: 0x06000C39 RID: 3129 RVA: 0x0003DC95 File Offset: 0x0003BE95
		public DamageMonkeyKingRA()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x0003DCB2 File Offset: 0x0003BEB2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMonkeyKingRA.damages[level] * (double)target.MaxHealth + 0.275 * (double)source.GetTotalAaDamage();
		}

		// Token: 0x0400070E RID: 1806
		private static readonly double[] damages = new double[]
		{
			0.01,
			0.015,
			0.02
		};
	}
}
