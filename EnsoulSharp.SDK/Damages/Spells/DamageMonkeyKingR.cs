using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000236 RID: 566
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("MonkeyKing", SpellSlot.R, 0)]
	public class DamageMonkeyKingR : DamageSpell
	{
		// Token: 0x06000CBC RID: 3260 RVA: 0x0003EA0F File Offset: 0x0003CC0F
		public DamageMonkeyKingR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x0003EA25 File Offset: 0x0003CC25
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMonkeyKingR.damages[level] * (double)target.MaxHealth + 0.275 * (double)source.GetTotalAaDamage() * 8.0;
		}

		// Token: 0x0400073B RID: 1851
		private static readonly double[] damages = new double[]
		{
			0.08,
			0.12,
			0.16
		};
	}
}
