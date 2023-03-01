using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002A1 RID: 673
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ryze", SpellSlot.W, 0)]
	public class DamageRyzeW : DamageSpell
	{
		// Token: 0x06000DFC RID: 3580 RVA: 0x00040C84 File Offset: 0x0003EE84
		public DamageRyzeW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x00040C9A File Offset: 0x0003EE9A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRyzeW.damages[level] + 0.7 * (double)source.TotalMagicalDamage + 0.04 * (double)source.BonusMana;
		}

		// Token: 0x040007B0 RID: 1968
		private static readonly double[] damages = new double[]
		{
			80.0,
			110.0,
			140.0,
			170.0,
			200.0
		};
	}
}
