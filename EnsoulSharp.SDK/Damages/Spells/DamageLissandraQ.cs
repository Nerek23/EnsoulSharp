using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000218 RID: 536
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lissandra", SpellSlot.Q, 0)]
	public class DamageLissandraQ : DamageSpell
	{
		// Token: 0x06000C63 RID: 3171 RVA: 0x0003E0CE File Offset: 0x0003C2CE
		public DamageLissandraQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x0003E0E4 File Offset: 0x0003C2E4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLissandraQ.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400071C RID: 1820
		private static readonly double[] damages = new double[]
		{
			70.0,
			110.0,
			140.0,
			170.0,
			200.0
		};
	}
}
