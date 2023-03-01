using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001C0 RID: 448
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jayce", SpellSlot.W, 0)]
	public class DamageJayceW : DamageSpell
	{
		// Token: 0x06000B5E RID: 2910 RVA: 0x0003C325 File Offset: 0x0003A525
		public DamageJayceW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x0003C33B File Offset: 0x0003A53B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJayceW.damages[level] + 0.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006BE RID: 1726
		private static readonly double[] damages = new double[]
		{
			35.0,
			50.0,
			65.0,
			80.0,
			95.0,
			1100.0
		};
	}
}
