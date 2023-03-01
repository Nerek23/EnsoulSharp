using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001D6 RID: 470
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kassadin", SpellSlot.E, 0)]
	public class DamageKassadinE : DamageSpell
	{
		// Token: 0x06000B9F RID: 2975 RVA: 0x0003CB1F File Offset: 0x0003AD1F
		public DamageKassadinE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0003CB35 File Offset: 0x0003AD35
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKassadinE.damages[level] + 0.85 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006D9 RID: 1753
		private static readonly double[] damages = new double[]
		{
			60.0,
			90.0,
			120.0,
			150.0,
			180.0
		};
	}
}
