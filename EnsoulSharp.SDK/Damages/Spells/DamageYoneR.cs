using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000328 RID: 808
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Yone", SpellSlot.R, 0)]
	public class DamageYoneR : DamageSpell
	{
		// Token: 0x06000F91 RID: 3985 RVA: 0x00043A82 File Offset: 0x00041C82
		public DamageYoneR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x00043A98 File Offset: 0x00041C98
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYoneR.damages[level] + 0.8 * (double)source.GetTotalAaDamage();
		}

		// Token: 0x0400084A RID: 2122
		private static readonly double[] damages = new double[]
		{
			200.0,
			400.0,
			600.0
		};
	}
}
