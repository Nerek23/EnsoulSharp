using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000227 RID: 551
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Malzahar", SpellSlot.Q, 0)]
	public class DamageMalzaharQ : DamageSpell
	{
		// Token: 0x06000C90 RID: 3216 RVA: 0x0003E549 File Offset: 0x0003C749
		public DamageMalzaharQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x0003E55F File Offset: 0x0003C75F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMalzaharQ.damages[level] + 0.55 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400072C RID: 1836
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0,
			175.0,
			210.0
		};
	}
}
