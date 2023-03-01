using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200032F RID: 815
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Xerath", SpellSlot.W, 0)]
	public class DamageXerathW : DamageSpell
	{
		// Token: 0x06000FA6 RID: 4006 RVA: 0x00043C88 File Offset: 0x00041E88
		public DamageXerathW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x00043C9E File Offset: 0x00041E9E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageXerathW.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000851 RID: 2129
		private static readonly double[] damages = new double[]
		{
			60.0,
			95.0,
			130.0,
			165.0,
			200.0
		};
	}
}
