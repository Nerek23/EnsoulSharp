using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001E0 RID: 480
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kayle", SpellSlot.Q, 0)]
	public class DamageKayleQ : DamageSpell
	{
		// Token: 0x06000BBC RID: 3004 RVA: 0x0003CEFF File Offset: 0x0003B0FF
		public DamageKayleQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0003CF15 File Offset: 0x0003B115
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKayleQ.damages[level] + 0.6 * (double)source.GetBonusPhysicalDamage() + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006E3 RID: 1763
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
