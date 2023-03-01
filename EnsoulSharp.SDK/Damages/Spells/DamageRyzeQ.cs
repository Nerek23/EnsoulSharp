using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002A0 RID: 672
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ryze", SpellSlot.Q, 0)]
	public class DamageRyzeQ : DamageSpell
	{
		// Token: 0x06000DF9 RID: 3577 RVA: 0x00040C29 File Offset: 0x0003EE29
		public DamageRyzeQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x00040C3F File Offset: 0x0003EE3F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRyzeQ.damages[level] + 0.55 * (double)source.TotalMagicalDamage + 0.02 * (double)source.BonusMana;
		}

		// Token: 0x040007AF RID: 1967
		private static readonly double[] damages = new double[]
		{
			70.0,
			90.0,
			110.0,
			130.0,
			150.0
		};
	}
}
