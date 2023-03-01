using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200031C RID: 796
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vladimir", SpellSlot.Q, 1)]
	public class DamageVladimirQ1 : DamageSpell
	{
		// Token: 0x06000F6D RID: 3949 RVA: 0x0004369D File Offset: 0x0004189D
		public DamageVladimirQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x000436BA File Offset: 0x000418BA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVladimirQ1.damages[level] + 1.11 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400083C RID: 2108
		private static readonly double[] damages = new double[]
		{
			148.0,
			185.0,
			222.0,
			259.0,
			296.0
		};
	}
}
