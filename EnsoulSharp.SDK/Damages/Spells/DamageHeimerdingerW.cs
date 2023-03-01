using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001A6 RID: 422
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Heimerdinger", SpellSlot.W, 0)]
	public class DamageHeimerdingerW : DamageSpell
	{
		// Token: 0x06000B0A RID: 2826 RVA: 0x0003BB86 File Offset: 0x00039D86
		public DamageHeimerdingerW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0003BB9C File Offset: 0x00039D9C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageHeimerdingerW.damages[level] + 0.93 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006A6 RID: 1702
		private static readonly double[] damages = new double[]
		{
			90.0,
			135.0,
			180.0,
			225.0,
			270.0
		};
	}
}
