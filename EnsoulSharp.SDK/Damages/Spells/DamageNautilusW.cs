using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000247 RID: 583
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nautilus", SpellSlot.W, 0)]
	public class DamageNautilusW : DamageSpell
	{
		// Token: 0x06000CEF RID: 3311 RVA: 0x0003EF12 File Offset: 0x0003D112
		public DamageNautilusW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x0003EF28 File Offset: 0x0003D128
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNautilusW.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400074C RID: 1868
		private static readonly double[] damages = new double[]
		{
			30.0,
			40.0,
			50.0,
			60.0,
			70.0
		};
	}
}
