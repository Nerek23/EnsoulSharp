using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002EE RID: 750
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("TwistedFate", SpellSlot.Q, 0)]
	public class DamageTwistedFateQ : DamageSpell
	{
		// Token: 0x06000EE3 RID: 3811 RVA: 0x00042705 File Offset: 0x00040905
		public DamageTwistedFateQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x0004271B File Offset: 0x0004091B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTwistedFateQ.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000808 RID: 2056
		private static readonly double[] damages = new double[]
		{
			60.0,
			100.0,
			140.0,
			180.0,
			220.0
		};
	}
}
