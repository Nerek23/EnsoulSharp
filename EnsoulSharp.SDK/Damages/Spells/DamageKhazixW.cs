using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001F5 RID: 501
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Khazix", SpellSlot.W, 0)]
	public class DamageKhazixW : DamageSpell
	{
		// Token: 0x06000BFA RID: 3066 RVA: 0x0003D5AA File Offset: 0x0003B7AA
		public DamageKhazixW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0003D5C0 File Offset: 0x0003B7C0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKhazixW.damages[level] + (double)(1f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x040006F9 RID: 1785
		private static readonly double[] damages = new double[]
		{
			85.0,
			115.0,
			145.0,
			175.0,
			205.0
		};
	}
}
