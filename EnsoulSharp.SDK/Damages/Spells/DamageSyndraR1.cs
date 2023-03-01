using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002D3 RID: 723
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Syndra", SpellSlot.R, 1)]
	public class DamageSyndraR1 : DamageSpell
	{
		// Token: 0x06000E92 RID: 3730 RVA: 0x00041D96 File Offset: 0x0003FF96
		public DamageSyndraR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x00041DB3 File Offset: 0x0003FFB3
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSyndraR1.damages[level] + 0.17 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007EA RID: 2026
		private static readonly double[] damages = new double[]
		{
			90.0,
			130.0,
			170.0
		};
	}
}
