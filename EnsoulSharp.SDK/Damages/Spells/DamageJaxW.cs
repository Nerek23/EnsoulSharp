using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001BC RID: 444
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jax", SpellSlot.W, 0)]
	public class DamageJaxW : DamageSpell
	{
		// Token: 0x06000B52 RID: 2898 RVA: 0x0003C1BF File Offset: 0x0003A3BF
		public DamageJaxW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x0003C1D5 File Offset: 0x0003A3D5
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJaxW.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006B9 RID: 1721
		private static readonly double[] damages = new double[]
		{
			50.0,
			85.0,
			120.0,
			155.0,
			190.0
		};
	}
}
