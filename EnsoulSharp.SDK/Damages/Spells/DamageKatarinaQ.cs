using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001DB RID: 475
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Katarina", SpellSlot.Q, 0)]
	public class DamageKatarinaQ : DamageSpell
	{
		// Token: 0x06000BAE RID: 2990 RVA: 0x0003CD0D File Offset: 0x0003AF0D
		public DamageKatarinaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x0003CD23 File Offset: 0x0003AF23
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKatarinaQ.damages[level] + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006DF RID: 1759
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
