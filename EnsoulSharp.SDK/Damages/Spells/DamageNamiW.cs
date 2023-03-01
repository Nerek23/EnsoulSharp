using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200023F RID: 575
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nami", SpellSlot.W, 0)]
	public class DamageNamiW : DamageSpell
	{
		// Token: 0x06000CD7 RID: 3287 RVA: 0x0003ECB2 File Offset: 0x0003CEB2
		public DamageNamiW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x0003ECC8 File Offset: 0x0003CEC8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNamiW.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000744 RID: 1860
		private static readonly double[] damages = new double[]
		{
			70.0,
			110.0,
			150.0,
			190.0,
			230.0
		};
	}
}
