using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001BB RID: 443
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jax", SpellSlot.R, 0)]
	public class DamageJaxR : DamageSpell
	{
		// Token: 0x06000B4F RID: 2895 RVA: 0x0003C180 File Offset: 0x0003A380
		public DamageJaxR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0003C196 File Offset: 0x0003A396
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJaxR.damages[level] + (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006B8 RID: 1720
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
