using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001CF RID: 463
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Karma", SpellSlot.Q, 0)]
	public class DamageKarmaQ : DamageSpell
	{
		// Token: 0x06000B8A RID: 2954 RVA: 0x0003C8B7 File Offset: 0x0003AAB7
		public DamageKarmaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0003C8CD File Offset: 0x0003AACD
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKarmaQ.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006D1 RID: 1745
		private static readonly double[] damages = new double[]
		{
			70.0,
			120.0,
			170.0,
			220.0,
			270.0
		};
	}
}
