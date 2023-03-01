using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200033E RID: 830
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zoe", SpellSlot.W, 0)]
	public class DamageZoeW : DamageSpell
	{
		// Token: 0x06000FD3 RID: 4051 RVA: 0x000441A2 File Offset: 0x000423A2
		public DamageZoeW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x000441B8 File Offset: 0x000423B8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZoeW.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000862 RID: 2146
		private static readonly double[] damages = new double[]
		{
			75.0,
			105.0,
			135.0,
			165.0,
			195.0
		};
	}
}
