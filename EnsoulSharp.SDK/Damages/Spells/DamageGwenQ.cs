using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000F8 RID: 248
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gwen", SpellSlot.Q, 0)]
	public class DamageGwenQ : DamageSpell
	{
		// Token: 0x060008F7 RID: 2295 RVA: 0x00038009 File Offset: 0x00036209
		public DamageGwenQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0003801F File Offset: 0x0003621F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGwenQ.damages[level] + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005D9 RID: 1497
		private static readonly double[] damages = new double[]
		{
			60.0,
			85.0,
			110.0,
			135.0,
			160.0
		};
	}
}
