using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002D1 RID: 721
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Syndra", SpellSlot.Q, 0)]
	public class DamageSyndraQ : DamageSpell
	{
		// Token: 0x06000E8C RID: 3724 RVA: 0x00041CF1 File Offset: 0x0003FEF1
		public DamageSyndraQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x00041D07 File Offset: 0x0003FF07
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSyndraQ.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007E8 RID: 2024
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0,
			175.0,
			262.5
		};
	}
}
