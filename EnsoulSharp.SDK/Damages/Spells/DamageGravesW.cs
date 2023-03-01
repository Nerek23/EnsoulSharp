using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200019F RID: 415
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Graves", SpellSlot.W, 0)]
	public class DamageGravesW : DamageSpell
	{
		// Token: 0x06000AF5 RID: 2805 RVA: 0x0003B94F File Offset: 0x00039B4F
		public DamageGravesW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0003B965 File Offset: 0x00039B65
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGravesW.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400069F RID: 1695
		private static readonly double[] damages = new double[]
		{
			60.0,
			110.0,
			160.0,
			210.0,
			260.0
		};
	}
}
