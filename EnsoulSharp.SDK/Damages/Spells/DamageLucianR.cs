using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200021C RID: 540
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lucian", SpellSlot.R, 0)]
	public class DamageLucianR : DamageSpell
	{
		// Token: 0x06000C6F RID: 3183 RVA: 0x0003E206 File Offset: 0x0003C406
		public DamageLucianR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x0003E21C File Offset: 0x0003C41C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLucianR.damages[level] + 0.25 * (double)source.GetBonusAaDamage() + 0.15 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000721 RID: 1825
		private static readonly double[] damages = new double[]
		{
			15.0,
			30.0,
			45.0
		};
	}
}
