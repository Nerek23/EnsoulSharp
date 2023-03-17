using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000306 RID: 774
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Xayah", SpellSlot.E, 0)]
	public class DamageXayahE : DamageSpell
	{
		// Token: 0x06000F2B RID: 3883 RVA: 0x00042F5A File Offset: 0x0004115A
		public DamageXayahE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x00042F70 File Offset: 0x00041170
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageXayahE.damages[level] + 0.6 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000824 RID: 2084
		private static readonly double[] damages = new double[]
		{
			50.0,
			60.0,
			70.0,
			80.0,
			90.0
		};
	}
}
