using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200034D RID: 845
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zyra", SpellSlot.R, 0)]
	public class DamageZyraR : DamageSpell
	{
		// Token: 0x06000FFF RID: 4095 RVA: 0x00044605 File Offset: 0x00042805
		public DamageZyraR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06001000 RID: 4096 RVA: 0x0004461B File Offset: 0x0004281B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZyraR.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000871 RID: 2161
		private static readonly double[] damages = new double[]
		{
			180.0,
			265.0,
			350.0
		};
	}
}
